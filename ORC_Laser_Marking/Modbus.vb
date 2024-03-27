Imports EasyModbus
Public Class Modbus
    Dim modbusClient As ModbusClient
    Dim ConnectionError As Boolean
    Public Sub OpenPort(IP As String, PORT As String)
        modbusClient = New ModbusClient(IP, Val(PORT))
        modbusClient.Connect()
    End Sub
    Public Sub ClosePort()
        modbusClient.Disconnect()
    End Sub
    Public Function _ConnectionError() As Boolean
        Return ConnectionError
    End Function
    Public Sub WriteBit(addr As Integer, bit As Integer, val As Integer)
        Dim address_val() As Integer
        address_val = modbusClient.ReadHoldingRegisters(addr, 1)

        Dim binaryString As String = Convert.ToString(address_val(0), 2).PadLeft(16, "0"c)
        binaryString = binaryString.Reverse.ToArray
        Dim temp(16)
        Dim temp_str As String
        For i As Integer = 0 To binaryString.Length - 1
            If i = bit Then
                temp(i) = val
            Else
                If binaryString(i) = "1" Then
                    temp(i) = 1
                Else
                    temp(i) = 0
                End If
            End If
            temp_str = temp_str + temp(i).ToString
        Next
        temp_str = temp_str.Reverse.ToArray
        Dim integer_val As Integer = Convert.ToInt16(temp_str.ToString, 2)

        modbusClient.WriteSingleRegister(addr, integer_val)
    End Sub
    Public Function ReadBit(addr As Integer, bit As Integer) As Integer
        Dim address_val() As Integer
        address_val = modbusClient.ReadHoldingRegisters(addr, 1)

        Dim binaryString As String = Convert.ToString(address_val(0), 2).PadLeft(16, "0"c)
        binaryString = binaryString.Reverse.ToArray
        For i As Integer = 0 To binaryString.Length - 1
            If i = bit Then
                Return Val(binaryString(i))
            End If
        Next
    End Function
    Public Function ReadDoubleInteger(addr As Integer) As Integer
        Dim address_val() As Integer
        Dim result As Integer

        address_val = modbusClient.ReadHoldingRegisters(addr, 2)
        result = (CInt(address_val(0)) And &HFFFF) Or (CInt(address_val(1)) << 16)
        Return result
    End Function
    Public Sub WriteDoubleInteger(addr As Integer, val As Int32)
        Dim values(1) As Int32
        values(0) = CInt((val >> 16) And &HFFFF)
        values(1) = CInt(val And &HFFFF)
        Dim result(1) As Integer
        result(0) = values(1)
        result(1) = values(0)
        modbusClient.WriteMultipleRegisters(addr, result)
    End Sub
    Public Function ReadFloat(startAddress As Integer) As Double
        Dim vals() As Integer = modbusClient.ReadHoldingRegisters(startAddress, 2)
        'Console.WriteLine(vals(0).ToString + " " + vals(1).ToString)
        Return ConvertDW2Float(CShort(vals(0)), CShort(vals(1)))
    End Function
    Private Function ConvertDW2Float(reg1 As Short, reg2 As Short) As Single
        Dim bytes(3) As Byte
        Dim intBytes1 As Byte() = BitConverter.GetBytes(reg2)
        Dim intBytes2 As Byte() = BitConverter.GetBytes(reg1)

        ' Assuming Float Swap format (swapping the two 16-bit registers)
        bytes(0) = intBytes2(0)
        bytes(1) = intBytes2(1)
        bytes(2) = intBytes1(0)
        bytes(3) = intBytes1(1)

        Dim result As Single = BitConverter.ToSingle(bytes, 0)
        'Console.WriteLine(result)
        Return result
    End Function
    Public Sub WriteFloat(StartAddress As Integer, Value As Single)
        Dim values() As Integer = ConvertFloat2DW(Value)
        modbusClient.WriteMultipleRegisters(StartAddress, values)
    End Sub

    Private Function ConvertFloat2DW(fval As Single) As Integer()
        Dim byVals As Byte() = BitConverter.GetBytes(fval)

        ' Swap the byte order for "Float Swap" format
        Dim bytes(3) As Byte
        bytes(0) = byVals(2)
        bytes(1) = byVals(3)
        bytes(2) = byVals(0)
        bytes(3) = byVals(1)

        ' Convert to Short array for Modbus WriteMultipleRegisters
        Dim values(1) As Short
        values(0) = BitConverter.ToInt16(bytes, 0)
        values(1) = BitConverter.ToInt16(bytes, 2)

        ' Convert to Integer array for Modbus WriteMultipleRegisters
        Dim result(1) As Integer
        result(0) = values(1)
        result(1) = values(0)

        Return result
    End Function
    Public Function ReadInteger(address As Integer) As Integer
        Dim val() As Integer = modbusClient.ReadHoldingRegisters(address, 1)
        Return val(0)
    End Function
    Public Sub WriteInteger(address As Integer, value As Integer)
        modbusClient.WriteSingleRegister(address, value)
    End Sub
End Class
