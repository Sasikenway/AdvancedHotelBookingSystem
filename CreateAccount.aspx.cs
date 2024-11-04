using System;
using System.Web.UI;
using System.Data.SqlClient;

namespace AdvancedHotelBookingSystem
{
    public partial class CreateAccount : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void CreateAccountButton_Click(object sender, EventArgs e)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["HotelDBConnectionString"].ConnectionString; // Update with your connection string
            string username = UsernameTextBox.Text;
            string password = PasswordTextBox.Text;
            string confirmPassword = ConfirmPasswordTextBox.Text;

            if (password != confirmPassword)
            {
                // Show an error message to the user
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Users (Username, Password) VALUES (@Username, @Password)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@Password", password); // Consider hashing passwords in production

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                // Redirect to the login page or show a success message
                Response.Redirect("~/Login.aspx");
            }
        }
    }
}
