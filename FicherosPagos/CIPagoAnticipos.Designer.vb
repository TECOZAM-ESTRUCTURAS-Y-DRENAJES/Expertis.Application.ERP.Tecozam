﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CIPagoAnticipos
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
        Dim CmbPolacos_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CIPagoAnticipos))
        Me.Panel1 = New Solmicro.Expertis.Engine.UI.Panel
        Me.NtbTotal = New Solmicro.Expertis.Engine.UI.NumericTextBox
        Me.NtbTotalMarcado = New Solmicro.Expertis.Engine.UI.NumericTextBox
        Me.Label2 = New Solmicro.Expertis.Engine.UI.Label
        Me.Label1 = New Solmicro.Expertis.Engine.UI.Label
        Me.LblOperario = New Solmicro.Expertis.Engine.UI.Label
        Me.AdvOperario = New Solmicro.Expertis.Engine.UI.AdvSearch
        Me.LblBancoTransf = New Solmicro.Expertis.Engine.UI.Label
        Me.AdvBancoTransf = New Solmicro.Expertis.Engine.UI.AdvSearch
        Me.LblPolacos = New Solmicro.Expertis.Engine.UI.Label
        Me.CmbPolacos = New Solmicro.Expertis.Engine.UI.ComboBox
        Me.FilterPanel.SuspendLayout()
        Me.CIMntoGridPanel.suspendlayout()
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiCommandManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Toolbar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Menubar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MainPanel.SuspendLayout()
        Me.MainPanelCIMntoContainer.SuspendLayout()
        Me.Panel1.suspendlayout()
        CType(Me.CmbPolacos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'FilterPanel
        '
        Me.FilterPanel.Controls.Add(Me.CmbPolacos)
        Me.FilterPanel.Controls.Add(Me.LblPolacos)
        Me.FilterPanel.Controls.Add(Me.AdvBancoTransf)
        Me.FilterPanel.Controls.Add(Me.LblBancoTransf)
        Me.FilterPanel.Controls.Add(Me.AdvOperario)
        Me.FilterPanel.Controls.Add(Me.LblOperario)
        Me.FilterPanel.Location = New System.Drawing.Point(0, 198)
        Me.FilterPanel.Size = New System.Drawing.Size(536, 78)
        '
        'CIMntoGridPanel
        '
        Me.CIMntoGridPanel.Controls.Add(Me.Panel1)
        Me.CIMntoGridPanel.Size = New System.Drawing.Size(536, 198)
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
        Me.Grid.Size = New System.Drawing.Size(536, 153)
        Me.Grid.UseCheck = True
        Me.Grid.ViewName = "vTECFrmPagoAnticipo"
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
        Me.MainPanel.Size = New System.Drawing.Size(536, 276)
        '
        'MainPanelCIMntoContainer
        '
        Me.MainPanelCIMntoContainer.Size = New System.Drawing.Size(536, 276)
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.NtbTotal)
        Me.Panel1.Controls.Add(Me.NtbTotalMarcado)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 153)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(536, 45)
        Me.Panel1.TabIndex = 1
        '
        'NtbTotal
        '
        Me.NtbTotal.DisabledBackColor = System.Drawing.Color.White
        Me.NtbTotal.Enabled = False
        Me.NtbTotal.Location = New System.Drawing.Point(429, 12)
        Me.NtbTotal.Name = "NtbTotal"
        Me.NtbTotal.Size = New System.Drawing.Size(100, 21)
        Me.NtbTotal.TabIndex = 3
        '
        'NtbTotalMarcado
        '
        Me.NtbTotalMarcado.DisabledBackColor = System.Drawing.Color.White
        Me.NtbTotalMarcado.Enabled = False
        Me.NtbTotalMarcado.Location = New System.Drawing.Point(278, 12)
        Me.NtbTotalMarcado.Name = "NtbTotalMarcado"
        Me.NtbTotalMarcado.Size = New System.Drawing.Size(100, 21)
        Me.NtbTotalMarcado.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(388, 14)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(35, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Total"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(185, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(87, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Total Marcado"
        '
        'LblOperario
        '
        Me.LblOperario.Location = New System.Drawing.Point(8, 26)
        Me.LblOperario.Name = "LblOperario"
        Me.LblOperario.Size = New System.Drawing.Size(57, 13)
        Me.LblOperario.TabIndex = 0
        Me.LblOperario.Text = "Operario"
        '
        'AdvOperario
        '
        Me.AdvOperario.DisabledBackColor = System.Drawing.Color.White
        Me.AdvOperario.EntityName = "Operario"
        Me.AdvOperario.Location = New System.Drawing.Point(96, 20)
        Me.AdvOperario.Name = "AdvOperario"
        Me.AdvOperario.PrimaryDataFields = "IDOperario"
        Me.AdvOperario.SecondaryDataFields = "IDOperario"
        Me.AdvOperario.Size = New System.Drawing.Size(100, 23)
        Me.AdvOperario.TabIndex = 1
        '
        'LblBancoTransf
        '
        Me.LblBancoTransf.Location = New System.Drawing.Point(8, 51)
        Me.LblBancoTransf.Name = "LblBancoTransf"
        Me.LblBancoTransf.Size = New System.Drawing.Size(82, 13)
        Me.LblBancoTransf.TabIndex = 2
        Me.LblBancoTransf.Text = "Banco Trans."
        '
        'AdvBancoTransf
        '
        Me.AdvBancoTransf.DisabledBackColor = System.Drawing.Color.White
        Me.AdvBancoTransf.EntityName = "BancoPropio"
        Me.AdvBancoTransf.Location = New System.Drawing.Point(96, 47)
        Me.AdvBancoTransf.Name = "AdvBancoTransf"
        Me.AdvBancoTransf.PrimaryDataFields = "IDBancoPropio"
        Me.AdvBancoTransf.SecondaryDataFields = "IDBancoPropio"
        Me.AdvBancoTransf.Size = New System.Drawing.Size(100, 23)
        Me.AdvBancoTransf.TabIndex = 3
        '
        'LblPolacos
        '
        Me.LblPolacos.Location = New System.Drawing.Point(260, 26)
        Me.LblPolacos.Name = "LblPolacos"
        Me.LblPolacos.Size = New System.Drawing.Size(50, 13)
        Me.LblPolacos.TabIndex = 4
        Me.LblPolacos.Text = "Polacos"
        '
        'CmbPolacos
        '
        CmbPolacos_DesignTimeLayout.LayoutString = resources.GetString("CmbPolacos_DesignTimeLayout.LayoutString")
        Me.CmbPolacos.DesignTimeLayout = CmbPolacos_DesignTimeLayout
        Me.CmbPolacos.DisabledBackColor = System.Drawing.Color.White
        Me.CmbPolacos.Location = New System.Drawing.Point(316, 22)
        Me.CmbPolacos.Name = "CmbPolacos"
        Me.CmbPolacos.SelectedIndex = -1
        Me.CmbPolacos.SelectedItem = Nothing
        Me.CmbPolacos.Size = New System.Drawing.Size(100, 21)
        Me.CmbPolacos.TabIndex = 5
        '
        'CIPagoAnticipos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(544, 364)
        Me.EntityName = "Operario"
        Me.KeyField = "IDOperario"
        Me.Name = "CIPagoAnticipos"
        Me.Text = "CIPagoAnticipos"
        Me.UseCheck = True
        Me.ViewName = "vTECFrmPagoAnticipo"
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
        CType(Me.CmbPolacos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CmbPolacos As Solmicro.Expertis.Engine.UI.ComboBox
    Friend WithEvents LblPolacos As Solmicro.Expertis.Engine.UI.Label
    Friend WithEvents AdvBancoTransf As Solmicro.Expertis.Engine.UI.AdvSearch
    Friend WithEvents LblBancoTransf As Solmicro.Expertis.Engine.UI.Label
    Friend WithEvents AdvOperario As Solmicro.Expertis.Engine.UI.AdvSearch
    Friend WithEvents LblOperario As Solmicro.Expertis.Engine.UI.Label
    Friend WithEvents Panel1 As Solmicro.Expertis.Engine.UI.Panel
    Friend WithEvents NtbTotal As Solmicro.Expertis.Engine.UI.NumericTextBox
    Friend WithEvents NtbTotalMarcado As Solmicro.Expertis.Engine.UI.NumericTextBox
    Friend WithEvents Label2 As Solmicro.Expertis.Engine.UI.Label
    Friend WithEvents Label1 As Solmicro.Expertis.Engine.UI.Label
End Class
