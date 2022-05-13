Public Class CIPagoLiquidaciones

    Private dblTotalMarcado As Double

    Private Sub CIPagoLiquidaciones_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        CmbAño.Value = Now.Year
        RellenarComboAños(CmbAño)
        CmbMes.DataSource = EnumData.EnumView("enumcaMesAño")
    End Sub

    Private Sub CIPagoLiquidaciones_QueryExecuted(ByVal sender As Object, ByRef e As Solmicro.Expertis.Engine.UI.QueryExecutedEventArgs) Handles Me.QueryExecuted
        NtbTotal.Value = Grid.GetTotal(Grid.Columns("Pagare"), AggregateFunction.Sum)
    End Sub

    Private Sub CIPagoLiquidaciones_QueryExecuting(ByVal sender As Object, ByRef e As Solmicro.Expertis.Engine.UI.QueryExecutingEventArgs) Handles Me.QueryExecuting
        With e.Filter
            If AdvOperario.Text <> "" Then .Add("IdOperario2", FilterOperator.Equal, AdvOperario.Text, FilterType.String)
            If CmbMes.Text <> "" Then .Add("Mes", FilterOperator.Equal, CmbMes.Text, FilterType.String)
            If CmbAño.Text <> "" Then .Add("Anyo", FilterOperator.Equal, CmbAño.Text, FilterType.String)
        End With
    End Sub

    Private Sub Grid_RecordChecked(ByVal sender As Object, ByVal e As Solmicro.Expertis.Engine.UI.CheckedEventArgs) Handles MyBase.RecordChecked
        If e.CheckState = CheckStates.Checked Then
            dblTotalMarcado = dblTotalMarcado + e.Row.Cells("Pagare").Value()
        Else
            dblTotalMarcado = dblTotalMarcado - e.Row.Cells("Pagare").Value()
        End If
        NtbTotalMarcado.Value = dblTotalMarcado
    End Sub

    Private Sub CIPagoLiquidaciones_SetReportDataSource(ByVal sender As Object, ByVal e As Solmicro.Expertis.Engine.UI.ReportDataSourceEventArgs) Handles Me.SetReportDataSource
        Select Case e.Alias
            Case "INFPagoLiquidacionPastor"
                e.DataSource = Grid.CheckedRecords()
            Case "INFPagoLiquidacionPopular"
                e.DataSource = Grid.CheckedRecords()
        End Select
    End Sub

    Private Sub CIPagoLiquidaciones_SetReportDesignObjects(ByVal sender As Object, ByVal e As Solmicro.Expertis.Engine.UI.ReportDesignObjectsEventArgs) Handles Me.SetReportDesignObjects
        If e.Alias = "INFPagoLiquidacionPastor" Then
            Imprimir("LiquidacionePastorA4.rpt", e)
        ElseIf (e.Alias = "INFPagoLiquidacionPopular") Then
            Imprimir("LiquidacionePopularA4.rpt", e)
        End If
    End Sub

    Private Sub Imprimir(ByVal strInforme As String, ByVal e As Solmicro.Expertis.Engine.UI.ReportDesignObjectsEventArgs)
        e.Formulas("fechavencimiento").Text = ClbFechaVto.Text
    End Sub
End Class