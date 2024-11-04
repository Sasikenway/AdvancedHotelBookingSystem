<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdminLogin.aspx.cs" Inherits="AdvancedHotelBookingSystem.AdminLogin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Admin Login</h2>
    <asp:Panel ID="LoginPanel" runat="server" CssClass="login-panel">
        <asp:TextBox ID="AdminUsernameTextBox" runat="server" CssClass="form-control" Placeholder="Username" />
        <asp:TextBox ID="AdminPasswordTextBox" runat="server" TextMode="Password" CssClass="form-control" Placeholder="Password" />
        <asp:Button ID="AdminLoginButton" runat="server" Text="Login" CssClass="btn btn-primary" OnClick="AdminLoginButton_Click" />
        <asp:Label ID="LoginStatusLabel" runat="server" ForeColor="Red" />
    </asp:Panel>
</asp:Content>
