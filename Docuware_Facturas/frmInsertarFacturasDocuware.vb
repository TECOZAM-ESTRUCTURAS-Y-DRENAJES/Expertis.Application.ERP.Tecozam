Imports Solmicro.Expertis.Business.ClasesTecozam
Imports Solmicro.Expertis.Business.Negocio
Imports Solmicro.Expertis.Engine.DAL

Public Class frmInsertarFacturasDocuware

    'CONSTANTES referencias a la base de datos
    Const TECOZAM As String = "001"
    Const FERRALLAS As String = "002"
    Const SECOZAM As String = "003"
    Const TECODEMO As String = "004"

    Dim IDFactura As String
    Dim IDLineaFactura As String
    Dim IDcontFactDocu As String

    Dim dtResultados As New DataTable

    Dim aux As New Solmicro.Expertis.Business.ClasesTecozam.MetodosAuxiliares


    Private Sub frmInsertarFacturasDocuware_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadToolbarActions()

        dtResultados.Columns.Add("FechaFactura", GetType(String))
        dtResultados.Columns.Add("NFactura", GetType(String))
        dtResultados.Columns.Add("SuFactura", GetType(String))
    End Sub


#Region "ToolbarActions"
    Private Sub LoadToolbarActions()
        Dim db As String
        db = ExpertisApp.DataBaseName.ToString()

        'MsgBox(db)
        Select Case db
            Case "xTecozam50R2"
                Me.FormActions.Add("Insertar Facturas (TECOZAM)", AddressOf InsertFacturasTecozam)
            Case "xFerrallas50R2", "xFerrallas50R2_PRUEBA"
                Me.FormActions.Add("Traer Facturas", AddressOf TraerFacturasFerrallas)
                Me.AddSeparator()
                Me.FormActions.Add("Crear Facturas (FERRALLAS)", AddressOf InsertFacturasFerrallas)
            Case "xSecozam50R2", "xSecozam50R2Demo"
                Me.FormActions.Add("Traer Facturas ", AddressOf TraerFacturasSecozam)
                Me.AddSeparator()
                Me.FormActions.Add("Crear Facturas (SECOZAM)", AddressOf InsertFacturasSecozam)
            Case "xTecozam50R2Demo"
                Me.FormActions.Add("Traer Facturas", AddressOf TraerFacturasDemo)
                Me.AddSeparator()
                Me.FormActions.Add("Crear Facturas (TECOZAM DEMO)", AddressOf InsertFacturasTecozamDemo)
                'Me.FormActions.Add("Prueba Commit y Rollback", AddressOf PruebaCommitRollBack)
        End Select
    End Sub
#End Region

