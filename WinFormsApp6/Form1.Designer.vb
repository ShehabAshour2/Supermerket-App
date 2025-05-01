<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Merket
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Merket))
        FlowLayoutPanel1 = New FlowLayoutPanel()
        btnAddProduct = New Button()
        btnSaveChanges = New Button()
        SearchName = New TextBox()
        cmbCat = New ComboBox()
        btnFind = New Button()
        btnDelete = New Button()
        btnShowAll = New Button()
        btnEdit = New Button()
        SuspendLayout()
        ' 
        ' FlowLayoutPanel1
        ' 
        FlowLayoutPanel1.AutoScroll = True
        FlowLayoutPanel1.Location = New Point(92, 294)
        FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        FlowLayoutPanel1.Size = New Size(1627, 723)
        FlowLayoutPanel1.TabIndex = 6
        ' 
        ' btnAddProduct
        ' 
        btnAddProduct.AutoSize = True
        btnAddProduct.BackColor = SystemColors.ActiveBorder
        btnAddProduct.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnAddProduct.Location = New Point(1298, 117)
        btnAddProduct.Name = "btnAddProduct"
        btnAddProduct.Size = New Size(176, 38)
        btnAddProduct.TabIndex = 7
        btnAddProduct.Text = "Add Product"
        btnAddProduct.UseVisualStyleBackColor = False
        ' 
        ' btnSaveChanges
        ' 
        btnSaveChanges.AutoSize = True
        btnSaveChanges.BackColor = SystemColors.ActiveBorder
        btnSaveChanges.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnSaveChanges.Location = New Point(1298, 185)
        btnSaveChanges.Name = "btnSaveChanges"
        btnSaveChanges.Size = New Size(108, 38)
        btnSaveChanges.TabIndex = 8
        btnSaveChanges.Text = "Save "
        btnSaveChanges.UseVisualStyleBackColor = False
        ' 
        ' SearchName
        ' 
        SearchName.BackColor = SystemColors.ScrollBar
        SearchName.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        SearchName.Location = New Point(1092, 47)
        SearchName.Multiline = True
        SearchName.Name = "SearchName"
        SearchName.Size = New Size(266, 40)
        SearchName.TabIndex = 10
        ' 
        ' cmbCat
        ' 
        cmbCat.BackColor = SystemColors.ScrollBar
        cmbCat.FormattingEnabled = True
        cmbCat.ItemHeight = 20
        cmbCat.Location = New Point(1375, 59)
        cmbCat.MaxDropDownItems = 10
        cmbCat.Name = "cmbCat"
        cmbCat.Size = New Size(182, 28)
        cmbCat.Sorted = True
        cmbCat.TabIndex = 11
        cmbCat.TabStop = False
        ' 
        ' btnFind
        ' 
        btnFind.AutoSize = True
        btnFind.BackColor = SystemColors.ActiveBorder
        btnFind.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnFind.Location = New Point(1625, 49)
        btnFind.Name = "btnFind"
        btnFind.Size = New Size(94, 40)
        btnFind.TabIndex = 12
        btnFind.Text = "Search"
        btnFind.UseVisualStyleBackColor = False
        ' 
        ' btnDelete
        ' 
        btnDelete.AutoSize = True
        btnDelete.BackColor = SystemColors.ActiveBorder
        btnDelete.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnDelete.Location = New Point(1092, 185)
        btnDelete.Name = "btnDelete"
        btnDelete.Size = New Size(116, 38)
        btnDelete.TabIndex = 13
        btnDelete.Text = "Delete"
        btnDelete.UseVisualStyleBackColor = False
        ' 
        ' btnShowAll
        ' 
        btnShowAll.AutoSize = True
        btnShowAll.BackColor = SystemColors.ActiveBorder
        btnShowAll.Font = New Font("Segoe UI Semibold", 13F, FontStyle.Bold)
        btnShowAll.Location = New Point(1092, 117)
        btnShowAll.Name = "btnShowAll"
        btnShowAll.Size = New Size(116, 40)
        btnShowAll.TabIndex = 14
        btnShowAll.Text = "Show "
        btnShowAll.UseVisualStyleBackColor = False
        ' 
        ' btnEdit
        ' 
        btnEdit.AutoSize = True
        btnEdit.BackColor = SystemColors.ActiveBorder
        btnEdit.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnEdit.Location = New Point(1543, 117)
        btnEdit.Name = "btnEdit"
        btnEdit.Size = New Size(182, 38)
        btnEdit.TabIndex = 15
        btnEdit.Text = "Add Edit Product "
        btnEdit.UseVisualStyleBackColor = False
        ' 
        ' Merket
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), Image)
        BackgroundImageLayout = ImageLayout.Stretch
        ClientSize = New Size(1787, 1055)
        Controls.Add(btnEdit)
        Controls.Add(btnShowAll)
        Controls.Add(btnDelete)
        Controls.Add(btnFind)
        Controls.Add(cmbCat)
        Controls.Add(SearchName)
        Controls.Add(btnSaveChanges)
        Controls.Add(btnAddProduct)
        Controls.Add(FlowLayoutPanel1)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Name = "Merket"
        Text = "Merket "
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
    Friend WithEvents btnAddProduct As Button
    Friend WithEvents btnSaveChanges As Button
    Friend WithEvents SearchName As TextBox
    Friend WithEvents cmbCat As ComboBox
    Friend WithEvents btnFind As Button
    Friend WithEvents btnDelete As Button
    Friend WithEvents btnShowAll As Button
    Friend WithEvents btnEdit As Button

End Class
