<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMater/Site1.Master" AutoEventWireup="true" CodeBehind="tinhtrangtheovanban.aspx.cs" Inherits="iOffice.presentationLayer.ApproveUser.tinhtrangtheovanban" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p><%=hasLanguege["lbTinhTrang17"] %></p>
    <p style="margin-left:150px;text-align:left" class="button-wrap">
        <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="button Cancel" OnClick="btnBack_Click" Width="127px" /></p>
    <asp:GridView ID="GridViewDSTrangThaiPhieu" runat="server" AutoGenerateColumns="False" Width="1060px">
        <Columns>
            <asp:BoundField DataField="abname" />
            <asp:BoundField DataField="pdno" />
            <asp:BoundField DataField="mytitle" />
            <asp:BoundField DataField="YnName" />
            <asp:BoundField DataField="NameABC" />
            <asp:BoundField DataField="USERNAME" />
            <asp:BoundField DataField="DepName" />
        </Columns>
        <HeaderStyle BackColor="Tomato" CssClass="FixedHeader"></HeaderStyle>
    </asp:GridView>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="1060px">
        <Columns>
            <asp:BoundField DataField="abnameTW" />
            <asp:BoundField DataField="pdno" />
            <asp:BoundField DataField="mytitle" />
            <asp:BoundField DataField="YnNameTW" />
            <asp:BoundField DataField="NameABCTW" />
            <asp:BoundField DataField="USERNAME" />
            <asp:BoundField DataField="DepName" />
        </Columns>
        <HeaderStyle BackColor="Tomato" CssClass="FixedHeader"></HeaderStyle>
    </asp:GridView>
</asp:Content>
