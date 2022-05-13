<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CIPagoPisos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CIPagoPisos))
        Me.Panel1 = New Solmicro.Expertis.Engine.UI.Panel
        Me.NtbTotal = New Solmicro.Expertis.Engine.UI.NumericTextBox
        Me.NtbTotalMarcado = New Solmicro.Expertis.Engine.UI.NumericTextBox
        Me.Label2 = New Solmicro.Expertis.Engine.UI.Label
        Me.Label1 = New Solmicro.Expertis.Engine.UI.Label
        Me.Label3 = New Solmicro.Expertis.Engine.UI.Label
        Me.AdvBancoTransf = New Solmicro.Expertis.Engine.UI.AdvSearch
        Me.LblBancoTransf = New Solmicro.Expertis.Engine.UI.Label
        Me.AdvProveedor = New Solmicro.Expertis.Engine.UI.AdvSearch
        Me.UlbDescProveedor = New Solmicro.Expertis.Engine.UI.UnderLineLabel
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog
        Me.FilterPanel.SuspendLayout()
        Me.CIMntoGridPanel.suspendlayout()
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiCommandManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Toolbar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Menubar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MainPanel.SuspendLayout()
        Me.MainPanelCIMntoContainer.SuspendLayout()
        Me.Panel1.suspendlayout()
        Me.SuspendLayout()
        '
        'FilterPanel
        '
        Me.FilterPanel.Controls.Add(Me.UlbDescProveedor)
        Me.FilterPanel.Controls.Add(Me.AdvProveedor)
        Me.FilterPanel.Controls.Add(Me.AdvBancoTransf)
        Me.FilterPanel.Controls.Add(Me.LblBancoTransf)
        Me.FilterPanel.Controls.Add(Me.Label3)
        Me.FilterPanel.Size = New System.Drawing.Size(651, 80)
        '
        'CIMntoGridPanel
        '
        Me.CIMntoGridPanel.Controls.Add(Me.Panel1)
        Me.CIMntoGridPanel.Size = New System.Drawing.Size(651, 189)
        Me.CIMntoGridPanel.Controls.SetChildIndex(Me.Panel1, 0)
        Me.CIMntoGridPanel.Controls.SetChildIndex(Me.Grid, 0)
        '
        'Grid
        '
        Grid_DesignTimeLayout.LayoutString = resources.GetString("Grid_DesignTimeLayout.LayoutString")
        Me.Grid.DesignTimeLayout = Grid_DesignTimeLayout
        Me.Grid.EntityName = "Proveedor"
        Me.Grid.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Grid.KeyField = "IDProveedor"
        Me.Grid.Size = New System.Drawing.Size(651, 144)
        Me.Grid.UseCheck = True
        Me.Grid.ViewName = "vTECFrmPagoPisos"
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
        Me.MainPanel.Size = New System.Drawing.Size(651, 269)
        '
        'MainPanelCIMntoContainer
        '
        Me.MainPanelCIMntoContainer.Size = New System.Drawing.Size(651, 269)
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
        Me.Panel1.Size = New System.Drawing.Size(651, 45)
        Me.Panel1.TabIndex = 5
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
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(18, 26)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(66, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Proveedor"
        '
        'AdvBancoTransf
        '
        Me.AdvBancoTransf.DisabledBackColor = System.Drawing.Color.White
        Me.AdvBancoTransf.EntityName = "BancoPropio"
        Me.AdvBancoTransf.Location = New System.Drawing.Point(106, 47)
        Me.AdvBancoTransf.Name = "AdvBancoTransf"
        Me.AdvBancoTransf.PrimaryDataFields = "IDBancoPropio"
        Me.AdvBancoTransf.SecondaryDataFields = "IDBancoPropio"
        Me.AdvBancoTransf.Size = New System.Drawing.Size(100, 23)
        Me.AdvBancoTransf.TabIndex = 23
        '
        'LblBancoTransf
        '
        Me.LblBancoTransf.Location = New System.Drawing.Point(18, 51)
        Me.LblBancoTransf.Name = "LblBancoTransf"
        Me.LblBancoTransf.Size = New System.Drawing.Size(81, 13)
        Me.LblBancoTransf.TabIndex = 22
        Me.LblBancoTransf.Text = "Banco Trans."
        '
        'AdvProveedor
        '
        Me.AdvProveedor.DisabledBackColor = System.Drawing.Color.White
        Me.AdvProveedor.EntityName = "Proveedor"
        Me.AdvProveedor.Location = New System.Drawing.Point(106, 20)
        Me.AdvProveedor.Name = "AdvProveedor"
        Me.AdvProveedor.PrimaryDataFields = "IDProveedor"
        Me.AdvProveedor.SecondaryDataFields = "IDProveedor"
        Me.AdvProveedor.Size = New System.Drawing.Size(100, 23)
        Me.AdvProveedor.TabIndex = 24
        '
        'UlbDescProveedor
        '
        Me.TryDataBinding(UlbDescProveedor, New System.Windows.Forms.Binding("Text", Me.AdvProveedor, "DescProveedor", True))
        Me.UlbDescProveedor.Location = New System.Drawing.Point(212, 23)
        Me.UlbDescProveedor.Name = "UlbDescProveedor"
        Me.UlbDescProveedor.Size = New System.Drawing.Size(320, 23)
        Me.UlbDescProveedor.TabIndex = 25
        '
        'CIPagoPisos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(659, 357)
        Me.EntityName = "Proveedor"
        Me.KeyField = "IDProveedor"
        Me.Name = "CIPagoPisos"
        Me.Text = "CIPagoPisos"
        Me.UseCheck = True
        Me.ViewName = "vTECFrmPagoPisos"
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
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As Solmicro.Expertis.Engine.UI.Panel
    Friend WithEvents NtbTotal As Solmicro.Expertis.Engine.UI.NumericTextBox
    Friend WithEvents NtbTotalMarcado As Solmicro.Expertis.Engine.UI.NumericTextBox
    Friend WithEvents Label2 As Solmicro.Expertis.Engine.UI.Label
    Friend WithEvents Label1 As Solmicro.Expertis.Engine.UI.Label
    Friend WithEvents Label3 As Solmicro.Expertis.Engine.UI.Label
    Friend WithEvents UlbDescProveedor As Solmicro.Expertis.Engine.UI.UnderLineLabel
    Friend WithEvents AdvProveedor As Solmicro.Expertis.Engine.UI.AdvSearch
    Friend WithEvents AdvBancoTransf As Solmicro.Expertis.Engine.UI.AdvSearch
    Friend WithEvents LblBancoTransf As Solmicro.Expertis.Engine.UI.Label
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
End Class
