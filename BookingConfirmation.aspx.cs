using System;
using System.Web.UI;

namespace AdvancedHotelBookingSystem
{
    public partial class BookingConfirmation : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Retrieve booking details from query string and display
                if (Request.QueryString["roomType"] != null)
                {
                    RoomTypeLabel.Text = Request.QueryString["roomType"];
                    CheckInDateLabel.Text = Request.QueryString["checkIn"];
                    CheckOutDateLabel.Text = Request.QueryString["checkOut"];
                    GuestsLabel.Text = Request.QueryString["guests"];
                    TotalPriceLabel.Text = Request.QueryString["price"];
                }
            }
        }
    }
}
