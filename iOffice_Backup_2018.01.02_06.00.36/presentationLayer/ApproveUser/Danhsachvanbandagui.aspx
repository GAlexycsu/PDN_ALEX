<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMater/MyDocus.Master" AutoEventWireup="true" CodeBehind="Danhsachvanbandagui.aspx.cs" Inherits="iOffice.presentationLayer.ApproveUser.Danhsachvanbandagui" %>
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
                 width: '99%',
                 height: 700
             });
         }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="margin-left:10px">


     <p><%=hasLanguege["lbDSPhieuDaGui"] %></p>
  
      
    <asp:GridView ID="GridView1" runat="server" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" AutoGenerateColumns="False" OnRowDataBound="GridView1_RowDataBound" OnRowDeleting="GridView1_RowDeleting" PageSize="25" Width="99%">
    <Columns>
        <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="linkDeTails" runat="server" CommandName="Select" ><img src="../../Images/View.png" />
                                <asp:Label ID="lblDeTails" runat="server" Text=""></asp:Label>
                            </asp:LinkButton>
                        </ItemTemplate>
                <ItemStyle Width="6%" />
       </asp:TemplateField>
       <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="linkNoiDung" runat="server" CommandName="Delete" ><img src="../../Images/Up.png" />
                                <asp:Label ID="lblNoiDung" runat="server" Text=""></asp:Label>
                            </asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
        <asp:BoundField ItemStyle-Width="15%"  DataField="abname" />
        <asp:BoundField ItemStyle-Width="7%" ItemStyle-HorizontalAlign="Center" DataField="pdno" />
        <asp:BoundField ItemStyle-Width="30%" DataField="mytitle" />
        <asp:BoundField ItemStyle-Width="7%" ItemStyle-HorizontalAlign="Center" DataField="NameABC" />
        <asp:BoundField DataField="USERNAME" ItemStyle-HorizontalAlign="Center" />
        <asp:BoundField DataField="DepName" />
         
    </Columns>
        <HeaderStyle BackColor="Tomato" CssClass="FixedHeader"></HeaderStyle>
</asp:GridView>
   

    </div>
</asp:Content>
