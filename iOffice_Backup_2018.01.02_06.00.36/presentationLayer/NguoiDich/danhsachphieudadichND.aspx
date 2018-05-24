<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMater/MyDocusND.Master" AutoEventWireup="true" CodeBehind="danhsachphieudadichND.aspx.cs" Inherits="iOffice.presentationLayer.NguoiDich.danhsachphieudadichND" %>
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
                 height: 600
             });
         }
</script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
      
        <%=hasLanguege["lbDanhSachPhieuDadich"] %>
    </p>
    <asp:GridView ID="GridView1" runat="server" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" AutoGenerateColumns="False" OnRowDataBound="GridView1_RowDataBound" Width="98%" >
        <Columns>
           <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="linkDeTails" runat="server" CommandName="Select" ><img src="../../Images/View.png" />
                                <asp:Label ID="lblDeTails" runat="server" Text=""></asp:Label>
                            </asp:LinkButton>
                        </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="pdno" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" >
            
            </asp:BoundField>
            <asp:BoundField DataField="mytitle" >
          
            <ItemStyle Width="50%" />
            </asp:BoundField>
            <asp:BoundField DataField="USERNAME" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"   >
           
            </asp:BoundField>
            <asp:BoundField DataField="CFMDate2" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"  DataFormatString="{0:dd/MM/yyyy}" />
         
        </Columns>
        <HeaderStyle BackColor="Tomato" CssClass="FixedHeader"></HeaderStyle>
    </asp:GridView>
</asp:Content>
