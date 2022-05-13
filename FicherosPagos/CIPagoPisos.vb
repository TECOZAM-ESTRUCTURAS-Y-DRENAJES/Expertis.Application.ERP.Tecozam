﻿Imports Solmicro.Expertis.Business.Negocio

Public Class CIPagoPisos

    Private Const CDLGFilterList As String = "Norma 34(*.XML)|*.XML|#" & _
                                 "Todos los archivos (*.*)|*.*"

    Private dblTotalMarcado As Double

    Private Sub CIPagoPisos_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        loadToolbarActions()
    End Sub

    Private Sub CIPagoPisos_QueryExecuting(ByVal sender As Object, ByRef e As Solmicro.Expertis.Engine.UI.QueryExecutingEventArgs) Handles Me.QueryExecuting
        With e.Filter
            If AdvProveedor.Text <> "" Then .Add("Idproveedor", FilterOperator.Equal, AdvProveedor.Text, FilterType.String)
            If AdvBancoTransf.Text <> "" Then .Add("IDBancoPropio", FilterOperator.Equal, AdvBancoTransf.Text, FilterType.String)
        End With
    End Sub

    Private Sub CIPagoLiquidaciones_QueryExecuted(ByVal sender As Object, ByRef e As Solmicro.Expertis.Engine.UI.QueryExecutedEventArgs) Handles Me.QueryExecuted
        NtbTotal.Value = Grid.GetTotal(Grid.Columns("TotalPagar"), AggregateFunction.Sum)
    End Sub

    Private Sub Grid_RecordChecked(ByVal sender As Object, ByVal e As Solmicro.Expertis.Engine.UI.CheckedEventArgs) Handles MyBase.RecordChecked
        If e.CheckState = CheckStates.Checked Then
            dblTotalMarcado = dblTotalMarcado + Nz(e.Row.Cells("TotalPagar").Value, 0)
        Else
            dblTotalMarcado = dblTotalMarcado - Nz(e.Row.Cells("TotalPagar").Value, 0)
        End If
        NtbTotalMarcado.Value = dblTotalMarcado
    End Sub

    Private Sub CIPagoPisos_SetReportDataSource(ByVal sender As Object, ByVal e As Solmicro.Expertis.Engine.UI.ReportDataSourceEventArgs) Handles Me.SetReportDataSource
        Select Case e.Alias
            Case "PAGOPISOS"
                e.DataSource = Grid.CheckedRecords()
        End Select
    End Sub

    Private Sub loadToolbarActions()
        Me.FormActions.Add("Asignar Banco", AddressOf AccionAsignarBanco)
        Me.FormActions.Add("Generar Fichero Formato A3", AddressOf generarA3)
    End Sub

    Private Sub AccionAsignarBanco()
        Dim dtRegistrosMarcados As DataTable = Grid.CheckedRecords
        Dim dtProo As DataTable
        Dim oPro As New Proveedor
        Dim frmFormulario As New FrmSeleccionarBanco
        frmFormulario.ShowDialog()
        If frmFormulario.strIDBancoPropio <> "" Then
            If ExpertisApp.GenerateMessage("A los datos Marcados se van a asignar el Banco: " & frmFormulario.strIDBancoPropio & Chr(13) & Chr(10) & "Desesa Continuar?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) Then
                For Each fila As DataRow In dtRegistrosMarcados.Rows
                    dtProo = New Proveedor().SelOnPrimaryKey(fila("IDProveedor"))
                    dtProo.Rows(0)("IDBancoPropio") = frmFormulario.strIDBancoPropio
                    oPro.Update(dtProo)
                Next
            End If
        Else
            ExpertisApp.GenerateMessage("Proceso cancelado", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

    End Sub

    Private Sub generarA3()
        Dim intTipoFichero As Integer = 3

        If Len(AdvBancoTransf.Text) = 0 Then
            ExpertisApp.GenerateMessage("Debe indicar un banco de transferencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            AdvBancoTransf.Focus()
            Exit Sub
        End If

        If ExpertisApp.GenerateMessage("Se va generar el fichero C.S.B 34 de las líneas Marcadas" & _
         " y con banco de pago: " & AdvBancoTransf.Text & Chr(10) & Chr(13) & "¿Desea Continuar?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

            If Grid.RecordCount > 0 Then
                AccionFicheroTransferencia(AdvBancoTransf.Text)
            End If
        End If
    End Sub

    Function AccionFicheroTransferencia(ByVal strBanco As String)
        Dim strRuta As String

        Dim strMensajeGlobal As String = "Generado con exito el fichero de transferencias"
        If Len(strBanco) Then
            SaveFileDialog1.DefaultExt = ".XML"
            SaveFileDialog1.Filter = Replace(CDLGFilterList, "#", vbNullString, , , CompareMethod.Text)
            SaveFileDialog1.ShowDialog()
            strRuta = SaveFileDialog1.FileName
            If Len(strRuta & vbNullString) Then

                Dim dtFichero As New DataTable
                dtFichero.Columns.Add("Linea", GetType(String))

                Dim htPagos As New Hashtable
                htPagos.Clear()
                Dim i As Integer = 0
                For Each drRowMarcados As DataRow In Grid.CheckedRecords.Rows
                    htPagos("IDEnlace" & i) = drRowMarcados("IDProveedorBanco")
                    i = i + 1
                Next drRowMarcados
                Dim mIDProcess As Guid = MarcarRegistro(htPagos, FilterType.Numeric)
                Dim mblnDesmarcar As Boolean = True
                htPagos = Nothing

                Dim datFich As New DataGenerarFichero
                datFich.IDProcess = mIDProcess
                datFich.IDBancoPropio = strBanco
                datFich.FechaEmision = Today
                datFich.strTipoFichero = "Pisos"

                Dim lstRegsFich As Byte() = ExpertisApp.ExecuteTask(Of DataGenerarFichero, Byte())(AddressOf Fichero_PAIN_001_001_03.GenerarFichero, datFich)
                Grid.DeleteServerChecks()

                If Not lstRegsFich Is Nothing AndAlso lstRegsFich.Length > 0 AndAlso General.GuardarFicheroXML(lstRegsFich, strRuta, -1, datFich.FechaCargo, True) Then
                    ExpertisApp.GenerateMessage("Fichero generado.", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Information)
                    Dim informe As New Report("PagoPisos")
                    informe.DataSource = Grid.CheckedRecords
                    ExpertisApp.OpenReport(informe)
                End If

                Me.Cursor = Windows.Forms.Cursors.Default
            End If
        End If
    End Function
End Class