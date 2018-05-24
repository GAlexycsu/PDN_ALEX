<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMater/MyDocusND.Master" AutoEventWireup="true" CodeBehind="frmDanhsachphieumoikhoitaoND.aspx.cs" Inherits="iOffice.presentationLayer.NguoiDich.frmDanhsachphieumoikhoitaoND" %>
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
                 width: 870,
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
            width: 870,
            height: 600
        });
    }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <p><%=hasLanguege["lblDSphieutam"].ToString() %></p>
    <asp:GridView ID="GridView1" runat="server" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" AutoGenerateColumns="False" OnRowDataBound="GridView1_RowDataBound" PageSize="25" Width="1072px">
    <Columns>
        <asp:CommandField SelectText="Details" ShowSelectButton="True" />
       <%-- <asp:BoundField DataField="abtype" />--%>
        <asp:TemplateField HeaderText="" ShowHeader="false">
            <ItemTemplate>
                <asp:Label ID="lblMaLoaiPhieu" runat="server" Text='<%#Eval("abtype") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField DataField="abname" />
        <asp:BoundField DataField="pdno" />
        <asp:BoundField DataField="mytitle" />
        <asp:BoundField DataField="USERNAME" />
        <%--<asp:BoundField DataField="ID" />--%>
        <asp:TemplateField HeaderText="ID" ShowHeader="false">
            <ItemTemplate>
                <asp:Label ID="lblMaBoPhan" runat="server" Text='<%#Eval("ID") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField DataField="DepName" />
        
    </Columns>
        <HeaderStyle BackColor="Tomato" CssClass="FixedHeader"></HeaderStyle>
</asp:GridView>
     <asp:GridView ID="GridView2" runat="server" OnSelectedIndexChanged="GridView2_SelectedIndexChanged" AutoGenerateColumns="False" OnRowDataBound="GridView2_RowDataBound" PageSize="25" Width="1070px">
    <Columns>
        <asp:CommandField SelectText="Details" ShowSelectButton="True" />
          <asp:TemplateField HeaderText="" ShowHeader="false">
            <ItemTemplate>
                <asp:Label ID="lblMaLoaiPhieu" runat="server" Text='<%#Eval("abtype") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField DataField="abnameTW" />
        <asp:BoundField DataField="pdno" />
        <asp:BoundField DataField="mytitle" />
        <asp:BoundField DataField="USERNAME" />
       <asp:TemplateField HeaderText="ID" ShowHeader="false">
            <ItemTemplate>
                <asp:Label ID="lblMaBoPhan" runat="server" Text='<%#Eval("ID") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField DataField="DepName" />
         
    </Columns>
         <HeaderStyle BackColor="Tomato" CssClass="FixedHeader"></HeaderStyle>
</asp:GridView>
</asp:Content>
