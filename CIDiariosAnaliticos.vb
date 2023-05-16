Public Class CIDiariosAnaliticos

    Private Sub CIDiariosAnaliticos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargaEmpresas()
    End Sub

    Public Sub cargaEmpresas()
        Dim dtEmpresas As New DataTable
        dtEmpresas.Columns.Add("Empresa")

        Dim dr As DataRow
        dr = dtEmpresas.NewRow()
        dr("Empresa") = "T. ES."
        dtEmpresas.Rows.Add(dr)

        dr = dtEmpresas.NewRow()
        dr("Empresa") = "FERR."
        dtEmpresas.Rows.Add(dr)

        dr = dtEmpresas.NewRow()
        dr("Empresa") = "SEC."
        dtEmpresas.Rows.Add(dr)

        dr = dtEmpresas.NewRow()
        dr("Empresa") = "D.P. "
        dtEmpresas.Rows.Add(dr)

        dr = dtEmpresas.NewRow()
        dr("Empresa") = "T.UK"
        dtEmpresas.Rows.Add(dr)

        dr = dtEmpresas.NewRow()
        dr("Empresa") = "T.SU"
        dtEmpresas.Rows.Add(dr)

        dr = dtEmpresas.NewRow()
        dr("Empresa") = "T.SL"
        dtEmpresas.Rows.Add(dr)

        dr = dtEmpresas.NewRow()
        dr("Empresa") = "T.SB"
        dtEmpresas.Rows.Add(dr)

        dr = dtEmpresas.NewRow()
        dr("Empresa") = "T.NO"
        dtEmpresas.Rows.Add(dr)

        dr = dtEmpresas.NewRow()
        dr("Empresa") = "T.BANACHE"
        dtEmpresas.Rows.Add(dr)

        cmbEmpresa.DataSource = dtEmpresas
    End Sub

    Private Sub CIDiariosAnaliticos_QueryExecuting(ByVal sender As System.Object, ByRef e As Solmicro.Expertis.Engine.UI.QueryExecutingEventArgs) Handles MyBase.QueryExecuting
        e.Filter.Add("Empresa", FilterOperator.Equal, cmbEmpresa.Value)
        e.Filter.Add("FechaApunte", FilterOperator.GreaterThanOrEqual, cbFecha1.Value)
        e.Filter.Add("FechaApunte", FilterOperator.LessThanOrEqual, cbFecha2.Value)
    End Sub
End Class