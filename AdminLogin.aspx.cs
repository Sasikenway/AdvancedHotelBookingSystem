using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI;

namespace AdvancedHotelBookingSystem
{
    public partial class AdminLogin : Page
    {
        protected void AdminLoginButton_Click(object sender, EventArgs e)
        {
            string username = AdminUsernameTextBox.Text;
            string password = AdminPasswordTextBox.Text;

            string connectionString = ConfigurationManager.ConnectionStrings["HotelDBConnectionString"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM Admins WHERE Username = @Username AND Password = @Password";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@Password", password);

                conn.Open();
                int count = (int)cmd.ExecuteScalar();

                if (count > 0)
                {
                    // Redirect to admin dashboard or other admin pages
                    Response.Redirect("Admin.aspx");
                }
                else
                {
                    LoginStatusLabel.Text = "Invalid username or password.";
                }
            }
        }
    }
}
