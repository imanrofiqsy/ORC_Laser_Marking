Public Class LoadingForm
    Private Sub LoadingForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Enabled = True
        Cursor = Cursors.WaitCursor
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        LoadingBar.Value = LoadingBarValue
        lbl_loading.Text = LoadingBarMessage
    End Sub
End Class