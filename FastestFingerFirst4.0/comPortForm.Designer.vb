<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class comPortForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.textPanel = New System.Windows.Forms.RichTextBox()
        Me.sendText = New System.Windows.Forms.TextBox()
        Me.btnSend = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnRefreshPorts = New System.Windows.Forms.Button()
        Me.txtPort = New System.Windows.Forms.ListBox()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.setPort = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'textPanel
        '
        Me.textPanel.Location = New System.Drawing.Point(29, 121)
        Me.textPanel.Name = "textPanel"
        Me.textPanel.Size = New System.Drawing.Size(563, 255)
        Me.textPanel.TabIndex = 0
        Me.textPanel.Text = ""
        '
        'sendText
        '
        Me.sendText.Location = New System.Drawing.Point(29, 72)
        Me.sendText.Name = "sendText"
        Me.sendText.Size = New System.Drawing.Size(417, 22)
        Me.sendText.TabIndex = 1
        '
        'btnSend
        '
        Me.btnSend.Location = New System.Drawing.Point(468, 62)
        Me.btnSend.Name = "btnSend"
        Me.btnSend.Size = New System.Drawing.Size(105, 43)
        Me.btnSend.TabIndex = 2
        Me.btnSend.Text = "SEND"
        Me.btnSend.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(29, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(82, 17)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "COM PORT"
        '
        'btnRefreshPorts
        '
        Me.btnRefreshPorts.Location = New System.Drawing.Point(254, 19)
        Me.btnRefreshPorts.Name = "btnRefreshPorts"
        Me.btnRefreshPorts.Size = New System.Drawing.Size(107, 29)
        Me.btnRefreshPorts.TabIndex = 4
        Me.btnRefreshPorts.Text = "REFRESH"
        Me.btnRefreshPorts.UseVisualStyleBackColor = True
        '
        'txtPort
        '
        Me.txtPort.FormattingEnabled = True
        Me.txtPort.ItemHeight = 16
        Me.txtPort.Location = New System.Drawing.Point(117, 22)
        Me.txtPort.Name = "txtPort"
        Me.txtPort.Size = New System.Drawing.Size(131, 20)
        Me.txtPort.TabIndex = 5
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(29, 382)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(79, 36)
        Me.btnClear.TabIndex = 6
        Me.btnClear.Text = "CLEAR"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(517, 382)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(75, 36)
        Me.btnExit.TabIndex = 7
        Me.btnExit.Text = "EXIT"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'setPort
        '
        Me.setPort.Location = New System.Drawing.Point(389, 22)
        Me.setPort.Name = "setPort"
        Me.setPort.Size = New System.Drawing.Size(109, 23)
        Me.setPort.TabIndex = 8
        Me.setPort.Text = "SET PORT"
        Me.setPort.UseVisualStyleBackColor = True
        '
        'comPortForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(622, 433)
        Me.Controls.Add(Me.setPort)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.txtPort)
        Me.Controls.Add(Me.btnRefreshPorts)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnSend)
        Me.Controls.Add(Me.sendText)
        Me.Controls.Add(Me.textPanel)
        Me.MaximumSize = New System.Drawing.Size(640, 480)
        Me.MinimumSize = New System.Drawing.Size(640, 480)
        Me.Name = "comPortForm"
        Me.Text = "comPort"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents textPanel As RichTextBox
    Friend WithEvents sendText As TextBox
    Friend WithEvents btnSend As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents btnRefreshPorts As Button
    Friend WithEvents txtPort As ListBox
    Friend WithEvents btnClear As Button
    Friend WithEvents btnExit As Button
    Friend WithEvents setPort As Button
End Class
