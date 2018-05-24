<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMater/MyDocus.Master" AutoEventWireup="true" CodeBehind="DanhSachPhieuChuaDuyetBiTraVeCB.aspx.cs" Inherits="iOffice.presentationLayer.ApproveUser.DanhSachPhieuChuaDuyetBiTraVeCB" %>
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
                 height: 600
             });
         }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div>
         <asp:UpdatePanel ID="trave1" runat="server">
             <ContentTemplate>

           
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnRowDataBound="GridView1_RowDataBound">
            <Columns>
            <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="linkDeTails" runat="server" CommandName="Select" ><img src="../../Images/View.png" />
                                <asp:Label ID="lblDeTails" runat="server" Text=""></asp:Label>
                            </asp:LinkButton>
                        </ItemTemplate>
                       <ItemStyle Width="6%" />
                    </asp:TemplateField>
            <asp:BoundField DataField="pdno" ItemStyle-HorizontalAlign="Center" HeaderText="Mã phiếu" >
            </asp:BoundField>
            <asp:TemplateField Visible="false">
                <ItemTemplate>
                    <asp:Label ID="lblMaLoaiPhieu" runat="server" Text='<%#Eval("Abtype") %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="15%" />
            </asp:TemplateField>
            <asp:BoundField DataField="mytitle" ItemStyle-Width="40%" HeaderText="Tiêu đề" >
            </asp:BoundField>
           
            <asp:TemplateField HeaderText="" Visible="false">
                <ItemTemplate>
                    <asp:Label ID="lblCFMID1" runat="server" Text='<%#Eval("CFMID1") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
             <asp:BoundField DataField="UserName" ItemStyle-HorizontalAlign="Center" HeaderText="Nguoi Duyet" >
            </asp:BoundField>
            <asp:BoundField DataField="CFMDate0" ItemStyle-HorizontalAlign="Center" HeaderText="Ngày gửi" DataFormatString="{0:dd/MM/yyyy}" />
             <asp:BoundField DataField="pdmemovn1" ItemStyle-Width="30%" HeaderText="Y Kien" >
            </asp:BoundField>

            </Columns>
        </asp:GridView>
          </ContentTemplate>
             <Triggers>
                 <asp:AsyncPostBackTrigger ControlID="GridView1" />
             </Triggers>
         </asp:UpdatePanel>
    </div>
</asp:Content>
