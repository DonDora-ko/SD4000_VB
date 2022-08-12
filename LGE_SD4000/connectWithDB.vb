
Imports System.DirectoryServices
Imports System.Threading.Thread
Imports System.Diagnostics
Imports System.IO
Imports System.Text
Imports MySql.Data.MySqlClient
Imports System.STAThreadAttribute
Module connectWithDB
    Public PowerUser As String = "administrator"
    Public PowerUserPW As String = "0413"
    Public userID, userInfo, instrumentName, useStartTime, useEndTime As String
    Public displayName As String = ""
    Public ServerName, DBPort, DBName, DBID, DBPW As String
    Public TableName, TestRoom As String
    'DBLocalHost = "tvdxfile.lge.com:3307"
    'DBPort = "3307"
    'DBName = "test_Instrument"
    'DBID = "optics"
    'DBPW = "$LCDoled1234"

    '";Database=" & My.Settings.db &


    Public strSQL As String = "Data Source=" & My.Settings.ServerName &
                           ";User Id=" & My.Settings.ServerID &
                           ";Password=" & My.Settings.ServerPW &
                           ";SslMode=none;CharSet=utf8" &
                            ";Port=" & My.Settings.ServerPort &
                            ";"

    Public Function ldapMatching(userID As String, userPW As String) As String
        Dim i As Integer
        Dim domainNameList(4) As String
        Dim domainName As String
        Dim ep_ldap_list As String
        Dim Connected As Object
        Dim DirEntry As DirectoryEntry
        Dim searcher As DirectorySearcher
        Dim ldapRoot As DirectoryEntry

        If userID <> PowerUser Then         '1) when user is normal user
            ep_ldap_list = My.Settings.EP_LDAP_List
            domainNameList = Split(ep_ldap_list, vbCrLf)

            For i = 0 To domainNameList.Length
                'Connect with Logon Server : first of all, get logonserver domain(= DOS CMD prompt --> type "SET" --> get 'LOGONSERVER' value
                domainName = ""
                If i = 0 Then
                    domainName = "LDAP://" & System.Environment.GetEnvironmentVariable("logonserver").Split("\")(2) & ".lge.net"
                    'domainName = "LDAP://" & Trim(domainNameList(i - 1)) & ":389/DC=LGE,DC=NET"
                    Debug.Print("#####" & domainName)
                    'Connect with logon Server as we knew - 5 domains
                Else
                    domainName = "LDAP://" & Replace(Replace(Trim(domainNameList(i - 1)), vbCr, ""), vbLf, "") & ":389/DC=LGE,DC=NET"
                    Debug.Print("#####" & domainName)
                End If
                Try
                    ldapRoot = New DirectoryEntry(domainName, userID, userPW, AuthenticationTypes.Secure)
                    Connected = ldapRoot.NativeObject
                    searcher = New DirectorySearcher(ldapRoot)

                    searcher.Filter = "CN=" & userID 'search address book with EP ID

                    For Each result As SearchResult In searcher.FindAll
                        DirEntry = result.GetDirectoryEntry
                        displayName = DirEntry.Properties("displayName").Value  ' displayName contains Name/Emp.Level/department Name(EPID) i.e.)이현숙/책임연구원/TV선행기구가상검증팀(shook.lee@lge.com)
                    Next
                    Debug.Print("LoginServer Domain : " & domainName & "," & displayName)
                    Return displayName
                    Exit For

                Catch ex As Exception
                    If ex.ToString.Contains("0x8007052E") Then ' when enter wrong ID or PW
                        MsgBox(("Wrong ID/Password"))
                        Return Nothing
                        Exit Function
                    End If

                    If i = domainNameList.Length Then

                        If ex.ToString.Contains("0x8007203A") Then
                            MsgBox(("LDAP Server Disconnected" & vbCrLf & ex.Message))
                            'displayName = userID & "/admin./admin팀(shook.lee@lge.com)"
                            Return Nothing
                            Exit Function
                        Else
                            MsgBox((ex.Message))
                            Return Nothing
                            Exit Function
                        End If
                    End If

                End Try
            Next i
        Else
            If userPW <> PowerUserPW Then
                MsgBox("Wrong ID/Password")
                Return Nothing
                Exit Function
            End If
            displayName = userID & "/admin./admin팀(shook.lee@lge.com)"
            Return displayName
        End If
    End Function
    Public Function sendLoginData_Start(tableName As String) As Integer
        Dim i As Integer
        Dim conn = New MySqlConnection(strSQL)
        Dim insertQuery, searchQuery As String
        insertQuery = ""
        searchQuery = ""

        Try
            conn.Open()
        Catch ex As Exception
            MsgBox("Cannot save Instrument login Log to server" & vbCrLf & ex.ToString)
            Return Nothing
            Exit Function
        End Try

        'ex) Dim Sql As String = "insert into instrument_management(instrumentname,userid,userInfo,userstarttime,userendtimem,Test_Room) values('test','test','test','" & starttime & "','" & endtime & "TV_RND_KR" &"')"
        Dim Sql As String =
            "insert into " & tableName & "(instrumentname,userid,userInfo,userstarttime,Test_Room) " &
            "values(" &
            "'" & Form_Login.currentLoginInfo.instrumentName &
            "','" & Form_Login.currentLoginInfo.userID &
            "','" & Form_Login.currentLoginInfo.displayName &
            "','" & Form_Login.currentLoginInfo.useStartTime &
             "','" & Form_Login.currentLoginInfo.Test_Room &
            "')"

        'Debug.Print("SQL Command : " & Sql)
        Dim Comm = New MySqlCommand(Sql, conn)

        Try
            i = Comm.ExecuteNonQuery()
            If i = 1 Then
                Debug.Print("Success")
            Else
                MsgBox("Cannot save Instrument login Log to server")
                Return Nothing
                Exit Function
            End If
            conn.Close()

        Catch ex As Exception
            MsgBox("Cannot save Instrument login Log to server")
            Return Nothing
            Exit Function
        End Try

        '----------------------------------------------------
        'get PK
        '----------------------------------------------------
        Dim ds As DataRow
        ds = selectSeveralValues(tableName, "(`instrumentname` = """ & Form_Login.currentLoginInfo.instrumentName & """) And " &
                                        "(`userid` = """ & Form_Login.currentLoginInfo.userID & """) And " &
                                         "(`userInfo` = """ & Form_Login.currentLoginInfo.displayName & """) And " &
                                         "(`userstarttime` = """ & Form_Login.currentLoginInfo.useStartTime & """) And " &
                                         "(`Test_Room` = """ & Form_Login.currentLoginInfo.Test_Room & """)")

        Return ds.Item("id")
        'lv2_ID = currentDataStructure.Maker = ds.Item("Part_2lv_ID")  'ex) PK matching value = "RE-009" ,"DP-012"...

    End Function
    Public Sub UpdateLoginData_End(tableName As String)
        Dim i As Integer
        Dim conn = New MySqlConnection(strSQL)
        Dim UpdateQuery As String
        UpdateQuery = ""

        Try
            conn.Open()
        Catch ex As Exception
            MsgBox("Cannot save Instrument login Log to server" & vbCrLf & ex.ToString)
            Exit Sub
        End Try
        'Ex) UPDATE `instrument_Management` SET `Test_Room`="TV_KR_RND"	 WHERE `id`=346
        Dim Sql As String = "UPDATE `" & tableName & "` SET `userendtime`= """ & Form_Login.currentLoginInfo.useEndTime & """ WHERE `id`=" & Form_Login.currentLoginInfo.PK_InstrumentLog
        Dim Comm = New MySqlCommand(Sql, conn)

        'Debug.Print(tableName)
        Debug.Print(Sql)
        Try
            i = Comm.ExecuteNonQuery()
            If i = 1 Then
                Debug.Print("Success")
            Else
                MsgBox("Cannot save Instrument login Log to server")
                Exit Sub
            End If
            conn.Close()

        Catch ex As Exception
            MsgBox("Cannot save Instrument login Log to server")
            Exit Sub
        End Try
    End Sub
    Public Function sendDataToDB_SD4000(currentDataStructure As Form_Main.measuredData) As Integer
        Dim i As Integer
        Dim conn = New MySqlConnection(strSQL)
        Dim insertQuery, searchQuery As String
        Dim colIndex As Integer = 0
        Dim columnName As String = ""
        Dim value As String = ""
        Dim searchValue As String = ""
        Dim searchResult As String = ""
        Dim part_PK As String = ""
        Dim ds As DataRow
        Dim part_info_PK As String = ""
        insertQuery = ""
        searchQuery = ""

        Try
            conn.Open()
        Catch ex As Exception
            MsgBox("Error While sending Date To DB" & vbCrLf & ex.ToString)
            'Debug.Print("DB Connection Error")
            Return 0
            Exit Function
        End Try

        currentDataStructure.instrument = "Reflectometer"
        '----------------------------------------------------------------
        'get part_pk from M_Optic_Part, search key value as a part_category
        '----------------------------------------------------------------
        searchValue = currentDataStructure.Part_Category
        part_PK = select1ColumnWith1Condition("M_Optic_Part", "PK", "Part_Category", searchValue)
        currentDataStructure.Part_PK = part_PK
        '----------------------------------------------------------------
        'get part_info(Part_Name_PK,Maker,Part_Rev), with Part_Name and park_PK, Search Part_Name_PK, maker, Rev
        '----------------------------------------------------------------
        searchValue = "`Master_PK` = " & currentDataStructure.Part_PK & " And " & "`Part_Name` = """ & currentDataStructure.Part_Name & """"
        ds = selectSeveralValues("M_Optic_Part_Name", searchValue)
        currentDataStructure.Part_Name_PK = ds.Item("PK")
        currentDataStructure.Maker = ds.Item("Maker")
        currentDataStructure.Part_Rev = ds.Item("Rev")
        '----------------------------------------------------------------
        'add data on "W_Sheet_Part_Info" table : info_PK is unique PK value when measuring or storing data
        '----------------------------------------------------------------
        part_info_PK = insertOn_W_Optic_Part_Info("W_Sheet_Part_Info", currentDataStructure)
        If part_info_PK Is Nothing Then
            Return 0
            Exit Function
        End If
        'Debug.Print("★☆Part_PK, Part_Info_PK :  " & part_PK & "," & part_info_PK)
        '----------------------------------------------------------------
        'deposit "INSERT Queries" for L*~v' (11 parameters)
        '0:L*, 1:a*, 2:b*, 3:X, 4:Y, 5:Z, 6:x,7:y,8:YI,9:u',10:v'
        '----------------------------------------------------------------
        Dim opticaldataString(10, 0) As String
        Dim arrayParam(10) As String
        Dim arrayValue(10) As String
        arrayParam = {"L*_R", "a*_R", "b*_R", "X_R", "Y_R", "Z_R", "CIE_x_R", "CIE_y_R", "YI ASTM E313-73_R", "u'_R", "v'_R"}
        arrayValue = {currentDataStructure.L_Star, currentDataStructure.a_Star, currentDataStructure.b_Star, currentDataStructure.X, currentDataStructure.Y, currentDataStructure.Z, currentDataStructure.CIE_x, currentDataStructure.CIE_y, currentDataStructure.YI_ASTM_E313_73, currentDataStructure.u_prime, currentDataStructure.v_prime}
        Dim retValue As String

        For i = 0 To 10
            retValue = insertQueryMakeForM_Optic_Part_Properties_ID("W_Sheet_Part_Measure", arrayParam(i), 0, arrayValue(i), part_PK, part_info_PK, currentDataStructure)
            If retValue Is Nothing Then
                retValue = ""
            End If
            opticaldataString(i, 0) = retValue
        Next
        insertQuery = ""
        For i = 0 To 10
            insertQuery += opticaldataString(i, 0)
        Next
        '----------------------------------------------------------------
        'upload optica parameters : L* ~ u'/v'
        '----------------------------------------------------------------
        Dim retInt As Integer
        retInt = insertToTable("W_Sheet_Part_Measure", insertQuery, currentDataStructure)
        If retInt = Nothing Then
            Return 0
            Exit Function
        End If

        retInt = Nothing
        'Debug.Print("L*~v' parameter Insert Query : " & insertQuery)
        '----------------------------------------------------------------
        'deposit "INSERT Queries" for Spectrum(Spectrum Count = 81 for SD4000, delta : 5nm)
        '----------------------------------------------------------------
        insertQuery = ""
        For i = 0 To Form_Main.spectrumCount - 1
            retValue = ""
            Dim wavelength As Integer
            wavelength = Form_Main.SPECTRUM_START + Form_Main.SPECTRUM_INTERVAL * i
            retValue = insertQueryMakeForM_Optic_Part_Properties_ID("W_Sheet_Part_Measure", "Reflectance", wavelength, currentDataStructure.Spectrum(i), part_PK, part_info_PK, currentDataStructure)
            'retValue = insertQueryMake("W_Optic_Part_Measure", arrayParam(i), arrayValue(i), part_PK, part_info_PK)
            If retValue Is Nothing Then
                retValue = ""
            End If
            insertQuery += retValue
        Next
        retInt = insertToTable("W_Sheet_Part_Measure", insertQuery, currentDataStructure)
        If retInt = Nothing Then
            Return 0
            Exit Function
        End If
        'Debug.Print(insertQuery)
        Return 1
    End Function
    Public Function getComboItemsFromDB(tableName As String, searchColumnName As String, conditionColumnName As String, conditionValue As String, delimeter As String) As String
        Dim conn = New MySqlConnection(strSQL)
        Dim dbDataSet As New DataSet
        Dim dbDataAdapter As New MySqlDataAdapter
        Dim dbResult As String = ""
        Dim queryStr As String = ""
        If Len(conditionColumnName) < 1 Then
            queryStr = "select " & "`" & searchColumnName & "`" & " from " & tableName
        Else
            queryStr = "select " & "`" & searchColumnName & "`" & " from " & tableName & " where " & "`" & conditionColumnName & "`" & "= """ & conditionValue & """"
        End If

        'Debug.Print(queryStr)

        Try
            conn.Open()
            dbDataAdapter.SelectCommand = New MySqlCommand(queryStr, conn)
            dbDataAdapter.Fill(dbDataSet)

            For Each ds As DataRow In dbDataSet.Tables(0).Rows
                dbResult = dbResult & delimeter & ds.Item(searchColumnName)
            Next
            'MsgBox(dbResult)
            conn.Close()
        Catch ex As Exception
            MsgBox("Error in getComboItemsFromDB :  " & ex.Message)
            Return Nothing
        End Try

        Return dbResult
    End Function

    Public Function selectPK(tableName As String, conditionString As String) As String
        Dim conn = New MySqlConnection(strSQL)
        Dim dbDataSet As New DataSet
        Dim dbDataAdapter As New MySqlDataAdapter
        Dim dbResult As String = ""
        Dim queryStr As String = ""
        Dim ds As DataRow

        queryStr = "Select `PK` " & "from " & tableName & " where " & conditionString
        Debug.Print("Part Info Search : " & queryStr)



        Try
            conn.Open()
            dbDataAdapter.SelectCommand = New MySqlCommand(queryStr, conn)
            dbDataAdapter.Fill(dbDataSet)

            ds = dbDataSet.Tables(0).Rows(0)
            dbResult = ds.Item("PK")
            conn.Close()
        Catch ex As Exception
            MsgBox("Error while selecting WPartInfoPK : " & ex.Message)
            Return Nothing
        End Try

        Return dbResult
    End Function
    Public Function select1ColumnWith1Condition(tableName As String, searchColumnName As String, conditionColumnName As String, conditionValue As String) As String
        Dim conn = New MySqlConnection(strSQL)
        Dim dbDataSet As New DataSet
        Dim dbDataAdapter As New MySqlDataAdapter
        Dim dbResult As String = ""
        Dim queryStr As String = ""
        Dim ds As DataRow

        If Len(conditionColumnName) < 1 Then
            queryStr = "select " & "`" & searchColumnName & "`" & " from " & tableName
        Else
            queryStr = "select " & "`" & searchColumnName & "`" & " from " & tableName & " where " & "`" & conditionColumnName & "`" & "= """ & conditionValue & """"
        End If

        'Debug.Print(queryStr)

        Try
            conn.Open()
            dbDataAdapter.SelectCommand = New MySqlCommand(queryStr, conn)
            dbDataAdapter.Fill(dbDataSet)

            ds = dbDataSet.Tables(0).Rows(0)
            dbResult = ds.Item(searchColumnName)
            conn.Close()
        Catch ex As Exception
            MsgBox("Error in selectValueFromDB : " & ex.Message)
            Return Nothing
        End Try

        Return dbResult
    End Function
    Private Function select1ColumnWithSeveralCondition(tableName As String, searchColumnName As String, conditionString As String) As String
        Dim conn = New MySqlConnection(strSQL)
        Dim dbDataSet As New DataSet
        Dim dbDataAdapter As New MySqlDataAdapter
        Dim dbResult As String = ""
        Dim queryStr As String = ""
        Dim ds As DataRow

        queryStr = "select " & "`" & searchColumnName & "`" & " from " & tableName & " where " & conditionString
        'Debug.Print("select Several Values with conditions: " & queryStr)
        Try
            conn.Open()
            dbDataAdapter.SelectCommand = New MySqlCommand(queryStr, conn)
            dbDataAdapter.Fill(dbDataSet)

            ds = dbDataSet.Tables(0).Rows(0)
            dbResult = ds.Item(searchColumnName)
            conn.Close()
        Catch ex As Exception
            'MsgBox("Error while selecting PartInfo : " & ex.Message)
            Debug.Print("Error while selecting part Info.")
            Return Nothing
        End Try

        Return dbResult
    End Function
    Private Function selectSeveralValues(tableName As String, conditionString As String) As DataRow
        Dim conn = New MySqlConnection(strSQL)
        Dim dbDataSet As New DataSet
        Dim dbDataAdapter As New MySqlDataAdapter
        Dim dbResult As String = ""
        Dim queryStr As String = ""
        Dim ds As DataRow

        queryStr = "select * " & "from " & tableName & " where " & conditionString
        Debug.Print("select Several Values with conditions: " & queryStr)

        Try
            conn.Open()
            dbDataAdapter.SelectCommand = New MySqlCommand(queryStr, conn)
            dbDataAdapter.Fill(dbDataSet)

            ds = dbDataSet.Tables(0).Rows(0)
            conn.Close()
        Catch ex As Exception
            'MsgBox("Error while selecting PartInfo : " & ex.Message)
            Debug.Print("Error while selecting part Info.")
            Return Nothing
        End Try

        Return ds
    End Function

    Public Function getTableFromDB(tableName As String, searchColumnName As String, condition As String) As DataTable

        Dim conn = New MySqlConnection(strSQL)
        Dim dbDataSet As New DataSet
        Dim dbDataAdapter As New MySqlDataAdapter
        Dim dbResult As String = ""
        Dim queryStr As String = ""
        Dim table As New DataTable()

        If Len(condition) < 1 Then
            queryStr = "select " & searchColumnName & " from " & tableName
        Else
            queryStr = "select " & searchColumnName & " from " & tableName & " where " & condition
        End If

        Debug.Print("in getTableFromDB : " & queryStr)

        Try
            conn.Open()
            dbDataAdapter.SelectCommand = New MySqlCommand(queryStr, conn)
            dbDataAdapter.Fill(table)

            'For Each ds As DataRow In dbDataSet.Tables(0).Rows
            'dbResult = ds.Item("PK")
            'MsgBox(dbResult)
            'Next

            conn.Close()
        Catch ex As Exception
            MsgBox("Error In getComboItemsFromDB :  " & ex.Message)
            Return Nothing
        End Try

        Return table
    End Function


    Private Function insertOn_W_Optic_Part_Info(tableName As String, dataStructure As Form_Main.measuredData) As String
        Dim conn = New MySqlConnection(strSQL)
        Dim scmd As MySqlCommand
        Dim insertQuery As String = ""
        Dim searchQuery As String = ""
        Dim retValue As String = ""

        insertQuery = "Insert into " & tableName & " (Part_Name_PK,Use_Flag,Part_Category,Part_Name,Maker,Part_Rev,Direction,Year,Model,Event,Seq,ID,DateTime,Note,Instrument) " &
                        "values(" &
        """" & dataStructure.Part_Name_PK &
        """,""Y" &
        """,""" & dataStructure.Part_Category &
        """,""" & dataStructure.Part_Name &
        """,""" & dataStructure.Maker &
        """,""" & dataStructure.Part_Rev &
        """,""" & dataStructure.Direction &
        """,""" & dataStructure.MP_Year &
        """,""" & dataStructure.Dev_Model &
         """,""" & dataStructure.Dev_Event &
         """,""" & dataStructure.Sequence &
         """,""" & Form_Login.currentLoginInfo.userID &
         """,""" & dataStructure.DateTime &
         """,""" & dataStructure.Note &
         """,""" & dataStructure.instrument &
        """)"

        Debug.Print("insertQuery1: " & insertQuery)
        Try
            conn.Open()
            scmd = New MySqlCommand(insertQuery, conn)
            scmd.ExecuteNonQuery()
            'searchValue = "`Master PK` = " & part_PK & " and " & "`Part_Name` = """ & currentDataStructure.Part_Name & """"
            'MsgBox(currentLoginInfo.userID)
            searchQuery = "`Part_Category` = """ & dataStructure.Part_Category & """" &
                " and " & "`Part_Name` = """ & dataStructure.Part_Name & """" &
                " and " & "`Direction` = """ & dataStructure.Direction & """" &
                " and " & "`Year` = """ & dataStructure.MP_Year & """" &
                " and " & "`Model` = """ & dataStructure.Dev_Model & """" &
                " and " & "`ID` = """ & Form_Login.currentLoginInfo.userID & """" &
                " and " & "`DateTime` = """ & dataStructure.DateTime & """" &
                " And " & "`Note` = """ & dataStructure.Note & """"

            retValue = selectPK(tableName, searchQuery)
            scmd.Dispose()
            conn.Close()
        Catch ex As Exception
            MsgBox("Error while insert : " & ex.Message & vbCrLf & "Can't save to DB " & dataStructure.Part_Category & ":" & dataStructure.Part_Name)
            Return Nothing
        End Try
        Return retValue
    End Function

    Private Function insertQueryMakeForM_Optic_Part_Properties_ID(tableName As String, parameter As String, wavelength As Integer, data As Single, part_pk As Integer, part_info_PK As Integer, dataStructure As Form_Main.measuredData) As String
        Dim insertQuery As String
        Dim PK2, lv3_ID, lv3_Parameter, lv3_Unit As String
        Dim ds As DataRow

        If (parameter = "Reflectance") And (wavelength >= 300) Then ' in case of Spectrum data
            Try
                ds = selectSeveralValues("M_Optic_Part_Properties_ID", "(`Master_Parameter` = """ & parameter & """) And (`Part_PK`= " & part_pk & ")")
                If Not (ds Is Nothing) Then
                    PK2 = ds.Item("PK")  'ex) 9
                    'lv2_ID = currentDataStructure.Maker = ds.Item("Part_2lv_ID")  'ex) PK matching value = "RE-009" ,"DP-012"...

                    ds = selectSeveralValues("M_Optic_Part_Properties", "(`Properties_PK` =" & PK2 & ") AND ( `Use_Flag`=""Y"") AND (`Parameter`=""" & parameter & "_" & wavelength & "nm"")")
                    'PK3 = ds.Item("PK")
                    lv3_ID = ds.Item("Part_3lv_ID")
                    lv3_Parameter = ds.Item("Parameter")
                    lv3_Unit = ds.Item("Unit")

                    insertQuery = ""

                    insertQuery = "Insert into " & tableName & " (Part_Info_PK,Properties_PK,Part_3lv_ID,Parameter,Unit,Data) " &
                        "values(" &
                        """" & part_info_PK &
                        """,""" & PK2 &
                        """,""" & lv3_ID &
                        """,""" & lv3_Parameter &
                        """,""" & lv3_Unit &
                        """,""" & data &
                        """);"
                Else
                    Return Nothing
                End If
            Catch ex As Exception
                Debug.Print("Error in connectWithDB.insertData : " & dataStructure.Part_Name & "," & parameter & vbCrLf & ex.Message)
                Return Nothing
            End Try
            Return insertQuery
        Else 'not spectrum Data
            Try
                ds = selectSeveralValues("M_Optic_Part_Properties_ID", "(`Master_Parameter` = """ & parameter & """) And (`Part_PK`= " & part_pk & ")")
                If Not (ds Is Nothing) Then
                    PK2 = ds.Item("PK")  'ex) 9
                    'lv2_ID = currentDataStructure.Maker = ds.Item("Part_2lv_ID")  'ex) PK matching value = "RE-009" ,"DP-012"...

                    ds = selectSeveralValues("M_Optic_Part_Properties", "(`Properties_PK` =" & PK2 & ") AND ( `Use_Flag`=""Y"")")
                    'PK3 = ds.Item("PK")
                    lv3_ID = ds.Item("Part_3lv_ID")
                    lv3_Parameter = ds.Item("Parameter")
                    lv3_Unit = ds.Item("Unit")

                    insertQuery = ""

                    insertQuery = "Insert into " & tableName & " (Part_Info_PK,Properties_PK,Part_3lv_ID,Parameter,Unit,Data) " &
                    "values(" &
                    """" & part_info_PK &
                    """,""" & PK2 &
                    """,""" & lv3_ID &
                    """,""" & lv3_Parameter &
                    """,""" & lv3_Unit &
                    """,""" & data &
                    """);"
                Else
                    Return Nothing
                End If
            Catch ex As Exception
                Debug.Print("Error in connectWithDB.insertData : " & dataStructure.Part_Name & "," & parameter & vbCrLf & ex.Message)
                Return Nothing
            End Try
            Return insertQuery
        End If

    End Function
    Private Function insertToTable(tableName As String, conditionString As String, dataStructure As Form_Main.measuredData) As Integer
        Dim conn = New MySqlConnection(strSQL)
        Dim scmd As MySqlCommand
        Dim retValue As Integer

        Try
            'Debug.Print("insertQuery1: " & conditionString)
            conn.Open()
            scmd = New MySqlCommand(conditionString, conn)
            retValue = scmd.ExecuteNonQuery()
            scmd.Dispose()
            conn.Close()
        Catch ex As Exception
            MsgBox("Error in ""insertToTable""  : " & dataStructure.Part_Name & vbCrLf & ex.Message)
            Return Nothing
        End Try
        Return retValue
    End Function
End Module
