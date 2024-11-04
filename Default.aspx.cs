using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace AdvancedHotelBookingSystem
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (User.Identity.IsAuthenticated)
                {
                    LoadHotels("All");
                }
                else
                {
                    Response.Redirect("~/Login.aspx?message=LoginFirst");
                }
            }
        }

        protected void CategoryDropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadHotels(CategoryDropdown.SelectedValue);
        }

        private void LoadHotels(string category)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["HotelDBConnectionString"].ConnectionString;
            string query = "SELECT HotelName, Description, Address, ImageUrl FROM Hotels";

            // Modify the query based on the selected category
            if (category == "Luxury")
            {
                query += " WHERE Description LIKE '%luxury%'"; // Assuming luxury hotels are described as "luxury"
            }
            else if (category == "BestDeals")
            {
                // Modify the query to include TOP with ORDER BY to make it valid
                query += " WHERE HotelID IN (SELECT TOP 1 HotelID FROM Rooms ORDER BY Price ASC)";
            }
            else if (category == "Recommended")
            {
                query += " WHERE Description LIKE '%recommended%'"; // Assuming recommended hotels have this keyword
            }
            else if (category == "Nearby")
            {
                query += " WHERE Address LIKE '%nearby%'"; // Assuming nearby hotels are based on address
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                HotelsRepeater.DataSource = reader;
                HotelsRepeater.DataBind();
            }
        }


    }
}
