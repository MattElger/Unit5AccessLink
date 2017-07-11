<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.txtDBName = New System.Windows.Forms.TextBox()
        Me.txtTableName = New System.Windows.Forms.TextBox()
        Me.btnCreateDB = New System.Windows.Forms.Button()
        Me.btnCreateTable = New System.Windows.Forms.Button()
        Me.txtDDL = New System.Windows.Forms.TextBox()
        Me.btnPopulate = New System.Windows.Forms.Button()
        Me.txtData = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'txtDBName
        '
        Me.txtDBName.Location = New System.Drawing.Point(12, 33)
        Me.txtDBName.Name = "txtDBName"
        Me.txtDBName.Size = New System.Drawing.Size(132, 20)
        Me.txtDBName.TabIndex = 0
        '
        'txtTableName
        '
        Me.txtTableName.Location = New System.Drawing.Point(12, 104)
        Me.txtTableName.Name = "txtTableName"
        Me.txtTableName.Size = New System.Drawing.Size(132, 20)
        Me.txtTableName.TabIndex = 1
        '
        'btnCreateDB
        '
        Me.btnCreateDB.Location = New System.Drawing.Point(172, 25)
        Me.btnCreateDB.Name = "btnCreateDB"
        Me.btnCreateDB.Size = New System.Drawing.Size(113, 35)
        Me.btnCreateDB.TabIndex = 2
        Me.btnCreateDB.Text = "Create blank database"
        Me.btnCreateDB.UseVisualStyleBackColor = True
        '
        'btnCreateTable
        '
        Me.btnCreateTable.Location = New System.Drawing.Point(172, 96)
        Me.btnCreateTable.Name = "btnCreateTable"
        Me.btnCreateTable.Size = New System.Drawing.Size(113, 35)
        Me.btnCreateTable.TabIndex = 3
        Me.btnCreateTable.Text = "Create table using DDL"
        Me.btnCreateTable.UseVisualStyleBackColor = True
        '
        'txtDDL
        '
        Me.txtDDL.Location = New System.Drawing.Point(12, 164)
        Me.txtDDL.Multiline = True
        Me.txtDDL.Name = "txtDDL"
        Me.txtDDL.Size = New System.Drawing.Size(364, 163)
        Me.txtDDL.TabIndex = 4
        '
        'btnPopulate
        '
        Me.btnPopulate.Location = New System.Drawing.Point(405, 292)
        Me.btnPopulate.Name = "btnPopulate"
        Me.btnPopulate.Size = New System.Drawing.Size(113, 35)
        Me.btnPopulate.TabIndex = 5
        Me.btnPopulate.Text = "Populate table using data"
        Me.btnPopulate.UseVisualStyleBackColor = True
        '
        'txtData
        '
        Me.txtData.Location = New System.Drawing.Point(12, 344)
        Me.txtData.Multiline = True
        Me.txtData.Name = "txtData"
        Me.txtData.Size = New System.Drawing.Size(506, 254)
        Me.txtData.TabIndex = 6
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(530, 610)
        Me.Controls.Add(Me.txtData)
        Me.Controls.Add(Me.btnPopulate)
        Me.Controls.Add(Me.txtDDL)
        Me.Controls.Add(Me.btnCreateTable)
        Me.Controls.Add(Me.btnCreateDB)
        Me.Controls.Add(Me.txtTableName)
        Me.Controls.Add(Me.txtDBName)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtDBName As System.Windows.Forms.TextBox
    Friend WithEvents txtTableName As System.Windows.Forms.TextBox
    Friend WithEvents btnCreateDB As System.Windows.Forms.Button
    Friend WithEvents btnCreateTable As System.Windows.Forms.Button
    Friend WithEvents txtDDL As System.Windows.Forms.TextBox
    Friend WithEvents btnPopulate As System.Windows.Forms.Button
    Friend WithEvents txtData As System.Windows.Forms.TextBox

End Class
