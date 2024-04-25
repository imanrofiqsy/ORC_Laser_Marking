Imports System.Data.SqlClient
Public Class LogForm
    Private Sub DateTime_Tick(sender As Object, e As EventArgs) Handles DateTime.Tick
        lbl_date.Text = Date.Now.ToString("dd-MM-yyyy")
        lbl_curr_time.Text = Date.Now.ToString("hh:mm:ss")
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
    Private Sub btn_home_Click(sender As Object, e As EventArgs) Handles btn_home.Click
        Close()
        MainForm.Show()
    End Sub

    Private Sub LogForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        GetUserLevel()

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
    Private Sub LoadTable()
        Call DatabaseConnection.Connect()
        Dim sc As New SqlCommand("SELECT * FROM tb_datalog", DatabaseConnection.Connection)
        Dim adapter As New SqlDataAdapter(sc)
        Dim ds As New DataSet

        adapter.Fill(ds)
        DataGridView1.DataSource = ds.Tables(0)
    End Sub
End Class