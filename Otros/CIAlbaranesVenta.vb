Public Class CIAlbaranesVenta

    Private Sub CIAlbaranesVenta_QueryExecuting(ByVal sender As System.Object, ByRef e As Solmicro.Expertis.Engine.UI.QueryExecutingEventArgs) Handles MyBase.QueryExecuting
        With e.Filter
            If txtAlbaran.Text <> "" Then .Add("NAlbaran", FilterOperator.Equal, txtAlbaran.Text, FilterType.String)
            If txtObra.Text <> "" Then .Add("IDAlmacenDeposito", FilterOperator.Equal, txtObra.Text, FilterType.String)
        End With
    End Sub
End Class