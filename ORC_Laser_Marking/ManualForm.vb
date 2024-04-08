Imports System.Threading
Public Class ManualForm
    Dim ManualThread As Thread
    Dim Modbus = New Modbus
    Private Sub DateTime_Tick(sender As Object, e As EventArgs) Handles DateTime.Tick
        lbl_date.Text = Date.Now.ToString("dd-MM-yyyy")
        lbl_curr_time.Text = Date.Now.ToString("hh:mm:ss")
    End Sub
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
    Private Sub PostGB(station As Integer)
        If station = 1 Then
            gb_ST1.Location = New Size(138, 169)
            gb_ST1.Size = New Point(1074, 540)
            gb_ST1.BringToFront()
            gb_ST1.Visible = True
        Else
            gb_ST1.Visible = False
        End If
        If station = 2 Then
            gb_ST2.Location = New Size(138, 169)
            gb_ST2.Size = New Point(1074, 540)
            gb_ST2.BringToFront()
            gb_ST2.Visible = True
        Else
            gb_ST2.Visible = False
        End If
        If station = 3 Then
            gb_ST3.Location = New Size(138, 169)
            gb_ST3.Size = New Point(1074, 540)
            gb_ST3.BringToFront()
            tab_ST3.BringToFront()
            gb_ST3.Visible = True
        Else
            gb_ST3.Visible = False
        End If
        If station = 4 Then
            gb_ST4.Location = New Size(138, 169)
            gb_ST4.Size = New Point(1074, 540)
            gb_ST4.BringToFront()
            gb_ST4.Visible = True
        Else
            gb_ST4.Visible = False
        End If
        If station = 5 Then
            gb_ST5.Location = New Size(138, 169)
            gb_ST5.Size = New Point(1074, 540)
            gb_ST5.BringToFront()
            gb_ST5.Visible = True
        Else
            gb_ST5.Visible = False
        End If
        If station = 6 Then
            gb_ST6.Location = New Size(138, 169)
            gb_ST6.Size = New Point(1074, 540)
            gb_ST6.BringToFront()
            gb_ST6.Visible = True
        Else
            gb_ST6.Visible = False
        End If
    End Sub
    Private Sub ManualForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        GetUserLevel()
        ManualThread = New Thread(AddressOf MainLoop)
        ManualThread.Start()
        PostGB(1)
    End Sub
    Private Sub MainLoop()
        Do
            If GetCylinder.V101 = 1 Then
                ind_v101_max.Image = My.Resources.led_green_on
            Else
                ind_v101_max.Image = My.Resources.led_red_on
            End If

            If GetCylinder.V101 = 2 Then
                ind_v101_min.Image = My.Resources.led_green_on
            Else
                ind_v101_min.Image = My.Resources.led_red_on
            End If

            'Cyl3
            If GetCylinder.V301 = 1 Then
                ind_v301_max.Image = My.Resources.led_green_on
            Else
                ind_v301_max.Image = My.Resources.led_red_on
            End If

            If GetCylinder.V301 = 2 Then
                ind_v301_min.Image = My.Resources.led_green_on
            Else
                ind_v301_min.Image = My.Resources.led_red_on
            End If

            If GetCylinder.V302 = 1 Then
                ind_v302_max.Image = My.Resources.led_green_on
            Else
                ind_v302_max.Image = My.Resources.led_red_on
            End If

            If GetCylinder.V302 = 2 Then
                ind_v302_min.Image = My.Resources.led_green_on
            Else
                ind_v302_min.Image = My.Resources.led_red_on
            End If

            If GetCylinder.V303 = 1 Then
                ind_v303_max.Image = My.Resources.led_green_on
            Else
                ind_v303_max.Image = My.Resources.led_red_on
            End If

            If GetCylinder.V303 = 2 Then
                ind_v303_min.Image = My.Resources.led_green_on
            Else
                ind_v303_min.Image = My.Resources.led_red_on
            End If

            If GetCylinder.V304 = 1 Then
                ind_v304_max.Image = My.Resources.led_green_on
            Else
                ind_v304_max.Image = My.Resources.led_red_on
            End If

            If GetCylinder.V304 = 2 Then
                ind_v304_min.Image = My.Resources.led_green_on
            Else
                ind_v304_min.Image = My.Resources.led_red_on
            End If

            'Cyl 4
            If GetCylinder.V401 = 1 Then
                ind_v401_max.Image = My.Resources.led_green_on
            Else
                ind_v401_max.Image = My.Resources.led_red_on
            End If

            If GetCylinder.V401 = 2 Then
                ind_v401_min.Image = My.Resources.led_green_on
            Else
                ind_v401_min.Image = My.Resources.led_red_on
            End If

            'Cyl 5
            If GetCylinder.V501 = 1 Then
                ind_v501_max.Image = My.Resources.led_green_on
            Else
                ind_v501_max.Image = My.Resources.led_red_on
            End If

            If GetCylinder.V501 = 2 Then
                ind_v501_min.Image = My.Resources.led_green_on
            Else
                ind_v501_min.Image = My.Resources.led_red_on
            End If

            If GetCylinder.V502 = 1 Then
                ind_v502_max.Image = My.Resources.led_green_on
            Else
                ind_v502_max.Image = My.Resources.led_red_on
            End If

            If GetCylinder.V502 = 2 Then
                ind_v502_min.Image = My.Resources.led_green_on
            Else
                ind_v502_min.Image = My.Resources.led_red_on
            End If

            If GetCylinder.V503 = 1 Then
                ind_v503_max.Image = My.Resources.led_green_on
            Else
                ind_v503_max.Image = My.Resources.led_red_on
            End If

            If GetCylinder.V503 = 2 Then
                ind_v503_min.Image = My.Resources.led_green_on
            Else
                ind_v503_min.Image = My.Resources.led_red_on
            End If

            'Camera ST5 Indicator##################################
            'Camera Run
            If MachineStatus.LCamRun = 1 Then
                ind_Lcam_run.Image = My.Resources.led_green_on
            Else
                ind_Lcam_run.Image = My.Resources.led_red_on
            End If

            If MachineStatus.RCamRun = 1 Then
                ind_Rcam_run.Image = My.Resources.led_green_on
            Else
                ind_Rcam_run.Image = My.Resources.led_red_on
            End If

            'Camera Ready
            If MachineStatus.LCamReady = 1 Then
                ind_Lcam_ready.Image = My.Resources.led_green_on
            Else
                ind_Lcam_ready.Image = My.Resources.led_red_on
            End If

            If MachineStatus.RCamReady = 1 Then
                ind_Rcam_ready.Image = My.Resources.led_green_on
            Else
                ind_Rcam_ready.Image = My.Resources.led_red_on
            End If

            'Camera Error
            If MachineStatus.LCamError = 1 Then
                ind_Lcam_error.Image = My.Resources.led_green_on
            Else
                ind_Lcam_error.Image = My.Resources.led_red_on
            End If

            If MachineStatus.RCamError = 1 Then
                ind_Rcam_error.Image = My.Resources.led_green_on
            Else
                ind_Rcam_error.Image = My.Resources.led_red_on
            End If

            'Camera OK
            If MachineStatus.LCamOK = 1 Then
                ind_Lcam_ok.Image = My.Resources.led_green_on
            Else
                ind_Lcam_ok.Image = My.Resources.led_red_on
            End If

            If MachineStatus.RCamOK = 1 Then
                ind_Rcam_ok.Image = My.Resources.led_green_on
            Else
                ind_Rcam_ok.Image = My.Resources.led_red_on
            End If

            'Camera NG
            If MachineStatus.LCamNG = 1 Then
                ind_Lcam_ng.Image = My.Resources.led_green_on
            Else
                ind_Lcam_ng.Image = My.Resources.led_red_on
            End If

            If MachineStatus.RCamNG = 1 Then
                ind_Rcam_ng.Image = My.Resources.led_green_on
            Else
                ind_Rcam_ng.Image = My.Resources.led_red_on
            End If

            'Cyl6
            If GetCylinder.V601 = 1 Then
                ind_v601_max.Image = My.Resources.led_green_on
            Else
                ind_v601_max.Image = My.Resources.led_red_on
            End If

            If GetCylinder.V601 = 2 Then
                ind_v601_min.Image = My.Resources.led_green_on
            Else
                ind_v601_min.Image = My.Resources.led_red_on
            End If

            If GetCylinder.V602 = 1 Then
                ind_v602_max.Image = My.Resources.led_green_on
            Else
                ind_v602_max.Image = My.Resources.led_red_on
            End If

            If GetCylinder.V602 = 2 Then
                ind_v602_min.Image = My.Resources.led_green_on
            Else
                ind_v602_min.Image = My.Resources.led_red_on
            End If

            If GetCylinder.V603 = 1 Then
                ind_v603_max.Image = My.Resources.led_green_on
            Else
                ind_v603_max.Image = My.Resources.led_red_on
            End If

            If GetCylinder.V603 = 2 Then
                ind_v603_min.Image = My.Resources.led_green_on
            Else
                ind_v603_min.Image = My.Resources.led_red_on
            End If

            'Festo############################################
            'Indicator Ax Enabled
            If Fest.IndAxEnabledL Then
                ind_Lfesto_ax_enabled.Image = My.Resources.led_green_on
            Else
                ind_Lfesto_ax_enabled.Image = My.Resources.led_red_on
            End If

            If Fest.IndAxEnabledR Then
                ind_Rfesto_ax_enabled.Image = My.Resources.led_green_on
            Else
                ind_Rfesto_ax_enabled.Image = My.Resources.led_red_on
            End If

            'Indicator Ax Pos
            If Fest.IndAxPosL Then
                ind_Lfesto_ax_pos.Image = My.Resources.led_green_on
            Else
                ind_Lfesto_ax_pos.Image = My.Resources.led_red_on
            End If

            If Fest.IndAxPosR Then
                ind_Rfesto_ax_pos.Image = My.Resources.led_green_on
            Else
                ind_Rfesto_ax_pos.Image = My.Resources.led_red_on
            End If

            'Indicator Ax Sp
            If Fest.IndAxSpL Then
                ind_Lfesto_ax_sp.Image = My.Resources.led_green_on
            Else
                ind_Lfesto_ax_sp.Image = My.Resources.led_red_on
            End If

            If Fest.IndAxSpR Then
                ind_Rfesto_ax_sp.Image = My.Resources.led_green_on
            Else
                ind_Rfesto_ax_sp.Image = My.Resources.led_red_on
            End If

            'Indicator Ax Ack
            If Fest.IndAxAckL Then
                ind_Lfesto_ax_ack.Image = My.Resources.led_green_on
            Else
                ind_Lfesto_ax_ack.Image = My.Resources.led_red_on
            End If

            If Fest.IndAxAckR Then
                ind_Rfesto_ax_ack.Image = My.Resources.led_green_on
            Else
                ind_Rfesto_ax_ack.Image = My.Resources.led_red_on
            End If

            'Indicator Ax Ref
            If Fest.IndAxRefL Then
                ind_Lfesto_ax_ref.Image = My.Resources.led_green_on
            Else
                ind_Lfesto_ax_ref.Image = My.Resources.led_red_on
            End If

            If Fest.IndAxRefR Then
                ind_Rfesto_ax_ref.Image = My.Resources.led_green_on
            Else
                ind_Rfesto_ax_ref.Image = My.Resources.led_red_on
            End If

            'Indicator Ax Warn
            If Fest.IndAxWarnL Then
                ind_Lfesto_ax_warn.Image = My.Resources.led_green_on
            Else
                ind_Lfesto_ax_warn.Image = My.Resources.led_red_on
            End If

            If Fest.IndAxWarnR Then
                ind_Rfesto_ax_warn.Image = My.Resources.led_green_on
            Else
                ind_Rfesto_ax_warn.Image = My.Resources.led_red_on
            End If

            'Indicator Ax Error
            If Fest.IndAxErrorL Then
                ind_Lfesto_ax_error.Image = My.Resources.led_green_on
            Else
                ind_Lfesto_ax_error.Image = My.Resources.led_red_on
            End If

            If Fest.IndAxErrorR Then
                ind_Rfesto_ax_error.Image = My.Resources.led_green_on
            Else
                ind_Rfesto_ax_error.Image = My.Resources.led_red_on
            End If

            'Indicator Ax LockOut
            If Fest.IndLockL Then
                ind_Lfesto_lock.Image = My.Resources.led_green_on
            Else
                ind_Lfesto_lock.Image = My.Resources.led_red_on
            End If

            If Fest.IndLockR Then
                ind_Rfesto_lock.Image = My.Resources.led_green_on
            Else
                ind_Rfesto_lock.Image = My.Resources.led_red_on
            End If

            'Indicator Error
            If Fest.IndErrorL Then
                ind_Lfesto_error.Image = My.Resources.led_green_on
            Else
                ind_Lfesto_error.Image = My.Resources.led_red_on
            End If

            If Fest.IndErrorR Then
                ind_Rfesto_error.Image = My.Resources.led_green_on
            Else
                ind_Rfesto_error.Image = My.Resources.led_red_on
            End If

            ''Text Box Actual Position
            'Invoke(Sub()
            '           txt_Lfesto_aposition.Text = Fest.TextAPositionL
            '       End Sub)

            'Invoke(Sub()
            '           txt_Rfesto_aposition.Text = Fest.TextAPositionR
            '       End Sub)

            ''Text Box Fault Number
            'Invoke(Sub()
            '           txt_Lfesto_fault.Text = Fest.TextFaultL
            '       End Sub)

            'Invoke(Sub()
            '           txt_Rfesto_fault.Text = Fest.TextFaultR
            '       End Sub)

            If IsHandleCreated Then
                ' Access controls using Invoke or BeginInvoke
                Invoke(Sub()
                           txt_Lfesto_aposition.Text = Fest.TextAPositionL
                           txt_Rfesto_aposition.Text = Fest.TextAPositionR
                           txt_Lfesto_fault.Text = Fest.TextFaultL
                           txt_Rfesto_fault.Text = Fest.TextFaultR
                           lbl_cav_1.Text = MachineStatus.CavityST1
                           lbl_cav_2.Text = MachineStatus.CavityST2
                           lbl_cav_3.Text = MachineStatus.CavityST3
                           lbl_cav_4.Text = MachineStatus.CavityST4
                           lbl_cav_5.Text = MachineStatus.CavityST5
                           lbl_cav_6.Text = MachineStatus.CavityST6
                           lbl_cyc_1.Text = MachineStatus.CycleST1
                           lbl_cyc_2.Text = MachineStatus.CycleST2
                           lbl_cyc_3.Text = MachineStatus.CycleST3
                           lbl_cyc_4.Text = MachineStatus.CycleST4
                           lbl_cyc_5.Text = MachineStatus.CycleST5
                           lbl_cyc_6.Text = MachineStatus.CycleST6
                       End Sub)
            Else
                ' Handle the case where the handle is not created yet
                ' You can choose to retry or defer the operation
            End If

            'Laser ST4 Indicator######################################
            'Laser Error
            If MachineStatus.LaserError = 1 Then
                ind_laser_error.Image = My.Resources.led_green_on
            Else
                ind_laser_error.Image = My.Resources.led_red_on
            End If

            'Laser Busy
            If MachineStatus.LaserReady = 1 Then
                ind_laser_ready.Image = My.Resources.led_green_on
            Else
                ind_laser_ready.Image = My.Resources.led_red_on
            End If

            'Laser Busy
            If MachineStatus.LaserBusy = 1 Then
                ind_laser_busy.Image = My.Resources.led_green_on
            Else
                ind_laser_busy.Image = My.Resources.led_red_on
            End If

            'Laser Shutter
            If MachineStatus.LaserShutter = 1 Then
                ind_laser_shutter.Image = My.Resources.led_green_on
            Else
                ind_laser_shutter.Image = My.Resources.led_red_on
            End If

            'Laser Interlock
            If MachineStatus.LaserInterlock = 1 Then
                ind_laser_interlock.Image = My.Resources.led_green_on
            Else
                ind_laser_interlock.Image = My.Resources.led_red_on
            End If

            'Laser Command OK
            If MachineStatus.LaserCommandOK = 1 Then
                ind_laser_command.Image = My.Resources.led_green_on
            Else
                ind_laser_command.Image = My.Resources.led_red_on
            End If

            Thread.Sleep(150)
        Loop
    End Sub

    Private Sub btn_v101_fw_MouseDown(sender As Object, e As MouseEventArgs) Handles btn_v101_fw.MouseDown
        SetCylinder.V101 = 1
        PlcTrigger.V101 = True
        PlcWriteState = True
    End Sub

    Private Sub btn_v101_fw_MouseUp(sender As Object, e As MouseEventArgs) Handles btn_v101_fw.MouseUp
        SetCylinder.V101 = 0
        PlcTrigger.V101 = True
        PlcWriteState = True
    End Sub

    Private Sub btn_v101_bw_MouseDown(sender As Object, e As MouseEventArgs) Handles btn_v101_bw.MouseDown
        SetCylinder.V101 = 2
        PlcTrigger.V101 = True
        PlcWriteState = True
    End Sub

    Private Sub btn_v101_bw_MouseUp(sender As Object, e As MouseEventArgs) Handles btn_v101_bw.MouseUp
        SetCylinder.V101 = 0
        PlcTrigger.V101 = True
        PlcWriteState = True
    End Sub

    Private Sub Button3_MouseDown(sender As Object, e As MouseEventArgs) Handles Button3.MouseDown
        SetCylinder.TurnTable = 1
        PlcTrigger.TurnTable = True
        PlcWriteState = True
    End Sub

    Private Sub Button3_MouseUp(sender As Object, e As MouseEventArgs) Handles Button3.MouseUp
        SetCylinder.TurnTable = 0
        PlcTrigger.TurnTable = True
        PlcWriteState = True
    End Sub

    Private Sub btn_st1_Click(sender As Object, e As EventArgs) Handles btn_st1.Click
        PostGB(1)
    End Sub

    Private Sub btn_st2_Click(sender As Object, e As EventArgs) Handles btn_st2.Click
        PostGB(2)
    End Sub

    Private Sub btn_st3_Click(sender As Object, e As EventArgs) Handles btn_st3.Click
        PostGB(3)
    End Sub
    'Button Cylinder 3
    Private Sub btn_v301_fw_MouseDown(sender As Object, e As MouseEventArgs) Handles btn_v301_fw.MouseDown
        SetCylinder.V301 = 1
        PlcTrigger.V301 = True
        PlcWriteState = True
    End Sub

    Private Sub btn_v301_fw_MouseUp(sender As Object, e As MouseEventArgs) Handles btn_v301_fw.MouseUp
        SetCylinder.V301 = 0
        PlcTrigger.V301 = True
        PlcWriteState = True
    End Sub

    Private Sub btn_v301_bw_MouseDown(sender As Object, e As MouseEventArgs) Handles btn_v301_bw.MouseDown
        SetCylinder.V301 = 2
        PlcTrigger.V301 = True
        PlcWriteState = True
    End Sub

    Private Sub btn_v301_bw_MouseUp(sender As Object, e As MouseEventArgs) Handles btn_v301_bw.MouseUp
        SetCylinder.V301 = 0
        PlcTrigger.V301 = True
        PlcWriteState = True
    End Sub

    Private Sub btn_v302_fw_MouseDown(sender As Object, e As MouseEventArgs) Handles btn_v302_fw.MouseDown
        SetCylinder.V302 = 1
        PlcTrigger.V302 = True
        PlcWriteState = True
    End Sub

    Private Sub btn_v302_fw_MouseUp(sender As Object, e As MouseEventArgs) Handles btn_v302_fw.MouseUp
        SetCylinder.V302 = 0
        PlcTrigger.V302 = True
        PlcWriteState = True
    End Sub

    Private Sub btn_v302_bw_MouseDown(sender As Object, e As MouseEventArgs) Handles btn_v302_bw.MouseDown
        SetCylinder.V302 = 2
        PlcTrigger.V302 = True
        PlcWriteState = True
    End Sub

    Private Sub btn_v302_bw_MouseUp(sender As Object, e As MouseEventArgs) Handles btn_v302_bw.MouseUp
        SetCylinder.V302 = 0
        PlcTrigger.V302 = True
        PlcWriteState = True
    End Sub

    Private Sub btn_v303_fw_MouseDown(sender As Object, e As MouseEventArgs) Handles btn_v303_fw.MouseDown
        SetCylinder.V303 = 1
        PlcTrigger.V303 = True
        PlcWriteState = True
    End Sub

    Private Sub btn_v303_fw_MouseUp(sender As Object, e As MouseEventArgs) Handles btn_v303_fw.MouseUp
        SetCylinder.V303 = 0
        PlcTrigger.V303 = True
        PlcWriteState = True
    End Sub

    Private Sub btn_v303_bw_MouseDown(sender As Object, e As MouseEventArgs) Handles btn_v303_bw.MouseDown
        SetCylinder.V303 = 2
        PlcTrigger.V303 = True
        PlcWriteState = True
    End Sub

    Private Sub btn_v303_bw_MouseUp(sender As Object, e As MouseEventArgs) Handles btn_v303_bw.MouseUp
        SetCylinder.V303 = 0
        PlcTrigger.V303 = True
        PlcWriteState = True
    End Sub

    Private Sub btn_v304_fw_MouseDown(sender As Object, e As MouseEventArgs) Handles btn_v304_fw.MouseDown
        SetCylinder.V304 = 1
        PlcTrigger.V304 = True
        PlcWriteState = True
    End Sub

    Private Sub btn_v304_fw_MouseUp(sender As Object, e As MouseEventArgs) Handles btn_v304_fw.MouseUp
        SetCylinder.V304 = 0
        PlcTrigger.V304 = True
        PlcWriteState = True
    End Sub

    Private Sub btn_v304_bw_MouseDown(sender As Object, e As MouseEventArgs) Handles btn_v304_bw.MouseDown
        SetCylinder.V304 = 2
        PlcTrigger.V304 = True
        PlcWriteState = True
    End Sub

    Private Sub btn_v304_bw_MouseUp(sender As Object, e As MouseEventArgs) Handles btn_v304_bw.MouseUp
        SetCylinder.V304 = 0
        PlcTrigger.V304 = True
        PlcWriteState = True
    End Sub
    'Button Cylinder 4
    Private Sub btn_v401_fw_MouseDown(sender As Object, e As MouseEventArgs) Handles btn_v401_fw.MouseDown
        With SetCylinder
            .MW4101_ = Modbus.WriteBit(.MW4101_, 0, 1)
        End With
        PlcTrigger.MW4101_ = True
        PlcWriteState = True
    End Sub

    Private Sub btn_v401_fw_MouseUp(sender As Object, e As MouseEventArgs) Handles btn_v401_fw.MouseUp
        With SetCylinder
            .MW4101_ = Modbus.WriteBit(.MW4101_, 0, 0)
        End With
        PlcTrigger.MW4101_ = True
        PlcWriteState = True
    End Sub

    Private Sub btn_v401_bw_MouseDown(sender As Object, e As MouseEventArgs) Handles btn_v401_bw.MouseDown
        With SetCylinder
            .MW4101_ = Modbus.WriteBit(.MW4101_, 1, 1)
        End With
        PlcTrigger.MW4101_ = True
        PlcWriteState = True
    End Sub

    Private Sub btn_v401_bw_MouseUp(sender As Object, e As MouseEventArgs) Handles btn_v401_bw.MouseUp
        With SetCylinder
            .MW4101_ = Modbus.WriteBit(.MW4101_, 1, 2)
        End With
        PlcTrigger.MW4101_ = True
        PlcWriteState = True
    End Sub

    'Laser Button ST4
    Private Sub btn_laser_trigger_MouseDown(sender As Object, e As MouseEventArgs) Handles btn_laser_trigger.MouseDown
        With SetCylinder
            .MW4101_ = Modbus.WriteBit(.MW4101_, 2, 1)
        End With
        PlcTrigger.MW4101_ = True
        PlcWriteState = True
    End Sub

    Private Sub btn_laser_trigger_MouseUp(sender As Object, e As MouseEventArgs) Handles btn_laser_trigger.MouseUp
        With SetCylinder
            .MW4101_ = Modbus.WriteBit(.MW4101_, 2, 0)
        End With
        PlcTrigger.MW4101_ = True
        PlcWriteState = True
    End Sub

    Private Sub btn_laser_reset_MouseDown(sender As Object, e As MouseEventArgs) Handles btn_laser_reset.MouseDown
        With SetCylinder
            .MW4101_ = Modbus.WriteBit(.MW4101_, 4, 1)
        End With
        PlcTrigger.MW4101_ = True
        PlcWriteState = True
    End Sub

    Private Sub btn_laser_reset_MouseUp(sender As Object, e As MouseEventArgs) Handles btn_laser_reset.MouseUp
        With SetCylinder
            .MW4101_ = Modbus.WriteBit(.MW4101_, 4, 0)
        End With
        PlcTrigger.MW4101_ = True
        PlcWriteState = True
    End Sub

    Private Sub btn_send_laser_Mouse_Down(sender As Object, e As EventArgs) Handles btn_send_laser.MouseDown
        MainForm.sendLaserString(txt_laser_char.Text)
        With SetCylinder
            .MW4101_ = Modbus.WriteBit(.MW4101_, 6, 1)
        End With
        PlcTrigger.MW4101_ = True
        PlcWriteState = True
    End Sub
    Private Sub btn_send_laser_Mouse_Up(sender As Object, e As EventArgs) Handles btn_send_laser.MouseUp
        With SetCylinder
            .MW4101_ = Modbus.WriteBit(.MW4101_, 6, 0)
        End With
        PlcTrigger.MW4101_ = True
        PlcWriteState = True
    End Sub
    'Button Cylinder 6
    Private Sub btn_v601_fw_MouseDown(sender As Object, e As MouseEventArgs) Handles btn_v601_fw.MouseDown
        SetCylinder.V601 = 1
        PlcTrigger.V601 = True
        PlcWriteState = True
    End Sub

    Private Sub btn_v601_fw_MouseUp(sender As Object, e As MouseEventArgs) Handles btn_v601_fw.MouseUp
        SetCylinder.V601 = 0
        PlcTrigger.V601 = True
        PlcWriteState = True
    End Sub

    Private Sub btn_v601_bw_MouseDown(sender As Object, e As MouseEventArgs) Handles btn_v601_bw.MouseDown
        SetCylinder.V601 = 2
        PlcTrigger.V601 = True
        PlcWriteState = True
    End Sub

    Private Sub btn_v601_bw_MouseUp(sender As Object, e As MouseEventArgs) Handles btn_v601_bw.MouseUp
        SetCylinder.V601 = 0
        PlcTrigger.V601 = True
        PlcWriteState = True
    End Sub

    Private Sub btn_v602_fw_MouseDown(sender As Object, e As MouseEventArgs) Handles btn_v602_fw.MouseDown
        SetCylinder.V602 = 1
        PlcTrigger.V602 = True
        PlcWriteState = True
    End Sub

    Private Sub btn_v602_fw_MouseUp(sender As Object, e As MouseEventArgs) Handles btn_v602_fw.MouseUp
        SetCylinder.V602 = 0
        PlcTrigger.V602 = True
        PlcWriteState = True
    End Sub

    Private Sub btn_v602_bw_MouseDown(sender As Object, e As MouseEventArgs) Handles btn_v602_bw.MouseDown
        SetCylinder.V602 = 2
        PlcTrigger.V602 = True
        PlcWriteState = True
    End Sub

    Private Sub btn_v602_bw_MouseUp(sender As Object, e As MouseEventArgs) Handles btn_v602_bw.MouseUp
        SetCylinder.V602 = 0
        PlcTrigger.V602 = True
        PlcWriteState = True
    End Sub

    Private Sub btn_v603_fw_MouseDown(sender As Object, e As MouseEventArgs) Handles btn_v603_fw.MouseDown
        SetCylinder.V603 = 1
        PlcTrigger.V603 = True
        PlcWriteState = True
    End Sub

    Private Sub btn_v603_fw_MouseUp(sender As Object, e As MouseEventArgs) Handles btn_v603_fw.MouseUp
        SetCylinder.V603 = 0
        PlcTrigger.V603 = True
        PlcWriteState = True
    End Sub

    Private Sub btn_v603_bw_MouseDown(sender As Object, e As MouseEventArgs) Handles btn_v603_bw.MouseDown
        SetCylinder.V603 = 2
        PlcTrigger.V603 = True
        PlcWriteState = True
    End Sub

    Private Sub btn_v603_bw_MouseUp(sender As Object, e As MouseEventArgs) Handles btn_v603_bw.MouseUp
        SetCylinder.V603 = 0
        PlcTrigger.V603 = True
        PlcWriteState = True
    End Sub
    'Festo Button#####################################################
    'Enable Drive
    Private Sub cbx_enableL_CheckedChanged(sender As Object, e As EventArgs) Handles cbx_enableL.CheckedChanged
        If cbx_enableL.Checked = True Then
            With Fest
                .MW370_ = Modbus.WriteBit(.MW370_, 0, 1)
            End With
            PlcTrigger.MW370_ = True
            PlcWriteState = True
        Else
            With Fest
                .MW370_ = Modbus.WriteBit(.MW370_, 0, 0)
            End With
            PlcTrigger.MW370_ = True
            PlcWriteState = True
        End If
    End Sub
    Private Sub cbx_enableR_CheckedChanged(sender As Object, e As EventArgs) Handles cbx_enableR.CheckedChanged
        If cbx_enableR.Checked = True Then
            With Fest
                .MW380_ = Modbus.WriteBit(.MW380_, 0, 1)
            End With
            PlcTrigger.MW380_ = True
            PlcWriteState = True
        Else
            With Fest
                .MW380_ = Modbus.WriteBit(.MW380_, 0, 0)
            End With
            PlcTrigger.MW380_ = True
            PlcWriteState = True
        End If
    End Sub
    'Button Stop
    Private Sub btn_Lfesto_stop_MouseDown(sender As Object, e As MouseEventArgs) Handles btn_Lfesto_stop.MouseDown
        With Fest
            .MW370_ = Modbus.WriteBit(.MW370_, 1, 1)
        End With
        PlcTrigger.MW370_ = True
        PlcWriteState = True
    End Sub

    Private Sub btn_Lfesto_stop_MouseUp(sender As Object, e As MouseEventArgs) Handles btn_Lfesto_stop.MouseUp
        With Fest
            .MW370_ = Modbus.WriteBit(.MW370_, 1, 0)
        End With
        PlcTrigger.MW370_ = True
        PlcWriteState = True
    End Sub

    Private Sub btn_Rfesto_stop_MouseDown(sender As Object, e As MouseEventArgs) Handles btn_Rfesto_stop.MouseDown
        With Fest
            .MW380_ = Modbus.WriteBit(.MW380_, 1, 1)
        End With
        PlcTrigger.MW380_ = True
        PlcWriteState = True
    End Sub

    Private Sub btn_Rfesto_stop_MouseUp(sender As Object, e As MouseEventArgs) Handles btn_Rfesto_stop.MouseUp
        With Fest
            .MW380_ = Modbus.WriteBit(.MW380_, 1, 0)
        End With
        PlcTrigger.MW380_ = True
        PlcWriteState = True
    End Sub
    'Button Clear
    Private Sub btn_Lfesto_clear_MouseDown(sender As Object, e As MouseEventArgs) Handles btn_Lfesto_clear.MouseDown
        With Fest
            .MW370_ = Modbus.WriteBit(.MW370_, 2, 1)
        End With
        PlcTrigger.MW370_ = True
        PlcWriteState = True
    End Sub

    Private Sub btn_Lfesto_clear_MouseUp(sender As Object, e As MouseEventArgs) Handles btn_Lfesto_clear.MouseUp
        With Fest
            .MW370_ = Modbus.WriteBit(.MW370_, 2, 0)
        End With
        PlcTrigger.MW370_ = True
        PlcWriteState = True
    End Sub

    Private Sub btn_Rfesto_clear_MouseDown(sender As Object, e As MouseEventArgs) Handles btn_Rfesto_clear.MouseDown
        With Fest
            .MW380_ = Modbus.WriteBit(.MW380_, 2, 1)
        End With
        PlcTrigger.MW380_ = True
        PlcWriteState = True
    End Sub

    Private Sub btn_Rfesto_clear_MouseUp(sender As Object, e As MouseEventArgs) Handles btn_Rfesto_clear.MouseUp
        With Fest
            .MW380_ = Modbus.WriteBit(.MW380_, 2, 0)
        End With
        PlcTrigger.MW380_ = True
        PlcWriteState = True
    End Sub

    'Button Ack
    Private Sub btn_Lfesto_ack_MouseDown(sender As Object, e As MouseEventArgs) Handles btn_Lfesto_ack.MouseDown, btn_apply_mode_pos_left.MouseDown, btn_apply_pos_vel_left.MouseDown
        With Fest
            .MW370_ = Modbus.WriteBit(.MW370_, 3, 1)
        End With
        PlcTrigger.MW370_ = True
        PlcWriteState = True
    End Sub

    Private Sub btn_Lfesto_ack_MouseUp(sender As Object, e As MouseEventArgs) Handles btn_Lfesto_ack.MouseUp, btn_apply_mode_pos_left.MouseUp, btn_apply_pos_vel_left.MouseUp
        With Fest
            .MW370_ = Modbus.WriteBit(.MW370_, 3, 0)
        End With
        PlcTrigger.MW370_ = True
        PlcWriteState = True
    End Sub

    Private Sub btn_Rfesto_ack_MouseDown(sender As Object, e As MouseEventArgs) Handles btn_Rfesto_ack.MouseDown
        With Fest
            .MW380_ = Modbus.WriteBit(.MW380_, 3, 1)
        End With
        PlcTrigger.MW380_ = True
        PlcWriteState = True
    End Sub

    Private Sub btn_Rfesto_ack_MouseUp(sender As Object, e As MouseEventArgs) Handles btn_Rfesto_ack.MouseUp
        With Fest
            .MW380_ = Modbus.WriteBit(.MW380_, 3, 0)
        End With
        PlcTrigger.MW380_ = True
        PlcWriteState = True
    End Sub

    'Button Go
    Private Sub btn_Lfesto_go_MouseDown(sender As Object, e As MouseEventArgs) Handles btn_Lfesto_go.MouseDown
        With Fest
            .MW370_ = Modbus.WriteBit(.MW370_, 4, 1)
        End With
        PlcTrigger.MW370_ = True
        PlcWriteState = True
    End Sub

    Private Sub btn_Lfesto_go_MouseUp(sender As Object, e As MouseEventArgs) Handles btn_Lfesto_go.MouseUp
        With Fest
            .MW370_ = Modbus.WriteBit(.MW370_, 4, 0)
        End With
        PlcTrigger.MW370_ = True
        PlcWriteState = True
    End Sub

    Private Sub btn_Rfesto_go_MouseDown(sender As Object, e As MouseEventArgs) Handles btn_Rfesto_go.MouseDown
        With Fest
            .MW380_ = Modbus.WriteBit(.MW380_, 4, 1)
        End With
        PlcTrigger.MW380_ = True
        PlcWriteState = True
    End Sub

    Private Sub btn_Rfesto_go_MouseUp(sender As Object, e As MouseEventArgs) Handles btn_Rfesto_go.MouseUp
        With Fest
            .MW380_ = Modbus.WriteBit(.MW380_, 4, 0)
        End With
        PlcTrigger.MW380_ = True
        PlcWriteState = True
    End Sub

    'Button Jog Plus
    Private Sub btn_Lfesto_jogplus_MouseDown(sender As Object, e As MouseEventArgs) Handles btn_Lfesto_jogplus.MouseDown
        With Fest
            .MW370_ = Modbus.WriteBit(.MW370_, 5, 1)
        End With
        PlcTrigger.MW370_ = True
        PlcWriteState = True
    End Sub

    Private Sub btn_Lfesto_jogplus_MouseUp(sender As Object, e As MouseEventArgs) Handles btn_Lfesto_jogplus.MouseUp
        With Fest
            .MW370_ = Modbus.WriteBit(.MW370_, 5, 0)
        End With
        PlcTrigger.MW370_ = True
        PlcWriteState = True
    End Sub

    Private Sub btn_Rfesto_jogplus_MouseDown(sender As Object, e As MouseEventArgs) Handles btn_Rfesto_jogplus.MouseDown
        With Fest
            .MW380_ = Modbus.WriteBit(.MW380_, 5, 1)
        End With
        PlcTrigger.MW380_ = True
        PlcWriteState = True
    End Sub

    Private Sub btn_Rfesto_jogplus_MouseUp(sender As Object, e As MouseEventArgs) Handles btn_Rfesto_jogplus.MouseUp
        With Fest
            .MW380_ = Modbus.WriteBit(.MW380_, 5, 0)
        End With
        PlcTrigger.MW380_ = True
        PlcWriteState = True
    End Sub

    'Button Jog Min
    Private Sub btn_Lfesto_jogmin_MouseDown(sender As Object, e As MouseEventArgs) Handles btn_Lfesto_jogmin.MouseDown
        With Fest
            .MW370_ = Modbus.WriteBit(.MW370_, 6, 1)
        End With
        PlcTrigger.MW370_ = True
        PlcWriteState = True
    End Sub

    Private Sub btn_Lfesto_jogmin_MouseUp(sender As Object, e As MouseEventArgs) Handles btn_Lfesto_jogmin.MouseUp
        With Fest
            .MW370_ = Modbus.WriteBit(.MW370_, 6, 0)
        End With
        PlcTrigger.MW370_ = True
        PlcWriteState = True
    End Sub

    Private Sub btn_Rfesto_jogmin_MouseDown(sender As Object, e As MouseEventArgs) Handles btn_Rfesto_jogmin.MouseDown
        With Fest
            .MW380_ = Modbus.WriteBit(.MW380_, 6, 1)
        End With
        PlcTrigger.MW380_ = True
        PlcWriteState = True
    End Sub

    Private Sub btn_Rfesto_jogmin_MouseUp(sender As Object, e As MouseEventArgs) Handles btn_Rfesto_jogmin.MouseUp
        With Fest
            .MW380_ = Modbus.WriteBit(.MW380_, 6, 0)
        End With
        PlcTrigger.MW380_ = True
        PlcWriteState = True
    End Sub

    Private Sub btn_apply_mode_pos_Click(sender As Object, e As EventArgs) Handles btn_apply_mode_pos_left.Click
        With Fest
            If rdo_Lfesto_homing.Checked Then
                .ModPosL = 4
            ElseIf rdo_Lfesto_inching.Checked Then
                .ModPosL = 8
            ElseIf rdo_Lfesto_jog.Checked Then
                .ModPosL = 7
            ElseIf rdo_Lfesto_move.Checked Then
                .ModPosL = 2
            End If

            PlcTrigger.ModPosL = True
            PlcWriteState = True
        End With
    End Sub

    Private Sub btn_apply_mode_pos_right_Click(sender As Object, e As EventArgs) Handles btn_apply_mode_pos_right.Click
        With Fest
            If rdo_Rfesto_homing.Checked Then
                .ModPosR = 4
            ElseIf rdo_Rfesto_inching.Checked Then
                .ModPosR = 8
            ElseIf rdo_Rfesto_jog.Checked Then
                .ModPosR = 7
            ElseIf rdo_Rfesto_move.Checked Then
                .ModPosR = 2
            End If

            PlcTrigger.ModPosR = True
            PlcWriteState = True
        End With
    End Sub

    Private Sub btn_apply_pos_vel_Click(sender As Object, e As EventArgs) Handles btn_apply_pos_vel_left.Click
        If txt_Lfesto_tposition.Text <> "" And txt_Lfesto_tvelocity.Text <> "" Then
            With Fest
                .TextTpositionL = Convert.ToInt32(txt_Lfesto_tposition.Text)
                .TextTvelocityL = CInt(txt_Lfesto_tvelocity.Text)

                PlcTrigger.TargetPosVelL = True
                PlcWriteState = True
            End With
        End If
    End Sub

    Private Sub btn_apply_pos_vel_right_Click(sender As Object, e As EventArgs) Handles btn_apply_pos_vel_right.Click
        If txt_Rfesto_tposition.Text <> "" And txt_Rfesto_tvelocity.Text <> "" Then
            With Fest
                .TextTpositionR = Convert.ToInt32(txt_Rfesto_tposition.Text)
                .TextTvelocityR = CInt(txt_Rfesto_tvelocity.Text)

                PlcTrigger.TargetPosVelR = True
                PlcWriteState = True
            End With
        End If
    End Sub

    Private Sub btn_st4_Click(sender As Object, e As EventArgs) Handles btn_st4.Click
        PostGB(4)
    End Sub

    Private Sub btn_st5_Click(sender As Object, e As EventArgs) Handles btn_st5.Click
        PostGB(5)
    End Sub
    'Button Cylinder 5
    Private Sub btn_v501_fw_MouseDown(sender As Object, e As MouseEventArgs) Handles btn_v501_fw.MouseDown
        SetCylinder.V501 = 1
        PlcTrigger.V501 = True
        PlcWriteState = True
    End Sub

    Private Sub btn_v501_fw_MouseUp(sender As Object, e As MouseEventArgs) Handles btn_v501_fw.MouseUp
        SetCylinder.V501 = 0
        PlcTrigger.V501 = True
        PlcWriteState = True
    End Sub

    Private Sub btn_v501_bw_MouseDown(sender As Object, e As MouseEventArgs) Handles btn_v501_bw.MouseDown
        SetCylinder.V501 = 2
        PlcTrigger.V501 = True
        PlcWriteState = True
    End Sub

    Private Sub btn_v501_bw_MouseUp(sender As Object, e As MouseEventArgs) Handles btn_v501_bw.MouseUp
        SetCylinder.V501 = 0
        PlcTrigger.V501 = True
        PlcWriteState = True
    End Sub

    Private Sub btn_v502_fw_MouseDown(sender As Object, e As MouseEventArgs) Handles btn_v502_fw.MouseDown
        SetCylinder.V502 = 1
        PlcTrigger.V502 = True
        PlcWriteState = True
    End Sub

    Private Sub btn_v502_fw_MouseUp(sender As Object, e As MouseEventArgs) Handles btn_v502_fw.MouseUp
        SetCylinder.V502 = 0
        PlcTrigger.V502 = True
        PlcWriteState = True
    End Sub

    Private Sub btn_v502_bw_MouseDown(sender As Object, e As MouseEventArgs) Handles btn_v502_bw.MouseDown
        SetCylinder.V502 = 2
        PlcTrigger.V502 = True
        PlcWriteState = True
    End Sub

    Private Sub btn_v502_bw_MouseUp(sender As Object, e As MouseEventArgs) Handles btn_v502_bw.MouseUp
        SetCylinder.V502 = 0
        PlcTrigger.V502 = True
        PlcWriteState = True
    End Sub

    Private Sub btn_v503_fw_MouseDown(sender As Object, e As MouseEventArgs) Handles btn_v503_fw.MouseDown
        SetCylinder.V503 = 1
        PlcTrigger.V503 = True
        PlcWriteState = True
    End Sub

    Private Sub btn_v503_fw_MouseUp(sender As Object, e As MouseEventArgs) Handles btn_v503_fw.MouseUp
        SetCylinder.V503 = 0
        PlcTrigger.V503 = True
        PlcWriteState = True
    End Sub

    Private Sub btn_v503_bw_MouseDown(sender As Object, e As MouseEventArgs) Handles btn_v503_bw.MouseDown
        SetCylinder.V503 = 2
        PlcTrigger.V503 = True
        PlcWriteState = True
    End Sub

    Private Sub btn_v503_bw_MouseUp(sender As Object, e As MouseEventArgs) Handles btn_v503_bw.MouseUp
        SetCylinder.V503 = 0
        PlcTrigger.V503 = True
        PlcWriteState = True
    End Sub

    'Camera Button ST5
    Private Sub btn_Lcam_trigger_MouseDown(sender As Object, e As MouseEventArgs) Handles btn_Lcam_trigger.MouseDown
        With SetCylinder
            .MW5104_ = Modbus.WriteBit(.MW5104_, 2, 1)
        End With
        PlcTrigger.MW5104_ = True
        PlcWriteState = True
    End Sub

    Private Sub btn_Lcam_trigger_MouseUp(sender As Object, e As MouseEventArgs) Handles btn_Lcam_trigger.MouseUp
        With SetCylinder
            .MW5104_ = Modbus.WriteBit(.MW5104_, 2, 0)
        End With
        PlcTrigger.MW5104_ = True
        PlcWriteState = True
    End Sub

    Private Sub btn_Lcam_reset_MouseDown(sender As Object, e As MouseEventArgs) Handles btn_Lcam_reset.MouseDown
        With SetCylinder
            .MW5104_ = Modbus.WriteBit(.MW5104_, 0, 1)
        End With
        PlcTrigger.MW5104_ = True
        PlcWriteState = True
    End Sub

    Private Sub btn_Lcam_reset_MouseUp(sender As Object, e As MouseEventArgs) Handles btn_Lcam_reset.MouseUp
        With SetCylinder
            .MW5104_ = Modbus.WriteBit(.MW5104_, 0, 0)
        End With
        PlcTrigger.MW5104_ = True
        PlcWriteState = True
    End Sub

    Private Sub btn_Rcam_trigger_MouseDown(sender As Object, e As MouseEventArgs) Handles btn_Rcam_trigger.MouseDown
        With SetCylinder
            .MW5105_ = Modbus.WriteBit(.MW5105_, 2, 1)
        End With
        PlcTrigger.MW5105_ = True
        PlcWriteState = True
    End Sub

    Private Sub btn_Rcam_trigger_MouseUp(sender As Object, e As MouseEventArgs) Handles btn_Rcam_trigger.MouseUp
        With SetCylinder
            .MW5105_ = Modbus.WriteBit(.MW5105_, 2, 0)
        End With
        PlcTrigger.MW5105_ = True
        PlcWriteState = True
    End Sub

    Private Sub btn_Rcam_reset_MouseDown(sender As Object, e As MouseEventArgs) Handles btn_Rcam_reset.MouseDown
        With SetCylinder
            .MW5105_ = Modbus.WriteBit(.MW5105_, 0, 1)
        End With
        PlcTrigger.MW5105_ = True
        PlcWriteState = True
    End Sub

    Private Sub btn_Rcam_reset_MouseUp(sender As Object, e As MouseEventArgs) Handles btn_Rcam_reset.MouseUp
        With SetCylinder
            .MW5105_ = Modbus.WriteBit(.MW5105_, 0, 0)
        End With
        PlcTrigger.MW5105_ = True
        PlcWriteState = True
    End Sub

    Private Sub btn_st6_Click(sender As Object, e As EventArgs) Handles btn_st6.Click
        PostGB(6)
    End Sub
End Class