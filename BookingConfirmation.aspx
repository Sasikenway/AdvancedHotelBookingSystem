<%@ Page Title="Booking Confirmation" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BookingConfirmation.aspx.cs" Inherits="AdvancedHotelBookingSystem.BookingConfirmation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Booking Confirmation</h2>
    <div class="alert alert-success">
        <strong>Success!</strong> Your BooKING has been confirmed.
    </div>
    <div class="card">
        <div class="card-body">
            <h5 class="card-title">Booking Details</h5>
            <p class="card-text">Room Type: <asp:Label ID="RoomTypeLabel" runat="server" /></p>
            <p class="card-text">Check-In Date: <asp:Label ID="CheckInDateLabel" runat="server" /></p>
            <p class="card-text">Check-Out Date: <asp:Label ID="CheckOutDateLabel" runat="server" /></p>
            <p class="card-text">Number of Guests: <asp:Label ID="GuestsLabel" runat="server" /></p>
            <p class="card-text">Total Price: <asp:Label ID="TotalPriceLabel" runat="server" /></p>
        </div>
    </div>
    <a href="Booking.aspx" class="btn btn-primary mt-3">Book Another Room</a>
</asp:Content>
