Imports Microsoft.VisualBasic.ApplicationServices

Namespace My
    Partial Friend Class MyApplication
        Private Sub MyApplication_Startup(sender As Object, e As StartupEventArgs) Handles Me.Startup
            ' إنشاء وعرض نموذج الدخول
            Dim loginForm As New LoginForm()

            ' عرض النموذج كنموذج حوار
            If loginForm.ShowDialog() = DialogResult.OK Then
                ' إذا نجح الدخول، افتح النموذج الرئيسي

            Else
                ' إذا فشل الدخول، أغلق التطبيق
                e.Cancel = True
            End If
        End Sub
    End Class
End Namespace