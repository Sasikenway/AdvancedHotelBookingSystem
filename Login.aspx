<%@ Page Title="Login" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="AdvancedHotelBookingSystem.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h2 class="text-center mb-4">Login</h2>
        <div class="row justify-content-center">
            <div class="col-md-6">
                <div class="card p-4 shadow-sm">
                    <div class="card-body">
                        <asp:Label ID="LoginMessageLabel" runat="server" CssClass="alert alert-warning" Visible="false"></asp:Label>
                        <asp:Label ID="UsernameLabel" runat="server" Text="Username" CssClass="form-label"></asp:Label>
                        <asp:TextBox ID="UsernameTextBox" runat="server" CssClass="form-control mb-3"></asp:TextBox>
                        <asp:Label ID="PasswordLabel" runat="server" Text="Password" CssClass="form-label"></asp:Label>
                        <asp:TextBox ID="PasswordTextBox" runat="server" TextMode="Password" CssClass="form-control mb-3"></asp:TextBox>
                        <asp:Button ID="LoginButton" runat="server" Text="Login" CssClass="btn btn-primary w-100" OnClick="LoginButton_Click" />
                        <div class="text-center mt-3">
                            <asp:Button ID="CreateAccountButton" runat="server" Text="Create Account" CssClass="btn btn-secondary" OnClick="CreateAccountButton_Click" />
                        </div>
                        <asp:Button ID="AdminLoginButton" runat="server" Text="Admin Login" CssClass="btn btn-secondary" OnClick="AdminLoginButton_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
