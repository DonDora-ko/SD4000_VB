<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_AdminSetting
    Inherits System.Windows.Forms.Form

    'Form은 Dispose를 재정의하여 구성 요소 목록을 정리합니다.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows Form 디자이너에 필요합니다.
    Private components As System.ComponentModel.IContainer

    '참고: 다음 프로시저는 Windows Form 디자이너에 필요합니다.
    '수정하려면 Windows Form 디자이너를 사용하십시오.  
    '코드 편집기에서는 수정하지 마세요.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txt_TCPIP = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txt_DBName = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txt_ServerPort = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txt_DBPW = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txt_DBID = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txt_ServerName = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txt_InstrumentName = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txt_excelTemplateDirectory = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txt_LogDirectory = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txt_EPDomainList = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txt_TestRoom = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.btn_save = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txt_DBAdmin = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.btn_backTodefault = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txt_DBAdmin)
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Controls.Add(Me.txt_TCPIP)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txt_DBName)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.txt_ServerPort)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.txt_DBPW)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txt_DBID)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txt_ServerName)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Font = New System.Drawing.Font("LG Smart UI Regular", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(20, 90)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(516, 296)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "DataBase"
        '
        'txt_TCPIP
        '
        Me.txt_TCPIP.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txt_TCPIP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_TCPIP.Font = New System.Drawing.Font("LG Smart UI Regular", 10.0!)
        Me.txt_TCPIP.ForeColor = System.Drawing.Color.Black
        Me.txt_TCPIP.Location = New System.Drawing.Point(118, 145)
        Me.txt_TCPIP.Name = "txt_TCPIP"
        Me.txt_TCPIP.Size = New System.Drawing.Size(153, 23)
        Me.txt_TCPIP.TabIndex = 57
        Me.txt_TCPIP.Text = "1"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("LG Smart UI Regular", 9.5!, System.Drawing.FontStyle.Bold)
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(98, Byte), Integer), CType(CType(98, Byte), Integer), CType(CType(98, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(17, 147)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(53, 15)
        Me.Label6.TabIndex = 56
        Me.Label6.Text = "TCP/IP"
        '
        'txt_DBName
        '
        Me.txt_DBName.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txt_DBName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_DBName.Font = New System.Drawing.Font("LG Smart UI Regular", 10.0!)
        Me.txt_DBName.ForeColor = System.Drawing.Color.Black
        Me.txt_DBName.Location = New System.Drawing.Point(118, 106)
        Me.txt_DBName.Name = "txt_DBName"
        Me.txt_DBName.Size = New System.Drawing.Size(153, 23)
        Me.txt_DBName.TabIndex = 55
        Me.txt_DBName.Text = "optics"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("LG Smart UI Regular", 9.5!, System.Drawing.FontStyle.Bold)
        Me.Label13.ForeColor = System.Drawing.Color.FromArgb(CType(CType(98, Byte), Integer), CType(CType(98, Byte), Integer), CType(CType(98, Byte), Integer))
        Me.Label13.Location = New System.Drawing.Point(17, 108)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(66, 15)
        Me.Label13.TabIndex = 54
        Me.Label13.Text = "DB Name"
        '
        'txt_ServerPort
        '
        Me.txt_ServerPort.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txt_ServerPort.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_ServerPort.Font = New System.Drawing.Font("LG Smart UI Regular", 10.0!)
        Me.txt_ServerPort.ForeColor = System.Drawing.Color.Black
        Me.txt_ServerPort.Location = New System.Drawing.Point(118, 67)
        Me.txt_ServerPort.Name = "txt_ServerPort"
        Me.txt_ServerPort.Size = New System.Drawing.Size(153, 23)
        Me.txt_ServerPort.TabIndex = 53
        Me.txt_ServerPort.Text = "3307"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("LG Smart UI Regular", 9.5!, System.Drawing.FontStyle.Bold)
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(98, Byte), Integer), CType(CType(98, Byte), Integer), CType(CType(98, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(17, 69)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(36, 15)
        Me.Label9.TabIndex = 52
        Me.Label9.Text = "Port"
        '
        'txt_DBPW
        '
        Me.txt_DBPW.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txt_DBPW.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_DBPW.Font = New System.Drawing.Font("LG Smart UI Regular", 10.0!)
        Me.txt_DBPW.ForeColor = System.Drawing.Color.Black
        Me.txt_DBPW.Location = New System.Drawing.Point(118, 223)
        Me.txt_DBPW.Name = "txt_DBPW"
        Me.txt_DBPW.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txt_DBPW.Size = New System.Drawing.Size(153, 23)
        Me.txt_DBPW.TabIndex = 49
        Me.txt_DBPW.Text = "$LCDoled1234"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("LG Smart UI Regular", 9.5!, System.Drawing.FontStyle.Bold)
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(98, Byte), Integer), CType(CType(98, Byte), Integer), CType(CType(98, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(17, 225)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(29, 15)
        Me.Label5.TabIndex = 48
        Me.Label5.Text = "PW"
        '
        'txt_DBID
        '
        Me.txt_DBID.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txt_DBID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_DBID.Font = New System.Drawing.Font("LG Smart UI Regular", 10.0!)
        Me.txt_DBID.ForeColor = System.Drawing.Color.Black
        Me.txt_DBID.Location = New System.Drawing.Point(118, 184)
        Me.txt_DBID.Name = "txt_DBID"
        Me.txt_DBID.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txt_DBID.Size = New System.Drawing.Size(153, 23)
        Me.txt_DBID.TabIndex = 47
        Me.txt_DBID.Text = "optics"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("LG Smart UI Regular", 9.5!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(98, Byte), Integer), CType(CType(98, Byte), Integer), CType(CType(98, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(17, 186)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(20, 15)
        Me.Label1.TabIndex = 46
        Me.Label1.Text = "ID"
        '
        'txt_ServerName
        '
        Me.txt_ServerName.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txt_ServerName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_ServerName.Font = New System.Drawing.Font("LG Smart UI Regular", 10.0!)
        Me.txt_ServerName.ForeColor = System.Drawing.Color.Black
        Me.txt_ServerName.Location = New System.Drawing.Point(118, 28)
        Me.txt_ServerName.Name = "txt_ServerName"
        Me.txt_ServerName.Size = New System.Drawing.Size(153, 23)
        Me.txt_ServerName.TabIndex = 39
        Me.txt_ServerName.Text = "tvdxfile.lge.com"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("LG Smart UI Regular", 9.5!, System.Drawing.FontStyle.Bold)
        Me.Label12.ForeColor = System.Drawing.Color.FromArgb(CType(CType(98, Byte), Integer), CType(CType(98, Byte), Integer), CType(CType(98, Byte), Integer))
        Me.Label12.Location = New System.Drawing.Point(17, 30)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(86, 15)
        Me.Label12.TabIndex = 38
        Me.Label12.Text = "ServerName"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txt_InstrumentName)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.txt_excelTemplateDirectory)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.txt_LogDirectory)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.txt_EPDomainList)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.txt_TestRoom)
        Me.GroupBox2.Controls.Add(Me.Label15)
        Me.GroupBox2.Font = New System.Drawing.Font("LG Smart UI Regular", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(20, 392)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(516, 274)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "etc...."
        '
        'txt_InstrumentName
        '
        Me.txt_InstrumentName.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txt_InstrumentName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_InstrumentName.Font = New System.Drawing.Font("LG Smart UI Regular", 10.0!)
        Me.txt_InstrumentName.ForeColor = System.Drawing.Color.Black
        Me.txt_InstrumentName.Location = New System.Drawing.Point(124, 32)
        Me.txt_InstrumentName.Name = "txt_InstrumentName"
        Me.txt_InstrumentName.Size = New System.Drawing.Size(147, 23)
        Me.txt_InstrumentName.TabIndex = 55
        Me.txt_InstrumentName.Text = "SD4000"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("LG Smart UI Regular", 9.5!, System.Drawing.FontStyle.Bold)
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(98, Byte), Integer), CType(CType(98, Byte), Integer), CType(CType(98, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(17, 34)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(79, 30)
        Me.Label8.TabIndex = 54
        Me.Label8.Text = "Instrument" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Name"
        '
        'txt_excelTemplateDirectory
        '
        Me.txt_excelTemplateDirectory.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txt_excelTemplateDirectory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_excelTemplateDirectory.Font = New System.Drawing.Font("LG Smart UI Regular", 10.0!)
        Me.txt_excelTemplateDirectory.ForeColor = System.Drawing.Color.Black
        Me.txt_excelTemplateDirectory.Location = New System.Drawing.Point(124, 239)
        Me.txt_excelTemplateDirectory.Name = "txt_excelTemplateDirectory"
        Me.txt_excelTemplateDirectory.Size = New System.Drawing.Size(371, 23)
        Me.txt_excelTemplateDirectory.TabIndex = 53
        Me.txt_excelTemplateDirectory.Text = "D:\Data\가상검증팀\Template\Reflectance_Template(don't modify).xlsx"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("LG Smart UI Regular", 9.5!, System.Drawing.FontStyle.Bold)
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(98, Byte), Integer), CType(CType(98, Byte), Integer), CType(CType(98, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(17, 239)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(106, 15)
        Me.Label7.TabIndex = 52
        Me.Label7.Text = "excel Template"
        '
        'txt_LogDirectory
        '
        Me.txt_LogDirectory.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txt_LogDirectory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_LogDirectory.Font = New System.Drawing.Font("LG Smart UI Regular", 10.0!)
        Me.txt_LogDirectory.ForeColor = System.Drawing.Color.Black
        Me.txt_LogDirectory.Location = New System.Drawing.Point(124, 204)
        Me.txt_LogDirectory.Name = "txt_LogDirectory"
        Me.txt_LogDirectory.Size = New System.Drawing.Size(371, 23)
        Me.txt_LogDirectory.TabIndex = 51
        Me.txt_LogDirectory.Text = "D:\Data\"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("LG Smart UI Regular", 9.5!, System.Drawing.FontStyle.Bold)
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(98, Byte), Integer), CType(CType(98, Byte), Integer), CType(CType(98, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(17, 204)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(103, 15)
        Me.Label4.TabIndex = 50
        Me.Label4.Text = "Save Directory" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'txt_EPDomainList
        '
        Me.txt_EPDomainList.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txt_EPDomainList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_EPDomainList.Font = New System.Drawing.Font("LG Smart UI Regular", 10.0!)
        Me.txt_EPDomainList.ForeColor = System.Drawing.Color.Black
        Me.txt_EPDomainList.Location = New System.Drawing.Point(124, 101)
        Me.txt_EPDomainList.Multiline = True
        Me.txt_EPDomainList.Name = "txt_EPDomainList"
        Me.txt_EPDomainList.Size = New System.Drawing.Size(371, 90)
        Me.txt_EPDomainList.TabIndex = 49
        Me.txt_EPDomainList.Text = "lge.net" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "ptkmf10-dc12.lge.net" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "156.147.162.251" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "PTKMF10-DC13.lge.net" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "BSNDR10-DC1" &
    "1.lge.net"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("LG Smart UI Regular", 9.5!, System.Drawing.FontStyle.Bold)
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(98, Byte), Integer), CType(CType(98, Byte), Integer), CType(CType(98, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(17, 101)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(103, 30)
        Me.Label3.TabIndex = 48
        Me.Label3.Text = "LDAP Domain" & Global.Microsoft.VisualBasic.ChrW(10) & "(Max. 5개 설정)"
        '
        'txt_TestRoom
        '
        Me.txt_TestRoom.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txt_TestRoom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_TestRoom.Font = New System.Drawing.Font("LG Smart UI Regular", 10.0!)
        Me.txt_TestRoom.ForeColor = System.Drawing.Color.Black
        Me.txt_TestRoom.Location = New System.Drawing.Point(124, 68)
        Me.txt_TestRoom.Name = "txt_TestRoom"
        Me.txt_TestRoom.Size = New System.Drawing.Size(147, 23)
        Me.txt_TestRoom.TabIndex = 47
        Me.txt_TestRoom.Text = "TV_KR_RND"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("LG Smart UI Regular", 9.5!, System.Drawing.FontStyle.Bold)
        Me.Label15.ForeColor = System.Drawing.Color.FromArgb(CType(CType(98, Byte), Integer), CType(CType(98, Byte), Integer), CType(CType(98, Byte), Integer))
        Me.Label15.Location = New System.Drawing.Point(17, 70)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(33, 15)
        Me.Label15.TabIndex = 46
        Me.Label15.Text = "Site"
        '
        'btn_save
        '
        Me.btn_save.BackColor = System.Drawing.Color.Maroon
        Me.btn_save.Font = New System.Drawing.Font("LG Smart UI Regular", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btn_save.ForeColor = System.Drawing.Color.White
        Me.btn_save.Location = New System.Drawing.Point(424, 29)
        Me.btn_save.Name = "btn_save"
        Me.btn_save.Size = New System.Drawing.Size(112, 49)
        Me.btn_save.TabIndex = 26
        Me.btn_save.Text = "save"
        Me.btn_save.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("LG Smart UI Regular", 25.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label2.Location = New System.Drawing.Point(13, 29)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(247, 39)
        Me.Label2.TabIndex = 28
        Me.Label2.Text = "Admin. Setting"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txt_DBAdmin
        '
        Me.txt_DBAdmin.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txt_DBAdmin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_DBAdmin.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.txt_DBAdmin.ForeColor = System.Drawing.Color.Black
        Me.txt_DBAdmin.Location = New System.Drawing.Point(118, 262)
        Me.txt_DBAdmin.Name = "txt_DBAdmin"
        Me.txt_DBAdmin.Size = New System.Drawing.Size(371, 24)
        Me.txt_DBAdmin.TabIndex = 61
        Me.txt_DBAdmin.Text = "shook.lee@lge.com"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Calibri", 9.5!, System.Drawing.FontStyle.Bold)
        Me.Label17.ForeColor = System.Drawing.Color.FromArgb(CType(CType(98, Byte), Integer), CType(CType(98, Byte), Integer), CType(CType(98, Byte), Integer))
        Me.Label17.Location = New System.Drawing.Point(11, 264)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(64, 15)
        Me.Label17.TabIndex = 60
        Me.Label17.Text = "DB Admin."
        '
        'btn_backTodefault
        '
        Me.btn_backTodefault.BackColor = System.Drawing.Color.WhiteSmoke
        Me.btn_backTodefault.Font = New System.Drawing.Font("LG Smart UI Regular", 10.0!)
        Me.btn_backTodefault.Location = New System.Drawing.Point(299, 31)
        Me.btn_backTodefault.Name = "btn_backTodefault"
        Me.btn_backTodefault.Size = New System.Drawing.Size(119, 49)
        Me.btn_backTodefault.TabIndex = 27
        Me.btn_backTodefault.Text = "default" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Value"
        Me.btn_backTodefault.UseVisualStyleBackColor = False
        Me.btn_backTodefault.Visible = False
        '
        'Form_AdminSetting
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(548, 678)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btn_backTodefault)
        Me.Controls.Add(Me.btn_save)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("LG Smart UI Regular", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Name = "Form_AdminSetting"
        Me.Text = "Administrator Setting"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents txt_DBPW As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txt_DBID As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txt_ServerName As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents txt_TestRoom As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents btn_save As Button
    Friend WithEvents txt_TCPIP As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents txt_DBName As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents txt_ServerPort As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents txt_LogDirectory As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txt_EPDomainList As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txt_excelTemplateDirectory As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txt_InstrumentName As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents txt_DBAdmin As TextBox
    Friend WithEvents Label17 As Label
    Friend WithEvents btn_backTodefault As Button
End Class
