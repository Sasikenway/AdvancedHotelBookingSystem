using System;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace AdvancedHotelBookingSystem
{
    public partial class Booking : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Username"] == null)
            {
                Response.Redirect("~/Login.aspx?message=LoginFirst");
            }

            if (!IsPostBack)
            {
                LoadAvailableRooms();
            }
        }

        private void LoadAvailableRooms()
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["HotelDBConnectionString"].ConnectionString;
            string query = "SELECT RoomID, RoomType, Price, RoomImageUrl FROM Rooms";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.HasRows)
                        {
                            AvailableRoomsList.DataSource = reader;
                            AvailableRoomsList.DataBind();
                        }
                        else
                        {
                            ErrorMessageLabel.Text = "No available rooms found.";
                            ErrorMessageLabel.Visible = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle any errors that occurred during data retrieval
                ErrorMessageLabel.Text = "An error occurred while loading rooms: " + ex.Message;
                ErrorMessageLabel.Visible = true;
            }
        }

        protected void BookButton_Click(object sender, EventArgs e)
        {
            string checkInDate = CheckInTextBox.Text;
            string checkOutDate = CheckOutTextBox.Text;
            int guests = Convert.ToInt32(GuestsDropDownList.SelectedValue);
            string roomType = RoomTypeDropDownList.SelectedItem.Text;

            DateTime checkInDateTime;
            DateTime checkOutDateTime;

            if (DateTime.TryParse(checkInDate, out checkInDateTime) && DateTime.TryParse(checkOutDate, out checkOutDateTime))
            {
                int numberOfDays = (checkOutDateTime - checkInDateTime).Days;

                if (numberOfDays <= 0)
                {
                    ErrorMessageLabel.Text = "Check-out date must be after the check-in date.";
                    ErrorMessageLabel.Visible = true;
                    return;
                }

                string selectedRoomId = GetSelectedRoomId();
                if (string.IsNullOrEmpty(selectedRoomId))
                {
                    ErrorMessageLabel.Text = "Please select a room.";
                    ErrorMessageLabel.Visible = true;
                    return;
                }

                // Store booking details in session variables
                Session["CheckInDate"] = checkInDateTime;
                Session["CheckOutDate"] = checkOutDateTime;
                Session["Guests"] = guests;
                Session["RoomType"] = roomType;
                Session["SelectedRoomId"] = selectedRoomId;
                Session["NumberOfDays"] = numberOfDays;

                // Redirect to payment page
                Response.Redirect("Payment.aspx");
            }
            else
            {
                ErrorMessageLabel.Text = "Invalid date format.";
                ErrorMessageLabel.Visible = true;
            }
        }

        private string GetSelectedRoomId()
        {
            foreach (RepeaterItem item in AvailableRoomsList.Items)
            {
                RadioButton radioButton = (RadioButton)item.FindControl("SelectRoomRadioButton");
                HiddenField hiddenField = (HiddenField)item.FindControl("RoomIDHiddenField");

                if (radioButton != null && radioButton.Checked)
                {
                    return hiddenField.Value;
                }
            }
            return null;
        }
    }
}
