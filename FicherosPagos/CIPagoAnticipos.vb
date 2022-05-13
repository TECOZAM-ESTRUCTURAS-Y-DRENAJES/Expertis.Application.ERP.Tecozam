Public Class CIPagoAnticipos

    Private dblTotalMarcado As Double

    Private Sub CIPagoAnticipos_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LoadEnums()
    End Sub

    Private Sub LoadEnums()
        CmbPolacos.DataSource = New EnumData("enumBoolean")
        CmbPolacos.Value = enumBoolean.Todos
    End Sub

    Private Sub CIPagoAnticipos_QueryExecuted(ByVal sender As Object, ByRef e As Solmicro.Expertis.Engine.UI.QueryExecutedEventArgs) Handles Me.QueryExecuted
        NtbTotal.Value = Grid.GetTotal(Grid.Columns("Anticipo Fijo"), AggregateFunction.Sum)
    End Sub

    Private Sub CIPagoAnticipos_QueryExecuting(ByVal sender As Object, ByRef e As Solmicro.Expertis.Engine.UI.QueryExecutingEventArgs) Handles Me.QueryExecuting
        With e.Filter

            If AdvOperario.Text <> "" Then .Add(New StringFilterItem("IDOperario", FilterOperator.Equal, AdvOperario.Text))
            If AdvBancoTransf.Text <> "" Then .Add(New StringFilterItem("IdBancoPropio", FilterOperator.Equal, AdvBancoTransf.Text))

            If CmbPolacos.Value = enumBoolean.Si Then
                .Add(New NumberFilterItem("IdPais", FilterOperator.NotEqual, "060"))
            ElseIf CmbPolacos.Value = enumBoolean.No Then
                .Add(New NumberFilterItem("IdPais", FilterOperator.Equal, "060"))
            End If

        End With
    End Sub

    Private Sub Grid_RecordChecked(ByVal sender As Object, ByVal e As Solmicro.Expertis.Engine.UI.CheckedEventArgs) Handles MyBase.RecordChecked
        If e.CheckState = CheckStates.Checked Then
            dblTotalMarcado = dblTotalMarcado + e.Row.Cells("Anticipo Fijo").Value()
        Else
            dblTotalMarcado = dblTotalMarcado - e.Row.Cells("Anticipo Fijo").Value()
        End If
        NtbTotalMarcado.Value = dblTotalMarcado

    End Sub

    Private Sub CIPagoAnticipos_SetReportDataSource(ByVal sender As Object, ByVal e As Solmicro.Expertis.Engine.UI.ReportDataSourceEventArgs) Handles Me.SetReportDataSource
        Select Case e.Alias
            Case "INFPAGOANTICIPO"
                e.DataSource = Grid.CheckedRecords()
        End Select
    End Sub
End Class