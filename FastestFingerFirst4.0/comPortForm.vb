Imports System.ComponentModel
Imports System.IO

Module GlobalVariables4
    Public selPort As String
End Module
Public Class comPortForm
    Private WithEvents bgwTasks As New BackgroundWorker
    Public WithEvents SerialPort As New IO.Ports.SerialPort
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            RefreshPorts()
            SPSetup()
            bgwTasks.RunWorkerAsync()
        Catch ex As Exception
            MessageBox.Show("Arduino drivers not installed.")
        End Try

    End Sub


    Private Sub btnSend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSend.Click
        Try
            If SerialPort.IsOpen Then
                SerialPort.Write(sendText.Text)
            Else
                SPSetup()
                SerialPort.Write(sendText.Text)
            End If
        Catch ex As Exception
            MessageBox.Show("Arduino Port not set or no text to send.")
        End Try

    End Sub


    Private Sub ConnectSerial()
        Try
            SerialPort.BaudRate = 9600
            SerialPort.PortName = selPort
            SerialPort.Open()
        Catch
            SerialPort.Close()
        End Try
    End Sub


    Delegate Sub myMethodDelegate(ByVal [text] As String)
    Dim myD1 As New myMethodDelegate(AddressOf myShowStringMethod)


    Sub myShowStringMethod(ByVal myString As String)
        textPanel.AppendText(myString)
    End Sub





    Private Sub btnRefreshPorts_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefreshPorts.Click
        RefreshPorts()
    End Sub


    Private Sub RefreshPorts()
        txtPort.Items.Clear()
        For Each sp As String In My.Computer.Ports.SerialPortNames
            txtPort.Items.Add(sp)
        Next
        If txtPort.Items.Count > 0 Then
            txtPort.SelectedIndex = 0
            selPort = txtPort.Text
        End If
    End Sub


    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        textPanel.Text = String.Empty
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        SerialPort.Close()
        Me.Close()
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

    Private Sub txtPort_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPort.SelectedIndexChanged
        selPort = txtPort.Text
        Me.Text = String.Format("Arduino Serial Communication - {0}", selPort)
        SPSetup()
    End Sub

    Private Sub setPort_Click(sender As Object, e As EventArgs) Handles setPort.Click
        Dashboard.comport.Text = selPort
    End Sub
End Class
