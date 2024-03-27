<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ManualForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ManualForm))
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.lbl_date = New System.Windows.Forms.Label()
        Me.DateTime = New System.Windows.Forms.Timer(Me.components)
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lbl_curr_time = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lbl_user = New System.Windows.Forms.Label()
        Me.gb_ST1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.btn_v101_bw = New System.Windows.Forms.Button()
        Me.btn_v101_fw = New System.Windows.Forms.Button()
        Me.ind_v101_min = New System.Windows.Forms.PictureBox()
        Me.ind_v101_max = New System.Windows.Forms.PictureBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label301 = New System.Windows.Forms.Label()
        Me.Label283 = New System.Windows.Forms.Label()
        Me.Label288 = New System.Windows.Forms.Label()
        Me.Label280 = New System.Windows.Forms.Label()
        Me.Label285 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label284 = New System.Windows.Forms.Label()
        Me.Label281 = New System.Windows.Forms.Label()
        Me.ind_safety_st6 = New System.Windows.Forms.PictureBox()
        Me.ind_safety_st2 = New System.Windows.Forms.PictureBox()
        Me.ind_safety_st4 = New System.Windows.Forms.PictureBox()
        Me.ind_cycle_status = New System.Windows.Forms.PictureBox()
        Me.ind_safety_st5 = New System.Windows.Forms.PictureBox()
        Me.ind_safety_st1 = New System.Windows.Forms.PictureBox()
        Me.ind_safety_st3 = New System.Windows.Forms.PictureBox()
        Me.ind_altivar_status = New System.Windows.Forms.PictureBox()
        Me.btn_st6 = New System.Windows.Forms.Button()
        Me.btn_st5 = New System.Windows.Forms.Button()
        Me.btn_st4 = New System.Windows.Forms.Button()
        Me.btn_st3 = New System.Windows.Forms.Button()
        Me.btn_st2 = New System.Windows.Forms.Button()
        Me.btn_st1 = New System.Windows.Forms.Button()
        Me.btn_home = New System.Windows.Forms.Button()
        Me.btn_login = New System.Windows.Forms.Button()
        Me.pb_status_bar = New System.Windows.Forms.PictureBox()
        Me.pb_status_mc = New System.Windows.Forms.PictureBox()
        Me.pb_logo = New System.Windows.Forms.PictureBox()
        Me.gb_ST1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.ind_v101_min, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ind_v101_max, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.ind_safety_st6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ind_safety_st2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ind_safety_st4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ind_cycle_status, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ind_safety_st5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ind_safety_st1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ind_safety_st3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ind_altivar_status, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pb_status_bar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pb_status_mc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pb_logo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.Color.DarkRed
        Me.TextBox1.Font = New System.Drawing.Font("Arial Narrow", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.ForeColor = System.Drawing.SystemColors.Window
        Me.TextBox1.Location = New System.Drawing.Point(12, 121)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(1326, 30)
        Me.TextBox1.TabIndex = 26
        Me.TextBox1.Text = "ALARM : . . . . . . . . "
        '
        'lbl_date
        '
        Me.lbl_date.AutoSize = True
        Me.lbl_date.BackColor = System.Drawing.Color.LimeGreen
        Me.lbl_date.Font = New System.Drawing.Font("Arial Narrow", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_date.ForeColor = System.Drawing.Color.White
        Me.lbl_date.Location = New System.Drawing.Point(788, 64)
        Me.lbl_date.Name = "lbl_date"
        Me.lbl_date.Size = New System.Drawing.Size(124, 31)
        Me.lbl_date.TabIndex = 12
        Me.lbl_date.Text = "31-12-2000"
        '
        'DateTime
        '
        Me.DateTime.Enabled = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.LimeGreen
        Me.Label2.Font = New System.Drawing.Font("Arial Narrow", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(435, 64)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(121, 31)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "STOPPED"
        '
        'lbl_curr_time
        '
        Me.lbl_curr_time.AutoSize = True
        Me.lbl_curr_time.BackColor = System.Drawing.Color.LimeGreen
        Me.lbl_curr_time.Font = New System.Drawing.Font("Arial Narrow", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_curr_time.ForeColor = System.Drawing.Color.White
        Me.lbl_curr_time.Location = New System.Drawing.Point(812, 29)
        Me.lbl_curr_time.Name = "lbl_curr_time"
        Me.lbl_curr_time.Size = New System.Drawing.Size(100, 31)
        Me.lbl_curr_time.TabIndex = 10
        Me.lbl_curr_time.Text = "23:59:59"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.LimeGreen
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(435, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(110, 31)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "MANUAL"
        '
        'lbl_user
        '
        Me.lbl_user.AutoSize = True
        Me.lbl_user.Font = New System.Drawing.Font("Arial Narrow", 48.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_user.Location = New System.Drawing.Point(1192, 20)
        Me.lbl_user.Name = "lbl_user"
        Me.lbl_user.Size = New System.Drawing.Size(146, 75)
        Me.lbl_user.TabIndex = 8
        Me.lbl_user.Text = "ENG"
        '
        'gb_ST1
        '
        Me.gb_ST1.Controls.Add(Me.GroupBox3)
        Me.gb_ST1.Controls.Add(Me.GroupBox2)
        Me.gb_ST1.Font = New System.Drawing.Font("Arial Narrow", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gb_ST1.Location = New System.Drawing.Point(138, 169)
        Me.gb_ST1.Name = "gb_ST1"
        Me.gb_ST1.Size = New System.Drawing.Size(1074, 540)
        Me.gb_ST1.TabIndex = 29
        Me.gb_ST1.TabStop = False
        Me.gb_ST1.Text = "STATION 1"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.GroupBox5)
        Me.GroupBox3.Controls.Add(Me.GroupBox4)
        Me.GroupBox3.Location = New System.Drawing.Point(199, 41)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(869, 464)
        Me.GroupBox3.TabIndex = 3
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "OPERATION"
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.Button3)
        Me.GroupBox5.Location = New System.Drawing.Point(191, 25)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(135, 110)
        Me.GroupBox5.TabIndex = 112
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "TURN TABLE"
        '
        'Button3
        '
        Me.Button3.Font = New System.Drawing.Font("Arial Narrow", 12.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.Location = New System.Drawing.Point(14, 24)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(110, 76)
        Me.Button3.TabIndex = 108
        Me.Button3.Text = "TRIGGER TURN TABLE"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.btn_v101_bw)
        Me.GroupBox4.Controls.Add(Me.btn_v101_fw)
        Me.GroupBox4.Controls.Add(Me.ind_v101_min)
        Me.GroupBox4.Controls.Add(Me.ind_v101_max)
        Me.GroupBox4.Location = New System.Drawing.Point(6, 25)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(175, 110)
        Me.GroupBox4.TabIndex = 111
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "CYL V101"
        '
        'btn_v101_bw
        '
        Me.btn_v101_bw.Location = New System.Drawing.Point(12, 65)
        Me.btn_v101_bw.Name = "btn_v101_bw"
        Me.btn_v101_bw.Size = New System.Drawing.Size(110, 35)
        Me.btn_v101_bw.TabIndex = 108
        Me.btn_v101_bw.Text = "BACKWARD"
        Me.btn_v101_bw.UseVisualStyleBackColor = True
        '
        'btn_v101_fw
        '
        Me.btn_v101_fw.Location = New System.Drawing.Point(12, 24)
        Me.btn_v101_fw.Name = "btn_v101_fw"
        Me.btn_v101_fw.Size = New System.Drawing.Size(110, 35)
        Me.btn_v101_fw.TabIndex = 109
        Me.btn_v101_fw.Text = "FORWARD"
        Me.btn_v101_fw.UseVisualStyleBackColor = True
        '
        'ind_v101_min
        '
        Me.ind_v101_min.BackColor = System.Drawing.Color.Transparent
        Me.ind_v101_min.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ind_v101_min.Image = CType(resources.GetObject("ind_v101_min.Image"), System.Drawing.Image)
        Me.ind_v101_min.Location = New System.Drawing.Point(128, 65)
        Me.ind_v101_min.Name = "ind_v101_min"
        Me.ind_v101_min.Size = New System.Drawing.Size(35, 35)
        Me.ind_v101_min.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.ind_v101_min.TabIndex = 110
        Me.ind_v101_min.TabStop = False
        '
        'ind_v101_max
        '
        Me.ind_v101_max.BackColor = System.Drawing.Color.Transparent
        Me.ind_v101_max.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ind_v101_max.Image = CType(resources.GetObject("ind_v101_max.Image"), System.Drawing.Image)
        Me.ind_v101_max.Location = New System.Drawing.Point(128, 24)
        Me.ind_v101_max.Name = "ind_v101_max"
        Me.ind_v101_max.Size = New System.Drawing.Size(35, 35)
        Me.ind_v101_max.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.ind_v101_max.TabIndex = 111
        Me.ind_v101_max.TabStop = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label301)
        Me.GroupBox2.Controls.Add(Me.Label283)
        Me.GroupBox2.Controls.Add(Me.Label288)
        Me.GroupBox2.Controls.Add(Me.Label280)
        Me.GroupBox2.Controls.Add(Me.Label285)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Label284)
        Me.GroupBox2.Controls.Add(Me.Label281)
        Me.GroupBox2.Controls.Add(Me.ind_safety_st6)
        Me.GroupBox2.Controls.Add(Me.ind_safety_st2)
        Me.GroupBox2.Controls.Add(Me.ind_safety_st4)
        Me.GroupBox2.Controls.Add(Me.ind_cycle_status)
        Me.GroupBox2.Controls.Add(Me.ind_safety_st5)
        Me.GroupBox2.Controls.Add(Me.ind_safety_st1)
        Me.GroupBox2.Controls.Add(Me.ind_safety_st3)
        Me.GroupBox2.Controls.Add(Me.ind_altivar_status)
        Me.GroupBox2.Location = New System.Drawing.Point(16, 41)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(177, 464)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "STATUS INDICATOR"
        '
        'Label301
        '
        Me.Label301.AutoSize = True
        Me.Label301.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label301.Location = New System.Drawing.Point(58, 428)
        Me.Label301.Name = "Label301"
        Me.Label301.Size = New System.Drawing.Size(106, 20)
        Me.Label301.TabIndex = 122
        Me.Label301.Text = "Safety Station 6"
        '
        'Label283
        '
        Me.Label283.AutoSize = True
        Me.Label283.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label283.Location = New System.Drawing.Point(57, 203)
        Me.Label283.Name = "Label283"
        Me.Label283.Size = New System.Drawing.Size(106, 20)
        Me.Label283.TabIndex = 121
        Me.Label283.Text = "Safety Station 2"
        '
        'Label288
        '
        Me.Label288.AutoSize = True
        Me.Label288.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label288.Location = New System.Drawing.Point(58, 316)
        Me.Label288.Name = "Label288"
        Me.Label288.Size = New System.Drawing.Size(106, 20)
        Me.Label288.TabIndex = 120
        Me.Label288.Text = "Safety Station 4"
        '
        'Label280
        '
        Me.Label280.AutoSize = True
        Me.Label280.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label280.Location = New System.Drawing.Point(57, 91)
        Me.Label280.Name = "Label280"
        Me.Label280.Size = New System.Drawing.Size(86, 20)
        Me.Label280.TabIndex = 119
        Me.Label280.Text = "Cycle Status"
        '
        'Label285
        '
        Me.Label285.AutoSize = True
        Me.Label285.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label285.Location = New System.Drawing.Point(58, 372)
        Me.Label285.Name = "Label285"
        Me.Label285.Size = New System.Drawing.Size(106, 20)
        Me.Label285.TabIndex = 117
        Me.Label285.Text = "Safety Station 5"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(57, 147)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(106, 20)
        Me.Label3.TabIndex = 116
        Me.Label3.Text = "Safety Station 1"
        '
        'Label284
        '
        Me.Label284.AutoSize = True
        Me.Label284.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label284.Location = New System.Drawing.Point(58, 260)
        Me.Label284.Name = "Label284"
        Me.Label284.Size = New System.Drawing.Size(106, 20)
        Me.Label284.TabIndex = 118
        Me.Label284.Text = "Safety Station 3"
        '
        'Label281
        '
        Me.Label281.AutoSize = True
        Me.Label281.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label281.Location = New System.Drawing.Point(57, 35)
        Me.Label281.Name = "Label281"
        Me.Label281.Size = New System.Drawing.Size(92, 20)
        Me.Label281.TabIndex = 115
        Me.Label281.Text = "Altivar Status"
        '
        'ind_safety_st6
        '
        Me.ind_safety_st6.BackColor = System.Drawing.Color.Transparent
        Me.ind_safety_st6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ind_safety_st6.Image = CType(resources.GetObject("ind_safety_st6.Image"), System.Drawing.Image)
        Me.ind_safety_st6.Location = New System.Drawing.Point(20, 423)
        Me.ind_safety_st6.Name = "ind_safety_st6"
        Me.ind_safety_st6.Size = New System.Drawing.Size(30, 30)
        Me.ind_safety_st6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.ind_safety_st6.TabIndex = 114
        Me.ind_safety_st6.TabStop = False
        '
        'ind_safety_st2
        '
        Me.ind_safety_st2.BackColor = System.Drawing.Color.Transparent
        Me.ind_safety_st2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ind_safety_st2.Image = CType(resources.GetObject("ind_safety_st2.Image"), System.Drawing.Image)
        Me.ind_safety_st2.Location = New System.Drawing.Point(19, 198)
        Me.ind_safety_st2.Name = "ind_safety_st2"
        Me.ind_safety_st2.Size = New System.Drawing.Size(30, 30)
        Me.ind_safety_st2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.ind_safety_st2.TabIndex = 113
        Me.ind_safety_st2.TabStop = False
        '
        'ind_safety_st4
        '
        Me.ind_safety_st4.BackColor = System.Drawing.Color.Transparent
        Me.ind_safety_st4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ind_safety_st4.Image = CType(resources.GetObject("ind_safety_st4.Image"), System.Drawing.Image)
        Me.ind_safety_st4.Location = New System.Drawing.Point(20, 311)
        Me.ind_safety_st4.Name = "ind_safety_st4"
        Me.ind_safety_st4.Size = New System.Drawing.Size(30, 30)
        Me.ind_safety_st4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.ind_safety_st4.TabIndex = 112
        Me.ind_safety_st4.TabStop = False
        '
        'ind_cycle_status
        '
        Me.ind_cycle_status.BackColor = System.Drawing.Color.Transparent
        Me.ind_cycle_status.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ind_cycle_status.Image = CType(resources.GetObject("ind_cycle_status.Image"), System.Drawing.Image)
        Me.ind_cycle_status.Location = New System.Drawing.Point(19, 86)
        Me.ind_cycle_status.Name = "ind_cycle_status"
        Me.ind_cycle_status.Size = New System.Drawing.Size(30, 30)
        Me.ind_cycle_status.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.ind_cycle_status.TabIndex = 111
        Me.ind_cycle_status.TabStop = False
        '
        'ind_safety_st5
        '
        Me.ind_safety_st5.BackColor = System.Drawing.Color.Transparent
        Me.ind_safety_st5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ind_safety_st5.Image = CType(resources.GetObject("ind_safety_st5.Image"), System.Drawing.Image)
        Me.ind_safety_st5.Location = New System.Drawing.Point(20, 367)
        Me.ind_safety_st5.Name = "ind_safety_st5"
        Me.ind_safety_st5.Size = New System.Drawing.Size(30, 30)
        Me.ind_safety_st5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.ind_safety_st5.TabIndex = 109
        Me.ind_safety_st5.TabStop = False
        '
        'ind_safety_st1
        '
        Me.ind_safety_st1.BackColor = System.Drawing.Color.Transparent
        Me.ind_safety_st1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ind_safety_st1.Image = CType(resources.GetObject("ind_safety_st1.Image"), System.Drawing.Image)
        Me.ind_safety_st1.Location = New System.Drawing.Point(19, 142)
        Me.ind_safety_st1.Name = "ind_safety_st1"
        Me.ind_safety_st1.Size = New System.Drawing.Size(30, 30)
        Me.ind_safety_st1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.ind_safety_st1.TabIndex = 108
        Me.ind_safety_st1.TabStop = False
        '
        'ind_safety_st3
        '
        Me.ind_safety_st3.BackColor = System.Drawing.Color.Transparent
        Me.ind_safety_st3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ind_safety_st3.Image = CType(resources.GetObject("ind_safety_st3.Image"), System.Drawing.Image)
        Me.ind_safety_st3.Location = New System.Drawing.Point(20, 255)
        Me.ind_safety_st3.Name = "ind_safety_st3"
        Me.ind_safety_st3.Size = New System.Drawing.Size(30, 30)
        Me.ind_safety_st3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.ind_safety_st3.TabIndex = 110
        Me.ind_safety_st3.TabStop = False
        '
        'ind_altivar_status
        '
        Me.ind_altivar_status.BackColor = System.Drawing.Color.Transparent
        Me.ind_altivar_status.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ind_altivar_status.Image = Global.MASTER.My.Resources.Resources.led_green_on
        Me.ind_altivar_status.Location = New System.Drawing.Point(19, 30)
        Me.ind_altivar_status.Name = "ind_altivar_status"
        Me.ind_altivar_status.Size = New System.Drawing.Size(30, 30)
        Me.ind_altivar_status.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.ind_altivar_status.TabIndex = 107
        Me.ind_altivar_status.TabStop = False
        '
        'btn_st6
        '
        Me.btn_st6.Font = New System.Drawing.Font("Arial Narrow", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_st6.Image = CType(resources.GetObject("btn_st6.Image"), System.Drawing.Image)
        Me.btn_st6.Location = New System.Drawing.Point(1218, 624)
        Me.btn_st6.Name = "btn_st6"
        Me.btn_st6.Size = New System.Drawing.Size(120, 85)
        Me.btn_st6.TabIndex = 24
        Me.btn_st6.Text = "ST6"
        Me.btn_st6.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btn_st6.UseVisualStyleBackColor = True
        '
        'btn_st5
        '
        Me.btn_st5.Font = New System.Drawing.Font("Arial Narrow", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_st5.Image = CType(resources.GetObject("btn_st5.Image"), System.Drawing.Image)
        Me.btn_st5.Location = New System.Drawing.Point(1218, 533)
        Me.btn_st5.Name = "btn_st5"
        Me.btn_st5.Size = New System.Drawing.Size(120, 85)
        Me.btn_st5.TabIndex = 22
        Me.btn_st5.Text = "ST5"
        Me.btn_st5.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btn_st5.UseVisualStyleBackColor = True
        '
        'btn_st4
        '
        Me.btn_st4.Font = New System.Drawing.Font("Arial Narrow", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_st4.Image = CType(resources.GetObject("btn_st4.Image"), System.Drawing.Image)
        Me.btn_st4.Location = New System.Drawing.Point(1218, 442)
        Me.btn_st4.Name = "btn_st4"
        Me.btn_st4.Size = New System.Drawing.Size(120, 85)
        Me.btn_st4.TabIndex = 20
        Me.btn_st4.Text = "ST4"
        Me.btn_st4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btn_st4.UseVisualStyleBackColor = True
        '
        'btn_st3
        '
        Me.btn_st3.Font = New System.Drawing.Font("Arial Narrow", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_st3.Image = CType(resources.GetObject("btn_st3.Image"), System.Drawing.Image)
        Me.btn_st3.Location = New System.Drawing.Point(1218, 351)
        Me.btn_st3.Name = "btn_st3"
        Me.btn_st3.Size = New System.Drawing.Size(120, 85)
        Me.btn_st3.TabIndex = 18
        Me.btn_st3.Text = "ST3"
        Me.btn_st3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btn_st3.UseVisualStyleBackColor = True
        '
        'btn_st2
        '
        Me.btn_st2.Font = New System.Drawing.Font("Arial Narrow", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_st2.Image = CType(resources.GetObject("btn_st2.Image"), System.Drawing.Image)
        Me.btn_st2.Location = New System.Drawing.Point(1218, 260)
        Me.btn_st2.Name = "btn_st2"
        Me.btn_st2.Size = New System.Drawing.Size(120, 85)
        Me.btn_st2.TabIndex = 16
        Me.btn_st2.Text = "ST2"
        Me.btn_st2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btn_st2.UseVisualStyleBackColor = True
        '
        'btn_st1
        '
        Me.btn_st1.Font = New System.Drawing.Font("Arial Narrow", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_st1.Image = CType(resources.GetObject("btn_st1.Image"), System.Drawing.Image)
        Me.btn_st1.Location = New System.Drawing.Point(1218, 169)
        Me.btn_st1.Name = "btn_st1"
        Me.btn_st1.Size = New System.Drawing.Size(120, 85)
        Me.btn_st1.TabIndex = 15
        Me.btn_st1.Text = "ST1"
        Me.btn_st1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btn_st1.UseVisualStyleBackColor = True
        '
        'btn_home
        '
        Me.btn_home.Font = New System.Drawing.Font("Arial Narrow", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_home.Image = Global.MASTER.My.Resources.Resources.icons8_home_50
        Me.btn_home.Location = New System.Drawing.Point(12, 169)
        Me.btn_home.Name = "btn_home"
        Me.btn_home.Size = New System.Drawing.Size(120, 85)
        Me.btn_home.TabIndex = 14
        Me.btn_home.Text = "Home"
        Me.btn_home.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btn_home.UseVisualStyleBackColor = True
        '
        'btn_login
        '
        Me.btn_login.Font = New System.Drawing.Font("Arial Narrow", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_login.Image = Global.MASTER.My.Resources.Resources.icons8_change_user_50
        Me.btn_login.Location = New System.Drawing.Point(1101, 20)
        Me.btn_login.Name = "btn_login"
        Me.btn_login.Size = New System.Drawing.Size(85, 85)
        Me.btn_login.TabIndex = 13
        Me.btn_login.Text = "Login"
        Me.btn_login.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btn_login.UseVisualStyleBackColor = True
        '
        'pb_status_bar
        '
        Me.pb_status_bar.BackColor = System.Drawing.Color.LimeGreen
        Me.pb_status_bar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pb_status_bar.Location = New System.Drawing.Point(425, 20)
        Me.pb_status_bar.Name = "pb_status_bar"
        Me.pb_status_bar.Size = New System.Drawing.Size(500, 85)
        Me.pb_status_bar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pb_status_bar.TabIndex = 7
        Me.pb_status_bar.TabStop = False
        '
        'pb_status_mc
        '
        Me.pb_status_mc.Image = Global.MASTER.My.Resources.Resources.mark_ok
        Me.pb_status_mc.Location = New System.Drawing.Point(967, 20)
        Me.pb_status_mc.Name = "pb_status_mc"
        Me.pb_status_mc.Size = New System.Drawing.Size(85, 85)
        Me.pb_status_mc.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pb_status_mc.TabIndex = 6
        Me.pb_status_mc.TabStop = False
        '
        'pb_logo
        '
        Me.pb_logo.Image = Global.MASTER.My.Resources.Resources.logo_sanindo_tekno_batam
        Me.pb_logo.Location = New System.Drawing.Point(12, 20)
        Me.pb_logo.Name = "pb_logo"
        Me.pb_logo.Size = New System.Drawing.Size(250, 85)
        Me.pb_logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pb_logo.TabIndex = 5
        Me.pb_logo.TabStop = False
        '
        'ManualForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1350, 729)
        Me.Controls.Add(Me.gb_ST1)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.btn_st6)
        Me.Controls.Add(Me.btn_st5)
        Me.Controls.Add(Me.btn_st4)
        Me.Controls.Add(Me.btn_st3)
        Me.Controls.Add(Me.btn_st2)
        Me.Controls.Add(Me.btn_st1)
        Me.Controls.Add(Me.btn_home)
        Me.Controls.Add(Me.btn_login)
        Me.Controls.Add(Me.lbl_date)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lbl_curr_time)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lbl_user)
        Me.Controls.Add(Me.pb_status_bar)
        Me.Controls.Add(Me.pb_status_mc)
        Me.Controls.Add(Me.pb_logo)
        Me.Name = "ManualForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Project Title"
        Me.gb_ST1.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        CType(Me.ind_v101_min, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ind_v101_max, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.ind_safety_st6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ind_safety_st2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ind_safety_st4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ind_cycle_status, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ind_safety_st5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ind_safety_st1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ind_safety_st3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ind_altivar_status, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pb_status_bar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pb_status_mc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pb_logo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents btn_st6 As Button
    Friend WithEvents btn_st5 As Button
    Friend WithEvents btn_st4 As Button
    Friend WithEvents btn_st3 As Button
    Friend WithEvents btn_st2 As Button
    Friend WithEvents btn_st1 As Button
    Friend WithEvents btn_home As Button
    Friend WithEvents btn_login As Button
    Friend WithEvents lbl_date As Label
    Friend WithEvents DateTime As Timer
    Friend WithEvents Label2 As Label
    Friend WithEvents lbl_curr_time As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents lbl_user As Label
    Friend WithEvents pb_status_bar As PictureBox
    Friend WithEvents pb_status_mc As PictureBox
    Friend WithEvents pb_logo As PictureBox
    Friend WithEvents gb_ST1 As GroupBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents Button3 As Button
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents btn_v101_bw As Button
    Friend WithEvents btn_v101_fw As Button
    Friend WithEvents ind_v101_min As PictureBox
    Friend WithEvents ind_v101_max As PictureBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label301 As Label
    Friend WithEvents Label283 As Label
    Friend WithEvents Label288 As Label
    Friend WithEvents Label280 As Label
    Friend WithEvents Label285 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label284 As Label
    Friend WithEvents Label281 As Label
    Friend WithEvents ind_safety_st6 As PictureBox
    Friend WithEvents ind_safety_st2 As PictureBox
    Friend WithEvents ind_safety_st4 As PictureBox
    Friend WithEvents ind_cycle_status As PictureBox
    Friend WithEvents ind_safety_st5 As PictureBox
    Friend WithEvents ind_safety_st1 As PictureBox
    Friend WithEvents ind_safety_st3 As PictureBox
    Friend WithEvents ind_altivar_status As PictureBox
End Class
