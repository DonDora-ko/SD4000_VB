<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_Login
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_Login))
        Me.btn_login = New System.Windows.Forms.Button()
        Me.txt_EPID = New System.Windows.Forms.RichTextBox()
        Me.lbl_InstumentName = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btn_adminMenu = New System.Windows.Forms.Button()
        Me.cuteImgList = New System.Windows.Forms.ImageList(Me.components)
        Me.btn_help = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pb_IntrumentPicture = New System.Windows.Forms.PictureBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txt_EPPassword = New System.Windows.Forms.MaskedTextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txt_Purpose = New System.Windows.Forms.RichTextBox()
        Me.Panel1.SuspendLayout()
        CType(Me.pb_IntrumentPicture, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btn_login
        '
        Me.btn_login.BackColor = System.Drawing.Color.WhiteSmoke
        Me.btn_login.FlatAppearance.BorderSize = 0
        Me.btn_login.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_login.Font = New System.Drawing.Font("LG Smart UI Bold", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.btn_login.ForeColor = System.Drawing.Color.FromArgb(CType(CType(98, Byte), Integer), CType(CType(98, Byte), Integer), CType(CType(98, Byte), Integer))
        Me.btn_login.Location = New System.Drawing.Point(97, 512)
        Me.btn_login.Name = "btn_login"
        Me.btn_login.Size = New System.Drawing.Size(400, 55)
        Me.btn_login.TabIndex = 4
        Me.btn_login.Text = "Login"
        Me.btn_login.UseVisualStyleBackColor = False
        '
        'txt_EPID
        '
        Me.txt_EPID.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txt_EPID.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txt_EPID.Font = New System.Drawing.Font("LG Smart UI Bold", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.txt_EPID.ForeColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.txt_EPID.Location = New System.Drawing.Point(97, 310)
        Me.txt_EPID.Margin = New System.Windows.Forms.Padding(20, 3, 3, 3)
        Me.txt_EPID.MaxLength = 30
        Me.txt_EPID.Multiline = False
        Me.txt_EPID.Name = "txt_EPID"
        Me.txt_EPID.Size = New System.Drawing.Size(400, 32)
        Me.txt_EPID.TabIndex = 1
        Me.txt_EPID.Text = "EP ID"
        '
        'lbl_InstumentName
        '
        Me.lbl_InstumentName.Font = New System.Drawing.Font("LG Smart UI Bold", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.lbl_InstumentName.ForeColor = System.Drawing.Color.FromArgb(CType(CType(98, Byte), Integer), CType(CType(98, Byte), Integer), CType(CType(98, Byte), Integer))
        Me.lbl_InstumentName.Location = New System.Drawing.Point(229, 181)
        Me.lbl_InstumentName.Name = "lbl_InstumentName"
        Me.lbl_InstumentName.Size = New System.Drawing.Size(237, 104)
        Me.lbl_InstumentName.TabIndex = 43
        Me.lbl_InstumentName.Text = "SD4000"
        Me.lbl_InstumentName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel4
        '
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel4.Location = New System.Drawing.Point(80, 573)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(432, 53)
        Me.Panel4.TabIndex = 41
        '
        'Panel3
        '
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel3.Location = New System.Drawing.Point(512, 70)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(80, 556)
        Me.Panel3.TabIndex = 40
        '
        'Panel2
        '
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel2.Location = New System.Drawing.Point(0, 70)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(80, 556)
        Me.Panel2.TabIndex = 39
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btn_adminMenu)
        Me.Panel1.Controls.Add(Me.btn_help)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(592, 70)
        Me.Panel1.TabIndex = 38
        '
        'btn_adminMenu
        '
        Me.btn_adminMenu.BackColor = System.Drawing.Color.WhiteSmoke
        Me.btn_adminMenu.Dock = System.Windows.Forms.DockStyle.Right
        Me.btn_adminMenu.FlatAppearance.BorderSize = 0
        Me.btn_adminMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_adminMenu.ImageKey = "WDSC_Illustration_834x834.png"
        Me.btn_adminMenu.ImageList = Me.cuteImgList
        Me.btn_adminMenu.Location = New System.Drawing.Point(500, 0)
        Me.btn_adminMenu.Name = "btn_adminMenu"
        Me.btn_adminMenu.Size = New System.Drawing.Size(43, 70)
        Me.btn_adminMenu.TabIndex = 3
        Me.btn_adminMenu.TabStop = False
        Me.btn_adminMenu.UseVisualStyleBackColor = False
        '
        'cuteImgList
        '
        Me.cuteImgList.ImageStream = CType(resources.GetObject("cuteImgList.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.cuteImgList.TransparentColor = System.Drawing.Color.Transparent
        Me.cuteImgList.Images.SetKeyName(0, "family_illustration-01.png")
        Me.cuteImgList.Images.SetKeyName(1, "WDSC_Illustration_834x834.png")
        '
        'btn_help
        '
        Me.btn_help.BackColor = System.Drawing.Color.Transparent
        Me.btn_help.Dock = System.Windows.Forms.DockStyle.Right
        Me.btn_help.FlatAppearance.BorderSize = 0
        Me.btn_help.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_help.Image = Global.LGE_SD4000.My.Resources.Resources.help_button
        Me.btn_help.Location = New System.Drawing.Point(543, 0)
        Me.btn_help.Name = "btn_help"
        Me.btn_help.Size = New System.Drawing.Size(49, 70)
        Me.btn_help.TabIndex = 2
        Me.btn_help.TabStop = False
        Me.btn_help.UseVisualStyleBackColor = False
        '
        'Label5
        '
        Me.Label5.Image = Global.LGE_SD4000.My.Resources.Resources.LoginHbar_107_107_107_
        Me.Label5.Location = New System.Drawing.Point(97, 407)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(400, 6)
        Me.Label5.TabIndex = 45
        '
        'Label1
        '
        Me.Label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label1.Image = Global.LGE_SD4000.My.Resources.Resources.LGLogo
        Me.Label1.Location = New System.Drawing.Point(78, 70)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(276, 98)
        Me.Label1.TabIndex = 42
        '
        'pb_IntrumentPicture
        '
        Me.pb_IntrumentPicture.Image = Global.LGE_SD4000.My.Resources.Resources.반사율측정기_SD4000
        Me.pb_IntrumentPicture.Location = New System.Drawing.Point(130, 181)
        Me.pb_IntrumentPicture.Name = "pb_IntrumentPicture"
        Me.pb_IntrumentPicture.Size = New System.Drawing.Size(93, 93)
        Me.pb_IntrumentPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pb_IntrumentPicture.TabIndex = 46
        Me.pb_IntrumentPicture.TabStop = False
        '
        'Label4
        '
        Me.Label4.Image = Global.LGE_SD4000.My.Resources.Resources.LoginHbar_107_107_107_
        Me.Label4.Location = New System.Drawing.Point(97, 345)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(400, 6)
        Me.Label4.TabIndex = 44
        '
        'txt_EPPassword
        '
        Me.txt_EPPassword.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txt_EPPassword.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txt_EPPassword.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        Me.txt_EPPassword.Font = New System.Drawing.Font("LG Smart UI Bold", 13.0!)
        Me.txt_EPPassword.ForeColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.txt_EPPassword.Location = New System.Drawing.Point(97, 379)
        Me.txt_EPPassword.Name = "txt_EPPassword"
        Me.txt_EPPassword.Size = New System.Drawing.Size(400, 21)
        Me.txt_EPPassword.TabIndex = 2
        Me.txt_EPPassword.Text = "PC PASSWORD"
        Me.txt_EPPassword.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!)
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(98, Byte), Integer), CType(CType(98, Byte), Integer), CType(CType(98, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(93, 434)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(190, 22)
        Me.Label3.TabIndex = 49
        Me.Label3.Text = "Measurement Purpose"
        '
        'Label2
        '
        Me.Label2.Image = Global.LGE_SD4000.My.Resources.Resources.LoginHbar_107_107_107_
        Me.Label2.Location = New System.Drawing.Point(95, 494)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(400, 5)
        Me.Label2.TabIndex = 48
        '
        'txt_Purpose
        '
        Me.txt_Purpose.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txt_Purpose.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txt_Purpose.Font = New System.Drawing.Font("LG Smart UI Bold", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.txt_Purpose.ForeColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.txt_Purpose.Location = New System.Drawing.Point(97, 459)
        Me.txt_Purpose.Margin = New System.Windows.Forms.Padding(20, 3, 3, 3)
        Me.txt_Purpose.MaxLength = 50
        Me.txt_Purpose.Multiline = False
        Me.txt_Purpose.Name = "txt_Purpose"
        Me.txt_Purpose.Size = New System.Drawing.Size(400, 32)
        Me.txt_Purpose.TabIndex = 3
        Me.txt_Purpose.Text = "Purpose"
        '
        'Form_Login
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(592, 626)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.pb_IntrumentPicture)
        Me.Controls.Add(Me.txt_Purpose)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btn_login)
        Me.Controls.Add(Me.txt_EPID)
        Me.Controls.Add(Me.lbl_InstumentName)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.txt_EPPassword)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Font = New System.Drawing.Font("LG Smart UI Bold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Name = "Form_Login"
        Me.Text = "Form_Login"
        Me.Panel1.ResumeLayout(False)
        CType(Me.pb_IntrumentPicture, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btn_login As Button
    Friend WithEvents txt_EPID As RichTextBox
    Friend WithEvents lbl_InstumentName As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents btn_help As Button
    Friend WithEvents pb_IntrumentPicture As PictureBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents btn_adminMenu As Button
    Friend WithEvents txt_EPPassword As MaskedTextBox
    Friend WithEvents cuteImgList As ImageList
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txt_Purpose As RichTextBox
End Class
