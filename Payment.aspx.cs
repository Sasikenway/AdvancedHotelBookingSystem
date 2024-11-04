using System;
using System.Data.SqlClient;
using System.Web.UI;

namespace AdvancedHotelBookingSystem
{
    public partial class Payment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Check if session variables exist
                if (Session["CheckInDate"] == null || Session["CheckOutDate"] == null || Session["Guests"] == null || Session["SelectedRoomId"] == null)
                {
                    // If any of the required session variables are missing, redirect to the booking page
                    Response.Redirect("~/Booking.aspx");
                    return;
                }

                // Retrieve booking details from Session
                DateTime checkInDate = (DateTime)Session["CheckInDate"];
                DateTime checkOutDate = (DateTime)Session["CheckOutDate"];
                int guests = (int)Session["Guests"];
                int roomId = Convert.ToInt32(Session["SelectedRoomId"]);

                // Display booking details
                RoomDetailsLabel.Text = $"Check-In Date: {checkInDate:MM/dd/yyyy}<br />" +
                                        $"Check-Out Date: {checkOutDate:MM/dd/yyyy}<br />" +
                                        $"Number of Guests: {guests}<br />";

                // Load and display room details
                LoadRoomDetails(roomId, checkInDate, checkOutDate);
            }
        }

        private void LoadRoomDetails(int roomId, DateTime checkInDate, DateTime checkOutDate)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["HotelDBConnectionString"].ConnectionString;
            string query = "SELECT RoomType, Price FROM Rooms WHERE RoomID = @RoomID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@RoomID", roomId);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        RoomDetailsLabel.Text += $"Room Type: {reader["RoomType"]}<br />Price: ${reader["Price"]}";

                        // Calculate the total price based on the number of days
                        int numberOfDays = (checkOutDate - checkInDate).Days;
                        decimal pricePerDay = Convert.ToDecimal(reader["Price"]);
                        decimal totalPrice = pricePerDay * numberOfDays;

                        // Store the total price in a session variable
                        Session["TotalPrice"] = totalPrice;

                        // Display the total price
                        RoomDetailsLabel.Text += $"<br />Total Price: ${totalPrice}";
                    }
                }
            }
        }

        protected void PayButton_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                int roomId = Convert.ToInt32(Session["SelectedRoomId"]);

                // Retrieve necessary booking details
                string roomType = Session["RoomType"].ToString();
                string checkInDate = Session["CheckInDate"].ToString();
                string checkOutDate = Session["CheckOutDate"].ToString();
                string guests = Session["Guests"].ToString();
                string totalPrice = Session["TotalPrice"].ToString();

                // Here you would normally integrate with a payment gateway
                FinalizeBooking(roomId);

                // Redirect to BookingConfirmation with query string
                string redirectUrl = $"~/BookingConfirmation.aspx?roomType={roomType}&checkIn={checkInDate}&checkOut={checkOutDate}&guests={guests}&price={totalPrice}";
                Response.Redirect(redirectUrl);
            }
        }

        private void FinalizeBooking(int roomId)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["HotelDBConnectionString"].ConnectionString;
            string updateQuery = "UPDATE Rooms SET Available = 0 WHERE RoomID = @RoomID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(updateQuery, connection))
                {
                    command.Parameters.AddWithValue("@RoomID", roomId);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
