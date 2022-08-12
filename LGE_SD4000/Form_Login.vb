Imports System.DirectoryServices
Imports System.Threading.Thread
Imports System.Diagnostics
Imports System.IO
Imports System.Text
Imports MySql.Data.MySqlClient
Imports System.STAThreadAttribute

Public Class Form_Login
    Public PowerUser As String = "administrator"
    Public PowerUserPW As String = "0413"
    Public loginLog As String = ""
    Public path As String = ""
    Public Structure loginInfo
        Dim instrumentName As String
        Dim userID As String
        Dim displayName As String
        Dim useStartTime As String
        Dim useEndTime As String
        Dim Test_Room As String
        Dim PK_InstrumentLog As String
        Dim test_Purpose As String
    End Structure

    Public currentLoginInfo As New loginInfo



    Private Sub btn_help_Click(sender As Object, e As EventArgs) Handles btn_help.Click
        MsgBox("On Error Or question, contact e-mail  shook.lge@lge.com")
    End Sub
    Private Sub btn_login_Click(sender As Object, e As EventArgs) Handles btn_login.Click
        Dim displayName As String = ""
        Dim fs As FileStream

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

        If Len(Trim(txt_Purpose.Text)) = 0 Then
            MsgBox("Please input Measurement Purpose")
            txt_Purpose.Focus()
            Exit Sub
        ElseIf txt_Purpose.Text = "Purpose"
            MsgBox("Please input Measurement Purpose")
            txt_Purpose.Focus()
            Exit Sub
        End If

        'check if user is admin. or not
        '1) when user is normal user
        '2) when user is administrator, ID = administrator , PW = 0413
        userID = txt_EPID.Text
        '-----------------------------------------------------------------
        'Open .exe file - before (Success)
        currentLoginInfo.instrumentName = Strings.Replace(My.Settings.InstrumentName, vbLf, "")
        currentLoginInfo.userID = userID
        currentLoginInfo.displayName = connectWithDB.ldapMatching(userID, txt_EPPassword.Text)
        currentLoginInfo.test_Purpose = txt_Purpose.Text

        If Not (currentLoginInfo.displayName Is Nothing) Then
            'Debug.Print("111111" & currentLoginInfo.displayName)
            currentLoginInfo.useStartTime = Now.ToString(("yyyy-MM-dd HH:mm:ss"))
            currentLoginInfo.Test_Room = Strings.Replace(My.Settings.Test_Room, vbLf, "")

            loginLog = currentLoginInfo.displayName & ", " &
                currentLoginInfo.userID & ", " &
                currentLoginInfo.displayName & ", " &
                currentLoginInfo.useStartTime & ", " &
                currentLoginInfo.test_Purpose & vbNewLine

            currentLoginInfo.PK_InstrumentLog = sendLoginData_Start("instrument_Management")
            'Debug.Print("2222" & currentLoginInfo.displayName)
            '-----------------------------------------------------------------
            ' loginLog = loginLog & "," & useEndTime & "," & TestRoom
            'Save Log file in several locations
            If Strings.Replace(My.Settings.SaveDirectory, vbLf, "").EndsWith("\") Then
                path = Strings.Replace(My.Settings.SaveDirectory, vbLf, "") & currentLoginInfo.instrumentName & "_UserLog.txt"
            Else
                path = Strings.Replace(My.Settings.SaveDirectory, vbLf, "") & "\" & currentLoginInfo.instrumentName & "_UserLog.txt"
            End If
            Try
                If (Dir(path) = "") Then
                    fs = File.Create(path) ' Create file
                    fs.Close()
                End If
                File.AppendAllText(path, loginLog)
            Catch ex As Exception
                Debug.Print("Fail to write file at local : " & path)
            End Try
            Form_Main.Show()
            Me.Close()
        Else
            btn_login.Text = "Log in"  '  While logging in change button name
        End If


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

        lbl_InstumentName.Text = My.Settings.InstrumentName

    End Sub

    Private Sub btn_adminMenu_Click(sender As Object, e As EventArgs) Handles btn_adminMenu.Click
        If txt_EPID.Text = PowerUser Then
            If txt_EPPassword.Text = PowerUserPW Then
                Form_AdminSetting.ShowDialog()
            End If
        End If
    End Sub

    Private Sub txt_Purpose_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_Purpose.KeyDown
        If (e.KeyValue = 13) Then
            Call btn_login_Click(sender, e)
        End If
    End Sub

    Private Sub txt_Purpose_Click(sender As Object, e As EventArgs) Handles txt_Purpose.Click, txt_Purpose.TabStopChanged, txt_Purpose.GotFocus

        'MsgBox(Trim(txt_Purpose.Text))
        If Trim(txt_Purpose.Text) = "Purpose" Then
            txt_Purpose.Clear()
        Else
            Exit Sub
        End If
    End Sub

    Private Sub txt_Purpose_LostFocus(sender As Object, e As EventArgs) Handles txt_Purpose.LostFocus
        If Len(Trim(txt_Purpose.Text)) <= 0 Then
            txt_Purpose.Text = "Purpose"
        Else
            Exit Sub
        End If
    End Sub
End Class