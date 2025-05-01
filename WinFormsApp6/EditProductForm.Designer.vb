<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EditProductForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EditProductForm))
        txtName = New TextBox()
        txtPrice = New TextBox()
        descriptionTextBox = New TextBox()
        cmbCategory = New ComboBox()
        PictureBox = New PictureBox()
        btnBrowseImage = New Button()
        btnCancel = New Button()
        btnSave = New Button()
        CType(PictureBox, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' txtName
        ' 
        txtName.Anchor = AnchorStyles.None
        txtName.BackColor = SystemColors.ScrollBar
        txtName.Font = New Font("Segoe UI Semibold", 12.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        txtName.Location = New Point(487, 116)
        txtName.Multiline = True
        txtName.Name = "txtName"
        txtName.Size = New Size(189, 38)
        txtName.TabIndex = 0
        txtName.Text = "Name "
        ' 
        ' txtPrice
        ' 
        txtPrice.Anchor = AnchorStyles.None
        txtPrice.BackColor = SystemColors.ScrollBar
        txtPrice.Font = New Font("Segoe UI Semibold", 12.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        txtPrice.Location = New Point(487, 170)
        txtPrice.Multiline = True
        txtPrice.Name = "txtPrice"
        txtPrice.Size = New Size(189, 37)
        txtPrice.TabIndex = 1
        txtPrice.Text = "Price"
        ' 
        ' descriptionTextBox
        ' 
        descriptionTextBox.Anchor = AnchorStyles.None
        descriptionTextBox.BackColor = SystemColors.ScrollBar
        descriptionTextBox.Font = New Font("Segoe UI Semibold", 12.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        descriptionTextBox.Location = New Point(487, 224)
        descriptionTextBox.Multiline = True
        descriptionTextBox.Name = "descriptionTextBox"
        descriptionTextBox.Size = New Size(189, 38)
        descriptionTextBox.TabIndex = 2
        descriptionTextBox.Text = "description"
        ' 
        ' cmbCategory
        ' 
        cmbCategory.Anchor = AnchorStyles.None
        cmbCategory.BackColor = SystemColors.ScrollBar
        cmbCategory.Font = New Font("Segoe UI Semibold", 12.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        cmbCategory.FormattingEnabled = True
        cmbCategory.Location = New Point(487, 274)
        cmbCategory.Name = "cmbCategory"
        cmbCategory.Size = New Size(189, 36)
        cmbCategory.TabIndex = 3
        cmbCategory.Text = "Category"
        ' 
        ' PictureBox
        ' 
        PictureBox.Anchor = AnchorStyles.None
        PictureBox.BackColor = SystemColors.ScrollBar
        PictureBox.Location = New Point(87, 120)
        PictureBox.Name = "PictureBox"
        PictureBox.Size = New Size(157, 138)
        PictureBox.TabIndex = 4
        PictureBox.TabStop = False
        ' 
        ' btnBrowseImage
        ' 
        btnBrowseImage.Anchor = AnchorStyles.None
        btnBrowseImage.BackColor = SystemColors.ScrollBar
        btnBrowseImage.Location = New Point(87, 285)
        btnBrowseImage.Name = "btnBrowseImage"
        btnBrowseImage.Size = New Size(157, 29)
        btnBrowseImage.TabIndex = 5
        btnBrowseImage.Text = "BrowseImage"
        btnBrowseImage.UseVisualStyleBackColor = False
        ' 
        ' btnCancel
        ' 
        btnCancel.Anchor = AnchorStyles.None
        btnCancel.BackColor = SystemColors.ScrollBar
        btnCancel.Font = New Font("Segoe UI Semibold", 12.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnCancel.Location = New Point(487, 335)
        btnCancel.Name = "btnCancel"
        btnCancel.Size = New Size(94, 39)
        btnCancel.TabIndex = 6
        btnCancel.Text = "Cancel"
        btnCancel.UseVisualStyleBackColor = False
        ' 
        ' btnSave
        ' 
        btnSave.Anchor = AnchorStyles.None
        btnSave.BackColor = SystemColors.ScrollBar
        btnSave.Font = New Font("Segoe UI Semibold", 12.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnSave.Location = New Point(587, 335)
        btnSave.Name = "btnSave"
        btnSave.Size = New Size(94, 39)
        btnSave.TabIndex = 7
        btnSave.Text = "Save"
        btnSave.UseVisualStyleBackColor = False
        ' 
        ' EditProductForm
        ' 
        AutoScaleDimensions = New SizeF(8.0F, 20.0F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.ActiveCaptionText
        BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), Image)
        BackgroundImageLayout = ImageLayout.Stretch
        ClientSize = New Size(800, 450)
        Controls.Add(btnSave)
        Controls.Add(btnCancel)
        Controls.Add(btnBrowseImage)
        Controls.Add(PictureBox)
        Controls.Add(cmbCategory)
        Controls.Add(descriptionTextBox)
        Controls.Add(txtPrice)
        Controls.Add(txtName)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Name = "EditProductForm"
        Text = "Edit Product"
        CType(PictureBox, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents txtName As TextBox
    Friend WithEvents txtPrice As TextBox
    Friend WithEvents descriptionTextBox As TextBox
    Friend WithEvents cmbCategory As ComboBox
    Friend WithEvents PictureBox As PictureBox
    Friend WithEvents btnBrowseImage As Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents btnSave As Button
End Class
