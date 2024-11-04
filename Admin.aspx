<%@ Page Title="Admin" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="AdvancedHotelBookingSystem.Admin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Hotel Management</h2>
    <div class="container">
        <asp:GridView ID="HotelsGridView" runat="server" AutoGenerateColumns="False" OnRowEditing="HotelsGridView_RowEditing"
            OnRowUpdating="HotelsGridView_RowUpdating" OnRowCancelingEdit="HotelsGridView_RowCancelingEdit"
            OnRowDeleting="HotelsGridView_RowDeleting" DataKeyNames="HotelID">
            <Columns>
                <asp:BoundField DataField="HotelID" HeaderText="ID" ReadOnly="True" />
                <asp:TemplateField HeaderText="Name">
                    <ItemTemplate>
                        <asp:Label ID="HotelNameLabel" runat="server" Text='<%# Eval("HotelName") %>' />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="HotelNameTextBox" runat="server" Text='<%# Bind("HotelName") %>' CssClass="form-control" />
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Description">
                    <ItemTemplate>
                        <asp:Label ID="DescriptionLabel" runat="server" Text='<%# Eval("Description") %>' />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="DescriptionTextBox" runat="server" Text='<%# Bind("Description") %>' CssClass="form-control" TextMode="MultiLine" Rows="4" />
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Address">
                    <ItemTemplate>
                        <asp:Label ID="AddressLabel" runat="server" Text='<%# Eval("Address") %>' />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="AddressTextBox" runat="server" Text='<%# Bind("Address") %>' CssClass="form-control" />
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Image">
                    <ItemTemplate>
                        <asp:Image ID="HotelImage" runat="server" ImageUrl='<%# Eval("ImageUrl") %>' Width="100px" Height="100px" />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:Image ID="HotelImage" runat="server" ImageUrl='<%# Eval("ImageUrl") %>' Width="100px" Height="100px" />
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
            </Columns>
        </asp:GridView>




        <h3>Add/Edit Hotel</h3>
        <asp:Panel ID="HotelDetailsPanel" runat="server">
            <asp:TextBox ID="HotelNameTextBox" runat="server" CssClass="form-control" />
            <asp:TextBox ID="DescriptionTextBox" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="4" />
            <asp:TextBox ID="AddressTextBox" runat="server" CssClass="form-control" />
            <asp:FileUpload ID="HotelImageUpload" runat="server" CssClass="form-control" />
            <asp:Button ID="SaveButton" runat="server" Text="Save" CssClass="btn btn-primary" OnClick="SaveButton_Click" />
        </asp:Panel>
    </div>
</asp:Content>
