<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LogForm
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
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.lbl_date = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lbl_curr_time = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lbl_user = New System.Windows.Forms.Label()
        Me.btn_home = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox_Status = New System.Windows.Forms.GroupBox()
        Me.RTB_Status = New System.Windows.Forms.RichTextBox()
        Me.GroupBox_Export = New System.Windows.Forms.GroupBox()
        Me.btn_fileLocation = New System.Windows.Forms.Button()
        Me.ProgressBarExport = New System.Windows.Forms.ProgressBar()
        Me.txtFileLocation = New System.Windows.Forms.TextBox()
        Me.btn_export = New System.Windows.Forms.Button()
        Me.GroupBox_Filter = New System.Windows.Forms.GroupBox()
        Me.rbByREF = New System.Windows.Forms.RadioButton()
        Me.rbBydate = New System.Windows.Forms.RadioButton()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.tbSearchPO = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.DateTimePickerEndDate = New System.Windows.Forms.DateTimePicker()
        Me.DateTimePickerStartDate = New System.Windows.Forms.DateTimePicker()
        Me.btn_search = New System.Windows.Forms.Button()
        Me.DateTime = New System.Windows.Forms.Timer(Me.components)
        Me.btn_login = New System.Windows.Forms.Button()
        Me.pb_status_mc = New System.Windows.Forms.PictureBox()
        Me.pb_logo = New System.Windows.Forms.PictureBox()
        Me.pb_status_bar = New System.Windows.Forms.PictureBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox_Status.SuspendLayout()
        Me.GroupBox_Export.SuspendLayout()
        Me.GroupBox_Filter.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.pb_status_mc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pb_logo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pb_status_bar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
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
        Me.TextBox1.TabIndex = 73
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
        Me.lbl_date.TabIndex = 70
        Me.lbl_date.Text = "31-12-2000"
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
        Me.Label2.TabIndex = 69
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
        Me.lbl_curr_time.TabIndex = 68
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
        Me.Label1.TabIndex = 67
        Me.Label1.Text = "MANUAL"
        '
        'lbl_user
        '
        Me.lbl_user.AutoSize = True
        Me.lbl_user.Font = New System.Drawing.Font("Arial Narrow", 48.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_user.Location = New System.Drawing.Point(1192, 20)
        Me.lbl_user.Name = "lbl_user"
        Me.lbl_user.Size = New System.Drawing.Size(146, 75)
        Me.lbl_user.TabIndex = 66
        Me.lbl_user.Text = "ENG"
        '
        'btn_home
        '
        Me.btn_home.Font = New System.Drawing.Font("Arial Narrow", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_home.Image = Global.MASTER.My.Resources.Resources.icons8_home_50
        Me.btn_home.Location = New System.Drawing.Point(12, 169)
        Me.btn_home.Name = "btn_home"
        Me.btn_home.Size = New System.Drawing.Size(120, 85)
        Me.btn_home.TabIndex = 72
        Me.btn_home.Text = "Home"
        Me.btn_home.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btn_home.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(6, 13)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(1176, 339)
        Me.DataGridView1.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.GroupBox4)
        Me.GroupBox1.Controls.Add(Me.GroupBox_Status)
        Me.GroupBox1.Controls.Add(Me.GroupBox_Export)
        Me.GroupBox1.Controls.Add(Me.GroupBox_Filter)
        Me.GroupBox1.Location = New System.Drawing.Point(138, 163)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1200, 546)
        Me.GroupBox1.TabIndex = 74
        Me.GroupBox1.TabStop = False
        '
        'GroupBox_Status
        '
        Me.GroupBox_Status.BackColor = System.Drawing.Color.White
        Me.GroupBox_Status.Controls.Add(Me.RTB_Status)
        Me.GroupBox_Status.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox_Status.ForeColor = System.Drawing.Color.Black
        Me.GroupBox_Status.Location = New System.Drawing.Point(816, 370)
        Me.GroupBox_Status.Name = "GroupBox_Status"
        Me.GroupBox_Status.Size = New System.Drawing.Size(378, 170)
        Me.GroupBox_Status.TabIndex = 24
        Me.GroupBox_Status.TabStop = False
        Me.GroupBox_Status.Text = "Status"
        '
        'RTB_Status
        '
        Me.RTB_Status.BackColor = System.Drawing.Color.White
        Me.RTB_Status.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RTB_Status.ForeColor = System.Drawing.SystemColors.WindowText
        Me.RTB_Status.Location = New System.Drawing.Point(6, 25)
        Me.RTB_Status.Name = "RTB_Status"
        Me.RTB_Status.ReadOnly = True
        Me.RTB_Status.Size = New System.Drawing.Size(366, 139)
        Me.RTB_Status.TabIndex = 0
        Me.RTB_Status.Text = ""
        '
        'GroupBox_Export
        '
        Me.GroupBox_Export.BackColor = System.Drawing.Color.White
        Me.GroupBox_Export.Controls.Add(Me.btn_fileLocation)
        Me.GroupBox_Export.Controls.Add(Me.ProgressBarExport)
        Me.GroupBox_Export.Controls.Add(Me.txtFileLocation)
        Me.GroupBox_Export.Controls.Add(Me.btn_export)
        Me.GroupBox_Export.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox_Export.ForeColor = System.Drawing.Color.Black
        Me.GroupBox_Export.Location = New System.Drawing.Point(481, 370)
        Me.GroupBox_Export.Name = "GroupBox_Export"
        Me.GroupBox_Export.Size = New System.Drawing.Size(329, 170)
        Me.GroupBox_Export.TabIndex = 22
        Me.GroupBox_Export.TabStop = False
        Me.GroupBox_Export.Text = "Export File Location"
        '
        'btn_fileLocation
        '
        Me.btn_fileLocation.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_fileLocation.Location = New System.Drawing.Point(22, 123)
        Me.btn_fileLocation.Name = "btn_fileLocation"
        Me.btn_fileLocation.Size = New System.Drawing.Size(94, 35)
        Me.btn_fileLocation.TabIndex = 10
        Me.btn_fileLocation.Text = "Select File Location"
        Me.btn_fileLocation.UseVisualStyleBackColor = True
        '
        'ProgressBarExport
        '
        Me.ProgressBarExport.Location = New System.Drawing.Point(22, 63)
        Me.ProgressBarExport.Name = "ProgressBarExport"
        Me.ProgressBarExport.Size = New System.Drawing.Size(289, 23)
        Me.ProgressBarExport.TabIndex = 9
        '
        'txtFileLocation
        '
        Me.txtFileLocation.BackColor = System.Drawing.Color.White
        Me.txtFileLocation.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFileLocation.ForeColor = System.Drawing.Color.Black
        Me.txtFileLocation.Location = New System.Drawing.Point(22, 31)
        Me.txtFileLocation.Name = "txtFileLocation"
        Me.txtFileLocation.Size = New System.Drawing.Size(289, 22)
        Me.txtFileLocation.TabIndex = 8
        '
        'btn_export
        '
        Me.btn_export.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_export.Location = New System.Drawing.Point(217, 123)
        Me.btn_export.Name = "btn_export"
        Me.btn_export.Size = New System.Drawing.Size(94, 35)
        Me.btn_export.TabIndex = 6
        Me.btn_export.Text = "Export"
        Me.btn_export.UseVisualStyleBackColor = True
        '
        'GroupBox_Filter
        '
        Me.GroupBox_Filter.BackColor = System.Drawing.Color.White
        Me.GroupBox_Filter.Controls.Add(Me.rbByREF)
        Me.GroupBox_Filter.Controls.Add(Me.rbBydate)
        Me.GroupBox_Filter.Controls.Add(Me.GroupBox3)
        Me.GroupBox_Filter.Controls.Add(Me.GroupBox2)
        Me.GroupBox_Filter.Controls.Add(Me.btn_search)
        Me.GroupBox_Filter.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox_Filter.ForeColor = System.Drawing.Color.Black
        Me.GroupBox_Filter.Location = New System.Drawing.Point(6, 370)
        Me.GroupBox_Filter.Name = "GroupBox_Filter"
        Me.GroupBox_Filter.Size = New System.Drawing.Size(469, 170)
        Me.GroupBox_Filter.TabIndex = 21
        Me.GroupBox_Filter.TabStop = False
        Me.GroupBox_Filter.Text = "Datalog Finder"
        '
        'rbByREF
        '
        Me.rbByREF.AutoSize = True
        Me.rbByREF.Location = New System.Drawing.Point(348, 70)
        Me.rbByREF.Name = "rbByREF"
        Me.rbByREF.Size = New System.Drawing.Size(115, 24)
        Me.rbByREF.TabIndex = 8
        Me.rbByREF.TabStop = True
        Me.rbByREF.Text = "By References"
        Me.rbByREF.UseVisualStyleBackColor = True
        '
        'rbBydate
        '
        Me.rbBydate.AutoSize = True
        Me.rbBydate.Location = New System.Drawing.Point(348, 33)
        Me.rbBydate.Name = "rbBydate"
        Me.rbBydate.Size = New System.Drawing.Size(74, 24)
        Me.rbBydate.TabIndex = 7
        Me.rbBydate.TabStop = True
        Me.rbBydate.Text = "By Date"
        Me.rbBydate.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.tbSearchPO)
        Me.GroupBox3.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(6, 115)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(313, 49)
        Me.GroupBox3.TabIndex = 6
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "By References"
        '
        'tbSearchPO
        '
        Me.tbSearchPO.BackColor = System.Drawing.Color.White
        Me.tbSearchPO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbSearchPO.ForeColor = System.Drawing.Color.Black
        Me.tbSearchPO.Location = New System.Drawing.Point(9, 21)
        Me.tbSearchPO.Name = "tbSearchPO"
        Me.tbSearchPO.Size = New System.Drawing.Size(298, 22)
        Me.tbSearchPO.TabIndex = 24
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.DateTimePickerEndDate)
        Me.GroupBox2.Controls.Add(Me.DateTimePickerStartDate)
        Me.GroupBox2.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(6, 25)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(313, 73)
        Me.GroupBox2.TabIndex = 5
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "By Date"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(6, 19)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(69, 20)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Start Date"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(6, 47)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(65, 20)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "End Date"
        '
        'DateTimePickerEndDate
        '
        Me.DateTimePickerEndDate.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateTimePickerEndDate.Location = New System.Drawing.Point(97, 43)
        Me.DateTimePickerEndDate.Name = "DateTimePickerEndDate"
        Me.DateTimePickerEndDate.Size = New System.Drawing.Size(200, 26)
        Me.DateTimePickerEndDate.TabIndex = 2
        '
        'DateTimePickerStartDate
        '
        Me.DateTimePickerStartDate.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateTimePickerStartDate.Location = New System.Drawing.Point(97, 15)
        Me.DateTimePickerStartDate.Name = "DateTimePickerStartDate"
        Me.DateTimePickerStartDate.Size = New System.Drawing.Size(200, 26)
        Me.DateTimePickerStartDate.TabIndex = 0
        '
        'btn_search
        '
        Me.btn_search.Location = New System.Drawing.Point(325, 115)
        Me.btn_search.Name = "btn_search"
        Me.btn_search.Size = New System.Drawing.Size(138, 49)
        Me.btn_search.TabIndex = 4
        Me.btn_search.Text = "Search"
        Me.btn_search.UseVisualStyleBackColor = True
        '
        'DateTime
        '
        Me.DateTime.Enabled = True
        '
        'btn_login
        '
        Me.btn_login.Font = New System.Drawing.Font("Arial Narrow", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_login.Image = Global.MASTER.My.Resources.Resources.icons8_change_user_50
        Me.btn_login.Location = New System.Drawing.Point(1101, 20)
        Me.btn_login.Name = "btn_login"
        Me.btn_login.Size = New System.Drawing.Size(85, 85)
        Me.btn_login.TabIndex = 71
        Me.btn_login.Text = "Login"
        Me.btn_login.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btn_login.UseVisualStyleBackColor = True
        '
        'pb_status_mc
        '
        Me.pb_status_mc.Image = Global.MASTER.My.Resources.Resources.mark_ok
        Me.pb_status_mc.Location = New System.Drawing.Point(967, 20)
        Me.pb_status_mc.Name = "pb_status_mc"
        Me.pb_status_mc.Size = New System.Drawing.Size(85, 85)
        Me.pb_status_mc.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pb_status_mc.TabIndex = 64
        Me.pb_status_mc.TabStop = False
        '
        'pb_logo
        '
        Me.pb_logo.Image = Global.MASTER.My.Resources.Resources.logo_sanindo_tekno_batam
        Me.pb_logo.Location = New System.Drawing.Point(12, 20)
        Me.pb_logo.Name = "pb_logo"
        Me.pb_logo.Size = New System.Drawing.Size(250, 85)
        Me.pb_logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pb_logo.TabIndex = 63
        Me.pb_logo.TabStop = False
        '
        'pb_status_bar
        '
        Me.pb_status_bar.BackColor = System.Drawing.Color.LimeGreen
        Me.pb_status_bar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pb_status_bar.Location = New System.Drawing.Point(425, 20)
        Me.pb_status_bar.Name = "pb_status_bar"
        Me.pb_status_bar.Size = New System.Drawing.Size(500, 85)
        Me.pb_status_bar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pb_status_bar.TabIndex = 65
        Me.pb_status_bar.TabStop = False
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.DataGridView1)
        Me.GroupBox4.Location = New System.Drawing.Point(6, 6)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(1188, 358)
        Me.GroupBox4.TabIndex = 25
        Me.GroupBox4.TabStop = False
        '
        'LogForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1350, 729)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.lbl_date)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lbl_curr_time)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lbl_user)
        Me.Controls.Add(Me.btn_home)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btn_login)
        Me.Controls.Add(Me.pb_status_mc)
        Me.Controls.Add(Me.pb_logo)
        Me.Controls.Add(Me.pb_status_bar)
        Me.Name = "LogForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "LogForm"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox_Status.ResumeLayout(False)
        Me.GroupBox_Export.ResumeLayout(False)
        Me.GroupBox_Export.PerformLayout()
        Me.GroupBox_Filter.ResumeLayout(False)
        Me.GroupBox_Filter.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.pb_status_mc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pb_logo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pb_status_bar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents lbl_date As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents lbl_curr_time As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents lbl_user As Label
    Friend WithEvents btn_home As Button
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents DateTime As Timer
    Friend WithEvents btn_login As Button
    Friend WithEvents pb_status_mc As PictureBox
    Friend WithEvents pb_logo As PictureBox
    Friend WithEvents pb_status_bar As PictureBox
    Friend WithEvents GroupBox_Filter As GroupBox
    Friend WithEvents rbByREF As RadioButton
    Friend WithEvents rbBydate As RadioButton
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents tbSearchPO As TextBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents DateTimePickerEndDate As DateTimePicker
    Friend WithEvents DateTimePickerStartDate As DateTimePicker
    Friend WithEvents btn_search As Button
    Friend WithEvents GroupBox_Status As GroupBox
    Friend WithEvents RTB_Status As RichTextBox
    Friend WithEvents GroupBox_Export As GroupBox
    Friend WithEvents btn_fileLocation As Button
    Friend WithEvents ProgressBarExport As ProgressBar
    Friend WithEvents txtFileLocation As TextBox
    Friend WithEvents btn_export As Button
    Friend WithEvents GroupBox4 As GroupBox
End Class
