Public Class frmContadorFacturasDocuware

    Public contValue As String

    Private Sub bCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bCancelar.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Private Sub AdvContador_SetPredefinedFilter(ByVal sender As System.Object, ByVal e As Solmicro.Expertis.Engine.UI.AdvSearchFilterEventArgs) Handles AdvContador.SetPredefinedFilter
        e.Filter.Add("Entidad", FilterOperator.Equal, "FacturaCompraCabecera")
    End Sub

    Private Sub bAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bAceptar.Click
        contValue = AdvContador.Value
        Me.Close()
    End Sub
End Class