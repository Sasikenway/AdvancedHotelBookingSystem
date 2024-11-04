<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="AdvancedHotelBookingSystem.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main aria-labelledby="title">
        <h2 id="title"><%: Title %>.</h2>
        <h3> Reach Us</h3>
        <address>
            Doon Valley Way<br />
            Waterloo, ON 98052-6399<br />
            <abbr title="Phone">P:</abbr>
            425.555.0100
        </address>

        <address>
            <strong>Support:</strong>   <a href="mailto:Support@example.com">Support@conestoga.com</a><br />
            <strong>Marketing:</strong> <a href="mailto:Marketing@example.com">Marketing@conestoga.com</a>
        </address>
    </main>
</asp:Content>
