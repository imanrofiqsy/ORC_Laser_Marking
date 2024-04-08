Module GlobalVariable
    Public UserLevel As Integer
    Public LoadingBarValue As Integer
    Public LoadingBarMessage As String
    Public SequenceIndex As Integer
    Public LaserTrigger As Boolean
    Public PlcWriteState As Boolean
    Public Fest As Festo
    Public Structure Festo
        'Festo Left
        Dim MW370_ As Integer

        Dim ModPosL As Integer
        Dim TextTpositionL As Int32
        Dim TextTvelocityL As Integer
        Dim TextAPositionL As Integer
        Dim TextFaultL As Integer

        Dim IndicatorLeft As Integer
        Dim IndAxEnabledL As Integer
        Dim IndAxPosL As Integer
        Dim IndAxSpL As Integer
        Dim IndAxAckL As Integer
        Dim IndAxRefL As Integer
        Dim IndAxWarnL As Integer
        Dim IndAxErrorL As Integer
        Dim IndLockL As Integer
        Dim IndErrorL As Integer

        'Festo Right
        Dim MW380_ As Integer

        Dim ModPosR As Integer
        Dim TextTpositionR As Int32
        Dim TextTvelocityR As Integer
        Dim TextAPositionR As Integer
        Dim TextFaultR As Integer

        Dim IndicatorRight As Integer
        Dim IndAxEnabledR As Integer
        Dim IndAxPosR As Integer
        Dim IndAxSpR As Integer
        Dim IndAxAckR As Integer
        Dim IndAxRefR As Integer
        Dim IndAxWarnR As Integer
        Dim IndAxErrorR As Integer
        Dim IndLockR As Integer
        Dim IndErrorR As Integer
    End Structure
    Public ProductResult As Result
    Public Structure Result
        Dim MeasurementLeft As String
        Dim MeasurementRight As String
        Dim MeasurementLeftStatus As Integer
        Dim MeasurementRightStatus As Integer
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

        Dim LaserTrigger As Boolean
        Dim TurnTable As Boolean
        Dim V101 As Boolean
        Dim V301 As Boolean
        Dim V302 As Boolean
        Dim V303 As Boolean
        Dim V304 As Boolean
        'Dim V401 As Boolean

        Dim MW4101_ As Boolean

        Dim V501 As Boolean
        Dim V502 As Boolean
        Dim V503 As Boolean
        Dim V601 As Boolean
        Dim V602 As Boolean
        Dim V603 As Boolean
        Dim MW11100_ As Boolean
        Dim References As Boolean
        Dim HeidenResult As Boolean

        'Festo
        Dim MW370_ As Boolean
        Dim MW380_ As Boolean
        Dim ModPosL As Boolean
        Dim ModPosR As Boolean
        Dim TargetPosVelL As Boolean
        Dim TargetPosVelR As Boolean

        'Camera
        Dim MW5104_ As Boolean
        Dim MW5105_ As Boolean

        'Empty
        Dim Empty As Boolean
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

        'Current Cav number for each station
        Dim CavityST1 As Integer
        Dim CavityST2 As Integer
        Dim CavityST3 As Integer
        Dim CavityST4 As Integer
        Dim CavityST5 As Integer
        Dim CavityST6 As Integer

        'Cycle Time
        Dim CycleST1 As Double
        Dim CycleST2 As Double
        Dim CycleST3 As Double
        Dim CycleST4 As Double
        Dim CycleST5 As Double
        Dim CycleST6 As Double

        'Laser
        Dim Laser As integer
        Dim LaserTrigger As Integer
        Dim LaserReset As Integer
        Dim LaserError As Integer
        Dim LaserReady As Integer
        Dim LaserBusy As Integer
        Dim LaserShutter As Integer
        Dim LaserInterlock As Integer
        Dim LaserCommandOK As Integer

        'Camera
        Dim LeftCamera As Integer
        Dim LCamReset As Integer
        Dim LCamTrigger As Integer
        Dim LCamRun As Integer
        Dim LCamReady As Integer
        Dim LCamError As Integer
        Dim LCamOK As Integer
        Dim LCamNG As Integer

        Dim RightCamera As Integer
        Dim RCamReset As Integer
        Dim RCamTrigger As Integer
        Dim RCamRun As Integer
        Dim RCamReady As Integer
        Dim RCamError As Integer
        Dim RCamOK As Integer
        Dim RCamNG As Integer
    End Structure
    Public SetCylinder As Cylinder
    Public GetCylinder As Cylinder
    Public Structure Cylinder
        Dim TurnTable As Integer
        Dim V101 As Integer
        Dim V102 As Integer
        Dim V301 As Integer
        Dim V302 As Integer
        Dim V303 As Integer
        Dim V304 As Integer

        Dim V401 As Integer
        Dim MW4101_ As Integer

        Dim MW5104_ As Integer
        Dim MW5105_ As Integer

        Dim V501 As Integer
        Dim V502 As Integer
        Dim V503 As Integer
        Dim V601 As Integer
        Dim V602 As Integer
        Dim V603 As Integer
        Dim MW1900_ As Integer
        Dim MW1900_0 As Integer
        Dim MW1900_1 As Integer
        Dim MW2900_ As Integer
        Dim MW2900_0 As Integer
        Dim MW2900_1 As Integer
        Dim MW3900_ As Integer
        Dim MW3900_0 As Integer
        Dim MW3900_1 As Integer
        Dim MW4900_ As Integer
        Dim MW4900_0 As Integer
        Dim MW4900_1 As Integer
        Dim MW5900_ As Integer
        Dim MW5900_0 As Integer
        Dim MW5900_1 As Integer
        Dim MW6900_ As Integer
        Dim MW6900_0 As Integer
        Dim MW6900_1 As Integer
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
