Imports System.Data.SqlClient
Public Class DatabaseConnection
    Public Connection As SqlConnection
    Public Function Connect() As Boolean
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
            If Connection.State = ConnectionState.Closed Then Connection.Open() Else Connection.Close()
            Return True
        Catch ex As Exception
            MsgBox("Database Connection Error -> " + ex.Message)
            Return False
        End Try
    End Function
End Class
