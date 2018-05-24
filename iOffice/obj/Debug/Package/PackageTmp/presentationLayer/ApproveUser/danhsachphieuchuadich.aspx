<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMater/MyDocus.Master" AutoEventWireup="true" CodeBehind="danhsachphieuchuadich.aspx.cs" Inherits="iOffice.presentationLayer.ApproveUser.danhsachphieuchuadich" %>
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
                 width: '98%',
                 height: 700
             });
         }
</script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
       <%-- <asp:Label ID="lbPhieuchuaduyet" runat="server" Text="Danh sách phiếu chưa dịch"></asp:Label>--%>
        <%=hasLanguege["lbPhieuchuadich"] %>
    </p>
    <br />


    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnRowDataBound="GridView1_RowDataBound" PageSize="25" Width="97%">
        <Columns>
            <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="linkDeTails" runat="server" CommandName="Select" ><img src="../../Images/View.png" />
                                <asp:Label ID="lblDeTails" runat="server" Text=""></asp:Label>
                            </asp:LinkButton>
                        </ItemTemplate>
                 <ItemStyle Width="6%" />
                    </asp:TemplateField>
            <asp:BoundField DataField="pdno" ItemStyle-Width="20%" ItemStyle-HorizontalAlign="Center" HeaderText="Mã phiếu" >
            <%--<HeaderStyle Width="80px" />--%>
            </asp:BoundField>
            <asp:BoundField DataField="mytitle" ItemStyle-Width="40%" HeaderText="Tiêu đề" >
            <%--<HeaderStyle Width="500px" />--%>
            </asp:BoundField>
            <asp:BoundField DataField="TenNguoiDich" ItemStyle-HorizontalAlign="Center" HeaderText="Người dịch" >
            <%--<HeaderStyle Width="100px" />--%>
            </asp:BoundField>
            <asp:BoundField DataField="CFMDate0" ItemStyle-HorizontalAlign="Center" HeaderText="Ngày gửi" DataFormatString="{0:dd/MM/yyyy}" />

           
          
        </Columns>
        <HeaderStyle BackColor="Tomato" CssClass="FixedHeader"></HeaderStyle>
    </asp:GridView>

        
</asp:Content>
