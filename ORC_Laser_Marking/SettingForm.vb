Imports System.Threading
Imports ControlBPM
Public Class SettingForm
    Dim Modbus = New Modbus
    Dim SettingThread As Thread

    Dim fullPath As String = System.AppDomain.CurrentDomain.BaseDirectory
    Dim projectFolder As String = fullPath.Replace("\ORC_Laser_Marking\bin\Debug\", "").Replace("\ORC_Laser_Marking\bin\Release\", "")
    Dim iniPath As String = projectFolder + "\config\Config.INI"
    Private Sub btn_home_Click(sender As Object, e As EventArgs) Handles btn_home.Click
        Close()
        MainForm.Show()
    End Sub
    Private Sub GetUserLevel()
        If UserLevel = 1 Then
            lbl_user.Text = "ADM"
        ElseIf UserLevel = 2 Then
            lbl_user.Text = "ENG"
        ElseIf UserLevel = 3 Then
            lbl_user.Text = "OPE"
        ElseIf UserLevel = 4 Then
            lbl_user.Text = "QUA"
        End If
    End Sub
    Private Sub DateTime_Tick(sender As Object, e As EventArgs) Handles DateTime.Tick
        lbl_date.Text = Date.Now.ToString("dd-MM-yyyy")
        lbl_curr_time.Text = Date.Now.ToString("hh:mm:ss")

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
    End Sub
    Private Sub SettingForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        GetUserLevel()
        SettingThread = New Thread(AddressOf MainLoop)
        SettingThread.Start()
        With Config
            .IP = ReadINI(iniPath, "PLC", "IP")
            .Port = ReadINI(iniPath, "PLC", "Port")
            txt_IP_PLC.Text = .IP
            txt_Port_PLC.Text = .Port
        End With
        If isConnected = True Then
            Invoke(Sub()
                       lbl_plc_ind.Text = "Connected"
                       lbl_plc_ind.BackColor = Color.LimeGreen
                   End Sub)
        End If
    End Sub
    Private Sub MainLoop()
        Do
            With MachineStatus
                If Modbus.ReadBit(.MW1000_, 0) = 1 Then
                    ind_status_1.BackColor = Color.Lime
                Else
                    ind_status_1.BackColor = Color.Red
                End If

                If Modbus.ReadBit(.MW2000_, 0) = 1 Then
                    ind_status_2.BackColor = Color.Lime
                Else
                    ind_status_2.BackColor = Color.Red
                End If

                If Modbus.ReadBit(.MW3000_, 0) = 1 Then
                    ind_status_3.BackColor = Color.Lime
                Else
                    ind_status_3.BackColor = Color.Red
                End If

                If Modbus.ReadBit(.MW4000_, 0) = 1 Then
                    ind_status_4.BackColor = Color.Lime
                Else
                    ind_status_4.BackColor = Color.Red
                End If

                If Modbus.ReadBit(.MW5000_, 0) = 1 Then
                    ind_status_5.BackColor = Color.Lime
                Else
                    ind_status_5.BackColor = Color.Red
                End If

                If Modbus.ReadBit(.MW6000_, 0) = 1 Then
                    ind_status_6.BackColor = Color.Lime
                Else
                    ind_status_6.BackColor = Color.Red
                End If
            End With
            Thread.Sleep(150)
        Loop
    End Sub
    Private Sub btn_apply_station_Click(sender As Object, e As EventArgs) Handles btn_apply_station.Click
        With MachineStatus
            If cb_enable_1.Text = "Disable" Then
                cb_left_1.Checked = False
                cb_right_1.Checked = False
                .MW1000_ = 0
            ElseIf cb_enable_1.Text = "Enable" Then
                .MW1000_ = Modbus.WriteBit(.MW1000_, 0, 1)
                If cb_left_1.Checked Then
                    .MW1000_ = Modbus.WriteBit(.MW1000_, 1, 1)
                Else
                    .MW1000_ = Modbus.WriteBit(.MW1000_, 1, 0)
                End If
                If cb_right_1.Checked Then
                    .MW1000_ = Modbus.WriteBit(.MW1000_, 2, 1)
                Else
                    .MW1000_ = Modbus.WriteBit(.MW1000_, 2, 0)
                End If
            End If
            If cb_enable_2.Text = "Disable" Then
                cb_left_2.Checked = False
                cb_right_2.Checked = False
                .MW2000_ = 0
            ElseIf cb_enable_2.Text = "Enable" Then
                .MW2000_ = Modbus.WriteBit(.MW2000_, 0, 1)
                If cb_left_2.Checked Then
                    .MW2000_ = Modbus.WriteBit(.MW2000_, 1, 1)
                Else
                    .MW2000_ = Modbus.WriteBit(.MW2000_, 1, 0)
                End If
                If cb_right_2.Checked Then
                    .MW2000_ = Modbus.WriteBit(.MW2000_, 2, 1)
                Else
                    .MW2000_ = Modbus.WriteBit(.MW2000_, 2, 0)
                End If
            End If
            If cb_enable_3.Text = "Disable" Then
                cb_left_3.Checked = False
                cb_right_3.Checked = False
                .MW3000_ = 0
            ElseIf cb_enable_3.Text = "Enable" Then
                .MW3000_ = Modbus.WriteBit(.MW3000_, 0, 1)
                If cb_left_3.Checked Then
                    .MW3000_ = Modbus.WriteBit(.MW3000_, 1, 1)
                Else
                    .MW3000_ = Modbus.WriteBit(.MW3000_, 1, 0)
                End If
                If cb_right_3.Checked Then
                    .MW3000_ = Modbus.WriteBit(.MW3000_, 2, 1)
                Else
                    .MW3000_ = Modbus.WriteBit(.MW3000_, 2, 0)
                End If
            End If
            If cb_enable_4.Text = "Disable" Then
                cb_left_4.Checked = False
                cb_right_4.Checked = False
                .MW4000_ = 0
            ElseIf cb_enable_4.Text = "Enable" Then
                .MW4000_ = Modbus.WriteBit(.MW4000_, 0, 1)
                If cb_left_4.Checked Then
                    .MW4000_ = Modbus.WriteBit(.MW4000_, 1, 1)
                Else
                    .MW4000_ = Modbus.WriteBit(.MW4000_, 1, 0)
                End If
                If cb_right_4.Checked Then
                    .MW4000_ = Modbus.WriteBit(.MW4000_, 2, 1)
                Else
                    .MW4000_ = Modbus.WriteBit(.MW4000_, 2, 0)
                End If
            End If
            If cb_enable_5.Text = "Disable" Then
                cb_left_5.Checked = False
                cb_right_5.Checked = False
                .MW5000_ = 0
            ElseIf cb_enable_5.Text = "Enable" Then
                .MW5000_ = Modbus.WriteBit(.MW5000_, 0, 1)
                If cb_left_5.Checked Then
                    .MW5000_ = Modbus.WriteBit(.MW5000_, 1, 1)
                Else
                    .MW5000_ = Modbus.WriteBit(.MW5000_, 1, 0)
                End If
                If cb_right_5.Checked Then
                    .MW5000_ = Modbus.WriteBit(.MW5000_, 2, 1)
                Else
                    .MW5000_ = Modbus.WriteBit(.MW5000_, 2, 0)
                End If
            End If
            If cb_enable_6.Text = "Disable" Then
                cb_left_6.Checked = False
                cb_right_6.Checked = False
                .MW1000_ = 0
            ElseIf cb_enable_6.Text = "Enable" Then
                .MW6000_ = Modbus.WriteBit(.MW6000_, 0, 1)
                If cb_left_6.Checked Then
                    .MW6000_ = Modbus.WriteBit(.MW6000_, 1, 1)
                Else
                    .MW6000_ = Modbus.WriteBit(.MW6000_, 1, 0)
                End If
                If cb_right_1.Checked Then
                    .MW6000_ = Modbus.WriteBit(.MW6000_, 2, 1)
                Else
                    .MW6000_ = Modbus.WriteBit(.MW6000_, 2, 0)
                End If
            End If
            PlcTrigger.EnableDisable = True
            PlcWriteState = True
        End With
    End Sub
    Private Sub btn_connect_plc_Click(sender As Object, e As EventArgs) Handles btn_connect_plc.Click
        Try
            Modbus.OpenPort(txt_IP_PLC.Text, txt_Port_PLC.Text)
            Invoke(Sub()
                       lbl_plc_ind.Text = "Connected"
                       lbl_plc_ind.BackColor = Color.LimeGreen
                   End Sub)
            IsConnected = True
        Catch ex As Exception
            MessageBox.Show("Error connecting to PLC: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            Invoke(Sub()
                       lbl_plc_ind.Text = "Disconnected"
                       lbl_plc_ind.BackColor = Color.DarkRed
                   End Sub)
            IsConnected = False
        End Try
    End Sub

    Private Sub btn_disconnect_plc_Click(sender As Object, e As EventArgs) Handles btn_disconnect_plc.Click
        Try
            Modbus.ClosePort()
            Invoke(Sub()
                       lbl_plc_ind.Text = "Disconnected"
                       lbl_plc_ind.BackColor = Color.DarkRed
                   End Sub)

            IsConnected = False
        Catch ex As Exception
            MessageBox.Show("Error disconnecting from PLC: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class