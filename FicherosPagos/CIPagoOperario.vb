Public Class CIPagoOperario

    Private Const CDLGFilterList As String = "Norma 34(*.XML)|*.XML|#" & _
                                  "Todos los archivos (*.*)|*.*"

    Private dblTotalMarcado As Double

    Private Sub CIPagoOperario_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        loadToolbarActions()
        CmbAño.Value = Now.Year
        RellenarComboAños(CmbAño)
        CmbMes.DataSource = EnumData.EnumView("enumcaMesAño")
    End Sub

    Private Sub CIPagoOperario_QueryExecuting(ByVal sender As Object, ByRef e As Solmicro.Expertis.Engine.UI.QueryExecutingEventArgs) Handles Me.QueryExecuting
        With e.Filter
            If AdvOperario.Text <> "" Then .Add("IdOperario2", FilterOperator.Equal, AdvOperario.Text, FilterType.String)
            If AdvBancoTransf.Text <> "" Then .Add("IdBancoPropio", FilterOperator.Equal, AdvBancoTransf.Text, FilterType.String)
            If CmbMes.Text <> "" Then .Add("Mes", FilterOperator.Equal, CmbMes.Value, FilterType.Numeric)
            If CmbAño.Text <> "" Then .Add("Anyo", FilterOperator.Equal, CmbAño.Text, FilterType.String)
            If AdvObra.Text <> "" Then .Add("IdObraPredet", FilterOperator.Equal, AdvObra.Value, FilterType.Numeric)
            If AdvPais.Text <> "" Then .Add("idpais", FilterOperator.Equal, AdvPais.Value, FilterType.String)
        End With
    End Sub

    Private Sub CIPagoLiquidaciones_QueryExecuted(ByVal sender As Object, ByRef e As Solmicro.Expertis.Engine.UI.QueryExecutedEventArgs) Handles Me.QueryExecuted
        NtbTotal.Value = Grid.GetTotal(Grid.Columns("Total"), AggregateFunction.Sum)
    End Sub

    Private Sub Grid_RecordChecked(ByVal sender As Object, ByVal e As Solmicro.Expertis.Engine.UI.CheckedEventArgs) Handles MyBase.RecordChecked
        If e.CheckState = CheckStates.Checked Then
            dblTotalMarcado = dblTotalMarcado + e.Row.Cells("Total").Value()
        Else
            dblTotalMarcado = dblTotalMarcado - e.Row.Cells("Total").Value()
        End If
        NtbTotalMarcado.Value = dblTotalMarcado
    End Sub

    Private Sub CIPagoOperario_SetReportDataSource(ByVal sender As Object, ByVal e As Solmicro.Expertis.Engine.UI.ReportDataSourceEventArgs) Handles Me.SetReportDataSource
        Select Case e.Alias
            Case "INFPAGOOPEARIO"
                e.DataSource = Grid.CheckedRecords()
        End Select
    End Sub

    Private Sub loadToolbarActions()
        Me.FormActions.Add("Asignar Banco", AddressOf AccionAsignarBanco)
        Me.FormActions.Add("Generar Fichero Formato A3", AddressOf generarA3)
        Me.FormActions.Add("Generar Fichero Formato UK", AddressOf ficheroCSVUK)
    End Sub

    Private Sub AccionAsignarBanco()
        Dim dtRegistrosMarcados As DataTable = Grid.CheckedRecords
        Dim dtOperario As DataTable
        Dim oOper As New Operario
        Dim frmFormulario As New FrmSeleccionarBanco
        frmFormulario.ShowDialog()
        If frmFormulario.strIDBancoPropio <> "" Then
            If ExpertisApp.GenerateMessage("A los datos Marcados se van a asignar el Banco: " & frmFormulario.strIDBancoPropio & Chr(13) & Chr(10) & "Desesa Continuar?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) Then
                For Each fila As DataRow In dtRegistrosMarcados.Rows
                    dtOperario = New Operario().SelOnPrimaryKey(fila("IDOperario2"))
                    dtOperario.Rows(0)("IDBancoPropio") = frmFormulario.strIDBancoPropio
                    oOper.Update(dtOperario)
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
                Dim i As Integer = 0
                For Each drRowMarcados As DataRow In Grid.CheckedRecords.Rows
                    htPagos("IDEnlace" & i) = drRowMarcados("IdOperario")
                    i = i + 1
                Next
                Dim mIDProcess As Guid = MarcarRegistro(htPagos, FilterType.Numeric)

                Dim datFich As New DataGenerarFichero
                datFich.IDProcess = mIDProcess
                datFich.IDBancoPropio = strBanco
                datFich.FechaEmision = Today
                datFich.strTipoFichero = "Operario"

                Dim lstRegsFich As Byte() = ExpertisApp.ExecuteTask(Of DataGenerarFichero, Byte())(AddressOf Fichero_PAIN_001_001_03.GenerarFichero, datFich)
                Grid.DeleteServerChecks()

                If Not lstRegsFich Is Nothing AndAlso lstRegsFich.Length > 0 AndAlso General.GuardarFicheroXML(lstRegsFich, strRuta, -1, datFich.FechaCargo, True) Then
                    ExpertisApp.GenerateMessage("Fichero generado.", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Information)
                    Dim informe As New Report("INFPAGOOPERARIO")
                    informe.DataSource = Grid.CheckedRecords
                    ExpertisApp.OpenReport(informe)
                End If

                Me.Cursor = Windows.Forms.Cursors.Default
            End If
        End If
    End Function

    Public Sub ficheroCSVUK()
        Dim H001 As String = ""
        Dim H002 As String = ""
        Dim H003 As String = ""
        Dim T001 As String = ""
        Dim T002 As String = ""
        Dim T003 As String = ""
        Dim T004 As String = ""
        Dim T005 As String = ""
        Dim T006 As String = ""
        Dim T007 As String = ""
        Dim T008 As String = ""
        Dim T009 As String = ""
        Dim T010 As String = ""
        Dim T011 As String = ""
        Dim T012 As String = ""
        Dim T013 As String = ""
        Dim T014 As String = ""
        Dim T015 As String = ""
        Dim T016 As String = ""
        Dim T017 As String = ""
        Dim T018 As String = ""
        Dim T019 As String = ""
        Dim T020 As String = ""
        Dim T021 As String = ""
        Dim T022 As String = ""
        Dim T023 As String = ""
        Dim T024 As String = ""
        Dim T025 As String = ""
        Dim T026 As String = ""
        Dim T027 As String = ""
        Dim T028 As String = ""
        Dim T029 As String = ""
        Dim T030 As String = ""
        Dim T031 As String = ""
        Dim T032 As String = ""
        Dim T033 As String = ""
        Dim T034 As String = ""
        Dim T035 As String = ""
        Dim T036 As String = ""
        Dim T037 As String = ""
        Dim T038 As String = ""
        Dim T039 As String = ""
        Dim T040 As String = ""
        Dim T041 As String = ""
        Dim T042 As String = ""
        Dim T043 As String = ""
        Dim T044 As String = ""
        Dim T045 As String = ""
        Dim T046 As String = ""
        Dim T047 As String = ""
        Dim T048 As String = ""
        Dim T049 As String = ""
        Dim T050 As String = ""
        Dim T051 As String = ""
        Dim T052 As String = ""
        Dim T053 As String = ""
        Dim T054 As String = ""
        Dim T055 As String = ""
        Dim T056 As String = ""
        Dim T057 As String = ""
        Dim T058 As String = ""
        Dim T059 As String = ""
        Dim T060 As String = ""
        Dim T061 As String = ""
        Dim T062 As String = ""
        Dim T063 As String = ""
        Dim T064 As String = ""
        Dim T065 As String = ""
        Dim T066 As String = ""
        Dim T067 As String = ""
        Dim T068 As String = ""
        Dim T069 As String = ""
        Dim T070 As String = ""
        Dim T071 As String = ""
        Dim T072 As String = ""
        Dim T073 As String = ""
        Dim T074 As String = ""
        Dim T075 As String = ""
        Dim T076 As String = ""
        Dim T077 As String = ""
        Dim T078 As String = ""
        Dim T079 As String = ""
        Dim T080 As String = ""
        Dim T081 As String = ""
        Dim T082 As String = ""

        Dim dtPagos As DataTable = Grid.CheckedRecords
        Dim dtFichero As New DataTable("fichero")
        Dim linea As New DataColumn("linea")
        dtFichero.Columns.Add(linea)
        Dim drFichero As DataRow = dtFichero.NewRow
        Dim registro As String = ""

        If Not dtPagos Is Nothing Then
            If dtPagos.Rows.Count = 0 Then
                MsgBox("No hay datos para generar el fichero")
                Exit Sub
            End If
        End If

        For Each drPagos As DataRow In dtPagos.Rows
            T001 = "07" 'identifica el codigo de la operacion
            T005 = drPagos("Id Operario")
            T013 = "GBP" 'moneda libras esterlinas
            T014 = drPagos("Total") ' valor en libras
            T022 = "" 'codigo del banco
            T028 = "" ' numero de cuenta del beneficiario
            T030 = drPagos("Nombre")
            T034 = "PAYROLL " & drPagos("Mes") & "-" & drPagos("Año")
            registro = H001 & "," & H002 & "," & H003 & "," & T001 & "," & T002 & "," & T003 & "," & T004 & "," & T005 & ","
            registro &= T006 & "," & T007 & "," & T008 & "," & T009 & "," & T010 & "," & T011 & "," & T012 & "," & T013 & ","
            registro &= T014 & "," & T015 & "," & T016 & "," & T017 & "," & T018 & "," & T019 & "," & T020 & "," & T021 & ","
            registro &= T022 & "," & T023 & "," & T024 & "," & T025 & "," & T026 & "," & T027 & "," & T028 & "," & T029 & ","
            registro &= T030 & "," & T031 & "," & T032 & "," & T033 & "," & T034 & "," & T035 & "," & T036 & "," & T037 & ","
            registro &= T038 & "," & T039 & "," & T040 & "," & T041 & "," & T042 & "," & T043 & "," & T044 & "," & T045 & ","
            registro &= T046 & "," & T047 & "," & T048 & "," & T049 & "," & T050 & "," & T051 & "," & T052 & "," & T053 & ","
            registro &= T054 & "," & T055 & "," & T056 & "," & T057 & "," & T058 & "," & T059 & "," & T060 & "," & T061 & ","
            registro &= T062 & "," & T063 & "," & T064 & "," & T065 & "," & T066 & "," & T067 & "," & T068 & "," & T069 & ","
            registro &= T071 & "," & T072 & "," & T073 & "," & T074 & "," & T075 & "," & T076 & "," & T077 & "," & T078 & ","
            registro &= T079 & "," & T080 & "," & T081 & "," & T082

            drFichero.Item("linea") = registro
            dtFichero.Rows.Add(drFichero)
            registro = ""

        Next
        generarCSV(dtFichero)

    End Sub

    Public Sub generarCSV(ByVal dtfichero As DataTable)
        SaveFileDialog2 = New SaveFileDialog
        SaveFileDialog2.Filter = "csv file|*.csv"
        SaveFileDialog2.Title = "Guardar Archivo como"
        SaveFileDialog2.ShowDialog()
        Dim path As String = IO.Path.GetDirectoryName(SaveFileDialog2.FileName)
        Dim csvSW As New IO.StreamWriter(path, False, System.Text.Encoding.UTF8)
        For Each dr As Data.DataRow In dtfichero.Rows
            csvSW.WriteLine(dr.Item("linea"))
        Next
        csvSW.Close()
        ExpertisApp.GenerateMessage("Se ha guardado el archivo en la siguiente ruta " & path, MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub AdvOperario_SelectionChanged(ByVal sender As Object, ByVal e As Solmicro.Expertis.Engine.UI.AdvSearchSelectionChangedEventArgs) Handles AdvOperario.SelectionChanged
        'UlbDescPais = e.Selected.Rows(0)("DescPais")
    End Sub
End Class