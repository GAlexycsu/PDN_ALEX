<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMater/Site1.Master" AutoEventWireup="true" CodeBehind="danhsachvanbandaky.aspx.cs" Inherits="iOffice.presentationLayer.ApproveUser.danhsachvanbandaky" %>
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
                 width: '100%',
                 height: 600
             });
         }
</script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="margin-left:10px">
    <p><%=hasLanguege["lbVBKy"] %></p>
    
          
    <asp:GridView ID="GridView1" runat="server" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" AutoGenerateColumns="False" OnRowDeleting="GridView1_RowDeleting" OnRowDataBound="GridView1_RowDataBound" PageSize="25" Width="99%">
    <Columns>
       <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="linkDeTails" runat="server" CommandName="Select" ><img src="../../Images/View.png" />
                                <asp:Label ID="lblDeTails" runat="server" Text=""></asp:Label>
                            </asp:LinkButton>
                        </ItemTemplate>
           <ItemStyle Width="6%" />
     </asp:TemplateField>
        
        <asp:BoundField ItemStyle-Width="20%"  DataField="abname" />
        <asp:BoundField ItemStyle-Width="7%" ItemStyle-HorizontalAlign="Center" DataField="pdno" />
        <asp:BoundField ItemStyle-Width="30%" DataField="mytitle" />
        <asp:BoundField ItemStyle-Width="7%" ItemStyle-HorizontalAlign="Center" DataField="YnName" />
        <asp:BoundField ItemStyle-Width="7%" ItemStyle-HorizontalAlign="Center" DataField="NameABC" />
        <asp:BoundField DataField="USERNAME" />
        <asp:BoundField DataField="DepName" />
      
        <asp:TemplateField Visible="false">
            <ItemTemplate>
                <asp:Label ID="lblMaDonVi" runat="server" Text='<%#Eval("from_depart") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
        <HeaderStyle BackColor="Tomato" CssClass="FixedHeader"></HeaderStyle>
</asp:GridView>
  
    </div>
</asp:Content>
