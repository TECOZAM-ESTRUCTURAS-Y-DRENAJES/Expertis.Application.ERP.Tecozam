<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CIPagoPagaExtra
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CIPagoPagaExtra))
        Me.Panel1 = New Solmicro.Expertis.Engine.UI.Panel
        Me.NtbTotal = New Solmicro.Expertis.Engine.UI.NumericTextBox
        Me.NtbTotalMarcado = New Solmicro.Expertis.Engine.UI.NumericTextBox
        Me.Label2 = New Solmicro.Expertis.Engine.UI.Label
        Me.Label1 = New Solmicro.Expertis.Engine.UI.Label
        Me.LblAño = New Solmicro.Expertis.Engine.UI.Label
        Me.AdvBancoTransf = New Solmicro.Expertis.Engine.UI.AdvSearch
        Me.LblBancoTransf = New Solmicro.Expertis.Engine.UI.Label
        Me.AdvOperario = New Solmicro.Expertis.Engine.UI.AdvSearch
        Me.LblOperario = New Solmicro.Expertis.Engine.UI.Label
        Me.Frame1 = New Solmicro.Expertis.Engine.UI.Frame
        Me.RdbJulio = New Solmicro.Expertis.Engine.UI.RadioButton
        Me.RdbDiciembre = New Solmicro.Expertis.Engine.UI.RadioButton
        Me.CmbMes = New Solmicro.Expertis.Engine.UI.ComboBox
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog
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
        Me.Frame1.SuspendLayout()
        CType(Me.CmbMes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CmbAño, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'FilterPanel
        '
        Me.FilterPanel.Controls.Add(Me.CmbAño)
        Me.FilterPanel.Controls.Add(Me.Frame1)
        Me.FilterPanel.Controls.Add(Me.LblAño)
        Me.FilterPanel.Controls.Add(Me.AdvBancoTransf)
        Me.FilterPanel.Controls.Add(Me.LblBancoTransf)
        Me.FilterPanel.Controls.Add(Me.AdvOperario)
        Me.FilterPanel.Controls.Add(Me.LblOperario)
        Me.FilterPanel.Controls.Add(Me.CmbMes)
        Me.FilterPanel.Size = New System.Drawing.Size(653, 80)
        '
        'CIMntoGridPanel
        '
        Me.CIMntoGridPanel.Controls.Add(Me.Panel1)
        Me.CIMntoGridPanel.Size = New System.Drawing.Size(653, 189)
        Me.CIMntoGridPanel.Controls.SetChildIndex(Me.Panel1, 0)
        Me.CIMntoGridPanel.Controls.SetChildIndex(Me.Grid, 0)
        '
        'Grid
        '
        Grid_DesignTimeLayout.LayoutString = resources.GetString("Grid_DesignTimeLayout.LayoutString")
        Me.Grid.DesignTimeLayout = Grid_DesignTimeLayout
        Me.Grid.EntityName = "Operario"
        Me.Grid.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Grid.KeyField = "IDOperario"
        Me.Grid.Size = New System.Drawing.Size(653, 144)
        Me.Grid.UseCheck = True
        Me.Grid.ViewName = "vTECfrmPagaExtra"
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
        Me.MainPanel.Size = New System.Drawing.Size(653, 269)
        '
        'MainPanelCIMntoContainer
        '
        Me.MainPanelCIMntoContainer.Size = New System.Drawing.Size(653, 269)
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.NtbTotal)
        Me.Panel1.Controls.Add(Me.NtbTotalMarcado)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 144)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(653, 45)
        Me.Panel1.TabIndex = 4
        '
        'NtbTotal
        '
        Me.NtbTotal.DisabledBackColor = System.Drawing.Color.White
        Me.NtbTotal.Enabled = False
        Me.NtbTotal.Location = New System.Drawing.Point(538, 13)
        Me.NtbTotal.Name = "NtbTotal"
        Me.NtbTotal.Size = New System.Drawing.Size(100, 21)
        Me.NtbTotal.TabIndex = 3
        '
        'NtbTotalMarcado
        '
        Me.NtbTotalMarcado.DisabledBackColor = System.Drawing.Color.White
        Me.NtbTotalMarcado.Enabled = False
        Me.NtbTotalMarcado.Location = New System.Drawing.Point(387, 13)
        Me.NtbTotalMarcado.Name = "NtbTotalMarcado"
        Me.NtbTotalMarcado.Size = New System.Drawing.Size(100, 21)
        Me.NtbTotalMarcado.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(497, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(34, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Total"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(294, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(86, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Total Marcado"
        '
        'LblAño
        '
        Me.LblAño.Location = New System.Drawing.Point(221, 28)
        Me.LblAño.Name = "LblAño"
        Me.LblAño.Size = New System.Drawing.Size(29, 13)
        Me.LblAño.TabIndex = 22
        Me.LblAño.Text = "Año"
        '
        'AdvBancoTransf
        '
        Me.AdvBancoTransf.DisabledBackColor = System.Drawing.Color.White
        Me.AdvBancoTransf.EntityName = "BancoPropio"
        Me.AdvBancoTransf.Location = New System.Drawing.Point(105, 49)
        Me.AdvBancoTransf.Name = "AdvBancoTransf"
        Me.AdvBancoTransf.PrimaryDataFields = "IDBancoPropio"
        Me.AdvBancoTransf.SecondaryDataFields = "IDBancoPropio"
        Me.AdvBancoTransf.Size = New System.Drawing.Size(100, 23)
        Me.AdvBancoTransf.TabIndex = 21
        '
        'LblBancoTransf
        '
        Me.LblBancoTransf.Location = New System.Drawing.Point(17, 53)
        Me.LblBancoTransf.Name = "LblBancoTransf"
        Me.LblBancoTransf.Size = New System.Drawing.Size(81, 13)
        Me.LblBancoTransf.TabIndex = 20
        Me.LblBancoTransf.Text = "Banco Trans."
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
        Me.AdvOperario.TabIndex = 19
        '
        'LblOperario
        '
        Me.LblOperario.Location = New System.Drawing.Point(17, 28)
        Me.LblOperario.Name = "LblOperario"
        Me.LblOperario.Size = New System.Drawing.Size(57, 13)
        Me.LblOperario.TabIndex = 18
        Me.LblOperario.Text = "Operario"
        '
        'Frame1
        '
        Me.Frame1.Controls.Add(Me.RdbJulio)
        Me.Frame1.Controls.Add(Me.RdbDiciembre)
        Me.Frame1.Location = New System.Drawing.Point(407, 13)
        Me.Frame1.Name = "Frame1"
        Me.Frame1.Size = New System.Drawing.Size(207, 53)
        Me.Frame1.TabIndex = 24
        Me.Frame1.TabStop = False
        Me.Frame1.Text = "Mes"
        '
        'RdbJulio
        '
        Me.RdbJulio.Checked = True
        Me.RdbJulio.Location = New System.Drawing.Point(11, 17)
        Me.RdbJulio.Name = "RdbJulio"
        Me.RdbJulio.Size = New System.Drawing.Size(69, 23)
        Me.RdbJulio.TabIndex = 1
        Me.RdbJulio.TabStop = True
        Me.RdbJulio.Text = "Julio"
        '
        'RdbDiciembre
        '
        Me.RdbDiciembre.Location = New System.Drawing.Point(111, 17)
        Me.RdbDiciembre.Name = "RdbDiciembre"
        Me.RdbDiciembre.Size = New System.Drawing.Size(104, 23)
        Me.RdbDiciembre.TabIndex = 0
        Me.RdbDiciembre.Text = "Diciembre"
        '
        'CmbMes
        '
        CmbMes_DesignTimeLayout.LayoutString = resources.GetString("CmbMes_DesignTimeLayout.LayoutString")
        Me.CmbMes.DesignTimeLayout = CmbMes_DesignTimeLayout
        Me.CmbMes.DisabledBackColor = System.Drawing.Color.White
        Me.CmbMes.Location = New System.Drawing.Point(297, 24)
        Me.CmbMes.Name = "CmbMes"
        Me.CmbMes.SelectedIndex = -1
        Me.CmbMes.SelectedItem = Nothing
        Me.CmbMes.Size = New System.Drawing.Size(25, 21)
        Me.CmbMes.TabIndex = 25
        '
        'CmbAño
        '
        Me.CmbAño.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        CmbAño_DesignTimeLayout.LayoutString = resources.GetString("CmbAño_DesignTimeLayout.LayoutString")
        Me.CmbAño.DesignTimeLayout = CmbAño_DesignTimeLayout
        Me.CmbAño.DisabledBackColor = System.Drawing.Color.White
        Me.CmbAño.DisplayMember = "Año"
        Me.CmbAño.Location = New System.Drawing.Point(267, 24)
        Me.CmbAño.MaxLength = 4
        Me.CmbAño.Name = "CmbAño"
        Me.CmbAño.SelectedIndex = -1
        Me.CmbAño.SelectedItem = Nothing
        Me.CmbAño.Size = New System.Drawing.Size(100, 21)
        Me.CmbAño.TabIndex = 15
        Me.CmbAño.ValueMember = "Año"
        '
        'CIPagoPagaExtra
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(661, 357)
        Me.EntityName = "Operario"
        Me.KeyField = "IDOperario"
        Me.Name = "CIPagoPagaExtra"
        Me.Text = "CIPagosPagaExtra"
        Me.UseCheck = True
        Me.ViewName = "vTECfrmPagaExtra"
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
        Me.Frame1.ResumeLayout(False)
        CType(Me.CmbMes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CmbAño, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As Solmicro.Expertis.Engine.UI.Panel
    Friend WithEvents NtbTotal As Solmicro.Expertis.Engine.UI.NumericTextBox
    Friend WithEvents NtbTotalMarcado As Solmicro.Expertis.Engine.UI.NumericTextBox
    Friend WithEvents Label2 As Solmicro.Expertis.Engine.UI.Label
    Friend WithEvents Label1 As Solmicro.Expertis.Engine.UI.Label
    Friend WithEvents Frame1 As Solmicro.Expertis.Engine.UI.Frame
    Friend WithEvents RdbJulio As Solmicro.Expertis.Engine.UI.RadioButton
    Friend WithEvents RdbDiciembre As Solmicro.Expertis.Engine.UI.RadioButton
    Friend WithEvents LblAño As Solmicro.Expertis.Engine.UI.Label
    Friend WithEvents AdvBancoTransf As Solmicro.Expertis.Engine.UI.AdvSearch
    Friend WithEvents LblBancoTransf As Solmicro.Expertis.Engine.UI.Label
    Friend WithEvents AdvOperario As Solmicro.Expertis.Engine.UI.AdvSearch
    Friend WithEvents LblOperario As Solmicro.Expertis.Engine.UI.Label
    Friend WithEvents CmbMes As Solmicro.Expertis.Engine.UI.ComboBox
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Public WithEvents CmbAño As Solmicro.Expertis.Engine.UI.ComboBox
End Class
