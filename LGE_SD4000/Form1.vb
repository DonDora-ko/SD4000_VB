Imports FarPoint.CalcEngine
Imports System.Threading.Thread



Class Form1
    Const dataColumnCount As Integer = 106
    'No,PartCategory , PartName,Direction, Year, Model, Event,Seq,Note, DateTime ==> 10 EA
    'MeasurementMode(Ref/Trans),Specular component, UV, STD Illuminantm , Observer .z
    '380~780,Δ5nm  ==>  81EA
    Const PIC_SEQUENCE1_HEIGHT As Integer = 230
    Const PIC_SEQUENCE2_HEIGHT As Integer = 150
    Const PIC_SEQUENCE3_HEIGHT As Integer = 130
    Const PIC_SEQUENCE4_HEIGHT As Integer = 260
    Const SPECTRUM_START As Integer = 380
    Const SPECTRUM_END As Integer = 780
    Const SPECTRUM_INTERVAL As Integer = 5

    'Column width of datagrid(table)
    Const COLUMNWIDTH_XS As Integer = 40
    Const COLUMNWIDTH_S As Integer = 60
    Const COLUMNWIDTH_M As Integer = 80
    Const COLUMNWIDTH_L As Integer = 150
    Const COLUMNWIDTH_XL As Integer = 200
    Const SERIALCOMMDELAY As Integer = 200
    Const YI_COLUMN_IN_DATAGRIDVIEW As Integer = 9
    Const LSTAR_COLUMN_IN_DATAGRIDVIEW As Integer = 10
    Const ASTAR_COLUMN_IN_DATAGRIDVIEW As Integer = 11
    Const BSTART_COLUMN_IN_DATAGRIDVIEW As Integer = 12
    Const X_COLUMN_IN_DATAGRIDVIEW As Integer = 13
    Const Y_COLUMN_IN_DATAGRIDVIEW As Integer = 14
    Const Z_COLUMN_IN_DATAGRIDVIEW As Integer = 15
    Const x1931_COLUMN_IN_DATAGRIDVIEW As Integer = 16
    Const y1931_COLUMN_IN_DATAGRIDVIEW As Integer = 17
    Const SPECTRUM_START_COLUMN_IN_DATAGRIDVIEW As Integer = 18

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

    Public minValue As Single = 100
    Public maxValue As Single = 0

    Public Chart_Color() As Color = {Color.Black, Color.Red, Color.Blue, Color.Green, Color.Magenta, Color.Yellow, Color.DarkCyan, Color.DarkGray, Color.DarkOliveGreen, Color.DarkOrange} ' define 10 color

    Public selectedData() As String
    '※※※※※※※※※※※구조체 내 수치타입 , Single or Double 추후 확정필요※※※※※※※※※※
    Public Structure measuredData
        Dim No As Integer
        Dim Part_Category, Part_Name, Direction, MP_Year, Dev_Model, Dev_Event As String
        Dim Sequence As Integer
        Dim Note As String
        Dim YI_ASTM_E313_73, L_Star, a_Star, b_Star, X, Y, Z, x_1931, y_1931 As Single
        Dim Spectrum() As Single
        Dim DateTime, Measurement_Method, Specular_Component, UV, STD_Illuminants, Observer, MeasuringAperture As String
    End Structure

    Private Sub Button2_Click(sender As Object, e As EventArgs)
        'MsgBox(MatchFunctionInfo.MatchFunction(0).ToString())

        '        MsgBox(MatchFunctionInfo.TDistFunction.ToString())

        MsgBox(MatchFunctionInfo.ZTestFunction)

    End Sub
    Private Sub initilize_dataGridView_ColumnName(cnt As Integer) 'cnt = number of spectrum data
        Dim i As Integer
        i = 0
        ReDim columnNameArray(dataColumnCount - 1)
        Dim arr1(), arr2(), arr3() As String
        ReDim arr1(17)
        ReDim arr2(cnt - 1)
        ReDim arr3(6)

        arr1 = {
                                        "No.",   '0
                                        "Part Category",  '1
                                        "Part Name",   '2
                                        "Direction",  '3
                                        "MP Year", '4
                                        "Model Name", '5
                                        "Event", '6
                                        "Sequence", '7
                                        "note", '8
                                        "YI ASTM E313-73", '9
                                        "L*", '10
                                        "a*", '11
                                        "b*", '12
                                        "X", '13
                                        "Y", '14
                                        "Z", '15
                                        "x(1931)", '16
                                        "y(1931)" '17
                                   }

        i = 0
        For i = 0 To (cnt - 1) '0~   for SD4000,380~780, interval 5nm = 81ea
            arr2(i) = (Spectrum_Start + Spectrum_Interval * (i) & " nm")
        Next i

        arr3 = {
        "DateTime", '99
        "Measruement Method", '100
        "Specular component", '101
        "UV", '102
        "Standard Illuminant", '103
        "Observer", '104
        "Measuring Aperture"  '105
        }

        Dim j, k As Integer
        j = 0
        k = 0
        '0~17,18~
        'Ubound(arr1) = 17 , data no. = 18 , 0~17
        'Ubound(arr2) = 80 , data no.= 81 , 18~98
        'Ubound(arr3) = 5 , data no.= 6, 99~104
        'Ubound(ColumnNameArray) =104 , 104 =(17+80+5)+2, data No. = 105

        For j = 0 To UBound(columnNameArray)
            If j <= UBound(arr1) Then
                columnNameArray(j) = arr1(j)  '0~17, Ubound(arr1) = 17
            ElseIf j <= UBound(arr1) + UBound(arr2) + 1 Then '18~98 Ubound(arr1) = 17, UBound(arr2) = 80
                columnNameArray(j) = arr2(j - UBound(arr1) - 1)
            ElseIf j <= UBound(arr1) + UBound(arr2) + UBound(arr3) + 2 Then '99~104, Ubound(arr1)=17, Ubound(arr2) = 80, Ubound(arr3) = 6
                columnNameArray(j) = arr3(j - UBound(arr1) - UBound(arr2) - 2)
            End If
        Next j

    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim j As Integer
        Dim combo_Direction As DataGridViewComboBoxColumn = New DataGridViewComboBoxColumn
        Dim spectrum_Chart_Area As DataVisualization.Charting.ChartArea

        Call initSerialCommunication()
        spectrumCount = (Spectrum_End - Spectrum_Start) / Spectrum_Interval + 1 'for SD4000, Spectrum_count is  81

        Call set_picture_height(0, 0, 0, 0)
        DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        DataGridView1.ColumnCount = dataColumnCount
        'SET DataGrid HEADER
        Call initilize_dataGridView_ColumnName(spectrumCount)

        SetTableColumnProperty(DataGridView1.Columns(0), columnNameArray(0), ColumnWidth_XS, True) 'Data_No
        SetTableColumnProperty(DataGridView1.Columns(1), columnNameArray(1), ColumnWidth_L, False) 'Part_Category
        SetTableColumnProperty(DataGridView1.Columns(2), columnNameArray(2), ColumnWidth_L, False) 'Part_Name
        SetTableColumnProperty(DataGridView1.Columns(3), columnNameArray(3), ColumnWidth_M, False) 'direction
        SetTableColumnProperty(DataGridView1.Columns(4), columnNameArray(4), ColumnWidth_S, False) 'year
        SetTableColumnProperty(DataGridView1.Columns(5), columnNameArray(5), ColumnWidth_L, False) 'Model
        SetTableColumnProperty(DataGridView1.Columns(6), columnNameArray(6), ColumnWidth_M, False) 'event
        SetTableColumnProperty(DataGridView1.Columns(7), columnNameArray(7), ColumnWidth_XS, False) 'sequence
        SetTableColumnProperty(DataGridView1.Columns(8), columnNameArray(8), ColumnWidth_XL, False) 'note
        'SetTableColumnProperty (DataGridView1.Columns(9), columnNameArray(9), ColumnWidth_S,)

        For j = 9 To 9 + 9 + (spectrumCount - 1)   '9= 측정데이타 앞의 description개수, YI ASTM~y(1931)까지의 개수 9
            SetTableColumnProperty(DataGridView1.Columns(j), columnNameArray(j), ColumnWidth_S, True) 'measured values
        Next j

        SetTableColumnProperty(DataGridView1.Columns(99), columnNameArray(99), ColumnWidth_L, True) 'DateTime
        SetTableColumnProperty(DataGridView1.Columns(100), columnNameArray(100), ColumnWidth_M, True) 'Measurement Method
        SetTableColumnProperty(DataGridView1.Columns(101), columnNameArray(101), ColumnWidth_M, True) 'Specular component
        SetTableColumnProperty(DataGridView1.Columns(102), columnNameArray(102), ColumnWidth_XS, True) 'UV
        SetTableColumnProperty(DataGridView1.Columns(103), columnNameArray(103), ColumnWidth_XS, True) 'standard Illuminant
        SetTableColumnProperty(DataGridView1.Columns(104), columnNameArray(104), ColumnWidth_M + 15, True) 'observer
        SetTableColumnProperty(DataGridView1.Columns(105), columnNameArray(105), COLUMNWIDTH_S, True) 'Measuring Aperture

        spectrum_Chart_Area = spectrum_Chart.ChartAreas(0)
        With spectrum_Chart_Area
            With .AxisX
                .Title = "wavelength(nm)"
                .TitleFont = New Font("LG Smart UI Regular", 10, FontStyle.Regular)
                .MajorGrid.LineColor = Color.LightBlue
                .Minimum = SPECTRUM_START
                .Maximum = SPECTRUM_END
                .Interval = 50
            End With
            With .AxisY
                .Title = "Reflectance(%)"
                .TitleFont = New Font("LG Smart UI Regular", 10, FontStyle.Regular)
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
            .Font = New Font("LG Smart UI Regular", 10, FontStyle.Bold)
            .ForeColor = Color.Black
        End With
        spectrum_Chart.Titles.Add(spectrumChartTitle)

        Dim LabChartTitle As New DataVisualization.Charting.Title
        With LabChartTitle
            .Text = "        a*/b*"
            .Alignment = StringAlignment.Near
            .Docking = DataVisualization.Charting.Docking.Top
            .Font = New Font("LG Smart UI Regular", 10, FontStyle.Bold)
            .ForeColor = Color.Black
        End With
        Labchart.Titles.Add(LabChartTitle)


        Dim xyChartTitle As New DataVisualization.Charting.Title
        With xyChartTitle
            .Text = "x,y (CIE 1931)"
            .Alignment = StringAlignment.Far
            .Docking = DataVisualization.Charting.Docking.Top
            .Font = New Font("LG Smart UI Regular", 10, FontStyle.Bold)
            .ForeColor = Color.Black
        End With
        xyChart.Titles.Add(xyChartTitle)

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

            ' below process is meanless, but just do process because Color_Mate Program do these process
            tempStr = serialCommunicationResponse(SD4000_CMD.initialization)
            If tempStr.Contains("SD") Then

                serialCommunicationResponse(SD4000_CMD.getInstrumentInfo)

                readInstrumentSetting()
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

                readInstrumentSetting()
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
    Sub set_picture_height(a As Integer, b As Integer, c As Integer, d As Integer)
        pic_sequence1.Height = a
        pic_sequence2.Height = b
        pic_sequence3.Height = c
        pic_sequence4.Height = d
    End Sub
    Private Sub Panel3_MouseUp(sender As Object, e As MouseEventArgs) Handles Panel3.MouseUp, Label1.MouseUp
        Panel3.Width = 270
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
                retStr = serialPort.ReadExisting
                Sleep(1000)
            End While

            txt_ReceivedSerialTxt.AppendText("received : " & Trim(Replace(retStr, vbCrLf, "") & vbCrLf))
            If SD4000_CMD.getCalibrationResult(SD4000_CMD.doZeroCalibration, Trim(Replace(retStr, vbCrLf, ""))) Then
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

        Sleep(SERIALCOMMDELAY * 4)
        readInstrumentSetting()

        btn_ZeroCalibration.ForeColor = Color.Gray
        Call btn_StandardCalibration_MouseHover_1(sender, e)

    End Sub

    Private Sub btn_ZeroCalibration_MouseHover_1(sender As Object, e As EventArgs) Handles btn_ZeroCalibration.MouseHover
        Call Panel3_MouseLeave(sender, e)
        Call set_picture_height(pic_sequence1_height, pic_sequence2_height, 0, 0)
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
                retStr = serialPort.ReadExisting
            End While

            txt_ReceivedSerialTxt.AppendText("received : " & Trim(Replace(retStr, vbCrLf, "") & vbCrLf))
            If SD4000_CMD.getCalibrationResult(SD4000_CMD.doStandardCalibration, Trim(Replace(retStr, vbCrLf, ""))) Then
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

        Sleep(SERIALCOMMDELAY * 4)
        readInstrumentSetting()

        btn_StandardCalibration.ForeColor = Color.Gray
        Call btn_DoMeasurement_MouseHover_1(sender, e)

    End Sub

    Private Sub btn_StandardCalibration_MouseHover_1(sender As Object, e As EventArgs) Handles btn_StandardCalibration.MouseHover
        Call Panel3_MouseLeave(sender, e)
        Call set_picture_height(0, 0, pic_sequence3_height, 0)
        Call MoveCursor(btn_StandardCalibration)
    End Sub
    Private Sub btn_DoMeasurement_Click_1(sender As Object, e As EventArgs) Handles btn_DoMeasurement.Click
        Dim currentRow As New measuredData
        Dim currentDataGridRow(dataColumnCount - 1) As String
        ReDim currentRow.Spectrum(spectrumCount - 1)
        Dim observer As String
        Dim standardIlluminant As String
        Dim i As Integer

        observer = Trim(Me.cmb_Observer.Text)
        standardIlluminant = Trim(Me.cmb_StandardIlluminant.Text)

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
        Dim sendWPM, receivedRPM As String
        Dim retStr As String

        sendWPM = setWPMparameters()
        retStr = Trim(serialCommunicationResponse(sendWPM))
        If retStr = "ACK" Then
        Else
            MsgBox("Error while sending WPM")
            Exit Sub
        End If

        Dim sendWPM1, receivedRPM1 As String
        sendWPM1 = Strings.Right(sendWPM, 16)

        receivedRPM = Trim(serialCommunicationResponse(getMeasurementMode))
        receivedRPM1 = Strings.Right(receivedRPM, 16)

        txt_ReceivedSerialTxt.AppendText(sendWPM1 & vbCrLf)
        txt_ReceivedSerialTxt.AppendText(receivedRPM1 & vbCrLf)
        If sendWPM1 <> receivedRPM1 Then
            MsgBox("SettingWPM and ReadWPM are dirrerent.")
            Exit Sub
        End If
        '--------------------------------------------------------
        'Do Measure
        '--------------------------------------------------------
        Dim formerTime, laterTime As Date
        Dim deltaTime As TimeSpan

        retStr = ""
        formerTime = Now

        Try

            Form_PartInfo_Submit.Show()

            retStr = serialCommunicationResponse(SD4000_CMD.doMeasurement)


            While retStr = Nothing
                Sleep(8000)
                retStr = serialPort.ReadExisting
            End While
            txt_ReceivedSerialTxt.AppendText("received : " & retStr & vbCrLf)
            laterTime = Now
            deltaTime = laterTime - formerTime
            txt_ReceivedSerialTxt.AppendText("Standard Cal. Time : " & deltaTime.ToString & vbCrLf)
            txt_ReceivedSerialTxt.AppendText("------Measurement Done------" & vbCrLf)
        Catch ex As Exception
            MsgBox("Measurement Failed" & vbCrLf & ex.Message)
            Exit Sub
        End Try
        '--------------------------------------------------------
        'Handling Spectrum Data
        '--------------------------------------------------------
        'Dim resultDelimetedByNewLine() As String   'for SCI+SCE
        Dim resultDelimetedByComma() As String
        Dim measuredSpectrum() As Single
        ReDim measuredSpectrum(spectrumCount - 1)

        'resultDelimetedByNewLine = Strings.Split(result, vbCrLf)
        resultDelimetedByComma = Strings.Split(retStr, ",")

        If UBound(resultDelimetedByComma) < 89 Then ' sci or sce
            For i = 0 To spectrumCount - 1   'Spectrum from 380 to 780 nm, interval 5 nm
                currentDataGridRow(i + 18) = resultDelimetedByComma(i + 4)
                measuredSpectrum(i) = CSng(resultDelimetedByComma(i + 4))
            Next

            currentDataGridRow(0) = dataRow_Cnt
            'currentDataGridRow(1) = currentRow.Part_Category
            'currentDataGridRow(2) = currentRow.Part_Name
            'currentDataGridRow(3) = currentRow.Direction
            'currentDataGridRow(4) = currentRow.MP_Year
            'currentDataGridRow(5) = currentRow.Dev_Model
            'currentDataGridRow(6) = currentRow.Dev_Event
            'currentDataGridRow(7) = currentRow.Sequence
            'currentDataGridRow(8) = currentRow.Note

            Dim XYZarray(2) As Single
            Dim xy1931(1) As Single
            Dim Lab(2) As Single
            Dim YI As Single = 0

            XYZarray = opticalParameter.calculate_XYZ(measuredSpectrum, observer, standardIlluminant)
            xy1931 = opticalParameter.calculate_xy1931(XYZarray)
            Lab = opticalParameter.calculate_Lab_Star(XYZarray, observer, standardIlluminant)
            YI = opticalParameter.calculate_YI_ASTM_E313_73(measuredSpectrum)

            currentDataGridRow(9) = Math.Round(YI, 2)  'YI_ASTM
            currentDataGridRow(10) = Math.Round(Lab(0), 3) 'L*
            currentDataGridRow(11) = Math.Round(Lab(1), 3) 'a*
            currentDataGridRow(12) = Math.Round(Lab(2), 3) 'b*
            currentDataGridRow(13) = Math.Round(XYZarray(0), 3) 'X
            currentDataGridRow(14) = Math.Round(XYZarray(1), 3) 'Y
            currentDataGridRow(15) = Math.Round(XYZarray(2), 3) 'Z
            currentDataGridRow(16) = Math.Round(xy1931(0), 4) 'x(1931)
            currentDataGridRow(17) = Math.Round(xy1931(1), 4) 'y(1931)

            currentDataGridRow(99) = Now.ToString("yyyy-MM-dd HH:mm:ss")
            currentDataGridRow(100) = cmb_MeasurementMethod.Text
            currentDataGridRow(101) = cmb_SpecularComponent.Text
            currentDataGridRow(102) = cmb_UV.Text
            currentDataGridRow(103) = cmb_StandardIlluminant.Text
            currentDataGridRow(104) = cmb_Observer.Text
            currentDataGridRow(105) = sample_Hole_Size

            DataGridView1.Rows.Add(currentDataGridRow)
            If resultDelimetedByComma(86) = 1 And cmb_SpecularComponent.Text = "SCE" Then      '1,1(Specular component),1,S=00
            ElseIf resultDelimetedByComma(86) = 2 And cmb_SpecularComponent.Text = "SCI" Then
            ElseIf resultDelimetedByComma(86) = 3 And cmb_SpecularComponent.Text = "SCI+SCE" Then
            Else
                MsgBox("Specular Component Matching Error")
                Exit Sub
            End If

            'DataGridView1.Rows(dataRow_Cnt).Selected = True
            DataGridView1.CurrentCell = DataGridView1.Rows(dataRow_Cnt - 1).Cells(0)
            Call DataGridView1_SelectionChanged(sender, e)

        End If
        dataRow_Cnt += +1
    End Sub

    Private Sub btn_DoMeasurement_MouseHover_1(sender As Object, e As EventArgs) Handles btn_DoMeasurement.MouseHover
        Call Panel3_MouseLeave(sender, e)
        Call set_picture_height(0, 0, 0, pic_sequence4_height)
        Call MoveCursor(btn_DoMeasurement)

    End Sub

    Private Sub Panel3_MouseLeave(sender As Object, e As EventArgs) Handles Panel3.MouseLeave, Label15.Click, Panel5.MouseHover, Label15.MouseHover
        Panel3.Width = 45
    End Sub
    Private Sub MoveCursor(button As Control)
        'Set the Current cursor, move the cursor's Position,
        ' And set its clipping rectangle to the form. 

        Me.Cursor = New Cursor(Cursor.Current.Handle)
        Cursor.Position = New Point(Cursor.Position.X, button.Location.Y + 100)
        'Cursor.Clip = New Rectangle(Me.Location, Me.Size)
        ' MsgBox("moveMove mouse")
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If serialPort.IsOpen() Then
            serialPort.Close()
        End If
        Call initSerialCommunication()
    End Sub
    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
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
            Sleep(serialCommDelay)
            retStr = serialPort.ReadExisting
            retStr = Replace(retStr, vbCrLf, "")
            txt_ReceivedSerialTxt.AppendText("received : " & retStr & vbCrLf)
        Catch ex As Exception
            MsgBox("Error While communication command " & sendStr & vbCrLf & ex.Message)
        End Try

        Return retStr
    End Function
    Sub readInstrumentSetting()
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
            If k = 1 Then
                sample_Hole_Size = "LAV"
            ElseIf k = 2 Then
                sample_Hole_Size = "MAV"
            ElseIf k = 3 Then
                sample_Hole_Size = "SAV"
            Else
                MsgBox("serial Comm. Error : " & SD4000_CMD.getInstrumentStatus)
                Exit Sub
            End If
        Else
            MsgBox("serial Comm. Error : " & SD4000_CMD.getInstrumentStatus)
            Exit Sub
        End If

        Call showCalibrationStatus()
    End Sub
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

        If SD4000_CMD.setMeasurementMode_3rdDigit > 0 Then
            setWPMparameters = SD4000_CMD.setMeasurementMode &
                            SD4000_CMD.setMeasurementMode_1stDigit(cmb_MeasurementMethod.Text) & "," &
                            SD4000_CMD.setMeasurementMode_2ndDigit & "," &
                            SD4000_CMD.setMeasurementMode_3rdDigit & "," &
                            SD4000_CMD.setMeasurementMode_4thDigit(cmb_SpecularComponent.Text) & "," &
                            SD4000_CMD.setMeasurementMode_5thDigit(cmb_UV.Text) & ",100.0"
        Else
            MsgBox("hole size setting NG")
            Exit Function
        End If

    End Function
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        'SCI+SCE,received: 
        Dim sciPLUSsce, sci, sce As String
        Dim result As String
        sce = "@FM,H=380,780,5,50,51,52,53,97.33,97.66,98,98.33,98.66,99,99.06,99,98.86,98.96,99.19,99.28,98.99,99.3,99.32,99.4,99.33,99.32,99.42,99.42,99.45,99.53,99.5,99.47,99.55,99.59,99.49,99.5,99.61,99.45,99.6,99.59,99.59,99.6,99.6,99.64,99.58,99.63,99.59,99.59,99.41,99.52,99.49,99.39,99.52,99.51,99.52,99.64,99.74,99.54,99.41,99.24,99.44,99.32,99.27,99.3,99.38,99.33,99.18,99.12,99.09,99.38,99.36,99.35,99.3,99.3,99.37,99.46,99.25,99.35,99.32,99.22,99.23,98.97,99.27,99.35,99.22,1,1,1,S=00"
        sci = "@FM,H=380,780,5,011.918,017.370,023.123,027.502,029.961,031.166,031.506,031.533,031.492,031.447,031.263,031.112,030.960,030.825,030.737,030.635,030.420,030.406,030.286,030.155,029.998,029.865,029.777,029.652,029.516,029.420,029.297,029.172,029.087,029.003,028.879,028.773,028.686,028.542,028.494,028.382,028.265,028.204,028.119,027.999,027.900,027.844,027.739,027.699,027.524,027.420,027.368,027.276,027.284,027.225,027.115,027.037,026.992,026.858,026.751,026.590,026.596,026.542,026.455,026.444,026.416,026.332,026.210,026.065,025.967,025.993,025.963,025.913,025.918,025.828,025.734,025.707,025.539,025.476,025.547,025.500,025.438,025.358,025.370,025.401,025.335,1,2,1,S=00"
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

        Dim resultDelimetedByNewLine() As String
        Dim resultDelimetedByComma() As String
        Dim measuredSpectrum() As Single
        ReDim measuredSpectrum(spectrumCount - 1)
        Dim observer As String
        Dim standardIlluminant As String

        observer = Trim(Me.cmb_Observer.Text)
        standardIlluminant = Trim(Me.cmb_StandardIlluminant.Text)

        Debug.Print(observer)
        Debug.Print(standardIlluminant)

        resultDelimetedByNewLine = Strings.Split(result, vbCrLf)
        'MsgBox(UBound(resultDelimetedByNewLine)) 'if sci or sce : 0, sciPLUSsce =1
        resultDelimetedByComma = Strings.Split(result, ",")
        'MsgBox(UBound(resultDelimetedByComma)) ' for sci or sce : 88 , sciPLUSsce = 176
        Dim i As Integer
        Dim currentDataGridRow(105) As String

        If UBound(resultDelimetedByComma) < 89 Then ' sci or sce
            For i = 0 To spectrumCount - 1   'Spectrum from 380 to 780 nm, interval 5 nm
                currentDataGridRow(i + 18) = resultDelimetedByComma(i + 4)
                measuredSpectrum(i) = CSng(resultDelimetedByComma(i + 4))
            Next

            currentDataGridRow(0) = dataRow_Cnt
            'currentDataGridRow(1) = currentRow.Part_Category
            'currentDataGridRow(2) = currentRow.Part_Name
            'currentDataGridRow(3) = currentRow.Direction
            'currentDataGridRow(4) = currentRow.MP_Year
            'currentDataGridRow(5) = currentRow.Dev_Model
            'currentDataGridRow(6) = currentRow.Dev_Event
            'currentDataGridRow(7) = currentRow.Sequence
            'currentDataGridRow(8) = currentRow.Note

            Dim XYZarray(2) As Single
            Dim xy1931(1) As Single
            Dim Lab(2) As Single
            Dim YI As Single = 0

            XYZarray = opticalParameter.calculate_XYZ(measuredSpectrum, observer, standardIlluminant)
            xy1931 = opticalParameter.calculate_xy1931(XYZarray)
            Lab = opticalParameter.calculate_Lab_Star(XYZarray, observer, standardIlluminant)
            YI = opticalParameter.calculate_YI_ASTM_E313_73(measuredSpectrum)

            currentDataGridRow(9) = Math.Round(YI, 2)  'YI_ASTM
            currentDataGridRow(10) = Math.Round(Lab(0), 3) 'L*
            currentDataGridRow(11) = Math.Round(Lab(1), 3) 'a*
            currentDataGridRow(12) = Math.Round(Lab(2), 3) 'b*
            currentDataGridRow(13) = Math.Round(XYZarray(0), 3) 'X
            currentDataGridRow(14) = Math.Round(XYZarray(1), 3) 'Y
            currentDataGridRow(15) = Math.Round(XYZarray(2), 3) 'Z
            currentDataGridRow(16) = Math.Round(xy1931(0), 4) 'x(1931)
            currentDataGridRow(17) = Math.Round(xy1931(1), 4) 'y(1931)

            currentDataGridRow(99) = Now
            currentDataGridRow(100) = cmb_MeasurementMethod.Text
            currentDataGridRow(101) = cmb_SpecularComponent.Text
            currentDataGridRow(102) = cmb_UV.Text
            currentDataGridRow(103) = cmb_StandardIlluminant.Text
            currentDataGridRow(104) = cmb_Observer.Text
            currentDataGridRow(105) = sample_Hole_Size

            DataGridView1.Rows.Add(currentDataGridRow)
            If resultDelimetedByComma(86) = 1 And cmb_SpecularComponent.Text = "SCE" Then      '1,1(Specular component),1,S=00
            ElseIf resultDelimetedByComma(86) = 2 And cmb_SpecularComponent.Text = "SCI" Then
            ElseIf resultDelimetedByComma(86) = 3 And cmb_SpecularComponent.Text = "SCI+SCE" Then
            Else
                MsgBox("Specular Component Matching Error")
                Exit Sub
            End If


            DataGridView1.CurrentCell = DataGridView1.Rows(dataRow_Cnt - 1).Cells(0)
            Call DataGridView1_SelectionChanged(sender, e)

            dataRow_Cnt += 1
        End If

    End Sub
    Private Sub DataGridView1_select1Row(sender As Object, e As EventArgs)
        Dim spectrum_Chart_Area As DataVisualization.Charting.ChartArea
        Dim selectedRow As DataGridViewRow
        Dim rowDataStr As DataGridViewCellCollection
        Dim i As Integer
        Dim astar, bstar, lstar As Single
        Dim x1931, y1931 As Single

        spectrum_Chart_Area = spectrum_Chart.ChartAreas(0)
        selectedRow = DataGridView1.CurrentRow
        rowDataStr = selectedRow.Cells

        Dim opticalValue As Single
        Dim opticalSpectrum() As Single
        ReDim opticalSpectrum(spectrumCount - 1)

        For i = 0 To spectrumCount - 1
            opticalSpectrum(i) = CSng(rowDataStr(SPECTRUM_START_COLUMN_IN_DATAGRIDVIEW + i).Value)
        Next

        astar = CSng(rowDataStr(ASTAR_COLUMN_IN_DATAGRIDVIEW).Value)
        bstar = CSng(rowDataStr(BSTART_COLUMN_IN_DATAGRIDVIEW).Value)
        lstar = CSng(rowDataStr(LSTAR_COLUMN_IN_DATAGRIDVIEW).Value)

        x1931 = CSng(rowDataStr(x1931_COLUMN_IN_DATAGRIDVIEW).Value)
        y1931 = CSng(rowDataStr(y1931_COLUMN_IN_DATAGRIDVIEW).Value)
        '-----------------------------------------------
        ' Draw Spectrum chart
        '-----------------------------------------------
        Dim minValue, maxValue As Single
        Dim divideInt As Integer


        If UBound(opticalParameter.wavelength_5nm) = UBound(opticalSpectrum) Then

            For j = 0 To spectrumCount - 1
                If minValue > opticalSpectrum(j) Then
                    minValue = opticalSpectrum(j)
                End If
            Next

            divideInt = CInt(minValue / 10) - 1
            If divideInt < 0 Then
                divideInt = 0
            End If
            minValue = (divideInt * 10)


            With spectrum_Chart_Area
                With .AxisY
                    .Title = "Reflectance(%)"
                    .TitleFont = New Font("LG Smart UI Regular", 10, FontStyle.Regular)
                    .MajorGrid.LineColor = Color.LightBlue
                    .Minimum = minValue
                    .Maximum = 100
                    .Interval = 10
                End With

            End With

            spectrum_Chart.Series.Clear()
            spectrum_Chart.Series.Add((selectedRow.Index + 1).ToString & " : " & rowDataStr(2).Value)

            With spectrum_Chart.Series(0)
                .ChartType = DataVisualization.Charting.SeriesChartType.Line
                .BorderWidth = 1
                .Color = Color.Red
                .BorderDashStyle = DataVisualization.Charting.ChartDashStyle.Dash
                .MarkerStyle = DataVisualization.Charting.MarkerStyle.None

                Dim j As Integer

                For j = 0 To UBound(opticalSpectrum)
                    .Points.AddXY(opticalParameter.wavelength_5nm(j), opticalSpectrum(j))
                    If j = UBound(opticalSpectrum) Then
                        Debug.Print(opticalParameter.wavelength_5nm(j))
                        Debug.Print(opticalSpectrum(j))
                    End If
                Next

            End With
        End If
        spectrum_Chart.Show()


        '-----------------------------------------------
        ' Draw Lab chart
        '-----------------------------------------------
        If Len(astar) > 0 And Len(bstar) > 0 Then
            Labchart.Series.Clear()
            Labchart.Series.Add((selectedRow.Index + 1).ToString & " : " & rowDataStr(2).Value)

            With Labchart.Series(0)
                .ChartType = DataVisualization.Charting.SeriesChartType.Point
                .BorderWidth = 1
                .Color = Color.Red
                .BorderDashStyle = DataVisualization.Charting.ChartDashStyle.Dash
                .MarkerStyle = DataVisualization.Charting.MarkerStyle.Circle
                .MarkerSize = 10

                .Points.AddXY(astar, bstar)
            End With
        End If
        Labchart.Show()

        '-----------------------------------------------
        ' Draw xy chart
        '-----------------------------------------------
        If Len(x1931) > 0 And Len(y1931) > 0 Then
            xyChart.Series.Clear()
            xyChart.Series.Add((selectedRow.Index + 1).ToString & " : " & rowDataStr(2).Value)

            With xyChart.Series(0)
                .ChartType = DataVisualization.Charting.SeriesChartType.Point
                .BorderWidth = 1
                .Color = Color.Red
                .BorderDashStyle = DataVisualization.Charting.ChartDashStyle.Dash
                .MarkerStyle = DataVisualization.Charting.MarkerStyle.Circle
                .MarkerSize = 10


                .Points.AddXY(x1931, y1931)
            End With
        End If
        xyChart.Show()

    End Sub
    Private Sub DataGridView1_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridView1.SelectionChanged
        Dim spectrum_Chart_Area As DataVisualization.Charting.ChartArea
        Dim tempRowData As DataGridViewCellCollection
        Dim selectedRows As DataGridViewSelectedRowCollection
        Dim rowDataStr As DataGridViewCellCollection
        Dim i, j, k As Integer
        Dim astar, bstar, lstar As Single
        Dim x1931, y1931 As Single
        Dim opticalSpectrum() As Single
        ReDim opticalSpectrum(spectrumCount - 1)
        Dim divideInt As Integer
        Dim chartColor As Color
        Dim dataTablebesideChart(17, 0) As String
        Dim gap As Single
        Dim intervalInChart As Double

        minValue = 100
        maxValue = 0
        spectrum_Chart_Area = spectrum_Chart.ChartAreas(0)
        selectedRows = DataGridView1.SelectedRows
        spectrum_Chart.Series.Clear()
        Labchart.Series.Clear()
        xyChart.Series.Clear()

        rowDataStr = selectedRows(0).Cells()
        ' For i = 0 To selectedRows.Count - 1
        For k = 0 To 17
            'Debug.Print(rowDataStr(k).Value)
            'tempRowData = selectedRows(i).Cells()
            dataTablebesideChart(k, i) = rowDataStr(k).Value
            'Debug.Print(dataTablebesideChart(k, 0))
        Next k
        ' Next i


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
            Next

            astar = CSng(rowDataStr(ASTAR_COLUMN_IN_DATAGRIDVIEW).Value)
            bstar = CSng(rowDataStr(BSTART_COLUMN_IN_DATAGRIDVIEW).Value)
            lstar = CSng(rowDataStr(LSTAR_COLUMN_IN_DATAGRIDVIEW).Value)
            x1931 = CSng(rowDataStr(x1931_COLUMN_IN_DATAGRIDVIEW).Value)
            y1931 = CSng(rowDataStr(y1931_COLUMN_IN_DATAGRIDVIEW).Value)
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
                    .BorderDashStyle = DataVisualization.Charting.ChartDashStyle.Dash
                    .MarkerStyle = DataVisualization.Charting.MarkerStyle.None

                    For j = 0 To UBound(opticalSpectrum)
                        .Points.AddXY(opticalParameter.wavelength_5nm(j), opticalSpectrum(j))
                        If j = UBound(opticalSpectrum) Then
                            Debug.Print(opticalParameter.wavelength_5nm(j))
                            Debug.Print(opticalSpectrum(j))
                        End If
                    Next
                End With
            End If

            '-----------------------------------------------
            ' set for Lab chart
            '-----------------------------------------------
            If Len(astar) > 0 And Len(bstar) > 0 Then

                Labchart.Series.Add((rowDataStr(0).Value) & " : " & rowDataStr(2).Value)

                With Labchart.Series(i)
                    ' .Legend = (rowDataStr(0).Value) & " : " & rowDataStr(2).Value
                    .ChartType = DataVisualization.Charting.SeriesChartType.Point
                    .BorderWidth = 1
                    .Color = chartColor
                    .BorderDashStyle = DataVisualization.Charting.ChartDashStyle.Dash
                    .MarkerStyle = DataVisualization.Charting.MarkerStyle.Circle
                    .MarkerSize = 10
                    .Points.AddXY(astar, bstar)
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
                    .BorderDashStyle = DataVisualization.Charting.ChartDashStyle.Dash
                    .MarkerStyle = DataVisualization.Charting.MarkerStyle.Circle
                    .MarkerSize = 10


                    .Points.AddXY(x1931, y1931)
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

        '-----------------------------------------------
        ' show data on table beside charts
        '-----------------------------------------------
        DataGridView2.Rows.Clear()

        DataGridView2.ColumnCount = 2
        DataGridView2.Columns(0).Name = "Parameter"
        DataGridView2.Columns(1).Name = dataTablebesideChart(0, 0)

        DataGridView2.Rows.Add("Part Name", dataTablebesideChart(2, 0))
        DataGridView2.Rows.Add("YI ASTM E313-73", dataTablebesideChart(9, 0))
        DataGridView2.Rows.Add("L*", dataTablebesideChart(10, 0))
        DataGridView2.Rows.Add("a*", dataTablebesideChart(11, 0))
        DataGridView2.Rows.Add("b*", dataTablebesideChart(12, 0))
        DataGridView2.Rows.Add("Y", dataTablebesideChart(14, 0))
        DataGridView2.Rows.Add("x", dataTablebesideChart(16, 0))
        DataGridView2.Rows.Add("y", dataTablebesideChart(17, 0))

    End Sub
    Public Function RandomRGBColor() As Color
        Return Color.FromArgb(255,
            m_Rnd.Next(0, 255),
            m_Rnd.Next(0, 255),
            m_Rnd.Next(0, 255))
    End Function
    Private m_Rnd As New Random
End Class
