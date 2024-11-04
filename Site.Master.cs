using System;
using System.Web;
using static System.Collections.Specialized.BitVector32;
using System.Web.UI;
using System.Web.Security;


namespace AdvancedHotelBookingSystem
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Additional logic for handling page load can go here if needed
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
    }
}
