<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DetalleFacturaDocuware
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim Detalle_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DetalleFacturaDocuware))
        Me.Detalle = New Janus.Windows.GridEX.GridEX
        Me.Button1 = New Solmicro.Expertis.Engine.UI.Button
        CType(Me.Detalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Detalle
        '
        Me.Detalle.AllowDrop = True
        Me.Detalle.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.Detalle.ColumnAutoResize = True
        Detalle_DesignTimeLayout.LayoutString = resources.GetString("Detalle_DesignTimeLayout.LayoutString")
        Me.Detalle.DesignTimeLayout = Detalle_DesignTimeLayout
        Me.Detalle.Dock = System.Windows.Forms.DockStyle.Top
        Me.Detalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Detalle.GridLines = Janus.Windows.GridEX.GridLines.Horizontal
        Me.Detalle.GroupByBoxVisible = False
        Me.Detalle.Location = New System.Drawing.Point(0, 0)
        Me.Detalle.Name = "Detalle"
        Me.Detalle.ScrollBars = Janus.Windows.GridEX.ScrollBars.Vertical
        Me.Detalle.SelectedFormatStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(251, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Detalle.SelectedFormatStyle.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Detalle.Size = New System.Drawing.Size(516, 220)
        Me.Detalle.TabIndex = 4
        Me.Detalle.UpdateMode = Janus.Windows.GridEX.UpdateMode.CellUpdate
        Me.Detalle.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(205, 239)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 5
        Me.Button1.Text = "Cerrar"
        '
        'DetalleFacturaDocuware
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(516, 283)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Detalle)
        Me.Name = "DetalleFacturaDocuware"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "DetalleFacturaDocuware"
        CType(Me.Detalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Detalle As Janus.Windows.GridEX.GridEX
    Friend WithEvents Button1 As Solmicro.Expertis.Engine.UI.Button
End Class
