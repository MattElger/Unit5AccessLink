<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Menu
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
        Me.btnSetUpDB = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnSetUpDB
        '
        Me.btnSetUpDB.Location = New System.Drawing.Point(112, 103)
        Me.btnSetUpDB.Name = "btnSetUpDB"
        Me.btnSetUpDB.Size = New System.Drawing.Size(75, 23)
        Me.btnSetUpDB.TabIndex = 0
        Me.btnSetUpDB.Text = "Set up Database"
        Me.btnSetUpDB.UseVisualStyleBackColor = True
        '
        'Menu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 261)
        Me.Controls.Add(Me.btnSetUpDB)
        Me.Name = "Menu"
        Me.Text = "Menu"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnSetUpDB As System.Windows.Forms.Button
End Class
