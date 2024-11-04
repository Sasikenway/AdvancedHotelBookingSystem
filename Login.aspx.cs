using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Security;
using System.Configuration;

namespace AdvancedHotelBookingSystem
{
    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Check if a login message is present in the query string
            if (Request.QueryString["message"] == "LoginFirst")
            {
                LoginMessageLabel.Text = "Please log in first or create an account.";
                LoginMessageLabel.Visible = true;
            }
        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["HotelDBConnectionString"].ConnectionString;
            string username = UsernameTextBox.Text;
            string password = PasswordTextBox.Text;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM Users WHERE Username = @Username AND Password = @Password";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@Password", password); // Consider hashing passwords in production

                conn.Open();
                int count = (int)cmd.ExecuteScalar();
                conn.Close();

                if (count > 0)
                {
                    // Successful login
                    FormsAuthentication.SetAuthCookie(username, false);
                    Session["Username"] = username; // Set session variable if needed

                    // Redirect to Default page
                    Response.Redirect("~/Default.aspx");
                }
                else
                {
                    LoginMessageLabel.Text = "Invalid username or password.";
                    LoginMessageLabel.Visible = true;
                }
            }
        }

        protected void CreateAccountButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/CreateAccount.aspx");
        }

        protected void LogoutButton_Click(object sender, EventArgs e)
        {
            // Sign out the user
            FormsAuthentication.SignOut();

            // Clear the session
            Session.Clear();
            Session.Abandon();

            // Redirect to the login page
            Response.Redirect("~/Login.aspx");
        }

        protected void AdminLoginButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AdminLogin.aspx");
        }

    }
}
