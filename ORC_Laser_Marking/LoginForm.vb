Public Class LoginForm
    Private Sub btn_login_Click(sender As Object, e As EventArgs) Handles btn_login.Click
        If cb_username.Text = "Admin" And txt_password.Text = "admin" Then
            UserLevel = 1
            Me.Close()
            MainForm.Show()
        ElseIf cb_username.Text = "Engineer" And txt_password.Text = "engineer" Then
            UserLevel = 2
            Me.Close()
            MainForm.Show()
        ElseIf cb_username.Text = "Operator" And txt_password.Text = "operator" Then
            UserLevel = 3
            Me.Close()
            MainForm.Show()
        ElseIf cb_username.Text = "Quality" And txt_password.Text = "quality" Then
            UserLevel = 4
            Me.Close()
            MainForm.Show()
        Else
            lbl_incorrect.Visible = True
        End If
    End Sub

    Private Sub btn_exit_Click(sender As Object, e As EventArgs) Handles btn_exit.Click
        End
    End Sub

    Private Sub txt_password_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_password.KeyPress
        If e.KeyChar = Chr(13) Then
            btn_login.PerformClick()
        End If
    End Sub

    Private Sub cb_username_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb_username.SelectedIndexChanged
        lbl_incorrect.Visible = False
    End Sub

    Private Sub txt_password_TextChanged(sender As Object, e As EventArgs) Handles txt_password.TextChanged
        lbl_incorrect.Visible = False
    End Sub

    Private Sub LoginForm_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        txt_password.Text = ""
        cb_username.Text = ""
    End Sub
End Class