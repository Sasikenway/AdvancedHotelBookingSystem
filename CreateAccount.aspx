<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateAccount.aspx.cs" Inherits="AdvancedHotelBookingSystem.CreateAccount" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h2 class="text-center mb-4">Create Account</h2>
        <div class="row justify-content-center">
            <div class="col-md-6">
                <div class="card p-4 shadow-sm">
                    <div class="card-body">
                        <asp:Label ID="UsernameLabel" runat="server" Text="Username" CssClass="form-label"></asp:Label>
                        <asp:TextBox ID="UsernameTextBox" runat="server" CssClass="form-control mb-3"></asp:TextBox>
                        <asp:Label ID="PasswordLabel" runat="server" Text="Password" CssClass="form-label"></asp:Label>
                        <asp:TextBox ID="PasswordTextBox" runat="server" TextMode="Password" CssClass="form-control mb-3"></asp:TextBox>
                        <asp:Label ID="ConfirmPasswordLabel" runat="server" Text="Confirm Password" CssClass="form-label"></asp:Label>
                        <asp:TextBox ID="ConfirmPasswordTextBox" runat="server" TextMode="Password" CssClass="form-control mb-3"></asp:TextBox>
                        <asp:Button ID="CreateAccountButton" runat="server" Text="Create Account" CssClass="btn btn-primary w-100" OnClick="CreateAccountButton_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
