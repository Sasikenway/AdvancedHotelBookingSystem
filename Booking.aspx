<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Booking.aspx.cs" Inherits="AdvancedHotelBookingSystem.Booking" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Book Your Stay</h2>
    <div class="row">
        <div class="col-md-4">
            <asp:Label ID="CheckInLabel" runat="server" Text="Check-In Date"></asp:Label>
            <asp:TextBox ID="CheckInTextBox" runat="server" CssClass="form-control datepicker" />
        </div>
        <div class="col-md-4">
            <asp:Label ID="CheckOutLabel" runat="server" Text="Check-Out Date"></asp:Label>
            <asp:TextBox ID="CheckOutTextBox" runat="server" CssClass="form-control datepicker" />
        </div>
        <div class="col-md-4">
            <asp:Label ID="GuestsLabel" runat="server" Text="Number of Guests"></asp:Label>
            <asp:DropDownList ID="GuestsDropDownList" runat="server" CssClass="form-control">
                <asp:ListItem Value="1">1</asp:ListItem>
                <asp:ListItem Value="2">2</asp:ListItem>
                <asp:ListItem Value="3">3</asp:ListItem>
                <asp:ListItem Value="4">4</asp:ListItem>
                <asp:ListItem Value="5">5</asp:ListItem>
            </asp:DropDownList>
        </div>
    </div>

    <div class="row mt-3">
        <div class="col-md-4">
            <asp:Label ID="RoomTypeLabel" runat="server" Text="Room Type"></asp:Label>
            <asp:DropDownList ID="RoomTypeDropDownList" runat="server" CssClass="form-control">
                <asp:ListItem Value="Single">Single</asp:ListItem>
                <asp:ListItem Value="Double">Double</asp:ListItem>
                <asp:ListItem Value="Suite">Suite</asp:ListItem>
            </asp:DropDownList>
        </div>
        <div class="col-md-4">
            <asp:Button ID="BookButton" runat="server" Text="Book" CssClass="btn btn-primary mt-4" OnClick="BookButton_Click" />
        </div>
    </div>

    <asp:Label ID="ErrorMessageLabel" runat="server" ForeColor="Red" Visible="false" />

    <!-- Room Selection Section -->
    <div class="row mt-5">
        <asp:Repeater ID="AvailableRoomsList" runat="server">
            <ItemTemplate>
                <div class="col-md-4 mb-4">
                    <div class="card">
                        <img src='<%# Eval("RoomImageUrl") %>' class="card-img-top" style="height: 200px; object-fit: cover;" alt="Room Image" />
                        <div class="card-body">
                            <h5 class="card-title"><%# Eval("RoomType") %></h5>
                            <p class="card-text">Price: <%# Eval("Price") %></p>
                            <asp:RadioButton ID="SelectRoomRadioButton" runat="server" GroupName="RoomSelection" />
                            <asp:HiddenField ID="RoomIDHiddenField" runat="server" Value='<%# Eval("RoomID") %>' />
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
