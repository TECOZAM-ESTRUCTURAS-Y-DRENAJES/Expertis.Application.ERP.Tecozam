Public Class ProveedorDocu

    Public IDProveedor As String
    Public CifProveedor As String
    Public RazonSocial As String
    Public IDFormaPago As String
    Public IDCondicionPago As String
    Public IDDiaPago As String
    'Public IDProveedorBanco As String
    Public IDBancoPropio As String
    Public IDMoneda As String
    Public Direccion As String
    Public CodPostal As String
    Public Poblacion As String
    Public Provincia As String
    Public IDPais As String
    Public IDCentroGestion As String
    Public IDProveedorBanco As String

    Public Sub New(ByVal IDProveedor As String)
        Dim dt As New DataTable
        Dim f As New Filter
        f.Add("IDProveedor", FilterOperator.Equal, IDProveedor)
        dt = New BE.DataEngine().Filter("tbMaestroProveedor", f)

        If dt.Rows(0)("IDProveedor").ToString.Length <> 0 Then
            Me.IDProveedor = dt.Rows(0)("IDProveedor")
        End If

        Me.CifProveedor = Nz(dt.Rows(0)("CifProveedor"), "")
        Me.RazonSocial = Nz(dt.Rows(0)("RazonSocial"), "")
        Me.IDFormaPago = Nz(dt.Rows(0)("IDFormaPago"), "")
        Me.IDCondicionPago = Nz(dt.Rows(0)("IDCondicionPago"), "")
        Me.IDDiaPago = Nz(dt.Rows(0)("IDDiaPago"), "")

        If dt.Rows(0)("IDBancoPropio").ToString.Length <> 0 Then
            Me.IDBancoPropio = dt.Rows(0)("IDBancoPropio")
        End If

        If dt.Rows(0)("IDMoneda").ToString.Length <> 0 Then
            Me.IDMoneda = dt.Rows(0)("IDMoneda")
        End If

        If dt.Rows(0)("Direccion").ToString.Length <> 0 Then
            Me.Direccion = dt.Rows(0)("Direccion")
        End If

        If dt.Rows(0)("CodPostal").ToString.Length <> 0 Then
            Me.CodPostal = dt.Rows(0)("CodPostal")
        End If
        If dt.Rows(0)("Poblacion").ToString.Length <> 0 Then
            Me.Poblacion = dt.Rows(0)("Poblacion")
        End If
        If dt.Rows(0)("Provincia").ToString.Length <> 0 Then
            Me.Provincia = dt.Rows(0)("Provincia")
        End If
        If dt.Rows(0)("IDPais").ToString.Length <> 0 Then
            Me.IDPais = dt.Rows(0)("IDPais")
        End If

        If dt.Rows(0)("IDCentroGestion").ToString.Length <> 0 Then
            Me.IDCentroGestion = dt.Rows(0)("IDCentroGestion")
        End If

        If dt.Rows(0)("IDCentroGestion").ToString.Length <> 0 Then
            Me.IDCentroGestion = dt.Rows(0)("IDCentroGestion")
        End If

        Dim dt2 As New DataTable
        Dim fr As New Filter
        fr.Add("IDProveedor", FilterOperator.Equal, IDProveedor)

        dt2 = New BE.DataEngine().Filter("tbProveedorBanco", fr)

        Try
            If dt2.Rows(0)("IDProveedorBanco").ToString.Length <> 0 Then
                Me.IDProveedorBanco = dt2.Rows(0)("IDProveedorBanco")
            End If
        Catch ex As Exception
        End Try
        
    End Sub

End Class