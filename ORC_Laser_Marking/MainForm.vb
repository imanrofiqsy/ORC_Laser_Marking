Imports System.ComponentModel
Imports System.Threading
Imports System.Data.SqlClient
Imports ControlBPM
Public Class MainForm
    Dim ThreadLoadingBar As Thread
    Dim ThreadModbus As Thread
    Dim ThreadProcess As Thread
    Dim Modbus = New Modbus
    Dim Database = New DatabaseConnection

    Dim fullPath As String = System.AppDomain.CurrentDomain.BaseDirectory
    Dim projectFolder As String = fullPath.Replace("\ORC_Laser_Marking\bin\Debug\", "").Replace("\ORC_Laser_Marking\bin\Release\", "")
    Dim iniPath As String = projectFolder + "\config\Config.INI"
    Private Sub initLoadingBar()
        ThreadLoadingBar = New Thread(New ThreadStart(AddressOf ProcessLoad))
        ThreadLoadingBar.Start()
    End Sub
    Private Sub ProcessLoad()
        Do
            LoadingForm.ShowDialog()
            Thread.Sleep(100)
        Loop
    End Sub
    Private Sub UpdateLoadingBar(value As Integer, msg As String)
        LoadingBarValue = value
        LoadingBarMessage = msg
    End Sub
    Private Sub killLoadingBar()
        ThreadLoadingBar.Abort()
    End Sub
    Private Sub GetUserLevel()
        If UserLevel = 1 Then
            lbl_user.Text = "ADM"
            btn_setting.Enabled = True
            btn_manual.Enabled = True
            btn_references.Enabled = True
            btn_alarm.Enabled = True
            btn_log.Enabled = True
        ElseIf UserLevel = 2 Then
            lbl_user.Text = "ENG"
            btn_setting.Enabled = True
            btn_manual.Enabled = True
            btn_references.Enabled = True
            btn_alarm.Enabled = True
            btn_log.Enabled = True
        ElseIf UserLevel = 3 Then
            lbl_user.Text = "OPE"
            btn_setting.Enabled = False
            btn_manual.Enabled = False
            btn_references.Enabled = False
            btn_alarm.Enabled = False
            btn_log.Enabled = False
        ElseIf UserLevel = 4 Then
            lbl_user.Text = "QUA"
            btn_setting.Enabled = False
            btn_manual.Enabled = False
            btn_references.Enabled = False
            btn_alarm.Enabled = False
            btn_log.Enabled = False
        End If
    End Sub
    Private Sub DateTime_Tick(sender As Object, e As EventArgs) Handles DateTime.Tick
        lbl_curr_time.Text = Date.Now.ToString("dd-MM-yyyy")
        lbl_curr_time.Text = Date.Now.ToString("hh:mm:ss")
    End Sub

    Private Sub btn_manual_Click(sender As Object, e As EventArgs) Handles btn_manual.Click
        Hide()
        ManualForm.Show()
    End Sub

    Private Sub btn_references_Click(sender As Object, e As EventArgs) Handles btn_references.Click
        Hide()
        ReferencesForm.Show()
    End Sub

    Private Sub btn_alarm_Click(sender As Object, e As EventArgs) Handles btn_alarm.Click
        Hide()
        AlarmForm.Show()
    End Sub

    Private Sub btn_log_Click(sender As Object, e As EventArgs) Handles btn_log.Click
        Hide()
        LogForm.Show()
    End Sub

    Private Sub btn_setting_Click(sender As Object, e As EventArgs) Handles btn_setting.Click
        Hide()
        SettingForm.Show()
    End Sub

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        Hide()
        LoginForm.ShowDialog()
        initLoadingBar()

        Try
            With Config
                UpdateLoadingBar(20, "Establishing connection to PLC...")
                Modbus.OpenPort("127.0.0.1", "502")
                Thread.Sleep(500)

                UpdateLoadingBar(40, "Loading?? 2...")
                .dbHostName = ReadINI(iniPath, "DATABASE", "Hostname")
                .dbUsername = ReadINI(iniPath, "DATABASE", "Username")
                .dbPassword = ReadINI(iniPath, "DATABASE", "Password")
                .dbDatabase = ReadINI(iniPath, "DATABASE", "Database")
                Thread.Sleep(500)

                UpdateLoadingBar(60, "Loading?? 3...")
                Thread.Sleep(500)

                UpdateLoadingBar(80, "Creating Multithreading...")
                ThreadModbus = New Thread(AddressOf MainModbus)
                ThreadModbus.Start()
                ThreadProcess = New Thread(AddressOf MainProcess)
                Thread.Sleep(500)

                UpdateLoadingBar(100, "Loading?? 6...")
                Thread.Sleep(500)
            End With
        Catch ex As Exception
            UpdateLoadingBar(LoadingBarValue, "Error.. " + ex.Message + ", App is Clossing...")
            Thread.Sleep(2000)
            End
        End Try

        killLoadingBar()
        Cursor = Cursors.Default
        GetUserLevel()

        SequenceIndex = MainSequence.ScanRef
    End Sub
    Private Sub MainProcess()
        Do
            Select Case SequenceIndex
                Case MainSequence.ScanRef
                    If txt_ref.Text <> "" Then
                        ' program check reference
                        Call Database.Connect()
                        Dim sc As New SqlCommand("SELECT * FROM tb_References WHERE [References]='" & txt_ref.Text & "'", Database.Connection)
                        Dim rd As SqlDataReader = sc.ExecuteReader()

                        If rd.HasRows Then
                            ' kirim string ke plc
                            ' trigger load data
                            SequenceIndex = MainSequence.ScanOP
                        Else
                            lbl_op_ins.Text = "Invalid References..."
                            txt_ref.Text = ""
                        End If

                        rd.Close()
                    Else
                        lbl_op_ins.Text = "Please Scan Product References..."
                    End If

                Case MainSequence.ScanOP
                    If txt_ope_id.Text <> "" Then
                        SequenceIndex = MainSequence.ScanPO
                    Else
                        lbl_op_ins.Text = "Please Scan Operator ID..."
                    End If

                Case MainSequence.ScanPO
                    If txt_po_num.Text <> "" Then
                        ' program add datalog
                        ' load data finish 
                        SequenceIndex = MainSequence.GetData
                    Else
                        lbl_op_ins.Text = "Please Scan PO Number..."
                    End If
            End Select
            Thread.Sleep(150)
        Loop
    End Sub
    Private Sub MainModbus()
        Do
            If Not PlcTrigger Then
                PlcReading()
            Else
                PlcWriting()
                Thread.Sleep(100)
                PlcTrigger = False
            End If
            Thread.Sleep(150)
        Loop
    End Sub
    Private Sub PlcWriting()
        With SetCylinder
            Modbus.WriteInteger(1101, .V101)
            Modbus.WriteInteger(1110, .TurnTable)
        End With

    End Sub
    Private Sub PlcReading()
        With MachineStatus
            .PlcReady = Modbus.ReadInteger(10)
            .Mode = Modbus.ReadInteger(1)
            .State = Modbus.ReadInteger(2)
            .LoadDataBusy = Modbus.ReadBit(11, 1)
            .LoadDataFinish = Modbus.ReadBit(11, 2)
            .LoadDataFail = Modbus.ReadBit(11, 3)
            .MachineInitialized = Modbus.ReadBit(12, 0)
            .EmptyBusy = Modbus.ReadBit(9, 1)
            .EmptyFinish = Modbus.ReadBit(10, 1)
        End With

        With GetCylinder
            .V101 = Modbus.ReadInteger(6101)
            .V102 = Modbus.ReadInteger(6102)
        End With
    End Sub
    Private Sub btn_login_Click(sender As Object, e As EventArgs) Handles btn_login.Click
        Hide()
        LoginForm.ShowDialog()
        GetUserLevel()
    End Sub

    Private Sub MainForm_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        If ThreadModbus.IsAlive Then
            ThreadModbus.Abort()
        End If
    End Sub
End Class
