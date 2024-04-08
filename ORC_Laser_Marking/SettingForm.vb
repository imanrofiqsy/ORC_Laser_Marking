Public Class SettingForm
    Dim Modbus = New Modbus
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
    End Sub
    Private Sub SettingForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        GetUserLevel()
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
End Class