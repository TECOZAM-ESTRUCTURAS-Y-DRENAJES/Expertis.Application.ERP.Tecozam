Imports Solmicro.Expertis.Business.ClasesTecozam
Imports System.Math
Imports System.Text
Imports Solmicro.Expertis.Application.ERP.GlobalActions


Public Class frmFacturasDocuwareApp

    Public Sub New()
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        LoadToolBarActions()
    End Sub

    Private Sub LoadToolBarActions()
        Me.FormActions.Add("Insertar Facturas", AddressOf InsertarFacturas)
    End Sub

    Public Sub InsertarFacturas()
        Dim dtRegistros As New DataTable
        Dim filtroRegistros As New Filter(FilterUnionOperator.Or)
        filtroRegistros.Add("Insertado", FilterOperator.Equal, DBNull.Value)
        filtroRegistros.Add("Insertado", False)
        'Obtengo las lineas de factura para insertar
        dtRegistros = New BE.DataEngine().Filter("tbParteLineaFactura", filtroRegistros, , "SuFactura")
        'Si hay mas de una linea, empezamos el proyecto
        'Comprueba que la tabla tiene SuFactura
        For Each dr As DataRow In dtRegistros.Rows
            If dr("SuFactura").ToString.Length = 0 Or dr("FechaFactura").ToString.Length = 0 Then
                ExpertisApp.GenerateMessage("Existen facturas que no tienen SuFactura o Fecha de Factura. Reviselas.")
                Exit Sub
            End If
        Next

        If dtRegistros.Rows.Count > 0 Then
            If ExpertisApp.GenerateMessage("Se va a procedeer a crear las Facturas de Compra ¿Desea continuar?.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                Me.Cursor = Cursors.WaitCursor
                Dim ClsComunes As New ClsGenerarDocuwareFactCompra
                ClsComunes.GenerarFacturaCompra(dtRegistros)

                'Cierra la ventana
                Me.Cursor = Cursors.Arrow
                Me.Close()
            Else
                ExpertisApp.GenerateMessage("Proceso cancelado.", MessageBoxButtons.OK, MessageBoxIcon.Information)

            End If
        Else
            MsgBox("No hay facturas que insertar")
        End If
    End Sub
End Class
