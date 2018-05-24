<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMater/MyDocus.Master" AutoEventWireup="true" CodeBehind="danhsachvanbanchuadichNV.aspx.cs" Inherits="iOffice.presentationLayer.Users.danhsachvanbanchuadichNV" %>
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
    <p>
       <%-- <asp:Label ID="lbPhieuchuaduyet" runat="server" Text="Danh sách phiếu chưa dịch"></asp:Label>--%>
        <%=hasLanguege["lbPhieuchuadich"] %>
    </p>
    <br />
   

         
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnRowDataBound="GridView1_RowDataBound" PageSize="25" Width="99%">
        <Columns>
             <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="linkDeTails" runat="server" CommandName="Select" ><img src="../../Images/View.png" />
                                <asp:Label ID="lblDeTails" runat="server" Text=""></asp:Label>
                            </asp:LinkButton>
                        </ItemTemplate>
                  <ItemStyle Width="6%" />
                    </asp:TemplateField>
            <asp:BoundField DataField="pdno" HeaderText="Mã phiếu" ItemStyle-HorizontalAlign="Center" >
            
            </asp:BoundField>
            <asp:BoundField DataField="mytitle" ItemStyle-Width="60%" HeaderText="Tiêu đề"  >
             
            </asp:BoundField>
            <asp:BoundField DataField="TenNguoiDich" HeaderText="Người dịch" ItemStyle-HorizontalAlign="Center"  >
           
            </asp:BoundField>
            <asp:BoundField DataField="CFMDate0" HeaderText="Ngày gửi" ItemStyle-HorizontalAlign="Center" DataFormatString="{0:dd/MM/yyyy}"   >
            
            </asp:BoundField>
            
           
          
        </Columns>
        <HeaderStyle BackColor="Tomato" CssClass="FixedHeader"></HeaderStyle>
    </asp:GridView>
    
         

 
        </div>

</asp:Content>
