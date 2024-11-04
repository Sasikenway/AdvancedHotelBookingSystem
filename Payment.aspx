<%@ Page Title="Payment" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Payment.aspx.cs" Inherits="AdvancedHotelBookingSystem.Payment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h2>Payment</h2>

        <asp:Panel ID="PaymentPanel" runat="server">
            <div class="row">
                <div class="col-md-6 mb-3">
                    <label for="CardNumber" class="form-label">Card Number</label>
                    <asp:TextBox ID="CardNumberTextBox" runat="server" CssClass="form-control" placeholder="1234 5678 9012 3456"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="CardNumberRequired" runat="server" ControlToValidate="CardNumberTextBox" ErrorMessage="Card Number is required" CssClass="text-danger" Display="Dynamic" />
                    <asp:RegularExpressionValidator ID="CardNumberRegex" runat="server" ControlToValidate="CardNumberTextBox" ErrorMessage="Invalid Card Number" CssClass="text-danger" Display="Dynamic" ValidationExpression="^\d{4}\s\d{4}\s\d{4}\s\d{4}$" />
                </div>
                <div class="col-md-6 mb-3">
                    <label for="ExpirationDate" class="form-label">Expiration Date</label>
                    <asp:TextBox ID="ExpirationDateTextBox" runat="server" CssClass="form-control" placeholder="MM/YY"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="ExpirationDateRequired" runat="server" ControlToValidate="ExpirationDateTextBox" ErrorMessage="Expiration Date is required" CssClass="text-danger" Display="Dynamic" />
                    <asp:RegularExpressionValidator ID="ExpirationDateRegex" runat="server" ControlToValidate="ExpirationDateTextBox" ErrorMessage="Invalid Expiration Date" CssClass="text-danger" Display="Dynamic" ValidationExpression="^(0[1-9]|1[0-2])\/([0-9]{2})$" />
                </div>
            </div>
            <div class="row">
                <div class="col-md-6 mb-3">
                    <label for="CVV" class="form-label">CVV</label>
                    <asp:TextBox ID="CVVTextBox" runat="server" CssClass="form-control" placeholder="123"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="CVVRequired" runat="server" ControlToValidate="CVVTextBox" ErrorMessage="CVV is required" CssClass="text-danger" Display="Dynamic" />
                    <asp:RegularExpressionValidator ID="CVVRegex" runat="server" ControlToValidate="CVVTextBox" ErrorMessage="Invalid CVV" CssClass="text-danger" Display="Dynamic" ValidationExpression="^\d{3}$" />
                </div>
                <div class="col-md-6 mb-3">
                    <label for="NameOnCard" class="form-label">Name on Card</label>
                    <asp:TextBox ID="NameOnCardTextBox" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="NameOnCardRequired" runat="server" ControlToValidate="NameOnCardTextBox" ErrorMessage="Name on Card is required" CssClass="text-danger" Display="Dynamic" />
                </div>
            </div>
            <div class="text-center">
                <asp:Button ID="PayButton" runat="server" Text="Pay Now" CssClass="btn btn-primary" OnClick="PayButton_Click" />
            </div>
        </asp:Panel>

        <asp:Label ID="RoomDetailsLabel" runat="server" Text="" />
    </div>
</asp:Content>
