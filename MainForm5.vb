Imports MySql.Data.MySqlClient


Public Class MainForm5

    Dim myConnectionString = "User Id=root;Host=localhost;Database=loveinc"
    Dim myConn As New MySqlConnection(myConnectionString)

    Private Sub MainForm5_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MainForm1.Hide()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try

            Dim myAdapter As New MySqlDataAdapter("Select * from admin where userName='" & Me.TextBox2.Text & "' AND adminPass ='" & Me.TextBox1.Text & "';", myConn)
            Dim mydatatable As New DataTable
            myAdapter.Fill(mydatatable)

            If mydatatable.Rows.Count = 0 Then
                MessageBox.Show("No user found. Please try again.", "Love Inc")
                TextBox1.Text = ""
                TextBox2.Text = ""
                myConn.Close()

            ElseIf mydatatable.Rows.Count = 1 Then
                TextBox1.Text = ""
                TextBox2.Text = ""
                MainForm4.Show()
                myConn.Close()

            End If

        Catch ex As Exception
            MessageBox.Show("Error:" & ex.Message)
            TextBox1.Text = ""
            TextBox2.Text = ""
            myConn.Close()
        End Try

    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress

        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            Button2.PerformClick()
            e.Handled = True
        End If


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        MainForm1.Show()
        Me.Close()

    End Sub
End Class
