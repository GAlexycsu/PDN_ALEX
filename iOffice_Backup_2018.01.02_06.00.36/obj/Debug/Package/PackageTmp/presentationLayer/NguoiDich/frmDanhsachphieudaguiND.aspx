<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMater/MyDocusND.Master" AutoEventWireup="true" CodeBehind="frmDanhsachphieudaguiND.aspx.cs" Inherits="iOffice.presentationLayer.NguoiDich.frmDanhsachphieudaguiND" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../../Scripts/jquery.min.js"></script>
    <script src="../../Scripts/jquery-ui.min.js"></script>
    <script src="../../Scripts/gridviewScroll.min.js"></script>
     <script type="text/javascript">
         $(document).ready(function () {
             gridviewScroll();
         });

         function gridviewScroll() {
             $('#<%=GridView1.ClientID%>').gridviewScroll({
                 width: 1070,
                 height: 600
             });
         }
</script>
<script type="text/javascript">
    $(document).ready(function () {
        gridviewScroll1();
    });

    function gridviewScroll1() {
        $('#<%=GridView2.ClientID%>').gridviewScroll({
            width: 1070,
            height: 600
        });
    }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p><%=hasLanguege["lbDSPhieuDaGui"] %></p>
    <asp:GridView ID="GridView1" runat="server" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" AutoGenerateColumns="False" OnRowDataBound="GridView1_RowDataBound" OnRowDeleting="GridView1_RowDeleting"  Width="1070px">
    <Columns>
        <asp:CommandField SelectText="Details" ShowSelectButton="True" />
        <asp:CommandField DeleteText="Nội Dung" ShowDeleteButton="True" />
        <asp:BoundField DataField="abname" />
        <asp:BoundField DataField="pdno" />
        <asp:BoundField DataField="mytitle" />
        <asp:BoundField DataField="NameABC" />
        <asp:BoundField DataField="USERNAME" />
        <asp:BoundField DataField="DepName" />
    </Columns>
        <HeaderStyle BackColor="Tomato" CssClass="FixedHeader"></HeaderStyle>
</asp:GridView>
     <asp:GridView ID="GridView2" runat="server" OnSelectedIndexChanged="GridView2_SelectedIndexChanged" AutoGenerateColumns="False" OnRowDataBound="GridView2_RowDataBound" OnRowDeleting="GridView2_RowDeleting"  Width="1070px" >
    <Columns>
        <asp:CommandField SelectText="Details" ShowSelectButton="True" />
        <asp:CommandField DeleteText="Nội Dung" ShowDeleteButton="True" />
        <asp:BoundField DataField="abnameTW" />
        <asp:BoundField DataField="pdno" />
        <asp:BoundField DataField="mytitle" />
        <asp:BoundField DataField="NameABCTW" />
        <asp:BoundField DataField="USERNAME" />
        <asp:BoundField DataField="DepName" />
    </Columns>
         <HeaderStyle BackColor="Tomato" CssClass="FixedHeader"></HeaderStyle>
</asp:GridView>
</asp:Content>
