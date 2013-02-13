Imports MySql.Data.MySqlClient

Public Class MainForm4
    Dim myConnectionString = "User Id=root;Host=localhost;Database=loveinc"
    Dim myConn As New MySqlConnection(myConnectionString)
    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub MainForm4_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MainForm5.Hide()
    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click

    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

        Dim volunteerName As String
        volunteerName = TextBox1.Text

        Dim query As String = "SELECT * FROM volunteer WHERE lastName LIKE '" & volunteerName & "%'"
        Dim myAdapter As New MySqlDataAdapter(query, myConn)
        Dim mydatatable As New DataTable
        myAdapter.Fill(mydatatable)

        ListBox4.Items.Clear()
        ListBox1.Items.Clear()

        For x As Integer = 0 To mydatatable.Rows.Count - 1

            ' Label4.Text = Label4.Text & mydatatable.Rows(x).Item("volunteerID") & vbCrLf

            ListBox4.Items.Add(mydatatable.Rows(x).Item("volunteerID"))
            ListBox1.Items.Add(mydatatable.Rows(x).Item("firstName") & " " & mydatatable.Rows(x).Item("lastName"))


        Next

    End Sub

    Private Sub MenuStrip2_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles MenuStrip2.ItemClicked

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

        'Dim volunteerName As String
        'volunteerName = TextBox1.Text

        Dim query As String = "SELECT * FROM volunteer WHERE lastName='Velez'"
        Dim myAdapter As New MySqlDataAdapter(query, myConn)
        Dim mydatatable As New DataTable
        myAdapter.Fill(mydatatable)

        ListBox4.Items.Clear()
        ListBox1.Items.Clear()

        For x As Integer = 0 To mydatatable.Rows.Count - 1

            Label4.Text = Label4.Text & mydatatable.Rows(x).Item("volunteerID") & vbCrLf

            ListBox4.Items.Add(mydatatable.Rows(x).Item("volunteerID"))
            ListBox1.Items.Add(mydatatable.Rows(x).Item("firstName") & " " & mydatatable.Rows(x).Item("lastName"))


        Next
    End Sub
End Class
