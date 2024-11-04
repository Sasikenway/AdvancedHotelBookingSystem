<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="AdvancedHotelBookingSystem.Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Register</h2>
    <div class="row">
        <div class="col-md-6">
            <asp:Label ID="UsernameLabel" runat="server" Text="Username"></asp:Label>
            <asp:TextBox ID="UsernameTextBox" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="col-md-6">
            <asp:Label ID="EmailLabel" runat="server" Text="Email"></asp:Label>
            <asp:TextBox ID="EmailTextBox" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
    </div>
    <div class="row mt-3">
        <div class="col-md-6">
            <asp:Label ID="PasswordLabel" runat="server" Text="Password"></asp:Label>
            <asp:TextBox ID="PasswordTextBox" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="col-md-6">
            <asp:Label ID="ConfirmPasswordLabel" runat="server" Text="Confirm Password"></asp:Label>
            <asp:TextBox ID="ConfirmPasswordTextBox" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
        </div>
    </div>
    <asp:Button ID="RegisterButton" runat="server" Text="Register" CssClass="btn btn-primary mt-3" OnClick="RegisterButton_Click" />
</asp:Content>
