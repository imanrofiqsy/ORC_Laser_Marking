Imports System.Data.SqlClient
Public Class ReferencesForm
    Private Sub DateTime_Tick(sender As Object, e As EventArgs) Handles DateTime.Tick
        lbl_date.Text = Date.Now.ToString("dd-MM-yyyy")
        lbl_curr_time.Text = Date.Now.ToString("hh:mm:ss")
    End Sub
    Private Sub btn_home_Click(sender As Object, e As EventArgs) Handles btn_home.Click
        Close()
        MainForm.Show()
    End Sub

    Private Sub ReferencesForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadTable()

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
    Private Sub LoadTable()
        Call DatabaseConnection.Connect()
        Dim sc As New SqlCommand("SELECT * FROM tb_references", DatabaseConnection.Connection)
        Dim adapter As New SqlDataAdapter(sc)
        Dim ds As New DataSet

        adapter.Fill(ds)
        DataGridView1.DataSource = ds.Tables(0)
    End Sub
    Private Sub btn_add_Click(sender As Object, e As EventArgs) Handles btn_add.Click
        If txt_actuation_mode.Text <> "" And txt_camera_program.Text <> "" And txt_festo_distance_left.Text <> "" And txt_festo_distance_right.Text <> "" And txt_laser_template.Text <> "" And txt_level_distance.Text <> "" And txt_level_tolerance.Text <> "" And txt_oring_check.Text <> "" And txt_references.Text <> "" And txt_festo_speed_left.Text <> "" And txt_festo_speed_right.Text <> "" Then
            Try
                Call DatabaseConnection.Connect()
                Dim sc As New SqlCommand("INSERT INTO tb_references ([References], [Punching Mode], [Level Distance], [Level Tolerance], [Oring Check], [Festo Left Distance], [Festo Right Distance], [Festo Left Speed], [Festo Right Speed], [Laser Template Address], [Camera Program]) VALUES('" & txt_references.Text & "', '" & CInt(txt_actuation_mode.Text) & "', '" & txt_level_distance.Text.Replace(".", ",") & "', '" & txt_level_tolerance.Text.Replace(".", ",") & "', '" & txt_oring_check.Text & "', '" & Convert.ToInt32(txt_festo_distance_left.Text) & "', '" & Convert.ToInt32(txt_festo_distance_right.Text) & "', '" & CInt(txt_festo_speed_left.Text) & "', '" & CInt(txt_festo_speed_right.Text) & "', '" & CInt(txt_laser_template.Text) & "', '" & CInt(txt_camera_program.Text) & "')", DatabaseConnection.Connection)
                Dim adapter As New SqlDataAdapter(sc)
                adapter.SelectCommand.ExecuteNonQuery()
                LoadTable()
                rtb_references.SelectionColor = Color.Black
                rtb_references.AppendText(Date.Now.ToString("dd/MM/yyyy - hh:mm:ss ") + "[References] Finish add references " + Environment.NewLine)
                rtb_references.ScrollToCaret()
            Catch ex As Exception
                rtb_references.SelectionColor = Color.Red
                rtb_references.AppendText(Date.Now.ToString("dd/MM/yyyy - hh:mm:ss ") + "[References] Failed add references " + ex.Message + Environment.NewLine)
                rtb_references.ScrollToCaret()
            End Try
        End If
    End Sub

    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        Try
            Call DatabaseConnection.Connect()
            Dim sc As New SqlCommand("SELECT * FROM tb_references WHERE [References]='" & DataGridView1.CurrentCell.Value & "'", DatabaseConnection.Connection)
            Dim rd As SqlDataReader = sc.ExecuteReader
            rd.Read()

            txt_references.Text = rd.Item("References")
            txt_actuation_mode.Text = rd.Item("Punching Mode")
            txt_level_distance.Text = rd.Item("Level Distance")
            txt_level_tolerance.Text = rd.Item("Level Tolerance")
            txt_oring_check.Text = rd.Item("Oring Check")
            txt_festo_distance_left.Text = rd.Item("Festo Left Distance")
            txt_festo_distance_right.Text = rd.Item("Festo Right Distance")
            txt_festo_speed_left.Text = rd.Item("Festo Left Speed")
            txt_festo_speed_right.Text = rd.Item("Festo Right Speed")
            txt_laser_template.Text = rd.Item("Laser Template Address")
            txt_camera_program.Text = rd.Item("Camera Program")
            rtb_references.SelectionColor = Color.Black
            rtb_references.AppendText(Date.Now.ToString("dd/MM/yyyy - hh:mm:ss ") + "[References] Finish load references" + Environment.NewLine)
            rtb_references.ScrollToCaret()
        Catch ex As Exception
            rtb_references.SelectionColor = Color.Red
            rtb_references.AppendText(Date.Now.ToString("dd/MM/yyyy - hh:mm:ss ") + "[References] Failed load references " + ex.Message + Environment.NewLine)
            rtb_references.ScrollToCaret()
        End Try
    End Sub

    Private Sub btn_update_Click(sender As Object, e As EventArgs) Handles btn_update.Click
        If txt_actuation_mode.Text <> "" And txt_camera_program.Text <> "" And txt_festo_distance_left.Text <> "" And txt_festo_distance_right.Text <> "" And txt_laser_template.Text <> "" And txt_level_distance.Text <> "" And txt_level_tolerance.Text <> "" And txt_oring_check.Text <> "" And txt_references.Text <> "" And txt_festo_speed_left.Text <> "" And txt_festo_speed_right.Text <> "" Then
            Try
                Call DatabaseConnection.Connect()
                Dim sc As New SqlCommand("UPDATE tb_references SET [Punching Mode] = '" & CInt(txt_actuation_mode.Text) & "', [Level Distance] = '" & Double.Parse(txt_level_distance.Text.Replace(".", ",")) & "', [Level Tolerance] = '" & Double.Parse(txt_level_tolerance.Text.Replace(".", ",")) & "', [Oring Check] = '" & txt_oring_check.Text & "', [Festo Left Distance] = '" & Convert.ToInt32(txt_festo_distance_left.Text) & "', [Festo Right Distance] = '" & Convert.ToInt32(txt_festo_distance_right.Text) & "', [Festo Left Speed] = '" & CInt(txt_festo_speed_left.Text) & "', [Festo Right Speed] = '" & CInt(txt_festo_speed_right.Text) & "', [Laser Template Address] = '" & CInt(txt_laser_template.Text) & "', [Camera Program] = '" & CInt(txt_camera_program.Text) & "' WHERE [References] = '" & txt_references.Text & "'", DatabaseConnection.Connection)
                Dim adapter As New SqlDataAdapter(sc)
                adapter.SelectCommand.ExecuteNonQuery()
                LoadTable()
                rtb_references.SelectionColor = Color.Black
                rtb_references.AppendText(Date.Now.ToString("dd/MM/yyyy - hh:mm:ss ") + "[References] Finish update '" & txt_references.Text & "'" + Environment.NewLine)
                rtb_references.ScrollToCaret()
            Catch ex As Exception
                rtb_references.SelectionColor = Color.Red
                rtb_references.AppendText(Date.Now.ToString("dd/MM/yyyy - hh:mm:ss ") + "[References] Failed update '" & txt_references.Text & "'" + ex.Message + Environment.NewLine)
                rtb_references.ScrollToCaret()
            End Try
        End If
    End Sub

    Private Sub btn_delete_Click(sender As Object, e As EventArgs) Handles btn_delete.Click
        If txt_references.Text <> "" Then
            Try
                Call DatabaseConnection.Connect()
                Dim sc As New SqlCommand("DELETE FROM tb_references WHERE [References] = '" & txt_references.Text & "'", DatabaseConnection.Connection)
                Dim adapter As New SqlDataAdapter(sc)
                adapter.SelectCommand.ExecuteNonQuery()
                LoadTable()
                rtb_references.SelectionColor = Color.Black
                rtb_references.AppendText(Date.Now.ToString("dd/MM/yyyy - hh:mm:ss ") + "[References] Finish delete '" & txt_references.Text & "' " + Environment.NewLine)
                rtb_references.ScrollToCaret()
            Catch ex As Exception
                rtb_references.SelectionColor = Color.Red
                rtb_references.AppendText(Date.Now.ToString("dd/MM/yyyy - hh:mm:ss ") + "[References] Failed delete '" & txt_references.Text & "' " + ex.Message + Environment.NewLine)
                rtb_references.ScrollToCaret()
            End Try
        Else
            rtb_references.SelectionColor = Color.Red
            rtb_references.AppendText(Date.Now.ToString("dd/MM/yyyy - hh:mm:ss ") + "[References] Failed, Please fill References! " + Environment.NewLine)
            rtb_references.ScrollToCaret()
        End If
    End Sub
End Class