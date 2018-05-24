<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMater/MyDocus.Master" AutoEventWireup="true" CodeBehind="danhsachphieudaduyetNV.aspx.cs" Inherits="iOffice.presentationLayer.Users.danhsachphieudaduyetNV" %>
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
                 width:'100%',
                 height: 600
             });
         }
</script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--  <p><%=hasLanguege["lbDSPhieuDaDuyet"] %></p>--%>

    <p>
        <asp:Label ID="Label1" runat="server" Text="Danh sách phiếu đã duyệt 已经审核名单"></asp:Label></p>
    <div style="margin-left:10px">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"  OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnRowDataBound="GridView1_RowDataBound" PageSize="25" Width="99%">
            <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="linkDeTails" runat="server" CommandName="Select" ><img src="../../Images/View.png" />
                                <asp:Label ID="lblDeTails" runat="server" Text=""></asp:Label>
                            </asp:LinkButton>
                        </ItemTemplate>
                         <ItemStyle Width="6%" />
                    </asp:TemplateField>
                <asp:TemplateField Visible="false">
                    <ItemTemplate>
                        <asp:Label ID="lblMaLoaiPhieu" runat="server" Text='<%#Eval("abtype") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="abname" ItemStyle-Width="20%"  />
                <asp:BoundField DataField="pdno" ItemStyle-Width="7%" ItemStyle-HorizontalAlign="Center"   />
                <asp:BoundField DataField="mytitle" ItemStyle-Width="30%" />
                <asp:BoundField DataField="YnName"  ItemStyle-Width="7%" ItemStyle-HorizontalAlign="Center"   />
                <asp:BoundField DataField="NameABC"  ItemStyle-Width="7%" ItemStyle-HorizontalAlign="Center"   />
                <asp:BoundField DataField="USERNAME"  />
                <asp:TemplateField Visible="false">
                    <ItemTemplate>
                        <asp:Label ID="lblMaDV" runat="server" Text='<%#Eval("ID") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="DepName" />
               
               

            </Columns>
            <HeaderStyle BackColor="#6699ff" CssClass="FixedHeader"></HeaderStyle>
        </asp:GridView>
         
    </div>

</asp:Content>
