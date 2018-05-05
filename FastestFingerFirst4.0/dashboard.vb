Imports System
Imports System.Management
Imports System.Management.Instrumentation
Imports System.Windows.Forms
Imports System.Runtime.InteropServices
Imports Microsoft.VisualBasic.PowerPacks
Imports System.Diagnostics.Stopwatch
Imports WMPLib
Imports System.IO
Imports System.ComponentModel

Module GlobalVariables1
    Public SAPI = CreateObject("SAPI.spvoice")
    Public teamnumber As Integer() = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0}
    Public last As String
    Public keyboard As Integer() = {1, 2, 3, 4, 5, 6, 7, 8, 9, 0}
    Public started = False
    Public receivedData As String = ""
End Module

Module GlobalVariables2
    Public Total_number_ports As String = "10"
End Module

Module Globalvariables3
    Public checkE As Boolean = False
    Public total_time_limit As String = "60"
    Public port_time As Double() = {360000000000, 360000000000, 360000000000, 360000000000, 360000000000, 360000000000, 360000000000, 360000000000, 360000000000, 360000000000}
End Module
Public Class Dashboard

    Dim urls As String = "C:\ask.mp3" ' create the playlist      
    Dim resetnumber As Integer = 0 'reset only when timer has been started
    Dim compute_when_stopped As Integer = 0 'compute data only when timer has been stopped
    Dim x As Boolean = False
    Dim i As Integer
    Dim checkifnoclick As Integer = 0
    Dim high As Integer = 0
    Public watch As Stopwatch = Stopwatch.StartNew()
    Dim result As Double
    Dim millisecond As Integer = 0
    Dim timecalc As Integer = 60
    Public WithEvents SerialPort As New IO.Ports.SerialPort



    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Debugger.Click
        If mm.Enabled = False Then
            Button2.BackColor = Color.Red
            SAPI.Speak("Application is not set, Press the SET APPLICATION BUTTON")
        ElseIf timertext.Text = "MM:SS:MS" Then
            SAPI.Speak("Timer not started")
        ElseIf Not Total_number_ports = "0" Then
            SAPI.Speak("Aplication is working fine!")
        End If
    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        millisecond = millisecond + 1
        If millisecond = 99 Then
            millisecond = 0
        End If
        timecalc = watch.Elapsed.TotalSeconds
        timertext.Text = String.Format("{0:00}:{1:00}:{2:00}", watch.Elapsed.Minutes, watch.Elapsed.Seconds, millisecond) 'String.Format("{00}", watch.Elapsed.Minutes) & ":" & String.Format("{00}", watch.Elapsed.Seconds) & ":" & Convert.ToInt32(Microsoft.VisualBasic.Right(microseconds, 2)) * 60
        If timecalc = total_time_limit Or watch.Elapsed.Seconds = 3600 Then
            checkE = True
            timertext.Text = String.Format("{0:00}:{1:00}:{2:00}", watch.Elapsed.Minutes, watch.Elapsed.Seconds + 1, "00")
            StopTimerButton_Click(sender, e)

        End If
    End Sub




    Public Sub SerialPortConnection(ByVal sender As String)

        If started Then
            Try
                receivedData = sender.Chars(1)
            Catch ex As Exception

            End Try
            If receivedData = 1 And port_time(0) = 360000000000 Then
                Beep()
                port_time(0) = watch.Elapsed.Seconds + watch.ElapsedMilliseconds
            ElseIf receivedData = 2 And port_time(1) = 360000000000 Then
                Beep()

                port_time(1) = watch.Elapsed.Seconds + watch.ElapsedMilliseconds
            ElseIf receivedData = 3 And port_time(2) = 360000000000 Then
                Beep()
                port_time(2) = watch.Elapsed.Seconds + watch.ElapsedMilliseconds

            ElseIf receivedData = 4 And port_time(3) = 360000000000 Then
                Beep()

                port_time(3) = watch.Elapsed.Seconds + watch.ElapsedMilliseconds
            ElseIf receivedData = 5 And port_time(4) = 360000000000 Then
                Beep()

                port_time(4) = watch.Elapsed.Seconds + watch.ElapsedMilliseconds
            ElseIf receivedData = 6 And port_time(5) = 360000000000 Then
                Beep()

                port_time(5) = watch.Elapsed.Seconds + watch.ElapsedMilliseconds

            ElseIf receivedData = 7 And port_time(6) = 360000000000 Then
                Beep()

                port_time(6) = watch.Elapsed.Seconds + watch.ElapsedMilliseconds
            ElseIf receivedData = 8 And port_time(7) = 360000000000 Then
                Beep()

                port_time(7) = watch.Elapsed.Seconds + watch.ElapsedMilliseconds

            ElseIf receivedData = 9 And port_time(8) = 360000000000 Then
                Beep()

                port_time(8) = watch.Elapsed.Seconds + watch.ElapsedMilliseconds

            ElseIf receivedData = 0 And port_time(9) = 360000000000 Then
                Beep()

                port_time(9) = watch.Elapsed.Seconds + watch.ElapsedMilliseconds

            End If
        End If
    End Sub


    Public Sub StartTimerButton_Click(sender As System.Object, e As System.EventArgs) Handles StartTimerButton.Click
        If Total_number_ports = "0" Then
            MessageBox.Show("Number of teams or keyboards keys not defined.", "Error!!!")
        ElseIf resetnumber = 1 Then
            MessageBox.Show("Timer has been elapsed for one time. Please reset me", "Reset me Please!!!")
        Else
            If mm.Text = "seconds" Then
                mm.Text = "60"
                total_time_limit = 60
                Label5.Visible = True
            End If
            'ConnectionPanel.Visible = True
            'scorecardpanel.Visible = False
            My.Computer.Audio.Stop()
            Label5.Visible = True
            timertext.Text = "00:00:00"
            Button1.Enabled = False
            process.Enabled = False
            ResetButton.Enabled = False
            Debugger.Enabled = False
            portnumbermain.Enabled = False
            portaddress.Enabled = False
            help.Enabled = False
            mm.Enabled = False
            exitwindow.Enabled = False
            compute_when_stopped = 0
            warning.Text = "Please do not click anything, except STOP Button"
            description.Text = "KKNP : Keyboard Key Not Pressed"
            detail1.Text = "KKNP"
            detail2.Text = "KKNP"
            detail3.Text = "KKNP"
            detail4.Text = "KKNP"
            detail5.Text = "KKNP"
            detail6.Text = "KKNP"
            detail7.Text = "KKNP"
            detail8.Text = "KKNP"
            detail9.Text = "KKNP"
            detail10.Text = "KKNP"
            watch.Reset()
            My.Computer.Audio.Play("C:\ask.wav", AudioPlayMode.WaitToComplete)
            If SerialPort.IsOpen Then
                'receivedData = SerialPort.ReadExisting()
                'MessageBox.Show(receivedData)
            Else
                SPSetup()
            End If
            startTimer_Click(sender, e)
        End If
    End Sub


    Public Sub ResetButton_Click(sender As System.Object, e As System.EventArgs) Handles ResetButton.Click
        If resetnumber = 0 Then
            SAPI.speak("Timer not yet started")
        ElseIf compute_when_stopped = 0 Then
            SAPI.speak("Timer is still running")
        ElseIf resetnumber = 1 Then
            Timer1.Stop()
            x = False
            checkE = False
            millisecond = 0
            process.Enabled = True
            StopTimerButton.Enabled = True
            detail1.BackColor = Color.Aquamarine
            detail2.BackColor = Color.Aquamarine
            detail3.BackColor = Color.Aquamarine
            detail4.BackColor = Color.Aquamarine
            detail5.BackColor = Color.Aquamarine
            detail6.BackColor = Color.Aquamarine
            detail7.BackColor = Color.Aquamarine
            detail8.BackColor = Color.Aquamarine
            detail9.BackColor = Color.Aquamarine
            detail10.BackColor = Color.Aquamarine
            port_time(0) = 360000000000
            port_time(1) = 360000000000
            port_time(2) = 360000000000
            port_time(3) = 360000000000
            port_time(4) = 360000000000
            port_time(5) = 360000000000
            port_time(6) = 360000000000
            port_time(7) = 360000000000
            port_time(8) = 360000000000
            port_time(9) = 360000000000
            detail1.Text = "TNS"
            detail2.Text = "TNS"
            detail3.Text = "TNS"
            detail4.Text = "TNS"
            detail5.Text = "TNS"
            detail6.Text = "TNS"
            detail7.Text = "TNS"
            detail8.Text = "TNS"
            detail9.Text = "TNS"
            detail10.Text = "TNS"
            description.Text = "TNS : Timer Not Started "


            resultTeam1.Text = "TEAM 1 = NULL"
            resultTeam2.Text = "TEAM 2 = NULL"
            resultTeam3.Text = "TEAM 3 = NULL"
            resultTeam4.Text = "TEAM 4 = NULL"
            resultTeam5.Text = "TEAM 5 = NULL"
            resultTeam6.Text = "TEAM 6 = NULL"
            resultTeam7.Text = "TEAM 7 = NULL"
            resultTeam8.Text = "TEAM 8 = NULL"
            resultTeam9.Text = "TEAM 9 = NULL"
            resultTeam10.Text = "TEAM 10 = NULL"
            timertext.Text = "MM:SS:MS"
            checkifnoclick = 0
            MessageBox.Show("Everything will be erased.", "System reset")
            resetnumber = 0
            SAPI.speak("get ready for next question")
        End If
    End Sub

    'To show help and support
    Private Sub Help_Click(sender As System.Object, e As System.EventArgs) Handles help.Click
        MessageBox.Show("Note : Download Music first " & vbCrLf & "Step 1 : Define number of Teams (i.e no. of keyboards) " & vbCrLf & "Step 2 : Define keyboard key." & vbCrLf & "Step 3 : If above steps performed correctly then a Green light is shown else a red light will be shown." & vbCrLf & "Step 4: Incase of red light, press DEBUG button to check for errors." & vbCrLf & "Step 5 : Start the timer by pressing START button, timer window will show a timer running." & vbCrLf & "Step 6 : To stop a timer press STOP button." & vbCrLf & "Step 7 : Press the COMPUTE button to process the result." & vbCrLf & "Step 8 : Press RESET SYSTEM button to bring everything back to normal state." & vbCrLf & "Step 9 : Press EXIT if you want to exit from the software." & vbCrLf & "Thank you for using our service.", "Help and Support")
    End Sub
    'credits printing

    'to exit window
    Private Sub Exitwindow_Click(sender As System.Object, e As System.EventArgs) Handles exitwindow.Click
        SAPI.speak("It was a pleasure to assist you. ")
        Application.Exit()
    End Sub
    'to display address number of ports 

    'compute data once clicked "CLICKED"
    Private Sub Process_Click(sender As System.Object, e As System.EventArgs) Handles process.Click
        If timertext.Text = "MM:SS:MS" Then
            SAPI.speak("Timer not yet started")
        ElseIf compute_when_stopped = 0 Then
            MessageBox.Show("Timer still running.", "Error!!!")
        ElseIf resetnumber = 1 Then
            process.Enabled = False
            For i = 0 To 9
                high = 0
                For j = 0 To 9
                    If port_time(high) > port_time(j) Then
                        high = j
                    End If
                Next
                If i = 0 Then
                    If port_time(high) = 360000000000 Then
                        checkifnoclick = checkifnoclick + 1
                        resultTeam1.Text = " NULL"
                    Else
                        resultTeam1.Text = "TEAM " & (high + 1) & " = " & Display(high)
                        teamnumber(i) = high + 1
                    End If
                ElseIf i = 1 Then
                    If port_time(high) = 360000000000 Then
                        checkifnoclick = checkifnoclick + 1
                        resultTeam2.Text = " NULL"
                    Else
                        resultTeam2.Text = "TEAM " & (high + 1) & " = " & Display(high)
                        teamnumber(i) = high + 1
                    End If
                ElseIf i = 2 Then
                    If port_time(high) = 360000000000 Then
                        checkifnoclick = checkifnoclick + 1
                        resultTeam3.Text = " NULL"
                    Else
                        resultTeam3.Text = "TEAM " & (high + 1) & " = " & Display(high)
                        teamnumber(i) = high + 1
                    End If
                ElseIf i = 3 Then
                    If port_time(high) = 360000000000 Then
                        checkifnoclick = checkifnoclick + 1
                        resultTeam4.Text = " NULL"
                    Else
                        resultTeam4.Text = "TEAM " & (high + 1) & " = " & Display(high)
                        teamnumber(i) = high + 1
                    End If
                ElseIf i = 4 Then
                    If port_time(high) = 360000000000 Then
                        checkifnoclick = checkifnoclick + 1
                        resultTeam5.Text = " NULL"
                    Else
                        resultTeam5.Text = "TEAM " & (high + 1) & " = " & Display(high)
                        teamnumber(i) = high + 1
                    End If
                ElseIf i = 5 Then
                    If port_time(high) = 360000000000 Then
                        checkifnoclick = checkifnoclick + 1
                        resultTeam6.Text = " NULL"
                    Else
                        resultTeam6.Text = "TEAM " & (high + 1) & " = " & Display(high)
                        teamnumber(i) = high + 1
                    End If
                ElseIf i = 6 Then
                    If port_time(high) = 360000000000 Then
                        checkifnoclick = checkifnoclick + 1
                        resultTeam7.Text = " NULL"
                    Else
                        resultTeam7.Text = "TEAM " & (high + 1) & " = " & Display(high)
                        teamnumber(i) = high + 1
                    End If
                ElseIf i = 7 Then
                    If port_time(high) = 360000000000 Then
                        checkifnoclick = checkifnoclick + 1
                        resultTeam8.Text = " NULL"
                    Else
                        resultTeam8.Text = "TEAM " & (high + 1) & " = " & Display(high)
                        teamnumber(i) = high + 1
                    End If
                ElseIf i = 8 Then
                    If port_time(high) = 360000000000 Then
                        checkifnoclick = checkifnoclick + 1
                        resultTeam9.Text = " NULL"
                    Else
                        resultTeam9.Text = "TEAM " & (high + 1) & " = " & Display(high)
                        teamnumber(i) = high + 1
                    End If
                ElseIf i = 9 Then
                    If port_time(high) = 360000000000 Then
                        checkifnoclick = checkifnoclick + 1
                        resultTeam10.Text = " NULL"
                    Else
                        resultTeam10.Text = "TEAM " & (high + 1) & " = " & Display(high)
                        teamnumber(i) = high + 1
                    End If

                End If
                port_time(high) = 360000000000
            Next
            If Not checkifnoclick = 3 Or checkifnoclick = 2 Or checkifnoclick = 1 Or checkifnoclick = 4 Or checkifnoclick = 5 Or checkifnoclick = 6 Or checkifnoclick = 7 Or checkifnoclick = 8 Or checkifnoclick = 9 Or checkifnoclick = 10 Then
                BackgroundWorker1.RunWorkerAsync()
            End If
        End If
    End Sub

    Private Function Display(ByVal x As Integer) As String
        Select Case x
            Case 0
                Return port_time(0) / 1000
            Case 1
                Return port_time(1) / 1000
            Case 2
                Return port_time(2) / 1000
            Case 3
                Return port_time(3) / 1000
            Case 4

                Return port_time(4) / 1000
            Case 5
                Return port_time(5) / 1000
            Case 6
                Return port_time(6) / 1000
            Case 7
                Return port_time(7) / 1000
            Case 8
                Return port_time(8) / 1000
            Case 9
                Return port_time(9) / 1000
            Case Else
                Return "NULL"
        End Select
    End Function
    Public stopwav As String = "C:\stop.wav" ' create the playlist   
    Public startwav As String = "C:\start.wav"
    Private Sub StopTimerButton_Click(sender As Object, e As EventArgs) Handles StopTimerButton.Click
        If timertext.Text = "MM:SS:MS" Then
            MessageBox.Show("Timer not yet started.", "Error!!!")
        Else

            My.Computer.Audio.Stop() 'to stop start sound
            Player.URL = stopwav
            Player.controls.play()
            started = False ' set keypress event to false
            resetnumber = 1
            millisecond = 0
            Button1.Enabled = True
            process.Enabled = True
            ResetButton.Enabled = True
            Debugger.Enabled = True
            Label5.Visible = True
            mm.Enabled = True
            portnumbermain.Enabled = True
            portaddress.Enabled = True
            help.Enabled = True
            exitwindow.Enabled = True
            watch.Stop()
            watch.Reset()
            checkE = True
            warning.Text = ""
            compute_when_stopped = 1
            Timer1.Stop()
            StopTimerButton.Enabled = False

        End If
    End Sub


    Private Sub Wait(ByVal interval As Integer)
        Dim sw As New Stopwatch
        sw.Start()
        Do While sw.ElapsedMilliseconds < interval
            Application.DoEvents()
        Loop
        sw.Stop()
    End Sub
    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            If mm.Text = "seconds" Then
                mm.Text = "60"
                Label5.Visible = True
                total_time_limit = 60
            Else
                Label5.Visible = True
                total_time_limit = Convert.ToUInt32(mm.Text)
                Label4.Visible = True
                Wait(1000)
                Label4.Visible = False
            End If
        Catch ex As Exception
            MessageBox.Show("Enter a number!!!")
        End Try

    End Sub


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Button2.BackColor = Color.White
        StartTimerButton.Enabled = True
        StopTimerButton.Enabled = True
        ResetButton.Enabled = True
        process.Enabled = True
        Button1.Enabled = True
        mm.Enabled = True
        portcolour1.BackColor = Color.DeepSkyBlue
        portcolour2.BackColor = Color.DeepSkyBlue
        portcolour3.BackColor = Color.DeepSkyBlue
        portcolour4.BackColor = Color.DeepSkyBlue
        portcolour5.BackColor = Color.DeepSkyBlue
        portcolour6.BackColor = Color.DeepSkyBlue
        portcolour7.BackColor = Color.DeepSkyBlue
        portcolour8.BackColor = Color.DeepSkyBlue
        portcolour9.BackColor = Color.DeepSkyBlue
        portcolour10.BackColor = Color.DeepSkyBlue
        description.Text = "TNS : Timer Not Started "
        Button2.Enabled = False
        SAPI.Speak("All set")
    End Sub
    Public Player As WindowsMediaPlayer = New WindowsMediaPlayer

    Private Sub BackgroundWorker1_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        If Not resultTeam1.Text = "TEAM NAME = NULL" Then
            SAPI.speak("Result computed")

        End If
    End Sub

    'Download audio files from link provided
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        MessageBox.Show("Press OK to download the audio files now. ", "Audio Files link")
        System.Diagnostics.Process.Start("https://drive.google.com/open?id=0B5aObC_fxmDnWEsyM1RJd3lqZUE", "default")
        MessageBox.Show("Copy those files in C:\ drive before doing anything", "File location to set")
        Button5.BackColor = Color.White
    End Sub


    'show scorecard panel or connection panel
    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'scorecardpanel.Visible = False
        'ConnectionPanel.Visible = True
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'scorecardpanel.Visible = True
        'ConnectionPanel.Visible = False
    End Sub

    Public ROUND As Integer
    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Try
            If Convert.ToInt32(TextBox1.Text) Then
                SAPI.SPEAK("Round " & Convert.ToInt32(TextBox1.Text) & " started, All the best")
            End If
        Catch ex As Exception
            MessageBox.Show("Should be a Number.")
        End Try
    End Sub


    ''' <summary>
    ''' Add score to a particular team
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles addScoreButton.Click
        Try
            Select Case Convert.ToDouble(TEAMADD.Text)
                Case 1
                    TEAM1.Text = Convert.ToString(Convert.ToDouble(TEAM1.Text) + Convert.ToDouble(ADDSCORE.Text))
                    addScoreLabel.Text = "ADDED"
                Case 2
                    TEAM2.Text = Convert.ToString(Convert.ToDouble(TEAM2.Text) + Convert.ToDouble(ADDSCORE.Text))
                    addScoreLabel.Text = "ADDED"
                Case 3
                    TEAM3.Text = Convert.ToString(Convert.ToDouble(TEAM3.Text) + Convert.ToDouble(ADDSCORE.Text))
                    addScoreLabel.Text = "ADDED"
                Case 4
                    TEAM4.Text = Convert.ToString(Convert.ToDouble(TEAM4.Text) + Convert.ToDouble(ADDSCORE.Text))
                    addScoreLabel.Text = "ADDED"
                Case 5
                    TEAM5.Text = Convert.ToString(Convert.ToDouble(TEAM5.Text) + Convert.ToDouble(ADDSCORE.Text))
                    addScoreLabel.Text = "ADDED"
                Case 6
                    TEAM6.Text = Convert.ToString(Convert.ToDouble(TEAM6.Text) + Convert.ToDouble(ADDSCORE.Text))
                    addScoreLabel.Text = "ADDED"
                Case 7
                    TEAM7.Text = Convert.ToString(Convert.ToDouble(TEAM7.Text) + Convert.ToDouble(ADDSCORE.Text))
                    addScoreLabel.Text = "ADDED"
                Case 8
                    TEAM8.Text = Convert.ToString(Convert.ToDouble(TEAM8.Text) + Convert.ToDouble(ADDSCORE.Text))
                    addScoreLabel.Text = "ADDED"
                Case 9
                    TEAM9.Text = Convert.ToString(Convert.ToDouble(TEAM9.Text) + Convert.ToDouble(ADDSCORE.Text))
                    addScoreLabel.Text = "ADDED"
                Case 10
                    TEAM10.Text = Convert.ToString(Convert.ToDouble(TEAM10.Text) + Convert.ToDouble(ADDSCORE.Text))
                    addScoreLabel.Text = "ADDED"
                Case Else
                    addScoreLabel.Text = "ERROR"
            End Select
        Catch ex As Exception
            MessageBox.Show("Enter correct team number and score!!!")
        End Try

    End Sub

    ''' <summary>
    ''' Reset score of all teams
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles resetScore.Click
        Try
            ADDSCORE.Text = ""
            addScoreLabel.Text = ""
            removeLabel.Text = ""
            TEAMADD.Text = ""
            REMOVESCORE.Text = ""
            TEAMREMOVE.Text = ""
        Catch ex As Exception
            MessageBox.Show("Looks like some error!!!" + Convert.ToString(ex))
        End Try

    End Sub

    ''' <summary>
    ''' Remove score from a particular team 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles removeScoreButton.Click
        Try
            Select Case Convert.ToDouble(TEAMREMOVE.Text)
                Case 1
                    TEAM1.Text = Convert.ToString(Convert.ToDouble(TEAM1.Text) - Convert.ToDouble(REMOVESCORE.Text))
                    removeLabel.Text = "REMOVED"
                Case 2
                    TEAM2.Text = Convert.ToString(Convert.ToDouble(TEAM2.Text) - Convert.ToDouble(REMOVESCORE.Text))
                    removeLabel.Text = "REMOVED"
                Case 3
                    TEAM3.Text = Convert.ToString(Convert.ToDouble(TEAM3.Text) - Convert.ToDouble(REMOVESCORE.Text))
                    removeLabel.Text = "REMOVED"
                Case 4
                    TEAM4.Text = Convert.ToString(Convert.ToDouble(TEAM4.Text) - Convert.ToDouble(REMOVESCORE.Text))
                    removeLabel.Text = "REMOVED"
                Case 5
                    TEAM5.Text = Convert.ToString(Convert.ToDouble(TEAM5.Text) - Convert.ToDouble(REMOVESCORE.Text))
                    removeLabel.Text = "REMOVED"
                Case 6
                    TEAM6.Text = Convert.ToString(Convert.ToDouble(TEAM6.Text) - Convert.ToDouble(REMOVESCORE.Text))
                    removeLabel.Text = "REMOVED"
                Case 7
                    TEAM7.Text = Convert.ToString(Convert.ToDouble(TEAM7.Text) - Convert.ToDouble(REMOVESCORE.Text))
                    removeLabel.Text = "REMOVED"
                Case 8
                    TEAM8.Text = Convert.ToString(Convert.ToDouble(TEAM8.Text) - Convert.ToDouble(REMOVESCORE.Text))
                    removeLabel.Text = "REMOVED"
                Case 9
                    TEAM9.Text = Convert.ToString(Convert.ToDouble(TEAM9.Text) - Convert.ToDouble(REMOVESCORE.Text))
                    removeLabel.Text = "REMOVED"
                Case 10
                    TEAM10.Text = Convert.ToString(Convert.ToDouble(TEAM10.Text) - Convert.ToDouble(REMOVESCORE.Text))
                    removeLabel.Text = "REMOVED"
                Case Else
                    removeLabel.Text = "ERROR"
            End Select
        Catch ex As Exception
            MessageBox.Show("Enter correct team number and score!!!")
        End Try

    End Sub


    ''' <summary>
    ''' Handle arduino puch button event when timer has started completely
    ''' </summary>mybase
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub startTimer_Click(sender As Object, e As EventArgs) Handles startTimer.Click
        watch.Start()
        Timer1.Start()
        My.Computer.Audio.Play("C:\start.wav", AudioPlayMode.BackgroundLoop)
        'to take keypress event set it to True 
        started = True
    End Sub

    Private Sub comport_Click(sender As Object, e As EventArgs) Handles comport.Click
        comPortForm.Show()
        MessageBox.Show(selPort.ToString)
    End Sub

    Private Sub SerialPort_DataReceived(ByVal sender As Object, ByVal e As System.IO.Ports.SerialDataReceivedEventArgs) Handles SerialPort.DataReceived
        Try
            Dim str As String = SerialPort.ReadExisting
            SerialPortConnection(str)
        Catch ex As Exception
        End Try

    End Sub

    Public Sub SPSetup()    'Serial Port Setup
        On Error Resume Next
        If SerialPort.IsOpen Then
            SerialPort.Close()
        End If
        SerialPort.PortName = selPort  ' "COM3"
        SerialPort.BaudRate = 9600
        SerialPort.DataBits = 8
        SerialPort.StopBits = IO.Ports.StopBits.One
        SerialPort.Handshake = IO.Ports.Handshake.None
        SerialPort.Parity = IO.Ports.Parity.None
        SerialPort.Open()
    End Sub
End Class
