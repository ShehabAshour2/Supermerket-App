<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AddProductForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AddProductForm))
        txtProductName = New TextBox()
        txtPrice = New TextBox()
        cmbCategory = New ComboBox()
        pictureBox = New PictureBox()
        btnBrowseImage = New Button()
        btnSave = New Button()
        descriptionTextBox = New TextBox()
        btnAddCategory = New Button()
        CType(pictureBox, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' txtProductName
        ' 
        txtProductName.Anchor = AnchorStyles.None
        txtProductName.BackColor = SystemColors.ScrollBar
        txtProductName.Font = New Font("Segoe UI", 12.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtProductName.ImeMode = ImeMode.NoControl
        txtProductName.Location = New Point(322, 110)
        txtProductName.Multiline = True
        txtProductName.Name = "txtProductName"
        txtProductName.Size = New Size(214, 41)
        txtProductName.TabIndex = 0
        txtProductName.Text = "Name "
        ' 
        ' txtPrice
        ' 
        txtPrice.Anchor = AnchorStyles.None
        txtPrice.BackColor = SystemColors.ScrollBar
        txtPrice.Font = New Font("Segoe UI", 12.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtPrice.Location = New Point(322, 186)
        txtPrice.Multiline = True
        txtPrice.Name = "txtPrice"
        txtPrice.Size = New Size(214, 38)
        txtPrice.TabIndex = 1
        txtPrice.Text = "Price"
        ' 
        ' cmbCategory
        ' 
        cmbCategory.Anchor = AnchorStyles.None
        cmbCategory.BackColor = SystemColors.ScrollBar
        cmbCategory.Font = New Font("Segoe UI", 12.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        cmbCategory.FormattingEnabled = True
        cmbCategory.Location = New Point(322, 314)
        cmbCategory.Name = "cmbCategory"
        cmbCategory.Size = New Size(214, 36)
        cmbCategory.TabIndex = 2
        cmbCategory.Text = "Category"
        ' 
        ' pictureBox
        ' 
        pictureBox.Anchor = AnchorStyles.None
        pictureBox.BackColor = SystemColors.ScrollBar
        pictureBox.BackgroundImageLayout = ImageLayout.Zoom
        pictureBox.Location = New Point(81, 117)
        pictureBox.Name = "pictureBox"
        pictureBox.Size = New Size(187, 174)
        pictureBox.TabIndex = 3
        pictureBox.TabStop = False
        ' 
        ' btnBrowseImage
        ' 
        btnBrowseImage.Anchor = AnchorStyles.None
        btnBrowseImage.BackColor = SystemColors.ScrollBar
        btnBrowseImage.Location = New Point(102, 322)
        btnBrowseImage.Name = "btnBrowseImage"
        btnBrowseImage.Size = New Size(144, 29)
        btnBrowseImage.TabIndex = 4
        btnBrowseImage.Text = "btnBrowseImage"
        btnBrowseImage.UseVisualStyleBackColor = False
        ' 
        ' btnSave
        ' 
        btnSave.Anchor = AnchorStyles.None
        btnSave.BackColor = SystemColors.ScrollBar
        btnSave.Font = New Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnSave.Location = New Point(358, 383)
        btnSave.Name = "btnSave"
        btnSave.Size = New Size(117, 32)
        btnSave.TabIndex = 5
        btnSave.Text = "Save"
        btnSave.UseVisualStyleBackColor = False
        ' 
        ' descriptionTextBox
        ' 
        descriptionTextBox.Anchor = AnchorStyles.None
        descriptionTextBox.BackColor = SystemColors.ScrollBar
        descriptionTextBox.Font = New Font("Segoe UI", 12.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        descriptionTextBox.ImeMode = ImeMode.NoControl
        descriptionTextBox.Location = New Point(322, 243)
        descriptionTextBox.Multiline = True
        descriptionTextBox.Name = "descriptionTextBox"
        descriptionTextBox.ScrollBars = ScrollBars.Vertical
        descriptionTextBox.Size = New Size(214, 41)
        descriptionTextBox.TabIndex = 6
        descriptionTextBox.Text = "description"
        ' 
        ' btnAddCategory
        ' 
        btnAddCategory.Anchor = AnchorStyles.None
        btnAddCategory.BackColor = SystemColors.ScrollBar
        btnAddCategory.Font = New Font("Segoe UI Semibold", 10.0F, FontStyle.Bold)
        btnAddCategory.Location = New Point(565, 315)
        btnAddCategory.Name = "btnAddCategory"
        btnAddCategory.Size = New Size(143, 36)
        btnAddCategory.TabIndex = 7
        btnAddCategory.Text = "New Category"
        btnAddCategory.UseVisualStyleBackColor = False
        ' 
        ' AddProductForm
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.ActiveCaptionText
        BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), Image)
        BackgroundImageLayout = ImageLayout.Stretch
        ClientSize = New Size(794, 496)
        Controls.Add(btnAddCategory)
        Controls.Add(descriptionTextBox)
        Controls.Add(btnSave)
        Controls.Add(btnBrowseImage)
        Controls.Add(pictureBox)
        Controls.Add(cmbCategory)
        Controls.Add(txtPrice)
        Controls.Add(txtProductName)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Name = "AddProductForm"
        Text = "Add Product"
        CType(pictureBox, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents txtProductName As TextBox
    Friend WithEvents txtPrice As TextBox
    Friend WithEvents cmbCategory As ComboBox
    Friend WithEvents pictureBox As PictureBox
    Friend WithEvents btnBrowseImage As Button
    Friend WithEvents btnSave As Button
    Friend WithEvents descriptionTextBox As TextBox
    Friend WithEvents btnAddCategory As Button
End Class
