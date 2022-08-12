<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form은 Dispose를 재정의하여 구성 요소 목록을 정리합니다.
    <System.Diagnostics.DebuggerNonUserCode()>
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim ChartArea2 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend2 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series2 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim ChartArea3 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend3 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series3 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lbl_userInfo = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.pic_serialConnectivity = New System.Windows.Forms.PictureBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.cmb_Parity = New System.Windows.Forms.ComboBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.cmb_StopBits = New System.Windows.Forms.ComboBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.cmb_DataBits = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.cmb_Baudrate = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cmb_PortNo = New System.Windows.Forms.ComboBox()
        Me.cmb_Inferface = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.imglist_Condition = New System.Windows.Forms.ImageList(Me.components)
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cmb_Observer = New System.Windows.Forms.ComboBox()
        Me.cmb_StandardIlluminant = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cmb_UV = New System.Windows.Forms.ComboBox()
        Me.cmb_SpecularComponent = New System.Windows.Forms.ComboBox()
        Me.cmb_MeasurementMethod = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.imglist_light = New System.Windows.Forms.ImageList(Me.components)
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.btn_sendSerialTxt = New System.Windows.Forms.Button()
        Me.txt_ReceivedSerialTxt = New System.Windows.Forms.RichTextBox()
        Me.txt_SendSerialTxt = New System.Windows.Forms.TextBox()
        Me.btn_DoMeasurement = New System.Windows.Forms.Button()
        Me.pic_sequence4 = New System.Windows.Forms.PictureBox()
        Me.btn_StandardCalibration = New System.Windows.Forms.Button()
        Me.pic_sequence3 = New System.Windows.Forms.PictureBox()
        Me.btn_ZeroCalibration = New System.Windows.Forms.Button()
        Me.pic_sequence2 = New System.Windows.Forms.PictureBox()
        Me.pic_sequence1 = New System.Windows.Forms.PictureBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.DataGridView2 = New System.Windows.Forms.DataGridView()
        Me.xyChart = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.Labchart = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.spectrum_Chart = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.data_No = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.part_Category = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.part_Name = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.direction = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.year = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.model = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.mp_event = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.Sequence = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.note = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.serialPort = New System.IO.Ports.SerialPort(Me.components)
        Me.MeasuredDataBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Panel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.pic_serialConnectivity, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.pic_sequence4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pic_sequence3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pic_sequence2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pic_sequence1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel7.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.xyChart, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Labchart, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.spectrum_Chart, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MeasuredDataBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.Panel1.Controls.Add(Me.lbl_userInfo)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Font = New System.Drawing.Font("LG Smart UI Regular", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1573, 29)
        Me.Panel1.TabIndex = 0
        '
        'lbl_userInfo
        '
        Me.lbl_userInfo.AutoSize = True
        Me.lbl_userInfo.Dock = System.Windows.Forms.DockStyle.Right
        Me.lbl_userInfo.Font = New System.Drawing.Font("LG Smart UI Regular", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.lbl_userInfo.Location = New System.Drawing.Point(1310, 0)
        Me.lbl_userInfo.Name = "lbl_userInfo"
        Me.lbl_userInfo.Size = New System.Drawing.Size(263, 14)
        Me.lbl_userInfo.TabIndex = 0
        Me.lbl_userInfo.Text = "추상우/책임연구원/HE C4팀(sangwoo.choo@lge.com)"
        Me.lbl_userInfo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Font = New System.Drawing.Font("LG Smart UI Regular", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Panel2.ForeColor = System.Drawing.Color.Black
        Me.Panel2.Location = New System.Drawing.Point(0, 932)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1573, 29)
        Me.Panel2.TabIndex = 1
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.White
        Me.Panel3.Controls.Add(Me.GroupBox3)
        Me.Panel3.Controls.Add(Me.Label10)
        Me.Panel3.Controls.Add(Me.GroupBox2)
        Me.Panel3.Controls.Add(Me.Label5)
        Me.Panel3.Controls.Add(Me.GroupBox1)
        Me.Panel3.Controls.Add(Me.Label16)
        Me.Panel3.Controls.Add(Me.Label1)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel3.Font = New System.Drawing.Font("LG Smart UI Regular", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Panel3.Location = New System.Drawing.Point(0, 29)
        Me.Panel3.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(270, 903)
        Me.Panel3.TabIndex = 2
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.White
        Me.GroupBox3.Controls.Add(Me.Button1)
        Me.GroupBox3.Controls.Add(Me.pic_serialConnectivity)
        Me.GroupBox3.Controls.Add(Me.Label17)
        Me.GroupBox3.Controls.Add(Me.cmb_Parity)
        Me.GroupBox3.Controls.Add(Me.Label14)
        Me.GroupBox3.Controls.Add(Me.cmb_StopBits)
        Me.GroupBox3.Controls.Add(Me.Label13)
        Me.GroupBox3.Controls.Add(Me.cmb_DataBits)
        Me.GroupBox3.Controls.Add(Me.Label12)
        Me.GroupBox3.Controls.Add(Me.cmb_Baudrate)
        Me.GroupBox3.Controls.Add(Me.Label11)
        Me.GroupBox3.Controls.Add(Me.cmb_PortNo)
        Me.GroupBox3.Controls.Add(Me.cmb_Inferface)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.Label9)
        Me.GroupBox3.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(45, 419)
        Me.GroupBox3.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox3.Size = New System.Drawing.Size(225, 305)
        Me.GroupBox3.TabIndex = 20
        Me.GroupBox3.TabStop = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Button1.Location = New System.Drawing.Point(39, 275)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(147, 23)
        Me.Button1.TabIndex = 15
        Me.Button1.Text = "Re-connect"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'pic_serialConnectivity
        '
        Me.pic_serialConnectivity.Image = Global.LGE_SD4000.My.Resources.Resources.redlight
        Me.pic_serialConnectivity.Location = New System.Drawing.Point(152, 231)
        Me.pic_serialConnectivity.Name = "pic_serialConnectivity"
        Me.pic_serialConnectivity.Size = New System.Drawing.Size(34, 35)
        Me.pic_serialConnectivity.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pic_serialConnectivity.TabIndex = 14
        Me.pic_serialConnectivity.TabStop = False
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Label17.Location = New System.Drawing.Point(6, 244)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(89, 15)
        Me.Label17.TabIndex = 13
        Me.Label17.Text = "Connect Status"
        '
        'cmb_Parity
        '
        Me.cmb_Parity.Enabled = False
        Me.cmb_Parity.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.cmb_Parity.FormattingEnabled = True
        Me.cmb_Parity.Items.AddRange(New Object() {"even", "odd", "none"})
        Me.cmb_Parity.Location = New System.Drawing.Point(131, 201)
        Me.cmb_Parity.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmb_Parity.Name = "cmb_Parity"
        Me.cmb_Parity.Size = New System.Drawing.Size(82, 23)
        Me.cmb_Parity.TabIndex = 12
        Me.cmb_Parity.Text = "none"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Label14.Location = New System.Drawing.Point(6, 206)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(37, 15)
        Me.Label14.TabIndex = 11
        Me.Label14.Text = "Parity"
        '
        'cmb_StopBits
        '
        Me.cmb_StopBits.Enabled = False
        Me.cmb_StopBits.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.cmb_StopBits.FormattingEnabled = True
        Me.cmb_StopBits.Items.AddRange(New Object() {"1", "2", "1.5", "none"})
        Me.cmb_StopBits.Location = New System.Drawing.Point(131, 164)
        Me.cmb_StopBits.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmb_StopBits.Name = "cmb_StopBits"
        Me.cmb_StopBits.Size = New System.Drawing.Size(82, 23)
        Me.cmb_StopBits.TabIndex = 10
        Me.cmb_StopBits.Text = "1"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Label13.Location = New System.Drawing.Point(6, 169)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(55, 15)
        Me.Label13.TabIndex = 9
        Me.Label13.Text = "Stop Bits"
        '
        'cmb_DataBits
        '
        Me.cmb_DataBits.Enabled = False
        Me.cmb_DataBits.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.cmb_DataBits.FormattingEnabled = True
        Me.cmb_DataBits.Items.AddRange(New Object() {"8 bit", "7 bit"})
        Me.cmb_DataBits.Location = New System.Drawing.Point(132, 127)
        Me.cmb_DataBits.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmb_DataBits.Name = "cmb_DataBits"
        Me.cmb_DataBits.Size = New System.Drawing.Size(82, 23)
        Me.cmb_DataBits.TabIndex = 8
        Me.cmb_DataBits.Text = "8 bit"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Label12.Location = New System.Drawing.Point(7, 132)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(56, 15)
        Me.Label12.TabIndex = 7
        Me.Label12.Text = "Date Bits"
        '
        'cmb_Baudrate
        '
        Me.cmb_Baudrate.Enabled = False
        Me.cmb_Baudrate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.cmb_Baudrate.FormattingEnabled = True
        Me.cmb_Baudrate.Items.AddRange(New Object() {"9600", "19200", "38400", "56000", "11520", "128000", "256000"})
        Me.cmb_Baudrate.Location = New System.Drawing.Point(131, 90)
        Me.cmb_Baudrate.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmb_Baudrate.Name = "cmb_Baudrate"
        Me.cmb_Baudrate.Size = New System.Drawing.Size(82, 23)
        Me.cmb_Baudrate.TabIndex = 6
        Me.cmb_Baudrate.Text = "38400"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Label11.Location = New System.Drawing.Point(6, 95)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(57, 15)
        Me.Label11.TabIndex = 5
        Me.Label11.Text = "Baudrate"
        '
        'cmb_PortNo
        '
        Me.cmb_PortNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.cmb_PortNo.FormattingEnabled = True
        Me.cmb_PortNo.Items.AddRange(New Object() {"COM1", "COM2", "COM3", "COM4", "COM5", "COM6", "COM7", "COM8", "COM9", "COM10"})
        Me.cmb_PortNo.Location = New System.Drawing.Point(131, 53)
        Me.cmb_PortNo.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmb_PortNo.Name = "cmb_PortNo"
        Me.cmb_PortNo.Size = New System.Drawing.Size(82, 23)
        Me.cmb_PortNo.TabIndex = 4
        Me.cmb_PortNo.Text = "COM4"
        '
        'cmb_Inferface
        '
        Me.cmb_Inferface.Enabled = False
        Me.cmb_Inferface.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.cmb_Inferface.FormattingEnabled = True
        Me.cmb_Inferface.Items.AddRange(New Object() {"RS-232C", "USB"})
        Me.cmb_Inferface.Location = New System.Drawing.Point(131, 16)
        Me.cmb_Inferface.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmb_Inferface.Name = "cmb_Inferface"
        Me.cmb_Inferface.Size = New System.Drawing.Size(82, 23)
        Me.cmb_Inferface.TabIndex = 3
        Me.cmb_Inferface.Text = "RS-232C"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Label6.Location = New System.Drawing.Point(6, 58)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(51, 15)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "Port No."
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Label9.Location = New System.Drawing.Point(6, 21)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(54, 15)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "Interface"
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.Label10.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label10.Font = New System.Drawing.Font("LG Smart UI Regular", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label10.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label10.ImageKey = "Network.contrast-white.ico"
        Me.Label10.ImageList = Me.imglist_Condition
        Me.Label10.Location = New System.Drawing.Point(45, 354)
        Me.Label10.Name = "Label10"
        Me.Label10.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.Label10.Size = New System.Drawing.Size(225, 65)
        Me.Label10.TabIndex = 19
        Me.Label10.Text = "           Communication"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'imglist_Condition
        '
        Me.imglist_Condition.ImageStream = CType(resources.GetObject("imglist_Condition.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imglist_Condition.TransparentColor = System.Drawing.Color.Transparent
        Me.imglist_Condition.Images.SetKeyName(0, "D65_StandardIlluminants.png")
        Me.imglist_Condition.Images.SetKeyName(1, "Reflectance_Transmittance.png")
        Me.imglist_Condition.Images.SetKeyName(2, "Network.contrast-white.ico")
        Me.imglist_Condition.Images.SetKeyName(3, "family_illustration-01.png")
        Me.imglist_Condition.Images.SetKeyName(4, "WDSC_Illustration_834x834.png")
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.White
        Me.GroupBox2.Controls.Add(Me.cmb_Observer)
        Me.GroupBox2.Controls.Add(Me.cmb_StandardIlluminant)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(45, 263)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox2.Size = New System.Drawing.Size(225, 91)
        Me.GroupBox2.TabIndex = 18
        Me.GroupBox2.TabStop = False
        '
        'cmb_Observer
        '
        Me.cmb_Observer.Enabled = False
        Me.cmb_Observer.Font = New System.Drawing.Font("LG Smart UI Regular", 9.0!)
        Me.cmb_Observer.FormattingEnabled = True
        Me.cmb_Observer.Items.AddRange(New Object() {"2 Degree", "10 Degree"})
        Me.cmb_Observer.Location = New System.Drawing.Point(131, 56)
        Me.cmb_Observer.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmb_Observer.Name = "cmb_Observer"
        Me.cmb_Observer.Size = New System.Drawing.Size(82, 22)
        Me.cmb_Observer.TabIndex = 4
        Me.cmb_Observer.Text = "10 Degree"
        '
        'cmb_StandardIlluminant
        '
        Me.cmb_StandardIlluminant.Enabled = False
        Me.cmb_StandardIlluminant.Font = New System.Drawing.Font("LG Smart UI Regular", 9.0!)
        Me.cmb_StandardIlluminant.FormattingEnabled = True
        Me.cmb_StandardIlluminant.Items.AddRange(New Object() {"D65"})
        Me.cmb_StandardIlluminant.Location = New System.Drawing.Point(131, 18)
        Me.cmb_StandardIlluminant.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmb_StandardIlluminant.Name = "cmb_StandardIlluminant"
        Me.cmb_StandardIlluminant.Size = New System.Drawing.Size(82, 22)
        Me.cmb_StandardIlluminant.TabIndex = 3
        Me.cmb_StandardIlluminant.Text = "D65"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("LG Smart UI Regular", 9.0!)
        Me.Label7.Location = New System.Drawing.Point(6, 60)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(52, 14)
        Me.Label7.TabIndex = 1
        Me.Label7.Text = "Observer"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("LG Smart UI Regular", 9.0!)
        Me.Label8.Location = New System.Drawing.Point(6, 22)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(106, 14)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "Standard Illuminant"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.Label5.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label5.Font = New System.Drawing.Font("LG Smart UI Regular", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label5.ImageKey = "D65_StandardIlluminants.png"
        Me.Label5.ImageList = Me.imglist_Condition
        Me.Label5.Location = New System.Drawing.Point(45, 198)
        Me.Label5.Margin = New System.Windows.Forms.Padding(50, 0, 3, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.Label5.Size = New System.Drawing.Size(225, 65)
        Me.Label5.TabIndex = 17
        Me.Label5.Text = "           Illuminants and Observer"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.White
        Me.GroupBox1.Controls.Add(Me.cmb_UV)
        Me.GroupBox1.Controls.Add(Me.cmb_SpecularComponent)
        Me.GroupBox1.Controls.Add(Me.cmb_MeasurementMethod)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(45, 65)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox1.Size = New System.Drawing.Size(225, 133)
        Me.GroupBox1.TabIndex = 16
        Me.GroupBox1.TabStop = False
        '
        'cmb_UV
        '
        Me.cmb_UV.Enabled = False
        Me.cmb_UV.Font = New System.Drawing.Font("LG Smart UI Regular", 9.0!)
        Me.cmb_UV.FormattingEnabled = True
        Me.cmb_UV.Items.AddRange(New Object() {"Out", "In", "In+Out"})
        Me.cmb_UV.Location = New System.Drawing.Point(131, 95)
        Me.cmb_UV.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmb_UV.Name = "cmb_UV"
        Me.cmb_UV.Size = New System.Drawing.Size(82, 22)
        Me.cmb_UV.TabIndex = 5
        Me.cmb_UV.Text = "In"
        '
        'cmb_SpecularComponent
        '
        Me.cmb_SpecularComponent.Font = New System.Drawing.Font("LG Smart UI Regular", 9.0!)
        Me.cmb_SpecularComponent.FormattingEnabled = True
        Me.cmb_SpecularComponent.Items.AddRange(New Object() {"SCI", "SCE"})
        Me.cmb_SpecularComponent.Location = New System.Drawing.Point(131, 57)
        Me.cmb_SpecularComponent.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmb_SpecularComponent.Name = "cmb_SpecularComponent"
        Me.cmb_SpecularComponent.Size = New System.Drawing.Size(82, 22)
        Me.cmb_SpecularComponent.TabIndex = 4
        Me.cmb_SpecularComponent.Text = "SCI"
        '
        'cmb_MeasurementMethod
        '
        Me.cmb_MeasurementMethod.Enabled = False
        Me.cmb_MeasurementMethod.Font = New System.Drawing.Font("LG Smart UI Regular", 9.0!)
        Me.cmb_MeasurementMethod.FormattingEnabled = True
        Me.cmb_MeasurementMethod.Items.AddRange(New Object() {"Reflectance", "Transmittance"})
        Me.cmb_MeasurementMethod.Location = New System.Drawing.Point(131, 16)
        Me.cmb_MeasurementMethod.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmb_MeasurementMethod.Name = "cmb_MeasurementMethod"
        Me.cmb_MeasurementMethod.Size = New System.Drawing.Size(82, 22)
        Me.cmb_MeasurementMethod.TabIndex = 3
        Me.cmb_MeasurementMethod.Text = "Reflectance"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("LG Smart UI Regular", 9.0!)
        Me.Label4.Location = New System.Drawing.Point(6, 100)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(22, 14)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "UV"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("LG Smart UI Regular", 9.0!)
        Me.Label3.Location = New System.Drawing.Point(6, 64)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(110, 14)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Specular Component"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("LG Smart UI Regular", 9.0!)
        Me.Label2.Location = New System.Drawing.Point(6, 21)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(118, 14)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Measurement Method"
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.Label16.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label16.Font = New System.Drawing.Font("LG Smart UI Regular", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label16.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label16.ImageKey = "Reflectance_Transmittance.png"
        Me.Label16.ImageList = Me.imglist_Condition
        Me.Label16.Location = New System.Drawing.Point(45, 0)
        Me.Label16.Margin = New System.Windows.Forms.Padding(10, 0, 3, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.Label16.Size = New System.Drawing.Size(225, 65)
        Me.Label16.TabIndex = 15
        Me.Label16.Text = "           Measurement Mode"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label1.Image = Global.LGE_SD4000.My.Resources.Resources.Label11
        Me.Label1.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 903)
        Me.Label1.TabIndex = 21
        '
        'Panel4
        '
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Panel4.Location = New System.Drawing.Point(270, 29)
        Me.Panel4.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(10, 903)
        Me.Panel4.TabIndex = 3
        '
        'imglist_light
        '
        Me.imglist_light.ImageStream = CType(resources.GetObject("imglist_light.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imglist_light.TransparentColor = System.Drawing.Color.Transparent
        Me.imglist_light.Images.SetKeyName(0, "redlight.png")
        Me.imglist_light.Images.SetKeyName(1, "greenlight.png")
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.Button3)
        Me.Panel5.Controls.Add(Me.GroupBox4)
        Me.Panel5.Controls.Add(Me.btn_DoMeasurement)
        Me.Panel5.Controls.Add(Me.pic_sequence4)
        Me.Panel5.Controls.Add(Me.btn_StandardCalibration)
        Me.Panel5.Controls.Add(Me.pic_sequence3)
        Me.Panel5.Controls.Add(Me.btn_ZeroCalibration)
        Me.Panel5.Controls.Add(Me.pic_sequence2)
        Me.Panel5.Controls.Add(Me.pic_sequence1)
        Me.Panel5.Controls.Add(Me.Label15)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel5.Location = New System.Drawing.Point(280, 29)
        Me.Panel5.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(330, 903)
        Me.Panel5.TabIndex = 4
        '
        'Button3
        '
        Me.Button3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Button3.FlatAppearance.BorderSize = 0
        Me.Button3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(107, Byte), Integer), CType(CType(107, Byte), Integer), CType(CType(107, Byte), Integer))
        Me.Button3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(165, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.749999!, System.Drawing.FontStyle.Bold)
        Me.Button3.Location = New System.Drawing.Point(45, 434)
        Me.Button3.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(285, 62)
        Me.Button3.TabIndex = 28
        Me.Button3.Text = "test"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Button2)
        Me.GroupBox4.Controls.Add(Me.btn_sendSerialTxt)
        Me.GroupBox4.Controls.Add(Me.txt_ReceivedSerialTxt)
        Me.GroupBox4.Controls.Add(Me.txt_SendSerialTxt)
        Me.GroupBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.GroupBox4.Location = New System.Drawing.Point(51, 599)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(293, 177)
        Me.GroupBox4.TabIndex = 27
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "communication"
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.Button2.FlatAppearance.BorderSize = 0
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Location = New System.Drawing.Point(248, 126)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(39, 40)
        Me.Button2.TabIndex = 17
        Me.Button2.Text = "del."
        Me.Button2.UseVisualStyleBackColor = False
        '
        'btn_sendSerialTxt
        '
        Me.btn_sendSerialTxt.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.btn_sendSerialTxt.FlatAppearance.BorderSize = 0
        Me.btn_sendSerialTxt.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_sendSerialTxt.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_sendSerialTxt.Location = New System.Drawing.Point(248, 22)
        Me.btn_sendSerialTxt.Name = "btn_sendSerialTxt"
        Me.btn_sendSerialTxt.Size = New System.Drawing.Size(39, 22)
        Me.btn_sendSerialTxt.TabIndex = 16
        Me.btn_sendSerialTxt.Text = "send"
        Me.btn_sendSerialTxt.UseVisualStyleBackColor = False
        '
        'txt_ReceivedSerialTxt
        '
        Me.txt_ReceivedSerialTxt.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.txt_ReceivedSerialTxt.Location = New System.Drawing.Point(6, 49)
        Me.txt_ReceivedSerialTxt.Name = "txt_ReceivedSerialTxt"
        Me.txt_ReceivedSerialTxt.Size = New System.Drawing.Size(241, 117)
        Me.txt_ReceivedSerialTxt.TabIndex = 2
        Me.txt_ReceivedSerialTxt.Text = ""
        '
        'txt_SendSerialTxt
        '
        Me.txt_SendSerialTxt.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.txt_SendSerialTxt.Location = New System.Drawing.Point(6, 21)
        Me.txt_SendSerialTxt.Name = "txt_SendSerialTxt"
        Me.txt_SendSerialTxt.Size = New System.Drawing.Size(241, 21)
        Me.txt_SendSerialTxt.TabIndex = 0
        '
        'btn_DoMeasurement
        '
        Me.btn_DoMeasurement.Dock = System.Windows.Forms.DockStyle.Top
        Me.btn_DoMeasurement.FlatAppearance.BorderSize = 0
        Me.btn_DoMeasurement.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(107, Byte), Integer), CType(CType(107, Byte), Integer), CType(CType(107, Byte), Integer))
        Me.btn_DoMeasurement.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(165, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.btn_DoMeasurement.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_DoMeasurement.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.749999!, System.Drawing.FontStyle.Bold)
        Me.btn_DoMeasurement.Location = New System.Drawing.Point(45, 372)
        Me.btn_DoMeasurement.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btn_DoMeasurement.Name = "btn_DoMeasurement"
        Me.btn_DoMeasurement.Size = New System.Drawing.Size(285, 62)
        Me.btn_DoMeasurement.TabIndex = 26
        Me.btn_DoMeasurement.Text = "③ Click! Do Measurement"
        Me.btn_DoMeasurement.UseVisualStyleBackColor = True
        '
        'pic_sequence4
        '
        Me.pic_sequence4.Dock = System.Windows.Forms.DockStyle.Top
        Me.pic_sequence4.Image = Global.LGE_SD4000.My.Resources.Resources.No4_Domeasurement
        Me.pic_sequence4.InitialImage = Nothing
        Me.pic_sequence4.Location = New System.Drawing.Point(45, 310)
        Me.pic_sequence4.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.pic_sequence4.Name = "pic_sequence4"
        Me.pic_sequence4.Size = New System.Drawing.Size(285, 62)
        Me.pic_sequence4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pic_sequence4.TabIndex = 25
        Me.pic_sequence4.TabStop = False
        '
        'btn_StandardCalibration
        '
        Me.btn_StandardCalibration.Dock = System.Windows.Forms.DockStyle.Top
        Me.btn_StandardCalibration.FlatAppearance.BorderSize = 0
        Me.btn_StandardCalibration.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(107, Byte), Integer), CType(CType(107, Byte), Integer), CType(CType(107, Byte), Integer))
        Me.btn_StandardCalibration.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(165, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.btn_StandardCalibration.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_StandardCalibration.Font = New System.Drawing.Font("LG Smart UI Bold", 9.749999!, System.Drawing.FontStyle.Bold)
        Me.btn_StandardCalibration.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_StandardCalibration.ImageIndex = 0
        Me.btn_StandardCalibration.ImageList = Me.imglist_light
        Me.btn_StandardCalibration.Location = New System.Drawing.Point(45, 248)
        Me.btn_StandardCalibration.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btn_StandardCalibration.Name = "btn_StandardCalibration"
        Me.btn_StandardCalibration.Size = New System.Drawing.Size(285, 62)
        Me.btn_StandardCalibration.TabIndex = 24
        Me.btn_StandardCalibration.Text = "② Click! Standard Calibration"
        Me.btn_StandardCalibration.UseVisualStyleBackColor = True
        '
        'pic_sequence3
        '
        Me.pic_sequence3.Dock = System.Windows.Forms.DockStyle.Top
        Me.pic_sequence3.Image = Global.LGE_SD4000.My.Resources.Resources.No3_StandardCalibration
        Me.pic_sequence3.InitialImage = Nothing
        Me.pic_sequence3.Location = New System.Drawing.Point(45, 186)
        Me.pic_sequence3.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.pic_sequence3.Name = "pic_sequence3"
        Me.pic_sequence3.Size = New System.Drawing.Size(285, 62)
        Me.pic_sequence3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pic_sequence3.TabIndex = 23
        Me.pic_sequence3.TabStop = False
        '
        'btn_ZeroCalibration
        '
        Me.btn_ZeroCalibration.Dock = System.Windows.Forms.DockStyle.Top
        Me.btn_ZeroCalibration.FlatAppearance.BorderSize = 0
        Me.btn_ZeroCalibration.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(107, Byte), Integer), CType(CType(107, Byte), Integer), CType(CType(107, Byte), Integer))
        Me.btn_ZeroCalibration.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(165, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.btn_ZeroCalibration.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_ZeroCalibration.Font = New System.Drawing.Font("LG Smart UI Bold", 9.749999!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_ZeroCalibration.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_ZeroCalibration.ImageIndex = 0
        Me.btn_ZeroCalibration.ImageList = Me.imglist_light
        Me.btn_ZeroCalibration.Location = New System.Drawing.Point(45, 124)
        Me.btn_ZeroCalibration.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btn_ZeroCalibration.Name = "btn_ZeroCalibration"
        Me.btn_ZeroCalibration.Size = New System.Drawing.Size(285, 62)
        Me.btn_ZeroCalibration.TabIndex = 22
        Me.btn_ZeroCalibration.Text = "① Click! Zero-Calibration"
        Me.btn_ZeroCalibration.UseVisualStyleBackColor = True
        '
        'pic_sequence2
        '
        Me.pic_sequence2.Dock = System.Windows.Forms.DockStyle.Top
        Me.pic_sequence2.Image = Global.LGE_SD4000.My.Resources.Resources.No2_ZeroCalibration
        Me.pic_sequence2.InitialImage = Nothing
        Me.pic_sequence2.Location = New System.Drawing.Point(45, 62)
        Me.pic_sequence2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.pic_sequence2.Name = "pic_sequence2"
        Me.pic_sequence2.Size = New System.Drawing.Size(285, 62)
        Me.pic_sequence2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pic_sequence2.TabIndex = 21
        Me.pic_sequence2.TabStop = False
        '
        'pic_sequence1
        '
        Me.pic_sequence1.Dock = System.Windows.Forms.DockStyle.Top
        Me.pic_sequence1.Image = Global.LGE_SD4000.My.Resources.Resources.No1_SetSampleStand
        Me.pic_sequence1.InitialImage = Nothing
        Me.pic_sequence1.Location = New System.Drawing.Point(45, 0)
        Me.pic_sequence1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.pic_sequence1.Name = "pic_sequence1"
        Me.pic_sequence1.Size = New System.Drawing.Size(285, 62)
        Me.pic_sequence1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pic_sequence1.TabIndex = 20
        Me.pic_sequence1.TabStop = False
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.Label15.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label15.Image = Global.LGE_SD4000.My.Resources.Resources.Label2_Test_Sequence
        Me.Label15.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Label15.Location = New System.Drawing.Point(0, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(45, 903)
        Me.Label15.TabIndex = 0
        '
        'Panel6
        '
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel6.Location = New System.Drawing.Point(610, 29)
        Me.Panel6.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(10, 903)
        Me.Panel6.TabIndex = 5
        '
        'Panel7
        '
        Me.Panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel7.Controls.Add(Me.SplitContainer1)
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel7.Location = New System.Drawing.Point(620, 29)
        Me.Panel7.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(953, 903)
        Me.Panel7.TabIndex = 6
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.DataGridView2)
        Me.SplitContainer1.Panel1.Controls.Add(Me.xyChart)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Labchart)
        Me.SplitContainer1.Panel1.Controls.Add(Me.spectrum_Chart)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.DataGridView1)
        Me.SplitContainer1.Size = New System.Drawing.Size(951, 901)
        Me.SplitContainer1.SplitterDistance = 697
        Me.SplitContainer1.SplitterWidth = 5
        Me.SplitContainer1.TabIndex = 0
        '
        'DataGridView2
        '
        Me.DataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataGridView2.BackgroundColor = System.Drawing.Color.White
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView2.Location = New System.Drawing.Point(692, 25)
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.RowHeadersVisible = False
        Me.DataGridView2.RowTemplate.Height = 23
        Me.DataGridView2.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal
        Me.DataGridView2.Size = New System.Drawing.Size(238, 250)
        Me.DataGridView2.TabIndex = 3
        '
        'xyChart
        '
        ChartArea1.AxisX.Interval = 0.1R
        ChartArea1.AxisX.IsLabelAutoFit = False
        ChartArea1.AxisX.LabelStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!)
        ChartArea1.AxisX.MajorGrid.Enabled = False
        ChartArea1.AxisX.Maximum = 1.0R
        ChartArea1.AxisX.Minimum = 0R
        ChartArea1.AxisX.Title = "x"
        ChartArea1.AxisY.Interval = 0.1R
        ChartArea1.AxisY.IsLabelAutoFit = False
        ChartArea1.AxisY.LabelStyle.Font = New System.Drawing.Font("LG Smart UI Regular", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        ChartArea1.AxisY.MajorGrid.Enabled = False
        ChartArea1.AxisY.Maximum = 1.0R
        ChartArea1.AxisY.Minimum = 0R
        ChartArea1.AxisY.Title = "y"
        ChartArea1.BackImage = "D:\00.Programs\Pictures\optics\Plotting_Plot_Chromaticity_Diagram.png"
        ChartArea1.BackImageAlignment = System.Windows.Forms.DataVisualization.Charting.ChartImageAlignmentStyle.Center
        ChartArea1.BackImageWrapMode = System.Windows.Forms.DataVisualization.Charting.ChartImageWrapMode.Scaled
        ChartArea1.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot
        ChartArea1.InnerPlotPosition.Auto = False
        ChartArea1.InnerPlotPosition.Height = 80.0!
        ChartArea1.InnerPlotPosition.Width = 80.0!
        ChartArea1.InnerPlotPosition.X = 15.0!
        ChartArea1.InnerPlotPosition.Y = 3.0!
        ChartArea1.Name = "ChartArea1"
        Me.xyChart.ChartAreas.Add(ChartArea1)
        Legend1.Alignment = System.Drawing.StringAlignment.Center
        Legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom
        Legend1.Name = "Legend1"
        Me.xyChart.Legends.Add(Legend1)
        Me.xyChart.Location = New System.Drawing.Point(361, 371)
        Me.xyChart.Name = "xyChart"
        Series1.ChartArea = "ChartArea1"
        Series1.Legend = "Legend1"
        Series1.Name = "Series1"
        Me.xyChart.Series.Add(Series1)
        Me.xyChart.Size = New System.Drawing.Size(250, 300)
        Me.xyChart.TabIndex = 2
        Me.xyChart.Text = "Chart1"
        '
        'Labchart
        '
        ChartArea2.AxisX.Interval = 20.0R
        ChartArea2.AxisX.IsLabelAutoFit = False
        ChartArea2.AxisX.IsStartedFromZero = False
        ChartArea2.AxisX.LabelAutoFitMaxFontSize = 8
        ChartArea2.AxisX.LabelAutoFitMinFontSize = 5
        ChartArea2.AxisX.LabelStyle.Font = New System.Drawing.Font("LG Smart UI Regular", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ChartArea2.AxisX.LineColor = System.Drawing.Color.Transparent
        ChartArea2.AxisX.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.NotSet
        ChartArea2.AxisX.MajorGrid.Enabled = False
        ChartArea2.AxisX.Maximum = 100.0R
        ChartArea2.AxisX.Minimum = -100.0R
        ChartArea2.AxisX.TextOrientation = System.Windows.Forms.DataVisualization.Charting.TextOrientation.Horizontal
        ChartArea2.AxisX.Title = "a*"
        ChartArea2.AxisX.TitleFont = New System.Drawing.Font("LG Smart UI Regular", 8.0!)
        ChartArea2.AxisY.Interval = 20.0R
        ChartArea2.AxisY.IsLabelAutoFit = False
        ChartArea2.AxisY.LabelAutoFitMaxFontSize = 8
        ChartArea2.AxisY.LabelAutoFitMinFontSize = 5
        ChartArea2.AxisY.LabelStyle.Font = New System.Drawing.Font("LG Smart UI Regular", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ChartArea2.AxisY.LabelStyle.IntervalOffset = 0R
        ChartArea2.AxisY.LineColor = System.Drawing.Color.Transparent
        ChartArea2.AxisY.MajorGrid.Enabled = False
        ChartArea2.AxisY.MajorGrid.Interval = 20.0R
        ChartArea2.AxisY.MajorTickMark.Interval = 20.0R
        ChartArea2.AxisY.MajorTickMark.IntervalOffset = 0R
        ChartArea2.AxisY.MajorTickMark.TickMarkStyle = System.Windows.Forms.DataVisualization.Charting.TickMarkStyle.AcrossAxis
        ChartArea2.AxisY.Maximum = 100.0R
        ChartArea2.AxisY.Minimum = -100.0R
        ChartArea2.AxisY.MinorGrid.Interval = 20.0R
        ChartArea2.AxisY.MinorTickMark.Interval = 20.0R
        ChartArea2.AxisY.MinorTickMark.TickMarkStyle = System.Windows.Forms.DataVisualization.Charting.TickMarkStyle.AcrossAxis
        ChartArea2.AxisY.Title = "b*"
        ChartArea2.AxisY.TitleFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ChartArea2.BackImage = "D:\00.Programs\Pictures\optics\Lab_circle.png"
        ChartArea2.BackImageAlignment = System.Windows.Forms.DataVisualization.Charting.ChartImageAlignmentStyle.Center
        ChartArea2.BackImageWrapMode = System.Windows.Forms.DataVisualization.Charting.ChartImageWrapMode.Scaled
        ChartArea2.BorderColor = System.Drawing.Color.Transparent
        ChartArea2.InnerPlotPosition.Auto = False
        ChartArea2.InnerPlotPosition.Height = 80.0!
        ChartArea2.InnerPlotPosition.Width = 80.0!
        ChartArea2.InnerPlotPosition.X = 15.0!
        ChartArea2.InnerPlotPosition.Y = 3.0!
        ChartArea2.Name = "ChartArea1"
        ChartArea2.Position.Auto = False
        ChartArea2.Position.Height = 80.0!
        ChartArea2.Position.Width = 95.0!
        ChartArea2.Position.X = 5.0!
        ChartArea2.Position.Y = 7.0!
        Me.Labchart.ChartAreas.Add(ChartArea2)
        Legend2.Alignment = System.Drawing.StringAlignment.Center
        Legend2.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom
        Legend2.Name = "Legend1"
        Me.Labchart.Legends.Add(Legend2)
        Me.Labchart.Location = New System.Drawing.Point(36, 371)
        Me.Labchart.Name = "Labchart"
        Series2.ChartArea = "ChartArea1"
        Series2.Legend = "Legend1"
        Series2.Name = "Series1"
        Me.Labchart.Series.Add(Series2)
        Me.Labchart.Size = New System.Drawing.Size(251, 300)
        Me.Labchart.TabIndex = 1
        Me.Labchart.Text = "Chart2"
        '
        'spectrum_Chart
        '
        ChartArea3.Name = "ChartArea1"
        Me.spectrum_Chart.ChartAreas.Add(ChartArea3)
        Legend3.Name = "Legend1"
        Me.spectrum_Chart.Legends.Add(Legend3)
        Me.spectrum_Chart.Location = New System.Drawing.Point(36, 21)
        Me.spectrum_Chart.Name = "spectrum_Chart"
        Series3.ChartArea = "ChartArea1"
        Series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line
        Series3.LabelBorderColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Series3.LabelBorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash
        Series3.LabelForeColor = System.Drawing.Color.DimGray
        Series3.Legend = "Legend1"
        Series3.Name = "Series1"
        Series3.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32
        Me.spectrum_Chart.Series.Add(Series3)
        Me.spectrum_Chart.Size = New System.Drawing.Size(605, 241)
        Me.spectrum_Chart.TabIndex = 0
        Me.spectrum_Chart.Text = "Spectrum"
        '
        'DataGridView1
        '
        Me.DataGridView1.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(165, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(50, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("LG Smart UI Regular", 9.0!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.data_No, Me.part_Category, Me.part_Name, Me.direction, Me.year, Me.model, Me.mp_event, Me.Sequence, Me.note})
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Font = New System.Drawing.Font("LG Smart UI Regular", 9.0!)
        Me.DataGridView1.GridColor = System.Drawing.Color.PeachPuff
        Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.DataGridView1.Name = "DataGridView1"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.Gray
        DataGridViewCellStyle2.Font = New System.Drawing.Font("LG Smart UI Regular", 9.0!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.RowHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders
        Me.DataGridView1.RowTemplate.Height = 23
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(951, 199)
        Me.DataGridView1.TabIndex = 0
        '
        'data_No
        '
        Me.data_No.HeaderText = "No."
        Me.data_No.Name = "data_No"
        Me.data_No.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        '
        'part_Category
        '
        Me.part_Category.HeaderText = "Part Category"
        Me.part_Category.Items.AddRange(New Object() {"Reflector Sheet", "Diffuser Sheet", "Prism Sheet", "Diffuser Sheet", "Complex Sheet", "NOF Sheet", "Panel", "ETC"})
        Me.part_Category.Name = "part_Category"
        '
        'part_Name
        '
        Me.part_Name.HeaderText = "Part Name"
        Me.part_Name.Name = "part_Name"
        Me.part_Name.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        '
        'direction
        '
        Me.direction.HeaderText = "Direction"
        Me.direction.Items.AddRange(New Object() {"Forward", "Backward"})
        Me.direction.Name = "direction"
        '
        'year
        '
        Me.year.HeaderText = "Year"
        Me.year.Items.AddRange(New Object() {"Y18", "Y19", "Y20", "Y21", "Y22", "Y23", "Y24", "Y25", "Y26", "Y27", "Y28", "Y29", "Y30"})
        Me.year.Name = "year"
        '
        'model
        '
        Me.model.HeaderText = "Model Name"
        Me.model.Name = "model"
        Me.model.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        '
        'mp_event
        '
        Me.mp_event.HeaderText = "Event"
        Me.mp_event.Items.AddRange(New Object() {"Pre-PP", "PP", "DV", "PV", "Pre-MP", "MP"})
        Me.mp_event.Name = "mp_event"
        '
        'Sequence
        '
        Me.Sequence.HeaderText = "Sequence"
        Me.Sequence.Name = "Sequence"
        Me.Sequence.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        '
        'note
        '
        Me.note.HeaderText = "note"
        Me.note.Name = "note"
        Me.note.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        '
        'MeasuredDataBindingSource
        '
        Me.MeasuredDataBindingSource.DataSource = GetType(LGE_SD4000.Form1.measuredData)
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1573, 961)
        Me.Controls.Add(Me.Panel7)
        Me.Controls.Add(Me.Panel6)
        Me.Controls.Add(Me.Panel5)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("LG Smart UI Regular", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "[SD4000] Reflectance Measurement"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.pic_serialConnectivity, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.pic_sequence4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pic_sequence3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pic_sequence2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pic_sequence1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel7.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.xyChart, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Labchart, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.spectrum_Chart, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MeasuredDataBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents lbl_userInfo As Label
    Friend WithEvents imglist_Condition As ImageList
    Friend WithEvents imglist_light As ImageList
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Panel6 As Panel
    Friend WithEvents Panel7 As Panel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents cmb_Parity As ComboBox
    Friend WithEvents Label14 As Label
    Friend WithEvents cmb_StopBits As ComboBox
    Friend WithEvents Label13 As Label
    Friend WithEvents cmb_DataBits As ComboBox
    Friend WithEvents Label12 As Label
    Friend WithEvents cmb_Baudrate As ComboBox
    Friend WithEvents Label11 As Label
    Friend WithEvents cmb_PortNo As ComboBox
    Friend WithEvents cmb_Inferface As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents cmb_Observer As ComboBox
    Friend WithEvents cmb_StandardIlluminant As ComboBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents cmb_UV As ComboBox
    Friend WithEvents cmb_SpecularComponent As ComboBox
    Friend WithEvents cmb_MeasurementMethod As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents btn_DoMeasurement As Button
    Friend WithEvents pic_sequence4 As PictureBox
    Friend WithEvents btn_StandardCalibration As Button
    Friend WithEvents pic_sequence3 As PictureBox
    Friend WithEvents btn_ZeroCalibration As Button
    Friend WithEvents pic_sequence2 As PictureBox
    Friend WithEvents pic_sequence1 As PictureBox
    Friend WithEvents Label15 As Label
    Friend WithEvents serialPort As IO.Ports.SerialPort
    Friend WithEvents pic_serialConnectivity As PictureBox
    Friend WithEvents Label17 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents btn_sendSerialTxt As Button
    Friend WithEvents txt_ReceivedSerialTxt As RichTextBox
    Friend WithEvents txt_SendSerialTxt As TextBox
    Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Labchart As DataVisualization.Charting.Chart
    Friend WithEvents spectrum_Chart As DataVisualization.Charting.Chart
    Friend WithEvents data_No As DataGridViewTextBoxColumn
    Friend WithEvents part_Category As DataGridViewComboBoxColumn
    Friend WithEvents part_Name As DataGridViewTextBoxColumn
    Friend WithEvents direction As DataGridViewComboBoxColumn
    Friend WithEvents year As DataGridViewComboBoxColumn
    Friend WithEvents model As DataGridViewTextBoxColumn
    Friend WithEvents mp_event As DataGridViewComboBoxColumn
    Friend WithEvents Sequence As DataGridViewTextBoxColumn
    Friend WithEvents note As DataGridViewTextBoxColumn
    Friend WithEvents xyChart As DataVisualization.Charting.Chart
    Friend WithEvents DataGridView2 As DataGridView
    Friend WithEvents MeasuredDataBindingSource As BindingSource
End Class
