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

        TextBox1.Text = "ALARM : " + AlarmMessage
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
    Dim LastAlarm(23) As Integer
    Private Sub LoadTable()
        Dim TableMessage As String = ""
        With MachineAlarm
            If .DoorLock1 <> LastAlarm(1) Then
                LastAlarm(1) = .DoorLock1
                If .DoorLock1 Then
                    TableMessage = "Door Lock 1 Open"
                    AddDataRow(TableAlarm, TableMessage, Now)
                Else

                End If
            End If
            If .DoorLock2 <> LastAlarm(2) Then
                LastAlarm(2) = .DoorLock2
                If .DoorLock2 Then
                    TableMessage = "Door Lock 2 Open"
                    AddDataRow(TableAlarm, TableMessage, Now)
                End If
            End If
            If .DoorLock3 <> LastAlarm(3) Then
                LastAlarm(3) = .DoorLock3
                If .DoorLock3 Then
                    TableMessage = "Door Lock 3 Open"
                    AddDataRow(TableAlarm, TableMessage, Now)
                End If
            End If
            If .DoorLock4 <> LastAlarm(4) Then
                LastAlarm(4) = .DoorLock4
                If .DoorLock4 Then
                    TableMessage = "Door Lock 4 Open"
                    AddDataRow(TableAlarm, TableMessage, Now)
                End If
            End If
            If .Curtain <> LastAlarm(5) Then
                LastAlarm(5) = .Curtain
                If .Curtain Then
                    TableMessage = "Curtain Sensor Discrepancy"
                    AddDataRow(TableAlarm, TableMessage, Now)
                End If
            End If
            If .V101 <> LastAlarm(6) Then
                LastAlarm(6) = .Curtain
                If .V101 Then
                    TableMessage = "V101 Discrepancy"
                    AddDataRow(TableAlarm, TableMessage, Now)
                End If
            End If
            If .V301 <> LastAlarm(7) Then
                LastAlarm(7) = .V301
                If .V301 Then
                    TableMessage = "V301 Discrepancy"
                    AddDataRow(TableAlarm, TableMessage, Now)
                End If
            End If
            If .V302 <> LastAlarm(8) Then
                LastAlarm(8) = .V302
                If .V302 Then
                    TableMessage = "V302 Discrepancy"
                    AddDataRow(TableAlarm, TableMessage, Now)
                End If
            End If
            If .V303 <> LastAlarm(9) Then
                LastAlarm(9) = .V303
                If .V303 Then
                    TableMessage = "V303 Discrepancy"
                    AddDataRow(TableAlarm, TableMessage, Now)
                End If
            End If
            If .V304 <> LastAlarm(10) Then
                LastAlarm(10) = .V304
                If .V304 Then
                    TableMessage = "V304 Discrepancy"
                    AddDataRow(TableAlarm, TableMessage, Now)
                End If
            End If
            If .V401 <> LastAlarm(11) Then
                LastAlarm(11) = .V401
                If .V401 Then
                    TableMessage = "V401 Discrepancy"
                    AddDataRow(TableAlarm, TableMessage, Now)
                End If
            End If
            If .LaserError <> LastAlarm(12) Then
                LastAlarm(12) = .LaserError
                If .LaserError Then
                    TableMessage = "ST4 Laser Error please check the laser"
                    AddDataRow(TableAlarm, TableMessage, Now)
                End If
            End If
            If .ShutterLaserError <> LastAlarm(13) Then
                LastAlarm(13) = .ShutterLaserError
                If .ShutterLaserError Then
                    TableMessage = "ST4 Shutter Laser Error please check or reset"
                    AddDataRow(TableAlarm, TableMessage, Now)
                End If
            End If
            If .InterlockLaserError <> LastAlarm(14) Then
                LastAlarm(14) = .InterlockLaserError
                If .InterlockLaserError Then
                    TableMessage = "ST4 Interlock Laser Error please check or reset"
                    AddDataRow(TableAlarm, TableMessage, Now)
                End If
            End If
            If .V501 <> LastAlarm(15) Then
                LastAlarm(15) = .V501
                If .V501 Then
                    TableMessage = "V501 Discrepancy"
                    AddDataRow(TableAlarm, TableMessage, Now)
                End If
            End If
            If .V502 <> LastAlarm(16) Then
                LastAlarm(16) = .V502
                If .V502 Then
                    TableMessage = "V502 Discrepancy"
                    AddDataRow(TableAlarm, TableMessage, Now)
                End If
            End If
            If .V503 <> LastAlarm(17) Then
                LastAlarm(17) = .V503
                If .V503 Then
                    TableMessage = "V503 Discrepancy"
                    AddDataRow(TableAlarm, TableMessage, Now)
                End If
            End If
            If .CamLeftError <> LastAlarm(18) Then
                LastAlarm(18) = .CamLeftError
                If .CamLeftError Then
                    TableMessage = "ST5 Left Camera Error please reset the camera"
                    AddDataRow(TableAlarm, TableMessage, Now)
                End If
            End If
            If .CamRightError <> LastAlarm(19) Then
                LastAlarm(19) = .CamRightError
                If .CamRightError Then
                    TableMessage = "ST5 Right Camera Error please reset the camera"
                    AddDataRow(TableAlarm, TableMessage, Now)
                End If
            End If
            If .V601 <> LastAlarm(20) Then
                LastAlarm(20) = .V601
                If .V601 Then
                    TableMessage = "V601 Discrepancy"
                    AddDataRow(TableAlarm, TableMessage, Now)
                End If
            End If
            If .V602 <> LastAlarm(21) Then
                LastAlarm(21) = .V602
                If .V602 Then
                    TableMessage = "V602 Discrepancy"
                    AddDataRow(TableAlarm, TableMessage, Now)
                End If
            End If
            If .V603 <> LastAlarm(22) Then
                LastAlarm(22) = .V603
                If .V603 Then
                    TableMessage = "V603 Discrepancy"
                    AddDataRow(TableAlarm, TableMessage, Now)
                End If
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