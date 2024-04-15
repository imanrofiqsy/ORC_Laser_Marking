Public Class AlarmForm

    Dim TableAlarm As New DataTable("Alarm")
    Private Sub DateTime_Tick(sender As Object, e As EventArgs) Handles DateTime.Tick
        lbl_curr_time.Text = Date.Now.ToString("dd-MM-yyyy")
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

    Private Sub AlarmForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        GetUserLevel()

        TableAlarm.Columns.Add("Alarm List", GetType(String))
        TableAlarm.Columns.Add("Date Time", GetType(Date))
        LoadTable()
    End Sub

    Private Sub btn_refresh_Click(sender As Object, e As EventArgs) Handles btn_refresh.Click
        LoadTable()
    End Sub

    Private Sub LoadTable()
        Dim TableMessage As String = ""
        With MachineAlarm
            If .DoorLock1 Then
                TableMessage = "Door Lock 1 Open"
                AddDataRow(TableAlarm, TableMessage, Now)
            End If
            If .DoorLock2 Then
                TableMessage = "Door Lock 2 Open"
                AddDataRow(TableAlarm, TableMessage, Now)
            End If
            If .DoorLock3 Then
                TableMessage = "Door Lock 3 Open"
                AddDataRow(TableAlarm, TableMessage, Now)
            End If
            If .DoorLock4 Then
                TableMessage = "Door Lock 4 Open"
                AddDataRow(TableAlarm, TableMessage, Now)
            End If
            If .Curtain Then
                TableMessage = "Curtain Sensor Discrepancy"
                AddDataRow(TableAlarm, TableMessage, Now)
            End If
            If .V101 Then
                TableMessage = "V101 Discrepancy"
                AddDataRow(TableAlarm, TableMessage, Now)
            End If
            If .V301 Then
                TableMessage = "V301 Discrepancy"
                AddDataRow(TableAlarm, TableMessage, Now)
            End If
            If .V302 Then
                TableMessage = "V302 Discrepancy"
                AddDataRow(TableAlarm, TableMessage, Now)
            End If
            If .V303 Then
                TableMessage = "V303 Discrepancy"
                AddDataRow(TableAlarm, TableMessage, Now)
            End If
            If .V304 Then
                TableMessage = "V304 Discrepancy"
                AddDataRow(TableAlarm, TableMessage, Now)
            End If
            If .V401 Then
                TableMessage = "V401 Discrepancy"
                AddDataRow(TableAlarm, TableMessage, Now)
            End If
            If .LaserError Then
                TableMessage = "ST4 Laser Error please check the laser"
                AddDataRow(TableAlarm, TableMessage, Now)
            End If
            If .ShutterLaserError Then
                TableMessage = "ST4 Shutter Laser Error please check or reset"
                AddDataRow(TableAlarm, TableMessage, Now)
            End If
            If .InterlockLaserError Then
                TableMessage = "ST4 Interlock Laser Error please check or reset"
                AddDataRow(TableAlarm, TableMessage, Now)
            End If
            If .V501 Then
                TableMessage = "V501 Discrepancy"
                AddDataRow(TableAlarm, TableMessage, Now)
            End If
            If .V502 Then
                TableMessage = "V502 Discrepancy"
                AddDataRow(TableAlarm, TableMessage, Now)
            End If
            If .V503 Then
                TableMessage = "V503 Discrepancy"
                AddDataRow(TableAlarm, TableMessage, Now)
            End If
            If .CamLeftError Then
                TableMessage = "ST5 Left Camera Error please reset the camera"
                AddDataRow(TableAlarm, TableMessage, Now)
            End If
            If .CamRightError Then
                TableMessage = "ST5 Right Camera Error please reset the camera"
                AddDataRow(TableAlarm, TableMessage, Now)
            End If
            If .V601 Then
                TableMessage = "V601 Discrepancy"
                AddDataRow(TableAlarm, TableMessage, Now)
            End If
            If .V602 Then
                TableMessage = "V602 Discrepancy"
                AddDataRow(TableAlarm, TableMessage, Now)
            End If
            If .V603 Then
                TableMessage = "V603 Discrepancy"
                AddDataRow(TableAlarm, TableMessage, Now)
            End If
            DataGridView1.DataSource = TableAlarm
        End With
    End Sub

    Private Sub AddDataRow(Table As DataTable, List As String, TimeStamp As Date)
        Dim TableRow As DataRow = Table.NewRow
        TableRow("Alarm List") = List
        TableRow("Date Time") = TimeStamp
        Table.Rows.Add(TableRow)
    End Sub
End Class