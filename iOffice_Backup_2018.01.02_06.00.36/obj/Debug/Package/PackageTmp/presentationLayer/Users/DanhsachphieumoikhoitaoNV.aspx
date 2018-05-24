<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMater/MyDocus.Master" AutoEventWireup="true" CodeBehind="DanhsachphieumoikhoitaoNV.aspx.cs" Inherits="iOffice.presentationLayer.Users.DanhsachphieumoikhoitaoNV" %>
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
  <br />
   
    <p><%=hasLanguege["lblDSphieutam"].ToString() %></p>

      
          
       
    <asp:GridView ID="GridView1" runat="server" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" AutoGenerateColumns="False" OnRowDataBound="GridView1_RowDataBound" PageSize="25" Width="99%">
    <Columns>
    
        <asp:TemplateField>
            <ItemTemplate>
                <asp:LinkButton ID="linkDeTails" runat="server" CommandName="Select" ><img src="../../Images/View.png" />
                    <asp:Label ID="lblDeTails" runat="server" Text=""></asp:Label>
                </asp:LinkButton>
            </ItemTemplate>
             <ItemStyle Width="6%" />
        </asp:TemplateField>
       <asp:TemplateField HeaderText="abtype" Visible="false">
            <ItemTemplate>
                <asp:Label ID="lblabtype" runat="server" Text='<%#Eval("abtype") %>'></asp:Label>
            </ItemTemplate>
            
        </asp:TemplateField>
        <asp:BoundField DataField="abname" ItemStyle-Width="20%" >
        
        </asp:BoundField>
        <asp:BoundField DataField="pdno"  ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center"   >
         
        </asp:BoundField>
        <asp:BoundField DataField="mytitle"  ItemStyle-Width="35%"   >
       
        </asp:BoundField>
        <asp:BoundField DataField="USERNAME"  >
         
        </asp:BoundField>
         <asp:TemplateField HeaderText="ID" Visible="false">
            <ItemTemplate>
                <asp:Label ID="lblDepart" runat="server" Text='<%#Eval("ID") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField DataField="DepName" >
         
        </asp:BoundField>
        
    </Columns>
     <HeaderStyle CssClass="GridviewScrollHeader" /> 
    <RowStyle CssClass="GridviewScrollItem" /> 
    <PagerStyle CssClass="GridviewScrollPager" /> 
   <HeaderStyle BackColor="Tomato" CssClass="FixedHeader"></HeaderStyle>
</asp:GridView>

          
    </div>
          
   
</asp:Content>
