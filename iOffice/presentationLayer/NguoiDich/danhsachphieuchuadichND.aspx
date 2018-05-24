<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMater/MyDocusND.Master" AutoEventWireup="true" CodeBehind="danhsachphieuchuadichND.aspx.cs" Inherits="iOffice.presentationLayer.NguoiDich.danhsachphieuchuadichND" %>
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
        <%--<asp:Label ID="lbPhieuchuadich" runat="server" Text="Danh sách phiếu chưa dịch"></asp:Label>--%>
      <%=hasLanguege["lbPhieuchuadich"] %>
    </p>
    <br />
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnRowDataBound="GridView1_RowDataBound" PageSize="30" OnRowDeleting="GridView1_RowDeleting" Width="98%">
        <Columns>
           <%-- <asp:BoundField DataField="pdno" >
            <HeaderStyle Width="80px" />

            </asp:BoundField>--%>
            <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="linkDeTails" runat="server" CommandName="Select" ><img src="../../Images/View.png" />
                                <asp:Label ID="lblDeTails" runat="server" Text=""></asp:Label>
                            </asp:LinkButton>
                        </ItemTemplate>
               </asp:TemplateField>
             <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="linkNoiDung" runat="server" CommandName="Delete" ><img src="../../Images/Up.png" />
                                <asp:Label ID="lblnoiDung" runat="server" Text=""></asp:Label>
                            </asp:LinkButton>
                        </ItemTemplate>
            </asp:TemplateField>
             <asp:TemplateField HeaderText="pdno">
                <ItemTemplate>
                    <asp:Label ID="lblPdno" runat="server" Text='<%#Eval("pdno") %>'></asp:Label>
                </ItemTemplate>
                 <ItemStyle HorizontalAlign="Center" />
                 <HeaderStyle HorizontalAlign="Center" />
            </asp:TemplateField>
            <asp:BoundField DataField="mytitle" HeaderStyle-HorizontalAlign="Center"  >
            
            <ItemStyle Width="50%" />
            </asp:BoundField>
            <asp:TemplateField HeaderText="UserID" Visible="false">
                <ItemTemplate>
                    <asp:Label ID="lblUserID" runat="server" Text='<%#Eval("CFMID0") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="USERNAME"   >
            <HeaderStyle HorizontalAlign="Center"  />
            <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="CFMDate0"   DataFormatString="{0:dd/MM/yyyy}" HeaderText="Date" >
           
            
            <HeaderStyle HorizontalAlign="Center" />
            <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
           <asp:TemplateField Visible="false">
               <ItemTemplate>
                   <asp:Label ID="lblYn" runat="server" Text='<%#Eval("Yn") %>'></asp:Label>
               </ItemTemplate>
           </asp:TemplateField>
              <asp:TemplateField Visible="false">
               <ItemTemplate>
                   <asp:Label ID="lblisPause" runat="server" Text='<%#Eval("isPause") %>'></asp:Label>
               </ItemTemplate>
           </asp:TemplateField>
        </Columns>
        <HeaderStyle BackColor="Tomato" CssClass="FixedHeader"></HeaderStyle>
    </asp:GridView>
</asp:Content>
