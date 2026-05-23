using landscape_be.models;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

internal static class Program
{
    [STAThread]
    private static void Main() 
    {
        ApplicationConfiguration.Initialize();

        string conString = "Server=localhost\\SQLEXPRESS;Database=Landscape;TrustServerCertificate=true;Trusted_Connection=True;";
        DataTable dt = new DataTable();

        try
        {
            using SqlConnection con = new SqlConnection(conString);
            con.Open();

            // Create the employee to insert
            Employee employee = new Employee(2, "Jeff", "Jeffington", "jeff.jeffington@gmail.com");

            // Run insert with a dedicated command and parameters
            string insertQuery = "INSERT INTO Employees (EmployeeID, FirstName, LastName, Email) VALUES (@Id, @FirstName, @LastName, @Email)";
            using (SqlCommand insertCmd = new SqlCommand(insertQuery, con))
            {
                insertCmd.Parameters.AddWithValue("@Id", employee.Id);
                insertCmd.Parameters.AddWithValue("@FirstName", employee.FirstName);
                insertCmd.Parameters.AddWithValue("@LastName", employee.LastName);
                insertCmd.Parameters.AddWithValue("@Email", employee.Email);
                insertCmd.ExecuteNonQuery();
            }

            // Now select and load results
            string query = "SELECT * FROM Employees";
            using SqlCommand cmd = new SqlCommand(query, con);
            using SqlDataReader reader = cmd.ExecuteReader();
            dt.Load(reader);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error loading data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        using var form = new Form() { Text = "Employees", Width = 800, Height = 600 };
        var grid = new DataGridView { Dock = DockStyle.Fill, ReadOnly = true, AutoGenerateColumns = true };
        grid.DataSource = dt;
        form.Controls.Add(grid);

        Application.Run(form);
    }
}
