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
        Dim cbCentroCoste_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim cbCentroCoste2_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim cbCContable_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim cbCContable2_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CIDiariosAnaliticos))
        Me.Label1 = New Solmicro.Expertis.Engine.UI.Label
        Me.Label2 = New Solmicro.Expertis.Engine.UI.Label
        Me.Label3 = New Solmicro.Expertis.Engine.UI.Label
        Me.cbFecha1 = New Solmicro.Expertis.Engine.UI.CalendarBox
        Me.cbFecha2 = New Solmicro.Expertis.Engine.UI.CalendarBox
        Me.cmbEmpresa = New Solmicro.Expertis.Engine.UI.ComboBox
        Me.Label4 = New Solmicro.Expertis.Engine.UI.Label
        Me.cbCentroCoste = New Solmicro.Expertis.Engine.UI.ComboBox
        Me.cbCentroCoste2 = New Solmicro.Expertis.Engine.UI.ComboBox
        Me.Label5 = New Solmicro.Expertis.Engine.UI.Label
        Me.Label6 = New Solmicro.Expertis.Engine.UI.Label
        Me.Label7 = New Solmicro.Expertis.Engine.UI.Label
        Me.cbCContable = New Solmicro.Expertis.Engine.UI.ComboBox
        Me.cbCContable2 = New Solmicro.Expertis.Engine.UI.ComboBox
        Me.FilterPanel.SuspendLayout()
        Me.CIMntoGridPanel.suspendlayout()
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiCommandManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Toolbar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Menubar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MainPanel.SuspendLayout()
        Me.MainPanelCIMntoContainer.SuspendLayout()
        CType(Me.cmbEmpresa, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbCentroCoste, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbCentroCoste2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbCContable, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbCContable2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'FilterPanel
        '
        Me.FilterPanel.Controls.Add(Me.cbCContable2)
        Me.FilterPanel.Controls.Add(Me.cbCContable)
        Me.FilterPanel.Controls.Add(Me.Label6)
        Me.FilterPanel.Controls.Add(Me.Label7)
        Me.FilterPanel.Controls.Add(Me.cbCentroCoste2)
        Me.FilterPanel.Controls.Add(Me.Label5)
        Me.FilterPanel.Controls.Add(Me.cbCentroCoste)
        Me.FilterPanel.Controls.Add(Me.Label4)
        Me.FilterPanel.Controls.Add(Me.cmbEmpresa)
        Me.FilterPanel.Controls.Add(Me.cbFecha2)
        Me.FilterPanel.Controls.Add(Me.cbFecha1)
        Me.FilterPanel.Controls.Add(Me.Label3)
        Me.FilterPanel.Controls.Add(Me.Label2)
        Me.FilterPanel.Controls.Add(Me.Label1)
        Me.FilterPanel.Location = New System.Drawing.Point(0, 223)
        Me.FilterPanel.Size = New System.Drawing.Size(1027, 114)
        '
        'CIMntoGridPanel
        '
        Me.CIMntoGridPanel.Size = New System.Drawing.Size(1027, 223)
        '
        'Grid
        '
        Grid_DesignTimeLayout.LayoutString = resources.GetString("Grid_DesignTimeLayout.LayoutString")
        Me.Grid.DesignTimeLayout = Grid_DesignTimeLayout
        Me.Grid.Size = New System.Drawing.Size(1027, 223)
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
        Me.MainPanel.Size = New System.Drawing.Size(1027, 337)
        '
        'MainPanelCIMntoContainer
        '
        Me.MainPanelCIMntoContainer.Size = New System.Drawing.Size(1027, 337)
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(18, 31)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(102, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Fecha Apunte>="
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(18, 70)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(102, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Fecha Apunte<="
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(773, 35)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(57, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Empresa"
        '
        'cbFecha1
        '
        Me.cbFecha1.DisabledBackColor = System.Drawing.Color.White
        Me.cbFecha1.Location = New System.Drawing.Point(126, 31)
        Me.cbFecha1.Name = "cbFecha1"
        Me.cbFecha1.Size = New System.Drawing.Size(126, 21)
        Me.cbFecha1.TabIndex = 3
        '
        'cbFecha2
        '
        Me.cbFecha2.DisabledBackColor = System.Drawing.Color.White
        Me.cbFecha2.Location = New System.Drawing.Point(126, 70)
        Me.cbFecha2.Name = "cbFecha2"
        Me.cbFecha2.Size = New System.Drawing.Size(126, 21)
        Me.cbFecha2.TabIndex = 4
        '
        'cmbEmpresa
        '
        cmbEmpresa_DesignTimeLayout.LayoutString = resources.GetString("cmbEmpresa_DesignTimeLayout.LayoutString")
        Me.cmbEmpresa.DesignTimeLayout = cmbEmpresa_DesignTimeLayout
        Me.cmbEmpresa.DisabledBackColor = System.Drawing.Color.White
        Me.cmbEmpresa.Location = New System.Drawing.Point(886, 31)
        Me.cmbEmpresa.Name = "cmbEmpresa"
        Me.cmbEmpresa.SelectedIndex = -1
        Me.cmbEmpresa.SelectedItem = Nothing
        Me.cmbEmpresa.Size = New System.Drawing.Size(121, 21)
        Me.cmbEmpresa.TabIndex = 62
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(267, 35)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(123, 13)
        Me.Label4.TabIndex = 63
        Me.Label4.Text = "Centro de Coste >="
        '
        'cbCentroCoste
        '
        cbCentroCoste_DesignTimeLayout.LayoutString = resources.GetString("cbCentroCoste_DesignTimeLayout.LayoutString")
        Me.cbCentroCoste.DesignTimeLayout = cbCentroCoste_DesignTimeLayout
        Me.cbCentroCoste.DisabledBackColor = System.Drawing.Color.White
        Me.cbCentroCoste.Location = New System.Drawing.Point(399, 31)
        Me.cbCentroCoste.Name = "cbCentroCoste"
        Me.cbCentroCoste.SelectedIndex = -1
        Me.cbCentroCoste.SelectedItem = Nothing
        Me.cbCentroCoste.Size = New System.Drawing.Size(121, 21)
        Me.cbCentroCoste.TabIndex = 64
        '
        'cbCentroCoste2
        '
        cbCentroCoste2_DesignTimeLayout.LayoutString = resources.GetString("cbCentroCoste2_DesignTimeLayout.LayoutString")
        Me.cbCentroCoste2.DesignTimeLayout = cbCentroCoste2_DesignTimeLayout
        Me.cbCentroCoste2.DisabledBackColor = System.Drawing.Color.White
        Me.cbCentroCoste2.Location = New System.Drawing.Point(399, 66)
        Me.cbCentroCoste2.Name = "cbCentroCoste2"
        Me.cbCentroCoste2.SelectedIndex = -1
        Me.cbCentroCoste2.SelectedItem = Nothing
        Me.cbCentroCoste2.Size = New System.Drawing.Size(121, 21)
        Me.cbCentroCoste2.TabIndex = 66
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(267, 70)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(123, 13)
        Me.Label5.TabIndex = 65
        Me.Label5.Text = "Centro de Coste <="
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(537, 70)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(103, 13)
        Me.Label6.TabIndex = 68
        Me.Label6.Text = "IDCContable <="
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(537, 35)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(103, 13)
        Me.Label7.TabIndex = 67
        Me.Label7.Text = "IDCContable >="
        '
        'cbCContable
        '
        cbCContable_DesignTimeLayout.LayoutString = resources.GetString("cbCContable_DesignTimeLayout.LayoutString")
        Me.cbCContable.DesignTimeLayout = cbCContable_DesignTimeLayout
        Me.cbCContable.DisabledBackColor = System.Drawing.Color.White
        Me.cbCContable.Location = New System.Drawing.Point(646, 35)
        Me.cbCContable.Name = "cbCContable"
        Me.cbCContable.SelectedIndex = -1
        Me.cbCContable.SelectedItem = Nothing
        Me.cbCContable.Size = New System.Drawing.Size(121, 21)
        Me.cbCContable.TabIndex = 69
        '
        'cbCContable2
        '
        cbCContable2_DesignTimeLayout.LayoutString = resources.GetString("cbCContable2_DesignTimeLayout.LayoutString")
        Me.cbCContable2.DesignTimeLayout = cbCContable2_DesignTimeLayout
        Me.cbCContable2.DisabledBackColor = System.Drawing.Color.White
        Me.cbCContable2.Location = New System.Drawing.Point(646, 66)
        Me.cbCContable2.Name = "cbCContable2"
        Me.cbCContable2.SelectedIndex = -1
        Me.cbCContable2.SelectedItem = Nothing
        Me.cbCContable2.Size = New System.Drawing.Size(121, 21)
        Me.cbCContable2.TabIndex = 70
        '
        'CIDiariosAnaliticos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1035, 425)
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
        CType(Me.cbCentroCoste, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbCentroCoste2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbCContable, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbCContable2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label2 As Solmicro.Expertis.Engine.UI.Label
    Friend WithEvents Label1 As Solmicro.Expertis.Engine.UI.Label
    Friend WithEvents Label3 As Solmicro.Expertis.Engine.UI.Label
    Friend WithEvents cmbEmpresa As Solmicro.Expertis.Engine.UI.ComboBox
    Friend WithEvents cbFecha2 As Solmicro.Expertis.Engine.UI.CalendarBox
    Friend WithEvents cbFecha1 As Solmicro.Expertis.Engine.UI.CalendarBox
    Friend WithEvents Label4 As Solmicro.Expertis.Engine.UI.Label
    Friend WithEvents cbCentroCoste As Solmicro.Expertis.Engine.UI.ComboBox
    Friend WithEvents cbCentroCoste2 As Solmicro.Expertis.Engine.UI.ComboBox
    Friend WithEvents Label5 As Solmicro.Expertis.Engine.UI.Label
    Friend WithEvents cbCContable2 As Solmicro.Expertis.Engine.UI.ComboBox
    Friend WithEvents cbCContable As Solmicro.Expertis.Engine.UI.ComboBox
    Friend WithEvents Label6 As Solmicro.Expertis.Engine.UI.Label
    Friend WithEvents Label7 As Solmicro.Expertis.Engine.UI.Label
End Class
