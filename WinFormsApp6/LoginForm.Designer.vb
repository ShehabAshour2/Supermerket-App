<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LoginForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(LoginForm))
        txtUsername = New TextBox()
        txtPassword = New TextBox()
        btnExit = New Button()
        btnLogin = New Button()
        SuspendLayout()
        ' 
        ' txtUsername
        ' 
        txtUsername.Anchor = AnchorStyles.None
        txtUsername.Font = New Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        txtUsername.Location = New Point(251, 353)
        txtUsername.Multiline = True
        txtUsername.Name = "txtUsername"
        txtUsername.Size = New Size(179, 38)
        txtUsername.TabIndex = 0
        txtUsername.Text = "Username"
        ' 
        ' txtPassword
        ' 
        txtPassword.Anchor = AnchorStyles.None
        txtPassword.BackColor = SystemColors.Menu
        txtPassword.Font = New Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        txtPassword.Location = New Point(251, 424)
        txtPassword.Multiline = True
        txtPassword.Name = "txtPassword"
        txtPassword.Size = New Size(179, 38)
        txtPassword.TabIndex = 1
        txtPassword.Text = "Password"
        ' 
        ' btnExit
        ' 
        btnExit.Anchor = AnchorStyles.None
        btnExit.BackColor = SystemColors.ActiveBorder
        btnExit.Font = New Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnExit.Location = New Point(464, 424)
        btnExit.Name = "btnExit"
        btnExit.Size = New Size(99, 38)
        btnExit.TabIndex = 2
        btnExit.Text = "Exit"
        btnExit.UseVisualStyleBackColor = False
        ' 
        ' btnLogin
        ' 
        btnLogin.Anchor = AnchorStyles.None
        btnLogin.BackColor = SystemColors.ActiveBorder
        btnLogin.Font = New Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnLogin.Location = New Point(464, 353)
        btnLogin.Name = "btnLogin"
        btnLogin.Size = New Size(99, 38)
        btnLogin.TabIndex = 3
        btnLogin.Text = "Login"
        btnLogin.UseVisualStyleBackColor = False
        ' 
        ' LoginForm
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), Image)
        BackgroundImageLayout = ImageLayout.Stretch
        ClientSize = New Size(817, 571)
        Controls.Add(btnLogin)
        Controls.Add(btnExit)
        Controls.Add(txtPassword)
        Controls.Add(txtUsername)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Name = "LoginForm"
        Text = "LoginForm"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents txtUsername As TextBox
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents btnExit As Button
    Friend WithEvents btnLogin As Button
End Class
