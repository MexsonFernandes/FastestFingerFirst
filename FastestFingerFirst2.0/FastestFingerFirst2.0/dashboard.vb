Imports System
Imports System.Management
Imports System.Management.Instrumentation
Imports System.Windows.Forms
Imports System.Runtime.InteropServices
Imports Microsoft.VisualBasic.PowerPacks
Imports System.Diagnostics.Stopwatch
Imports WMPLib
Module GlobalVariables1
    Public SAPI = CreateObject("SAPI.spvoice")
    Public teamnumber As Integer() = {0, 0, 0}
    Public last As String
    Public keyboard As Integer() = {49, 50, 51, 52, 113, 119, 101, 114}
End Module

Module GlobalVariables2
    'sets the Form's text property (title)
    Public Total_number_ports As String = "8"
End Module

Module Globalvariables3
    Public checkE As Boolean = False
    Public total_time_limit As String = "60"
    Public port_time As Double() = {3600000000005, 360000000000, 360000000000, 360000000000, 360000000000, 360000000000, 360000000000, 360000000000}
End Module
Public Class Dashboard
    Dim urls As String = "C:\ask.mp3" ' create the playlist      
    Dim resetnumber As Integer = 0 'reset only when timer has been started
    Dim compute_when_stopped As Integer = 0 'compute data only when timer has been stopped
    Dim x As Boolean = False
    Dim i As Integer
    Dim checkifnoclick As Integer = 0
    Dim high As Integer = 0
    Dim watch As Stopwatch = Stopwatch.StartNew()
    Dim result As Double
    Dim millisecond As Integer = 0
    Dim timecalc As Integer = 60
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


    Private Sub Form1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles StartTimerButton.KeyPress, StopTimerButton.KeyPress ', StartTimerButton.
        ' result = watch.Elapsed.Seconds + watch.ElapsedMilliseconds
        If Asc(e.KeyChar) = keyboard(0) And port_time(0) = 360000000000 Then
            ' Beep()
            If checkE = True Then
                MessageBox.Show("Team 1 were late in pressing key!!!", "Time's up")
            Else
                port_time(0) = watch.Elapsed.Seconds + watch.ElapsedMilliseconds
                detail1.Text = (timertext.Text.Length - 3) & "." & watch.Elapsed.Milliseconds ' Mod 100
                '     last = detail1.Text(detail1.Text.Length - 2)
                '   If last(last.Length - 1) = "." Then
                '  ' Str = Str.Remove(Str.Length - 1);
                ' detail1.Text = detail1.Text.Remove(detail1.Text.Length - 1) & "00"
                'End If              

                detail1.BackColor = Color.Lime
            End If
        ElseIf Asc(e.KeyChar) = keyboard(1) And port_time(1) = 360000000000 Then
            ' Beep()
            If checkE = True Then
                MessageBox.Show("Team 2 were late in pressing key!!!", "Time's up")
            Else
                port_time(1) = watch.Elapsed.Seconds + watch.ElapsedMilliseconds
                detail2.Text = timertext.Text & "." & watch.Elapsed.Milliseconds ' Mod 100


                detail2.BackColor = Color.Lime
            End If
        ElseIf Asc(e.KeyChar) = keyboard(2) And port_time(2) = 360000000000 Then
            ' Beep()
            If checkE = True Then
                MessageBox.Show("Team 3 were late in pressing key!!!", "Time's up")
            Else
                port_time(2) = watch.Elapsed.Seconds + watch.ElapsedMilliseconds

                detail3.Text = timertext.Text & "." & watch.Elapsed.Milliseconds 'Mod 100



                detail3.BackColor = Color.Lime
            End If
        ElseIf Asc(e.KeyChar) = keyboard(3) And port_time(3) = 360000000000 Then
            '   Beep()
            If checkE = True Then
                MessageBox.Show("Team 4 were late in pressing key!!!", "Time's up")
            Else
                port_time(3) = watch.Elapsed.Seconds + watch.ElapsedMilliseconds

                detail4.Text = timertext.Text & "." & watch.Elapsed.Milliseconds 'Mod 100


                detail4.BackColor = Color.Lime
            End If
        ElseIf Asc(e.KeyChar) = keyboard(4) And port_time(4) = 360000000000 Then
            '  Beep()
            If checkE = True Then
                MessageBox.Show("Team 5 were late in pressing key!!!", "Time's up")
            Else
                port_time(4) = watch.Elapsed.Seconds + watch.ElapsedMilliseconds
                detail5.Text = timertext.Text & "." & watch.Elapsed.Milliseconds ' Mod 100



                detail5.BackColor = Color.Lime
            End If
        ElseIf Asc(e.KeyChar) = keyboard(5) And port_time(5) = 360000000000 Then
            'Beep()
            If checkE = True Then
                MessageBox.Show("Team 6 were late in pressing key!!!", "Time's up")
            Else
                port_time(5) = watch.Elapsed.Seconds + watch.ElapsedMilliseconds
                detail6.Text = timertext.Text & "." & watch.Elapsed.Milliseconds 'Mod 100


                detail6.BackColor = Color.Lime
            End If
        ElseIf Asc(e.KeyChar) = keyboard(6) And port_time(6) = 360000000000 Then
            ' Beep()
            If checkE = True Then
                MessageBox.Show("Team 7 were late in pressing key!!!", "Time's up")
            Else

                port_time(6) = watch.Elapsed.Seconds + watch.ElapsedMilliseconds
                detail7.Text = timertext.Text & "." & watch.Elapsed.Milliseconds ' Mod 100

                detail7.BackColor = Color.Lime
            End If
        ElseIf Asc(e.KeyChar) = keyboard(7) And port_time(7) = 360000000000 Then
            '  Beep()
            If checkE = True Then
                MessageBox.Show("Team 8 were late in pressing key!!!", "Time's up")
            Else
                port_time(7) = watch.Elapsed.Seconds + watch.ElapsedMilliseconds
                detail8.Text = timertext.Text & "." & watch.Elapsed.Milliseconds ' Mod 100


                detail8.BackColor = Color.Lime
            End If

        End If
    End Sub
    'to play background sound
    'Public WithEvents Function BackgroundWorker2(sender As System.Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker2.DoWork
    '    While startsound = True
    '        Dim urls As String = "C:\start.wav" ' create the playlist      
    '        Player.URL = urls
    '        Player.controls.play()
    '    End While
    'End Function
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
            ConnectionPanel.Visible = True
            scorecardpanel.Visible = False
            My.Computer.Audio.Stop()
            My.Computer.Audio.Play("C:\start.wav", AudioPlayMode.BackgroundLoop)
            Label5.Visible = True
            timertext.Text = "00:00:00"
            ' BackgroundWorker2.RunWorkerAsync(sender, e)
            ' startgreen1.BackColor = Color.LimeGreen
            'stopred1.BackColor = Color.FromArgb(255, 192, 192)
            Button1.Enabled = False
            Process.Enabled = False
            ResetButton.Enabled = False
            Debugger.Enabled = False
            portnumbermain.Enabled = False
            portaddress.Enabled = False
            Help.Enabled = False
            credits.Enabled = False
            mm.Enabled = False
            exitwindow.Enabled = False
            watch.Reset()
            watch.Start()
            compute_when_stopped = 0
            warning.Text = "Please do not click anything, except STOP Button"


            description.Text = "KKNP : Keyboard Key Not Pressed"
            If Total_number_ports = "1" Then
                detail1.Text = "KKNP"
                detail2.Text = "NULL"
                detail3.Text = "NULL"
                detail4.Text = "NULL"
                detail5.Text = "NULL"
                detail6.Text = "NULL"
                detail7.Text = "NULL"
                detail8.Text = "NULL"
                'detail9.Text = "NULL"
                '   detail10.Text = "NULL"
                '  detail11.Text = "NULL"
                ' detail12.Text = "NULL"
                'detail13.Text = "NULL"
                'detail14.Text = "NULL"
                ' detail15.Text = "NULL"
                ' detail16.Text = "NULL"

            ElseIf Total_number_ports = "2" Then
                detail1.Text = "KKNP"
                detail2.Text = "KKNP"
                detail3.Text = "NULL"
                detail4.Text = "NULL"
                detail5.Text = "NULL"
                detail6.Text = "NULL"
                detail7.Text = "NULL"
                detail8.Text = "NULL"
                '     detail9.Text = "NULL"
                '               detail10.Text = "NULL"
                '              detail11.Text = "NULL"
                '             detail12.Text = "NULL"
                '            detail13.Text = "NULL"
                '           detail14.Text = "NULL"
                '          detail15.Text = "NULL"
                ''         detail16.Text = "NULL"
            ElseIf Total_number_ports = "3" Then
                detail1.Text = "KKNP"
                detail2.Text = "KKNP"
                detail3.Text = "KKNP"
                detail4.Text = "NULL"
                detail5.Text = "NULL"
                detail6.Text = "NULL"
                detail7.Text = "NULL"
                detail8.Text = "NULL"
                '              detail9.Text = "NULL"
                '         detail10.Text = "NULL"
                '             detail11.Text = "NULL"
                '            detail12.Text = "NULL"
                '           detail13.Text = "NULL"
                '          detail14.Text = "NULL"
                '        detail15.Text = "NULL"
                '       detail16.Text = "NULL"
            ElseIf Total_number_ports = "4" Then
                detail1.Text = "KKNP"
                detail2.Text = "KKNP"
                detail3.Text = "KKNP"
                detail4.Text = "KKNP"
                detail5.Text = "NULL"
                detail6.Text = "NULL"
                detail7.Text = "NULL"
                detail8.Text = "NULL"
                '                detail9.Text = "NULL"
                '               detail10.Text = "NULL"
                '              detail11.Text = "NULL"
                '             detail12.Text = "NULL"
                '            detail13.Text = "NULL"
                '           detail14.Text = "NULL"
                ''          detail15.Text = "NULL"
                '        detail16.Text = "NULL"
            ElseIf Total_number_ports = "5" Then
                detail1.Text = "KKNP"
                detail2.Text = "KKNP"
                detail3.Text = "KKNP"
                detail4.Text = "KKNP"
                detail5.Text = "KKNP"
                detail6.Text = "NULL"
                detail7.Text = "NULL"
                detail8.Text = "NULL"
                '       detail9.Text = "NULL"
                '      detail10.Text = "NULL"
                '     detail11.Text = "NULL"
                '    detail12.Text = "NULL"
                ' detail13.Text = "NULL"
                '   detail14.Text = "NULL"
                '  detail15.Text = "NULL"
                ' detail16.Text = "NULL"
            ElseIf Total_number_ports = "6" Then
                detail1.Text = "KKNP"
                detail2.Text = "KKNP"
                detail3.Text = "KKNP"
                detail4.Text = "KKNP"
                detail5.Text = "KKNP"
                detail6.Text = "KKNP"
                detail7.Text = "NULL"
                detail8.Text = "NULL"
                '            detail9.Text = "NULL"
                '           detail10.Text = "NULL"
                '          detail11.Text = "NULL"
                '         detail12.Text = "NULL"
                '      detail13.Text = "NULL"
                '        detail14.Text = "NULL"
                '       detail15.Text = "NULL"
                '     detail16.Text = "NULL"
            ElseIf Total_number_ports = "7" Then
                detail1.Text = "KKNP"
                detail2.Text = "KKNP"
                detail3.Text = "KKNP"
                detail4.Text = "KKNP"
                detail5.Text = "KKNP"
                detail6.Text = "KKNP"
                detail7.Text = "KKNP"
                detail8.Text = "NULL"
                '             detail9.Text = "NULL"
                '            detail10.Text = "NULL"
                '           detail11.Text = "NULL"
                '          detail12.Text = "NULL"
                '         detail13.Text = "NULL"
                '        detail14.Text = "NULL"
                '       detail15.Text = "NULL"
                '      detail16.Text = "NULL"
            ElseIf Total_number_ports = "8" Then
                detail1.Text = "KKNP"
                detail2.Text = "KKNP"
                detail3.Text = "KKNP"
                detail4.Text = "KKNP"
                detail5.Text = "KKNP"
                detail6.Text = "KKNP"
                detail7.Text = "KKNP"
                detail8.Text = "KKNP"
                '              detail9.Text = "NULL"
                '             detail10.Text = "NULL"
                '            detail11.Text = "NULL"
                '           detail12.Text = "NULL"
                '        detail13.Text = "NULL"
                '          detail14.Text = "NULL"
                '         detail15.Text = "NULL"
                '       detail16.Text = "NULL"
            ElseIf Total_number_ports = "9" Then
                detail1.Text = "KKNP"
                detail2.Text = "KKNP"
                detail3.Text = "KKNP"
                detail4.Text = "KKNP"
                detail5.Text = "KKNP"
                detail6.Text = "KKNP"
                detail7.Text = "KKNP"
                detail8.Text = "KKNP"
                '            detail9.Text = "KKNP"
                '           detail10.Text = "NULL"
                '          detail11.Text = "NULL"
                '         detail12.Text = "NULL"
                '        detail13.Text = "NULL"
                '      detail14.Text = "NULL"
                '       detail15.Text = "NULL"
                '     detail16.Text = "NULL"
            ElseIf Total_number_ports = "10" Then
                detail1.Text = "KKNP"
                detail2.Text = "KKNP"
                detail3.Text = "KKNP"
                detail4.Text = "KKNP"
                detail5.Text = "KKNP"
                detail6.Text = "KKNP"
                detail7.Text = "KKNP"
                detail8.Text = "KKNP"
                '    detail9.Text = "KKNP"
                '   detail10.Text = "KKNP"
                '  detail11.Text = "NULL"
                'detail12.Text = "NULL"
                ' detail13.Text = "NULL"
                ' detail14.Text = "NULL"
                ' detail15.Text = "NULL"
                ' detail16.Text = "NULL"
            ElseIf Total_number_ports = "11" Then
                detail1.Text = "KKNP"
                detail2.Text = "KKNP"
                detail3.Text = "KKNP"
                detail4.Text = "KKNP"
                detail5.Text = "KKNP"
                detail6.Text = "KKNP"
                detail7.Text = "KKNP"
                detail8.Text = "KKNP"
                '   detail9.Text = "KKNP"
                '  detail10.Text = "KKNP"
                ' detail11.Text = "KKNP"
                ' detail12.Text = "NULL"
                '  detail13.Text = "NULL"
                '  detail14.Text = "NULL"
                ' detail15.Text = "NULL"
                ' detail16.Text = "NULL"
            ElseIf Total_number_ports = "12" Then
                detail1.Text = "KKNP"
                detail2.Text = "KKNP"
                detail3.Text = "KKNP"
                detail4.Text = "KKNP"
                detail5.Text = "KKNP"
                detail6.Text = "KKNP"
                detail7.Text = "KKNP"
                detail8.Text = "KKNP"
                '          detail9.Text = "KKNP"
                '         detail10.Text = "KKNP"
                '     detail11.Text = "KKNP"
                '        detail12.Text = "KKNP"
                ''       detail13.Text = "NULL"
                '     detail14.Text = "NULL"
                '    detail15.Text = "NULL"
                'detail16.Text = "NULL"
            ElseIf Total_number_ports = "13" Then
                detail1.Text = "KKNP"
                detail2.Text = "KKNP"
                detail3.Text = "KKNP"
                detail4.Text = "KKNP"
                detail5.Text = "KKNP"
                detail6.Text = "KKNP"
                detail7.Text = "KKNP"
                detail8.Text = "KKNP"
                '           detail9.Text = "KKNP"
                '          detail10.Text = "KKNP"
                '         detail11.Text = "KKNP"
                '        detail12.Text = "KKNP"
                '       detail13.Text = "KKNP"
                '      detail14.Text = "NULL"
                ''     detail15.Text = "NULL"
                '   detail16.Text = "NULL"
            ElseIf Total_number_ports = "14" Then
                detail1.Text = "KKNP"
                detail2.Text = "KKNP"
                detail3.Text = "KKNP"
                detail4.Text = "KKNP"
                detail5.Text = "KKNP"
                detail6.Text = "KKNP"
                detail7.Text = "KKNP"
                detail8.Text = "KKNP"
                '         detail9.Text = "KKNP"
                '        detail10.Text = "KKNP"
                '     detail11.Text = "KKNP"
                '       detail12.Text = "KKNP"
                '      detail13.Text = "KKNP"
                '    detail14.Text = "KKNP"
                '   detail15.Text = "NULL"
                ' '  detail16.Text = "NULL"
            ElseIf Total_number_ports = "15" Then
                detail1.Text = "KKNP"
                detail2.Text = "KKNP"
                detail3.Text = "KKNP"
                detail4.Text = "KKNP"
                detail5.Text = "KKNP"
                detail6.Text = "KKNP"
                detail7.Text = "KKNP"
                detail8.Text = "KKNP"
                '               detail9.Text = "KKNP"
                '              detail10.Text = "KKNP"
                '             detail11.Text = "KKNP"
                '          detail12.Text = "KKNP"
                '            detail13.Text = "KKNP"
                '           detail14.Text = "KKNP"
                '         detail15.Text = "KKNP"
                '        detail16.Text = "NULL"
            ElseIf Total_number_ports = "16" Then
                detail1.Text = "KKNP"
                detail2.Text = "KKNP"
                detail3.Text = "KKNP"
                detail4.Text = "KKNP"
                detail5.Text = "KKNP"
                detail6.Text = "KKNP"
                detail7.Text = "KKNP"
                detail8.Text = "KKNP"
                '               detail9.Text = "KKNP"
                '           detail10.Text = "KKNP"
                '              detail11.Text = "KKNP"
                '             detail12.Text = "KKNP"
                '            detail13.Text = "KKNP"
                '        detail14.Text = "KKNP"
                ''          detail15.Text = "KKNP"
                '       detail16.Text = "KKNP"
            End If
            Timer1.Start()
        End If
    End Sub


    Public Sub ResetButton_Click(sender As System.Object, e As System.EventArgs) Handles ResetButton.Click
        If resetnumber = 0 Then
            SAPI.speak("Timer not yet started")
            ' MessageBox.Show("Timer not yet started!!!", "Reset Error!!!")
        ElseIf compute_when_stopped = 0 Then
            SAPI.speak("Timer is still running")
            ' MessageBox.Show("Timer still running.", "Error!!!")
        ElseIf resetnumber = 1 Then
            Timer1.Stop()
            x = False
            checkE = False
            millisecond = 0
            Process.Enabled = True
            StopTimerButton.Enabled = True
            Button3.BackColor = Color.DeepSkyBlue
            detail1.BackColor = Color.Aquamarine
            detail2.BackColor = Color.Aquamarine
            detail3.BackColor = Color.Aquamarine
            detail4.BackColor = Color.Aquamarine
            detail5.BackColor = Color.Aquamarine
            detail6.BackColor = Color.Aquamarine
            detail7.BackColor = Color.Aquamarine
            detail8.BackColor = Color.Aquamarine
            port_time(0) = 360000000000
            port_time(1) = 360000000000
            port_time(2) = 360000000000
            port_time(3) = 360000000000
            port_time(4) = 360000000000
            port_time(5) = 360000000000
            port_time(6) = 360000000000
            port_time(7) = 360000000000

            detail1.Text = "TNS"
            detail2.Text = "TNS"
            detail3.Text = "TNS"
            detail4.Text = "TNS"
            detail5.Text = "TNS"
            detail6.Text = "TNS"
            detail7.Text = "TNS"
            detail8.Text = "TNS"

            description.Text = "TNS : Timer Not Started "
            If Total_number_ports = "1" Then
                detail1.Text = "TNS"
                detail2.Text = "NULL"
                detail3.Text = "NULL"
                detail4.Text = "NULL"
                detail5.Text = "NULL"
                detail6.Text = "NULL"
                detail7.Text = "NULL"
                detail8.Text = "NULL"

            ElseIf Total_number_ports = "2" Then
                detail1.Text = "TNS"
                detail2.Text = "TNS"
                detail3.Text = "NULL"
                detail4.Text = "NULL"
                detail5.Text = "NULL"
                detail6.Text = "NULL"
                detail7.Text = "NULL"
                detail8.Text = "NULL"

            ElseIf Total_number_ports = "3" Then
                detail1.Text = "TNS"
                detail2.Text = "TNS"
                detail3.Text = "TNS"
                detail4.Text = "NULL"
                detail5.Text = "NULL"
                detail6.Text = "NULL"
                detail7.Text = "NULL"
                detail8.Text = "NULL"

            ElseIf Total_number_ports = "4" Then
                detail1.Text = "TNS"
                detail2.Text = "TNS"
                detail3.Text = "TNS"
                detail4.Text = "TNS"
                detail5.Text = "NULL"
                detail6.Text = "NULL"
                detail7.Text = "NULL"
                detail8.Text = "NULL"

            ElseIf Total_number_ports = "5" Then
                detail1.Text = "TNS"
                detail2.Text = "TNS"
                detail3.Text = "TNS"
                detail4.Text = "TNS"
                detail5.Text = "TNS"
                detail6.Text = "NULL"
                detail7.Text = "NULL"
                detail8.Text = "NULL"

            ElseIf Total_number_ports = "6" Then
                detail1.Text = "TNS"
                detail2.Text = "TNS"
                detail3.Text = "TNS"
                detail4.Text = "TNS"
                detail5.Text = "TNS"
                detail6.Text = "TNS"
                detail7.Text = "NULL"
                detail8.Text = "NULL"

            ElseIf Total_number_ports = "7" Then
                detail1.Text = "TNS"
                detail2.Text = "TNS"
                detail3.Text = "TNS"
                detail4.Text = "TNS"
                detail5.Text = "TNS"
                detail6.Text = "TNS"
                detail7.Text = "TNS"
                detail8.Text = "NULL"

            ElseIf Total_number_ports = "8" Then
                detail1.Text = "TNS"
                detail2.Text = "TNS"
                detail3.Text = "TNS"
                detail4.Text = "TNS"
                detail5.Text = "TNS"
                detail6.Text = "TNS"
                detail7.Text = "TNS"
                detail8.Text = "TNS"

            End If

            firstname.Text = "Team Name = NULL"
            secondname.Text = "Team Name = NULL"
            thirdname.Text = "Team Name = NULL"
            firsttime.Text = "Time = NULL"
            secondtime.Text = "Time = NULL"
            thirdtime.Text = "Time = NULL"
            timertext.Text = "MM:SS:MS"
            checkifnoclick = 0
            MessageBox.Show("Everything will be erased.", "System reset")
            resetnumber = 0
            SAPI.speak("System Resetted for next question")
        End If
    End Sub

    'To show help and support
    Private Sub Help_Click(sender As System.Object, e As System.EventArgs) Handles help.Click
        MessageBox.Show("Note : Download Music first " & vbCrLf & "Step 1 : Define number of Teams (i.e no. of keyboards) " & vbCrLf & "Step 2 : Define keyboard key." & vbCrLf & "Step 3 : If above steps performed correctly then a Green light is shown else a red light will be shown." & vbCrLf & "Step 4: Incase of red light, press DEBUG button to check for errors." & vbCrLf & "Step 5 : Start the timer by pressing START button, timer window will show a timer running." & vbCrLf & "Step 6 : To stop a timer press STOP button." & vbCrLf & "Step 7 : Press the COMPUTE button to process the result." & vbCrLf & "Step 8 : Press RESET SYSTEM button to bring everything back to normal state." & vbCrLf & "Step 9 : Press EXIT if you want to exit from the software." & vbCrLf & "Thank you for using our service.", "Help and Support")
    End Sub
    'credits printing
    Private Sub Credits_Click(sender As System.Object, e As System.EventArgs) Handles credits.Click
        MessageBox.Show("Application developed by RoboMex" & vbCrLf & "robomex2020@gmail.com" & vbCrLf & "All rights reserved. Copyright © 2017", "Credits")
    End Sub
    'to exit window
    Private Sub Exitwindow_Click(sender As System.Object, e As System.EventArgs) Handles exitwindow.Click
        SAPI.speak("Thank you for using me, bye ")
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
            Process.Enabled = False
            ConnectionPanel.Visible = False
            scorecardpanel.Visible = True
            For i = 0 To 2
                high = 0
                For j = 0 To 7
                    If port_time(high) > port_time(j) Then
                        high = j
                    End If
                Next
                If i = 0 Then

                    If port_time(high) = 360000000000 Then
                        checkifnoclick = checkifnoclick + 1
                        firstname.Text = "TEAM NAME = NULL"
                        firsttime.Text = "TIME = NULL"
                    Else
                        firstname.Text = "TEAM NAME = " & (high + 1)
                        firsttime.Text = "TIME = " & Display(high)
                        teamnumber(0) = high + 1
                    End If
                ElseIf i = 1 Then
                    If port_time(high) = 360000000000 Then
                        checkifnoclick = checkifnoclick + 1
                        secondname.Text = "TEAM NAME = NULL"
                        secondtime.Text = "TIME = NULL"

                    Else
                        secondname.Text = "TEAM NAME = " & (high + 1)
                        secondtime.Text = "TIME = " & Display(high)
                        teamnumber(1) = high + 1
                    End If
                ElseIf i = 2 Then
                    If port_time(high) = 360000000000 Then
                        checkifnoclick = checkifnoclick + 1
                        thirdname.Text = "TEAM NAME = NULL"
                        thirdtime.Text = "TIME = NULL"
                    Else
                        thirdname.Text = "TEAM NAME = " & (high + 1)
                        thirdtime.Text = "TIME = " & Display(high)
                        teamnumber(2) = high + 1

                    End If
                End If
                port_time(high) = 360000000000
            Next
            If Not checkifnoclick = 3 Or checkifnoclick = 2 Or checkifnoclick = 1 Then
                BackgroundWorker1.RunWorkerAsync()
            End If
            If checkifnoclick = 3 Then
                SAPI.speak("Ohhh, no, one knows the answer")
                'MessageBox.Show("Very bad!!! Not a single participant knows the answer.", "Shame!!!")
            End If
        End If
    End Sub

    Private Function Display(ByVal x As Integer) As String
        Select Case x
            Case 0
                Return detail1.Text
            Case 1
                Return detail2.Text
            Case 2
                Return detail3.Text
            Case 3
                Return detail4.Text
            Case 4

                Return detail5.Text
            Case 5
                Return detail6.Text
            Case 6
                Return detail7.Text
            Case 7
                Return detail8.Text

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
            '  Player.URL = stopwav
            '   Player.controls.play()

            resetnumber = 1
            checkE = True
            millisecond = 0
            Button1.Enabled = True
            Process.Enabled = True
            ResetButton.Enabled = True
            Debugger.Enabled = True
            Label5.Visible = True
            mm.Enabled = True
            portnumbermain.Enabled = True
            portaddress.Enabled = True
            Help.Enabled = True
            credits.Enabled = True
            exitwindow.Enabled = True
            watch.Stop()
            watch.Reset()
            checkE = True
            warning.Text = ""
            ' startgreen1.BackColor = Color.FromArgb(192, 255, 192)
            ' stopred1.BackColor = Color.Red
            compute_when_stopped = 1
            Timer1.Stop()
            StopTimerButton.Enabled = False
            If detail1.Text = "KKNP" Then
                detail1.BackColor = Color.LightSalmon
            End If
            If detail2.Text = "KKNP" Then
                detail2.BackColor = Color.LightSalmon
            End If
            If detail3.Text = "KKNP" Then
                detail3.BackColor = Color.LightSalmon
            End If
            If detail4.Text = "KKNP" Then
                detail4.BackColor = Color.LightSalmon
            End If
            If detail5.Text = "KKNP" Then
                detail5.BackColor = Color.LightSalmon
            End If
            If detail6.Text = "KKNP" Then
                detail6.BackColor = Color.LightSalmon
            End If
            If detail7.Text = "KKNP" Then
                detail7.BackColor = Color.LightSalmon
            End If
            If detail8.Text = "KKNP" Then
                detail8.BackColor = Color.LightSalmon
            End If
        End If
    End Sub


    Private Sub Wait(ByVal interval As Integer)
        Dim sw As New Stopwatch
        sw.Start()
        Do While sw.ElapsedMilliseconds < interval
            ' Allows UI to remain responsive
            Application.DoEvents()
        Loop
        sw.Stop()
    End Sub
    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        If mm.Text = "seconds" Then
            mm.Text = "60"
            Label5.Visible = True
            total_time_limit = 60
        Else
            SAPI.speak(mm.Text + "  seconds set")
            Label5.Visible = True
            total_time_limit = Convert.ToUInt32(mm.Text)
            Label4.Visible = True
            Wait(1000)
            Label4.Visible = False
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Button2.BackColor = Color.White
        StartTimerButton.Enabled = True
        StopTimerButton.Enabled = True
        ResetButton.Enabled = True
        Process.Enabled = True
        Button1.Enabled = True
        mm.Enabled = True
        detail1.BackColor = Color.Aquamarine
        detail2.BackColor = Color.Aquamarine
        detail3.BackColor = Color.Aquamarine
        detail4.BackColor = Color.Aquamarine
        detail5.BackColor = Color.Aquamarine
        detail6.BackColor = Color.Aquamarine
        detail7.BackColor = Color.Aquamarine
        detail8.BackColor = Color.Aquamarine
        portcolor1.BackColor = Color.DeepSkyBlue
        portcolor2.BackColor = Color.DeepSkyBlue
        portcolor3.BackColor = Color.DeepSkyBlue
        portcolor4.BackColor = Color.DeepSkyBlue
        portcolor5.BackColor = Color.DeepSkyBlue
        portcolor6.BackColor = Color.DeepSkyBlue
        portcolor7.BackColor = Color.DeepSkyBlue
        portcolor8.BackColor = Color.DeepSkyBlue
        detail1.Text = "TNS"
        detail2.Text = "TNS"
        detail3.Text = "TNS"
        detail4.Text = "TNS"
        detail5.Text = "TNS"
        detail6.Text = "TNS"
        detail7.Text = "TNS"
        detail8.Text = "TNS"
        description.Text = "TNS : Timer Not Started "
        Button2.Enabled = False
        SAPI.Speak("All set")
        ' BackgroundWorker1.RunWorkerAsync(1)
    End Sub
    'Public Player As WindowsMediaPlayer = New WindowsMediaPlayer
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Button3.BackColor = Color.White
        ' Player.URL = urls
        'Player.controls.play()
    End Sub

    Private Sub BackgroundWorker1_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        '   If e Then
        ' SAPI.Speak("All set")
        ' End If


        If Not firstname.Text = "TEAM NAME = NULL" Then
            SAPI.speak("Result computed")
            SAPI.speak("team  " + Convert.ToString(teamnumber(0)) + " is first")
        End If
        If Not secondname.Text = "TEAM NAME = NULL" Then
            SAPI.speak("team  " + Convert.ToString(teamnumber(1)) + " is second")
        End If
        If Not thirdname.Text = "TEAM NAME = NULL" Then
            SAPI.speak("team  " + Convert.ToString(teamnumber(2)) + " is third")
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        MessageBox.Show("Press OK to download the audio files now. ", "Audio Files link")
        System.Diagnostics.Process.Start("https://drive.google.com/open?id=0B5aObC_fxmDnWEsyM1RJd3lqZUE", "default")
        MessageBox.Show("Copy those files in C:\ drive before doing anything", "File location to set")
        Button5.BackColor = Color.White
    End Sub

    Public backmusic As Boolean = False
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If backmusic = False Then
            backmusic = True
            Button4.BackColor = Color.White
            My.Computer.Audio.Stop()
            My.Computer.Audio.Play("C:\back.wav", AudioPlayMode.BackgroundLoop)
        Else
            backmusic = False
            My.Computer.Audio.Stop()
            Button4.BackColor = Color.DeepSkyBlue
        End If
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        scorecardpanel.Visible = False
        ConnectionPanel.Visible = True
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        scorecardpanel.Visible = True
        ConnectionPanel.Visible = False
    End Sub
    Public ROUND As Integer
    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        ROUND = Convert.ToInt32(TextBox1.Text)
        SAPI.SPEAK("Round " & ROUND & " started, All the best")
    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        Select Case Convert.ToDouble(TEAMADD.Text)
            Case 1
                TEAM1.Text = Convert.ToString(Convert.ToDouble(TEAM1.Text) + Convert.ToDouble(ADDSCORE.Text))
                Label14.Text = "ADDED"
            Case 2
                TEAM2.Text = Convert.ToString(Convert.ToDouble(TEAM2.Text) + Convert.ToDouble(ADDSCORE.Text))
                Label14.Text = "ADDED"
            Case 3
                TEAM3.Text = Convert.ToString(Convert.ToDouble(TEAM3.Text) + Convert.ToDouble(ADDSCORE.Text))
                Label14.Text = "ADDED"
            Case 4
                TEAM4.Text = Convert.ToString(Convert.ToDouble(TEAM4.Text) + Convert.ToDouble(ADDSCORE.Text))
                Label14.Text = "ADDED"
            Case 5
                TEAM5.Text = Convert.ToString(Convert.ToDouble(TEAM5.Text) + Convert.ToDouble(ADDSCORE.Text))
                Label14.Text = "ADDED"
            Case 6
                TEAM6.Text = Convert.ToString(Convert.ToDouble(TEAM6.Text) + Convert.ToDouble(ADDSCORE.Text))
                Label14.Text = "ADDED"
            Case 7
                TEAM7.Text = Convert.ToString(Convert.ToDouble(TEAM7.Text) + Convert.ToDouble(ADDSCORE.Text))
                Label14.Text = "ADDED"
            Case 8
                TEAM8.Text = Convert.ToString(Convert.ToDouble(TEAM8.Text) + Convert.ToDouble(ADDSCORE.Text))
                Label14.Text = "ADDED"
            Case Else
                Label14.Text = "ERROR"
        End Select
    End Sub

    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click
        ADDSCORE.Text = ""
        Label14.Text = ""
        Label15.Text = ""
        TEAMADD.Text = ""
        REMOVESCORE.Text = ""
        TEAMREMOVE.Text = ""
    End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        Select Case Convert.ToDouble(TEAMREMOVE.Text)
            Case 1
                TEAM1.Text = Convert.ToString(Convert.ToDouble(TEAM1.Text) - Convert.ToDouble(REMOVESCORE.Text))
                Label15.Text = "REMOVED"
            Case 2
                TEAM2.Text = Convert.ToString(Convert.ToDouble(TEAM2.Text) - Convert.ToDouble(REMOVESCORE.Text))
                Label15.Text = "REMOVED"
            Case 3
                TEAM3.Text = Convert.ToString(Convert.ToDouble(TEAM3.Text) - Convert.ToDouble(REMOVESCORE.Text))
                Label15.Text = "REMOVED"
            Case 4
                TEAM4.Text = Convert.ToString(Convert.ToDouble(TEAM4.Text) - Convert.ToDouble(REMOVESCORE.Text))
                Label15.Text = "REMOVED"
            Case 5
                TEAM5.Text = Convert.ToString(Convert.ToDouble(TEAM5.Text) - Convert.ToDouble(REMOVESCORE.Text))
                Label15.Text = "REMOVED"
            Case 6
                TEAM6.Text = Convert.ToString(Convert.ToDouble(TEAM6.Text) - Convert.ToDouble(REMOVESCORE.Text))
                Label15.Text = "REMOVED"
            Case 7
                TEAM7.Text = Convert.ToString(Convert.ToDouble(TEAM7.Text) - Convert.ToDouble(REMOVESCORE.Text))
                Label15.Text = "REMOVED"
            Case 8
                TEAM8.Text = Convert.ToString(Convert.ToDouble(TEAM8.Text) - Convert.ToDouble(REMOVESCORE.Text))
                Label15.Text = "REMOVED"
            Case Else
                Label15.Text = "ERROR"
        End Select
    End Sub

End Class
