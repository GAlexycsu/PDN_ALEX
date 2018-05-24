<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMater/MyDocus.Master" AutoEventWireup="true" CodeBehind="danhsachvanbandadichNV.aspx.cs" Inherits="iOffice.presentationLayer.Users.danhsachvanbandadichNV" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link href="../../Style/GridviewScroll.css" rel="stylesheet" />
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
        <asp:Label ID="lbPhieudadich" runat="server" Text=""></asp:Label>
        <%=hasLanguege["lbDSPhieuDaDich"] %>
    </p>
    <br />
   <div style="margin-left:10px">


          
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnRowDataBound="GridView1_RowDataBound" PageSize="25" Width="98%">
        <Columns>
           <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="linkDeTails" runat="server" CommandName="Select" ><img src="../../Images/View.png" />
                                <asp:Label ID="lblDeTails" runat="server" Text=""></asp:Label>
                            </asp:LinkButton>
                        </ItemTemplate>
                <ItemStyle Width="6%" />
                    </asp:TemplateField>
            <asp:BoundField DataField="pdno"  ItemStyle-Width="7%" ItemStyle-HorizontalAlign="Center" HeaderText="Mã phiếu" >
            <%--<HeaderStyle Width="80px" />--%>
            </asp:BoundField>
            <asp:BoundField DataField="mytitle" ItemStyle-Width="40%" HeaderText="Tiêu đề" >
            <%--<HeaderStyle Width="450px" />--%>
            </asp:BoundField>
            <asp:BoundField DataField="TenNguoiDich" ItemStyle-HorizontalAlign="Center" HeaderText="Người dịch" >
           <%-- <HeaderStyle Width="150px" />--%>
            </asp:BoundField>
            <asp:BoundField DataField="CFMDate2"   ItemStyle-HorizontalAlign="Center" HeaderText="" DataFormatString="{0:dd/MM/yyyy}" />
        </Columns>
            <HeaderStyle BackColor="Tomato" CssClass="FixedHeader"></HeaderStyle>
    </asp:GridView>
 
   </div>


</asp:Content>
