<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="AdvancedHotelBookingSystem._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">
        <h1>Welcome to BooKING.com</h1>

        <!-- Category Dropdown -->
        <div class="form-group">
            <label for="categorySelect">Select Category:</label>
            <asp:DropDownList ID="CategoryDropdown" runat="server" AutoPostBack="true" OnSelectedIndexChanged="CategoryDropdown_SelectedIndexChanged" CssClass="form-control">
                <asp:ListItem Value="All" Text="All" Selected="True"></asp:ListItem>
                <asp:ListItem Value="Luxury" Text="Luxury"></asp:ListItem>
                <asp:ListItem Value="BestDeals" Text="Best Deals"></asp:ListItem>
                <asp:ListItem Value="Recommended" Text="Recommended"></asp:ListItem>
                <asp:ListItem Value="Nearby" Text="Nearby"></asp:ListItem>
            </asp:DropDownList>
        </div>

        <div class="row mt-4">
            <asp:Repeater ID="HotelsRepeater" runat="server">
                <ItemTemplate>
                    <div class="hotel-card mb-4">
                        <div class="row">
                            <div class="col-md-4">
                                <img src='<%# Eval("ImageUrl") %>' alt='<%# Eval("HotelName") %>' class="img-fluid hotel-image" />
                            </div>
                            <div class="col-md-8">
                                <h3><%# Eval("HotelName") %></h3>
                                <p><%# Eval("Description") %></p>
                                <p><strong>Address:</strong> <%# Eval("Address") %></p>
                                <a href="Booking.aspx" class="btn btn-primary">Book Now</a>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>

</asp:Content>
