using System;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using System.Web.UI.WebControls;

namespace AdvancedHotelBookingSystem
{
    public partial class Admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
            }
        }

        private void BindGrid()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["HotelDBConnectionString"].ConnectionString;
            string query = "SELECT * FROM Hotels";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                HotelsGridView.DataSource = cmd.ExecuteReader();
                HotelsGridView.DataBind();
            }
        }

        protected void HotelsGridView_RowEditing(object sender, GridViewEditEventArgs e)
        {
            HotelsGridView.EditIndex = e.NewEditIndex;
            BindGrid();
        }

        protected void HotelsGridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.RowIndex < HotelsGridView.Rows.Count)
                {
                    GridViewRow row = HotelsGridView.Rows[e.RowIndex];
                    if (e.RowIndex >= 0 && e.RowIndex < HotelsGridView.DataKeys.Count)
                    {
                        string hotelID = HotelsGridView.DataKeys[e.RowIndex].Value.ToString();
                        string hotelName = ((TextBox)row.FindControl("HotelNameTextBox")).Text;
                        string description = ((TextBox)row.FindControl("DescriptionTextBox")).Text;
                        string address = ((TextBox)row.FindControl("AddressTextBox")).Text;

                        // Handle image update (if needed)
                        string imageUrl = ((Image)row.FindControl("HotelImage")).ImageUrl;

                        string connectionString = ConfigurationManager.ConnectionStrings["HotelDBConnectionString"].ConnectionString;
                        string query = "UPDATE Hotels SET HotelName = @HotelName, Description = @Description, Address = @Address, ImageUrl = @ImageUrl WHERE HotelID = @HotelID";

                        using (SqlConnection conn = new SqlConnection(connectionString))
                        {
                            SqlCommand cmd = new SqlCommand(query, conn);
                            cmd.Parameters.AddWithValue("@HotelName", hotelName);
                            cmd.Parameters.AddWithValue("@Description", description);
                            cmd.Parameters.AddWithValue("@Address", address);
                            cmd.Parameters.AddWithValue("@ImageUrl", imageUrl);
                            cmd.Parameters.AddWithValue("@HotelID", hotelID);

                            conn.Open();
                            cmd.ExecuteNonQuery();
                            conn.Close();
                        }

                        HotelsGridView.EditIndex = -1;
                        BindGrid();
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exception (e.g., log it and show a friendly error message)
                // For now, rethrow the exception for debugging
                throw;
            }
        }



        protected void HotelsGridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            HotelsGridView.EditIndex = -1;
            BindGrid();
        }

        protected void HotelsGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                // Ensure RowIndex is valid
                if (e.RowIndex >= 0 && e.RowIndex < HotelsGridView.DataKeys.Count)
                {
                    string hotelID = HotelsGridView.DataKeys[e.RowIndex].Value.ToString();

                    string connectionString = ConfigurationManager.ConnectionStrings["HotelDBConnectionString"].ConnectionString;
                    string query = "DELETE FROM Hotels WHERE HotelID = @HotelID";

                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@HotelID", hotelID);

                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }

                    BindGrid();
                }
                else
                {
                    // Handle invalid index scenario
                    // Log an error or show a message
                    throw new ArgumentOutOfRangeException("Row index is out of range.");
                }
            }
            catch (Exception ex)
            {
                // Log or handle the exception
                // For now, rethrow it for debugging
                throw;
            }
        }


        protected void SaveButton_Click(object sender, EventArgs e)
        {
            string hotelName = HotelNameTextBox.Text;
            string description = DescriptionTextBox.Text;
            string address = AddressTextBox.Text;

            string imageUrl = string.Empty;
            if (HotelImageUpload.HasFile)
            {
                // Ensure the images directory exists
                string imagesFolderPath = Server.MapPath("/images/");
                if (!Directory.Exists(imagesFolderPath))
                {
                    Directory.CreateDirectory(imagesFolderPath);
                }

                string fileName = Path.GetFileName(HotelImageUpload.PostedFile.FileName);
                string filePath = Path.Combine(imagesFolderPath, fileName);
                HotelImageUpload.SaveAs(filePath);
                imageUrl = "/images/" + fileName;
            }

            string connectionString = ConfigurationManager.ConnectionStrings["HotelDBConnectionString"].ConnectionString;

            if (string.IsNullOrEmpty(hotelID))
            {
                // Insert new hotel
                string query = "INSERT INTO Hotels (HotelName, Description, Address, ImageUrl) VALUES (@HotelName, @Description, @Address, @ImageUrl)";
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@HotelName", hotelName);
                    cmd.Parameters.AddWithValue("@Description", description);
                    cmd.Parameters.AddWithValue("@Address", address);
                    cmd.Parameters.AddWithValue("@ImageUrl", imageUrl);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            else
            {
                // Update existing hotel
                string query = "UPDATE Hotels SET HotelName = @HotelName, Description = @Description, Address = @Address, ImageUrl = @ImageUrl WHERE HotelID = @HotelID";
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@HotelName", hotelName);
                    cmd.Parameters.AddWithValue("@Description", description);
                    cmd.Parameters.AddWithValue("@Address", address);
                    cmd.Parameters.AddWithValue("@ImageUrl", imageUrl);
                    cmd.Parameters.AddWithValue("@HotelID", hotelID);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }

            // Clear fields and update grid
            HotelNameTextBox.Text = string.Empty;
            DescriptionTextBox.Text = string.Empty;
            AddressTextBox.Text = string.Empty;
            HotelImageUpload.Attributes.Clear();
            BindGrid();
        }


        // Add a property to hold the current editing hotel's ID
        private string hotelID
        {
            get { return ViewState["HotelID"] as string; }
            set { ViewState["HotelID"] = value; }
        }
    }
}
