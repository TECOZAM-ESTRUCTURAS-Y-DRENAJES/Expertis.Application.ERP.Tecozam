Imports Janus.Windows.GridEX

Public Class DetalleFacturaDocuware
    Inherits System.Windows.Forms.Form


    Public mData2 As New DataTable

    Public Sub New()
        MyBase.New()
        InitializeComponent()
        'CrearEsquema()
    End Sub

    Private Sub DetalleFacturaDocuware_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Detalle.TabKeyBehavior = TabKeyBehavior.ControlNavigation
        Detalle.DataSource = mData2
    End Sub

    Private Sub DetalleFacturaDocuware_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        Button1.Focus()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
End Class