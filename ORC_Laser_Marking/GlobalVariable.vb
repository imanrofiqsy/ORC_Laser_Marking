Module GlobalVariable
    Public UserLevel As Integer
    Public LoadingBarValue As Integer
    Public LoadingBarMessage As String
    Public SequenceIndex As Integer
    Public LaserTrigger As Boolean
    Public PlcWriteState As Boolean
    Public ProductResult As Result
    Public Structure Result
        Dim MeasurementLeft As Integer
        Dim MeasurementRight As Integer
        Dim CameraLeft As Integer
        Dim CameraRight As Integer
        Dim ProductLeft As Integer
        Dim ProductRight As Integer
    End Structure
    Public PlcSave As Save
    Public Structure Save
        Dim MW11100_ As Integer
        Dim MW11100_0 As Integer
        Dim MW11100_1 As Integer
        Dim MW11100_2 As Integer
        Dim MW11100_3 As Integer
        Dim MW11100_4 As Integer
        Dim MW11100_6 As Integer
        Dim MW11100_7 As Integer
        Dim MW11100_10 As Integer
        Dim MW11100_11 As Integer
    End Structure
    Public PlcTrigger As Trigger
    Public Structure Trigger
        'PC Status
        Dim App As Boolean

        'References
        Dim TrigLoadData As Boolean

        Dim TurnTable As Boolean
        Dim V101 As Boolean

        Dim MW11100_ As Boolean
    End Structure
    Public Enum MainSequence
        ScanRef
        ScanOP
        ScanPO
        ScanQty
        GetData
    End Enum
    Public ProductReferences As References
    Public Structure References
        Dim References As String
        Dim LaserStringData As String
        Dim LaserCharData As Char
        Dim PunchingMode As Integer
        Dim LevelDistance As Double
        Dim LevelTolerance As Double
        Dim OringCheck As Integer
        Dim FestoLeftDistance As Int32
        Dim FestoRightDistance As Int32
        Dim FestoLeftSpeed As Integer
        Dim FestoRightSpeed As Integer
        Dim LaserTemplateAddress As Integer
        Dim CameraProgram As Integer
    End Structure
    Public MachineStatus As Status
    Public Structure Status
        Dim PlcReady As Integer
        'PC Status
        Dim App As Integer

        Dim State As Integer
        Dim Mode As Integer
        Dim Qty As Integer
        Dim OutputPass As Integer
        Dim OutputFail As Integer

        'Emtying Process
        Dim EmptyRequest As Integer
        Dim EmptyBusy As Integer
        Dim EmptyFinish As Integer

        'References
        Dim TrigLoadData As Integer
        Dim LoadDataBusy As Integer
        Dim LoadDataFinish As Integer
        Dim LoadDataFail As Integer

        'General Status
        Dim MachineInitialized As Integer
    End Structure
    Public SetCylinder As Cylinder
    Public GetCylinder As Cylinder
    Public Structure Cylinder
        Dim TurnTable As Integer
        Dim V101 As Integer
        Dim V102 As Integer
    End Structure
    Public Config As MachineConfig
    Public Structure MachineConfig
        Dim IP As String
        Dim Port As String
        Dim dbHostName As String
        Dim dbDatabase As String
        Dim dbUsername As String
        Dim dbPassword As String
        Dim CountProduct As Integer
    End Structure
End Module
