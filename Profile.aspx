<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="AdvancedHotelBookingSystem.Profile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Your Profile</h2>
    <div class="row">
        <div class="col-md-6">
            <h3>Booking History</h3>
            <asp:GridView ID="BookingHistoryGrid" runat="server" AutoGenerateColumns="false" CssClass="table table-striped">
                <Columns>
                    <asp:BoundField DataField="BookingID" HeaderText="Booking ID" />
                    <asp:BoundField DataField="RoomType" HeaderText="Room Type" />
                    <asp:BoundField DataField="CheckInDate" HeaderText="Check-In Date" />
                    <asp:BoundField DataField="CheckOutDate" HeaderText="Check-Out Date" />
                    <asp:BoundField DataField="TotalPrice" HeaderText="Total Price" />
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSourceBookingHistory" runat="server" 
                ConnectionString="<%$ ConnectionStrings:HotelDBConnectionString %>" 
                SelectCommand="SELECT BookingID, RoomType, CheckInDate, CheckOutDate, TotalPrice FROM Bookings WHERE UserID = @UserID">
                <SelectParameters>
                    <asp:Parameter Name="UserID" Type="String" />
                </SelectParameters>
            </asp:SqlDataSource>
        </div>
        <div class="col-md-6">
            <h3>Update Your Information</h3>
            <asp:Label ID="EmailLabel" runat="server" Text="Email"></asp:Label>
            <asp:TextBox ID="EmailTextBox" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:Label ID="PhoneLabel" runat="server" Text="Phone Number" CssClass="mt-3"></asp:Label>
            <asp:TextBox ID="PhoneTextBox" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:Button ID="UpdateProfileButton" runat="server" Text="Update" CssClass="btn btn-primary mt-3" OnClick="UpdateProfileButton_Click" />
        </div>
    </div>
</asp:Content>

