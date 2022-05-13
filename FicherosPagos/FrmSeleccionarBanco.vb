Public Class FrmSeleccionarBanco

    Public strIDBancoPropio As String

    Private Sub BtnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAceptar.Click
        If advbancoPropio.text = "" Then
            ExpertisApp.GenerateMessage("Debe rellenar el banco propio", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            strIDBancoPropio = AdvBancoPropio.Text
            Me.Close()
        End If
    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        strIDBancoPropio = ""
        Me.Close()
    End Sub
End Class