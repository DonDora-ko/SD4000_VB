'Author : shook.lee.lge.com (Hyun Sook Lee)
'Date : Y2022, Feb. 21st
'Purpose : Reflectance measurement SD4000 Login and Colormate.exe link program --> Instruments log file 

'Author : shook.lee.lge.com (Hyun Sook Lee)
'Date : Y2022, March. 3rd
'Purpose : add DB info. at Setting_admin. form and  new column "Test_Room"

Imports System.DirectoryServices
Imports System.Threading.Thread
Imports System.Diagnostics
Imports System.IO
Imports System.Text
Imports MySql.Data.MySqlClient
Imports System.STAThreadAttribute
Public Class Login_SD4000
    Public PowerUser As String = "administrator"
    Public PowerUserPW As String = "0413"
    Public loginLog As String
    Public userID, userInfo, instrumentName, useStartTime, useEndTime As String
    Public ServerName, DBPort, DBName, DBID, DBPW As String
    Public TableName, TestRoom As String
    'DBLocalHost = "tvdxfile.lge.com:3307"
    'DBPort = "3307"
    'DBName = "test_Instrument"
    'DBID = "optics"
    'DBPW = "$LCDoled1234"
    Dim strSQL As String = "Data Source=" & My.Settings.ServerName &
                           ";Database=" & My.Settings.DBName &
                           ";User Id=optics;Password=$LCDoled1234;SslMode=none;CharSet=utf8;Port=3307;"

    Private Sub Login_SD4000_Load_1(sender As Object, e As EventArgs) Handles MyBase.Load
        lbl_InstumentName.Text = My.Settings.PGName
    End Sub

    Private Sub btn_help_Click(sender As Object, e As EventArgs) Handles btn_help.Click
        MsgBox("On error or question, contact e-mail : shook.lge@lge.com")
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btn_login.Click
        Dim FileName As String = My.Settings.RunProgramDirectory
        Dim PGNameOnTaskManager As String = My.Settings.RunProgramName
        Dim userPW As String
        Dim i As Integer
        Dim domainNameList(4) As String
        Dim domainName As String
        Dim j As Integer = 0
        Dim displayName As String = ""
        Dim logSaveFileList(4) As String
        Dim path As String
        Dim fs As FileStream
        Dim p As New Process()
        Dim processList() As Process

        btn_login.Text = "Logging....Wait a minute"  '  While logging in change button name

        'check validation ID&PW.
        If Len(Trim(txt_EPID.Text)) <= 0 Then
            MsgBox("Please input EP ID")
            txt_EPID.Focus()
            Exit Sub
        ElseIf txt_EPID.Text = "EP ID" Then
            MsgBox("Please input EP ID")
            txt_EPID.Focus()
            Exit Sub
        End If

        If Len(Trim(txt_EPPassword.Text)) = 0 Then
            MsgBox("Please input PC Password")
            txt_EPPassword.Focus()
            Exit Sub
        ElseIf txt_EPPassword.Text = "PC PASSWORD"
            MsgBox("please Input PC Password")
            txt_EPPassword.Focus()
            Exit Sub
        End If


        'check if user is admin. or not
        '1) when user is normal user
        '2) when user is administrator, ID = administrator , PW = 0413
        userID = txt_EPID.Text
        userPW = txt_EPPassword.Text

        If userID <> PowerUser Then         '1) when user is normal user
            For i = 0 To domainNameList.Length
                'Connect with Logon Server : first of all, get logonserver domain(= DOS CMD prompt --> type "SET" --> get 'LOGONSERVER' value
                domainName = ""
                If i = 0 Then
                    domainName = "LDAP://" & System.Environment.GetEnvironmentVariable("logonserver").Split("\")(2) & ".lge.net"
                    'Debug.Print("Logon Server Name:" & domainName)
                    'Connect with logon Server as we knew - 5 domains
                ElseIf i > 0 Then
                    domainName = "LDAP://" & Trim(Setting_Admin.txt_EPDomainList.Lines(i - 1)) & ":389/DC=LGE,DC=NET"
                    'Debug.Print("Logon Server Name: " & domainName)
                End If

                Dim ldapRoot As DirectoryEntry = New DirectoryEntry(domainName, userID, userPW, AuthenticationTypes.Secure)

                Try
                    Dim Connected As Object = ldapRoot.NativeObject
                    Dim DirEntry As DirectoryEntry
                    Dim searcher As DirectorySearcher = New DirectorySearcher(ldapRoot)
                    searcher.Filter = "CN=" & userID 'search address book with EP ID

                    For Each result As SearchResult In searcher.FindAll
                        DirEntry = result.GetDirectoryEntry
                        displayName = DirEntry.Properties("displayName").Value  ' displayName contains Name/Emp.Level/department Name(EPID) i.e.)이현숙/책임연구원/TV선행기구가상검증팀(shook.lee@lge.com)
                    Next
                    Debug.Print("LoginServer Domain : " & domainName)
                    'Debug.Print("User Info : " & displayName)
                    Exit For
                Catch ex As Exception
                    'Debug.Print("exception : " & ex.ToString)
                    If ex.ToString.Contains("0x8007052E") Then ' when enter wrong ID or PW
                        MsgBox(("Wrong ID/Password"))
                        btn_login.Text = "Login"
                        txt_EPPassword.Focus()
                        btn_login.Text = "Login"
                        Exit Sub
                    ElseIf ex.ToString.Contains("0x8007203A") Then
                        Debug.Print("Server disconnected")
                        j = j + 1
                        Exit Try
                    End If

                    If j = 5 Then    'When 5 Domain server not connected all
                        MsgBox("Server Disconnected. Check Internet Connection and please contact shook.lee@lge.com")
                        btn_login.Text = "Login"
                        Exit Sub
                    End If
                End Try
            Next i

            btn_login.Text = "Login"

        ElseIf userID = PowerUser Then
            If userPW <> PowerUserPW Then
                MsgBox("Wrong ID/Password")
                Exit Sub
            End If
            displayName = userID
        End If
        '-----------------------------------------------------------------
        'Open .exe file - before (Success)
        loginLog = "" 'login log string
        p.StartInfo.FileName = My.Settings.RunProgramDirectory
        p.StartInfo.UseShellExecute = False

        Me.Hide()
        Debug.Print("----------------------------")
        p.Start()

        useStartTime = p.StartTime.ToString(("yyyy-MM-dd HH:mm:ss"))

        PGNameOnTaskManager = p.ProcessName
        My.Settings.RunProgramName = PGNameOnTaskManager
        'Debug.Print("Start Time :" & useStartTime)
        TestRoom = My.Settings.Test_Room
        instrumentName = My.Settings.PGName.Replace(vbCrLf, "")
        userInfo = displayName
        loginLog = instrumentName & ", " & userID & ", " & displayName & ", " & useStartTime
        processList = Process.GetProcessesByName(p.ProcessName)
        Debug.Print(p.ProcessName)
        Debug.Print(PGNameOnTaskManager & "   No : " & processList.Length)

        Try
            ' p.WaitForExit()
            While processList.Length > 0 ' every 1 sec. check if .exe program is running or not
                processList = Process.GetProcessesByName(p.ProcessName)
                'Debug.Print("in loop, calc : " & processList.Length)
                Sleep(1000)
            End While
        Catch ex As Exception

        End Try

        useEndTime = p.ExitTime.ToString(("yyyy-MM-dd HH:mm:ss"))
        '-----------------------------------------------------------------
        loginLog = loginLog & "," & useEndTime & "," & TestRoom
        Debug.Print(loginLog)
        Debug.Print("DirectoryLine # : " & Setting_Admin.txt_LogDirectory.Lines.Length)
        'Save Log file in several locations
        For i = 0 To Setting_Admin.txt_LogDirectory.Lines.Length - 1

            If Setting_Admin.txt_LogDirectory.Lines(i).EndsWith("\") Then
                path = (Setting_Admin.txt_LogDirectory.Lines(i)).Split(vbCrLf)(0) & instrumentName & "_UserLog.txt"
            Else
                path = (Setting_Admin.txt_LogDirectory.Lines(i)).Split(vbCrLf)(0) & "\" & instrumentName & "_UserLog.txt"

            End If

            Try
                If Not (Dir(Setting_Admin.txt_LogDirectory.Lines(i)) <> "") Then
                    fs = File.Create(path) ' Create file
                    fs.Close()
                End If
                File.AppendAllText(path, loginLog & vbNewLine)
            Catch ex As Exception
                'Debug.Print("Fail to write file at local : " & path)
            End Try
        Next i
        sendDataToDB()
        Me.Close()
        'instrumentName & "," & userId & "," & displayName & "," & p.StartTime &"," p.ExitTime
    End Sub
    Private Sub txt_EPID_Click(sender As Object, e As EventArgs) Handles txt_EPID.Click, txt_EPID.GotFocus, txt_EPID.TabStopChanged
        If txt_EPID.Text = "EP ID" Then
            txt_EPID.Clear()
        Else
            Exit Sub
        End If
    End Sub

    Private Sub txt_EPID_LostFocus(sender As Object, e As EventArgs) Handles txt_EPID.LostFocus
        If Len(Trim(txt_EPID.Text)) <= 0 Then
            txt_EPID.Text = "EP ID"
        Else
            Exit Sub
        End If
    End Sub
    Private Sub txt_EPPassword_LostFocus(sender As Object, e As EventArgs) Handles txt_EPPassword.LostFocus
        If Len(Trim(txt_EPPassword.Text)) <= 0 Then
            txt_EPPassword.PasswordChar = ""
            txt_EPPassword.Text = "PC PASSWORD"
        Else
            txt_EPPassword.PasswordChar = "*"
            Exit Sub
        End If
    End Sub
    Private Sub txt_EPPassword_Click(sender As Object, e As EventArgs) Handles txt_EPPassword.Click, txt_EPPassword.GotFocus, txt_EPPassword.TabStopChanged
        If Trim(txt_EPPassword.Text) = "PC PASSWORD" Then
            txt_EPPassword.Clear()
            txt_EPPassword.PasswordChar = "*"
        Else
            Exit Sub
        End If
    End Sub
    Private Sub Login_SD4000_Load(sender As Object, e As EventArgs)
        'MsgBox("LOAD")
        Me.txt_EPPassword.PasswordChar = ""
        Me.txt_EPPassword.Text = "PC PASSWORD"

        lbl_InstumentName.Text = My.Settings.PGName
        If Trim(My.Settings.PictureDirectory) = "" Then
            pb_IntrumentPicture.Image = My.Resources.반사율측정기_SD4000

        Else
            pb_IntrumentPicture.Image = Image.FromFile(My.Settings.PictureDirectory)
        End If


    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        If txt_EPID.Text = PowerUser Then
            If txt_EPPassword.Text = PowerUserPW Then
                Setting_Admin.Show()
            End If
        End If

    End Sub
    Private Sub sendDataToDB()
        Dim i As Integer
        Dim conn = New MySqlConnection(strSQL)
        TableName = My.Settings.TableName
        Try
            conn.Open()
        Catch ex As Exception
            MsgBox(ex.ToString)
            Debug.Print("DB Initilizatio Error")
            Me.Close()

        End Try


        If Trim(instrumentName.Length) < 1 Then
            instrumentName = "NULL"
        End If
        If Trim(userID.Length) < 1 Then
            userID = "NULL"
        End If
        If Trim(userInfo.Length) < 1 Then
            userInfo = "NULL"
        End If
        If Trim(useStartTime.Length) < 1 Then
            useStartTime = Date.Now.ToString
        End If
        If Trim(useEndTime.Length) < 1 Then
            useEndTime = Date.Now.ToString
        End If
        'sql format see below
        'Dim Sql As String = "insert into instrument_management(instrumentname,userid,userInfo,userstarttime,userendtimem,Test_Room) values('test','test','test','" & starttime & "','" & endtime & "TV_RND_KR" &"')"
        Dim Sql As String =
            "insert into " & TableName & "(instrumentname,userid,userInfo,userstarttime,userendtime,Test_Room) " &
            "values(" &
            "'" & instrumentName.Replace(vbCrLf, "") &
            "','" & userID &
            "','" & userInfo &
            "','" & useStartTime &
            "','" & useEndTime &
            "','" & TestRoom &
            "')"

        Debug.Print("SQL Command : " & Sql)
        Dim Comm = New MySqlCommand(Sql, conn)

        Try
            i = Comm.ExecuteNonQuery()
            If i = 1 Then
                Debug.Print("Success")
            Else
                Debug.Print("FAIL")
            End If
            conn.Close()

        Catch ex As Exception
            Debug.Print(ex.ToString)
        End Try


    End Sub
End Class