Imports System.IO
Imports System.Globalization

Public Class frmCrearAlbaranesTrazalMe

#Region "ToolbarActions"
    Private Sub LoadToolbarActions()
        Me.FormActions.Add("Crear albaranes en el servidor.", AddressOf ProcesarAlbaranes)
    End Sub
#End Region

#Region "LOAD"
    Private Sub frmCrearAlbaranesTrazalMe_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadToolbarActions()
    End Sub
#End Region

    Dim rutaSalida = "\\stor01\DG\Comun\ALBARANES-TRAZALME\0. COMENZADOS\0. DESDE ALMACEN\"
    Dim rutaRetorno = "\\stor01\DG\Comun\ALBARANES-TRAZALME\0. COMENZADOS\1. DESDE OBRA\"

#Region "CreaAlbaranesEnFicheros"
    Private Sub ProcesarFilasAlbaranes(ByVal dtAlbaranesSinCrear As DataTable)
        Dim ruta As String = ""

        ' Variables para controlar el archivo
        Dim idAlbaranActual As Integer = dtAlbaranesSinCrear.Rows(0)("IDAlbaran")
        Dim fechaActual As String = dtAlbaranesSinCrear.Rows(0)("FechaDocumento")
        Dim nObraDestinoActual As String = dtAlbaranesSinCrear.Rows(0)("NObraDestino")
        Dim nObraOrigenActual As String = dtAlbaranesSinCrear.Rows(0)("NObraOrigen")
        Dim observacionesActual As String = ""
        Dim informacion As String = ""
        Dim cabecera As String = ""

        ' Recorremos cada fila
        For Each fila As DataRow In dtAlbaranesSinCrear.Rows
            Dim idAlbaran As Integer = CInt(fila("IDAlbaran"))
            Dim fecha As DateTime = fila("FechaDocumento")
            Dim nObraDestino As String = fila("NObraDestino")
            Dim nObraOrigen As String = fila("NObraOrigen")
            Dim observaciones As String = Nz(fila("Observaciones"), "")

            ' Si el IDAlbaran es diferente al actual, cerramos el archivo actual y abrimos uno nuevo
            If idAlbaran <> idAlbaranActual Then
                GuardarArchivo(cabecera, nObraOrigenActual, nObraDestinoActual, fechaActual, ruta, observacionesActual, idAlbaranActual, informacion)
                idAlbaranActual = idAlbaran : fechaActual = fecha : nObraDestinoActual = nObraDestino : nObraOrigenActual = nObraOrigen : observacionesActual = observaciones
                informacion = "" : cabecera = "" : observaciones = ""
            End If
            Dim descArticulo As String = devuelveDescArticulo(fila("IDArticulo"))
            informacion &= Environment.NewLine & "El artículo " & descArticulo & " con IDArticulo " & fila("IDArticulo").ToString + " y cantidad: " + fila("Cantidad").ToString + "."

        Next
        GuardarArchivo(cabecera, nObraOrigenActual, nObraDestinoActual, fechaActual, ruta, observacionesActual, idAlbaranActual, informacion)

        'MANDAR CORREO DE QUE HAY ALBARANES EN COMUN COPIA DAVID DE MOMENTO
        'HAY ALBARANES DE SALIDA POR CREAR.
        'DESDE ALMACEN: 4
        'DESDE OBRA: 3

    End Sub
#End Region
    Public Sub ProcesarAlbaranes()
        '1ª Parte: Conseguir todas las lineas
        Dim dtAlbaranesSinCrear As DataTable = devuelveAlbaranesSinCrear()

        If dtAlbaranesSinCrear.Rows.Count > 0 Then
            ProcesarFilasAlbaranes(dtAlbaranesSinCrear)
            actualizaRegistros(dtAlbaranesSinCrear)
        End If
    End Sub
    Public Sub GuardarArchivo(ByVal cabecera As String, ByVal nObraOrigenActual As String, ByVal nObraDestinoActual As String, ByVal fechaActual As DateTime, ByVal ruta As String, ByVal observacionesActual As String, ByVal idAlbaranActual As String, ByVal informacion As String)
        ' Escribir la información acumulada del último IDAlbaran fuera del bucle
        cabecera &= "Obra origen: " & nObraOrigenActual & Environment.NewLine
        cabecera &= "Obra destino: " & nObraDestinoActual & Environment.NewLine
        cabecera &= "Fecha: " & fechaActual.ToString()
        If nObraOrigenActual = "011" Then
            ruta = rutaSalida
        Else
            ruta = rutaRetorno
        End If
        Dim direccionFinal As String = ruta & nObraOrigenActual & "_" & nObraDestinoActual & "_" & DevuelveFechaConFormato(fechaActual.ToString) & "_" & idAlbaranActual & ".txt"
        File.WriteAllText(direccionFinal, cabecera & Environment.NewLine & informacion & Environment.NewLine & Environment.NewLine & observacionesActual)

    End Sub
    Public Sub actualizaRegistros(ByVal dtAlbaranesSinCrear As DataTable)
        Dim sql As String
        Dim aux As New Solmicro.Expertis.Business.ClasesTecozam.MetodosAuxiliares
        For Each fila As DataRow In dtAlbaranesSinCrear.Rows
            sql = "UPDATE tbAlbaranTrazalMe "
            sql &= "SET Insertada=1"
            sql &= " WHERE IDAlbaran = '" & fila("IDAlbaran").ToString & "' AND IDLinea= '" & fila("IDLinea").ToString & "'"

            aux.EjecutarSql(Sql)
        Next
    End Sub
    Public Function DevuelveFechaConFormato(ByVal fechanumero As String) As String

        Dim fechaActual As DateTime = fechanumero
        Dim formatoPersonalizado As String = "dd MM yyyy"
        Dim fechaComoStringConFormato As String = fechaActual.ToString(formatoPersonalizado)

        Return fechaComoStringConFormato

    End Function
    Function devuelveAlbaranesSinCrear() As DataTable
        Dim filtro As New Filter
        filtro.Add("Insertada", FilterOperator.Equal, False)
        Return New BE.DataEngine().Filter("tbAlbaranTrazalMe", filtro, , "IDAlbaran, IDLinea asc")
    End Function
    Public Function devuelveDescArticulo(ByVal IDArticulo As String) As String
        Dim dt As New DataTable
        Dim filtro As New Filter
        filtro.Add("IDArticulo", FilterOperator.Equal, IDArticulo)
        dt = New BE.DataEngine().Filter("tbMaestroArticulo", filtro)

        Return dt(0)("DescArticulo")
    End Function
End Class