Imports System.Data.OleDb

Public Class LoginForm



    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click

        If txtUsername.Text = "admin" AndAlso txtPassword.Text = "123" Then
            Me.DialogResult = DialogResult.OK
            Me.Close()
        Else
            MessageBox.Show("Incorrect login details")
        End If
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub


End Class

