<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmContadorFacturasDocuware
    Inherits Solmicro.Expertis.Engine.UI.FormBase

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
        Me.FrmDatos = New Solmicro.Expertis.Engine.UI.Frame
        Me.bCancelar = New Solmicro.Expertis.Engine.UI.Button
        Me.bAceptar = New Solmicro.Expertis.Engine.UI.Button
        Me.AdvContador = New Solmicro.Expertis.Engine.UI.AdvSearch
        Me.LblContador = New Solmicro.Expertis.Engine.UI.Label
        Me.FrmDatos.SuspendLayout()
        Me.SuspendLayout()
        '
        'FrmDatos
        '
        Me.FrmDatos.Controls.Add(Me.bCancelar)
        Me.FrmDatos.Controls.Add(Me.bAceptar)
        Me.FrmDatos.Controls.Add(Me.AdvContador)
        Me.FrmDatos.Controls.Add(Me.LblContador)
        Me.FrmDatos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FrmDatos.Location = New System.Drawing.Point(0, 0)
        Me.FrmDatos.Name = "FrmDatos"
        Me.FrmDatos.Size = New System.Drawing.Size(302, 101)
        Me.FrmDatos.TabIndex = 2
        Me.FrmDatos.TabStop = False
        Me.FrmDatos.Text = "Contador Facturas"
        '
        'bCancelar
        '
        Me.bCancelar.Location = New System.Drawing.Point(17, 68)
        Me.bCancelar.Name = "bCancelar"
        Me.bCancelar.Size = New System.Drawing.Size(87, 23)
        Me.bCancelar.TabIndex = 3
        Me.bCancelar.Text = "Cancelar"
        '
        'bAceptar
        '
        Me.bAceptar.Location = New System.Drawing.Point(187, 68)
        Me.bAceptar.Name = "bAceptar"
        Me.bAceptar.Size = New System.Drawing.Size(87, 23)
        Me.bAceptar.TabIndex = 2
        Me.bAceptar.Text = "Aceptar"
        '
        'AdvContador
        '
        Me.AdvContador.DisabledBackColor = System.Drawing.Color.White
        Me.AdvContador.EntityName = "EntidadContador"
        Me.AdvContador.Location = New System.Drawing.Point(127, 30)
        Me.AdvContador.Name = "AdvContador"
        Me.AdvContador.SecondaryDataFields = "IDContador"
        Me.AdvContador.Size = New System.Drawing.Size(147, 23)
        Me.AdvContador.TabIndex = 1
        '
        'LblContador
        '
        Me.LblContador.Location = New System.Drawing.Point(14, 35)
        Me.LblContador.Name = "LblContador"
        Me.LblContador.Size = New System.Drawing.Size(60, 13)
        Me.LblContador.TabIndex = 0
        Me.LblContador.Text = "Contador"
        '
        'frmContadorFacturasDocuware
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(302, 101)
        Me.Controls.Add(Me.FrmDatos)
        Me.Name = "frmContadorFacturasDocuware"
        Me.Text = "Introduzca el contador"
        Me.FrmDatos.ResumeLayout(False)
        Me.FrmDatos.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Public WithEvents FrmDatos As Solmicro.Expertis.Engine.UI.Frame
    Friend WithEvents bCancelar As Solmicro.Expertis.Engine.UI.Button
    Friend WithEvents bAceptar As Solmicro.Expertis.Engine.UI.Button
    Public WithEvents AdvContador As Solmicro.Expertis.Engine.UI.AdvSearch
    Public WithEvents LblContador As Solmicro.Expertis.Engine.UI.Label
End Class
