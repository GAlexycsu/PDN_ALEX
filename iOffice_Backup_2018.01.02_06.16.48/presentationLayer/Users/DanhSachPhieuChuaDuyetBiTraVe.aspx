<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMater/MyDocus.Master" AutoEventWireup="true" CodeBehind="DanhSachPhieuChuaDuyetBiTraVe.aspx.cs" Inherits="iOffice.presentationLayer.Users.DanhSachPhieuChuaDuyetBiTraVe" %>
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

           
        <asp:GridView ID="GridView1" runat="server" Width="99%" AutoGenerateColumns="False" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnRowDataBound="GridView1_RowDataBound" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3">
            <Columns>
             <asp:TemplateField>
            <ItemTemplate>
                <asp:LinkButton ID="linkDeTails" runat="server" CommandName="Select" ><img src="../../Images/View.png" />
                    <asp:Label ID="lblDeTails" runat="server" Text=""></asp:Label>
                </asp:LinkButton>
            </ItemTemplate>
             <ItemStyle Width="6%" />
        </asp:TemplateField>
            <asp:BoundField DataField="pdno" ItemStyle-Width="8%" ItemStyle-HorizontalAlign="Center" HeaderText="Mã phiếu" >
<ItemStyle HorizontalAlign="Center" Width="8%"></ItemStyle>
            </asp:BoundField>
            <asp:TemplateField Visible="false">
                <ItemTemplate>
                    <asp:Label ID="lblMaLoaiPhieu" runat="server" Text='<%#Eval("Abtype") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="mytitle" ItemStyle-Width="60%"  HeaderText="Tiêu đề" >
<ItemStyle Width="60%"></ItemStyle>
            </asp:BoundField>
           
            <asp:TemplateField HeaderText="" Visible="false">
                <ItemTemplate>
                    <asp:Label ID="lblCFMID1" runat="server" Text='<%#Eval("CFMID1") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
             <asp:BoundField DataField="UserName" ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center"   HeaderText="Nguoi Duyet" >
<ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="CFMDate0"  HeaderText="Ngày gửi" ItemStyle-HorizontalAlign="Center" DataFormatString="{0:dd/MM/yyyy}" >
<ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>
             <asp:BoundField DataField="pdmemovn1"   HeaderText="Y Kien" >
            </asp:BoundField>

            </Columns>
            <FooterStyle BackColor="White" ForeColor="#000066" />
            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
            <RowStyle ForeColor="#000066" />
            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#007DBB" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#00547E" />
        </asp:GridView>

    </div>

</asp:Content>
