<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Login_SD4000
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.btn_login = New System.Windows.Forms.Button()
        Me.txt_EPID = New System.Windows.Forms.RichTextBox()
        Me.lbl_InstumentName = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btn_help = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.txt_EPPassword = New System.Windows.Forms.MaskedTextBox()
        Me.pb_IntrumentPicture = New System.Windows.Forms.PictureBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        CType(Me.pb_IntrumentPicture, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btn_login
        '
        Me.btn_login.BackColor = System.Drawing.Color.WhiteSmoke
        Me.btn_login.FlatAppearance.BorderSize = 0
        Me.btn_login.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_login.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.btn_login.ForeColor = System.Drawing.Color.FromArgb(CType(CType(98, Byte), Integer), CType(CType(98, Byte), Integer), CType(CType(98, Byte), Integer))
        Me.btn_login.Location = New System.Drawing.Point(120, 396)
        Me.btn_login.Name = "btn_login"
        Me.btn_login.Size = New System.Drawing.Size(400, 75)
        Me.btn_login.TabIndex = 3
        Me.btn_login.Text = "Login"
        Me.btn_login.UseVisualStyleBackColor = False
        '
        'txt_EPID
        '
        Me.txt_EPID.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txt_EPID.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txt_EPID.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.txt_EPID.ForeColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.txt_EPID.Location = New System.Drawing.Point(120, 263)
        Me.txt_EPID.Margin = New System.Windows.Forms.Padding(20, 3, 3, 3)
        Me.txt_EPID.MaxLength = 20
        Me.txt_EPID.Multiline = False
        Me.txt_EPID.Name = "txt_EPID"
        Me.txt_EPID.Size = New System.Drawing.Size(400, 35)
        Me.txt_EPID.TabIndex = 1
        Me.txt_EPID.Text = "EP ID"
        '
        'lbl_InstumentName
        '
        Me.lbl_InstumentName.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.lbl_InstumentName.ForeColor = System.Drawing.Color.FromArgb(CType(CType(98, Byte), Integer), CType(CType(98, Byte), Integer), CType(CType(98, Byte), Integer))
        Me.lbl_InstumentName.Location = New System.Drawing.Point(232, 155)
        Me.lbl_InstumentName.Name = "lbl_InstumentName"
        Me.lbl_InstumentName.Size = New System.Drawing.Size(269, 78)
        Me.lbl_InstumentName.TabIndex = 31
        Me.lbl_InstumentName.Text = "SD4000"
        Me.lbl_InstumentName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel4
        '
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel4.Location = New System.Drawing.Point(80, 477)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(485, 60)
        Me.Panel4.TabIndex = 28
        '
        'Panel3
        '
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel3.Location = New System.Drawing.Point(565, 60)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(80, 477)
        Me.Panel3.TabIndex = 26
        '
        'Panel2
        '
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel2.Location = New System.Drawing.Point(0, 60)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(80, 477)
        Me.Panel2.TabIndex = 24
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btn_help)
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(645, 60)
        Me.Panel1.TabIndex = 22
        '
        'btn_help
        '
        Me.btn_help.BackColor = System.Drawing.Color.Transparent
        Me.btn_help.FlatAppearance.BorderSize = 0
        Me.btn_help.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_help.Image = Global.LoginWindosw.My.Resources.Resources.help_button
        Me.btn_help.Location = New System.Drawing.Point(569, 0)
        Me.btn_help.Name = "btn_help"
        Me.btn_help.Size = New System.Drawing.Size(49, 58)
        Me.btn_help.TabIndex = 2
        Me.btn_help.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Transparent
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Location = New System.Drawing.Point(538, 0)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(27, 23)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "..."
        Me.Button1.UseVisualStyleBackColor = False
        '
        'txt_EPPassword
        '
        Me.txt_EPPassword.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txt_EPPassword.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txt_EPPassword.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        Me.txt_EPPassword.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!)
        Me.txt_EPPassword.ForeColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.txt_EPPassword.Location = New System.Drawing.Point(120, 349)
        Me.txt_EPPassword.Name = "txt_EPPassword"
        Me.txt_EPPassword.Size = New System.Drawing.Size(400, 20)
        Me.txt_EPPassword.TabIndex = 2
        Me.txt_EPPassword.Text = "PC PASSWORD"
        Me.txt_EPPassword.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        '
        'pb_IntrumentPicture
        '
        Me.pb_IntrumentPicture.Image = Global.LoginWindosw.My.Resources.Resources.Login_SD4000
        Me.pb_IntrumentPicture.Location = New System.Drawing.Point(133, 155)
        Me.pb_IntrumentPicture.Name = "pb_IntrumentPicture"
        Me.pb_IntrumentPicture.Size = New System.Drawing.Size(93, 89)
        Me.pb_IntrumentPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pb_IntrumentPicture.TabIndex = 34
        Me.pb_IntrumentPicture.TabStop = False
        '
        'Label5
        '
        Me.Label5.Image = Global.LoginWindosw.My.Resources.Resources.LoginHbar_107_107_107_
        Me.Label5.Location = New System.Drawing.Point(120, 373)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(400, 5)
        Me.Label5.TabIndex = 33
        '
        'Label4
        '
        Me.Label4.Image = Global.LoginWindosw.My.Resources.Resources.LoginHbar_107_107_107_
        Me.Label4.Location = New System.Drawing.Point(120, 301)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(400, 5)
        Me.Label4.TabIndex = 32
        '
        'Label1
        '
        Me.Label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label1.Image = Global.LoginWindosw.My.Resources.Resources.LGLogo
        Me.Label1.Location = New System.Drawing.Point(80, 60)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(276, 84)
        Me.Label1.TabIndex = 29
        '
        'Login_SD4000
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(645, 537)
        Me.Controls.Add(Me.pb_IntrumentPicture)
        Me.Controls.Add(Me.txt_EPPassword)
        Me.Controls.Add(Me.btn_login)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txt_EPID)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.lbl_InstumentName)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "Login_SD4000"
        Me.Text = "Login_SD4000"
        Me.Panel1.ResumeLayout(False)
        CType(Me.pb_IntrumentPicture, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btn_login As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents txt_EPID As RichTextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents lbl_InstumentName As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents txt_EPPassword As MaskedTextBox
    Friend WithEvents Button1 As Button
    Friend WithEvents pb_IntrumentPicture As PictureBox
    Friend WithEvents btn_help As Button
End Class
