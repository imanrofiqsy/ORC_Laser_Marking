Imports System.ComponentModel
Imports System.Threading
Imports System.Data.SqlClient
Imports ControlBPM
Public Class MainForm
    Dim ThreadLoadingBar As Thread
    Dim ThreadModbus As Thread
    Dim ThreadLoadData As Thread
    Dim ThreadST3 As Thread
    Dim ThreadST5 As Thread
    Dim ThreadProductResult As Thread
    Dim Modbus = New Modbus
    Dim Database = New DatabaseConnection

    Dim fullPath As String = System.AppDomain.CurrentDomain.BaseDirectory
    Dim projectFolder As String = fullPath.Replace("\ORC_Laser_Marking\bin\Debug\", "").Replace("\ORC_Laser_Marking\bin\Release\", "")
    Dim iniPath As String = projectFolder + "\config\Config.INI"

    Dim CountST3 As Integer = 0
    Dim CountSt5 As Integer = 0
    Dim CountProductResult As Integer = 0
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
        With MachineStatus
            If .State = 1 Then
                Label2.Text = "RUNNING"
            ElseIf .State = 2 Then
                Label2.Text = "STOPPING"
            ElseIf .State = 3 Then
                Label2.Text = "INITIALIZED"
            ElseIf .State = 4 Then
                Label2.Text = "EMPTYING"
            ElseIf .State = 5 Then
                Label2.Text = "EMERGENCY"
            End If

            If .Mode = 1 Then
                Label1.Text = "AUTO"
            ElseIf .Mode = 2 Then
                Label1.Text = "MANUAL"
            End If
        End With
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
                ThreadLoadData = New Thread(AddressOf MainLoad)
                ThreadLoadData.Start()
                ThreadST3 = New Thread(AddressOf MainST3)
                ThreadST3.Start()
                ThreadST5 = New Thread(AddressOf MainST5)
                ThreadST5.Start()
                ThreadProductResult = New Thread(AddressOf MainProductResult)
                ThreadProductResult.Start()
                Thread.Sleep(500)

                UpdateLoadingBar(100, "Loading?? 6...")
                .CountProduct = ReadINI(iniPath, "STATUS", "CountProduct")
                CountST3 = .CountProduct
                CountSt5 = .CountProduct
                CountProductResult = .CountProduct
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

        MachineStatus.App = Modbus.WriteBit(MachineStatus.App, 0, 1)
        PlcTrigger.App = True
        PlcWriteState = True
        ind_software_open.BackColor = Color.Lime
        SequenceIndex = MainSequence.ScanRef
    End Sub
    Private Sub MainProductResult()
        Do
            With PlcSave
                If .MW11100_10 = 1 Then
                    ' update count
                    CountProductResult += 1
                    ' update text box
                    Invoke(Sub()

                           End Sub)
                    ' end update text box
                    ' data aquisition from plc
                    Dim LeftProdResult As Integer = ProductResult.ProductLeft
                    Dim RightProdResult As Integer = ProductResult.ProductRight
                    ' end data aquisition from plc
                    ' save database

                    ' end save database
                    ' trigger finish save data
                    .MW11100_ = Modbus.WriteBit(.MW11100_, 11, 1)
                    .MW11100_ = Modbus.WriteBit(.MW11100_, 10, 0)
                    PlcTrigger.MW11100_ = True
                    PlcWriteState = True
                    'end trigger finish save data
                End If
            End With
            Thread.Sleep(150)
        Loop
    End Sub
    Private Sub MainST5()
        Do
            With PlcSave
                If .MW11100_6 = 1 Then
                    ' update count
                    CountSt5 += 1
                    ' update text box
                    Invoke(Sub()

                           End Sub)
                    ' end update text box
                    ' data aquisition from plc
                    Dim LeftCameraResult As Integer = ProductResult.CameraLeft
                    Dim RightCameraResult As Integer = ProductResult.CameraRight
                    ' end data aquisition from plc
                    ' save database

                    ' end save database
                    ' trigger finish save data
                    .MW11100_ = Modbus.WriteBit(.MW11100_, 7, 1)
                    .MW11100_ = Modbus.WriteBit(.MW11100_, 6, 0)
                    PlcTrigger.MW11100_ = True
                    PlcWriteState = True
                    'end trigger finish save data
                End If
            End With
            Thread.Sleep(150)
        Loop
    End Sub
    Private Sub MainST3()
        Do
            With PlcSave
                If .MW11100_0 = 1 Then
                    ' update count
                    CountST3 += 1
                    ' update config
                    Config.CountProduct = CountST3
                    WriteINI(iniPath, "[STATUS]", "CountProduct", Config.CountProduct)
                    ' update text box
                    Invoke(Sub()

                           End Sub)
                    ' end update text box
                    ' data aquisition from instrument
                    Dim LeftHeidenResult As String = "999"
                    Dim RightHeidenResult As String = "999"
                    ' end data aquisition from instrument
                    ' save database

                    ' end save database
                    ' send data to modbus

                    ' end send data to modbus
                    ' trigger finish save data
                    .MW11100_ = Modbus.WriteBit(.MW11100_, 1, 1)
                    .MW11100_ = Modbus.WriteBit(.MW11100_, 0, 0)
                    PlcTrigger.MW11100_ = True
                    PlcWriteState = True
                    'end trigger finish save data
                ElseIf .MW11100_2 = 1 Then
                    ' update text box
                    Invoke(Sub()

                           End Sub)
                    ' end update text box
                    ' data aquisition from plc
                    Dim LeftMeasureResult As Integer = ProductResult.MeasurementLeft
                    Dim RightMeasureResult As Integer = ProductResult.MeasurementRight
                    ' end data aquisition from plc
                    ' save database

                    ' end save database
                    ' trigger finish save data
                    .MW11100_ = Modbus.WriteBit(.MW11100_, 3, 1)
                    .MW11100_ = Modbus.WriteBit(.MW11100_, 2, 0)
                    PlcTrigger.MW11100_ = True
                    PlcWriteState = True
                    'end trigger finish save data
                End If
            End With
            Thread.Sleep(150)
        Loop
    End Sub
    Private Sub sendLaserString(data As String)
        With ProductReferences
            Dim current_len As Integer
            .LaserStringData = data
            current_len = .LaserStringData.Length
            '' fix string to 20 char
            For i As Integer = current_len To 19
                .LaserStringData = .LaserStringData & " "
            Next
            LaserTrigger = True
        End With
    End Sub
    Private Sub MainLoad()
        Do
            With MachineStatus
                If .LoadDataBusy Then
                    ind_load_data_busy.BackColor = Color.Lime
                Else
                    ind_load_data_busy.BackColor = Color.Red
                End If

                If .LoadDataFail Then
                    ind_load_data_fail.BackColor = Color.Lime
                Else
                    ind_load_data_fail.BackColor = Color.Red
                End If

                If .LoadDataFinish Then
                    ind_load_data_finish.BackColor = Color.Lime
                Else
                    ind_load_data_finish.BackColor = Color.Red
                End If

                Invoke(Sub()
                           lbl_pass.Text = .OutputPass
                           lbl_fail.Text = .OutputFail
                           lbl_fpy.Text = Math.Round(Val(lbl_pass.Text) / (Val(lbl_pass.Text) + Val(lbl_fail.Text)), 2) * 100

                           If Double.IsNaN(Val(lbl_fpy.Text)) Then
                               lbl_fpy.Text = "0 %"
                           Else
                               lbl_fpy.Text = lbl_fpy.Text + " %"
                           End If
                       End Sub)
            End With
            Select Case SequenceIndex
                Case MainSequence.ScanRef
                    If txt_ref.Text <> "" Then
                        ' program check reference
                        Call Database.Connect()
                        Dim Query As String = "SELECT * FROM tb_References WHERE [References]='" & txt_ref.Text & "'"
                        Dim sc As New SqlCommand(Query, Database.Connection)
                        Dim rd As SqlDataReader = sc.ExecuteReader()
                        rd.Read()

                        If rd.HasRows Then
                            With ProductReferences
                                .References = rd.Item("References")
                                .PunchingMode = rd.Item("Punching Mode")
                                .LevelDistance = rd.Item("Level Distance")
                                .LevelTolerance = rd.Item("Level Tolerance")
                                .OringCheck = rd.Item("Oring Check")
                                .FestoLeftDistance = rd.Item("Festo Left Distance")
                                .FestoRightDistance = rd.Item("Festo Right Distance")
                                .FestoLeftSpeed = rd.Item("Festo Left Speed")
                                .FestoRightSpeed = rd.Item("Festo Right Speed")
                                .LaserTemplateAddress = rd.Item("Laser Template Address")
                                .CameraProgram = rd.Item("Camera Program")

                                ' kirim string ke plc
                                sendLaserString(.References)

                                ' trigger load data
                                MachineStatus.TrigLoadData = 1
                                PlcTrigger.TrigLoadData = True
                                PlcWriteState = True
                            End With
                            SequenceIndex = MainSequence.ScanOP
                        Else
                            Invoke(Sub()
                                       lbl_op_ins.Text = "Invalid References..."
                                       txt_ref.Text = ""
                                   End Sub)
                        End If

                        rd.Close()
                    Else
                        Invoke(Sub()
                                   lbl_op_ins.Text = "Please Scan Product References..."
                               End Sub)
                    End If

                Case MainSequence.ScanOP
                    If txt_ope_id.Text <> "" Then
                        SequenceIndex = MainSequence.ScanPO
                    Else
                        Invoke(Sub()
                                   lbl_op_ins.Text = "Please Scan Operator ID..."
                               End Sub)
                    End If

                Case MainSequence.ScanPO
                    If txt_po_num.Text <> "" Then
                        SequenceIndex = MainSequence.ScanQty
                    Else
                        Invoke(Sub()
                                   lbl_op_ins.Text = "Please Scan PO Number..."
                               End Sub)
                    End If

                Case MainSequence.ScanQty
                    If txt_qty.Text <> "" Then
                        ' program add datalog
                        ' load data finish 
                        If MachineStatus.LoadDataFinish Then
                            Invoke(Sub()
                                       lbl_op_ins.Text = "Load data finish, please start process..."
                                   End Sub)
                            SequenceIndex = MainSequence.GetData
                        Else
                            If MachineStatus.LoadDataFail Then
                                Invoke(Sub()
                                           lbl_op_ins.Text = "Load data fail please check References..."
                                       End Sub)
                            Else
                                Invoke(Sub()
                                           lbl_op_ins.Text = "Load data in proggress..."
                                       End Sub)
                            End If
                        End If
                    Else
                        Invoke(Sub()
                                   lbl_op_ins.Text = "Please Scan Qty Number..."
                               End Sub)
                    End If
            End Select
            Thread.Sleep(150)
        Loop
    End Sub
    Private Sub MainModbus()
        Do
            If Not PlcWriteState Then
                PlcReading()
            Else
                PlcWriting()
                PlcWriteState = False
            End If
            Thread.Sleep(50)
        Loop
    End Sub
    Private Sub PlcWriting()
        With SetCylinder
            If PlcTrigger.V101 Then
                PlcTrigger.V101 = False
                Modbus.WriteInteger(1101, .V101)
            End If
            If PlcTrigger.TurnTable Then
                PlcTrigger.TurnTable = False
                Modbus.WriteInteger(1110, .TurnTable)
            End If
        End With

        With MachineStatus
            If PlcTrigger.App Then
                PlcTrigger.App = False
                Modbus.WriteInteger(6, .App)
            End If
            If PlcTrigger.TrigLoadData Then
                PlcTrigger.TrigLoadData = False
                Modbus.WriteBit(11, 0, .TrigLoadData)
            End If
        End With

        If LaserTrigger Then
            LaserTrigger = False
            With ProductReferences
                '' send 20 char string
                For index As Integer = 0 To 19
                    .LaserCharData = .LaserStringData.Chars(index)
                    ''Debug.Write(index & " ")
                    ''Debug.WriteLine(char_data & " ")
                    Modbus.WriteInteger(10100 + index, Convert.ToInt32(.LaserCharData))
                Next
            End With
        End If

        With PlcSave
            If PlcTrigger.MW11100_ Then
                PlcTrigger.MW11100_ = False
                Modbus.WriteInteger(11100, .MW11100_)
            End If
        End With
    End Sub
    Private Sub PlcReading()
        With MachineStatus
            .PlcReady = Modbus.ReadInteger(10)
            .Mode = Modbus.ReadInteger(1)
            .State = Modbus.ReadInteger(2)

            Dim TempSaveLoadData As Integer = Modbus.ReadInteger(11)
            .LoadDataBusy = Modbus.ReadBit(TempSaveLoadData, 1)
            .LoadDataFinish = Modbus.ReadBit(TempSaveLoadData, 2)
            .LoadDataFail = Modbus.ReadBit(TempSaveLoadData, 3)

            .MachineInitialized = Modbus.ReadInteger(11)

            Dim TempSaveEmpty As Integer = Modbus.ReadInteger(9)
            .EmptyBusy = Modbus.ReadBit(TempSaveEmpty, 1)
            .EmptyFinish = Modbus.ReadBit(TempSaveEmpty, 2)
            .OutputFail = Modbus.ReadInteger(4)
            .OutputPass = Modbus.ReadInteger(3)
        End With

        With GetCylinder
            .V101 = Modbus.ReadInteger(6101)
            .V102 = Modbus.ReadInteger(6102)
        End With

        With PlcSave
            .MW11100_ = Modbus.ReadInteger(11100)
            .MW11100_0 = Modbus.ReadBit(.MW11100_, 0)
            .MW11100_2 = Modbus.ReadBit(.MW11100_, 2)
            .MW11100_6 = Modbus.ReadBit(.MW11100_, 6)
            .MW11100_10 = Modbus.ReadBit(.MW11100_, 10)
        End With

        With ProductResult
            .MeasurementLeft = Modbus.ReadInteger(12004)
            .MeasurementRight = Modbus.ReadInteger(12006)
            .CameraLeft = Modbus.ReadInteger(12008)
            .CameraRight = Modbus.ReadInteger(12010)
            .ProductLeft = Modbus.ReadInteger(12012)
            .ProductRight = Modbus.ReadInteger(12013)
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

    Private Sub btn_run_Click(sender As Object, e As EventArgs) Handles btn_run.Click
        With MachineStatus
            If Not .LoadDataFinish = 1 Then
                Exit Sub
            End If

            If txt_ref.Text = "" And txt_ope_id.Text = "" And txt_po_num.Text = "" Then
                Exit Sub
            End If

            If .LoadDataFinish Then
                .App = Modbus.WriteBit(.App, 1, 1)
                .App = Modbus.WriteBit(.App, 2, 0)
                PlcTrigger.App = True
                PlcWriteState = True
                btn_run.Enabled = False
                btn_stop.Enabled = True
                ind_software_run.BackColor = Color.Lime
                ind_software_stop.BackColor = Color.Red
            End If
        End With
    End Sub

    Private Sub btn_stop_Click(sender As Object, e As EventArgs) Handles btn_stop.Click
        With MachineStatus
            .App = Modbus.WriteBit(.App, 1, 0)
            .App = Modbus.WriteBit(.App, 2, 1)
            PlcTrigger.App = True
            PlcWriteState = True
            btn_stop.Enabled = False
            btn_run.Enabled = True
            ind_software_run.BackColor = Color.Red
            ind_software_stop.BackColor = Color.Lime
        End With
    End Sub
End Class
