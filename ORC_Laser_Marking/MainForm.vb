Imports System.ComponentModel
Imports System.Threading
Imports System.Data.SqlClient
Imports ControlBPM
Imports System.IO
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
        LoginForm.ShowDialog()
        Hide()
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
    Private Sub SaveDataLog()
        StartDate.Value = Date.Today
        EndDate.Value = Date.Today
        Dim _start As String = StartDate.Value.ToString("yyyy-MM-dd 00:00:00")
        Dim _end As String = EndDate.Value.ToString("yyyy-MM-dd 23:59:59")
        Try
            Call Database.Connect()
            Dim sc As New SqlCommand("SELECT * FROM tb_datalog WHERE [Date Time] BETWEEN '" + _start + "' AND '" + _end + "'", Database.Connection)
            Dim adapter As New SqlDataAdapter(sc)
            Dim ds As New DataSet

            adapter.Fill(ds)
            dgv_temp.DataSource = ds.Tables(0)
            dgv_temp.ClearSelection()

            Dim logFileName = $"Log_{Date.Now.ToString("yyyyMMdd")}.csv"
            Dim strFile As String = projectFolder & "\log\" & logFileName

            If dgv_temp.Rows.Count > 0 Then
                Dim value As String = ""
                Dim dr As New DataGridViewRow()

                Dim swOut As StreamWriter = File.CreateText(strFile)

                'write header rows to csv
                For i As Integer = 0 To dgv_temp.Columns.Count - 1
                    If i > 0 Then
                        swOut.Write(";")
                    End If
                    swOut.Write(dgv_temp.Columns(i).HeaderText)
                Next

                swOut.WriteLine()

                'write DataGridView rows to csv
                For j As Integer = 0 To dgv_temp.Rows.Count - 1
                    If j > 0 Then
                        swOut.WriteLine()
                    End If

                    dr = dgv_temp.Rows(j)

                    For i As Integer = 0 To dgv_temp.Columns.Count - 1
                        If i > 0 Then
                            swOut.Write(";")
                        End If
                        If IsDBNull(dr.Cells(i).Value) Then
                            value = "0"
                        Else
                            value = CStr(dr.Cells(i).Value)
                        End If
                        swOut.Write(value)
                    Next
                Next
                swOut.Close()
            End If
        Catch ex As Exception
            Console.WriteLine("Error Save Datalog" + ex.Message)
        End Try
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
                    WriteINI(iniPath, "STATUS", "CountProduct", Config.CountProduct)
                    ' data aquisition from instrument
                    Dim LeftHeidenResult As String = "99.9"
                    Dim RightHeidenResult As String = "99.9"
                    ' end data aquisition from instrument
                    ' update text box
                    Invoke(Sub()
                               Select Case MachineStatus.CavityST3
                                   Case 1
                                       lbl_st3_left_measure.Text = LeftHeidenResult
                                       lbl_st3_right_measure.Text = RightHeidenResult
                                       lbl_st5_left_camera.Text = ""
                                       lbl_st5_right_camera.Text = ""
                                       lbl_status_l.Text = ""
                                       lbl_status_r.Text = ""
                                   Case 2
                                       lbl_st3_left_measure_1.Text = LeftHeidenResult
                                       lbl_st3_right_measure_1.Text = RightHeidenResult
                                       lbl_st5_left_camera_1.Text = ""
                                       lbl_st5_right_camera_1.Text = ""
                                       lbl_status_l_1.Text = ""
                                       lbl_status_r_1.Text = ""
                                   Case 3
                                       lbl_st3_left_measure_2.Text = LeftHeidenResult
                                       lbl_st3_right_measure_2.Text = RightHeidenResult
                                       lbl_st5_left_camera_2.Text = ""
                                       lbl_st5_right_camera_2.Text = ""
                                       lbl_status_l_2.Text = ""
                                       lbl_status_r_2.Text = ""
                                   Case 4
                                       lbl_st3_left_measure_3.Text = LeftHeidenResult
                                       lbl_st3_right_measure_3.Text = RightHeidenResult
                                       lbl_st5_left_camera_3.Text = ""
                                       lbl_st5_right_camera_3.Text = ""
                                       lbl_status_l_3.Text = ""
                                       lbl_status_r_3.Text = ""
                                   Case 5
                                       lbl_st3_left_measure_4.Text = LeftHeidenResult
                                       lbl_st3_right_measure_4.Text = RightHeidenResult
                                       lbl_st5_left_camera_4.Text = ""
                                       lbl_st5_right_camera_4.Text = ""
                                       lbl_status_l_4.Text = ""
                                       lbl_status_r_4.Text = ""
                                   Case 6
                                       lbl_st3_left_measure_5.Text = LeftHeidenResult
                                       lbl_st3_right_measure_5.Text = RightHeidenResult
                                       lbl_st5_left_camera_5.Text = ""
                                       lbl_st5_right_camera_5.Text = ""
                                       lbl_status_l_5.Text = ""
                                       lbl_status_r_5.Text = ""
                               End Select
                           End Sub)
                    ' end update text box
                    ' save database
                    Call Database.Connect()
                    Dim sc As New SqlCommand("INSERT INTO tb_datalog ([ID], [Date Time], [References], [Operator], [Product Order], [ST3 Measurement Left], [ST3 Measurement Right]) VALUES(" & CountST3 & ", '" & Date.Now.ToString("yyyy-MM-dd HH:mm:ss") & "', '" & ProductReferences.References & "', '" & txt_ope_id.Text & "', '" & txt_po_num.Text & "', '" & LeftHeidenResult.Replace(".", ",") & "', '" & LeftHeidenResult.Replace(".", ",") & "')", Database.Connection)
                    Dim adapter As New SqlDataAdapter(sc)
                    adapter.SelectCommand.ExecuteNonQuery()
                    ' end save database
                    ' save datalog file
                    Invoke(Sub()
                               SaveDataLog()
                           End Sub)
                    ' end save datalog file
                    ' send data to modbus
                    ProductResult.MeasurementLeft = LeftHeidenResult.Replace(".", ",")
                    ProductResult.MeasurementRight = RightHeidenResult.Replace(".", ",")
                    PlcTrigger.HeidenResult = True
                    ' end send data to modbus
                    ' trigger finish save data
                    .MW11100_ = Modbus.WriteBit(.MW11100_, 1, 1)
                    .MW11100_ = Modbus.WriteBit(.MW11100_, 0, 0)
                    PlcTrigger.MW11100_ = True
                    PlcWriteState = True
                    'end trigger finish save data
                ElseIf .MW11100_2 = 1 Then
                    ' data aquisition from plc
                    Dim LeftMeasureResult As Integer = ProductResult.MeasurementLeftStatus
                    Dim RightMeasureResult As Integer = ProductResult.MeasurementRightStatus
                    ' end data aquisition from plc
                    ' update text box
                    Invoke(Sub()
                               Select Case MachineStatus.CavityST3
                                   Case 1
                                       If LeftMeasureResult = 1 Then
                                           lbl_st3_left_measure.BackColor = Color.Green
                                       ElseIf LeftMeasureResult = 2 Then
                                           lbl_st3_left_measure.BackColor = Color.Red
                                       End If

                                       If RightMeasureResult = 1 Then
                                           lbl_st3_right_measure.BackColor = Color.Green
                                       ElseIf RightMeasureResult = 2 Then
                                           lbl_st3_right_measure.BackColor = Color.Red
                                       End If
                                   Case 2
                                       If LeftMeasureResult = 1 Then
                                           lbl_st3_left_measure_1.BackColor = Color.Green
                                       ElseIf LeftMeasureResult = 2 Then
                                           lbl_st3_left_measure_1.BackColor = Color.Red
                                       End If

                                       If RightMeasureResult = 1 Then
                                           lbl_st3_right_measure_1.BackColor = Color.Green
                                       ElseIf RightMeasureResult = 2 Then
                                           lbl_st3_right_measure_1.BackColor = Color.Red
                                       End If
                                   Case 3
                                       If LeftMeasureResult = 1 Then
                                           lbl_st3_left_measure_2.BackColor = Color.Green
                                       ElseIf LeftMeasureResult = 2 Then
                                           lbl_st3_left_measure_2.BackColor = Color.Red
                                       End If

                                       If RightMeasureResult = 1 Then
                                           lbl_st3_right_measure_2.BackColor = Color.Green
                                       ElseIf RightMeasureResult = 2 Then
                                           lbl_st3_right_measure_2.BackColor = Color.Red
                                       End If
                                   Case 4
                                       If LeftMeasureResult = 1 Then
                                           lbl_st3_left_measure_3.BackColor = Color.Green
                                       ElseIf LeftMeasureResult = 2 Then
                                           lbl_st3_left_measure_3.BackColor = Color.Red
                                       End If

                                       If RightMeasureResult = 1 Then
                                           lbl_st3_right_measure_3.BackColor = Color.Green
                                       ElseIf RightMeasureResult = 2 Then
                                           lbl_st3_right_measure_3.BackColor = Color.Red
                                       End If
                                   Case 5
                                       If LeftMeasureResult = 1 Then
                                           lbl_st3_left_measure_4.BackColor = Color.Green
                                       ElseIf LeftMeasureResult = 2 Then
                                           lbl_st3_left_measure_4.BackColor = Color.Red
                                       End If

                                       If RightMeasureResult = 1 Then
                                           lbl_st3_right_measure_4.BackColor = Color.Green
                                       ElseIf RightMeasureResult = 2 Then
                                           lbl_st3_right_measure_4.BackColor = Color.Red
                                       End If
                                   Case 6
                                       If LeftMeasureResult = 1 Then
                                           lbl_st3_left_measure_5.BackColor = Color.Green
                                       ElseIf LeftMeasureResult = 2 Then
                                           lbl_st3_left_measure_5.BackColor = Color.Red
                                       End If

                                       If RightMeasureResult = 1 Then
                                           lbl_st3_right_measure_5.BackColor = Color.Green
                                       ElseIf RightMeasureResult = 2 Then
                                           lbl_st3_right_measure_5.BackColor = Color.Red
                                       End If
                               End Select
                           End Sub)
                    ' end update text box
                    ' save database
                    Call Database.Connect()
                    Dim sc As New SqlCommand("UPDATE tb_datalog SET [ST3 Measurement Left Status] = '" & LeftMeasureResult & "', [ST3 Measurement Right Status] = '" & RightMeasureResult & "' WHERE [ID] = " & CountST3 & "", Database.Connection)
                    Dim adapter As New SqlDataAdapter(sc)
                    adapter.SelectCommand.ExecuteNonQuery()
                    ' end save database
                    ' save datalog file
                    Invoke(Sub()
                               SaveDataLog()
                           End Sub)
                    ' end save datalog file
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
                    Invoke(Sub()
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

                                           lbl_actuation_mode.Text = .PunchingMode
                                           lbl_level_distance.Text = .LevelDistance
                                           lbl_tolerance.Text = .LevelTolerance
                                           lbl_oring_check.Text = .OringCheck
                                           lbl_festo_distance_left.Text = .FestoLeftDistance
                                           lbl_festo_distance_right.Text = .FestoRightDistance
                                           lbl_laser_template.Text = .LaserTemplateAddress
                                           lbl_camera_program.Text = .CameraProgram

                                           ' kirim database ke plc
                                           PlcTrigger.References = True

                                           ' kirim string ke plc
                                           sendLaserString(.References)

                                           ' trigger load data
                                           MachineStatus.TrigLoadData = Modbus.WriteBit(MachineStatus.TrigLoadData, 0, 1)
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

                           End Sub)
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
                Modbus.WriteInteger(11, .TrigLoadData)
            End If
        End With

        With ProductReferences
            If PlcTrigger.References Then
                PlcTrigger.References = False
                Modbus.WriteInteger(10000, .PunchingMode)
                Console.WriteLine(Single.Parse(.LevelDistance.ToString.Replace(".", ",")))
                Modbus.WriteFloat(10002, Single.Parse(.LevelDistance.ToString.Replace(".", ",")))
                Modbus.WriteFloat(10004, Single.Parse(.LevelTolerance.ToString.Replace(".", ",")))
                Modbus.WriteInteger(10006, .OringCheck)
                Modbus.WriteDoubleInteger(10008, .FestoLeftDistance)
                Modbus.WriteDoubleInteger(10010, .FestoRightDistance)
                Modbus.WriteInteger(10012, .FestoLeftSpeed)
                Modbus.WriteInteger(10014, .FestoRightSpeed)
                Modbus.WriteInteger(10030, .LaserTemplateAddress)
                Modbus.WriteInteger(10032, .CameraProgram)
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

        With ProductResult
            If PlcTrigger.HeidenResult Then
                PlcTrigger.HeidenResult = False
                Modbus.WriteFloat(12000, Single.Parse(.MeasurementLeft))
                Modbus.WriteFloat(12002, Single.Parse(.MeasurementRight))
            End If
        End With
    End Sub
    Private Sub PlcReading()
        With MachineStatus
            .PlcReady = Modbus.ReadInteger(10)
            .Mode = Modbus.ReadInteger(1)
            .State = Modbus.ReadInteger(2)

            .TrigLoadData = Modbus.ReadInteger(11)
            .LoadDataBusy = Modbus.ReadBit(.TrigLoadData, 1)
            .LoadDataFinish = Modbus.ReadBit(.TrigLoadData, 2)
            .LoadDataFail = Modbus.ReadBit(.TrigLoadData, 3)

            .MachineInitialized = Modbus.ReadInteger(11)

            .EmptyRequest = Modbus.ReadInteger(9)
            .EmptyBusy = Modbus.ReadBit(.EmptyRequest, 1)
            .EmptyFinish = Modbus.ReadBit(.EmptyRequest, 2)

            .CavityST3 = Modbus.ReadInteger(3952)
            .CavityST5 = Modbus.ReadInteger(5952)

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
            .MeasurementLeftStatus = Modbus.ReadInteger(12004)
            .MeasurementRightStatus = Modbus.ReadInteger(12006)
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

    Private Sub btn_clear_Click(sender As Object, e As EventArgs) Handles btn_clear.Click
        txt_ref.Text = ""
        txt_ope_id.Text = ""
        txt_po_num.Text = ""
        txt_qty.Text = ""
        SequenceIndex = MainSequence.ScanRef
    End Sub
End Class
