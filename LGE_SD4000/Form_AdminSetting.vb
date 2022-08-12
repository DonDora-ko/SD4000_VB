Public Class Form_AdminSetting
    Private Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        My.Settings.SaveDirectory = txt_LogDirectory.Text
        My.Settings.ExcelTemplate = txt_excelTemplateDirectory.Text
        My.Settings.ServerName = txt_ServerName.Text
        My.Settings.ServerPort = txt_ServerPort.Text
        My.Settings.TCPIP = txt_TCPIP.Text
        My.Settings.ServerID = txt_DBID.Text
        My.Settings.ServerPW = txt_DBPW.Text
        My.Settings.Test_Room = txt_TestRoom.Text
        My.Settings.EP_LDAP_List = txt_EPDomainList.Text
        My.Settings.InstrumentName = txt_InstrumentName.Text
        My.Settings.DBAdmin = txt_DBAdmin.Text

        Form_Login.lbl_InstumentName.Text = My.Settings.InstrumentName

        My.Settings.Save()

        MsgBox("SAVED")
    End Sub
    Private Sub Setting_Admin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txt_LogDirectory.Text = My.Settings.SaveDirectory
        txt_excelTemplateDirectory.Text = My.Settings.ExcelTemplate
        txt_ServerName.Text = My.Settings.ServerName
        txt_ServerPort.Text = My.Settings.ServerPort
        txt_TCPIP.Text = My.Settings.TCPIP
        txt_DBID.Text = My.Settings.ServerID
        txt_DBPW.Text = My.Settings.ServerPW

        txt_TestRoom.Text = My.Settings.Test_Room
        txt_EPDomainList.Text = My.Settings.EP_LDAP_List
        txt_InstrumentName.Text = My.Settings.InstrumentName

        txt_DBAdmin.Text = My.Settings.DBAdmin
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btn_backTodefault.Click
        txt_LogDirectory.Text = My.Settings.defaultSettings.Split(vbNewLine)(0)
        txt_excelTemplateDirectory.Text = My.Settings.defaultSettings.Split(vbNewLine)(1)
        txt_ServerName.Text = My.Settings.defaultSettings.Split(vbNewLine)(2)
        txt_ServerPort.Text = My.Settings.defaultSettings.Split(vbNewLine)(3)
        txt_DBName.Text = My.Settings.defaultSettings.Split(vbNewLine)(4)
        txt_TCPIP.Text = My.Settings.defaultSettings.Split(vbNewLine)(5)
        txt_DBID.Text = My.Settings.defaultSettings.Split(vbNewLine)(6)
        txt_DBPW.Text = My.Settings.defaultSettings.Split(vbNewLine)(7)
        txt_TestRoom.Text = My.Settings.defaultSettings.Split(vbNewLine)(14)
        txt_InstrumentName.Text = My.Settings.defaultSettings.Split(vbNewLine)(8)

        txt_EPDomainList.Text = Trim(My.Settings.defaultSettings.Split(vbNewLine)(9)) _
            & vbNewLine & Trim(My.Settings.defaultSettings.Split(vbLf)(10)) _
            & vbNewLine & Trim(My.Settings.defaultSettings.Split(vbLf)(11)) _
            & vbNewLine & Trim(My.Settings.defaultSettings.Split(vbLf)(12)) _
            & vbNewLine & Trim(My.Settings.defaultSettings.Split(vbLf)(13))
    End Sub
End Class