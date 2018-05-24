<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMater/MyDocusND.Master" AutoEventWireup="true" CodeBehind="tinhtrangtheovanbanND.aspx.cs" Inherits="iOffice.presentationLayer.NguoiDich.tinhtrangtheovanbanND" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p><%=hasLanguege["lbTinhTrang17"] %></p>
    <asp:GridView ID="GridViewDSTrangThaiPhieu" runat="server" AutoGenerateColumns="False" Width="1020px">
        <Columns>
            <asp:BoundField DataField="abname" />
            <asp:BoundField DataField="pdno" />
            <asp:BoundField DataField="mytitle" />
            <asp:BoundField DataField="YnName" />
            <asp:BoundField DataField="NameABC" />
            <asp:BoundField DataField="USERNAME" />
            <asp:BoundField DataField="DepName" />
        </Columns>

    </asp:GridView>

    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="1016px">
        <Columns>
            <asp:BoundField DataField="abnameTW" />
            <asp:BoundField DataField="pdno" />
            <asp:BoundField DataField="mytitle" />
            <asp:BoundField DataField="YnNameTW" />
            <asp:BoundField DataField="NameABCTW" />
            <asp:BoundField DataField="USERNAME" />
            <asp:BoundField DataField="DepName" />
        </Columns>

    </asp:GridView>
</asp:Content>
