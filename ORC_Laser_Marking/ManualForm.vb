Imports System.Threading
Public Class ManualForm
    Dim ManualThread As Thread
    Private Sub DateTime_Tick(sender As Object, e As EventArgs) Handles DateTime.Tick
        lbl_curr_time.Text = Date.Now.ToString("dd-MM-yyyy")
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

    Private Sub ManualForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        GetUserLevel()
        ManualThread = New Thread(AddressOf MainLoop)
        ManualThread.Start()
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
            Thread.Sleep(150)
        Loop
    End Sub

    Private Sub btn_v101_fw_MouseDown(sender As Object, e As MouseEventArgs) Handles btn_v101_fw.MouseDown
        SetCylinder.V101 = 1
        PlcTrigger.V101 = True
    End Sub

    Private Sub btn_v101_fw_MouseUp(sender As Object, e As MouseEventArgs) Handles btn_v101_fw.MouseUp
        SetCylinder.V101 = 0
        PlcTrigger.V101 = True
    End Sub

    Private Sub btn_v101_bw_MouseDown(sender As Object, e As MouseEventArgs) Handles btn_v101_bw.MouseDown
        SetCylinder.V101 = 2
        PlcTrigger.V101 = True
    End Sub

    Private Sub btn_v101_bw_MouseUp(sender As Object, e As MouseEventArgs) Handles btn_v101_bw.MouseUp
        SetCylinder.V101 = 0
        PlcTrigger.V101 = True
    End Sub

    Private Sub Button3_MouseDown(sender As Object, e As MouseEventArgs) Handles Button3.MouseDown
        SetCylinder.TurnTable = 1
        PlcTrigger.TurnTable = True
    End Sub

    Private Sub Button3_MouseUp(sender As Object, e As MouseEventArgs) Handles Button3.MouseUp
        SetCylinder.TurnTable = 0
        PlcTrigger.TurnTable = True
    End Sub
End Class