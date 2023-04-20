<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CIInsertarFacturasDocuware
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
        Dim cbBasededatos_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim cbInsertada_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim cbTransferida_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CIInsertarFacturasDocuware))
        Me.Label1 = New Solmicro.Expertis.Engine.UI.Label
        Me.Label2 = New Solmicro.Expertis.Engine.UI.Label
        Me.Label3 = New Solmicro.Expertis.Engine.UI.Label
        Me.Label4 = New Solmicro.Expertis.Engine.UI.Label
        Me.Label5 = New Solmicro.Expertis.Engine.UI.Label
        Me.Label6 = New Solmicro.Expertis.Engine.UI.Label
        Me.Label7 = New Solmicro.Expertis.Engine.UI.Label
        Me.Label8 = New Solmicro.Expertis.Engine.UI.Label
        Me.txtSuFactura = New Solmicro.Expertis.Engine.UI.TextBox
        Me.advProveedor = New Solmicro.Expertis.Engine.UI.AdvSearch
        Me.cbBasededatos = New Solmicro.Expertis.Engine.UI.ComboBox
        Me.advNObra = New Solmicro.Expertis.Engine.UI.AdvSearch
        Me.cbFIni = New Solmicro.Expertis.Engine.UI.CalendarBox
        Me.cbFFin = New Solmicro.Expertis.Engine.UI.CalendarBox
        Me.cbInsertada = New Solmicro.Expertis.Engine.UI.ComboBox
        Me.cbTransferida = New Solmicro.Expertis.Engine.UI.ComboBox
        Me.FilterPanel.SuspendLayout()
        Me.CIMntoGridPanel.suspendlayout()
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiCommandManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Toolbar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Menubar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MainPanel.SuspendLayout()
        Me.MainPanelCIMntoContainer.SuspendLayout()
        CType(Me.cbBasededatos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbInsertada, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbTransferida, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'FilterPanel
        '
        Me.FilterPanel.Controls.Add(Me.cbTransferida)
        Me.FilterPanel.Controls.Add(Me.cbInsertada)
        Me.FilterPanel.Controls.Add(Me.cbFFin)
        Me.FilterPanel.Controls.Add(Me.cbFIni)
        Me.FilterPanel.Controls.Add(Me.advNObra)
        Me.FilterPanel.Controls.Add(Me.cbBasededatos)
        Me.FilterPanel.Controls.Add(Me.advProveedor)
        Me.FilterPanel.Controls.Add(Me.txtSuFactura)
        Me.FilterPanel.Controls.Add(Me.Label8)
        Me.FilterPanel.Controls.Add(Me.Label7)
        Me.FilterPanel.Controls.Add(Me.Label6)
        Me.FilterPanel.Controls.Add(Me.Label5)
        Me.FilterPanel.Controls.Add(Me.Label4)
        Me.FilterPanel.Controls.Add(Me.Label3)
        Me.FilterPanel.Controls.Add(Me.Label2)
        Me.FilterPanel.Controls.Add(Me.Label1)
        Me.FilterPanel.Location = New System.Drawing.Point(0, 168)
        Me.FilterPanel.Size = New System.Drawing.Size(861, 101)
        '
        'CIMntoGridPanel
        '
        Me.CIMntoGridPanel.Size = New System.Drawing.Size(861, 168)
        '
        'Grid
        '
        Grid_DesignTimeLayout.LayoutString = resources.GetString("Grid_DesignTimeLayout.LayoutString")
        Me.Grid.DesignTimeLayout = Grid_DesignTimeLayout
        Me.Grid.EntityName = "FacturaDocuware"
        Me.Grid.KeyField = "IDFacturaDocuware"
        Me.Grid.PrimaryDataFields = "IDFacturaDocuware"
        Me.Grid.SecondaryDataFields = "IDFacturaDocuware"
        Me.Grid.Size = New System.Drawing.Size(861, 168)
        Me.Grid.UseCheck = True
        Me.Grid.ViewName = "vFacturasDocuware"
        '
        'CheckAll
        '
        Me.CheckAll.Visible = Janus.Windows.UI.InheritableBoolean.[True]
        '
        'UncheckAll
        '
        Me.UncheckAll.Visible = Janus.Windows.UI.InheritableBoolean.[True]
        '
        'ShowAllCheckedItems
        '
        Me.ShowAllCheckedItems.Visible = Janus.Windows.UI.InheritableBoolean.[True]
        '
        'Toolbar
        '
        Me.Toolbar.Size = New System.Drawing.Size(320, 28)
        '
        'Menubar
        '
        Me.Menubar.Location = New System.Drawing.Point(0, 28)
        '
        'MainPanel
        '
        Me.MainPanel.Size = New System.Drawing.Size(861, 269)
        '
        'MainPanelCIMntoContainer
        '
        Me.MainPanelCIMntoContainer.Size = New System.Drawing.Size(861, 269)
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(26, 32)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "SuFactura"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(26, 63)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Base de datos"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(431, 28)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(107, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Fecha Factura >="
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(431, 61)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(107, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Fecha Factura <="
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(232, 32)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(66, 13)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Proveedor"
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(232, 63)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(43, 13)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "NObra"
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(665, 28)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(55, 13)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "Creadas"
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(665, 59)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(71, 13)
        Me.Label8.TabIndex = 7
        Me.Label8.Text = "Transferida"
        '
        'txtSuFactura
        '
        Me.txtSuFactura.DisabledBackColor = System.Drawing.Color.White
        Me.txtSuFactura.Location = New System.Drawing.Point(118, 28)
        Me.txtSuFactura.Name = "txtSuFactura"
        Me.txtSuFactura.Size = New System.Drawing.Size(96, 21)
        Me.txtSuFactura.TabIndex = 30
        '
        'advProveedor
        '
        Me.TryDataBinding(advProveedor, New System.Windows.Forms.Binding("Text", Me, "IDProveedor", True))
        Me.advProveedor.DisabledBackColor = System.Drawing.Color.White
        Me.advProveedor.DisplayField = "IDProveedor"
        Me.advProveedor.EntityName = "Proveedor"
        Me.advProveedor.Location = New System.Drawing.Point(304, 26)
        Me.advProveedor.Name = "advProveedor"
        Me.advProveedor.PrimaryDataFields = "IDProveedor"
        Me.advProveedor.SecondaryDataFields = "IDProveedor"
        Me.advProveedor.Size = New System.Drawing.Size(100, 23)
        Me.advProveedor.TabIndex = 32
        Me.advProveedor.ViewName = "tbMaestroProveedor"
        '
        'cbBasededatos
        '
        cbBasededatos_DesignTimeLayout.LayoutString = resources.GetString("cbBasededatos_DesignTimeLayout.LayoutString")
        Me.cbBasededatos.DesignTimeLayout = cbBasededatos_DesignTimeLayout
        Me.cbBasededatos.DisabledBackColor = System.Drawing.Color.White
        Me.cbBasededatos.Location = New System.Drawing.Point(118, 59)
        Me.cbBasededatos.Name = "cbBasededatos"
        Me.cbBasededatos.SelectedIndex = -1
        Me.cbBasededatos.SelectedItem = Nothing
        Me.cbBasededatos.Size = New System.Drawing.Size(96, 21)
        Me.cbBasededatos.TabIndex = 31
        '
        'advNObra
        '
        Me.TryDataBinding(advNObra, New System.Windows.Forms.Binding("Text", Me, "NObra", True))
        Me.advNObra.DisabledBackColor = System.Drawing.Color.White
        Me.advNObra.DisplayField = "NObra"
        Me.advNObra.EntityName = "ObraCabecera"
        Me.advNObra.Location = New System.Drawing.Point(304, 56)
        Me.advNObra.Name = "advNObra"
        Me.advNObra.PrimaryDataFields = "NObra"
        Me.advNObra.SecondaryDataFields = "NObra"
        Me.advNObra.Size = New System.Drawing.Size(100, 23)
        Me.advNObra.TabIndex = 33
        Me.advNObra.ViewName = "tbObraCabecera"
        '
        'cbFIni
        '
        Me.cbFIni.DisabledBackColor = System.Drawing.Color.White
        Me.cbFIni.Location = New System.Drawing.Point(554, 27)
        Me.cbFIni.Name = "cbFIni"
        Me.cbFIni.Size = New System.Drawing.Size(92, 21)
        Me.cbFIni.TabIndex = 34
        '
        'cbFFin
        '
        Me.cbFFin.DisabledBackColor = System.Drawing.Color.White
        Me.cbFFin.Location = New System.Drawing.Point(554, 58)
        Me.cbFFin.Name = "cbFFin"
        Me.cbFFin.Size = New System.Drawing.Size(92, 21)
        Me.cbFFin.TabIndex = 35
        '
        'cbInsertada
        '
        cbInsertada_DesignTimeLayout.LayoutString = resources.GetString("cbInsertada_DesignTimeLayout.LayoutString")
        Me.cbInsertada.DesignTimeLayout = cbInsertada_DesignTimeLayout
        Me.cbInsertada.DisabledBackColor = System.Drawing.Color.White
        Me.cbInsertada.Location = New System.Drawing.Point(743, 24)
        Me.cbInsertada.Name = "cbInsertada"
        Me.cbInsertada.SelectedIndex = -1
        Me.cbInsertada.SelectedItem = Nothing
        Me.cbInsertada.Size = New System.Drawing.Size(100, 21)
        Me.cbInsertada.TabIndex = 38
        Me.cbInsertada.Text = "NO"
        '
        'cbTransferida
        '
        cbTransferida_DesignTimeLayout.LayoutString = resources.GetString("cbTransferida_DesignTimeLayout.LayoutString")
        Me.cbTransferida.DesignTimeLayout = cbTransferida_DesignTimeLayout
        Me.cbTransferida.DisabledBackColor = System.Drawing.Color.White
        Me.cbTransferida.Location = New System.Drawing.Point(743, 56)
        Me.cbTransferida.Name = "cbTransferida"
        Me.cbTransferida.SelectedIndex = -1
        Me.cbTransferida.SelectedItem = Nothing
        Me.cbTransferida.Size = New System.Drawing.Size(100, 21)
        Me.cbTransferida.TabIndex = 39
        '
        'CIInsertarFacturasDocuware
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(869, 357)
        Me.CreateTransaction = True
        Me.EntityName = "FacturaDocuware"
        Me.KeyField = "IDFacturaDocuware"
        Me.Name = "CIInsertarFacturasDocuware"
        Me.Text = "CI Crear Facturas Proveedores Docuware"
        Me.UseCheck = True
        Me.ViewName = "vFacturasDocuware"
        Me.FilterPanel.ResumeLayout(False)
        Me.FilterPanel.PerformLayout()
        Me.CIMntoGridPanel.ResumeLayout(False)
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiCommandManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Toolbar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Menubar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MainPanel.ResumeLayout(False)
        Me.MainPanelCIMntoContainer.ResumeLayout(False)
        CType(Me.cbBasededatos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbInsertada, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbTransferida, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label3 As Solmicro.Expertis.Engine.UI.Label
    Friend WithEvents Label2 As Solmicro.Expertis.Engine.UI.Label
    Friend WithEvents Label1 As Solmicro.Expertis.Engine.UI.Label
    Friend WithEvents Label4 As Solmicro.Expertis.Engine.UI.Label
    Friend WithEvents Label8 As Solmicro.Expertis.Engine.UI.Label
    Friend WithEvents Label7 As Solmicro.Expertis.Engine.UI.Label
    Friend WithEvents Label6 As Solmicro.Expertis.Engine.UI.Label
    Friend WithEvents Label5 As Solmicro.Expertis.Engine.UI.Label
    Friend WithEvents txtSuFactura As Solmicro.Expertis.Engine.UI.TextBox
    Friend WithEvents advProveedor As Solmicro.Expertis.Engine.UI.AdvSearch
    Friend WithEvents cbFFin As Solmicro.Expertis.Engine.UI.CalendarBox
    Friend WithEvents cbFIni As Solmicro.Expertis.Engine.UI.CalendarBox
    Friend WithEvents advNObra As Solmicro.Expertis.Engine.UI.AdvSearch
    Friend WithEvents cbBasededatos As Solmicro.Expertis.Engine.UI.ComboBox
    Friend WithEvents cbTransferida As Solmicro.Expertis.Engine.UI.ComboBox
    Friend WithEvents cbInsertada As Solmicro.Expertis.Engine.UI.ComboBox
End Class
