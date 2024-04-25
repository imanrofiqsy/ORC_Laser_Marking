Imports System.Data.SqlClient
Module DatabaseConnection
    Public Connection As SqlConnection
    Public Sub Connect()
        Try
            Dim database As String
            With Config
                database = "Data Source=" & .dbHostName & "\SQLEXPRESS;
                initial catalog=" & .dbDatabase & ";
                User ID=" & .dbUsername & ";
                Password=" & .dbPassword & ";
                MultipleActiveResultSets=true"
            End With
            Connection = New SqlConnection(database)
            If Connection.State = ConnectionState.Closed Then Connection.Open() ' Else Connection.Close()
        Catch ex As Exception
            MsgBox("Database Connection Error -> " + ex.Message)
        End Try
    End Sub
End Module
