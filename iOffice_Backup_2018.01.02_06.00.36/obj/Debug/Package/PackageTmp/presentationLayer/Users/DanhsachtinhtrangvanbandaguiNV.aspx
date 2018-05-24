<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMater/MyDocus.Master" AutoEventWireup="true" CodeBehind="DanhsachtinhtrangvanbandaguiNV.aspx.cs" Inherits="iOffice.presentationLayer.Users.DanhsachtinhtrangvanbandaguiNV" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

     <script src="../../Scripts/jquery.min.js"></script>
    <script src="../../Scripts/jquery-ui.min.js"></script>
    <script src="../../Scripts/gridviewScroll.min.js"></script>
     
<script type="text/javascript">
    $(document).ready(function () {
        gridviewScroll1();
    });

    function gridviewScroll1() {
        $('#<%=GridViewDSTrangThaiPhieu.ClientID%>').gridviewScroll({
            width: '100%',
            height: 600
        });
    }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        
    <p><%=hasLanguege["lblist"] %></p>
   <div style="margin-left:10px">


    <asp:GridView ID="GridViewDSTrangThaiPhieu" runat="server" AutoGenerateColumns="False" PageSize="25" Width="99%">
        <Columns>
            <asp:BoundField DataField="abname" ItemStyle-Width="20%" />
            <asp:BoundField DataField="pdno"  ItemStyle-Width="7%" ItemStyle-HorizontalAlign="Center"/>
            <asp:BoundField DataField="mytitle" ItemStyle-Width="30%" />
            <asp:BoundField DataField="YnName"  ItemStyle-Width="7%" ItemStyle-HorizontalAlign="Center" />
            <asp:BoundField DataField="NameABC"  ItemStyle-Width="7%" ItemStyle-HorizontalAlign="Center"/>
            <asp:BoundField DataField="USERNAME" />
            <asp:BoundField DataField="DepName" />
             
        </Columns>
        <HeaderStyle BackColor="Tomato" CssClass="FixedHeader"></HeaderStyle>
    </asp:GridView>
    
       </div>


  </asp:Content>
