<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CIPagoLiquidaciones
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
        Dim CmbMes_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim CmbAño_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CIPagoLiquidaciones))
        Me.Panel1 = New Solmicro.Expertis.Engine.UI.Panel
        Me.ClbFechaVto = New Solmicro.Expertis.Engine.UI.CalendarBox
        Me.LblFechaVto = New Solmicro.Expertis.Engine.UI.Label
        Me.NtbTotal = New Solmicro.Expertis.Engine.UI.NumericTextBox
        Me.NtbTotalMarcado = New Solmicro.Expertis.Engine.UI.NumericTextBox
        Me.Label2 = New Solmicro.Expertis.Engine.UI.Label
        Me.Label1 = New Solmicro.Expertis.Engine.UI.Label
        Me.LblAño = New Solmicro.Expertis.Engine.UI.Label
        Me.LblMes = New Solmicro.Expertis.Engine.UI.Label
        Me.AdvOperario = New Solmicro.Expertis.Engine.UI.AdvSearch
        Me.LblOperario = New Solmicro.Expertis.Engine.UI.Label
        Me.CmbMes = New Solmicro.Expertis.Engine.UI.ComboBox
        Me.CmbAño = New Solmicro.Expertis.Engine.UI.ComboBox
        Me.FilterPanel.SuspendLayout()
        Me.CIMntoGridPanel.suspendlayout()
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiCommandManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Toolbar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Menubar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MainPanel.SuspendLayout()
        Me.MainPanelCIMntoContainer.SuspendLayout()
        Me.Panel1.suspendlayout()
        CType(Me.CmbMes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CmbAño, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'FilterPanel
        '
        Me.FilterPanel.Controls.Add(Me.CmbAño)
        Me.FilterPanel.Controls.Add(Me.CmbMes)
        Me.FilterPanel.Controls.Add(Me.LblAño)
        Me.FilterPanel.Controls.Add(Me.LblMes)
        Me.FilterPanel.Controls.Add(Me.AdvOperario)
        Me.FilterPanel.Controls.Add(Me.LblOperario)
        Me.FilterPanel.Location = New System.Drawing.Point(0, 213)
        Me.FilterPanel.Size = New System.Drawing.Size(755, 56)
        '
        'CIMntoGridPanel
        '
        Me.CIMntoGridPanel.Controls.Add(Me.Panel1)
        Me.CIMntoGridPanel.Size = New System.Drawing.Size(755, 213)
        Me.CIMntoGridPanel.Controls.SetChildIndex(Me.Panel1, 0)
        Me.CIMntoGridPanel.Controls.SetChildIndex(Me.Grid, 0)
        '
        'Grid
        '
        Grid_DesignTimeLayout.LayoutString = resources.GetString("Grid_DesignTimeLayout.LayoutString")
        Me.Grid.DesignTimeLayout = Grid_DesignTimeLayout
        Me.Grid.EntityName = "Operario"
        Me.Grid.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.Grid.KeyField = "IDOperario"
        Me.Grid.Size = New System.Drawing.Size(755, 168)
        Me.Grid.UseCheck = True
        Me.Grid.ViewName = "vTECFrmPagoPagare"
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
        Me.MainPanel.Size = New System.Drawing.Size(755, 269)
        '
        'MainPanelCIMntoContainer
        '
        Me.MainPanelCIMntoContainer.Size = New System.Drawing.Size(755, 269)
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.ClbFechaVto)
        Me.Panel1.Controls.Add(Me.LblFechaVto)
        Me.Panel1.Controls.Add(Me.NtbTotal)
        Me.Panel1.Controls.Add(Me.NtbTotalMarcado)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 168)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(755, 45)
        Me.Panel1.TabIndex = 2
        '
        'ClbFechaVto
        '
        Me.ClbFechaVto.CustomFormat = "dd                MMMM                        yyyy"
        Me.ClbFechaVto.DateFormat = Janus.Windows.CalendarCombo.DateFormat.Custom
        Me.ClbFechaVto.DisabledBackColor = System.Drawing.Color.White
        Me.ClbFechaVto.Location = New System.Drawing.Point(123, 12)
        Me.ClbFechaVto.Name = "ClbFechaVto"
        Me.ClbFechaVto.Size = New System.Drawing.Size(235, 21)
        Me.ClbFechaVto.TabIndex = 5
        '
        'LblFechaVto
        '
        Me.LblFechaVto.Location = New System.Drawing.Point(11, 14)
        Me.LblFechaVto.Name = "LblFechaVto"
        Me.LblFechaVto.Size = New System.Drawing.Size(114, 13)
        Me.LblFechaVto.TabIndex = 4
        Me.LblFechaVto.Text = "Fecha Vencimiento"
        '
        'NtbTotal
        '
        Me.NtbTotal.DisabledBackColor = System.Drawing.Color.White
        Me.NtbTotal.Enabled = False
        Me.NtbTotal.Location = New System.Drawing.Point(638, 10)
        Me.NtbTotal.Name = "NtbTotal"
        Me.NtbTotal.Size = New System.Drawing.Size(100, 21)
        Me.NtbTotal.TabIndex = 3
        '
        'NtbTotalMarcado
        '
        Me.NtbTotalMarcado.DisabledBackColor = System.Drawing.Color.White
        Me.NtbTotalMarcado.Enabled = False
        Me.NtbTotalMarcado.Location = New System.Drawing.Point(487, 10)
        Me.NtbTotalMarcado.Name = "NtbTotalMarcado"
        Me.NtbTotalMarcado.Size = New System.Drawing.Size(100, 21)
        Me.NtbTotalMarcado.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(597, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(35, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Total"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(394, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(87, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Total Marcado"
        '
        'LblAño
        '
        Me.LblAño.Location = New System.Drawing.Point(394, 28)
        Me.LblAño.Name = "LblAño"
        Me.LblAño.Size = New System.Drawing.Size(29, 13)
        Me.LblAño.TabIndex = 16
        Me.LblAño.Text = "Año"
        '
        'LblMes
        '
        Me.LblMes.Location = New System.Drawing.Point(221, 28)
        Me.LblMes.Name = "LblMes"
        Me.LblMes.Size = New System.Drawing.Size(29, 13)
        Me.LblMes.TabIndex = 14
        Me.LblMes.Text = "Mes"
        '
        'AdvOperario
        '
        Me.AdvOperario.DisabledBackColor = System.Drawing.Color.White
        Me.AdvOperario.EntityName = "Operario"
        Me.AdvOperario.Location = New System.Drawing.Point(105, 22)
        Me.AdvOperario.Name = "AdvOperario"
        Me.AdvOperario.PrimaryDataFields = "IDOperario"
        Me.AdvOperario.SecondaryDataFields = "IDOperario"
        Me.AdvOperario.Size = New System.Drawing.Size(100, 23)
        Me.AdvOperario.TabIndex = 13
        '
        'LblOperario
        '
        Me.LblOperario.Location = New System.Drawing.Point(17, 28)
        Me.LblOperario.Name = "LblOperario"
        Me.LblOperario.Size = New System.Drawing.Size(57, 13)
        Me.LblOperario.TabIndex = 12
        Me.LblOperario.Text = "Operario"
        '
        'CmbMes
        '
        CmbMes_DesignTimeLayout.LayoutString = resources.GetString("CmbMes_DesignTimeLayout.LayoutString")
        Me.CmbMes.DesignTimeLayout = CmbMes_DesignTimeLayout
        Me.CmbMes.DisabledBackColor = System.Drawing.Color.White
        Me.CmbMes.DisplayMember = "Text"
        Me.CmbMes.Location = New System.Drawing.Point(256, 22)
        Me.CmbMes.Name = "CmbMes"
        Me.CmbMes.SelectedIndex = -1
        Me.CmbMes.SelectedItem = Nothing
        Me.CmbMes.Size = New System.Drawing.Size(132, 21)
        Me.CmbMes.TabIndex = 18
        Me.CmbMes.ValueMember = "value"
        '
        'CmbAño
        '
        Me.CmbAño.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        CmbAño_DesignTimeLayout.LayoutString = resources.GetString("CmbAño_DesignTimeLayout.LayoutString")
        Me.CmbAño.DesignTimeLayout = CmbAño_DesignTimeLayout
        Me.CmbAño.DisabledBackColor = System.Drawing.Color.White
        Me.CmbAño.DisplayMember = "Año"
        Me.CmbAño.Location = New System.Drawing.Point(429, 22)
        Me.CmbAño.MaxLength = 4
        Me.CmbAño.Name = "CmbAño"
        Me.CmbAño.SelectedIndex = -1
        Me.CmbAño.SelectedItem = Nothing
        Me.CmbAño.Size = New System.Drawing.Size(100, 21)
        Me.CmbAño.TabIndex = 19
        Me.CmbAño.ValueMember = "Año"
        '
        'CIPagoLiquidaciones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(763, 357)
        Me.EntityName = "Operario"
        Me.KeyField = "IDOperario"
        Me.Name = "CIPagoLiquidaciones"
        Me.Text = "CIPagosLiquidacion"
        Me.UseCheck = True
        Me.ViewName = "vTECFrmPagoPagare"
        Me.FilterPanel.ResumeLayout(False)
        Me.FilterPanel.PerformLayout()
        Me.CIMntoGridPanel.ResumeLayout(False)
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiCommandManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Toolbar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Menubar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MainPanel.ResumeLayout(False)
        Me.MainPanelCIMntoContainer.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.CmbMes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CmbAño, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As Solmicro.Expertis.Engine.UI.Panel
    Friend WithEvents NtbTotal As Solmicro.Expertis.Engine.UI.NumericTextBox
    Friend WithEvents NtbTotalMarcado As Solmicro.Expertis.Engine.UI.NumericTextBox
    Friend WithEvents Label2 As Solmicro.Expertis.Engine.UI.Label
    Friend WithEvents Label1 As Solmicro.Expertis.Engine.UI.Label
    Friend WithEvents LblAño As Solmicro.Expertis.Engine.UI.Label
    Friend WithEvents LblMes As Solmicro.Expertis.Engine.UI.Label
    Friend WithEvents AdvOperario As Solmicro.Expertis.Engine.UI.AdvSearch
    Friend WithEvents LblOperario As Solmicro.Expertis.Engine.UI.Label
    Friend WithEvents ClbFechaVto As Solmicro.Expertis.Engine.UI.CalendarBox
    Friend WithEvents LblFechaVto As Solmicro.Expertis.Engine.UI.Label
    Friend WithEvents CmbMes As Solmicro.Expertis.Engine.UI.ComboBox
    Public WithEvents CmbAño As Solmicro.Expertis.Engine.UI.ComboBox
End Class