#Region "Insertar Facturas Tecozam50R2 Demo"

    Public Sub InsertFacturasTecozamDemo()

        Dim dt As New DataTable
        Dim f As New Filter
        f.Add("Insertada", FilterOperator.Equal, False)
        f.Add("BaseDeDatos", FilterOperator.Equal, TECODEMO)

        dt = New BE.DataEngine().Filter("tbFacturasDocuware", f, , "IDFacturaDocuware, IDTipoIva")
        'Compruebo que todos los articulos de la tabla existen en bbdd
        Dim factura As String
        factura = comprueboExistenciaArticulo(dt)
        If factura.Length = 0 Then
            'Llamo al método que va a realizar la inserción
            insertarFacturas(dt)
        Else
            MessageBox.Show("¡Advertencia! La factura " & factura & " tiene un articulo que no existe. Corrijalo para poder crear la factura.", "Artículo Incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        'insertarFacturas(dt)
    End Sub
    Public Function comprueboExistenciaArticulo(ByVal dt As DataTable) As String
        Dim dtArticulo As New DataTable
        Dim fArticulo As New Filter
        Dim IDArticulo As String

        For Each row As DataRow In dt.Rows
            IDArticulo = row("IDArticulo")

            fArticulo.Add("IDArticulo", FilterOperator.Equal, IDArticulo)
            dtArticulo = New BE.DataEngine().Filter("tbMaestroArticulo", fArticulo)
            'Esto significa que no existe el Articulo.
            'Avisa antes de crear nada
            If dtArticulo.Rows.Count = 0 Then
                Return row("SuFactura")
            End If
            fArticulo.Clear()
        Next
        Return ""
    End Function
    Public Sub PruebaCommitRollBack()

        Dim sql As String
        sql = "insert into xtecozam50r2demo..tbMaestroPisos(Codigo, Domicilio, Poblacion,Provincia, IDPiso, IDProveedor, Propietario, IVAs, Vencimiento, Activo, Bloqueado) values('TEC-PISO-1000','Calle Aire', 'Zamora','Zamora', 156156156, 4140090825, 'David Velasco',21,1,1,0)"
        aux.HazTodo(sql)
    End Sub

#End Region

#Region "Insertar Facturas Tecozam"

    Public Sub InsertFacturasTecozam()
        Dim dt As New DataTable
        Dim f As New Filter
        f.Add("Insertada", FilterOperator.Equal, False)
        f.Add("BaseDeDatos", FilterOperator.Equal, TECODEMO)

        dt = New BE.DataEngine().Filter("tbFacturasDocuware", f, , "IDFacturaDocuware, IDTipoIva")
        'Compruebo que todos los articulos de la tabla existen en bbdd
        Dim factura As String
        factura = comprueboExistenciaArticulo(dt)
        If factura.Length = 0 Then
            'Llamo al método que va a realizar la inserción
            insertarFacturas(dt)
        Else
            MessageBox.Show("¡Advertencia! La factura " & factura & " tiene un articulo que no existe. Corrijalo para poder crear la factura.", "Artículo Incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

#End Region

#Region "Insertar Facturas Ferrallas"

    Public Sub TraerFacturasFerrallas()
        Dim dt As New DataTable
        Dim f As New Filter
        f.Add("Transferida", FilterOperator.Equal, False)
        f.Add("BaseDeDatos", FilterOperator.Equal, FERRALLAS)

        dt = New BE.DataEngine().Filter("xTecozam50R2..tbFacturasDocuware", f, , "IDFacturaDocuware, IDTipoIva")

        If dt.Rows.Count > 0 Then
            For Each dr As DataRow In dt.Rows
                Try
                    'Recorre las filas de bbdd de teco y las mete en tbFacturasDocuware
                    InsertaLinea(dr)
                    'Actualiza el campo Transferida a true para saber que está cambiada.
                    ActualizaLineaEnTeco(dr)
                Catch ex As Exception
                    MsgBox(ex)
                    Exit Sub
                End Try
            Next

            ExpertisApp.GenerateMessage("Facturas traidas correctamente.", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            ExpertisApp.GenerateMessage("Proceso cancelado. No hay facturas que traer.", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

        Me.UpdateData()
    End Sub

    Public Sub ActualizaLineaEnTeco(ByVal dr As DataRow)
        Dim StrSql As String
        StrSql = "UPDATE xTecozam50R2..tbFacturasDocuware "
        StrSql &= " SET Transferida = 1 WHERE IDFacturaDocuware= " & dr("IDFacturaDocuware") & " and IDLineaFactura = " & dr("IDLineaFactura") & ""
        aux.EjecutarSql(StrSql)
    End Sub

    Public Sub InsertaLinea(ByVal dr As DataRow)
        Dim sql As String

        If dr("NObra").ToString.Length = 0 Then
            Dim CentroCoste As String
            CentroCoste = GetCentroCoste(dr("IDArticulo"))

            If CentroCoste.ToString.Length = 0 Then
                sql = "INSERT INTO tbFacturasDocuware (IDFacturaDocuware, IDLineaFactura,IDProveedor,IDArticulo,"
                sql &= "IDTipoIva,BaseDeDatos, Insertada, Precio, Retencion, SuFactura, SuFechaFactura, FechaInserccionFactura, URL, Transferida)"
                sql &= "values (" & dr("IDFacturaDocuware") & "," & dr("IDLineaFactura") & "," & dr("IDProveedor") & ",'" & dr("IDArticulo") & "',"
                sql &= "'" & dr("IDTipoIva") & "','" & dr("BaseDeDatos") & "', 0 , " & dr("Precio").ToString.Replace(",", ".") & ", '" & dr("Retencion") & "', '" & dr("SuFactura") & "', '" & dr("SuFechaFactura") & "', '" & dr("FechaInserccionFactura") & "', '" & dr("URL") & "', 1)"

            Else
                sql = "INSERT INTO tbFacturasDocuware (IDFacturaDocuware, IDLineaFactura,IDProveedor,IDArticulo,"
                sql &= "IDTipoIva,BaseDeDatos, Insertada, NObra, Precio, Retencion, SuFactura, SuFechaFactura, FechaInserccionFactura, URL, Transferida)"
                sql &= "values (" & dr("IDFacturaDocuware") & "," & dr("IDLineaFactura") & "," & dr("IDProveedor") & ",'" & dr("IDArticulo") & "',"
                sql &= "'" & dr("IDTipoIva") & "','" & dr("BaseDeDatos") & "', 0 , '" & CentroCoste & "', " & dr("Precio").ToString.Replace(",", ".") & ", '" & dr("Retencion") & "', '" & dr("SuFactura") & "', '" & dr("SuFechaFactura") & "', '" & dr("FechaInserccionFactura") & "', '" & dr("URL") & "', 1)"

            End If
        Else
            sql = "INSERT INTO tbFacturasDocuware (IDFacturaDocuware, IDLineaFactura,IDProveedor,IDArticulo,"
            sql &= "IDTipoIva,BaseDeDatos, Insertada, NObra, Precio, Retencion, SuFactura, SuFechaFactura, FechaInserccionFactura, URL, Transferida)"
            sql &= "values (" & dr("IDFacturaDocuware") & "," & dr("IDLineaFactura") & "," & dr("IDProveedor") & ",'" & dr("IDArticulo") & "',"
            sql &= "'" & dr("IDTipoIva") & "','" & dr("BaseDeDatos") & "', 0 , '" & dr("NObra") & "', " & dr("Precio").ToString.Replace(",", ".") & ", '" & dr("Retencion") & "', '" & dr("SuFactura") & "', '" & dr("SuFechaFactura") & "', '" & dr("FechaInserccionFactura") & "', '" & dr("URL") & "', 1)"

        End If

        aux.EjecutarSql(sql)
    End Sub

    Public Function GetCentroCoste(ByVal IDArticulo As String) As String
        Dim dtArt As New DataTable
        Dim fArt As New Filter
        Try
            fArt.Add("IDArticulo", FilterOperator.Equal, IDArticulo)
            dtArt = New BE.DataEngine().Filter("tbMaestroArticulo", fArt)

            Dim dtFam As New DataTable
            Dim fFam As New Filter
            fFam.Add("IDFamilia", FilterOperator.Equal, dtArt.Rows(0)("IDFamilia"))
            dtFam = New BE.DataEngine().Filter("tbMaestroFamilia", fFam)

            Dim dtPlanCont As New DataTable
            Dim fPlanCont As New Filter
            fPlanCont.Add("IDCContable", FilterOperator.Equal, dtFam.Rows(0)("CCCompra"))
            fPlanCont.Add("IDEjercicio", FilterOperator.Equal, Year(Today))

            dtPlanCont = New BE.DataEngine().Filter("vfrmMntoPlanContableAnalitica", fPlanCont)

            If dtPlanCont.Rows.Count > 0 Then
                Return dtPlanCont.Rows(0)("IdCentroCoste")
            Else
                Return ""
            End If
        Catch ex As Exception
            Return ""
        End Try
        
    End Function

    Public Sub InsertFacturasFerrallas()
        Dim dt As New DataTable
        Dim f As New Filter
        f.Add("Insertada", FilterOperator.Equal, False)
        f.Add("BaseDeDatos", FilterOperator.Equal, TECODEMO)

        dt = New BE.DataEngine().Filter("tbFacturasDocuware", f, , "IDFacturaDocuware, IDTipoIva")
        'Compruebo que todos los articulos de la tabla existen en bbdd
        Dim factura As String
        factura = comprueboExistenciaArticulo(dt)
        If factura.Length = 0 Then
            'Llamo al método que va a realizar la inserción
            insertarFacturas(dt)
        Else
            MessageBox.Show("¡Advertencia! La factura " & factura & " tiene un articulo que no existe. Corrijalo para poder crear la factura.", "Artículo Incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

#End Region

#Region "Insertar Facturas Secozam"

    Public Sub TraerFacturasDemo()
        Dim dt As New DataTable
        Dim f As New Filter
        f.Add("Transferida", FilterOperator.Equal, False)
        f.Add("BaseDeDatos", FilterOperator.Equal, TECODEMO)

        dt = New BE.DataEngine().Filter("xTecozam50R2..tbFacturasDocuware", f, , "IDFacturaDocuware, IDTipoIva")

        If dt.Rows.Count > 0 Then
            For Each dr As DataRow In dt.Rows
                Try
                    'Recorre las filas de bbdd de teco y las mete en tbFacturasDocuware
                    InsertaLinea(dr)
                    'Actualiza el campo Transferida a true para saber que está cambiada.
                    ActualizaLineaEnTeco(dr)
                Catch ex As Exception
                    MsgBox(ex)
                    Exit Sub
                End Try
            Next

            ExpertisApp.GenerateMessage("Facturas traidas correctamente.", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            ExpertisApp.GenerateMessage("Proceso cancelado. No hay facturas que traer.", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

        Me.UpdateData()
    End Sub

    Public Sub TraerFacturasSecozam()
        Dim dt As New DataTable
        Dim f As New Filter
        f.Add("Transferida", FilterOperator.Equal, False)
        f.Add("BaseDeDatos", FilterOperator.Equal, SECOZAM)

        dt = New BE.DataEngine().Filter("xTecozam50R2..tbFacturasDocuware", f, , "IDFacturaDocuware, IDTipoIva")

        If dt.Rows.Count > 0 Then
            For Each dr As DataRow In dt.Rows
                Try
                    'Recorre las filas de bbdd de teco y las mete en tbFacturasDocuware
                    InsertaLinea(dr)
                    'Actualiza el campo Transferida a true para saber que está cambiada.
                    ActualizaLineaEnTeco(dr)
                Catch ex As Exception
                    MsgBox(ex)
                    Exit Sub
                End Try
            Next

            ExpertisApp.GenerateMessage("Facturas traidas correctamente.", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            ExpertisApp.GenerateMessage("Proceso cancelado. No hay facturas que traer.", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

        Me.UpdateData()
    End Sub


    Public Sub InsertFacturasSecozam()
        Dim dt As New DataTable
        Dim f As New Filter
        f.Add("Insertada", FilterOperator.Equal, False)
        f.Add("BaseDeDatos", FilterOperator.Equal, TECODEMO)

        dt = New BE.DataEngine().Filter("tbFacturasDocuware", f, , "IDFacturaDocuware, IDTipoIva")
        'Compruebo que todos los articulos de la tabla existen en bbdd
        Dim factura As String
        factura = comprueboExistenciaArticulo(dt)
        If factura.Length = 0 Then
            'Llamo al método que va a realizar la inserción
            insertarFacturas(dt)
        Else
            MessageBox.Show("¡Advertencia! La factura " & factura & " tiene un articulo que no existe. Corrijalo para poder crear la factura.", "Artículo Incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

#End Region

    Public Sub insertarFacturas(ByVal dt As DataTable)
        Dim dtLineas As New DataTable
        dtLineas = dt

        Dim Propuesta As New ResultFacturacion

        If dt.Rows.Count > 0 Then
            If ExpertisApp.GenerateMessage("Se va a procedeer a crear las Facturas de Compra ¿Desea continuar?.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                Me.Cursor = Cursors.WaitCursor

                Dim frm As New DetalleFacturaDocuware
                'Dim dtResultados As New DataTable
                'frm.mData2 = dtResultados
                'frm.ShowDialog()
                dtResultados.Clear()

                Dim cont As Integer = 0
                'Selecciona el contador que va a tene
                eligeContador()
                Dim cabeceraBandera As Boolean = True
                'Dim numFilas As Integer = dt.Rows.Count

                For Each dr As DataRow In dt.Rows
                    Try
                        If dt.Rows(cont)("IDFacturaDocuware") = dt.Rows(cont + 1)("IDFacturaDocuware") Then
                            cabeceraBandera = CreaLineaFSinActualizar(cabeceraBandera, dr)
                            cont += 1
                        Else
                            cabeceraBandera = CreaLineaFActualizando(cabeceraBandera, dr)
                            cont += 1
                        End If
                    Catch ex As Exception
                        CreaLineaFFinalActualizando(cabeceraBandera, dr)
                    End Try
                Next

                Me.Cursor = Cursors.Arrow
                frm.mData2 = dtResultados
                frm.ShowDialog()
                Me.UpdateData()
            Else
                ExpertisApp.GenerateMessage("Proceso cancelado.", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Else
            ExpertisApp.GenerateMessage("No hay ninguna línea para insertar.")
        End If

    End Sub
    Public Function CreaLineaFSinActualizar(ByVal cabeceraBandera As Boolean, ByVal dr As DataRow)
        'Crea Cabecera de factura
        If cabeceraBandera = True Then
            setFraComCabecera(dr)
            cabeceraBandera = False
        End If
        'Crea Linea de factura
        setFraComLinea(dr)
        'Actualizar Linea de Factura como creada: Insertada=True where IDFactura e IDLineaFactura 
        ActualizaLineaCreada(dr("IDFacturaDocuware"), dr("IDLineaFactura"))
        Return False
    End Function
    Public Function CreaLineaFActualizando(ByVal cabeceraBandera As Boolean, ByVal dr As DataRow)
        If cabeceraBandera = True Then
            setFraComCabecera(dr)
        End If
        'Crea Linea de factura
        setFraComLinea(dr)
        'Crea Linea de Vencimiento
        setFraVencimiento(dr)
        'Actualizo los datos de la Cabecera
        actualizaCabecera()
        'cabeceraBandera = True
        ActualizaLineaCreada(dr("IDFacturaDocuware"), dr("IDLineaFactura"))
        Return True
    End Function
    Public Sub CreaLineaFFinalActualizando(ByVal cabeceraBandera As Boolean, ByVal dr As DataRow)
        If cabeceraBandera = True Then
            setFraComCabecera(dr)
        End If
        'Crea Linea de factura
        setFraComLinea(dr)
        'Crea Linea de Vencimiento
        setFraVencimiento(dr)
        'Actualizo los datos de la Cabecera
        actualizaCabecera()
        ActualizaLineaCreada(dr("IDFacturaDocuware"), dr("IDLineaFactura"))
    End Sub
#Region "Acciones Contador"

    Public Function getNFactura() As String

        'Saca Contadores solo de Facturas Compra Cabecera
        'eligeContador()

        Dim dt As New DataTable
        Dim f As New Filter
        f.Add("IDContador", FilterOperator.Equal, IDcontFactDocu)
        dt = New BE.DataEngine().Filter("tbMaestroContador", f)

        Dim texto As String
        texto = dt.Rows(0)("Texto")
        Dim valorFinal As String
        Dim contador As String
        contador = dt.Rows(0)("Contador").ToString.Length

        If contador = 1 Then
            valorFinal = texto & "0000" & dt.Rows(0)("Contador").ToString
        ElseIf contador = 2 Then
            valorFinal = texto & "000" & dt.Rows(0)("Contador").ToString
        ElseIf contador = 3 Then
            valorFinal = texto & "00" & dt.Rows(0)("Contador").ToString
        ElseIf contador = 4 Then
            valorFinal = texto & "0" & dt.Rows(0)("Contador").ToString
        Else
            valorFinal = texto & "" & dt.Rows(0)("Contador").ToString
        End If

        'Actualiza Contador 
        'actualizaContador(dt.Rows(0)("Contador"))

        Return valorFinal
    End Function

    Public Sub eligeContador()
        Dim frm As New frmContadorFacturasDocuware
        frm.ShowDialog()
        IDcontFactDocu = frm.contValue
    End Sub

    Public Sub actualizaContador(ByVal contador As String)
        Dim sql As String
        sql = "UPDATE tbMaestroContador set Contador=" & (CDbl(contador) + 1) & " where IDContador='" & IDcontFactDocu & "'"
        aux.EjecutarSql(sql)
    End Sub

#End Region

#Region "FacturaCompraCabecera"

    Public Sub setFraComCabecera(ByVal dr As DataRow)
        Dim frComCabecera As New FacturaCompraCabecera
        Dim dtCabecera As DataTable = frComCabecera.AddNewForm
        Dim Proveedor As New ProveedorDocu(dr("IDProveedor"))

        IDFactura = aux.devuelveAutonumeri
        dtCabecera.Rows(0)("IDFactura") = IDFactura
        dtCabecera.Rows(0)("FechaFactura") = dr("SuFechaFactura")
        dtCabecera.Rows(0)("IDProveedor") = Proveedor.IDProveedor
        dtCabecera.Rows(0)("IDContador") = IDcontFactDocu
        dtCabecera.Rows(0)("IDCentroGestion") = Proveedor.IDCentroGestion
        dtCabecera.Rows(0)("SuFactura") = dr("SuFactura")
        dtCabecera.Rows(0)("SuFechaFactura") = dr("SuFechaFactura")
        dtCabecera.Rows(0)("CifProveedor") = Proveedor.CifProveedor
        dtCabecera.Rows(0)("RazonSocial") = Proveedor.RazonSocial
        dtCabecera.Rows(0)("IDFormaPago") = Proveedor.IDFormaPago
        dtCabecera.Rows(0)("IDCondicionPago") = Proveedor.IDCondicionPago
        dtCabecera.Rows(0)("IDDiaPago") = Proveedor.IDDiaPago
        Try
            dtCabecera.Rows(0)("IDProveedorBanco") = Proveedor.IDProveedorBanco
        Catch ex As Exception
        End Try
        dtCabecera.Rows(0)("IDBancoPropio") = Proveedor.IDBancoPropio
        dtCabecera.Rows(0)("IDMoneda") = Proveedor.IDMoneda
        dtCabecera.Rows(0)("CambioA") = 0
        dtCabecera.Rows(0)("CambioB") = 0
        dtCabecera.Rows(0)("Estado") = 0
        dtCabecera.Rows(0)("ImpLineas") = 0
        dtCabecera.Rows(0)("ImpLineasA") = 0
        dtCabecera.Rows(0)("ImpLineasB") = 0
        dtCabecera.Rows(0)("DtoFactura") = 0
        dtCabecera.Rows(0)("ImpDtoFactura") = 0
        dtCabecera.Rows(0)("ImpDtoFacturaA") = 0
        dtCabecera.Rows(0)("ImpDtoFacturaB") = 0
        dtCabecera.Rows(0)("DtoProntoPago") = 0
        dtCabecera.Rows(0)("ImpDpp") = 0
        dtCabecera.Rows(0)("ImpDppA") = 0
        dtCabecera.Rows(0)("ImpDppB") = 0
        dtCabecera.Rows(0)("RecFinan") = 0
        dtCabecera.Rows(0)("ImpRecFinan") = 0
        dtCabecera.Rows(0)("ImpRecFinanA") = 0
        dtCabecera.Rows(0)("ImpRecFinanB") = 0
        dtCabecera.Rows(0)("ImpRE") = 0
        dtCabecera.Rows(0)("ImpREA") = 0
        dtCabecera.Rows(0)("ImpREB") = 0
        dtCabecera.Rows(0)("BaseImponible") = 0
        dtCabecera.Rows(0)("BaseImponibleA") = 0
        dtCabecera.Rows(0)("BaseImponibleB") = 0
        dtCabecera.Rows(0)("ImpIva") = 0
        dtCabecera.Rows(0)("ImpIvaA") = 0
        dtCabecera.Rows(0)("ImpIvaB") = 0
        dtCabecera.Rows(0)("ImpIntrastat") = 0
        dtCabecera.Rows(0)("ImpIntrastatA") = 0
        dtCabecera.Rows(0)("ImpIntrastatB") = 0
        dtCabecera.Rows(0)("RetencionIRPF") = dr("Retencion")
        dtCabecera.Rows(0)("ImpRetencion") = 0
        dtCabecera.Rows(0)("ImpRetencionA") = 0
        dtCabecera.Rows(0)("ImpRetencionB") = 0
        dtCabecera.Rows(0)("ImpGastos") = 0
        dtCabecera.Rows(0)("ImpGastosA") = 0
        dtCabecera.Rows(0)("ImpGastosB") = 0
        dtCabecera.Rows(0)("ImpTotal") = 0
        dtCabecera.Rows(0)("ImpTotalA") = 0
        dtCabecera.Rows(0)("ImpTotalB") = 0
        dtCabecera.Rows(0)("IVAManual") = 0
        dtCabecera.Rows(0)("VencimientosManuales") = 0
        dtCabecera.Rows(0)("IntrastatProcesado") = 0
        dtCabecera.Rows(0)("IDTipoAsiento") = 0
        dtCabecera.Rows(0)("BaseRetencion") = 0
        dtCabecera.Rows(0)("BaseRetencionA") = 0
        dtCabecera.Rows(0)("BaseRetencionB") = 0
        dtCabecera.Rows(0)("RetencionManual") = 0
        dtCabecera.Rows(0)("RegimenEspecial") = 0
        dtCabecera.Rows(0)("Direccion") = Proveedor.Direccion
        dtCabecera.Rows(0)("CodPostal") = Proveedor.CodPostal
        dtCabecera.Rows(0)("Poblacion") = Proveedor.Poblacion
        dtCabecera.Rows(0)("Provincia") = Proveedor.Provincia
        dtCabecera.Rows(0)("IDPais") = Proveedor.IDPais
        dtCabecera.Rows(0)("ImpSinRepercutir") = 0
        dtCabecera.Rows(0)("ImpSinRepercutirA") = 0
        dtCabecera.Rows(0)("ImpSinRepercutirB") = 0
        dtCabecera.Rows(0)("FacturaPagoPeriodicoSN") = 0
        dtCabecera.Rows(0)("NoDescontabilizar") = 0
        'dtCabecera.Rows(0)("FechaParaDeclaracion") = 0
        dtCabecera.Rows(0)("FechaDeclaracionManual") = 0
        dtCabecera.Rows(0)("Exportado") = 0
        dtCabecera.Rows(0)("Exportar") = 1
        dtCabecera.Rows(0)("Enviar347") = 1
        'dtCabecera.Rows(0)("IDObra") = 0
        dtCabecera.Rows(0)("ImpRetencionGar") = 0
        dtCabecera.Rows(0)("ImpRetencionGarA") = 0
        dtCabecera.Rows(0)("ImpRetencionGarB") = 0
        dtCabecera.Rows(0)("Retencion") = 0
        'dtCabecera.Rows(0)("IDCentroCoste") = 0
        dtCabecera.Rows(0)("Enviar349") = 0
        dtCabecera.Rows(0)("Servicios349") = 0
        'dtCabecera.Rows(0)("TipoRetencionIRPF") = 0
        dtCabecera.Rows(0)("OpeTriangular") = 0
        dtCabecera.Rows(0)("Importacion") = 0
        dtCabecera.Rows(0)("ImpImpuestos") = 0
        dtCabecera.Rows(0)("ImpImpuestos") = 0
        dtCabecera.Rows(0)("ImpImpuestosA") = 0
        dtCabecera.Rows(0)("ImpImpuestosB") = 0
        dtCabecera.Rows(0)("CensadoAEAT") = 1
        dtCabecera.Rows(0)("EnviarSII") = 1
        dtCabecera.Rows(0)("FechaRegContable") = Today
        dtCabecera.Rows(0)("Sustitutiva") = 0
        dtCabecera.Rows(0)("NFactura") = getNFactura()
        dtCabecera.Rows(0)("IDFacturaDocuware") = dr("IDFacturaDocuware")
        dtCabecera.Rows(0)("URL") = dr("URL")
        Try
            frComCabecera.Update(dtCabecera)
            dtCabecera = Nothing
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

#End Region

#Region "FacturaCompraLinea"

    Public Sub setFraComLinea(ByVal dr As DataRow)
        Dim frComLinea As New FacturaCompraLinea
        Dim dtLinea As DataTable = frComLinea.AddNewForm
        Dim aux As New Solmicro.Expertis.Business.ClasesTecozam.MetodosAuxiliares
        Dim dtArticulo As New DataTable
        Dim filtro As New Filter
        filtro.Add("IDArticulo", FilterOperator.Equal, dr("IDArticulo"))
        dtArticulo = New BE.DataEngine().Filter("tbMaestroArticulo", filtro)


        IDLineaFactura = aux.devuelveAutonumeri
        dtLinea.Rows(0)("IDLineaFactura") = IDLineaFactura
        dtLinea.Rows(0)("IDFactura") = IDFactura
        dtLinea.Rows(0)("IDArticulo") = dr("IDArticulo")
        dtLinea.Rows(0)("DescArticulo") = dtArticulo.Rows(0)("DescArticulo").ToString
        dtLinea.Rows(0)("IDTipoIVA") = dr("IDTipoIva")

        dtLinea.Rows(0)("IDUdMedida") = dtArticulo.Rows(0)("IDUdInterna").ToString
        dtLinea.Rows(0)("Cantidad") = 1
        dtLinea.Rows(0)("Precio") = dr("Precio")
        dtLinea.Rows(0)("PrecioA") = dr("Precio")
        dtLinea.Rows(0)("PrecioB") = dr("Precio")
        dtLinea.Rows(0)("UdValoracion") = 1
        dtLinea.Rows(0)("Dto1") = 0
        dtLinea.Rows(0)("Dto2") = 0
        dtLinea.Rows(0)("Dto3") = 0
        dtLinea.Rows(0)("Importe") = dr("Precio")
        dtLinea.Rows(0)("ImporteA") = dr("Precio")
        dtLinea.Rows(0)("ImporteB") = dr("Precio")

        Dim dtFamilia As New DataTable
        Dim ffam As New Filter
        ffam.Add("IDFamilia", FilterOperator.Equal, dtArticulo.Rows(0)("IDFamilia"))
        dtFamilia = New BE.DataEngine().Filter("tbMaestroFamilia", ffam)

        Dim cccompraFam As String
        cccompraFam = dtFamilia.Rows(0)("CCCompra").ToString

        If cccompraFam.Length = 0 Then
            dtLinea.Rows(0)("CContable") = dtArticulo.Rows(0)("CCCompra").ToString
        Else
            dtLinea.Rows(0)("CContable") = cccompraFam
        End If

        dtLinea.Rows(0)("EstadoInmovilizado") = 0
        dtLinea.Rows(0)("Marca") = 0
        dtLinea.Rows(0)("TipoLineaFactura") = 0
        dtLinea.Rows(0)("IDCentroGestion") = "008"
        dtLinea.Rows(0)("IDUdInterna") = dtArticulo.Rows(0)("IDUdInterna").ToString
        dtLinea.Rows(0)("Factor") = 1
        dtLinea.Rows(0)("QInterna") = 1
        dtLinea.Rows(0)("Dto") = 0
        dtLinea.Rows(0)("DtoProntoPago") = 0
        dtLinea.Rows(0)("NoDeclarar") = 0


        dtArticulo = Nothing : dtFamilia = Nothing
        Try
            frComLinea.Update(dtLinea)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        'Hago la analítica y base imponible de esta línea
        setFraComAnalitica(dr)
        setFraBaseImponible(dr)
    End Sub
#End Region

#Region "FacturaCompraAnalitica"
    Public Sub setFraComAnalitica(ByVal dr)
        Dim dtCentroCosteAnalitica As New DataTable
        Dim f As New Filter
        f.Add("IDCentroCoste", FilterOperator.Equal, dr("NObra"))
        dtCentroCosteAnalitica = New BE.DataEngine().Filter("tbMaestroCentroCosteAnalitica", f)

        Dim fraComAnalitica As New FacturaCompraAnalitica
        Dim dtLineaAnalitica As DataTable = fraComAnalitica.AddNewForm
        Dim nObraPort As String

        If dr("NObra").ToString.Length <> 0 Then
            If dtCentroCosteAnalitica.Rows.Count > 0 Then
                dtLineaAnalitica.Rows(0)("IDLineaFactura") = IDLineaFactura
                'Aqui habrá que hacer la distincion para los centros de coste de portugal
                dtLineaAnalitica.Rows(0)("Importe") = dr("Precio")
                dtLineaAnalitica.Rows(0)("ImporteA") = dr("Precio")
                dtLineaAnalitica.Rows(0)("ImporteB") = dr("Precio")
                dtLineaAnalitica.Rows(0)("Porcentaje") = 100
                dtLineaAnalitica.Rows(0)("IDCentroCoste") = dr("NObra")
                Try
                    fraComAnalitica.Update(dtLineaAnalitica)
                    dtLineaAnalitica = Nothing
                Catch ex As Exception
                End Try
            Else
                dtLineaAnalitica.Rows(0)("IDLineaFactura") = IDLineaFactura
                'Aqui habrá que hacer la distincion para los centros de coste de portugal
                dtLineaAnalitica.Rows(0)("Importe") = dr("Precio")
                dtLineaAnalitica.Rows(0)("ImporteA") = dr("Precio")
                dtLineaAnalitica.Rows(0)("ImporteB") = dr("Precio")
                dtLineaAnalitica.Rows(0)("Porcentaje") = 100
                If dr("NObra") = "DP24" Then
                    nObraPort = "DP024"
                    dtLineaAnalitica.Rows(0)("IDCentroCoste") = nObraPort
                ElseIf dr("NObra") = "DPA24" Then
                    nObraPort = "DPA024"
                    dtLineaAnalitica.Rows(0)("IDCentroCoste") = nObraPort
                ElseIf dr("NObra") = "DP23" Then
                    nObraPort = "DP023"
                    dtLineaAnalitica.Rows(0)("IDCentroCoste") = nObraPort
                ElseIf dr("NObra") = "DP21" Then
                    nObraPort = "DP021"
                    dtLineaAnalitica.Rows(0)("IDCentroCoste") = nObraPort
                ElseIf dr("NObra") = "DP20" Then
                    nObraPort = "DP020"
                    dtLineaAnalitica.Rows(0)("IDCentroCoste") = nObraPort
                ElseIf dr("NObra") = "DPA20" Then
                    nObraPort = "DPA020"
                    dtLineaAnalitica.Rows(0)("IDCentroCoste") = nObraPort
                ElseIf dr("NObra") = "DP18" Then
                    nObraPort = "DP018"
                    dtLineaAnalitica.Rows(0)("IDCentroCoste") = nObraPort
                Else
                End If
                Try
                    fraComAnalitica.Update(dtLineaAnalitica)
                    dtLineaAnalitica = Nothing
                Catch ex As Exception
                End Try
            End If
        Else
        End If

    End Sub
#End Region

#Region "Base Imponible"
    Public Sub setFraBaseImponible(ByVal dr As DataRow)

        Dim frComBaseImponible As New FacturaCompraBaseImponible
        Dim dtBaseImponible As DataTable = frComBaseImponible.AddNewForm
        Dim aux As New Solmicro.Expertis.Business.ClasesTecozam.MetodosAuxiliares

        'Hago la comprobacion de que no hay ninguna linea con este mismo idtipoiva
        Dim IDLineaExisteONO As Integer
        IDLineaExisteONO = ExisteLineaBaseImponibleIDTipoIva(dr("IDTipoIva"))

        'Si es igual a 0 es que no hay ninguna linea con ese mismo IDTipoIva, se crea nueva
        'Si no se actualiza la que ya hay
        Dim tipo As Integer
        tipo = TipoIVALinea(dr("IDTipoIva"))

        If IDLineaExisteONO = 0 Then
            dtBaseImponible.Rows(0)("IDBaseImponible") = aux.devuelveAutonumeri
            dtBaseImponible.Rows(0)("IDFactura") = IDFactura
            dtBaseImponible.Rows(0)("IDTipoIva") = dr("IDTipoIva")
            dtBaseImponible.Rows(0)("BaseImponible") = dr("Precio")
            dtBaseImponible.Rows(0)("BaseImponibleA") = dr("Precio")
            dtBaseImponible.Rows(0)("BaseImponibleB") = dr("Precio")

            
            'IVA INVERSION SUJETO PASIVO ->1 (IVA sin repercutir)
            'IVA INTRACOMUNITARIO ->2
            'IVA RE ->3 (IVA normal + IvaRE)
            'IVA NORMAL -> 4
            Dim dtIVA As New DataTable
            Dim fIVA As New Filter
            fIVA.Add("IDTipoIva", FilterOperator.Equal, dr("IDTipoIva"))
            dtIVA = New BE.DataEngine().Filter("tbMaestroTipoIva", fIVA)

            Select Case tipo
                Case 1
                    dtBaseImponible.Rows(0)("ImpIva") = 0
                    dtBaseImponible.Rows(0)("ImpIvaA") = 0
                    dtBaseImponible.Rows(0)("ImpIvaB") = 0
                    dtBaseImponible.Rows(0)("ImpRE") = 0
                    dtBaseImponible.Rows(0)("ImpREA") = 0
                    dtBaseImponible.Rows(0)("ImpREB") = 0
                    dtBaseImponible.Rows(0)("ImpIntrastat") = 0
                    dtBaseImponible.Rows(0)("ImpIntrastatA") = 0
                    dtBaseImponible.Rows(0)("ImpIntrastatB") = 0
                    dtBaseImponible.Rows(0)("ImpSinRepercutir") = dr("Precio") * dtIVA.Rows(0)("IVASinRepercutir") / 100
                    dtBaseImponible.Rows(0)("ImpSinRepercutirA") = dr("Precio") * dtIVA.Rows(0)("IVASinRepercutir") / 100
                    dtBaseImponible.Rows(0)("ImpSinRepercutirB") = dr("Precio") * dtIVA.Rows(0)("IVASinRepercutir") / 100
                Case 2
                    dtBaseImponible.Rows(0)("ImpIva") = 0
                    dtBaseImponible.Rows(0)("ImpIvaA") = 0
                    dtBaseImponible.Rows(0)("ImpIvaB") = 0
                    dtBaseImponible.Rows(0)("ImpRE") = 0
                    dtBaseImponible.Rows(0)("ImpREA") = 0
                    dtBaseImponible.Rows(0)("ImpREB") = 0
                    dtBaseImponible.Rows(0)("ImpIntrastat") = dr("Precio") * dtIVA.Rows(0)("IvaIntrastat") / 100
                    dtBaseImponible.Rows(0)("ImpIntrastatA") = dr("Precio") * dtIVA.Rows(0)("IvaIntrastat") / 100
                    dtBaseImponible.Rows(0)("ImpIntrastatB") = dr("Precio") * dtIVA.Rows(0)("IvaIntrastat") / 100
                    dtBaseImponible.Rows(0)("ImpSinRepercutir") = 0
                    dtBaseImponible.Rows(0)("ImpSinRepercutirA") = 0
                    dtBaseImponible.Rows(0)("ImpSinRepercutirB") = 0
                Case 3
                    dtBaseImponible.Rows(0)("ImpIva") = dr("Precio") * dtIVA.Rows(0)("Factor") / 100
                    dtBaseImponible.Rows(0)("ImpIvaA") = dr("Precio") * dtIVA.Rows(0)("Factor") / 100
                    dtBaseImponible.Rows(0)("ImpIvaB") = dr("Precio") * dtIVA.Rows(0)("Factor") / 100
                    dtBaseImponible.Rows(0)("ImpRE") = dr("Precio") * dtIVA.Rows(0)("IvaRE") / 100
                    dtBaseImponible.Rows(0)("ImpREA") = dr("Precio") * dtIVA.Rows(0)("IvaRE") / 100
                    dtBaseImponible.Rows(0)("ImpREB") = dr("Precio") * dtIVA.Rows(0)("IvaRE") / 100
                    dtBaseImponible.Rows(0)("ImpIntrastat") = 0
                    dtBaseImponible.Rows(0)("ImpIntrastatA") = 0
                    dtBaseImponible.Rows(0)("ImpIntrastatB") = 0
                    dtBaseImponible.Rows(0)("ImpSinRepercutir") = 0
                    dtBaseImponible.Rows(0)("ImpSinRepercutirA") = 0
                    dtBaseImponible.Rows(0)("ImpSinRepercutirB") = 0
                Case 4
                    dtBaseImponible.Rows(0)("ImpIva") = dr("Precio") * dtIVA.Rows(0)("Factor") / 100
                    dtBaseImponible.Rows(0)("ImpIvaA") = dr("Precio") * dtIVA.Rows(0)("Factor") / 100
                    dtBaseImponible.Rows(0)("ImpIvaB") = dr("Precio") * dtIVA.Rows(0)("Factor") / 100
                    dtBaseImponible.Rows(0)("ImpRE") = 0
                    dtBaseImponible.Rows(0)("ImpREA") = 0
                    dtBaseImponible.Rows(0)("ImpREB") = 0
                    dtBaseImponible.Rows(0)("ImpIntrastat") = 0
                    dtBaseImponible.Rows(0)("ImpIntrastatA") = 0
                    dtBaseImponible.Rows(0)("ImpIntrastatB") = 0
                    dtBaseImponible.Rows(0)("ImpSinRepercutir") = 0
                    dtBaseImponible.Rows(0)("ImpSinRepercutirA") = 0
                    dtBaseImponible.Rows(0)("ImpSinRepercutirB") = 0
            End Select

            'Limpio Memoria
            fIVA = Nothing : dtIVA = Nothing

            dtBaseImponible.Rows(0)("ImpIVANoDeducible") = 0
            dtBaseImponible.Rows(0)("ImpIVANoDeducibleA") = 0
            dtBaseImponible.Rows(0)("ImpIVANoDeducibleB") = 0
            dtBaseImponible.Rows(0)("TipoIVADUA") = 0
            dtBaseImponible.Rows(0)("BaseImponibleDUA") = 0
            dtBaseImponible.Rows(0)("Origen") = 0
            Try
                frComBaseImponible.Update(dtBaseImponible)
                dtBaseImponible = Nothing
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        Else
            'Recupero según el ID de tbFacturaCompraBaseImponible y sumo según el ID y actualizo.
            Dim dtIDBaseImp As New DataTable
            Dim fID As New Filter
            fID.Add("IDBaseImponible", FilterOperator.Equal, IDLineaExisteONO)
            fID.Add("IDTipoIva", FilterOperator.Equal, dr("IDTipoIva"))
            'De esta tabla de la fila 0 tengo que sacar los datos que tengo que sumar con los nuevos
            dtIDBaseImp = New BE.DataEngine().Filter("tbFacturaCompraBaseImponible", fID)
            Dim ImpIva As Double
            Dim ImpRe As Double
            Dim ImpIntrastat As Double
            Dim ImpSinRepercutir As Double
            Dim BaseImponible As Double

            Dim dtIVA As New DataTable
            Dim fIVA As New Filter
            fIVA.Add("IDTipoIva", FilterOperator.Equal, dr("IDTipoIva"))
            dtIVA = New BE.DataEngine().Filter("tbMaestroTipoIva", fIVA)

            BaseImponible = dr("Precio")
            Select Case tipo
                Case 1
                    ImpIva = 0
                    ImpRe = 0
                    ImpIntrastat = 0
                    ImpSinRepercutir = BaseImponible * dtIVA.Rows(0)("IVASinRepercutir") / 100
                Case 2
                    ImpIva = 0
                    ImpRe = 0
                    ImpIntrastat = BaseImponible * dtIVA.Rows(0)("IvaIntrastat") / 100
                    ImpSinRepercutir = 0
                Case 3
                    ImpIva = 0 = BaseImponible * dtIVA.Rows(0)("Factor") / 100
                    ImpRe = BaseImponible * dtIVA.Rows(0)("IvaRE") / 100
                    ImpIntrastat = 0
                    ImpSinRepercutir = 0
                Case 4
                    ImpIva = BaseImponible * dtIVA.Rows(0)("Factor") / 100
                    ImpRe = 0
                    ImpIntrastat = 0
                    ImpSinRepercutir = 0
            End Select

            ImpIva = ImpIva + dtIDBaseImp.Rows(0)("ImpIva")
            ImpRe = ImpRe + dtIDBaseImp.Rows(0)("ImpRE")
            ImpIntrastat = ImpIntrastat + dtIDBaseImp.Rows(0)("ImpIntrastat")
            ImpSinRepercutir = ImpSinRepercutir + dtIDBaseImp.Rows(0)("ImpSinRepercutir")
            BaseImponible = BaseImponible + dtIDBaseImp.Rows(0)("BaseImponible")

            'Actualizo
            ActualizaBaseImponible(IDLineaExisteONO, ImpIva, ImpRe, ImpIntrastat, ImpSinRepercutir, BaseImponible)
        End If
        
    End Sub

    Public Function ExisteLineaBaseImponibleIDTipoIva(ByVal IDTipoIva As String) As Integer
        Dim dt As New DataTable
        Dim f As New Filter
        f.Add("IDTipoIva", FilterOperator.Equal, IDTipoIva)
        f.Add("IDFactura", FilterOperator.Equal, IDFactura)
        dt = New BE.DataEngine().Filter("tbFacturaCompraBaseImponible", f)

        If dt.Rows.Count > 0 Then
            Return dt.Rows(0)("IDBaseImponible")
        Else
            Return 0
        End If
    End Function

    Public Sub ActualizaBaseImponible(ByVal IDBaseImponible As Integer, ByVal ImpIva As Double, ByVal ImpRe As Double, _
    ByVal ImpIntrastat As Double, ByVal ImpSinRepercutir As Double, ByVal BaseImponible As Double)

        Dim StrSql As String = "UPDATE tbFacturaCompraBaseImponible "
        StrSql &= " SET BaseImponible = '" & BaseImponible.ToString.Replace(",", ".") & "', BaseImponibleA = '" & BaseImponible.ToString.Replace(",", ".") & "', BaseImponibleB = '" & BaseImponible.ToString.Replace(",", ".") & "',"
        StrSql &= " ImpIva = '" & ImpIva.ToString.Replace(",", ".") & "', ImpIvaA = '" & ImpIva.ToString.Replace(",", ".") & "', ImpIvaB = '" & BaseImponible.ToString.Replace(",", ".") & "',"
        StrSql &= " ImpRE = '" & ImpRe.ToString.Replace(",", ".") & "', ImpREA = '" & ImpRe.ToString.Replace(",", ".") & "', ImpREB = '" & ImpRe.ToString.Replace(",", ".") & "',"
        StrSql &= " ImpIntrastat = '" & ImpIntrastat.ToString.Replace(",", ".") & "', ImpIntrastatA = '" & ImpIntrastat.ToString.Replace(",", ".") & "', ImpIntrastatB = '" & ImpIntrastat.ToString.Replace(",", ".") & "',"
        StrSql &= " ImpSinRepercutir = '" & ImpSinRepercutir.ToString.Replace(",", ".") & "', ImpSinRepercutirA = '" & ImpSinRepercutir.ToString.Replace(",", ".") & "', ImpSinRepercutirB = '" & ImpSinRepercutir.ToString.Replace(",", ".") & "'"
        StrSql &= " WHERE IDBaseImponible= " & IDBaseImponible & ""

        aux.EjecutarSql(StrSql)
    End Sub
#End Region

#Region "Fecha Vencimiento"

    Public Sub setFraVencimiento(ByVal dr As DataRow)
        Dim db As String
        db = ExpertisApp.DataBaseName.ToString()

        Dim frComPagoVencimiento As New Pago
        Dim dtPago As DataTable = frComPagoVencimiento.AddNewForm
        Dim dtFraCabecera As DataTable
        dtFraCabecera = devuelveFraCabecera()

        dtPago.Rows(0)("IDPago") = aux.devuelveAutonumeri
        dtPago.Rows(0)("IDFactura") = IDFactura
        dtPago.Rows(0)("NFactura") = dtFraCabecera.Rows(0)("NFactura")
        'CContable = IDProveedor
        dtPago.Rows(0)("Titulo") = dtFraCabecera.Rows(0)("RazonSocial")
        dtPago.Rows(0)("IDFormaPago") = dtFraCabecera.Rows(0)("IDFormaPago")
        dtPago.Rows(0)("CContable") = dtFraCabecera.Rows(0)("IDProveedor")
        dtPago.Rows(0)("IDProveedor") = dtFraCabecera.Rows(0)("IDProveedor")

        Dim ImporteVencimiento As Double
        ImporteVencimiento = devuelveTotalImporteLineas()

        'Si tiene retención o no tiene retencion
        Dim retencion As Double
        'retencion = TieneRetencion(dtFraCabecera.Rows(0)("IDProveedor").ToString)
        retencion = dr("Retencion").ToString.Replace(".", ",")
        If retencion = 0 Then
            dtPago.Rows(0)("ImpVencimiento") = ImporteVencimiento
            dtPago.Rows(0)("ImpVencimientoA") = ImporteVencimiento
            dtPago.Rows(0)("ImpVencimientoB") = ImporteVencimiento

            'Fecha Vencimiento de donde viene
            dtPago.Rows(0)("FechaVencimiento") = devuelveFechaVencimiento()
            dtPago.Rows(0)("FechaVencimientoFactura") = devuelveFechaVencimiento()
            dtPago.Rows(0)("Situacion") = 0
            dtPago.Rows(0)("Impreso") = 0
            dtPago.Rows(0)("Contabilizado") = 0
            dtPago.Rows(0)("IDMoneda") = "EUR"
            dtPago.Rows(0)("CambioA") = 1
            dtPago.Rows(0)("CambioB") = 1
            dtPago.Rows(0)("RecargoFinanciero") = 0
            dtPago.Rows(0)("RecargoFinancieroA") = 0
            dtPago.Rows(0)("RecargoFinancieroB") = 0
            dtPago.Rows(0)("MarcaAgrupado") = 0
            dtPago.Rows(0)("IdTipoPago") = 0
            dtPago.Rows(0)("Permiso") = 0
            dtPago.Rows(0)("GeneradoAsientoTalon") = 0
            dtPago.Rows(0)("ImpIntereses") = 0
            dtPago.Rows(0)("ImpRecuperacionCoste") = 0
            dtPago.Rows(0)("ImpCuota") = 0
            dtPago.Rows(0)("GeneradaFacturadaSN") = 0
            dtPago.Rows(0)("ImpInteresesA") = 0
            dtPago.Rows(0)("ImpInteresesB") = 0
            dtPago.Rows(0)("ImpRecuperacionCosteA") = 0
            dtPago.Rows(0)("ImpRecuperacionCosteB") = 0
            dtPago.Rows(0)("ImpCuotaA") = 0
            dtPago.Rows(0)("ImpCuotaB") = 0
            dtPago.Rows(0)("GeneradoAsientoRemesa") = 0
            dtPago.Rows(0)("SyncDB") = db

            Try
                frComPagoVencimiento.Update(dtPago)
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        Else
            dtPago.Rows(0)("ImpVencimiento") = ImporteVencimiento - ImporteVencimiento * (retencion / 100)
            dtPago.Rows(0)("ImpVencimientoA") = ImporteVencimiento - ImporteVencimiento * (retencion / 100)
            dtPago.Rows(0)("ImpVencimientoB") = ImporteVencimiento - ImporteVencimiento * (retencion / 100)

            'Fecha Vencimiento de donde viene
            dtPago.Rows(0)("FechaVencimiento") = devuelveFechaVencimiento()
            dtPago.Rows(0)("FechaVencimientoFactura") = devuelveFechaVencimiento()
            dtPago.Rows(0)("Situacion") = 0
            dtPago.Rows(0)("Impreso") = 0
            dtPago.Rows(0)("Contabilizado") = 0
            dtPago.Rows(0)("IDMoneda") = "EUR"
            dtPago.Rows(0)("CambioA") = 1
            dtPago.Rows(0)("CambioB") = 1
            dtPago.Rows(0)("RecargoFinanciero") = 0
            dtPago.Rows(0)("RecargoFinancieroA") = 0
            dtPago.Rows(0)("RecargoFinancieroB") = 0
            dtPago.Rows(0)("MarcaAgrupado") = 0
            dtPago.Rows(0)("IdTipoPago") = 0
            dtPago.Rows(0)("Permiso") = 0
            dtPago.Rows(0)("GeneradoAsientoTalon") = 0
            dtPago.Rows(0)("ImpIntereses") = 0
            dtPago.Rows(0)("ImpRecuperacionCoste") = 0
            dtPago.Rows(0)("ImpCuota") = 0
            dtPago.Rows(0)("GeneradaFacturadaSN") = 0
            dtPago.Rows(0)("ImpInteresesA") = 0
            dtPago.Rows(0)("ImpInteresesB") = 0
            dtPago.Rows(0)("ImpRecuperacionCosteA") = 0
            dtPago.Rows(0)("ImpRecuperacionCosteB") = 0
            dtPago.Rows(0)("ImpCuotaA") = 0
            dtPago.Rows(0)("ImpCuotaB") = 0
            dtPago.Rows(0)("GeneradoAsientoRemesa") = 0
            dtPago.Rows(0)("SyncDB") = db

            Try
                frComPagoVencimiento.Update(dtPago)
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try

            'Y AHORA SE INSERTA EL VENCIMIENTO CORRESPONDIENTE A LA RETENCION
            Dim dtPagoRetencion As DataTable = frComPagoVencimiento.AddNewForm
            dtPagoRetencion.Rows(0)("IDPago") = aux.devuelveAutonumeri
            dtPagoRetencion.Rows(0)("IDFactura") = IDFactura
            dtPagoRetencion.Rows(0)("NFactura") = dtFraCabecera.Rows(0)("NFactura")
            'CContable = IDProveedor
            Select Case db
                Case "xTecozam50R2", "xTecozam50R2Demo"
                    dtPagoRetencion.Rows(0)("Titulo") = "PROVEEDOR DE RETENCION"
                    dtPagoRetencion.Rows(0)("IDFormaPago") = "00"
                    dtPagoRetencion.Rows(0)("CContable") = "4751000000"
                    dtPagoRetencion.Rows(0)("IDProveedor") = "4000000045"
                Case "xFerrallas50R2", "xFerrallas50R2Demo"
                    dtPagoRetencion.Rows(0)("Titulo") = "H.P. ACREEDORA POR RETENCION"
                    dtPagoRetencion.Rows(0)("IDFormaPago") = "00"
                    dtPagoRetencion.Rows(0)("CContable") = "4751000000"
                    dtPagoRetencion.Rows(0)("IDProveedor") = "4751000110"
                Case "xSecozam50R2", "xSecozam50R2Demo"
                    dtPagoRetencion.Rows(0)("Titulo") = "AGENCIA TRIBUTARIA"
                    dtPagoRetencion.Rows(0)("IDFormaPago") = "00"
                    dtPagoRetencion.Rows(0)("CContable") = "4750000000"
                    dtPagoRetencion.Rows(0)("IDProveedor") = "00"
            End Select

            dtPagoRetencion.Rows(0)("ImpVencimiento") = ImporteVencimiento * (retencion / 100)
            dtPagoRetencion.Rows(0)("ImpVencimientoA") = ImporteVencimiento * (retencion / 100)
            dtPagoRetencion.Rows(0)("ImpVencimientoB") = ImporteVencimiento * (retencion / 100)

            'Fecha Vencimiento de donde viene
            dtPagoRetencion.Rows(0)("FechaVencimiento") = devuelveFechaVencimientoRetencion()
            dtPagoRetencion.Rows(0)("FechaVencimientoFactura") = devuelveFechaVencimientoRetencion()
            dtPagoRetencion.Rows(0)("Situacion") = 0
            dtPagoRetencion.Rows(0)("Impreso") = 0
            dtPagoRetencion.Rows(0)("Contabilizado") = 0
            dtPagoRetencion.Rows(0)("IDMoneda") = "EUR"
            dtPagoRetencion.Rows(0)("CambioA") = 1
            dtPagoRetencion.Rows(0)("CambioB") = 1
            dtPagoRetencion.Rows(0)("RecargoFinanciero") = 0
            dtPagoRetencion.Rows(0)("RecargoFinancieroA") = 0
            dtPagoRetencion.Rows(0)("RecargoFinancieroB") = 0
            dtPagoRetencion.Rows(0)("MarcaAgrupado") = 0
            dtPagoRetencion.Rows(0)("IdTipoPago") = 0
            dtPagoRetencion.Rows(0)("Permiso") = 0
            dtPagoRetencion.Rows(0)("GeneradoAsientoTalon") = 0
            dtPagoRetencion.Rows(0)("ImpIntereses") = 0
            dtPagoRetencion.Rows(0)("ImpRecuperacionCoste") = 0
            dtPagoRetencion.Rows(0)("ImpCuota") = 0
            dtPagoRetencion.Rows(0)("GeneradaFacturadaSN") = 0
            dtPagoRetencion.Rows(0)("ImpInteresesA") = 0
            dtPagoRetencion.Rows(0)("ImpInteresesB") = 0
            dtPagoRetencion.Rows(0)("ImpRecuperacionCosteA") = 0
            dtPagoRetencion.Rows(0)("ImpRecuperacionCosteB") = 0
            dtPagoRetencion.Rows(0)("ImpCuotaA") = 0
            dtPagoRetencion.Rows(0)("ImpCuotaB") = 0
            dtPagoRetencion.Rows(0)("GeneradoAsientoRemesa") = 0
            dtPagoRetencion.Rows(0)("SyncDB") = db

            Try
                frComPagoVencimiento.Update(dtPagoRetencion)
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        End If
       
    End Sub

    Public Function TieneRetencion(ByVal IDProveedor As String) As Double
        Dim dt As New DataTable
        Dim f As New Filter

        f.Add("IDProveedor", FilterOperator.Equal, IDProveedor)
        dt = New BE.DataEngine().Filter("tbMaestroProveedor", f)

        If dt.Rows(0)("RetencionIRPF") <> 0 Then
            Return dt.Rows(0)("RetencionIRPF")
        Else
            Return 0
        End If
    End Function
#End Region

#Region "Metodos Auxiliares"

    Public Function devuelveFraCabecera() As DataTable
        Dim dtFra As New DataTable
        Dim f As New Filter
        f.Add("IDFactura", FilterOperator.Equal, IDFactura)
        dtFra = New BE.DataEngine().Filter("tbFacturaCompraCabecera", f)
        Return dtFra
    End Function

    Public Function devuelveFechaVencimientoRetencion() As Date
        Dim dtFra As New DataTable
        Dim f As New Filter
        f.Add("IDFactura", FilterOperator.Equal, IDFactura)
        dtFra = New BE.DataEngine().Filter("tbFacturaCompraCabecera", f)
        Dim fechaFra As Date
        fechaFra = dtFra.Rows(0)("SuFechaFactura")
        dtFra = Nothing
        Return fechaFra
    End Function

    Public Function devuelveFechaVencimiento() As Date
        Dim dtFra As New DataTable
        Dim f As New Filter
        f.Add("IDFactura", FilterOperator.Equal, IDFactura)
        dtFra = New BE.DataEngine().Filter("tbFacturaCompraCabecera", f)
        Dim fechaFra As Date
        fechaFra = dtFra.Rows(0)("SuFechaFactura")
        Dim IDDiaPago As String
        Dim IDCondicionPago As String
        Dim dia As Integer
        Dim diasSumar As Integer

        IDDiaPago = dtFra.Rows(0)("IDDiaPago").ToString
        Select Case IDDiaPago
            Case "00"
                dia = "00"
            Case "01"
                dia = "01"
            Case "02"
                dia = "05"
            Case "03"
                dia = "10"
            Case "04"
                dia = "15"
            Case "05"
                dia = "20"
            Case "06"
                dia = "25"
            Case "23"
                dia = "23"
            Case "27"
                dia = "27"
            Case "28"
                dia = "28"
            Case "30"
                dia = "30"
            Case Else
                dia = "00"
        End Select
        IDCondicionPago = dtFra.Rows(0)("IDCondicionPago").ToString

        Select Case [IDCondicionPago]
            Case "00"
                diasSumar = "00"
            Case "01"
                diasSumar = "30"
            Case "02"
                diasSumar = "60"
            Case "03"
                diasSumar = "90"
            Case "04"
                diasSumar = "120"
            Case "07"
                diasSumar = "100"
            Case "15"
                diasSumar = "15"
            Case "150"
                diasSumar = "150"
            Case "165"
                diasSumar = "165"
            Case "180"
                diasSumar = "180"
            Case "210"
                diasSumar = "210"
            Case "240"
                diasSumar = "240"
            Case "270"
                diasSumar = "270"
            Case "45"
                diasSumar = "45"
            Case "85"
                diasSumar = "85"
            Case Else
                diasSumar = "00"
        End Select

        dtFra = Nothing
        Dim fechaV As Date
        fechaV = obtieneFechaVencimientoFinal(fechaFra, dia, diasSumar)

        Return fechaV
    End Function

    Public Function obtieneFechaVencimientoFinal(ByVal fechaFra As Date, ByVal dia As Integer, ByVal diasSumar As Integer) As Date
        Dim fechaV As Date
        If dia = "00" Then
            fechaV = fechaFra.AddDays(diasSumar)
        Else
            If ((dia + diasSumar) < 31) And ((dia + diasSumar) < fechaFra.Day) Then
                fechaV = fechaFra.AddMonths(1)
                fechaV = fechaV.AddDays(dia - fechaV.Day)
            Else
                fechaV = fechaFra.AddDays(diasSumar)
                fechaV = fechaV.AddDays(dia - fechaV.Day)
            End If
        End If
        Return fechaV
    End Function

    Public Function devuelveTotalImporteLineas() As Double
        Dim dtFraLinea As New DataTable
        Dim f As New Filter
        Dim baseimpo As Double = 0
        Dim iva As Double = 0
        Dim total As Double = 0

        f.Add("IDFactura", FilterOperator.Equal, IDFactura)
        dtFraLinea = New BE.DataEngine().Filter("tbFacturaCompraLinea", f)
        For Each dr As DataRow In dtFraLinea.Rows
            baseimpo += dr("Precio")
            iva += getIvaLinea(dr)
        Next
        dtFraLinea = Nothing
        total = baseimpo + iva
        Return total
    End Function

    Public Function getIvaLinea(ByVal dr As DataRow) As Double
        Dim iva As Double

        Select Case dr("IDTipoIVA")
            Case "00"
                iva = 0
            Case "01"
                iva = 16
            Case "02"
                iva = 7
            Case "03"
                iva = 4
            Case "06"
                iva = 18
            Case "07"
                iva = 8
            Case "10"
                iva = 10
            Case "12"
                iva = 12
            Case "21"
                iva = 21
            Case Else
                iva = 0
        End Select

        Return dr("Precio") * iva / 100
        'IDCondicionPago = dtFra.Rows(0)("IDCondicionPago").ToString
    End Function

    Public Sub actualizaCabecera()
        Dim dt As New DataTable
        Dim f As New Filter

        f.Add("IDFactura", FilterOperator.Equal, IDFactura)
        dt = New BE.DataEngine().Filter("tbFacturaCompraBaseImponible", f)

        Dim baseImponible As Double = 0
        Dim iva As Double = 0
        Dim ImpRE As Double = 0
        Dim ImpIntrastat As Double = 0
        Dim ImpSinRepercutir As Double = 0
        Dim total As Double = 0


        For Each dr As DataRow In dt.Rows
            baseImponible += Nz(dr("BaseImponible"), 0)
            iva += Nz(dr("ImpIva"), 0)

            ImpRE += Nz(dr("ImpRE"), 0)
            ImpIntrastat += Nz(dr("ImpIntrastat"), 0)
            ImpSinRepercutir += Nz(dr("ImpSinRepercutir"), 0)
        Next

        total = baseImponible + iva

        dt = Nothing
        'Actualizo Base Imponible
        Dim StrSql As String = "UPDATE tbFacturaCompraCabecera "
        StrSql &= " SET ImpLineas = '" & baseImponible.ToString.Replace(",", ".") & "', ImpLineasA = '" & baseImponible.ToString.Replace(",", ".") & "', ImpLineasB = '" & baseImponible.ToString.Replace(",", ".") & "',"
        StrSql &= " BaseImponible = '" & baseImponible.ToString.Replace(",", ".") & "'"
        StrSql &= ", BaseImponibleA = '" & baseImponible.ToString.Replace(",", ".") & "'"
        StrSql &= ", BaseImponibleB = '" & baseImponible.ToString.Replace(",", ".") & "'"
        StrSql &= ", ImpTotal = '" & total.ToString.Replace(",", ".") & "', ImpTotalA = '" & total.ToString.Replace(",", ".") & "',ImpTotalB = '" & total.ToString.Replace(",", ".") & "'"
        StrSql &= ", BaseRetencion = " & baseImponible.ToString.Replace(",", ".") & ", BaseRetencionA = " & baseImponible.ToString.Replace(",", ".") & ", BaseRetencionB = " & baseImponible.ToString.Replace(",", ".") & ","
        StrSql &= " ImpIva = '" & iva.ToString.Replace(",", ".") & "',ImpIvaA = '" & iva.ToString.Replace(",", ".") & "',ImpIvaB = '" & iva.ToString.Replace(",", ".") & "',"
        StrSql &= " ImpRE = '" & ImpRE.ToString.Replace(",", ".") & "', ImpREA = '" & ImpRE.ToString.Replace(",", ".") & "', ImpREB = '" & ImpRE.ToString.Replace(",", ".") & "',"
        StrSql &= " ImpIntrastat = '" & ImpIntrastat.ToString.Replace(",", ".") & "', ImpIntrastatA = '" & ImpIntrastat.ToString.Replace(",", ".") & "', ImpIntrastatB = '" & ImpIntrastat.ToString.Replace(",", ".") & "',"
        StrSql &= " ImpSinRepercutir = '" & ImpSinRepercutir.ToString.Replace(",", ".") & "', ImpSinRepercutirA = '" & ImpSinRepercutir.ToString.Replace(",", ".") & "', ImpSinRepercutirB = '" & ImpSinRepercutir.ToString.Replace(",", ".") & "'"
        StrSql &= " WHERE IDFactura= " & IDFactura & ""

        aux.EjecutarSql(StrSql)

        'Este método Rellena la tabla que muestra las facturas creadas
        CompletaTablaResultados()
    End Sub

    Public Sub CompletaTablaResultados()

        Dim dt As New DataTable
        Dim f As New Filter

        f.Add("IDFactura", FilterOperator.Equal, IDFactura)
        dt = New BE.DataEngine().Filter("tbFacturaCompraCabecera", f)

        Dim newrow As DataRow = dtResultados.NewRow
        newrow("FechaFactura") = dt.Rows(0)("FechaFactura")
        newrow("SuFactura") = dt.Rows(0)("SuFactura")
        newrow("NFactura") = dt.Rows(0)("NFactura")
        dtResultados.Rows.Add(newrow)
    End Sub

    Public Function TipoIVALinea(ByVal IDTipoIva As String) As Integer

        'IVA INVERSION SUJETO PASIVO ->1 (IVA sin repercutir)
        'IVA INTRACOMUNITARIO ->2
        'IVA RE ->3 (IVA normal + IvaRE)
        'IVA NORMAL -> 4

        Dim dtTipoIva As New DataTable
        Dim f As New Filter
        f.Add("IDTipoIva", FilterOperator.Equal, IDTipoIva)

        dtTipoIva = New BE.DataEngine().Filter("tbMaestroTipoIva", f)

        If dtTipoIva.Rows(0)("SinRepercutir") = True Then
            Return 1
        ElseIf dtTipoIva.Rows(0)("IvaIntrastat").ToString <> 0 Then
            Return 2
        ElseIf dtTipoIva.Rows(0)("IvaRE").ToString <> 0 Then
            Return 3
        Else
            Return 4
        End If
    End Function

    Public Sub ActualizaLineaCreada(ByVal IDFacturaDocuware As Integer, ByVal IDLineaFactura As Integer)
        Dim StrSql As String = "UPDATE tbFacturasDocuware "
        StrSql &= " SET Insertada = '" & True & "'"
        StrSql &= " WHERE IDFacturaDocuware= " & IDFacturaDocuware & " and IDLineaFactura = " & IDLineaFactura & ""

        aux.EjecutarSql(StrSql)
    End Sub
#End Region

End Class


