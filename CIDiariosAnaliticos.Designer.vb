<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CIDiariosAnaliticos
    Inherits Solmicro.Expertis.Engine.UI.CIMnto

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
        Dim Grid_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim cmbEmpresa_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CIDiariosAnaliticos))
        Me.Label1 = New Solmicro.Expertis.Engine.UI.Label
        Me.Label2 = New Solmicro.Expertis.Engine.UI.Label
        Me.Label3 = New Solmicro.Expertis.Engine.UI.Label
        Me.cbFecha1 = New Solmicro.Expertis.Engine.UI.CalendarBox
        Me.cbFecha2 = New Solmicro.Expertis.Engine.UI.CalendarBox
        Me.cmbEmpresa = New Solmicro.Expertis.Engine.UI.ComboBox
        Me.FilterPanel.SuspendLayout()
        Me.CIMntoGridPanel.suspendlayout()
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiCommandManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Toolbar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Menubar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MainPanel.SuspendLayout()
        Me.MainPanelCIMntoContainer.SuspendLayout()
        CType(Me.cmbEmpresa, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'FilterPanel
        '
        Me.FilterPanel.Controls.Add(Me.cmbEmpresa)
        Me.FilterPanel.Controls.Add(Me.cbFecha2)
        Me.FilterPanel.Controls.Add(Me.cbFecha1)
        Me.FilterPanel.Controls.Add(Me.Label3)
        Me.FilterPanel.Controls.Add(Me.Label2)
        Me.FilterPanel.Controls.Add(Me.Label1)
        Me.FilterPanel.Location = New System.Drawing.Point(0, 230)
        Me.FilterPanel.Size = New System.Drawing.Size(800, 107)
        '
        'CIMntoGridPanel
        '
        Me.CIMntoGridPanel.Size = New System.Drawing.Size(800, 230)
        '
        'Grid
        '
        Grid_DesignTimeLayout.LayoutString = resources.GetString("Grid_DesignTimeLayout.LayoutString")
        Me.Grid.DesignTimeLayout = Grid_DesignTimeLayout
        Me.Grid.Size = New System.Drawing.Size(800, 230)
        Me.Grid.ViewName = "vUnionCtlCIDCAnalitica"
        '
        'Toolbar
        '
        Me.Toolbar.Size = New System.Drawing.Size(245, 28)
        '
        'Menubar
        '
        Me.Menubar.Location = New System.Drawing.Point(0, 28)
        '
        'MainPanel
        '
        Me.MainPanel.Size = New System.Drawing.Size(800, 337)
        '
        'MainPanelCIMntoContainer
        '
        Me.MainPanelCIMntoContainer.Size = New System.Drawing.Size(800, 337)
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(39, 45)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(102, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Fecha Apunte>="
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(299, 45)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(102, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Fecha Apunte<="
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(583, 45)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(57, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Empresa"
        '
        'cbFecha1
        '
        Me.cbFecha1.DisabledBackColor = System.Drawing.Color.White
        Me.cbFecha1.Location = New System.Drawing.Point(147, 45)
        Me.cbFecha1.Name = "cbFecha1"
        Me.cbFecha1.Size = New System.Drawing.Size(126, 21)
        Me.cbFecha1.TabIndex = 3
        '
        'cbFecha2
        '
        Me.cbFecha2.DisabledBackColor = System.Drawing.Color.White
        Me.cbFecha2.Location = New System.Drawing.Point(407, 45)
        Me.cbFecha2.Name = "cbFecha2"
        Me.cbFecha2.Size = New System.Drawing.Size(126, 21)
        Me.cbFecha2.TabIndex = 4
        '
        'cmbEmpresa
        '
        cmbEmpresa_DesignTimeLayout.LayoutString = resources.GetString("cmbEmpresa_DesignTimeLayout.LayoutString")
        Me.cmbEmpresa.DesignTimeLayout = cmbEmpresa_DesignTimeLayout
        Me.cmbEmpresa.DisabledBackColor = System.Drawing.Color.White
        Me.cmbEmpresa.Location = New System.Drawing.Point(646, 41)
        Me.cmbEmpresa.Name = "cmbEmpresa"
        Me.cmbEmpresa.SelectedIndex = -1
        Me.cmbEmpresa.SelectedItem = Nothing
        Me.cmbEmpresa.Size = New System.Drawing.Size(121, 21)
        Me.cmbEmpresa.TabIndex = 62
        '
        'CIDiariosAnaliticos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(808, 425)
        Me.Name = "CIDiariosAnaliticos"
        Me.Text = "CIDiariosAnaliticos"
        Me.ViewName = "vUnionCtlCIDCAnalitica"
        Me.FilterPanel.ResumeLayout(False)
        Me.FilterPanel.PerformLayout()
        Me.CIMntoGridPanel.ResumeLayout(False)
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiCommandManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Toolbar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Menubar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MainPanel.ResumeLayout(False)
        Me.MainPanelCIMntoContainer.ResumeLayout(False)
        CType(Me.cmbEmpresa, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label2 As Solmicro.Expertis.Engine.UI.Label
    Friend WithEvents Label1 As Solmicro.Expertis.Engine.UI.Label
    Friend WithEvents Label3 As Solmicro.Expertis.Engine.UI.Label
    Friend WithEvents cmbEmpresa As Solmicro.Expertis.Engine.UI.ComboBox
    Friend WithEvents cbFecha2 As Solmicro.Expertis.Engine.UI.CalendarBox
    Friend WithEvents cbFecha1 As Solmicro.Expertis.Engine.UI.CalendarBox
End Class
