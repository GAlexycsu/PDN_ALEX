<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMater/MyDocus.Master" AutoEventWireup="true" CodeBehind="tinhtrangtheovanbanNV.aspx.cs" Inherits="iOffice.presentationLayer.Users.tinhtrangtheovanbanNV" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../../Scripts/jquery.min.js"></script>
    <script src="../../Scripts/jquery-ui.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="margin-left:20px">
    <p><%=hasLanguege["lbTinhTrang17"] %></p>
    <div class="button-wrap" style="text-align:left;margin-left:50px">
        <asp:Button ID="btnTroVe" runat="server"  CssClass="button Cancel" Text="返回" OnClick="btnTroVe_Click" Width="176px" />
    </div>
    <asp:GridView ID="GridViewDSTrangThaiPhieu" runat="server" AutoGenerateColumns="False" Width="1074px">
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

    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="1071px">
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
        </div>
    </asp:Content>
