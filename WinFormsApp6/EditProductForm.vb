Imports System.Data.OleDb
Imports System.IO
Imports System.Drawing
Public Class EditProductForm
    Public Property OriginalName As String

    Private ConnectionString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Application.StartupPath & "\Market1.accdb"

    Private Sub EditProductForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim query As String = "SELECT * FROM Products WHERE Name = @Name"

        Using con As New OleDbConnection(ConnectionString)
            Using cmd As New OleDbCommand(query, con)
                cmd.Parameters.AddWithValue("@Name", OriginalName)

                Try
                    con.Open()
                    Dim reader = cmd.ExecuteReader()

                    If reader.Read() Then
                        txtName.Text = reader("Name").ToString()
                        txtPrice.Text = reader("Price").ToString()
                        descriptionTextBox.Text = reader("Description").ToString()

                        LoadCategories()

                        cmbCategory.SelectedItem = reader("Category").ToString()

                        If Not String.IsNullOrEmpty(reader("ImagePath").ToString()) Then
                            If File.Exists(reader("ImagePath").ToString()) Then
                                PictureBox.Image = Image.FromFile(reader("ImagePath").ToString())
                                btnBrowseImage.Tag = reader("ImagePath").ToString()
                            End If
                        End If
                    End If
                Catch ex As Exception
                    MessageBox.Show("Error loading product data: " & ex.Message)
                End Try
            End Using
        End Using
    End Sub

    Private Sub LoadCategories()
        cmbCategory.Items.Clear()
        Dim query As String = "SELECT DISTINCT Category FROM Products"

        Using con As New OleDbConnection(ConnectionString)
            Using cmd As New OleDbCommand(query, con)
                Try
                    con.Open()
                    Dim reader = cmd.ExecuteReader()
                    While reader.Read()
                        cmbCategory.Items.Add(reader("Category").ToString())
                    End While
                Catch ex As Exception
                    MessageBox.Show("Error loading categories: " & ex.Message)
                End Try
            End Using
        End Using
    End Sub

    Private Sub btnBrowseImage_Click(sender As Object, e As EventArgs) Handles btnBrowseImage.Click
        Dim openFileDialog As New OpenFileDialog()
        openFileDialog.Filter = "ملفات الصور|*.jpg;*.jpeg;*.png;*.bmp"

        If openFileDialog.ShowDialog() = DialogResult.OK Then
            PictureBox.Image = Image.FromFile(openFileDialog.FileName)
            btnBrowseImage.Tag = openFileDialog.FileName
        End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        If String.IsNullOrWhiteSpace(txtName.Text) OrElse
       Not Decimal.TryParse(txtPrice.Text, Nothing) OrElse
       cmbCategory.SelectedItem Is Nothing Then
            MessageBox.Show("Please enter all data correctly")
            Return
        End If

        If txtName.Text <> OriginalName Then
            Using con As New OleDbConnection(ConnectionString)
                Try
                    con.Open()
                    Dim checkQuery As String = "SELECT COUNT(*) FROM Products WHERE Name = @Name"

                    Using cmdCheck As New OleDbCommand(checkQuery, con)
                        cmdCheck.Parameters.AddWithValue("@Name", txtName.Text)
                        Dim exists As Integer = CInt(cmdCheck.ExecuteScalar())

                        If exists > 0 Then
                            MessageBox.Show("The product name already exists, please choose another name")
                            Return
                        End If
                    End Using
                Catch ex As Exception
                    MessageBox.Show("An error occurred while verifying the product name: " & ex.Message)
                    Return
                End Try
            End Using
        End If

        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub
End Class