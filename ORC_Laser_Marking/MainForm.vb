Imports System.ComponentModel
Imports System.Threading
Imports System.Data.SqlClient
Imports ControlBPM
Imports System.IO
Public Class MainForm
    Dim ThreadLoadingBar As Thread
    Dim ThreadModbus As Thread
    Dim ThreadLoadData As Thread
    Dim ThreadST1 As Thread
    Dim ThreadST3 As Thread
    Dim ThreadST5 As Thread
    Dim ThreadST6 As Thread
    Dim ThreadAlarm As Thread
    Dim Modbus = New Modbus
    Dim Database = New DatabaseConnection

    Dim fullPath As String = System.AppDomain.CurrentDomain.BaseDirectory
    Dim projectFolder As String = fullPath.Replace("\ORC_Laser_Marking\bin\Debug\", "").Replace("\ORC_Laser_Marking\bin\Release\", "")
    Dim iniPath As String = projectFolder + "\config\Config.INI"

    Dim CountST3 As Integer = 0
    Dim CountST5 As Integer = 0
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
        lbl_date.Text = Date.Now.ToString("dd-MM-yyyy")
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
                .IP = ReadINI(iniPath, "PLC", "IP")
                .Port = ReadINI(iniPath, "PLC", "Port")
                Modbus.OpenPort(.IP, .Port)
                Thread.Sleep(500)

                UpdateLoadingBar(40, "Loading?? 2...")
                .dbHostName = ReadINI(iniPath, "DATABASE", "Hostname")
                .dbUsername = ReadINI(iniPath, "DATABASE", "Username")
                .dbPassword = ReadINI(iniPath, "DATABASE", "Password")
                .dbDatabase = ReadINI(iniPath, "DATABASE", "Database")
                Thread.Sleep(500)
                Heiden.Open()
                Hain.Open()
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
                ThreadST6 = New Thread(AddressOf MainST6)
                ThreadST6.Start()
                ThreadAlarm = New Thread(AddressOf MainAlarm)
                ThreadAlarm.Start()
                Thread.Sleep(500)

                UpdateLoadingBar(100, "Loading App...")
                .CountProduct = ReadINI(iniPath, "STATUS", "CountProduct")
                CountST3 = .CountProduct
                CountST5 = .CountProduct
                CountProductResult = .CountProduct
                Thread.Sleep(500)
            End With
        Catch ex As Exception
            UpdateLoadingBar(LoadingBarValue, "Error.. " + ex.Message + ", App is Closing...")
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
    Private Sub MainAlarm()
        Do
            With MachineAlarm
                If .DoorLock1 Then
                    AlarmMessage = "Door Lock 1 Open"
                ElseIf .DoorLock2 Then
                    AlarmMessage = "Door Lock 2 Open"
                ElseIf .DoorLock3 Then
                    AlarmMessage = "Door Lock 3 Open"
                ElseIf .DoorLock4 Then
                    AlarmMessage = "Door Lock 4 Open"
                ElseIf .Curtain Then
                    AlarmMessage = "Curtain Sensor Discrepancy"
                ElseIf .V101 Then
                    AlarmMessage = "V101 Discrepancy"
                ElseIf .V301 Then
                    AlarmMessage = "V301 Discrepancy"
                ElseIf .V302 Then
                    AlarmMessage = "V302 Discrepancy"
                ElseIf .V303 Then
                    AlarmMessage = "V303 Discrepancy"
                ElseIf .V304 Then
                    AlarmMessage = "V304 Discrepancy"
                ElseIf .V401 Then
                    AlarmMessage = "V401 Discrepancy"
                ElseIf .LaserError Then
                    AlarmMessage = "ST4 Laser Error please check the laser"
                ElseIf .ShutterLaserError Then
                    AlarmMessage = "ST4 Shutter Laser Error please check or reset"
                ElseIf .InterlockLaserError Then
                    AlarmMessage = "ST4 Interlock Laser Error please check or reset"
                ElseIf .V501 Then
                    AlarmMessage = "V501 Discrepancy"
                ElseIf .V502 Then
                    AlarmMessage = "V502 Discrepancy"
                ElseIf .V503 Then
                    AlarmMessage = "V503 Discrepancy"
                ElseIf .CamLeftError Then
                    AlarmMessage = "ST5 Left Camera Error please reset the camera"
                ElseIf .CamRightError Then
                    AlarmMessage = "ST5 Right Camera Error please reset the camera"
                ElseIf .V601 Then
                    AlarmMessage = "V601 Discrepancy"
                ElseIf .V602 Then
                    AlarmMessage = "V602 Discrepancy"
                ElseIf .V603 Then
                    AlarmMessage = "V603 Discrepancy"
                Else
                    AlarmMessage = ". . . . . . . . "
                End If
                Invoke(Sub()
                           txt_alarm.Text = "ALARM : " + AlarmMessage
                       End Sub)
            End With
            Thread.Sleep(150)
        Loop
    End Sub
    Private Sub SaveDataLog()
        StartDate.Value = Date.Today
        EndDate.Value = Date.Today
        Dim _start As String = StartDate.Value.ToString("yyyy-MM-dd 00:00:00")
        Dim _end As String = EndDate.Value.ToString("yyyy-MM-dd 23:59:59")
        Try
            Call Database.Connect()
            Dim sc As New SqlCommand("SELECT * FROM tb_datalog WHERE [Date Time] BETWEEN '" + _start.Replace(".", ":") + "' AND '" + _end.Replace(".", ":") + "' ORDER BY [ID] ASC ", Database.Connection)
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
    Private Sub MainST6()
        Do
            If SequenceIndex = MainSequence.ScanQty Then
                With PlcSave
                    If .MW11100_10 = 1 Then
                        ' update count
                        CountProductResult += 1
                        ' data aquisition from plc
                        Dim LeftProdResult As Integer = ProductResult.ProductLeft
                        Dim RightProdResult As Integer = ProductResult.ProductRight
                        ' end data aquisition from plc
                        ' update text box
                        Invoke(Sub()
                                   Select Case MachineStatus.CavityST6
                                       Case 1
                                           If LeftProdResult = 1 Then
                                               lbl_status_l.BackColor = Color.Green
                                               lbl_status_l.Text = "OK"
                                           ElseIf LeftProdResult = 2 Then
                                               lbl_status_l.BackColor = Color.Red
                                               lbl_status_l.Text = "NG"
                                           End If

                                           If RightProdResult = 1 Then
                                               lbl_status_r.BackColor = Color.Green
                                               lbl_status_r.Text = "OK"
                                           ElseIf RightProdResult = 2 Then
                                               lbl_status_r.BackColor = Color.Red
                                               lbl_status_r.Text = "NG"
                                           End If

                                           TempSave_1.ProductLeft = LeftProdResult
                                           TempSave_1.ProductRight = RightProdResult
                                       Case 2
                                           If LeftProdResult = 1 Then
                                               lbl_status_l_1.BackColor = Color.Green
                                               lbl_status_l_1.Text = "OK"
                                           ElseIf LeftProdResult = 2 Then
                                               lbl_status_l_1.BackColor = Color.Red
                                               lbl_status_l_1.Text = "NG"
                                           End If

                                           If RightProdResult = 1 Then
                                               lbl_status_r_1.BackColor = Color.Green
                                               lbl_status_r_1.Text = "OK"
                                           ElseIf RightProdResult = 2 Then
                                               lbl_status_r_1.BackColor = Color.Red
                                               lbl_status_r_1.Text = "NG"
                                           End If

                                           TempSave_2.ProductLeft = LeftProdResult
                                           TempSave_2.ProductRight = RightProdResult
                                       Case 3
                                           If LeftProdResult = 1 Then
                                               lbl_status_l_2.BackColor = Color.Green
                                               lbl_status_l_2.Text = "OK"
                                           ElseIf LeftProdResult = 2 Then
                                               lbl_status_l_2.BackColor = Color.Red
                                               lbl_status_l_2.Text = "NG"
                                           End If

                                           If RightProdResult = 1 Then
                                               lbl_status_r_2.BackColor = Color.Green
                                               lbl_status_r_2.Text = "OK"
                                           ElseIf RightProdResult = 2 Then
                                               lbl_status_r_2.BackColor = Color.Red
                                               lbl_status_r_2.Text = "NG"
                                           End If

                                           TempSave_3.ProductLeft = LeftProdResult
                                           TempSave_3.ProductRight = RightProdResult
                                       Case 4
                                           If LeftProdResult = 1 Then
                                               lbl_status_l_3.BackColor = Color.Green
                                               lbl_status_l_3.Text = "OK"
                                           ElseIf LeftProdResult = 2 Then
                                               lbl_status_l_3.BackColor = Color.Red
                                               lbl_status_l_3.Text = "NG"
                                           End If

                                           If RightProdResult = 1 Then
                                               lbl_status_r_3.BackColor = Color.Green
                                               lbl_status_r_3.Text = "OK"
                                           ElseIf RightProdResult = 2 Then
                                               lbl_status_r_3.BackColor = Color.Red
                                               lbl_status_r_3.Text = "NG"
                                           End If

                                           TempSave_4.ProductLeft = LeftProdResult
                                           TempSave_4.ProductRight = RightProdResult
                                       Case 5
                                           If LeftProdResult = 1 Then
                                               lbl_status_l_4.BackColor = Color.Green
                                               lbl_status_l_4.Text = "OK"
                                           ElseIf LeftProdResult = 2 Then
                                               lbl_status_l_4.BackColor = Color.Red
                                               lbl_status_l_4.Text = "NG"
                                           End If

                                           If RightProdResult = 1 Then
                                               lbl_status_r_4.BackColor = Color.Green
                                               lbl_status_r_4.Text = "OK"
                                           ElseIf RightProdResult = 2 Then
                                               lbl_status_r_4.BackColor = Color.Red
                                               lbl_status_r_4.Text = "NG"
                                           End If

                                           TempSave_5.ProductLeft = LeftProdResult
                                           TempSave_5.ProductRight = RightProdResult
                                       Case 6
                                           If LeftProdResult = 1 Then
                                               lbl_status_l_5.BackColor = Color.Green
                                               lbl_status_l_5.Text = "OK"
                                           ElseIf LeftProdResult = 2 Then
                                               lbl_status_l_5.BackColor = Color.Red
                                               lbl_status_l_5.Text = "NG"
                                           End If

                                           If RightProdResult = 1 Then
                                               lbl_status_r_5.BackColor = Color.Green
                                               lbl_status_r_5.Text = "OK"
                                           ElseIf RightProdResult = 2 Then
                                               lbl_status_r_5.BackColor = Color.Red
                                               lbl_status_r_5.Text = "NG"
                                           End If

                                           TempSave_6.ProductLeft = LeftProdResult
                                           TempSave_6.ProductRight = RightProdResult
                                   End Select
                               End Sub)
                        ' end update text box
                        ' save database
                        'Call Database.Connect()
                        'Dim sc As New SqlCommand("UPDATE tb_datalog SET [Product Left Result] = '" & LeftProdResult & "', [Product Right Result] = '" & RightProdResult & "' WHERE [ID] = " & CountST5 & "", Database.Connection)
                        'Dim adapter As New SqlDataAdapter(sc)
                        'adapter.SelectCommand.ExecuteNonQuery()

                        Select Case MachineStatus.CavityST6
                            Case 1
                                With TempSave_1
                                    Call Database.Connect()
                                    Dim sc As New SqlCommand("INSERT INTO tb_datalog ([ID], [Date Time], [References], [Operator], [Product Order], [ST3 Measurement Left], [ST3 Measurement Right], [ST3 Measurement Left Status], [ST3 Measurement Right Status], [ST5 Camera Result Left], [ST5 Camera Result Right], [Product Left Result], [Product Right Result]) VALUES(" & CountProductResult & ", '" & Date.Now.ToString("yyyy-MM-dd HH:mm:ss").Replace(".", ":") & "', '" & ProductReferences.References & "', '" & txt_ope_id.Text & "', '" & txt_po_num.Text & "', '" & .MeasurementLeft.Replace(".", ",") & "', '" & .MeasurementRight.Replace(".", ",") & "', " & .MeasurementLeftStatus & ", " & .MeasurementRightStatus & ", " & .CameraLeft & ", " & .CameraRight & ", " & .ProductLeft & ", " & .ProductRight & " )", Database.Connection)
                                    Dim adapter As New SqlDataAdapter(sc)
                                    adapter.SelectCommand.ExecuteNonQuery()
                                End With
                            Case 2
                                With TempSave_2
                                    Call Database.Connect()
                                    Dim sc As New SqlCommand("INSERT INTO tb_datalog ([ID], [Date Time], [References], [Operator], [Product Order], [ST3 Measurement Left], [ST3 Measurement Right], [ST3 Measurement Left Status], [ST3 Measurement Right Status], [ST5 Camera Result Left], [ST5 Camera Result Right], [Product Left Result], [Product Right Result]) VALUES(" & CountProductResult & ", '" & Date.Now.ToString("yyyy-MM-dd HH:mm:ss").Replace(".", ":") & "', '" & ProductReferences.References & "', '" & txt_ope_id.Text & "', '" & txt_po_num.Text & "', '" & .MeasurementLeft.Replace(".", ",") & "', '" & .MeasurementRight.Replace(".", ",") & "', " & .MeasurementLeftStatus & ", " & .MeasurementRightStatus & ", " & .CameraLeft & ", " & .CameraRight & ", " & .ProductLeft & ", " & .ProductRight & " )", Database.Connection)
                                    Dim adapter As New SqlDataAdapter(sc)
                                    adapter.SelectCommand.ExecuteNonQuery()
                                End With
                            Case 3
                                With TempSave_3
                                    Call Database.Connect()
                                    Dim sc As New SqlCommand("INSERT INTO tb_datalog ([ID], [Date Time], [References], [Operator], [Product Order], [ST3 Measurement Left], [ST3 Measurement Right], [ST3 Measurement Left Status], [ST3 Measurement Right Status], [ST5 Camera Result Left], [ST5 Camera Result Right], [Product Left Result], [Product Right Result]) VALUES(" & CountProductResult & ", '" & Date.Now.ToString("yyyy-MM-dd HH:mm:ss").Replace(".", ":") & "', '" & ProductReferences.References & "', '" & txt_ope_id.Text & "', '" & txt_po_num.Text & "', '" & .MeasurementLeft.Replace(".", ",") & "', '" & .MeasurementRight.Replace(".", ",") & "', " & .MeasurementLeftStatus & ", " & .MeasurementRightStatus & ", " & .CameraLeft & ", " & .CameraRight & ", " & .ProductLeft & ", " & .ProductRight & " )", Database.Connection)
                                    Dim adapter As New SqlDataAdapter(sc)
                                    adapter.SelectCommand.ExecuteNonQuery()
                                End With
                            Case 4
                                With TempSave_4
                                    Call Database.Connect()
                                    Dim sc As New SqlCommand("INSERT INTO tb_datalog ([ID], [Date Time], [References], [Operator], [Product Order], [ST3 Measurement Left], [ST3 Measurement Right], [ST3 Measurement Left Status], [ST3 Measurement Right Status], [ST5 Camera Result Left], [ST5 Camera Result Right], [Product Left Result], [Product Right Result]) VALUES(" & CountProductResult & ", '" & Date.Now.ToString("yyyy-MM-dd HH:mm:ss").Replace(".", ":") & "', '" & ProductReferences.References & "', '" & txt_ope_id.Text & "', '" & txt_po_num.Text & "', '" & .MeasurementLeft.Replace(".", ",") & "', '" & .MeasurementRight.Replace(".", ",") & "', " & .MeasurementLeftStatus & ", " & .MeasurementRightStatus & ", " & .CameraLeft & ", " & .CameraRight & ", " & .ProductLeft & ", " & .ProductRight & " )", Database.Connection)
                                    Dim adapter As New SqlDataAdapter(sc)
                                    adapter.SelectCommand.ExecuteNonQuery()
                                End With
                            Case 5
                                With TempSave_5
                                    Call Database.Connect()
                                    Dim sc As New SqlCommand("INSERT INTO tb_datalog ([ID], [Date Time], [References], [Operator], [Product Order], [ST3 Measurement Left], [ST3 Measurement Right], [ST3 Measurement Left Status], [ST3 Measurement Right Status], [ST5 Camera Result Left], [ST5 Camera Result Right], [Product Left Result], [Product Right Result]) VALUES(" & CountProductResult & ", '" & Date.Now.ToString("yyyy-MM-dd HH:mm:ss").Replace(".", ":") & "', '" & ProductReferences.References & "', '" & txt_ope_id.Text & "', '" & txt_po_num.Text & "', '" & .MeasurementLeft.Replace(".", ",") & "', '" & .MeasurementRight.Replace(".", ",") & "', " & .MeasurementLeftStatus & ", " & .MeasurementRightStatus & ", " & .CameraLeft & ", " & .CameraRight & ", " & .ProductLeft & ", " & .ProductRight & " )", Database.Connection)
                                    Dim adapter As New SqlDataAdapter(sc)
                                    adapter.SelectCommand.ExecuteNonQuery()
                                End With
                            Case 6
                                With TempSave_6
                                    Call Database.Connect()
                                    Dim sc As New SqlCommand("INSERT INTO tb_datalog ([ID], [Date Time], [References], [Operator], [Product Order], [ST3 Measurement Left], [ST3 Measurement Right], [ST3 Measurement Left Status], [ST3 Measurement Right Status], [ST5 Camera Result Left], [ST5 Camera Result Right], [Product Left Result], [Product Right Result]) VALUES(" & CountProductResult & ", '" & Date.Now.ToString("yyyy-MM-dd HH:mm:ss").Replace(".", ":") & "', '" & ProductReferences.References & "', '" & txt_ope_id.Text & "', '" & txt_po_num.Text & "', '" & .MeasurementLeft.Replace(".", ",") & "', '" & .MeasurementRight.Replace(".", ",") & "', " & .MeasurementLeftStatus & ", " & .MeasurementRightStatus & ", " & .CameraLeft & ", " & .CameraRight & ", " & .ProductLeft & ", " & .ProductRight & " )", Database.Connection)
                                    Dim adapter As New SqlDataAdapter(sc)
                                    adapter.SelectCommand.ExecuteNonQuery()
                                End With
                        End Select

                        ' end save database
                        ' save datalog
                        Invoke(Sub()
                                   SaveDataLog()
                               End Sub)
                        ' trigger finish save data
                        .MW11100_ = Modbus.WriteBit(.MW11100_, 11, 1)
                        .MW11100_ = Modbus.WriteBit(.MW11100_, 10, 0)
                        PlcTrigger.MW11100_ = True
                        PlcWriteState = True
                        'end trigger finish save data
                    End If
                End With
            End If

            Thread.Sleep(150)
        Loop
    End Sub
    Private Sub MainST5()
        Do
            If SequenceIndex = MainSequence.ScanQty Then
                With PlcSave
                    If .MW11100_6 = 1 Then
                        ' update count
                        CountST5 += 1
                        ' data aquisition from plc
                        Dim LeftCameraResult As Integer = ProductResult.CameraLeft
                        Dim RightCameraResult As Integer = ProductResult.CameraRight
                        ' end data aquisition from plc
                        ' update text box
                        Invoke(Sub()
                                   Select Case MachineStatus.CavityST5
                                       Case 1
                                           If LeftCameraResult = 1 Then
                                               lbl_st5_left_camera.BackColor = Color.Green
                                               lbl_st5_left_camera.Text = "OK"
                                           ElseIf LeftCameraResult = 2 Then
                                               lbl_st5_left_camera.BackColor = Color.Red
                                               lbl_st5_left_camera.Text = "NG"
                                           End If

                                           If RightCameraResult = 1 Then
                                               lbl_st5_right_camera.BackColor = Color.Green
                                               lbl_st5_right_camera.Text = "OK"
                                           ElseIf RightCameraResult = 2 Then
                                               lbl_st5_right_camera.BackColor = Color.Red
                                               lbl_st5_right_camera.Text = "NG"
                                           End If
                                           TempSave_1.CameraRight = RightCameraResult
                                           TempSave_1.CameraLeft = LeftCameraResult
                                       Case 2
                                           If LeftCameraResult = 1 Then
                                               lbl_st5_left_camera_1.BackColor = Color.Green
                                               lbl_st5_left_camera_1.Text = "OK"
                                           ElseIf LeftCameraResult = 2 Then
                                               lbl_st5_left_camera_1.BackColor = Color.Red
                                               lbl_st5_left_camera_1.Text = "NG"
                                           End If

                                           If RightCameraResult = 1 Then
                                               lbl_st5_right_camera_1.BackColor = Color.Green
                                               lbl_st5_right_camera_1.Text = "OK"
                                           ElseIf RightCameraResult = 2 Then
                                               lbl_st5_right_camera_1.BackColor = Color.Red
                                               lbl_st5_right_camera_1.Text = "NG"
                                           End If
                                           TempSave_2.CameraRight = RightCameraResult
                                           TempSave_2.CameraLeft = LeftCameraResult
                                       Case 3
                                           If LeftCameraResult = 1 Then
                                               lbl_st5_left_camera_2.BackColor = Color.Green
                                               lbl_st5_left_camera_2.Text = "OK"
                                           ElseIf LeftCameraResult = 2 Then
                                               lbl_st5_left_camera_2.BackColor = Color.Red
                                               lbl_st5_left_camera_2.Text = "NG"
                                           End If

                                           If RightCameraResult = 1 Then
                                               lbl_st5_right_camera_2.BackColor = Color.Green
                                               lbl_st5_right_camera_2.Text = "OK"
                                           ElseIf RightCameraResult = 2 Then
                                               lbl_st5_right_camera_2.BackColor = Color.Red
                                               lbl_st5_right_camera_2.Text = "NG"
                                           End If
                                           TempSave_3.CameraRight = RightCameraResult
                                           TempSave_3.CameraLeft = LeftCameraResult
                                       Case 4
                                           If LeftCameraResult = 1 Then
                                               lbl_st5_left_camera_3.BackColor = Color.Green
                                               lbl_st5_left_camera_3.Text = "OK"
                                           ElseIf LeftCameraResult = 2 Then
                                               lbl_st5_left_camera_3.BackColor = Color.Red
                                               lbl_st5_left_camera_3.Text = "NG"
                                           End If

                                           If RightCameraResult = 1 Then
                                               lbl_st5_right_camera_3.BackColor = Color.Green
                                               lbl_st5_right_camera_3.Text = "OK"
                                           ElseIf RightCameraResult = 2 Then
                                               lbl_st5_right_camera_3.BackColor = Color.Red
                                               lbl_st5_right_camera_3.Text = "NG"
                                           End If
                                           TempSave_4.CameraRight = RightCameraResult
                                           TempSave_4.CameraLeft = LeftCameraResult
                                       Case 5
                                           If LeftCameraResult = 1 Then
                                               lbl_st5_left_camera_4.BackColor = Color.Green
                                               lbl_st5_left_camera_4.Text = "OK"
                                           ElseIf LeftCameraResult = 2 Then
                                               lbl_st5_left_camera_4.BackColor = Color.Red
                                               lbl_st5_left_camera_4.Text = "NG"
                                           End If

                                           If RightCameraResult = 1 Then
                                               lbl_st5_right_camera_4.BackColor = Color.Green
                                               lbl_st5_right_camera_4.Text = "OK"
                                           ElseIf RightCameraResult = 2 Then
                                               lbl_st5_right_camera_4.BackColor = Color.Red
                                               lbl_st5_right_camera_4.Text = "NG"
                                           End If
                                           TempSave_5.CameraRight = RightCameraResult
                                           TempSave_5.CameraLeft = LeftCameraResult
                                       Case 6
                                           If LeftCameraResult = 1 Then
                                               lbl_st5_left_camera_5.BackColor = Color.Green
                                               lbl_st5_left_camera_5.Text = "OK"
                                           ElseIf LeftCameraResult = 2 Then
                                               lbl_st5_left_camera_5.BackColor = Color.Red
                                               lbl_st5_left_camera_5.Text = "NG"
                                           End If

                                           If RightCameraResult = 1 Then
                                               lbl_st5_right_camera_5.BackColor = Color.Green
                                               lbl_st5_right_camera_5.Text = "OK"
                                           ElseIf RightCameraResult = 2 Then
                                               lbl_st5_right_camera_5.BackColor = Color.Red
                                               lbl_st5_right_camera_5.Text = "NG"
                                           End If
                                           TempSave_6.CameraRight = RightCameraResult
                                           TempSave_6.CameraLeft = LeftCameraResult
                                   End Select
                               End Sub)
                        ' end update text box
                        ' save database
                        Call Database.Connect()
                        Dim sc As New SqlCommand("UPDATE tb_datalog SET [ST5 Camera Result Left] = '" & LeftCameraResult & "', [ST5 Camera Result Right] = '" & RightCameraResult & "' WHERE [ID] = " & CountST5 & "", Database.Connection)
                        Dim adapter As New SqlDataAdapter(sc)
                        adapter.SelectCommand.ExecuteNonQuery()
                        ' end save database
                        ' save datalog file
                        Invoke(Sub()
                                   SaveDataLog()
                               End Sub)
                        ' trigger finish save data
                        .MW11100_ = Modbus.WriteBit(.MW11100_, 7, 1)
                        .MW11100_ = Modbus.WriteBit(.MW11100_, 6, 0)
                        PlcTrigger.MW11100_ = True
                        PlcWriteState = True
                        'end trigger finish save data
                    End If
                End With
            End If

            Thread.Sleep(150)
        Loop
    End Sub
    Private Sub MainST3()
        Do
            If SequenceIndex = MainSequence.ScanQty Then
                With PlcSave
                    If .MW11100_0 = 1 Then
                        ' update count
                        CountST3 += 1
                        ' update config
                        Config.CountProduct = CountST3
                        WriteINI(iniPath, "STATUS", "CountProduct", Config.CountProduct)
                        ' data aquisition from instrument
                        Heiden.Write("A00100" + vbCr)
                        Hain.Write("A00100" + vbCr)
                        Thread.Sleep(100)
                        Dim LeftHeidenResult As String = HeidenString.Replace(" ", "")
                        Dim RightHeidenResult As String = HainString.Replace(" ", "")
                        ' end data aquisition from instrument
                        ' update text box
                        Invoke(Sub()
                                   Select Case MachineStatus.CavityST3
                                       Case 1
                                           TempSave_1.MeasurementLeft = LeftHeidenResult
                                           TempSave_1.MeasurementRight = RightHeidenResult
                                           lbl_st3_left_measure.Text = LeftHeidenResult
                                           lbl_st3_right_measure.Text = RightHeidenResult
                                           lbl_st5_left_camera.Text = ""
                                           lbl_st5_right_camera.Text = ""
                                           lbl_status_l.Text = ""
                                           lbl_status_r.Text = ""
                                       Case 2
                                           TempSave_2.MeasurementLeft = LeftHeidenResult
                                           TempSave_2.MeasurementRight = RightHeidenResult
                                           lbl_st3_left_measure_1.Text = LeftHeidenResult
                                           lbl_st3_right_measure_1.Text = RightHeidenResult
                                           lbl_st5_left_camera_1.Text = ""
                                           lbl_st5_right_camera_1.Text = ""
                                           lbl_status_l_1.Text = ""
                                           lbl_status_r_1.Text = ""
                                       Case 3
                                           TempSave_3.MeasurementLeft = LeftHeidenResult
                                           TempSave_3.MeasurementRight = RightHeidenResult
                                           lbl_st3_left_measure_2.Text = LeftHeidenResult
                                           lbl_st3_right_measure_2.Text = RightHeidenResult
                                           lbl_st5_left_camera_2.Text = ""
                                           lbl_st5_right_camera_2.Text = ""
                                           lbl_status_l_2.Text = ""
                                           lbl_status_r_2.Text = ""
                                       Case 4
                                           TempSave_4.MeasurementLeft = LeftHeidenResult
                                           TempSave_4.MeasurementRight = RightHeidenResult
                                           lbl_st3_left_measure_3.Text = LeftHeidenResult
                                           lbl_st3_right_measure_3.Text = RightHeidenResult
                                           lbl_st5_left_camera_3.Text = ""
                                           lbl_st5_right_camera_3.Text = ""
                                           lbl_status_l_3.Text = ""
                                           lbl_status_r_3.Text = ""
                                       Case 5
                                           TempSave_5.MeasurementLeft = LeftHeidenResult
                                           TempSave_5.MeasurementRight = RightHeidenResult
                                           lbl_st3_left_measure_4.Text = LeftHeidenResult
                                           lbl_st3_right_measure_4.Text = RightHeidenResult
                                           lbl_st5_left_camera_4.Text = ""
                                           lbl_st5_right_camera_4.Text = ""
                                           lbl_status_l_4.Text = ""
                                           lbl_status_r_4.Text = ""
                                       Case 6
                                           TempSave_6.MeasurementLeft = LeftHeidenResult
                                           TempSave_6.MeasurementRight = RightHeidenResult
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
                        'Call Database.Connect()
                        'Dim sc As New SqlCommand("INSERT INTO tb_datalog ([ID], [Date Time], [References], [Operator], [Product Order], [ST3 Measurement Left], [ST3 Measurement Right]) VALUES(" & CountST3 & ", '" & Date.Now.ToString("yyyy-MM-dd HH:mm:ss").Replace(".", ":") & "', '" & ProductReferences.References & "', '" & txt_ope_id.Text & "', '" & txt_po_num.Text & "', '" & LeftHeidenResult.Replace(".", ",") & "', '" & LeftHeidenResult.Replace(".", ",") & "')", Database.Connection)
                        'Dim adapter As New SqlDataAdapter(sc)
                        'adapter.SelectCommand.ExecuteNonQuery()
                        ' end save database
                        ' save datalog file
                        'Invoke(Sub()
                        '           SaveDataLog()
                        '       End Sub)
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

                                           TempSave_1.MeasurementLeftStatus = LeftMeasureResult
                                           TempSave_1.MeasurementRightStatus = RightMeasureResult
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

                                           TempSave_2.MeasurementLeftStatus = LeftMeasureResult
                                           TempSave_2.MeasurementRightStatus = RightMeasureResult
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

                                           TempSave_3.MeasurementLeftStatus = LeftMeasureResult
                                           TempSave_3.MeasurementRightStatus = RightMeasureResult
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

                                           TempSave_4.MeasurementLeftStatus = LeftMeasureResult
                                           TempSave_4.MeasurementRightStatus = RightMeasureResult
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

                                           TempSave_5.MeasurementLeftStatus = LeftMeasureResult
                                           TempSave_5.MeasurementRightStatus = RightMeasureResult
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

                                           TempSave_6.MeasurementLeftStatus = LeftMeasureResult
                                           TempSave_6.MeasurementRightStatus = RightMeasureResult
                                   End Select
                               End Sub)
                        ' end update text box
                        ' save database
                        'Call Database.Connect()
                        'Dim sc As New SqlCommand("UPDATE tb_datalog SET [ST3 Measurement Left Status] = '" & LeftMeasureResult & "', [ST3 Measurement Right Status] = '" & RightMeasureResult & "' WHERE [ID] = " & CountST3 & "", Database.Connection)
                        'Dim adapter As New SqlDataAdapter(sc)
                        'adapter.SelectCommand.ExecuteNonQuery()
                        ' end save database
                        ' save datalog file
                        'Invoke(Sub()
                        '           SaveDataLog()
                        '       End Sub)
                        ' end save datalog file
                        ' trigger finish save data
                        .MW11100_ = Modbus.WriteBit(.MW11100_, 3, 1)
                        .MW11100_ = Modbus.WriteBit(.MW11100_, 2, 0)
                        PlcTrigger.MW11100_ = True
                        PlcWriteState = True
                        'end trigger finish save data
                    End If
                End With
            End If

            Thread.Sleep(150)
        Loop
    End Sub
    Public Sub sendLaserString(data As String)
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
                                       If MachineStatus.EmptyBusy = 1 Then
                                           lbl_op_ins.Text = "Load data finish, please start process..." + vbCrLf + "Empty busy..."
                                       ElseIf MachineStatus.EmptyFinish = 1 Then
                                           lbl_op_ins.Text = "Load data finish, please start process..." + vbCrLf + "Empty finish..."
                                       Else
                                           lbl_op_ins.Text = "Load data finish, please start process..."
                                       End If
                                   End Sub)
                            'SequenceIndex = MainSequence.GetData
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

                    Try
                        If IsHandleCreated Then
                            Invoke(Sub()
                                       lbl_cav_1.Text = MachineStatus.CavityST1
                                       lbl_cav_2.Text = MachineStatus.CavityST2
                                       lbl_cav_3.Text = MachineStatus.CavityST3
                                       lbl_cav_4.Text = MachineStatus.CavityST4
                                       lbl_cav_5.Text = MachineStatus.CavityST5
                                       lbl_cav_6.Text = MachineStatus.CavityST6
                                       lbl_cyc_1.Text = String.Format("{0:0.00}", MachineStatus.CycleST1)
                                       lbl_cyc_2.Text = String.Format("{0:0.00}", MachineStatus.CycleST2)
                                       lbl_cyc_3.Text = String.Format("{0:0.00}", MachineStatus.CycleST3)
                                       lbl_cyc_4.Text = String.Format("{0:0.00}", MachineStatus.CycleST4)
                                       lbl_cyc_5.Text = String.Format("{0:0.00}", MachineStatus.CycleST5)
                                       lbl_cyc_6.Text = String.Format("{0:0.00}", MachineStatus.CycleST6)
                                       Mc_Cyc_Time.Text = String.Format("{0:0.00}", MachineStatus.McCT)
                                   End Sub)
                        End If
                    Catch ex As Exception

                    End Try
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
            If PlcTrigger.V301 = True Then
                Modbus.WriteInteger(3101, .V301)
                PlcTrigger.V301 = False
            End If
            If PlcTrigger.V302 = True Then
                Modbus.WriteInteger(3102, .V302)
                PlcTrigger.V302 = False
            End If
            If PlcTrigger.V303 = True Then
                Modbus.WriteInteger(3103, .V303)
                PlcTrigger.V303 = False
            End If
            If PlcTrigger.V304 = True Then
                Modbus.WriteInteger(3104, .V304)
                PlcTrigger.V304 = False
            End If
            If PlcTrigger.MW4101_ = True Then
                Modbus.WriteInteger(4101, .MW4101_)
                PlcTrigger.MW4101_ = False
            End If
            If PlcTrigger.V501 = True Then
                Modbus.WriteInteger(5101, .V501)
                PlcTrigger.V501 = False
            End If
            If PlcTrigger.V502 = True Then
                Modbus.WriteInteger(5102, .V502)
                PlcTrigger.V502 = False
            End If
            If PlcTrigger.V503 = True Then
                Modbus.WriteInteger(5103, .V503)
                PlcTrigger.V503 = False
            End If
            If PlcTrigger.V601 = True Then
                Modbus.WriteInteger(6101, .V601)
                PlcTrigger.V601 = False
            End If
            If PlcTrigger.V602 = True Then
                Modbus.WriteInteger(6102, .V602)
                PlcTrigger.V602 = False
            End If
            If PlcTrigger.V603 = True Then
                Modbus.WriteInteger(6103, .V603)
                PlcTrigger.V603 = False
            End If
            If PlcTrigger.MW5104_ Then
                PlcTrigger.MW5104_ = False
                Modbus.WriteInteger(5104, .MW5104_)
            End If
            If PlcTrigger.MW5105_ Then
                PlcTrigger.MW5105_ = False
                Modbus.WriteInteger(5105, .MW5105_)
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
            If PlcTrigger.Empty Then
                PlcTrigger.Empty = False
                Modbus.WriteInteger(9, .EmptyRequest)
            End If
            If PlcTrigger.StartCali Then
                PlcTrigger.StartCali = False
                Modbus.WriteInteger(3105, .StartCali)
            End If
            If PlcTrigger.Left1 Then
                PlcTrigger.Left1 = False
                Modbus.WriteInteger(3020, .Left1)
            End If
            If PlcTrigger.Left2 Then
                PlcTrigger.Left2 = False
                Modbus.WriteInteger(3022, .Left2)
            End If
            If PlcTrigger.Left3 Then
                PlcTrigger.Left3 = False
                Modbus.WriteInteger(3024, .Left3)
            End If
            If PlcTrigger.Left4 Then
                PlcTrigger.Left4 = False
                Modbus.WriteInteger(3026, .Left4)
            End If
            If PlcTrigger.Left5 Then
                PlcTrigger.Left5 = False
                Modbus.WriteInteger(3028, .Left5)
            End If
            If PlcTrigger.Left6 Then
                PlcTrigger.Left6 = False
                Modbus.WriteInteger(3030, .Left6)
            End If
            If PlcTrigger.Right1 Then
                PlcTrigger.Right1 = False
                Modbus.WriteInteger(3032, .Right1)
            End If
            If PlcTrigger.Right2 Then
                PlcTrigger.Right2 = False
                Modbus.WriteInteger(3034, .Right2)
            End If
            If PlcTrigger.Right3 Then
                PlcTrigger.Right3 = False
                Modbus.WriteInteger(3036, .Right3)
            End If
            If PlcTrigger.Right4 Then
                PlcTrigger.Right4 = False
                Modbus.WriteInteger(3038, .Right4)
            End If
            If PlcTrigger.Right5 Then
                PlcTrigger.Right5 = False
                Modbus.WriteInteger(3040, .Right5)
            End If
            If PlcTrigger.Right6 Then
                PlcTrigger.Right6 = False
                Modbus.WriteInteger(3042, .Right6)
            End If
            If PlcTrigger.MW2000_ Or PlcTrigger.EnableDisable Then
                PlcTrigger.MW2000_ = False
                Modbus.WriteInteger(2000, .MW2000_)
            End If
            If PlcTrigger.EnableDisable Then
                PlcTrigger.EnableDisable = False
                Modbus.WriteInteger(1000, .MW1000_)
                Modbus.WriteInteger(3000, .MW3000_)
                Modbus.WriteInteger(4000, .MW4000_)
                Modbus.WriteInteger(5000, .MW5000_)
                Modbus.WriteInteger(6000, .MW6000_)
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
                'For index As Integer = 0 To 19
                '    .LaserCharData = .LaserStringData.Chars(index)
                '    ''Debug.Write(index & " ")
                '    ''Debug.WriteLine(char_data & " ")
                '    Modbus.WriteInteger(10100 + index, Convert.ToInt32(.LaserCharData))
                'Next
                Modbus.WriteInteger(10100, Convert.ToInt32(.LaserStringData.Chars(0)))
                Modbus.WriteInteger(10101, Convert.ToInt32(.LaserStringData.Chars(1)))
                Modbus.WriteInteger(10102, Convert.ToInt32(.LaserStringData.Chars(2)))
                Modbus.WriteInteger(10103, Convert.ToInt32(.LaserStringData.Chars(3)))
                Modbus.WriteInteger(10104, Convert.ToInt32(.LaserStringData.Chars(4)))
                Modbus.WriteInteger(10105, Convert.ToInt32(.LaserStringData.Chars(5)))
                Modbus.WriteInteger(10106, Convert.ToInt32(.LaserStringData.Chars(6)))
                Modbus.WriteInteger(10107, Convert.ToInt32(.LaserStringData.Chars(7)))
                Modbus.WriteInteger(10108, Convert.ToInt32(.LaserStringData.Chars(8)))
                Modbus.WriteInteger(10109, Convert.ToInt32(.LaserStringData.Chars(9)))
                Modbus.WriteInteger(10110, Convert.ToInt32(.LaserStringData.Chars(10)))
                Modbus.WriteInteger(10111, Convert.ToInt32(.LaserStringData.Chars(11)))
                Modbus.WriteInteger(10112, Convert.ToInt32(.LaserStringData.Chars(12)))
                Modbus.WriteInteger(10113, Convert.ToInt32(.LaserStringData.Chars(13)))
                Modbus.WriteInteger(10114, Convert.ToInt32(.LaserStringData.Chars(14)))
                Modbus.WriteInteger(10115, Convert.ToInt32(.LaserStringData.Chars(15)))
                Modbus.WriteInteger(10116, Convert.ToInt32(.LaserStringData.Chars(16)))
                Modbus.WriteInteger(10117, Convert.ToInt32(.LaserStringData.Chars(17)))
                Modbus.WriteInteger(10118, Convert.ToInt32(.LaserStringData.Chars(18)))
                Modbus.WriteInteger(10119, Convert.ToInt32(.LaserStringData.Chars(19)))
            End With
        End If

        With PlcSave
            If PlcTrigger.MW11100_ Then

                Modbus.WriteInteger(11100, .MW11100_)
                PlcTrigger.MW11100_ = False
            End If
        End With

        With ProductResult
            If PlcTrigger.HeidenResult Then

                Modbus.WriteDoubleInteger(12000, .MeasurementLeft)
                Modbus.WriteDoubleInteger(12002, .MeasurementRight)
                PlcTrigger.HeidenResult = False
            End If
        End With

        With Fest
            If PlcTrigger.MW370_ Then
                PlcTrigger.MW370_ = False
                Modbus.WriteInteger(370, .MW370_)
            End If
            If PlcTrigger.MW380_ Then
                PlcTrigger.MW380_ = False
                Modbus.WriteInteger(380, .MW380_)
            End If
            If PlcTrigger.ModPosL Then
                PlcTrigger.ModPosL = False
                Modbus.WriteInteger(375, .ModPosL)
            End If
            If PlcTrigger.ModPosR Then
                PlcTrigger.ModPosR = False
                Modbus.WriteInteger(385, .ModPosR)
            End If
            If PlcTrigger.TargetPosVelL Then
                PlcTrigger.TargetPosVelL = False
                Modbus.WriteDoubleInteger(372, .TextTpositionL)
                Modbus.WriteInteger(374, .TextTvelocityL)
            End If
            If PlcTrigger.TargetPosVelR Then
                PlcTrigger.TargetPosVelR = False
                Modbus.WriteDoubleInteger(382, .TextTpositionR)
                Modbus.WriteInteger(384, .TextTvelocityR)
            End If
        End With
    End Sub
    Private Sub PlcReading()
        With MachineAlarm
            .AlarmGeneral = Modbus.ReadInteger(90)
            .DoorLock1 = Modbus.ReadBit(.AlarmGeneral, 0)
            .DoorLock2 = Modbus.ReadBit(.AlarmGeneral, 1)
            .DoorLock3 = Modbus.ReadBit(.AlarmGeneral, 2)
            .DoorLock4 = Modbus.ReadBit(.AlarmGeneral, 3)
            .Curtain = Modbus.ReadBit(.AlarmGeneral, 4)

            .AlarmST1 = Modbus.ReadInteger(104)
            .V101 = Modbus.ReadBit(.AlarmST1, 0)

            .AlarmST3 = Modbus.ReadInteger(304)
            .V301 = Modbus.ReadBit(.AlarmST3, 0)
            .V302 = Modbus.ReadBit(.AlarmST3, 1)
            .V303 = Modbus.ReadBit(.AlarmST3, 2)
            .V304 = Modbus.ReadBit(.AlarmST3, 3)

            .AlarmST4 = Modbus.ReadInteger(404)
            .V401 = Modbus.ReadBit(.AlarmST4, 0)
            .LaserError = Modbus.ReadBit(.AlarmST4, 1)
            .ShutterLaserError = Modbus.ReadBit(.AlarmST4, 2)
            .InterlockLaserError = Modbus.ReadBit(.AlarmST4, 3)

            .AlarmST5 = Modbus.ReadInteger(504)
            .V501 = Modbus.ReadBit(.AlarmST5, 0)
            .V502 = Modbus.ReadBit(.AlarmST5, 1)
            .V503 = Modbus.ReadBit(.AlarmST5, 2)
            .CamLeftError = Modbus.ReadBit(.AlarmST5, 3)
            .CamRightError = Modbus.ReadBit(.AlarmST5, 4)

            .AlarmST6 = Modbus.ReadInteger(604)
            .V601 = Modbus.ReadBit(.AlarmST6, 0)
            .V602 = Modbus.ReadBit(.AlarmST6, 1)
            .V603 = Modbus.ReadBit(.AlarmST6, 2)
        End With
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

            .CavityST1 = Modbus.ReadInteger(1952)
            .CavityST2 = Modbus.ReadInteger(2952)
            .CavityST3 = Modbus.ReadInteger(3952)
            .CavityST4 = Modbus.ReadInteger(4952)
            .CavityST5 = Modbus.ReadInteger(5952)
            .CavityST6 = Modbus.ReadInteger(6952)

            .CycleST1 = Modbus.ReadFloat(1950)
            .CycleST2 = Modbus.ReadFloat(2950)
            .CycleST3 = Modbus.ReadFloat(3950)
            .CycleST4 = Modbus.ReadFloat(4950)
            .CycleST5 = Modbus.ReadFloat(5950)
            .CycleST6 = Modbus.ReadFloat(6950)
            .McCT = Modbus.ReadFloat(14)

            .OutputFail = Modbus.ReadInteger(4)
            .OutputPass = Modbus.ReadInteger(3)

            .Laser = Modbus.ReadInteger(4202)
            .LaserError = Modbus.ReadBit(.Laser, 0)
            .LaserReady = Modbus.ReadBit(.Laser, 1)
            .LaserBusy = Modbus.ReadBit(.Laser, 2)
            .LaserShutter = Modbus.ReadBit(.Laser, 3)
            .LaserInterlock = Modbus.ReadBit(.Laser, 4)
            .LaserCommandOK = Modbus.ReadBit(.Laser, 5)

            .LeftCamera = Modbus.ReadInteger(5204)
            .LCamError = Modbus.ReadBit(.LeftCamera, 2)
            .LCamNG = Modbus.ReadBit(.LeftCamera, 4)
            .LCamOK = Modbus.ReadBit(.LeftCamera, 3)
            .LCamReady = Modbus.ReadBit(.LeftCamera, 1)
            .LCamRun = Modbus.ReadBit(.LeftCamera, 0)

            .RightCamera = Modbus.ReadInteger(5205)
            .RCamError = Modbus.ReadBit(.RightCamera, 2)
            .RCamNG = Modbus.ReadBit(.RightCamera, 4)
            .RCamOK = Modbus.ReadBit(.RightCamera, 3)
            .RCamReady = Modbus.ReadBit(.RightCamera, 1)
            .RCamRun = Modbus.ReadBit(.RightCamera, 0)

            .CaliStatus = Modbus.ReadInteger(3205)
            .CaliBusy = Modbus.ReadBit(.CaliStatus, 0)

            .MW1000_ = Modbus.ReadInteger(1000)
            .MW2000_ = Modbus.ReadInteger(2000)
            .MW3000_ = Modbus.ReadInteger(3000)
            .MW4000_ = Modbus.ReadInteger(4000)
            .MW5000_ = Modbus.ReadInteger(5000)
            .MW6000_ = Modbus.ReadInteger(6000)
        End With

        With GetCylinder
            .V101 = Modbus.ReadInteger(1201)
            .V301 = Modbus.ReadInteger(3201)
            .V302 = Modbus.ReadInteger(3202)
            .V303 = Modbus.ReadInteger(3203)
            .V304 = Modbus.ReadInteger(3204)
            .V401 = Modbus.ReadInteger(4201)
            .V501 = Modbus.ReadInteger(5201)
            .V502 = Modbus.ReadInteger(5202)
            .V503 = Modbus.ReadInteger(5203)
            .V601 = Modbus.ReadInteger(6201)
            .V602 = Modbus.ReadInteger(6202)
            .V603 = Modbus.ReadInteger(6203)

            .MW1900_ = Modbus.ReadInteger(1900)
            .MW1900_0 = Modbus.ReadBit(.MW1900_, 0)
            .MW1900_1 = Modbus.ReadBit(.MW1900_, 1)

            .MW2900_ = Modbus.ReadInteger(2900)
            .MW2900_0 = Modbus.ReadBit(.MW2900_, 0)
            .MW2900_1 = Modbus.ReadBit(.MW2900_, 1)
            .MW2900_2 = Modbus.ReadBit(.MW2900_, 2)

            .MW3900_ = Modbus.ReadInteger(3900)
            .MW3900_0 = Modbus.ReadBit(.MW3900_, 0)
            .MW3900_1 = Modbus.ReadBit(.MW3900_, 1)

            .MW4900_ = Modbus.ReadInteger(4900)
            .MW4900_0 = Modbus.ReadBit(.MW4900_, 0)
            .MW4900_1 = Modbus.ReadBit(.MW4900_, 1)

            .MW5900_ = Modbus.ReadInteger(5900)
            .MW5900_0 = Modbus.ReadBit(.MW5900_, 0)
            .MW5900_1 = Modbus.ReadBit(.MW5900_, 1)

            .MW6900_ = Modbus.ReadInteger(6900)
            .MW6900_0 = Modbus.ReadBit(.MW6900_, 0)
            .MW6900_1 = Modbus.ReadBit(.MW6900_, 1)
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

        With Fest
            'Festo Left
            .IndicatorLeft = Modbus.ReadInteger(371)
            .IndAxEnabledL = Modbus.ReadBit(.IndicatorLeft, 0)
            .IndAxPosL = Modbus.ReadBit(.IndicatorLeft, 1)
            .IndAxSpL = Modbus.ReadBit(.IndicatorLeft, 2)
            .IndAxAckL = Modbus.ReadBit(.IndicatorLeft, 3)
            .IndAxRefL = Modbus.ReadBit(.IndicatorLeft, 4)
            .IndAxWarnL = Modbus.ReadBit(.IndicatorLeft, 5)
            .IndAxErrorL = Modbus.ReadBit(.IndicatorLeft, 6)
            .IndLockL = Modbus.ReadBit(.IndicatorLeft, 7)
            .IndErrorL = Modbus.ReadBit(.IndicatorLeft, 8)
            .TextAPositionL = Modbus.ReadDoubleInteger(376)
            .TextFaultL = Modbus.ReadInteger(378)

            'Festo Right
            .IndicatorRight = Modbus.ReadInteger(381)
            .IndAxEnabledR = Modbus.ReadBit(.IndicatorRight, 0)
            .IndAxPosR = Modbus.ReadBit(.IndicatorRight, 1)
            .IndAxSpR = Modbus.ReadBit(.IndicatorRight, 2)
            .IndAxAckR = Modbus.ReadBit(.IndicatorRight, 3)
            .IndAxRefR = Modbus.ReadBit(.IndicatorRight, 4)
            .IndAxWarnR = Modbus.ReadBit(.IndicatorRight, 5)
            .IndAxErrorR = Modbus.ReadBit(.IndicatorRight, 6)
            .IndLockR = Modbus.ReadBit(.IndicatorRight, 7)
            .IndErrorR = Modbus.ReadBit(.IndicatorRight, 8)
            .TextAPositionR = Modbus.ReadDoubleInteger(386)
            .TextFaultR = Modbus.ReadInteger(388)
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
        If ThreadLoadData.IsAlive Then
            ThreadLoadData.Abort()
        End If
        If ThreadST3.IsAlive Then
            ThreadST3.Abort()
        End If
        If ThreadST5.IsAlive Then
            ThreadST5.Abort()
        End If
        If ThreadST6.IsAlive Then
            ThreadST6.Abort()
        End If
        If ThreadAlarm.IsAlive Then
            ThreadAlarm.Abort()
        End If
        Heiden.Close()
        Hain.Close()
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

    Private Sub btn_empty_MouseDown(sender As Object, e As MouseEventArgs) Handles btn_empty.MouseDown
        With MachineStatus
            .EmptyRequest = Modbus.WriteBit(.EmptyRequest, 0, 1)
            PlcTrigger.Empty = True
            PlcWriteState = True
        End With
    End Sub

    Private Sub btn_empty_MouseUp(sender As Object, e As MouseEventArgs) Handles btn_empty.MouseUp
        With MachineStatus
            .EmptyRequest = Modbus.WriteBit(.EmptyRequest, 0, 0)
            PlcTrigger.Empty = True
            PlcWriteState = True
        End With
    End Sub

    Private Sub Heiden_DataReceived(sender As Object, e As Ports.SerialDataReceivedEventArgs) Handles Heiden.DataReceived
        Invoke(Sub()
                   HeidenString = Heiden.ReadExisting
                   Console.WriteLine("heiden : " + HeidenString)
               End Sub)
    End Sub

    Private Sub Hain_DataReceived(sender As Object, e As Ports.SerialDataReceivedEventArgs) Handles Hain.DataReceived
        Invoke(Sub()
                   HainString = Hain.ReadExisting
                   Console.WriteLine("hain : " + HainString)
               End Sub)
    End Sub

    Private Sub btn_send_cmd_Click(sender As Object, e As EventArgs) Handles btn_send_cmd.Click
        Heiden.Write(txt_cmd.Text + vbCr)
        txt_resp.Text = HeidenString
    End Sub
End Class
