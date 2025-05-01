Imports System.Data.OleDb
Imports System.IO

Public Class AddProductForm
    Private ReadOnly ConnectionString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Application.StartupPath & "\Market1.accdb"

    Private Sub btnBrowseImage_Click(sender As Object, e As EventArgs) Handles btnBrowseImage.Click
        Dim openFileDialog As New OpenFileDialog()
        openFileDialog.Title = "Select the product image"
        openFileDialog.Filter = "ملفات الصور|*.jpg;*.jpeg;*.png;*.bmp"

        If openFileDialog.ShowDialog() = DialogResult.OK Then
            Try
                Dim imagePath As String = openFileDialog.FileName
                pictureBox.Image = Image.FromFile(imagePath)
                btnBrowseImage.Tag = imagePath
            Catch ex As Exception
                MessageBox.Show("Error in loading the image: " & ex.Message)
            End Try
        End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try

            If String.IsNullOrWhiteSpace(txtProductName.Text) Then
                MessageBox.Show("Product name must be entered")
                Return
            End If

            If Not Decimal.TryParse(txtPrice.Text, Nothing) OrElse Decimal.Parse(txtPrice.Text) <= 0 Then
                MessageBox.Show("A valid price greater than zero must be entered")
                Return
            End If

            If cmbCategory.SelectedIndex = -1 Then
                MessageBox.Show("A category for the product must be selected")
                Return
            End If


            Dim imagePath As String = ""
            If btnBrowseImage.Tag IsNot Nothing Then
                imagePath = btnBrowseImage.Tag.ToString()
            End If


            Using con As New OleDbConnection(ConnectionString)
                con.Open()
                Dim query As String = "INSERT INTO Products (Name, Price, Category, ImagePath, [Description]) " &
                                 "VALUES (@Name, @Price, @Category, @ImagePath, @Desc)"

                Using cmd As New OleDbCommand(query, con)

                    cmd.Parameters.Add("@Name", OleDbType.VarChar).Value = txtProductName.Text.Trim()
                    cmd.Parameters.Add("@Price", OleDbType.Currency).Value = Decimal.Parse(txtPrice.Text)
                    cmd.Parameters.Add("@Category", OleDbType.VarChar).Value = cmbCategory.SelectedItem.ToString()
                    cmd.Parameters.Add("@ImagePath", OleDbType.VarChar).Value = imagePath


                    Dim description As String = ""
                    If descriptionTextBox IsNot Nothing AndAlso descriptionTextBox.Text IsNot Nothing Then
                        description = descriptionTextBox.Text.Trim()
                    End If
                    cmd.Parameters.Add("@Desc", OleDbType.VarChar).Value = description


                    Dim rowsAffected As Integer = cmd.ExecuteNonQuery()

                    If rowsAffected > 0 Then
                        MessageBox.Show("Product saved successfully")

                    Else
                        MessageBox.Show("Product not saved")
                    End If
                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show("An error occurred while saving: " & ex.ToString(), "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub AddProductForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            LoadCategories()

            If cmbCategory.Items.Count = 0 Then
                cmbCategory.Items.Add("General")
            End If
        Catch ex As Exception
            MessageBox.Show("Error while loading categories: " & ex.Message)
        End Try
    End Sub

    Private Sub LoadCategories()
        cmbCategory.Items.Clear()

        Try
            Using con As New OleDbConnection(ConnectionString)
                Dim query As String = "SELECT DISTINCT Category FROM Products WHERE Category IS NOT NULL"
                Using cmd As New OleDbCommand(query, con)
                    con.Open()
                    Using reader As OleDbDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            If Not reader.IsDBNull(reader.GetOrdinal("Category")) Then
                                cmbCategory.Items.Add(reader("Category").ToString())
                            End If
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            Throw New Exception("Failed to load categories: " & ex.Message)
        End Try
    End Sub

    Private Sub btnAddCategory_Click(sender As Object, e As EventArgs) Handles btnAddCategory.Click
        Dim newCategory As String = InputBox("Enter the new category name:")

        If Not String.IsNullOrWhiteSpace(newCategory) Then
            If Not cmbCategory.Items.Contains(newCategory) Then
                cmbCategory.Items.Add(newCategory)
                cmbCategory.SelectedItem = newCategory
                MessageBox.Show("New category added successfully.")
            Else
                MessageBox.Show("This category already exists.")
            End If
        Else
            MessageBox.Show("Please enter the category name.")
        End If
    End Sub
End Class
