Module GlobalVariable
    Public UserLevel As Integer
    Public LoadingBarValue As Integer
    Public LoadingBarMessage As String
    Public PlcTrigger As Boolean
    Public SequenceIndex As Integer
    Public LaserTrigger As Boolean
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
        Dim AppOpen As Integer
        Dim AppRun As Integer
        Dim AppStop As Integer

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
    End Structure
End Module
