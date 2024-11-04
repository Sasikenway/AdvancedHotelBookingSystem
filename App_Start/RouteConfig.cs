using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Routing;
using Microsoft.AspNet.FriendlyUrls;

namespace AdvancedHotelBookingSystem
{
    public static class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.EnableFriendlyUrls();
            routes.MapPageRoute("HomeRoute", "Home", "~/Default.aspx");
            routes.MapPageRoute("BookingRoute", "Booking", "~/Booking.aspx");
            routes.MapPageRoute("PaymentRoute", "Payment", "~/Payment.aspx");
            routes.MapPageRoute("ProfileRoute", "Profile", "~/Profile.aspx");
        }
    }
}
