Imports FarPoint.CalcEngine
Imports System.Threading
Imports Microsoft.Office.Interop
Imports System.IO.File
Class Form_Main
    Private th As Thread
    Public Const dataColumnCount As Integer = 109
    'No,PartCategory , PartName,Direction, Year, Model, Event,Seq,Note, DateTime ==> 10 EA
    'MeasurementMode(Ref/Trans),Specular component, UV, STD Illuminantm , Observer .z
    '380~780,Δ5nm  ==>  81EA
    Const PIC_SEQUENCE1_HEIGHT As Integer = 230
    Const PIC_SEQUENCE2_HEIGHT As Integer = 150
    Const PIC_SEQUENCE3_HEIGHT As Integer = 130
    Const PIC_SEQUENCE4_HEIGHT As Integer = 260
    Public Const SPECTRUM_START As Integer = 380
    Public Const SPECTRUM_END As Integer = 780
    Public Const SPECTRUM_INTERVAL As Integer = 5

    'Column width of datagrid(table)
    Const COLUMNWIDTH_XS As Integer = 40
    Const COLUMNWIDTH_S As Integer = 60
    Const COLUMNWIDTH_M As Integer = 80
    Const COLUMNWIDTH_L As Integer = 150
    Const COLUMNWIDTH_XL As Integer = 200
    Const SERIALCOMMDELAY As Integer = 200

    Public Const measureTime As Integer = 8000
    Public Const calibrationTime As Integer = 1000

    Public Const PART_IN_DATAGRIDVIEW As Integer = 1
    Public Const PART_CATEGORY_IN_DATAGRIDVIEW As Integer = 2
    Public Const PART_NAME_IN_DATAGRIDVIEW As Integer = 3
    Public Const DIRECTION_IN_DATAGRIDVIEW As Integer = 4
    Public Const YEAR_IN_DATAGRIDVIEW As Integer = 5
    Public Const MODEL_NAME_IN_DATAGRIDVIEW As Integer = 6
    Public Const EVENT_IN_DATAGRIDVIEW As Integer = 7
    Public Const SEQUENCE_IN_DATAGRIDVIEW As Integer = 8
    Public Const NOTE_IN_DATAGRIDVIEW As Integer = 9
    Public Const YI_COLUMN_IN_DATAGRIDVIEW As Integer = 10
    Public Const LSTAR_COLUMN_IN_DATAGRIDVIEW As Integer = 11
    Public Const ASTAR_COLUMN_IN_DATAGRIDVIEW As Integer = 12
    Public Const BSTART_COLUMN_IN_DATAGRIDVIEW As Integer = 13
    Public Const X_COLUMN_IN_DATAGRIDVIEW As Integer = 14
    Public Const Y_COLUMN_IN_DATAGRIDVIEW As Integer = 15
    Public Const Z_COLUMN_IN_DATAGRIDVIEW As Integer = 16
    Public Const x1931_COLUMN_IN_DATAGRIDVIEW As Integer = 17
    Public Const y1931_COLUMN_IN_DATAGRIDVIEW As Integer = 18
    Public Const uprime1976_COLUMN_IN_DATAGRIDVIEW As Integer = 19
    Public Const vprime1976_COLUMN_IN_DATAGRIDVIEW As Integer = 20
    Public Const SPECTRUM_START_COLUMN_IN_DATAGRIDVIEW As Integer = 21
    Public Const DATETIME_MEASURED_IN_DATAGRIDVIEW As Integer = 102
    Public Const MEASUREMENT_METHOD_IN_DATAGRIDVIEW As Integer = 103
    Public Const SPECULAR_COMPONENT_IN_DATAGRIDVIEW As Integer = 104
    Public Const UV_IN_DATAGRIDVIEW As Integer = 105
    Public Const STANDARD_ILLUMINANT_IN_DATAGRIDVIEW As Integer = 106
    Public Const OBSERVER_IN_DATAGRIDVIEW As Integer = 107
    Public Const MEASURING_APERTURE_IN_DATAGRIDVIEW As Integer = 108

    Public spectrumCount As Integer

    Public init_ZeroCal As Integer = 0
    Public init_standardCal As Integer = 0
    Public init_SerialCom As Integer = 0
    Public apertureSizeAtCalibration As String = ""
    Public columnNameArray() As String
    Public dataRow_Cnt As Integer = 1

    Public zeroCal_stand_yesORno As Integer = 0
    Public standardCal_stand_yeaOrno As Integer = 0
    Public sample_Hole_Size As String = ""

    Public blackThreshold As Single = 0.1
    Public whiteThreshold As Single = 95.0

    Public Chart_Color() As Color = {Color.Black, Color.Red, Color.Blue, Color.Green, Color.Magenta, Color.Yellow, Color.DarkCyan, Color.DarkGray, Color.DarkOliveGreen, Color.DarkOrange} ' define 10 color

    Public selectedData() As String
    '※※※※※※※※※※※구조체 내 수치타입 , Single or Double 추후 확정필요※※※※※※※※※※
    Public Structure measuredData
        Dim No As Integer
        Dim Part_PK, Part_Name_PK, MechaPartPK As Integer
        Dim Maker, Part_Rev As String
        Dim Part, Part_Category, Part_Name, Direction, MP_Year, Dev_Model, Dev_Event As String
        Dim Sequence As Integer
        Dim Note As String
        Dim YI_ASTM_E313_73, L_Star, a_Star, b_Star, X, Y, Z, CIE_x, CIE_y, u_prime, v_prime As Single
        Dim Spectrum() As Single
        Dim DateTime, Measurement_Method, Specular_Component, UV, STD_Illuminants, Observer, MeasuringAperture As String
        Dim instrument As String
    End Structure
    Public currentMeasuredData As New measuredData
    Private Sub Button2_Click(sender As Object, e As EventArgs)
        MsgBox(MatchFunctionInfo.ZTestFunction)
    End Sub
    Private Sub initilize_dataGridView_ColumnName(cnt As Integer) 'cnt = number of spectrum data
        Dim i As Integer
        i = 0
        ReDim columnNameArray(dataColumnCount - 1)
        Dim arr1(), arr2(), arr3() As String
        ReDim arr1(19)
        ReDim arr2(cnt - 1)
        ReDim arr3(6)

        arr1 = {
                                        "No.",   '0
                                        "Part", '1
                                        "Part Category",  '2
                                        "Part Name",   '3
                                        "Direction",  '4
                                        "MP Year", '5
                                        "Model Name", '6
                                        "Event", '7
                                        "Seq.", '8
                                        "note", '9
                                        "YI ASTM E313-73", '10
                                        "L*", '11
                                        "a*", '12
                                        "b*", '13
                                        "X", '14
                                        "Y", '15
                                        "Z", '16
                                        "CIE x", '17
                                        "CIE y", '18
                                        "u'", '19
                                        "v'" '20
                                   }

        i = 0

        For i = 0 To (cnt - 1) '0~   for SD4000,380~780, interval 5nm = 81ea
            arr2(i) = (SPECTRUM_START + SPECTRUM_INTERVAL * (i) & " nm")
        Next i

        arr3 = {
        "DateTime", '102
        "Measruement Method", '103
        "Specular component", '104
        "UV", '105
        "Standard Illuminant", '106
        "Observer", '107
        "Measuring Aperture"  '108
        }

        Dim j, k As Integer
        j = 0
        k = 0

        For j = 0 To UBound(columnNameArray)
            If j <= UBound(arr1) Then
                columnNameArray(j) = arr1(j)  '0~19, Ubound(arr1) = 19
            ElseIf j <= UBound(arr1) + UBound(arr2) + 1 Then '20~100 Ubound(arr1) = 19, UBound(arr2) = 80
                columnNameArray(j) = arr2(j - UBound(arr1) - 1)
            ElseIf j <= UBound(arr1) + UBound(arr2) + UBound(arr3) + 2 Then '101~107, Ubound(arr1)=19, Ubound(arr2) = 80, Ubound(arr3) = 6
                columnNameArray(j) = arr3(j - UBound(arr1) - UBound(arr2) - 2)
            End If
        Next j

    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim j As Integer
        Dim combo_Direction As DataGridViewComboBoxColumn = New DataGridViewComboBoxColumn
        Dim spectrum_Chart_Area As DataVisualization.Charting.ChartArea

        Call initSerialCommunication()
        Call setButtonStatus(init_SerialCom)

        spectrumCount = (SPECTRUM_END - SPECTRUM_START) / SPECTRUM_INTERVAL + 1 'for SD4000, Spectrum_count is  81

        Call set_picture_height(0, 0, 0, 0)
        DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        DataGridView1.ColumnCount = dataColumnCount

        Dim nowYear As Integer
        Dim i As Integer
        Dim retStr As String
        Dim delimeter As String = ","
        Dim itemList() As String

        Me.year.Items.Clear()

        retStr = connectWithDB.getComboItemsFromDB("optics.M_Optic_Part", "Category", "", "", delimeter)
        itemList = Split(retStr, delimeter)
        itemList = itemList.Distinct.ToArray
        Me.part.Items.AddRange(itemList)

        itemList = Nothing

        'Me.part_Category.Items.AddRange(New Object() {"Reflector Sheet", "Diffuser Plate", "Prism Sheet", "Diffuser Sheet", "Complex Sheet", "NOF Sheet", "Panel", "ETC"})

        nowYear = Now.Year
        For i = -3 To 3
            Me.year.Items.Add("Y" & Strings.Right((nowYear + i), 2))
        Next i

        'SET DataGrid HEADER
        Call initilize_dataGridView_ColumnName(spectrumCount)
        SetTableColumnProperty(DataGridView1.Columns(0), columnNameArray(0), COLUMNWIDTH_XS, True) 'Data_No
        SetTableColumnProperty(DataGridView1.Columns(PART_CATEGORY_IN_DATAGRIDVIEW), columnNameArray(PART_CATEGORY_IN_DATAGRIDVIEW), COLUMNWIDTH_L, True) 'Part_Category
        SetTableColumnProperty(DataGridView1.Columns(PART_NAME_IN_DATAGRIDVIEW), columnNameArray(PART_NAME_IN_DATAGRIDVIEW), COLUMNWIDTH_L, True) 'Part_Name
        SetTableColumnProperty(DataGridView1.Columns(DIRECTION_IN_DATAGRIDVIEW), columnNameArray(DIRECTION_IN_DATAGRIDVIEW), COLUMNWIDTH_M, False) 'direction
        SetTableColumnProperty(DataGridView1.Columns(YEAR_IN_DATAGRIDVIEW), columnNameArray(YEAR_IN_DATAGRIDVIEW), COLUMNWIDTH_S, False) 'year
        SetTableColumnProperty(DataGridView1.Columns(MODEL_NAME_IN_DATAGRIDVIEW), columnNameArray(MODEL_NAME_IN_DATAGRIDVIEW), COLUMNWIDTH_L, False) 'Model
        SetTableColumnProperty(DataGridView1.Columns(EVENT_IN_DATAGRIDVIEW), columnNameArray(EVENT_IN_DATAGRIDVIEW), COLUMNWIDTH_M, False) 'event
        SetTableColumnProperty(DataGridView1.Columns(SEQUENCE_IN_DATAGRIDVIEW), columnNameArray(SEQUENCE_IN_DATAGRIDVIEW), COLUMNWIDTH_XS, False) 'sequence
        SetTableColumnProperty(DataGridView1.Columns(NOTE_IN_DATAGRIDVIEW), columnNameArray(NOTE_IN_DATAGRIDVIEW), COLUMNWIDTH_XL, False) 'note
        'SetTableColumnProperty (DataGridView1.Columns(9), columnNameArray(9), ColumnWidth_S,)

        For j = 9 To 9 + 11 + (spectrumCount - 1)   '9= 측정데이타 앞의 description개수, YI ASTM~v'(1976)까지의 개수 11
            SetTableColumnProperty(DataGridView1.Columns(j), columnNameArray(j), COLUMNWIDTH_S, True) 'measured values
        Next j

        SetTableColumnProperty(DataGridView1.Columns(DATETIME_MEASURED_IN_DATAGRIDVIEW), columnNameArray(DATETIME_MEASURED_IN_DATAGRIDVIEW), COLUMNWIDTH_L, True) 'DateTime
        SetTableColumnProperty(DataGridView1.Columns(MEASUREMENT_METHOD_IN_DATAGRIDVIEW), columnNameArray(MEASUREMENT_METHOD_IN_DATAGRIDVIEW), COLUMNWIDTH_M, True) 'Measurement Method
        SetTableColumnProperty(DataGridView1.Columns(SPECULAR_COMPONENT_IN_DATAGRIDVIEW), columnNameArray(SPECULAR_COMPONENT_IN_DATAGRIDVIEW), COLUMNWIDTH_M, True) 'Specular component
        SetTableColumnProperty(DataGridView1.Columns(UV_IN_DATAGRIDVIEW), columnNameArray(UV_IN_DATAGRIDVIEW), COLUMNWIDTH_XS, True) 'UV
        SetTableColumnProperty(DataGridView1.Columns(STANDARD_ILLUMINANT_IN_DATAGRIDVIEW), columnNameArray(STANDARD_ILLUMINANT_IN_DATAGRIDVIEW), COLUMNWIDTH_XS, True) 'standard Illuminant
        SetTableColumnProperty(DataGridView1.Columns(OBSERVER_IN_DATAGRIDVIEW), columnNameArray(OBSERVER_IN_DATAGRIDVIEW), COLUMNWIDTH_M + 15, True) 'observer
        SetTableColumnProperty(DataGridView1.Columns(MEASURING_APERTURE_IN_DATAGRIDVIEW), columnNameArray(MEASURING_APERTURE_IN_DATAGRIDVIEW), COLUMNWIDTH_S, True) 'Measuring Aperture

        spectrum_Chart_Area = spectrum_Chart.ChartAreas(0)
        With spectrum_Chart_Area
            With .AxisX
                .Title = "wavelength(nm)"
                .TitleFont = New System.Drawing.Font("LG Smart UI", 10, FontStyle.Regular)
                .MajorGrid.LineColor = Color.LightBlue
                .Minimum = SPECTRUM_START
                .Maximum = SPECTRUM_END
                .Interval = 50
            End With
            With .AxisY
                .Title = "Reflectance(%)"
                .TitleFont = New System.Drawing.Font("LG Smart UI", 10, FontStyle.Regular)
                .MajorGrid.LineColor = Color.LightBlue
                .Interval = 10
            End With

            .BackColor = Color.FloralWhite
            .BackSecondaryColor = Color.White
            .BackGradientStyle = DataVisualization.Charting.GradientStyle.HorizontalCenter
            .BorderColor = Color.Gray
            .BorderDashStyle = DataVisualization.Charting.ChartDashStyle.Solid
            .BorderWidth = 1
            .ShadowOffset = 2
        End With

        Dim spectrumChartTitle As New DataVisualization.Charting.Title
        With spectrumChartTitle
            .Text = "Reflectance Spectrum(Δ5 nm)"
            .Alignment = StringAlignment.Far
            .Docking = DataVisualization.Charting.Docking.Top
            .Font = New System.Drawing.Font("LG Smart UI", 10, FontStyle.Bold)
            .ForeColor = Color.Black
        End With
        spectrum_Chart.Titles.Add(spectrumChartTitle)

        Dim LabChartTitle As New DataVisualization.Charting.Title
        With LabChartTitle
            .Text = "        a*/b*"
            .Alignment = StringAlignment.Near
            .Docking = DataVisualization.Charting.Docking.Top
            .Font = New System.Drawing.Font("LG Smart UI", 10, FontStyle.Bold)
            .ForeColor = Color.Black
        End With
        Labchart.Titles.Add(LabChartTitle)


        Dim xyChartTitle As New DataVisualization.Charting.Title
        With xyChartTitle
            .Text = "x,y (CIE 1931)"
            .Alignment = StringAlignment.Far
            .Docking = DataVisualization.Charting.Docking.Top
            .Font = New System.Drawing.Font("LG Smart UI", 10, FontStyle.Bold)
            .ForeColor = Color.Black
        End With
        xyChart.Titles.Add(xyChartTitle)

        Dim uvChartTitle As New DataVisualization.Charting.Title
        With uvChartTitle
            .Text = "u'v' (CIE 1976)"
            .Alignment = StringAlignment.Far
            .Docking = DataVisualization.Charting.Docking.Top
            .Font = New System.Drawing.Font("LG Smart UI", 10, FontStyle.Bold)
            .ForeColor = Color.Black
        End With
        uvChart.Titles.Add(uvChartTitle)

        Dim LChartTitle As New DataVisualization.Charting.Title
        With LChartTitle
            .Text = "L*" & vbCrLf & "(Brightness, 명도)"
            .Alignment = StringAlignment.Far
            .Docking = DataVisualization.Charting.Docking.Top
            .Font = New System.Drawing.Font("LG Smart UI", 10, FontStyle.Bold)
            .ForeColor = Color.Black
        End With
        Lchart.Titles.Add(LChartTitle)

        Dim YChartTitle As New DataVisualization.Charting.Title
        With YChartTitle
            .Text = "Y " & vbCrLf & "(Reflectance @548 nm)"
            .Alignment = StringAlignment.Far
            .Docking = DataVisualization.Charting.Docking.Top
            .Font = New System.Drawing.Font("LG Smart UI", 10, FontStyle.Bold)
            .ForeColor = Color.Black
        End With
        YChart.Titles.Add(YChartTitle)

        DataGridView1.AllowUserToAddRows = False
        lbl_userInfo.Text = Form_Login.currentLoginInfo.displayName
    End Sub
    Private Sub SetTableColumnProperty(a As DataGridViewColumn, col_Name As String, col_width As Integer, selectReadonly As Boolean)
        a.Name = col_Name
        a.Width = col_width
        a.ReadOnly = selectReadonly
    End Sub
    Private Sub initSerialCommunication()
        Dim tempStr As String

        serialPort.PortName = cmb_PortNo.Text
        serialPort.BaudRate = cmb_Baudrate.Text
        serialPort.DataBits = CInt(Strings.Left(cmb_DataBits.Text, 1))

        If CInt(cmb_StopBits.Text) = 1 Then
            serialPort.StopBits = IO.Ports.StopBits.One
        ElseIf CInt(cmb_StopBits.Text) = 2 Then
            serialPort.StopBits = IO.Ports.StopBits.Two
        ElseIf CInt(cmb_StopBits.Text) = 1.5 Then
            serialPort.StopBits = IO.Ports.StopBits.OnePointFive
        ElseIf cmb_StopBits.Text = "none" Then
            serialPort.StopBits = IO.Ports.StopBits.None
        End If

        If cmb_Parity.Text = "none" Then
            serialPort.Parity = IO.Ports.Parity.None
        ElseIf cmb_Parity.Text = "even" Then
            serialPort.Parity = IO.Ports.Parity.Even
        ElseIf cmb_Parity.Text = "odd" Then
            serialPort.Parity = IO.Ports.Parity.Odd
        End If
        serialPort.ReadTimeout = 500

        Try
            serialPort.Open()
            '--------------------------------------------------------------------------------------------
            ' below process is meanless, but just do process because Color_Mate Program do these process
            '--------------------------------------------------------------------------------------------
            tempStr = serialCommunicationResponse(SD4000_CMD.initialization)
            If tempStr.Contains("SD") Then

                serialCommunicationResponse(SD4000_CMD.getInstrumentInfo)

                If Not (readInstrumentSetting()) Then
                    Exit Sub
                End If
                'serialCommunicationResponse(SD4000_CMD.getInstrumentStatus)

                tempStr = serialCommunicationResponse(setWPMparameters) 'set command 'WPM.xxx.xxx.xxx
                If tempStr.Contains("ACK") Then
                Else
                    MsgBox("measuredData Condition Setting Error!")
                    Exit Sub
                End If
                serialCommunicationResponse(SD4000_CMD.getCalibrationNo)

                serialCommunicationResponse(SD4000_CMD.getCalibrationSN)

                serialCommunicationResponse(SD4000_CMD.getCalibrationDate)

                'serialCommunicationResponse(SD4000_CMD.getInstrumentStatus)

                If Not (readInstrumentSetting()) Then
                    Exit Sub
                End If
            Else
                MsgBox("not Connected.Check communication")
                pic_serialConnectivity.Image = My.Resources.redlight
                init_SerialCom = 0
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox("Turn on Instrument" & vbCrLf & ex.Message)
            pic_serialConnectivity.Image = My.Resources.redlight
            init_SerialCom = 0
            Exit Sub
        End Try

        init_SerialCom = 1
        pic_serialConnectivity.Image = My.Resources.greenlight
    End Sub
    Sub setButtonStatus(status As Boolean)
        btn_ZeroCalibration.Enabled = status
        btn_StandardCalibration.Enabled = status
        btn_DoMeasurement.Enabled = status

    End Sub
    Sub set_picture_height(a As Integer, b As Integer, c As Integer, d As Integer)
        pic_sequence1.Height = a
        pic_sequence2.Height = b
        pic_sequence3.Height = c
        pic_sequence4.Height = d
    End Sub
    Private Sub Panel3_MouseUp(sender As Object, e As MouseEventArgs) Handles Panel3.MouseUp, Label1.MouseUp
        Panel3.Width = 240
    End Sub
    Private Sub btn_ZeroCalibration_Click(sender As Object, e As EventArgs) Handles btn_ZeroCalibration.Click
        Dim retStr As String
        Dim formerTime, laterTime As Date
        Dim deltaTime As TimeSpan

        retStr = ""

        Call readInstrumentSetting()

        formerTime = Now
        Try
            retStr = serialCommunicationResponse(SD4000_CMD.doZeroCalibration)
            While retStr = Nothing
                Thread.Sleep(calibrationTime)
                retStr = serialPort.ReadExisting
            End While

            txt_ReceivedSerialTxt.AppendText("received : " & Trim(Strings.Replace(retStr, vbCrLf, "") & vbCrLf))
            If SD4000_CMD.getCalibrationResult(SD4000_CMD.doZeroCalibration, Trim(Strings.Replace(retStr, vbCrLf, ""))) Then
                laterTime = Now
                deltaTime = laterTime - formerTime
                txt_ReceivedSerialTxt.AppendText("Zero Cal. Time : " & deltaTime.ToString & vbCrLf)
                txt_ReceivedSerialTxt.AppendText("-------Zero-Calibraion Done------" & vbCrLf)
                init_ZeroCal = 1
            Else
                init_ZeroCal = 0
                Exit Sub
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            init_ZeroCal = 0
            Exit Sub
        End Try

        Thread.Sleep(calibrationTime)
        readInstrumentSetting()

        btn_ZeroCalibration.ForeColor = Color.Gray
        Call btn_StandardCalibration_MouseHover_1(sender, e)

    End Sub

    Private Sub btn_ZeroCalibration_MouseHover_1(sender As Object, e As EventArgs) Handles btn_ZeroCalibration.MouseHover
        Call Panel3_MouseLeave(sender, e)
        Call set_picture_height(PIC_SEQUENCE1_HEIGHT, PIC_SEQUENCE2_HEIGHT, 0, 0)
        Call MoveCursor(btn_ZeroCalibration)
    End Sub

    Private Sub btn_StandardCalibration_Click(sender As Object, e As EventArgs) Handles btn_StandardCalibration.Click
        Dim retStr As String
        Dim formerTime, laterTime As Date
        Dim deltaTime As TimeSpan

        If init_ZeroCal = 0 Then
            MsgBox("Do Zero_Calibration")
            Call btn_ZeroCalibration_MouseHover_1(sender, e)
            Exit Sub
        End If

        retStr = ""
        Call readInstrumentSetting()
        formerTime = Now

        Try
            retStr = serialCommunicationResponse(SD4000_CMD.doStandardCalibration)
            While retStr = Nothing
                Thread.Sleep(calibrationTime)
                retStr = serialPort.ReadExisting
            End While

            txt_ReceivedSerialTxt.AppendText("received : " & Trim(Strings.Replace(retStr, vbCrLf, "") & vbCrLf))
            If SD4000_CMD.getCalibrationResult(SD4000_CMD.doStandardCalibration, Trim(Strings.Replace(retStr, vbCrLf, ""))) Then
                laterTime = Now
                deltaTime = laterTime - formerTime
                txt_ReceivedSerialTxt.AppendText("Standard Cal. Time : " & deltaTime.ToString & vbCrLf)
                txt_ReceivedSerialTxt.AppendText("------Standard-Calibraion Done------" & vbCrLf)
                init_standardCal = 1
            Else
                init_standardCal = 0
                Exit Sub
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            init_standardCal = 0
            Exit Sub
        End Try

        Thread.Sleep(calibrationTime)
        readInstrumentSetting()

        btn_StandardCalibration.ForeColor = Color.Gray
        Call btn_DoMeasurement_MouseHover_1(sender, e)

    End Sub
    Private Sub btn_StandardCalibration_MouseHover_1(sender As Object, e As EventArgs) Handles btn_StandardCalibration.MouseHover
        Call Panel3_MouseLeave(sender, e)
        Call set_picture_height(0, 0, PIC_SEQUENCE3_HEIGHT, 0)
        Call MoveCursor(btn_StandardCalibration)
    End Sub
    Private Sub btn_DoMeasurement_Click(sender As Object, e As EventArgs) Handles btn_DoMeasurement.Click
        Dim sendWPM, receivedRPM As String
        Dim retStr As String
        Dim formerTime, laterTime As Date
        Dim deltaTime As TimeSpan
        Dim resultDelimetedByComma() As String

        Call readInstrumentSetting()

        If init_ZeroCal = 0 Then
            MsgBox("Zero-Calibration, Again")
            Exit Sub
        End If
        If init_standardCal = 0 Then
            MsgBox("Again Standard-Calibration, Again")
            Exit Sub
        End If
        '---------------------------------------------------------------
        ' pre-process to measure reflectance
        '---------------------------------------------------------------
        sendWPM = setWPMparameters()
        retStr = Trim(serialCommunicationResponse(sendWPM))
        If retStr = "ACK" Then
        Else
            MsgBox("Error while sending WPM")
            Exit Sub
        End If

        sendWPM = Strings.Right(sendWPM, 16)

        receivedRPM = Trim(serialCommunicationResponse(getMeasurementMode))
        receivedRPM = Strings.Right(receivedRPM, 16)

        txt_ReceivedSerialTxt.AppendText(sendWPM & vbCrLf)
        txt_ReceivedSerialTxt.AppendText(receivedRPM & vbCrLf)
        If sendWPM <> receivedRPM Then
            MsgBox("SettingWPM and ReadWPM are dirrerent.")
            Exit Sub
        End If

        Call setSettingParamsForPopup() 'Settings에 DataGridView1의 마지막줄 파라메타들을 먼저 설정한다.
        '--------------------------------------------------------
        'Do Measure
        '--------------------------------------------------------
        retStr = ""
        formerTime = Now

        th = New Thread(AddressOf ThreadPopupTask)
        th.IsBackground = True
        th.Start()

        'Form_PartInfo_Submit.ShowDialog()
        Try
            retStr = serialCommunicationResponse(SD4000_CMD.doMeasurement)

            While retStr = Nothing
                Thread.Sleep(measureTime)
                retStr = serialPort.ReadExisting
            End While
            txt_ReceivedSerialTxt.AppendText("received : " & retStr & vbCrLf)
            laterTime = Now
            deltaTime = laterTime - formerTime
            txt_ReceivedSerialTxt.AppendText("Measured Time : " & deltaTime.ToString & vbCrLf)
            txt_ReceivedSerialTxt.AppendText("------Measurement Done------" & vbCrLf)
        Catch ex As Exception
            MsgBox("Measurement Failed" & vbCrLf & ex.Message)
            Exit Sub
        End Try

        While th.IsAlive
            Me.Enabled = False
        End While
        Me.Enabled = True
        Me.BringToFront()
        '--------------------------------------------------------
        'Handling Spectrum Data
        '--------------------------------------------------------
        'Dim resultDelimetedByNewLine() As String   'for SCI+SCE

        currentMeasuredData.Sequence = "1"
        'resultDelimetedByNewLine = Strings.Split(result, vbCrLf)
        resultDelimetedByComma = Strings.Split(retStr, ",")

        If UBound(resultDelimetedByComma) < 89 Then ' sci or sce , Comma delimeted Data count

            Call setDataonDataGridView1(resultDelimetedByComma)

            If DataGridView1.RowCount > 1 Then
                DataGridView1.CurrentCell = DataGridView1.Rows(DataGridView1.Rows.Count - 1).Cells(0)
                Call DataGridView1_SelectionChanged(sender, e)
            Else
            End If

        End If
        dataRow_Cnt += +1
    End Sub
    Private Sub setSettingParamsForPopup()
        Dim rowDataStr As DataGridViewCellCollection
        Dim selectedRows As DataGridViewSelectedRowCollection
        ' Debug.Print("IN Selection changed of Datagridview")

        If DataGridView1.RowCount > 0 Then
            Try
                selectedRows = DataGridView1.SelectedRows
                rowDataStr = selectedRows(0).Cells()

                My.Settings.tempPartCategory = rowDataStr(PART_CATEGORY_IN_DATAGRIDVIEW).Value
                My.Settings.tempPartName = rowDataStr(PART_NAME_IN_DATAGRIDVIEW).Value
                My.Settings.tempPartDirection = rowDataStr(DIRECTION_IN_DATAGRIDVIEW).Value
                My.Settings.tempMPYear = rowDataStr(YEAR_IN_DATAGRIDVIEW).Value
                My.Settings.tempMPModel = rowDataStr(MODEL_NAME_IN_DATAGRIDVIEW).Value
                My.Settings.tempMPEvent = rowDataStr(EVENT_IN_DATAGRIDVIEW).Value
                My.Settings.tempNote = rowDataStr(NOTE_IN_DATAGRIDVIEW).Value
            Catch ex As Exception
                MsgBox(ex.Message)
                Exit Sub
            End Try
        Else

        End If
    End Sub
    Private Sub setDataonDataGridView1(rawDataFromInstrument As String())
        Dim currentDataGridRow(dataColumnCount - 1) As String
        Dim measuredSpectrum() As Single
        ReDim measuredSpectrum(spectrumCount - 1)
        Dim observer As String
        Dim standardIlluminant As String
        Dim i As Integer

        currentMeasuredData = Nothing
        observer = Trim(Me.cmb_Observer.Text)
        standardIlluminant = Trim(Me.cmb_StandardIlluminant.Text)

        For i = 0 To spectrumCount - 1   'Spectrum from 380 to 780 nm, interval 5 nm
            currentDataGridRow(i + SPECTRUM_START_COLUMN_IN_DATAGRIDVIEW) = rawDataFromInstrument(i + 4)
            measuredSpectrum(i) = CSng(rawDataFromInstrument(i + 4))
        Next

        currentMeasuredData.Sequence = 1
        currentMeasuredData.Part = My.Settings.tempPart
        currentMeasuredData.Part_Category = My.Settings.tempPartCategory
        currentMeasuredData.Part_Name = My.Settings.tempPartName
        currentMeasuredData.Direction = My.Settings.tempPartDirection
        currentMeasuredData.MP_Year = My.Settings.tempMPYear
        currentMeasuredData.Dev_Model = My.Settings.tempMPModel
        currentMeasuredData.Dev_Event = My.Settings.tempMPEvent
        currentMeasuredData.Note = My.Settings.tempNote
        currentDataGridRow(0) = dataRow_Cnt
        currentDataGridRow(PART_IN_DATAGRIDVIEW) = currentMeasuredData.Part
        currentDataGridRow(PART_CATEGORY_IN_DATAGRIDVIEW) = currentMeasuredData.Part_Category
        currentDataGridRow(PART_NAME_IN_DATAGRIDVIEW) = currentMeasuredData.Part_Name
        currentDataGridRow(DIRECTION_IN_DATAGRIDVIEW) = currentMeasuredData.Direction
        currentDataGridRow(YEAR_IN_DATAGRIDVIEW) = currentMeasuredData.MP_Year
        currentDataGridRow(MODEL_NAME_IN_DATAGRIDVIEW) = currentMeasuredData.Dev_Model
        currentDataGridRow(EVENT_IN_DATAGRIDVIEW) = currentMeasuredData.Dev_Event
        currentDataGridRow(SEQUENCE_IN_DATAGRIDVIEW) = currentMeasuredData.Sequence
        currentDataGridRow(NOTE_IN_DATAGRIDVIEW) = currentMeasuredData.Note

        Dim XYZarray(2) As Single
        Dim xy1931(1) As Single
        Dim Lab(2) As Single
        Dim uv1976(1) As Single
        Dim YI As Single = 0

        XYZarray = opticalParameter.calculate_XYZ(measuredSpectrum, observer, standardIlluminant)
        xy1931 = opticalParameter.calculate_xy1931(XYZarray)
        Lab = opticalParameter.calculate_Lab_Star(XYZarray, observer, standardIlluminant)
        YI = opticalParameter.calculate_YI_ASTM_E313_73(measuredSpectrum)
        uv1976 = opticalParameter.calculate_uvPrime(XYZarray)

        currentDataGridRow(YI_COLUMN_IN_DATAGRIDVIEW) = Math.Round(YI, 2)  'YI_ASTM
        currentDataGridRow(LSTAR_COLUMN_IN_DATAGRIDVIEW) = Math.Round(Lab(0), 3) 'L*
        currentDataGridRow(ASTAR_COLUMN_IN_DATAGRIDVIEW) = Math.Round(Lab(1), 3) 'a*
        currentDataGridRow(BSTART_COLUMN_IN_DATAGRIDVIEW) = Math.Round(Lab(2), 3) 'b*
        currentDataGridRow(X_COLUMN_IN_DATAGRIDVIEW) = Math.Round(XYZarray(0), 3) 'X
        currentDataGridRow(Y_COLUMN_IN_DATAGRIDVIEW) = Math.Round(XYZarray(1), 3) 'Y
        currentDataGridRow(Z_COLUMN_IN_DATAGRIDVIEW) = Math.Round(XYZarray(2), 3) 'Z
        currentDataGridRow(x1931_COLUMN_IN_DATAGRIDVIEW) = Math.Round(xy1931(0), 4) 'x(1931)
        currentDataGridRow(y1931_COLUMN_IN_DATAGRIDVIEW) = Math.Round(xy1931(1), 4) 'y(1931)
        currentDataGridRow(uprime1976_COLUMN_IN_DATAGRIDVIEW) = Math.Round(uv1976(0), 4) 'u'(1976)
        currentDataGridRow(vprime1976_COLUMN_IN_DATAGRIDVIEW) = Math.Round(uv1976(1), 4) 'v'(1976)

        currentDataGridRow(DATETIME_MEASURED_IN_DATAGRIDVIEW) = Now.ToString("yyyy-MM-dd HH:mm:ss")
        currentDataGridRow(MEASUREMENT_METHOD_IN_DATAGRIDVIEW) = cmb_MeasurementMethod.Text
        currentDataGridRow(SPECULAR_COMPONENT_IN_DATAGRIDVIEW) = cmb_SpecularComponent.Text
        currentDataGridRow(UV_IN_DATAGRIDVIEW) = cmb_UV.Text
        currentDataGridRow(STANDARD_ILLUMINANT_IN_DATAGRIDVIEW) = cmb_StandardIlluminant.Text
        currentDataGridRow(OBSERVER_IN_DATAGRIDVIEW) = cmb_Observer.Text
        currentDataGridRow(MEASURING_APERTURE_IN_DATAGRIDVIEW) = sample_Hole_Size

        'Dim retStr As String = ""
        'Dim delimeter As String = ","
        'Dim comboList() As String = {}
        'Dim part_pk As String = ""

        'If Len(currentDataGridRow(PART_CATEGORY_IN_DATAGRIDVIEW)) > 0 Then
        '    retStr = connectWithDB.getComboItemsFromDB("M_Optic_Part", "PK", "Part_Category", currentDataGridRow(PART_CATEGORY_IN_DATAGRIDVIEW), delimeter)
        '    comboList = Split(retStr, delimeter)
        '    part_pk = comboList(1)
        '    'Select Case`Part_Name` from M_Optic_Part_Name where 'Master PK' = 1
        '    retStr = connectWithDB.getComboItemsFromDB("M_Optic_Part_Name", "Part_Name", "Master PK", part_pk, delimeter)
        '    comboList = Split(retStr, delimeter)
        'End If

        DataGridView1.Rows.Add(currentDataGridRow)
        If rawDataFromInstrument(86) = 1 And cmb_SpecularComponent.Text = "SCE" Then      '1,1(Specular component),1,S=00
        ElseIf rawDataFromInstrument(86) = 2 And cmb_SpecularComponent.Text = "SCI" Then
        ElseIf rawDataFromInstrument(86) = 3 And cmb_SpecularComponent.Text = "SCI+SCE" Then
        Else
            MsgBox("Specular Component Matching Error")
            Exit Sub
        End If

    End Sub

    Private Sub btn_DoMeasurement_MouseHover_1(sender As Object, e As EventArgs) Handles btn_DoMeasurement.MouseHover
        Call Panel3_MouseLeave(sender, e)
        Call set_picture_height(0, 0, 0, PIC_SEQUENCE4_HEIGHT)
        Call MoveCursor(btn_DoMeasurement)

    End Sub
    Private Sub Panel3_MouseLeave(sender As Object, e As EventArgs) Handles Panel3.MouseLeave, Label15.Click, Panel5.MouseHover, Label15.MouseHover
        Panel3.Width = 40
    End Sub
    Private Sub MoveCursor(button As Control)
        'Set the Current cursor, move the cursor's Position,
        ' And set its clipping rectangle to the form. 

        Me.Cursor = New Cursor(Cursor.Current.Handle)
        Cursor.Position = New System.Drawing.Point(Cursor.Position.X, Me.Location.Y + button.Location.Y + 100)

    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If serialPort.IsOpen() Then
            serialPort.Close()
        End If
        Call initSerialCommunication()
        Call setButtonStatus(init_SerialCom)
    End Sub
    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Dim tempStr As String


        Form_Login.currentLoginInfo.useEndTime = Now.ToString(("yyyy-MM-dd HH:mm:ss"))
        connectWithDB.UpdateLoginData_End("instrument_Management")

        tempStr = ""
        tempStr = "," & Form_Login.currentLoginInfo.useEndTime & "," & Form_Login.currentLoginInfo.Test_Room

        Try
            System.IO.File.AppendAllText(Form_Login.path, tempStr & vbCrLf)
        Catch ex As Exception
            'Debug.Print("Fail to write file at local : " & path)
        End Try

        If serialPort.IsOpen Then
            serialPort.Close()
        End If

    End Sub
    Private Sub btn_sendSerialTxt_Click(sender As Object, e As EventArgs) Handles btn_sendSerialTxt.Click
        Dim sendMessage, receivedMessage As String
        sendMessage = txt_SendSerialTxt.Text
        receivedMessage = ""

        Call serialCommunicationResponse(sendMessage)

        txt_SendSerialTxt.Clear()
        txt_SendSerialTxt.Focus()
    End Sub

    Private Sub txt_SendSerialTxt_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_SendSerialTxt.KeyDown
        If (e.KeyValue = 13) Then
            Call btn_sendSerialTxt_Click(sender, e)
        End If
    End Sub
    Private Sub cmb_SpecularComponent_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_SpecularComponent.SelectedIndexChanged
        If cmb_SpecularComponent.SelectedText = "SCI+SCE" Then
            cmb_UV.Items.Clear()
            cmb_UV.Items.Add({"In", "Out"})
            cmb_UV.Text = "In"
        Else
            cmb_UV.Items.Clear()
            cmb_UV.Items.Add({"In", "Out", "In+Out"})
            cmb_UV.Text = "In"
        End If
    End Sub
    Function serialCommunicationResponse(sendStr As String) As String
        Dim retStr As String
        retStr = ""

        Try
            serialPort.WriteLine(sendStr)
            txt_ReceivedSerialTxt.AppendText("send : " & sendStr & vbCrLf)
            Thread.Sleep(SERIALCOMMDELAY)
            retStr = serialPort.ReadExisting
            retStr = Strings.Replace(retStr, vbCrLf, "")
            txt_ReceivedSerialTxt.AppendText("received : " & retStr & vbCrLf)
        Catch ex As Exception
            MsgBox("Error While communication command " & sendStr & vbCrLf & ex.Message)
        End Try

        Return retStr
    End Function
    Function readInstrumentSetting() As Boolean
        Dim retStr As String
        Dim instrumentCondition() As String
        Dim k As Integer
        retStr = ""

        retStr = serialCommunicationResponse(SD4000_CMD.getInstrumentStatus)
        'retStr = @RIS,1,1,0,0,0,1
        'MsgBox(retStr)
        instrumentCondition = Strings.Split(retStr, ",")
        'MsgBox(UBound(instrumentCondition))
        If UBound(instrumentCondition) = 6 Then
            init_ZeroCal = instrumentCondition(1)
            init_standardCal = instrumentCondition(2)
            zeroCal_stand_yesORno = instrumentCondition(3)
            standardCal_stand_yeaOrno = instrumentCondition(4)
            k = instrumentCondition(6)
            If k = 0 Then
                MsgBox("Sample Stand is missing. Place Sample Stand.")
                Return False
                Exit Function
            ElseIf k = 1 Then
                sample_Hole_Size = "LAV"
            ElseIf k = 2 Then
                sample_Hole_Size = "MAV"
            ElseIf k = 3 Then
                sample_Hole_Size = "SAV"
            Else
                MsgBox("serial Comm. Error : " & SD4000_CMD.getInstrumentStatus)
                Return False
                Exit Function
            End If
        Else
            MsgBox("serial Comm. Error : " & SD4000_CMD.getInstrumentStatus)
            Return False
            Exit Function
        End If

        Call showCalibrationStatus()
        Return True
    End Function
    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        txt_ReceivedSerialTxt.Clear()
    End Sub
    Private Sub txt_ReceivedSerialTxt_TextChanged(sender As Object, e As EventArgs) Handles txt_ReceivedSerialTxt.TextChanged
        txt_ReceivedSerialTxt.SelectionStart = txt_ReceivedSerialTxt.Text.Length
        txt_ReceivedSerialTxt.ScrollToCaret()
    End Sub
    Sub showCalibrationStatus()
        If init_ZeroCal = 0 Then
            btn_ZeroCalibration.ImageIndex = 0
        Else
            btn_ZeroCalibration.ImageIndex = 1
        End If

        If init_standardCal = 0 Then
            btn_StandardCalibration.ImageIndex = 0
        Else
            btn_StandardCalibration.ImageIndex = 1
        End If
    End Sub
    Function setWPMparameters() As String
        Dim retStr As String
        If SD4000_CMD.setMeasurementMode_3rdDigit > 0 Then
            retStr = SD4000_CMD.setMeasurementMode &
                            SD4000_CMD.setMeasurementMode_1stDigit(cmb_MeasurementMethod.Text) & "," &
                            SD4000_CMD.setMeasurementMode_2ndDigit & "," &
                            SD4000_CMD.setMeasurementMode_3rdDigit & "," &
                            SD4000_CMD.setMeasurementMode_4thDigit(cmb_SpecularComponent.Text) & "," &
                            SD4000_CMD.setMeasurementMode_5thDigit(cmb_UV.Text) & ",100.0"
            Return retStr
        Else
            MsgBox("hole size setting NG")
            Return Nothing
            Exit Function
        End If

    End Function
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click   ' This is for admin. confirm
        'SCI+SCE,received: 
        Dim sciPLUSsce, sci, sce As String
        Dim result As String
        Dim resultDelimetedByComma() As String
        Dim measuredSpectrum() As Single
        ReDim measuredSpectrum(spectrumCount - 1)
        Dim currentDataGridRow(dataColumnCount - 1) As String

        currentMeasuredData = Nothing

        sce = "@FM,H=380,780,5,50,51,52,53,97.33,97.66,98,98.33,98.66,99,99.06,99,98.86,98.96,99.19,99.28,98.99,99.3,99.32,99.4,99.33,99.32,99.42,99.42,99.45,99.53,99.5,99.47,99.55,99.59,99.49,99.5,99.61,99.45,99.6,99.59,99.59,99.6,99.6,99.64,99.58,99.63,99.59,99.59,99.41,99.52,99.49,99.39,99.52,99.51,99.52,99.64,99.74,99.54,99.41,99.24,99.44,99.32,99.27,99.3,99.38,99.33,99.18,99.12,99.09,99.38,99.36,99.35,99.3,99.3,99.37,99.46,99.25,99.35,99.32,99.22,99.23,98.97,99.27,99.35,99.22,1,1,1,S=00"
        sci = "@FM,H=380,780,5,011.918,017.370,023.123,027.502,029.961,031.166,031.506,031.533,031.492,031.447,031.263,031.112,030.960,030.825,030.737,030.635,030.420,030.406,030.286,030.155,029.998,029.865,029.777,029.652,029.516,029.420,029.297,029.172,029.087,029.003,028.879,028.773,028.686,028.542,028.494,028.382,028.265,028.204,028.119,027.999,027.900,027.844,027.739,027.699,027.524,027.420,027.368,027.276,027.284,027.225,027.115,027.037,026.992,026.858,026.751,026.590,026.596,026.542,026.455,026.444,026.416,026.332,026.210,026.065,025.967,025.993,025.963,025.913,025.918,025.828,025.734,025.707,025.539,025.476,025.547,025.500,025.438,025.358,025.370,025.401,025.335,1,2,1,S=00"
        sciPLUSsce = ""
        If cmb_SpecularComponent.Text = "SCI" Then
            result = sci
        ElseIf cmb_SpecularComponent.Text = "SCE" Then
            result = sce
        ElseIf cmb_SpecularComponent.Text = "SCE+SCI" Or cmb_SpecularComponent.Text = "SCI+SCE" Then
            result = sciPLUSsce
        Else
            MsgBox("need to check specular component")
            Exit Sub
        End If

        th = New Thread(AddressOf ThreadPopupTask)
        th.IsBackground = True
        th.Start()

        While th.IsAlive
            Me.Enabled = False
        End While
        Me.Enabled = True
        Me.BringToFront()

        resultDelimetedByComma = Strings.Split(result, ",")

        If UBound(resultDelimetedByComma) < 89 Then ' sci or sce
            Call setDataonDataGridView1(resultDelimetedByComma)
            Debug.Print(DataGridView1.RowCount)
            If DataGridView1.RowCount > 0 Then
                'DataGridView1.CurrentCell = DataGridView1.Rows(DataGridView1.Rows.Count - 1).Cells(0)
                'Call DataGridView1_SelectionChanged(sender, e)
            Else
            End If
            dataRow_Cnt += 1
        End If
    End Sub
    Private Sub ThreadPopupTask()
        Form_PartInfo_Submit.ShowDialog()
        'Return "closed"
    End Sub
    Private Sub DataGridView1_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridView1.SelectionChanged
        Dim spectrum_Chart_Area As DataVisualization.Charting.ChartArea
        Dim selectedRows As DataGridViewSelectedRowCollection
        Dim rowDataStr As DataGridViewCellCollection
        Dim i, j, k As Integer
        Dim astar, bstar, lstar As Single
        Dim Y, x1931, y1931 As Single
        Dim uprime1976, vprime1976 As Single
        Dim opticalSpectrum() As Single
        ReDim opticalSpectrum(spectrumCount - 1)
        Dim divideInt As Integer
        Dim chartColor As Color
        Dim dataTablebesideChart(vprime1976_COLUMN_IN_DATAGRIDVIEW, 0) As String
        Dim gap As Single
        Dim intervalInChart As Double
        Dim minValue As Integer = 100
        Dim maxValue As Integer = 0
        'minValue = 100
        'maxValue = 0
        spectrum_Chart_Area = spectrum_Chart.ChartAreas(0)
        selectedRows = DataGridView1.SelectedRows
        spectrum_Chart.Series.Clear()
        Labchart.Series.Clear()
        xyChart.Series.Clear()
        Lchart.Series.Clear()
        YChart.Series.Clear()
        uvChart.Series.Clear()

        DataGridView2.Rows.Clear()

        ' Debug.Print("IN Selection changed of Datagridview")
        If DataGridView1.RowCount > 0 Then
            Try
                rowDataStr = selectedRows(0).Cells()
                For k = 0 To vprime1976_COLUMN_IN_DATAGRIDVIEW
                    'Debug.Print(rowDataStr(k).Value)
                    'tempRowData = selectedRows(i).Cells()
                    dataTablebesideChart(k, 0) = rowDataStr(k).Value
                    'Debug.Print(dataTablebesideChart(k, 0))
                Next k


                For i = 0 To selectedRows.Count - 1
                    rowDataStr = selectedRows(selectedRows.Count - 1 - i).Cells()
                    For j = 0 To spectrumCount - 1
                        opticalSpectrum(j) = CSng(rowDataStr(SPECTRUM_START_COLUMN_IN_DATAGRIDVIEW + j).Value)
                        If minValue > opticalSpectrum(j) Then
                            minValue = opticalSpectrum(j)
                        End If

                        If maxValue < opticalSpectrum(j) Then
                            maxValue = opticalSpectrum(j)
                        End If
                    Next j

                    astar = CSng(rowDataStr(ASTAR_COLUMN_IN_DATAGRIDVIEW).Value)
                    bstar = CSng(rowDataStr(BSTART_COLUMN_IN_DATAGRIDVIEW).Value)
                    lstar = CSng(rowDataStr(LSTAR_COLUMN_IN_DATAGRIDVIEW).Value)
                    Y = CSng(rowDataStr(Y_COLUMN_IN_DATAGRIDVIEW).Value)
                    x1931 = CSng(rowDataStr(x1931_COLUMN_IN_DATAGRIDVIEW).Value)
                    y1931 = CSng(rowDataStr(y1931_COLUMN_IN_DATAGRIDVIEW).Value)
                    uprime1976 = CSng(rowDataStr(uprime1976_COLUMN_IN_DATAGRIDVIEW).Value)
                    vprime1976 = CSng(rowDataStr(vprime1976_COLUMN_IN_DATAGRIDVIEW).Value)
                    '-----------------------------------------------
                    ' set for Spectrum chart
                    '-----------------------------------------------
                    If UBound(opticalParameter.wavelength_5nm) = UBound(opticalSpectrum) Then
                        ' spectrum_Chart.Series.Add((rowDataStr(0).Value).ToString & " : " & rowDataStr(2).Value)
                        If i < 10 Then
                            chartColor = Chart_Color(i)
                        Else
                            chartColor = RandomRGBColor()
                        End If
                        spectrum_Chart.Series.Add((rowDataStr(0).Value) & " : " & rowDataStr(2).Value)
                        With spectrum_Chart.Series(i)
                            '  .Legend = (rowDataStr(0).Value) & " : " & rowDataStr(2).Value
                            .ChartType = DataVisualization.Charting.SeriesChartType.Line
                            .BorderWidth = 1
                            .Color = chartColor
                            .BorderDashStyle = DataVisualization.Charting.ChartDashStyle.Solid
                            .MarkerStyle = DataVisualization.Charting.MarkerStyle.None

                            For j = 0 To UBound(opticalSpectrum)
                                .Points.AddXY(opticalParameter.wavelength_5nm(j), opticalSpectrum(j))
                                'If j = UBound(opticalSpectrum) Then
                                '    Debug.Print(opticalParameter.wavelength_5nm(j))
                                '    Debug.Print(opticalSpectrum(j))
                                'End If
                            Next j
                        End With
                    End If

                    '-----------------------------------------------
                    ' set for a*b* chart
                    '-----------------------------------------------
                    If Len(astar) > 0 And Len(bstar) > 0 Then

                        Labchart.Series.Add((rowDataStr(0).Value) & " : " & rowDataStr(2).Value)

                        With Labchart.Series(i)
                            ' .Legend = (rowDataStr(0).Value) & " : " & rowDataStr(2).Value
                            .ChartType = DataVisualization.Charting.SeriesChartType.Point
                            .BorderWidth = 1
                            .Color = chartColor
                            .BorderDashStyle = DataVisualization.Charting.ChartDashStyle.NotSet
                            .MarkerStyle = DataVisualization.Charting.MarkerStyle.Circle
                            .MarkerSize = 10
                            .Points.AddXY(astar, bstar)
                        End With
                    End If

                    '-----------------------------------------------
                    ' set for L* chart
                    '-----------------------------------------------
                    If Len(lstar) > 0 Then

                        Lchart.Series.Add((rowDataStr(0).Value) & " : " & rowDataStr(2).Value)

                        With Lchart.Series(i)
                            ' .Legend = (rowDataStr(0).Value) & " : " & rowDataStr(2).Value
                            .ChartType = DataVisualization.Charting.SeriesChartType.Point
                            .BorderWidth = 1
                            .Color = chartColor
                            .BorderDashStyle = DataVisualization.Charting.ChartDashStyle.NotSet
                            .MarkerStyle = DataVisualization.Charting.MarkerStyle.Circle
                            .MarkerSize = 10
                            .Points.AddXY(0.5, lstar)
                        End With
                    End If

                    '-----------------------------------------------
                    ' set for Y chart
                    '-----------------------------------------------
                    If Len(Y) > 0 Then

                        YChart.Series.Add((rowDataStr(0).Value) & " : " & rowDataStr(2).Value)

                        With YChart.Series(i)
                            ' .Legend = (rowDataStr(0).Value) & " : " & rowDataStr(2).Value
                            .ChartType = DataVisualization.Charting.SeriesChartType.Point
                            .BorderWidth = 1
                            .Color = chartColor
                            .BorderDashStyle = DataVisualization.Charting.ChartDashStyle.NotSet
                            .MarkerStyle = DataVisualization.Charting.MarkerStyle.Circle
                            .MarkerSize = 10
                            .Points.AddXY(0.5, Y)
                        End With
                    End If

                    '-----------------------------------------------
                    ' set for xy chart
                    '-----------------------------------------------
                    If Len(x1931) > 0 And Len(y1931) > 0 Then

                        xyChart.Series.Add((rowDataStr(0).Value) & " : " & rowDataStr(2).Value)

                        With xyChart.Series(i)
                            ' .Legend = (rowDataStr(0).Value) & " : " & rowDataStr(2).Value
                            .ChartType = DataVisualization.Charting.SeriesChartType.Point
                            .BorderWidth = 1
                            .Color = chartColor
                            .BorderDashStyle = DataVisualization.Charting.ChartDashStyle.NotSet
                            .MarkerStyle = DataVisualization.Charting.MarkerStyle.Circle
                            .MarkerSize = 10
                            .Points.AddXY(x1931, y1931)
                        End With
                    End If
                    '-----------------------------------------------
                    ' set for u'v' chart
                    '-----------------------------------------------
                    If Len(uprime1976) > 0 And Len(vprime1976) > 0 Then

                        uvChart.Series.Add((rowDataStr(0).Value) & " : " & rowDataStr(2).Value)

                        With uvChart.Series(i)
                            ' .Legend = (rowDataStr(0).Value) & " : " & rowDataStr(2).Value
                            .ChartType = DataVisualization.Charting.SeriesChartType.Point
                            .BorderWidth = 1
                            .Color = chartColor
                            .BorderDashStyle = DataVisualization.Charting.ChartDashStyle.NotSet
                            .MarkerStyle = DataVisualization.Charting.MarkerStyle.Circle
                            .MarkerSize = 10
                            .Points.AddXY(uprime1976, vprime1976)
                        End With
                    End If

                Next i
                '-----------------------------------------------
                ' set max/min value for spectrum chart
                '-----------------------------------------------
                divideInt = CInt(minValue / 10) - 1
                If divideInt < 0 Then
                    divideInt = 0
                End If

                minValue = (divideInt * 10)
                divideInt = CInt(maxValue / 10) + 1
                maxValue = divideInt * 10

                gap = maxValue - minValue
                If gap <= 10 Then
                    intervalInChart = 1
                ElseIf gap < 50 Then
                    intervalInChart = 5
                Else
                    intervalInChart = 10
                End If

                With spectrum_Chart_Area
                    With .AxisY
                        .Minimum = minValue
                        .Maximum = maxValue
                        .Interval = intervalInChart
                    End With
                End With
                '-----------------------------------------------
                ' Draw Charts
                '-----------------------------------------------
                spectrum_Chart.Show()
                Labchart.Show()
                xyChart.Show()
                Lchart.Show()
                YChart.Show()
                uvChart.Show()
                '-----------------------------------------------
                ' show data on table beside charts
                '-----------------------------------------------
                DataGridView2.Rows.Clear()

                DataGridView2.ColumnCount = 2
                DataGridView2.Columns(0).Name = "Parameter"
                DataGridView2.Columns(1).Name = dataTablebesideChart(0, 0)

                DataGridView2.Rows.Add("Part Name", dataTablebesideChart(PART_NAME_IN_DATAGRIDVIEW, 0))
                DataGridView2.Rows.Add("YI ASTM E313-73", dataTablebesideChart(YI_COLUMN_IN_DATAGRIDVIEW, 0))
                DataGridView2.Rows.Add("L*", dataTablebesideChart(LSTAR_COLUMN_IN_DATAGRIDVIEW, 0))
                DataGridView2.Rows.Add("a*", dataTablebesideChart(ASTAR_COLUMN_IN_DATAGRIDVIEW, 0))
                DataGridView2.Rows.Add("b*", dataTablebesideChart(BSTART_COLUMN_IN_DATAGRIDVIEW, 0))
                DataGridView2.Rows.Add("Y", dataTablebesideChart(Y_COLUMN_IN_DATAGRIDVIEW, 0))
                DataGridView2.Rows.Add("x", dataTablebesideChart(x1931_COLUMN_IN_DATAGRIDVIEW, 0))
                DataGridView2.Rows.Add("y", dataTablebesideChart(y1931_COLUMN_IN_DATAGRIDVIEW, 0))
                DataGridView2.Rows.Add("u'", dataTablebesideChart(uprime1976_COLUMN_IN_DATAGRIDVIEW, 0))
                DataGridView2.Rows.Add("v'", dataTablebesideChart(vprime1976_COLUMN_IN_DATAGRIDVIEW, 0))
            Catch ex As Exception
                MsgBox(ex.Message)
                Exit Sub
            End Try
        Else

        End If
    End Sub
    Public Function RandomRGBColor() As Color
        Return Color.FromArgb(255,
            m_Rnd.Next(0, 255),
            m_Rnd.Next(0, 255),
            m_Rnd.Next(0, 255))
    End Function
    Private m_Rnd As New Random
    Private Sub btn_adminMenu_Click(sender As Object, e As EventArgs) Handles btn_adminMenu.Click
        If Form_Login.currentLoginInfo.userID = PowerUser Then
            Form_AdminSetting.ShowDialog()
        End If
    End Sub
    Private Sub btn_deleteRowsInDatagridview_Click(sender As Object, e As EventArgs) Handles btn_deleteRowsInDatagridview.Click
        Dim index As Integer
        Dim selectedRows As DataGridViewSelectedRowCollection
        Dim i As Integer
        selectedRows = DataGridView1.SelectedRows

        If MsgBox("Delete " & selectedRows.Count & " Row ??", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then 'OK : 1, Calcel : 2
            Debug.Print("selectedRows count : " & selectedRows.Count)
            For i = 0 To selectedRows.Count - 1
                index = selectedRows(i).Index
                DataGridView1.Rows.RemoveAt(index)
            Next i
        Else
            Exit Sub
        End If
    End Sub
    Private Sub DataGridView1_KeyDown(sender As Object, e As KeyEventArgs) Handles DataGridView1.KeyDown
        If (e.KeyValue = 46) Then
            Call btn_deleteRowsInDatagridview_Click(sender, e)
        End If
    End Sub
    Private Sub btn_SaveAndUpload_Click(sender As Object, e As EventArgs) Handles btn_SaveAndUpload.Click
        'Dim xlApp As Microsoft.Office.Interop.Excel.ApplicationClass
        Dim xls As Excel.Application = Nothing
        Dim xworkbook As Excel.Workbook = Nothing
        Dim xworksheet As Excel.Worksheet = Nothing
        Dim misValue As Object = System.Reflection.Missing.Value
        Dim filename As String = ""
        Dim result As DialogResult
        Dim startRow As Integer = 4
        Dim startColumn As Integer = 2
        Dim dg As DataGridView
        Dim dataColumn As DataGridViewColumn
        Dim selectedRows As DataGridViewRowCollection
        Dim rowDataStr As DataGridViewCellCollection
        Dim colIndex As Integer = 0
        Dim rowIndex As Integer = 0
        Dim DBSaveRowcount As Integer = 0
        'th = New Thread(AddressOf setLabelText)
        'th.IsBackground = True
        'th.Start()

        If DataGridView1.RowCount > 0 Then
            Me.Enabled = False
            '------------------------------------------------------------------
            'SaveFileDialog setting
            '------------------------------------------------------------------
            lbl_saveStatus.Text = "Saving Excel"
            SaveFileDialog1.Filter = "EXCEL FILES|*.xlsx;*.xls"
            SaveFileDialog1.FileName = "SD4000_Reflectance_DATA(" & Now.ToString("yyyy-MM-dd") & ")"
            SaveFileDialog1.RestoreDirectory = True
            SaveFileDialog1.InitialDirectory = My.Settings.SaveDirectory

            result = SaveFileDialog1.ShowDialog()
            '------------------------------------------------------------------
            'Save data on excel template
            '------------------------------------------------------------------
            ProgressBar2.Value = 5
            xls = New Excel.Application()
            xls.Visible = False


            Try
                xworkbook = xls.Workbooks.Open(Strings.Replace(My.Settings.ExcelTemplate, vbLf, ""))
                If xworkbook Is Nothing Then
                    xworkbook = New Excel.Workbook
                End If

            Catch ex As Exception
                MsgBox(ex.Message)

            End Try
            xworksheet = xworkbook.Sheets(1)

            ProgressBar2.Value = 10

            dg = DataGridView1
            selectedRows = Nothing
            '2-1+1=2
            If result = DialogResult.OK Then
                filename = SaveFileDialog1.FileName
                'write Column's Name
                For Each dataColumn In dg.Columns
                    colIndex = colIndex + 1
                    xworksheet.Cells(startRow, startColumn - 1 + colIndex) = dataColumn.Name
                Next

                selectedRows = dg.Rows

                For i = 0 To selectedRows.Count - 1
                    rowDataStr = selectedRows(i).Cells()
                    For j = 0 To dataColumnCount - 1
                        xworksheet.Cells(startRow + i + 1, startColumn + j) = rowDataStr(j).Value
                    Next
                    ProgressBar2.Value = 50 / selectedRows.Count * (i + 1)
                Next

                Try
                    xworkbook.SaveAs(filename, Excel.XlFileFormat.xlOpenXMLWorkbook)
                    xworkbook.Close(False)
                    xls.Workbooks.Close() '(My.Settings.ExcelTemplate)
                    xls.Quit()
                    'Application.DoEvents()
                    'lbl_saveStatus.Refresh()
                    lbl_saveStatus.Text = "Excel saved at" & filename

                Catch ex As Exception
                    MsgBox("ERROR!! : " & vbCrLf & ex.Message)
                    lbl_saveStatus.Text = "Error while saving excel"
                    ProgressBar2.Value = 0
                    Me.Enabled = True
                    Exit Sub
                End Try
                ProgressBar2.Value = 50

                '------------------------------------------------------------------
                'send data to DB
                '------------------------------------------------------------------
                Dim saveDBRows As DataGridViewRowCollection
                Dim saveDBArray As DataGridViewCellCollection

                saveDBRows = DataGridView1.Rows
                ' Application.DoEvents()
                lbl_saveStatus.Text = "Excel saved @" & filename & "  → Uploading To DB"

                'lbl_saveStatus.Refresh()

                For i = 0 To DataGridView1.Rows.Count - 1
                    Dim DBdataStructure As New measuredData
                    saveDBArray = saveDBRows(i).Cells()

                    DBdataStructure.No = saveDBArray(0).Value

                    DBdataStructure.Part = saveDBArray(PART_IN_DATAGRIDVIEW).Value
                    DBdataStructure.Part_Category = saveDBArray(PART_CATEGORY_IN_DATAGRIDVIEW).Value
                    DBdataStructure.Part_Name = saveDBArray(PART_NAME_IN_DATAGRIDVIEW).Value
                    DBdataStructure.Direction = saveDBArray(DIRECTION_IN_DATAGRIDVIEW).Value
                    DBdataStructure.MP_Year = saveDBArray(YEAR_IN_DATAGRIDVIEW).Value
                    DBdataStructure.Dev_Model = saveDBArray(MODEL_NAME_IN_DATAGRIDVIEW).Value
                    DBdataStructure.Dev_Event = saveDBArray(EVENT_IN_DATAGRIDVIEW).Value
                    DBdataStructure.Sequence = saveDBArray(SEQUENCE_IN_DATAGRIDVIEW).Value
                    DBdataStructure.Note = saveDBArray(NOTE_IN_DATAGRIDVIEW).Value

                    DBdataStructure.YI_ASTM_E313_73 = saveDBArray(YI_COLUMN_IN_DATAGRIDVIEW).Value
                    DBdataStructure.L_Star = saveDBArray(LSTAR_COLUMN_IN_DATAGRIDVIEW).Value
                    DBdataStructure.a_Star = saveDBArray(ASTAR_COLUMN_IN_DATAGRIDVIEW).Value
                    DBdataStructure.b_Star = saveDBArray(BSTART_COLUMN_IN_DATAGRIDVIEW).Value
                    DBdataStructure.X = saveDBArray(X_COLUMN_IN_DATAGRIDVIEW).Value
                    DBdataStructure.Y = saveDBArray(Y_COLUMN_IN_DATAGRIDVIEW).Value
                    DBdataStructure.Z = saveDBArray(Z_COLUMN_IN_DATAGRIDVIEW).Value
                    DBdataStructure.CIE_x = saveDBArray(x1931_COLUMN_IN_DATAGRIDVIEW).Value
                    DBdataStructure.CIE_y = saveDBArray(y1931_COLUMN_IN_DATAGRIDVIEW).Value
                    DBdataStructure.u_prime = saveDBArray(uprime1976_COLUMN_IN_DATAGRIDVIEW).Value
                    DBdataStructure.v_prime = saveDBArray(vprime1976_COLUMN_IN_DATAGRIDVIEW).Value

                    DBdataStructure.DateTime = saveDBArray(DATETIME_MEASURED_IN_DATAGRIDVIEW).Value
                    DBdataStructure.Measurement_Method = saveDBArray(MEASUREMENT_METHOD_IN_DATAGRIDVIEW).Value
                    DBdataStructure.Specular_Component = saveDBArray(SPECULAR_COMPONENT_IN_DATAGRIDVIEW).Value
                    DBdataStructure.UV = saveDBArray(UV_IN_DATAGRIDVIEW).Value
                    DBdataStructure.STD_Illuminants = saveDBArray(STANDARD_ILLUMINANT_IN_DATAGRIDVIEW).Value
                    DBdataStructure.Observer = saveDBArray(OBSERVER_IN_DATAGRIDVIEW).Value
                    DBdataStructure.MeasuringAperture = saveDBArray(MEASURING_APERTURE_IN_DATAGRIDVIEW).Value

                    ReDim DBdataStructure.Spectrum(spectrumCount - 1)

                    For j = 0 To spectrumCount - 1
                        DBdataStructure.Spectrum(j) = CSng(saveDBArray(SPECTRUM_START_COLUMN_IN_DATAGRIDVIEW + j).Value)
                    Next j
                    Try
                        DBSaveRowcount += connectWithDB.sendDataToDB_SD4000(DBdataStructure)
                    Catch ex As Exception
                        MsgBox("Data Save Failed" & vbCrLf & ex.Message)
                        Me.Enabled = True
                        Exit Sub
                    End Try

                    ProgressBar2.Value = 100 / selectedRows.Count * (i + 1)
                Next

                'Debug.Print(filename)
                If DBSaveRowcount <> DataGridView1.Rows.Count Then
                    MsgBox("Save Excel completed and upload to DB Failed" & vbCrLf & "Saved data " & DBSaveRowcount & " out of " & DataGridView1.Rows.Count)
                Else
                    MsgBox("Save Excel And DB completed!")
                End If 'Application.DoEvents()
                lbl_saveStatus.Text = "Excel saved @" & filename & " + Complete uploaing to DB"
                'Me.Refresh()

            End If
            Me.Enabled = True
        Else
            MsgBox("No data to save")
            Me.Enabled = True
            Exit Sub
        End If

        ProgressBar2.Value = 0

    End Sub

    Private Delegate Sub setControlTextDelegate(ByVal aControl As Control, ByVal text As String)
    Private Sub setControlText(ByVal aControl As Control, ByVal someText As String)
        If lbl_saveStatus.InvokeRequired Then
            Dim del As New setControlTextDelegate(AddressOf setControlText)
            Me.Invoke(del, New Object() {aControl, someText})
        Else
            aControl.Text = someText
        End If
    End Sub


End Class
