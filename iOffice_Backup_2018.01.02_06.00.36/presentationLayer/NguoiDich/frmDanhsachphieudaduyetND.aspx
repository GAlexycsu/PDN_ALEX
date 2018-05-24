<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMater/MyDocusND.Master" AutoEventWireup="true" CodeBehind="frmDanhsachphieudaduyetND.aspx.cs" Inherits="iOffice.presentationLayer.NguoiDich.frmDanhsachphieudaduyetND" %>
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
                 width: 870,
                 height: 600
             });
         }
</script>
<script type="text/javascript">
    $(document).ready(function () {
        gridviewScroll1();
    });

    function gridviewScroll1() {
        $('#<%=GridView2.ClientID%>').gridviewScroll({
            width: 870,
            height: 600
        });
    }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        <asp:Label ID="Label1" runat="server" Text="Danh sách phiếu đã duyệt 已经审核名单"></asp:Label></p>
    <div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnRowDataBound="GridView1_RowDataBound" OnPageIndexChanging="GridView1_PageIndexChanging" PageSize="25" Width="1070px">
            <Columns>
                <%--<asp:BoundField DataField="abtype" />--%>
                <asp:TemplateField ShowHeader="false">
                    <ItemTemplate>
                        <asp:Label ID="lblMaLoaiPhieu" runat="server" Text='<%#Eval("abtype") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="abname" />
                <asp:BoundField DataField="pdno" />
                <asp:BoundField DataField="mytitle" />
                <asp:BoundField DataField="YnName" />
                <asp:BoundField DataField="NameABC" />
                <asp:BoundField DataField="USERNAME" />
                <asp:TemplateField ShowHeader="false">
                    <ItemTemplate>
                        <asp:Label ID="lblMaDV" runat="server" Text='<%#Eval("ID") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="DepName" />
               
                <asp:CommandField ShowSelectButton="True" />

            </Columns>
            <HeaderStyle BackColor="Tomato" CssClass="FixedHeader"></HeaderStyle>
        </asp:GridView>
         <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="GridView2_SelectedIndexChanged" OnRowDataBound="GridView2_RowDataBound" OnPageIndexChanging="GridView2_PageIndexChanging" PageSize="25" Width="1070px">
            <Columns>
                <asp:TemplateField HeaderText="" ShowHeader="false">
                    <ItemTemplate>
                        <asp:Label ID="lblMaLoaiPhieu" runat="server" Text='<%#Eval("abtype") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="abnameTW" />
                <asp:BoundField DataField="pdno" />
                <asp:BoundField DataField="mytitle" />
                <asp:BoundField DataField="YnNameTW" />
                <asp:BoundField DataField="NameABCTW" />
                <asp:BoundField DataField="USERNAME" />
                <asp:TemplateField ShowHeader="false">
                    <ItemTemplate>
                        <asp:Label ID="lblMaDV" runat="server" Text='<%#Eval("ID") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:BoundField DataField="DepName" />
                
                <asp:CommandField ShowSelectButton="True" />
            </Columns>
             <HeaderStyle BackColor="Tomato" CssClass="FixedHeader"></HeaderStyle>
        </asp:GridView>
    </div>
</asp:Content>
