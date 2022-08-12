Module SD4000_CMD
    Public Const initialization As String = "@RII"
    Public Const getInstrumentStatus As String = "@RIS"  'example) @RIS,1,1,0,0,0,1
    '                                                       -#1 digit :  Zero-cal. status
    '                                                       -#2 digit : standard-cal. status
    '                                                       -#3 digit :  Zero-cal stand attached or not
    '                                                       -#4 digit : standard-cal. stand attached or not
    '                                                       -#5 digit : don't know , default =0
    '                                                       -#6 digit : sample hole(plate) size, 1:LAV, 2:MAV, 3:SAV , when changed both cal.status set to "0" (1st and 2nd digit) 

    Public Const getInstrumentInfo As String = "@RPI"
    Public Const getCalibrationNo As String = "@RSP,1"
    Public Const getCalibrationSN As String = "@RSP,3"
    Public Const getCalibrationDate As String = "@RSP,4"
    Public Const setMeasurementMode As String = "@WPM,"    'example) @WPM,1,1,1,2,2,100.0
    '                                                        - default setting : @WPM,1,1,1,2,1                    
    '                                                        -#1 digit : 1:Reflection, Transmission
    '                                                        -#2 digit : default=1
    '                                                        -#3 digit : default=1
    '                                                        -#4 digit : 1:SCE, 2:SCI, 3:SCE+SCI
    '                                                        -#5 digit : 1: UV in, 2: UV out, 3: UV in+out
    Public Const doZeroCalibration As String = "@FZ"
    Public Const doStandardCalibration As String = "@FS"
    Public Const doMeasurement As String = "@FM"
    Public Const getMeasurementMode As String = "@RPM"
    'Public Function getInstrumentStatus_1stDigit()  'example) @RIS,1,1,0,0,0,1 -#1 digit :  Zero-cal. status
    'End Function
    'Public Function getInstrumentStatus_2ndDigit() 'example) @RIS,1,1,0,0,0,1 -#2 digit : standard-cal. status
    'End Function
    'Public Function getInstrumentStatus_3rdDigit() 'example) @RIS,1,1,0,0,0,1   -#3 digit :  Zero-cal stand attached or not
    'End Function
    'Public Function getInstrumentStatus_4rdDigit()  'example) @RIS,1,1,0,0,0,1   -#4 digit : standard-cal. stand attached or not
    'End Function
    'Public Function getInstrumentStatus_5rdDigit()  'example) @RIS,1,1,0,0,0,1    -#5 digit : don't know , default =0
    'End Function
    'Public Function getInstrumentStatus_6rdDigit() 'example) @RIS,1,1,0,0,0,1   -#6 digit : sample hole(plate) size, 1:LAV, 2:MAV, 3:SAV , when changed both cal.status set to "0" (1st and 2nd digit) 
    'End Function
    Function setMeasurementMode_1stDigit(reflectionORtransmission As String) As Integer 'example) @WPM,1,1,1,2,2,100.0  -#1 digit : 1:Reflection, 2: Transmission
        If Trim(reflectionORtransmission) = "Reflectance" Then
            setMeasurementMode_1stDigit = 1
        ElseIf Trim(reflectionORtransmission) = "Transmittance"
            setMeasurementMode_1stDigit = 2
        Else
            MsgBox("MeasurementMethod Wrong")
            setMeasurementMode_1stDigit = 0
        End If
    End Function
    Public Function setMeasurementMode_2ndDigit() As Integer 'example) @WPM,1,1,1,2,2,100.0    -#2 digit : default=1
        setMeasurementMode_2ndDigit = 1
    End Function
    Public Function setMeasurementMode_3rdDigit() As Integer 'example) @WPM,1,1,1,2,2,100.0    -#3 digit : aperture_size : LAV =1, MAV=2, SAV=3
        Dim retStr As Integer

        If Form_Main.sample_Hole_Size = "LAV" Then
            retStr = 1
        ElseIf Form_Main.sample_Hole_Size = "MAV" Then
            retStr = 2
        ElseIf Form_Main.sample_Hole_Size = "SAV" Then
            retStr = 3
        Else
            retStr = 0
        End If

        Return retStr

    End Function
    Public Function setMeasurementMode_4thDigit(sceORsci As String) As Integer   'example) @WPM,1,1,1,2,2,100.0      -#4 digit : 1:SCE, 2:SCI, 3:SCE+SCI
        If sceORsci = "SCE" Then
            setMeasurementMode_4thDigit = 1
        ElseIf sceORsci = "SCI" Then
            setMeasurementMode_4thDigit = 2
        ElseIf sceORsci = "SCE+SCI"
            setMeasurementMode_4thDigit = 3
        Else sceORsci = "SCI+SCE"
            setMeasurementMode_4thDigit = 3
        End If
    End Function
    Public Function setMeasurementMode_5thDigit(uvinORout As String) As Integer 'example) @WPM,1,1,1,2,2,100.0      -#5 digit : 1: UV in, 2: UV out, 3: UV in+out
        If uvinORout = "In" Then
            setMeasurementMode_5thDigit = 1
        ElseIf uvinORout = "Out" Then
            setMeasurementMode_5thDigit = 2
        ElseIf uvinORout = "In+Out" Then
            setMeasurementMode_5thDigit = 3
        Else uvinORout = "Out+In"
            setMeasurementMode_5thDigit = 3
        End If
    End Function
    Public Function getCalibrationResult(inputCMD As String, retMSG As String) As Boolean
        If inputCMD = doZeroCalibration Then
            If retMSG = "@FZ,02" Or retMSG = "@FZ,00" Then   '@FZ,02
                getCalibrationResult = True
            ElseIf retMSG = "@FZ,07" Then
                MsgBox("Too Bright, place ""Black cover""")
                getCalibrationResult = False
            Else
                MsgBox("Zero Cal. Error : " & retMSG)
                getCalibrationResult = False
            End If
        ElseIf inputCMD = doStandardCalibration Then
            If retMSG = "@FS,00" Or retMSG = "@FS,01" Then
                getCalibrationResult = True
            ElseIf retMSG = "@FS,08" Then
                MsgBox("Too Dark, place ""Standard(White) cover""")
                getCalibrationResult = False
            Else
                MsgBox("Standard Cal. Error : " & retMSG)
                getCalibrationResult = False
            End If
        Else
            MsgBox("UNDEFINED CALIBRATION COMMAND")
            Return False
        End If
    End Function

End Module
