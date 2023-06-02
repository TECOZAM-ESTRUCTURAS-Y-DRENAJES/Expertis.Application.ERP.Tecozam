Public Class CIDiariosAnaliticos

    Private Sub CIDiariosAnaliticos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargaEmpresas()
        cargaCentrosCoste()
        cargaCContables()
    End Sub

    Public Sub cargaCentrosCoste()
        Dim dt As New DataTable
        Dim f As New Filter

        Dim dtCentrosCoste As New DataTable
        dtCentrosCoste.Columns.Add("IDCentroCoste")
        dtCentrosCoste.Columns.Add("Empresa")
        dt = New BE.DataEngine().Filter("vUnionCentrosCoste", f)
        Dim dr As DataRow

        For Each fila As DataRow In dt.Rows
            dr = dtCentrosCoste.NewRow()
            dr("IDCentroCoste") = fila("IDCentroCoste")
            dr("Empresa") = fila("Empresa")
            dtCentrosCoste.Rows.Add(dr)
        Next

        cbCentroCoste.DataSource = dtCentrosCoste
        cbCentroCoste2.DataSource = dtCentrosCoste
    End Sub
    Public Sub cargaCContables()
        Dim dt As New DataTable
        Dim f As New Filter

        Dim dtCContable As New DataTable
        dtCContable.Columns.Add("IDCContable")
        dt = New BE.DataEngine().Filter("vUnionCtlCIDCAnalitica", f, "Distinct(IDCContable)")
        Dim dr As DataRow

        For Each fila As DataRow In dt.Rows
            dr = dtCContable.NewRow()
            dr("IDCContable") = fila("IDCContable")
            dtCContable.Rows.Add(dr)
        Next
        cbCContable.DataSource = dtCContable
        cbCContable2.DataSource = dtCContable

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
        dr("Empresa") = "D. P."
        dtEmpresas.Rows.Add(dr)

        dr = dtEmpresas.NewRow()
        dr("Empresa") = "T. UK."
        dtEmpresas.Rows.Add(dr)

        dr = dtEmpresas.NewRow()
        dr("Empresa") = "T. SU."
        dtEmpresas.Rows.Add(dr)

        dr = dtEmpresas.NewRow()
        dr("Empresa") = "T. SL."
        dtEmpresas.Rows.Add(dr)

        dr = dtEmpresas.NewRow()
        dr("Empresa") = "T. SB."
        dtEmpresas.Rows.Add(dr)

        dr = dtEmpresas.NewRow()
        dr("Empresa") = "T. NO."
        dtEmpresas.Rows.Add(dr)

        dr = dtEmpresas.NewRow()
        dr("Empresa") = "T. G.E"
        dtEmpresas.Rows.Add(dr)

        cmbEmpresa.DataSource = dtEmpresas
    End Sub

    Private Sub CIDiariosAnaliticos_QueryExecuting(ByVal sender As System.Object, ByRef e As Solmicro.Expertis.Engine.UI.QueryExecutingEventArgs) Handles MyBase.QueryExecuting
        e.Filter.Add("Empresa", FilterOperator.Equal, cmbEmpresa.Value)
        e.Filter.Add("IDCentroCoste", FilterOperator.GreaterThanOrEqual, cbCentroCoste.Value)
        e.Filter.Add("IDCentroCoste", FilterOperator.LessThanOrEqual, cbCentroCoste2.Value)
        e.Filter.Add("IDCContable", FilterOperator.GreaterThanOrEqual, cbCContable.Value)
        e.Filter.Add("IDCContable", FilterOperator.LessThanOrEqual, cbCContable2.Value)
        e.Filter.Add("FechaApunte", FilterOperator.GreaterThanOrEqual, cbFecha1.Value)
        e.Filter.Add("FechaApunte", FilterOperator.LessThanOrEqual, cbFecha2.Value)
    End Sub
End Class