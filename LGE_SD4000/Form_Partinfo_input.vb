Imports System.Threading

Public Class Form_PartInfo_Submit
    Private th2 As Thread
    Delegate Sub btnCallBack(ByVal state As Object)
    Dim cbFunc As btnCallBack
    Public dt_ModelList As DataTable

    Const INDEX_MECHA_PART_PK = 0
    Const INDEX_MECHA_PART_NAME_PK = 1
    Const INDEX_COLOR = 2
    Const INDEX_TYPE = 3
    Const INDEX_MAKER = 4
    Const INDEX_BASE = 5
    Const INDEX_CODE = 6
    Const INDEX_PARTNO = 7
    Const INDEX_APPLY = 8
    Const INDEX_CREATOR = 9
    Const WIDE_WIDTH = 1470
    Const NARROW_WIDTH = 540


    Public Structure partInfo
        Dim Part_Category As String
        Dim Part_Name As String
        Dim Direction As String
        Dim MP_Year As String
        Dim Dev_Model As String
        Dim Dev_Event As String
        Dim Note As String
    End Structure

    Public currentPartInfo As New partInfo
    Private Sub popup_Partinfo_input_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim retStr As String
        Dim delimeter As String = ","
        Dim comboList() As String
        Dim nowYear As Integer
        Dim eventList(5) As String
        Dim directionList(1) As String
        'For Each c As Control In Me.Controls
        '    If c.GetType = GetType(ComboBox) Then
        '        c.Items.Clear()
        '    End If
        'Next

        'initilize combolist
        Me.Width = NARROW_WIDTH
        btn_Submit.Enabled = False
        cmb_Category.Items.Clear()
        cmb_PartCategory.Items.Clear()
        cmb_PartName.Items.Clear()
        cmb_Direction.Items.Clear()
        cmb_Year.Items.Clear()
        cmb_Event.Items.Clear()

        retStr = connectWithDB.getComboItemsFromDB("optics.M_Optic_Part", "Category", "", "", delimeter)
        comboList = Split(retStr, delimeter)
        comboList = comboList.Distinct.ToArray
        cmb_Category.Items.AddRange(comboList)

        'set combobox list "year" - dynamic setting now +-3 year
        nowYear = Now.Year
        For i = -3 To 3
            cmb_Year.Items.Add("Y" & Strings.Right((nowYear + i), 2))
        Next i

        'set combobox list "event"
        eventList = {"Pre-PP", "PP", "DV", "PV", "Pre-MP", "MP"}  'Pre-PP/PP/DV/PV/Pre-MP/MP
        cmb_Event.Items.AddRange(eventList)

        comboboxEnabling(True, False, False, False)

        th2 = New Thread(AddressOf ThreadTask)
        th2.IsBackground = True
        th2.Start()

    End Sub
    Private Sub cmb_PartCategory_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_PartCategory.SelectedIndexChanged, cmb_PartName.MouseClick
        Dim retStr As String = ""
        Dim delimeter As String = ","
        Dim comboList() As String = {}
        Dim part_pk As String = ""
        Dim searchQuery As String
        Dim tablename1, tablename2 As String

        TableName = ""
        'btn_Submit.Enabled = False
        cmb_PartName.Items.Clear()
        cmb_PartName.Text = ""
        ' cmb_Direction.Items.Clear()

        searchQuery = "`Category` = """ & cmb_Category.Text & """ And " &
                      "`Part_Category` = """ & cmb_PartCategory.Text & """"

        If Len(cmb_PartCategory.Text) > 1 Then
            If InStr(UCase(cmb_Category.Text), "OPT", vbTextCompare) > 0 Then
                tablename1 = "optics.M_Optic_Part"
                tablename2 = "optics.M_Optic_Part_Name"
            ElseIf InStr(UCase(cmb_Category.Text), "MECH", vbTextCompare) > 0
                tablename1 = "mecha.M_Mech_Part"
                tablename2 = "mecha.M_Mech_Part_Name"
            Else MsgBox("Contact Admin.")
            End If
        Else
            Me.Width = NARROW_WIDTH
            cmb_PartName.Text = ""
            cmb_PartName.Enabled = False
        End If

        'set combobox list "part_category"
        Form_Main.currentMeasuredData.Part_PK = connectWithDB.selectPK(tablename1, searchQuery)
        part_pk = Form_Main.currentMeasuredData.Part_PK
        comboboxEnabling(True, True, True, True)

        If Len(cmb_PartCategory.Text) > 1 Then
            If InStr(UCase(cmb_Category.Text), "OPT", vbTextCompare) > 0 Then
                Me.Width = NARROW_WIDTH
                cmb_PartName.Enabled = True
                cmb_PartName.Text = ""
                cmb_PartName.Items.Clear()
                'retStr = connectWithDB.getComboItemsFromDB(tablename, "PK", "Part_Category", cmb_PartCategory.Text, delimeter)
                'comboList = Split(retStr, delimeter)
                'part_pk = comboList(1)

                'Select Case`Part_Name` from M_Optic_Part_Name where 'Master PK' = 1
                retStr = connectWithDB.getComboItemsFromDB(tablename2, "Part_Name", "Master_PK", part_pk, delimeter)
                comboList = Split(retStr, delimeter)
                cmb_PartName.Items.AddRange(comboList)
            ElseIf InStr(UCase(cmb_Category.Text), "MECH", vbTextCompare) > 0
                Me.Width = WIDE_WIDTH
                SearchModel()
                dg_ModelList.DataSource = Me.dt_ModelList
            Else MsgBox("Contact Admin.")
            End If
        Else
            Me.Width = NARROW_WIDTH
            cmb_PartName.Text = ""
            cmb_PartName.Enabled = False
        End If
    End Sub
    Private Sub SearchModel()
        Dim delimiter As String
        Me.dt_ModelList = Nothing
        Dim conditionStr As String
        delimiter = ","

        conditionStr = "`Master_PK` = """ & Form_Main.currentMeasuredData.Part_PK & """"

        'If Len(Trim(cmb_Year.Text)) > 1 Then
        'SELECT `PK`,`Model_Name`,`Year`,`Maker`,`Rev` FROM `M_Model_Name` WHERE 1

        Const INDEX_MECHA_PART_PK = 0
        Const INDEX_MECHA_PART_NAME_PK = 1
        Const INDEX_COLOR = 2
        Const INDEX_TYPE = 3
        Const INDEX_MAKER = 4
        Const INDEX_BASE = 5
        Const INDEX_CODE = 6
        Const INDEX_PARTNO = 7
        Const INDEX_APPLY = 8
        Const INDEX_CREATOR = 9

        Me.dt_ModelList = connectWithDB.getTableFromDB("mecha.M_Mech_Part_Name", "`PK`,`Master_PK`,`Color`,`Type`,`Maker`,`Base`,`Code`,`Part_Number`,`apply`,`Create_ID`", conditionStr)
        'Form_ModelList.dg_ModelList.DataSource = Me.dt_ModelList
        ' End If
    End Sub

    Public Sub btn_Submit_Click(sender As Object, e As EventArgs) Handles btn_Submit.Click
        If validatePartInfo() = False Then
            Exit Sub
        End If
        '    If InStr() Then
        My.Settings.tempPart = cmb_Category.Text
        My.Settings.tempPartCategory = cmb_PartCategory.Text
        My.Settings.tempPartName = cmb_PartName.Text
        My.Settings.tempPartDirection = cmb_Direction.Text
        My.Settings.tempMPYear = cmb_Year.Text
        My.Settings.tempMPModel = cmb_ModelName.Text
        My.Settings.tempMPEvent = cmb_Event.Text
        My.Settings.tempNote = txt_Note.Text
        Form_Main.Refresh()
        Me.Close()
    End Sub
    Private Function validatePartInfo() As Boolean  '시간 날때, C as contols로 변경해보자
        If cmb_PartCategory.Text = "" Then
            MsgBox("Select Part_Category")
            cmb_PartCategory.Focus()
            Return False
            Exit Function
        End If

        If Not cmb_PartCategory.Items.Contains(cmb_PartCategory.Text.ToString) Then
            MsgBox("Select proper Part_category In list")
            cmb_PartCategory.Focus()
            Return False
            Exit Function
        End If

        If cmb_PartName.Text = "" Then
            MsgBox("Select Part_Name")
            cmb_PartName.Focus()
            Return False
            Exit Function
        End If


        If InStr(UCase(cmb_Category.Text), "OPT", vbTextCompare) > 0 Then
            If Not cmb_PartName.Items.Contains(cmb_PartName.Text.ToString) Then
                MsgBox("Select proper Part_Name In list")
                cmb_PartName.Focus()
                Return False
                Exit Function
            End If
        ElseIf InStr(UCase(cmb_Category.Text), "MEC", vbTextCompare) > 0 Then
        Else MsgBox("Contact Admin.")
        End If


        If cmb_Direction.Text = "" Then
            MsgBox("Select Sample Direction")
            cmb_Direction.Focus()
            Return False
            Exit Function
        End If

        If Not cmb_Direction.Items.Contains(cmb_Direction.Text.ToString) Then
            MsgBox("Select proper direction In list")
            cmb_Direction.Focus()
            Return False
            Exit Function
        End If

        If cmb_Year.Text = "" Then
            MsgBox("Please Select 대략의 year")
            cmb_Year.Focus()
            Return False
            Exit Function
        End If

        If Not cmb_Year.Items.Contains(cmb_Year.Text.ToString) Then
            MsgBox("Select proper year In list")
            cmb_Year.Focus()
            Return False
            Exit Function
        End If

        If cmb_ModelName.Text = "" Then
            MsgBox("Please Input Model Name To apply")
            cmb_ModelName.Focus()
            Return False
            Exit Function
        End If

        If cmb_Event.Text = "" Then
            MsgBox("please Select current Event")
            cmb_Event.Focus()
            Return False
            Exit Function
        End If

        If Not cmb_Event.Items.Contains(cmb_Event.Text.ToString) Then
            MsgBox("Please Select current Event")
            cmb_Event.Focus()
            Return False
            Exit Function
        End If

        If Trim(txt_Note.Text) = "" Then
            txt_Note.Text = "--"
        End If

        Return True
    End Function
    Private Sub setParameterToStructure()
        With Form_Main.currentMeasuredData
            .Part_Category = cmb_PartCategory.Text
            .Part_Name = cmb_PartName.Text
            .Direction = cmb_Direction.Text
            .MP_Year = cmb_Year.Text
            .Dev_Model = cmb_ModelName.Text
            .Dev_Event = cmb_Event.Text
            .Note = txt_Note.Text
        End With
    End Sub
    Private Sub cmb_PartCategory_KeyDown(sender As Object, e As KeyEventArgs) Handles cmb_PartCategory.KeyDown
        cmb_PartCategory.SelectedIndex = Find_Item(cmb_PartCategory, cmb_PartCategory.Text)
    End Sub
    Public Function Find_Item(cmb As ComboBox, Str As String) As Integer

        Dim Count As Double
        Dim i As Double
        Dim retInt As Integer
        Count = cmb.Items.Count

        For i = 0 To Count - 1
            If InStr(1, cmb.Items(i), Str) > 0 Then
                retInt = i
                Return retInt
                Exit Function
            End If
        Next i
        Return -1

    End Function

    Private Sub ThreadTask(ByVal state As Object)
        Dim stp As Integer
        Dim newval As Integer = 0
        Dim rnd As New Random()
        Dim measureDuration As Integer = Form_Main.measureTime

        ProgressBar1.Value = 0

        For i = 0 To measureDuration / 500
            stp = ProgressBar1.Step
            newval = ProgressBar1.Value + stp
            If newval > ProgressBar1.Maximum Then
                newval = ProgressBar1.Maximum
            ElseIf newval < ProgressBar1.Minimum Then
                newval = ProgressBar1.Minimum
            End If
            ProgressBar1.BeginInvoke(Sub() ProgressBar1.Value = newval)
            Thread.Sleep(500)
        Next i

        If btn_Submit.InvokeRequired Then
            btn_Submit.BeginInvoke(Sub() btn_Submit.Enabled = True)
        Else
            btn_Submit.Enabled = True
        End If

    End Sub

    Private Sub txt_Note_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_Note.KeyDown
        If (e.KeyValue = 13) Then
            Call btn_Submit_Click(sender, e)
        End If
    End Sub

    Private Sub cmb_PartName_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_PartName.SelectedIndexChanged
        If cmb_PartName.Text.Contains("etc") Then
            MsgBox("Input Part_name And details On Note")
            txt_Note.Focus()
        End If

    End Sub

    Private Sub cmb_Category_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_Category.SelectedIndexChanged
        Dim retStr As String
        Dim delimeter As String = ","
        Dim comboList() As String
        Dim eventList(5) As String
        Dim directionList(1) As String
        Dim searchQuery As String
        Dim dbname As String
        btn_Submit.Enabled = False
        cmb_PartCategory.Items.Clear()
        cmb_PartName.Items.Clear()
        cmb_Direction.Items.Clear()

        If InStr(UCase(cmb_Category.Text), "OPT", vbTextCompare) > 0 Then
            dbname = "optics.M_Optic_Part"

            cmb_PartCategory.Items.Remove("LED")
            directionList = {"Forward", "Backward"}

        ElseIf InStr(UCase(cmb_Category.Text), "MEC", vbTextCompare) > 0 Then
            dbname = "mecha.M_Mech_Part"

            directionList = {"NA"}
            cmb_PartName.Enabled = False
        Else MsgBox("Contact Admin.")
        End If

        searchQuery = "`Category` = """ & cmb_Category.Text & """"

        'set combobox list "part_category"
        Form_Main.currentMeasuredData.Part_PK = connectWithDB.selectPK(dbname, searchQuery)
        retStr = connectWithDB.getComboItemsFromDB(dbname, "Part_Category", "Category", cmb_Category.Text, delimeter)
        comboList = Split(retStr, delimeter)
        cmb_PartCategory.Items.AddRange(comboList)

        'set combobox list  ""sheet direction"
        cmb_Direction.Items.AddRange(directionList)

        comboboxEnabling(True, True, False, True)

        If Len(cmb_PartCategory.Text) < 1 Then
            cmb_PartName.Enabled = False
        End If

        'cmb_
        'cmb_PartCategory.Text = My.Settings.tempPartCategory
        'cmb_PartName.Text = My.Settings.tempPartName
        'cmb_Direction.Text = My.Settings.tempPartDirection
        'cmb_Year.Text = My.Settings.tempMPYear
        'txt_ModelName.Text = My.Settings.tempMPModel
        'cmb_Event.Text = My.Settings.tempMPEvent
        'txt_Note.Text = My.Settings.tempNote
    End Sub




    Private Sub comboboxEnabling(category As Boolean, part_category As Boolean, part_name As Boolean, direction As Boolean)
        cmb_Category.Enabled = category
        cmb_PartCategory.Enabled = part_category
        cmb_PartName.Enabled = part_name
        cmb_Direction.Enabled = direction
    End Sub

    Private Sub btn_ModelApply_Click(sender As Object, e As EventArgs) Handles btn_ModelApply.Click
        Dim selectedRows As DataGridViewSelectedRowCollection
        Dim rowDataStr As DataGridViewCellCollection

        selectedRows = dg_ModelList.SelectedRows
        If selectedRows.Count > 0 Then
            rowDataStr = selectedRows(0).Cells()
            Form_Main.currentMeasuredData.Part_PK = rowDataStr(INDEX_MECHA_PART_PK).Value
            Form_Main.currentMeasuredData.Part_Name_PK = rowDataStr(INDEX_MECHA_PART_NAME_PK).Value
            Form_Main.currentMeasuredData.Part_Name = rowDataStr(INDEX_PARTNO).Value
            Form_Main.currentMeasuredData.Maker = rowDataStr(INDEX_MAKER).Value

            Me.Width = NARROW_WIDTH

            cmb_PartName.Text = Form_Main.currentMeasuredData.Part_Name
        Else
            Me.Width = WIDE_WIDTH
            MsgBox("Select 1 Row")
        End If

    End Sub

    Private Sub dg_ModelList_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dg_ModelList.CellMouseDoubleClick
        Call btn_ModelApply_Click(sender, e)
    End Sub

    Private Sub cmb_Year_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_Year.SelectedIndexChanged

        Dim DBName As String
        Dim searchQuery As String
        Dim retStr As String
        Dim comboList As String()
        Dim delimeter As String = ","


        DBName = ""

        If InStr(UCase(cmb_Category.Text), "OPT", vbTextCompare) > 0 Then
            DBName = "optics.M_Model_Name"
        ElseIf InStr(UCase(cmb_Category.Text), "MEC", vbTextCompare) > 0 Then
            DBName = "mecha.M_Mech_Model_Name"
        Else MsgBox("Contact Admin.")
        End If

        searchQuery = "`Year` = """ & cmb_Year.Text & """"

        'set combobox list "part_category"
        'Form_Main.currentMeasuredData.Part_PK = connectWithDB.selectPK(DBName, searchQuery)
        retStr = connectWithDB.getComboItemsFromDB(DBName, "Model_Name", "Year", cmb_Year.Text, delimeter)
        comboList = Split(retStr, delimeter)
        Array.Sort(comboList)
        cmb_ModelName.Items.AddRange(comboList)

        cmb_ModelName.Enabled = True
    End Sub

    Private Sub cmb_ModelName_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_ModelName.SelectedIndexChanged

    End Sub
End Class