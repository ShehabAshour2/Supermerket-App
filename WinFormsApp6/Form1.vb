



Imports System.Data.OleDb
Imports System.Linq
Imports System.IO
Imports Windows.Win32.System



Public Class Merket
    ' 
    Public Property CurrentUserRole As String

    Private Sub Market_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        LoadCategories()

    End Sub
    Public Class Product
        Public Property Name As String
        Public Property Price As Decimal
        Public Property Category As String
        Public Property Description As String
        Public Property Image As String
    End Class


    Dim connectionString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Application.StartupPath & "\Market1.accdb"



    Dim con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Application.StartupPath & "\Market1.accdb")
    Dim dbPath = Application.StartupPath & "\Market1.accdb"




    Private Sub btnAddProduct_Click(sender As Object, e As EventArgs) Handles btnAddProduct.Click

        Dim addForm As New AddProductForm()


        If addForm.ShowDialog() = DialogResult.OK Then


            If addForm.txtProductName Is Nothing OrElse
           addForm.txtPrice Is Nothing OrElse
           addForm.cmbCategory Is Nothing OrElse
           addForm.btnBrowseImage Is Nothing Then

                MessageBox.Show("An error occurred while reading product data from the form.")
                Exit Sub
            End If


            If addForm.cmbCategory.SelectedItem Is Nothing Then
                MessageBox.Show("Please select a category for the product.")
                Exit Sub
            End If


            If addForm.btnBrowseImage.Tag Is Nothing Then
                MessageBox.Show("Please select an image for the product.")
                Exit Sub
            End If
            If addForm.ShowDialog() = DialogResult.OK Then

                LoadCategories()
            End If

            Dim dt As New DataTable()
            dt.Columns.Add("Name", GetType(String))
            dt.Columns.Add("Price", GetType(Decimal))
            dt.Columns.Add("Category", GetType(String))
            dt.Columns.Add("ImagePath", GetType(String))
            dt.Columns.Add("description", GetType(String))


            Dim newRow As DataRow = dt.NewRow()
            newRow("Name") = addForm.txtProductName.Text
            newRow("Price") = Decimal.Parse(addForm.txtPrice.Text)
            newRow("Category") = addForm.cmbCategory.SelectedItem.ToString()
            newRow("ImagePath") = addForm.btnBrowseImage.Tag.ToString()
            newRow("description") = addForm.descriptionTextBox.Text

            dt.Rows.Add(newRow)


            AddProductToDisplay(newRow)
        End If
    End Sub






    Private Sub AddProductToDisplay(row As DataRow)
        Dim panel As New Panel()
        panel.Width = 250
        panel.Height = 250
        panel.BorderStyle = BorderStyle.FixedSingle
        panel.Margin = New Padding(8)
        panel.Tag = row("Name").ToString()


        Dim pic As New PictureBox()
        pic.SizeMode = PictureBoxSizeMode.Zoom
        pic.Width = 130
        pic.Height = 100
        pic.Top = 8
        pic.Left = 10

        If System.IO.File.Exists(row("ImagePath").ToString()) Then
            pic.Image = Image.FromFile(row("ImagePath").ToString())
        End If


        Dim lblName As New Label()
        lblName.Text = row("Name").ToString()
        lblName.Font = New Font("Segoe UI", 11.5, FontStyle.Bold)
        lblName.AutoSize = True
        lblName.TextAlign = ContentAlignment.MiddleCenter
        lblName.Width = 110
        lblName.Top = pic.Bottom + 5
        lblName.Left = 10


        Dim lblPrice As New Label()
        lblPrice.Text = row("Price").ToString() & " EGP"
        lblPrice.Font = New Font("Segoe UI", 10, FontStyle.Bold)
        lblPrice.AutoSize = False
        lblPrice.TextAlign = ContentAlignment.MiddleCenter
        lblPrice.Width = 110
        lblPrice.Top = lblName.Bottom + 2
        lblPrice.Left = 10

        Dim lblCategory As New Label()
        lblCategory.Text = row("Category").ToString()
        lblCategory.Font = New Font("Segoe UI", 10, FontStyle.Bold)

        lblCategory.AutoSize = True
        lblCategory.TextAlign = ContentAlignment.MiddleCenter
        lblCategory.Width = 110
        lblCategory.Top = lblPrice.Bottom + 2
        lblCategory.Left = 10
        Dim lbldescription As New Label()
        lbldescription.Text = row("description").ToString()
        lbldescription.Font = New Font("Segoe UI", 11.5, FontStyle.Bold)
        lbldescription.AutoSize = True
        lbldescription.TextAlign = ContentAlignment.MiddleCenter
        lbldescription.Width = 110
        lbldescription.Top = pic.Bottom + 5
        lbldescription.Left = 10


        panel.Controls.Add(pic)
        panel.Controls.Add(lblName)
        panel.Controls.Add(lblPrice)
        panel.Controls.Add(lblCategory)
        panel.Controls.Add(lbldescription)

        FlowLayoutPanel1.Controls.Add(panel)


        AddHandler panel.Click, AddressOf Panel_Click
        AddHandler pic.Click, AddressOf Panel_Click
        AddHandler lblName.Click, AddressOf Panel_Click
        AddHandler lblPrice.Click, AddressOf Panel_Click
        AddHandler lblCategory.Click, AddressOf Panel_Click
        AddHandler lbldescription.Click, AddressOf Panel_Click

    End Sub



    Private selectedPanel As Panel = Nothing

    Private Sub Panel_Click(sender As Object, e As EventArgs)
        Dim clickedControl As Control = CType(sender, Control)
        Dim panel As Panel


        If TypeOf clickedControl Is Panel Then
            panel = CType(clickedControl, Panel)
        Else

            panel = CType(clickedControl.Parent, Panel)
        End If


        If selectedPanel IsNot Nothing Then
            selectedPanel.BorderStyle = BorderStyle.FixedSingle
        End If


        selectedPanel = panel
        selectedPanel.BorderStyle = BorderStyle.Fixed3D
    End Sub

    Private Sub DisplayProducts(category As String)




        Dim query = "SELECT Category, Name, Price, ImagePath, description FROM Products WHERE Category = @Category ORDER BY Name"
        Dim dt As New DataTable()

        Using con As New OleDbConnection(connectionString)
            Using cmd As New OleDbCommand(query, con)
                cmd.Parameters.AddWithValue("@Category", category)
                con.Open()
                dt.Load(cmd.ExecuteReader())
            End Using
        End Using

        For Each row As DataRow In dt.Rows

            Dim productPanel As New Panel()
            productPanel.Tag = row("Name").ToString()
            productPanel.Size = New Size(250, 250)
            productPanel.BackColor = Color.White
            productPanel.BorderStyle = BorderStyle.FixedSingle
            productPanel.Margin = New Padding(5)





            Dim pic As New PictureBox()
            pic.Size = New Size(100, 60)
            pic.SizeMode = PictureBoxSizeMode.Zoom
            pic.Location = New Point(75, 5)


            Dim imagePathFromDB As String = row("ImagePath").ToString()

            If Not String.IsNullOrEmpty(imagePathFromDB) Then
                Dim fullPath As String = Path.Combine(Application.StartupPath, imagePathFromDB)

                If File.Exists(fullPath) Then
                    Try
                        pic.Image = Image.FromFile(fullPath)
                    Catch ex As Exception
                        MessageBox.Show("Error while loading the image: " & ex.Message)
                    End Try
                Else
                    MessageBox.Show("Image path does not exist: " & fullPath)
                End If
            Else
                MessageBox.Show("No path specified for the image.")
            End If




            Dim lblName As New Label()
            lblName.Text = row("Name").ToString()
            lblName.Location = New Point(10, 70)
            lblName.AutoSize = True
            lblName.Font = New Font("Arial", 10, FontStyle.Bold)


            Dim lblPrice As New Label()
            lblPrice.Text = row("Price").ToString() & " EGP"
            lblPrice.Location = New Point(10, 95)
            lblPrice.AutoSize = True
            lblPrice.Font = New Font("Arial", 9)

            Dim lbldescription As New Label()
            lbldescription.Text = row("description").ToString()
            lbldescription.Location = New Point(10, 120)
            lbldescription.Size = New Size(230, 60)
            lbldescription.AutoSize = False
            lbldescription.MaximumSize = New Size(230, 60)
            lbldescription.Font = New Font("Arial", 10, FontStyle.Bold)
            lbldescription.ForeColor = Color.Gray
            lbldescription.TextAlign = ContentAlignment.TopLeft
            lbldescription.AutoEllipsis = True


            productPanel.Controls.Add(pic)
            productPanel.Controls.Add(lblName)
            productPanel.Controls.Add(lblPrice)
            productPanel.Controls.Add(lbldescription)

            FlowLayoutPanel1.Controls.Add(productPanel)


        Next

    End Sub



    Private Sub LoadProducts()
        Dim connectionString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Application.StartupPath & "\Market1.accdb;Persist Security Info=False;"

        Dim connection As New OleDbConnection(connectionString)

        Try
            connection.Open()
            Dim command As New OleDbCommand("SELECT * FROM Products", connection)
            Dim reader As OleDbDataReader = command.ExecuteReader()



            While reader.Read()
                Dim pnl As New Panel()
                pnl.Size = New Size(180, 270)
                pnl.BackColor = Color.LightGray
                pnl.Margin = New Padding(10)

                Dim pic As New PictureBox()
                pic.Size = New Size(160, 120)
                pic.Location = New Point(10, 10)
                pic.SizeMode = PictureBoxSizeMode.Zoom
                pic.ImageLocation = reader("ImagePath").ToString()
                pic.Tag = reader("ImagePath").ToString()
                pic.Name = "ImagePath"


                pnl.Controls.Add(pic)

                Dim lblName As New Label()
                lblName.Text = reader("Name").ToString()
                lblName.Font = New Font("Segoe UI", 11, FontStyle.Bold)
                lblName.TextAlign = ContentAlignment.MiddleCenter
                lblName.Size = New Size(160, 25)
                lblName.Location = New Point(10, 140)
                lblName.Name = "Name"

                pnl.Controls.Add(lblName)


                Dim lblPrice As New Label()
                lblPrice.Text = "Price: " & reader("Price").ToString() & " EGP"
                lblPrice.Font = New Font("Segoe UI", 10, FontStyle.Bold)
                lblPrice.TextAlign = ContentAlignment.MiddleCenter
                lblPrice.Size = New Size(160, 20)
                lblPrice.Location = New Point(10, 170)
                lblPrice.Name = "Price"

                pnl.Controls.Add(lblPrice)


                Dim lblCategory As New Label()
                lblCategory.Text = reader("Category").ToString()
                lblCategory.Font = New Font("Segoe UI", 10, FontStyle.Bold)
                lblCategory.TextAlign = ContentAlignment.MiddleCenter
                lblCategory.Size = New Size(160, 20)
                lblCategory.Name = "Category"

                lblCategory.Location = New Point(10, 200)
                pnl.Controls.Add(lblCategory)




                Dim lbldescription As New Label()
                lbldescription.Text = reader("description").ToString()
                lbldescription.Font = New Font("Segoe UI", 8, FontStyle.Bold)
                lbldescription.TextAlign = ContentAlignment.MiddleCenter
                lbldescription.Size = New Size(160, 20)
                lbldescription.Location = New Point(15, 220)
                lbldescription.Name = "description"

                pnl.Controls.Add(lbldescription)

                FlowLayoutPanel1.Controls.Add(pnl)
            End While
        Catch ex As Exception
            MessageBox.Show("Error loading products: " & ex.Message)
        Finally
            connection.Close()
        End Try
    End Sub









    Private Sub btnFind_Click(sender As Object, e As EventArgs) Handles btnFind.Click
        Dim nameFilter As String = SearchName.Text.Trim()
        Dim categoryFilter As String = cmbCat.Text.Trim()

        FlowLayoutPanel1.Controls.Clear()

        Dim query As String = "SELECT * FROM Products WHERE 1=1"
        Dim parameters As New List(Of OleDbParameter)()

        If Not String.IsNullOrEmpty(nameFilter) Then
            query &= " AND Name LIKE ?"
            parameters.Add(New OleDbParameter("Name", "%" & nameFilter & "%"))
        End If

        If Not String.IsNullOrEmpty(categoryFilter) Then
            query &= " AND Category = ?"
            parameters.Add(New OleDbParameter("Category", categoryFilter))

        End If

        Dim dt As New DataTable()

        Using con As New OleDbConnection(connectionString)
            Using cmd As New OleDbCommand(query, con)

                For Each p In parameters
                    cmd.Parameters.Add(p)
                Next

                con.Open()
                dt.Load(cmd.ExecuteReader())
            End Using
        End Using

        For Each row As DataRow In dt.Rows
            AddProductToDisplay(row)
        Next
    End Sub

    Private Sub LoadCategories()
        Dim query As String = "SELECT DISTINCT Category FROM Products"

        Using con As New OleDbConnection(connectionString)
            Using cmd As New OleDbCommand(query, con)
                Try
                    con.Open()
                    Dim reader As OleDbDataReader = cmd.ExecuteReader()
                    cmbCat.Items.Clear()

                    While reader.Read()
                        cmbCat.Items.Add(reader("Category").ToString())
                    End While
                Catch ex As Exception
                    MessageBox.Show("Error while loading categories: " & ex.Message)
                End Try
            End Using
        End Using
    End Sub

    Private Sub cmbCat_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCat.SelectedIndexChanged




    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If selectedPanel Is Nothing Then
            MessageBox.Show("Select a product firstاً.")
            Return
        End If


        Dim productName As String = selectedPanel.Tag.ToString()
        MessageBox.Show("The selected product: " & productName)


        Using conn As New OleDb.OleDbConnection(connectionString)
            Try
                conn.Open()
                Dim cmd As New OleDb.OleDbCommand("DELETE FROM Products WHERE Name = ?", conn)
                cmd.Parameters.AddWithValue("?", productName)
                cmd.ExecuteNonQuery()
                MessageBox.Show("The product has been deleted from the database.")
            Catch ex As Exception
                MessageBox.Show("An error occurred while deleting the product: " & ex.Message)
            End Try
        End Using


        FlowLayoutPanel1.Controls.Remove(selectedPanel)
        selectedPanel = Nothing

        MessageBox.Show("Product successfully deleted from the interface.")
    End Sub

    Private Sub btnShowAll_Click(sender As Object, e As EventArgs) Handles btnShowAll.Click
        FlowLayoutPanel1.Controls.Clear()
        LoadProducts()
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If selectedPanel Is Nothing Then
            MessageBox.Show("Please select a product first by clicking on it")
            Return
        End If

        Dim productName As String = selectedPanel.Tag.ToString()


        Dim editForm As New EditProductForm()
        editForm.OriginalName = productName

        If editForm.ShowDialog() = DialogResult.OK Then

            Dim updateQuery As String = "UPDATE Products SET 
                                   Name = @NewName, 
                                   Price = @Price, 
                                   Category = @Category, 
                                   Description = @Description, 
                                   ImagePath = @ImagePath 
                                   WHERE Name = @OldName"

            Using con As New OleDbConnection(connectionString)
                Using cmd As New OleDbCommand(updateQuery, con)

                    cmd.Parameters.AddWithValue("@NewName", editForm.txtName.Text)
                    cmd.Parameters.AddWithValue("@Price", Decimal.Parse(editForm.txtPrice.Text))
                    cmd.Parameters.AddWithValue("@Category", editForm.cmbCategory.SelectedItem.ToString())
                    cmd.Parameters.AddWithValue("@Description", editForm.descriptionTextBox.Text)
                    cmd.Parameters.AddWithValue("@ImagePath", If(editForm.btnBrowseImage.Tag IsNot Nothing,
                                                         editForm.btnBrowseImage.Tag.ToString(), ""))
                    cmd.Parameters.AddWithValue("@OldName", productName)

                    Try
                        con.Open()
                        Dim rowsAffected = cmd.ExecuteNonQuery()

                        If rowsAffected > 0 Then

                            FlowLayoutPanel1.Controls.Remove(selectedPanel)


                            Dim dt As New DataTable()
                            dt.Columns.Add("Name", GetType(String))
                            dt.Columns.Add("Price", GetType(Decimal))
                            dt.Columns.Add("Category", GetType(String))
                            dt.Columns.Add("ImagePath", GetType(String))
                            dt.Columns.Add("Description", GetType(String))

                            Dim row = dt.NewRow()
                            row("Name") = editForm.txtName.Text
                            row("Price") = Decimal.Parse(editForm.txtPrice.Text)
                            row("Category") = editForm.cmbCategory.SelectedItem.ToString()
                            row("ImagePath") = If(editForm.btnBrowseImage.Tag IsNot Nothing,
                                            editForm.btnBrowseImage.Tag.ToString(), "")
                            row("Description") = editForm.descriptionTextBox.Text
                            dt.Rows.Add(row)


                            AddProductToDisplay(row)

                            MessageBox.Show("Product updated successfully")
                        Else
                            MessageBox.Show("Product not found for update")
                        End If
                    Catch ex As Exception
                        MessageBox.Show("An Error occurred during the update: " & ex.Message)
                    End Try
                End Using
            End Using
        End If
    End Sub

    Private Sub btnSaveChanges_Click(sender As Object, e As EventArgs) Handles btnSaveChanges.Click

        MessageBox.Show("Saved successfully")
    End Sub
End Class












