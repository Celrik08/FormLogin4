Public Class FormKasir

    Private Sub TextKode_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextKode.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            TextJumlah.Focus()
        End If
    End Sub
    Private Sub TextKode_TextChanged(sender As Object, e As EventArgs) Handles TextKode.TextChanged
        Dim kode As String = TextKode.Text

        If kode = "69244853701232" Then
            TextNama.Text = "pulpen"
            TextHarga.Text = "Rp. 5.000"
        ElseIf kode = "8997214298441" Then
            TextNama.Text = "stabiloa"
            TextHarga.Text = "Rp. 7.000"
        ElseIf kode = "4974052841675" Then
            TextNama.Text = "Spidol"
            TextHarga.Text = "Rp. 4.500"
        Else
            TextNama.Text = ""
            TextHarga.Text = ""
        End If
    End Sub

    Private Sub TextJumlah_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextJumlah.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            CalculateSubTotal()
            e.Handled = True
        End If
    End Sub
    Private Sub CalculateSubTotal()
        Dim jumlah As Integer = Convert.ToInt32(TextJumlah.Text)
        Dim harga As Decimal = Convert.ToDecimal(TextHarga.Text.Replace("Rp. ", "").Replace(".", ""))
        Dim subTotal As Decimal = harga * jumlah
        TextSub.Text = subTotal.ToString("C")
    End Sub
    Private Sub BtnSimpan_Click(sender As Object, e As EventArgs) Handles BtnSimpan.Click
        Dim kode As String = TextKode.Text
        Dim nama As String = TextNama.Text
        Dim harga As String = TextHarga.Text
        Dim jumlah As String = TextJumlah.Text
        Dim subTotal As String = TextSub.Text

        Dim formPenjualan As FormPenjualan = CType(Application.OpenForms("FormPenjualan"), FormPenjualan)
        If formPenjualan IsNot Nothing Then
            formPenjualan.AddDataToDataGridView(kode, nama, harga, jumlah, subTotal)
            formPenjualan.UpdateTotal(subTotal) ' Update total pada FormPenjualan
            formPenjualan.Show() ' Buka FormPenjualan
            Me.Hide() ' Sembunyikan FormKasir
        End If
    End Sub
End Class