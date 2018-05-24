<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMater/AdminMaster.Master" AutoEventWireup="true" CodeBehind="FDanhSachLoaiPhieu.aspx.cs" Inherits="iOffice.presentationLayer.Admin.FDanhSachLoaiPhieu" %>
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
                width: 700,
                height: 600
            });
        }
</script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p><%=hasLanguege["dsloaiphieu"].ToString() %>
        </p>
    <table style="margin-left:20px">
        <tr>
            <td>
                 <%=hasLanguege["idloai"].ToString() %>
            </td>
            <td>
                <asp:TextBox ID="txtMaLoai" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtMaLoai" ValidationGroup="groupThem" Text="*" ForeColor="Red" ErrorMessage=""></asp:RequiredFieldValidator>
            </td>
        </tr>
          <tr>
            <td>
                 <%=hasLanguege["tentiengviet"].ToString() %>
            </td>
            <td>
                <asp:TextBox ID="txtTenLoaiVN" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTenLoaiVN" Text="*" ForeColor="Red" ValidationGroup="groupThem" ErrorMessage=""></asp:RequiredFieldValidator>
            </td>
        </tr>
          <tr>
            <td>
                <%=hasLanguege["tentienghoa"].ToString() %>
            </td>
            <td>
                <asp:TextBox ID="txtTenLoaiTW" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtTenLoaiTW" Text="*" ForeColor="Red" ValidationGroup="groupThem" ErrorMessage=""></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="Button1" runat="server" Text="Save" ValidationGroup="groupThem" OnClick="Button1_Click" />
            </td>
        </tr>
    </table>
    <p>
        <asp:Label ID="lblThongBao" runat="server" Text=""></asp:Label>
    </p>
    <div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowDeleting="GridView1_RowDeleting" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" DataKeyNames="abtype" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2" Width="700px">
            <Columns>
                <asp:CommandField SelectText="Modify" ShowSelectButton="True" HeaderText="Modify" />
               <asp:TemplateField HeaderText="Delete">
                    
                            <ItemTemplate> 
                                <asp:Button ID="Button1" runat="server" CommandName="Delete" Text="Delete"  
                                    onclientclick="return confirm('Are you sure you want to delete this event?');" /> 
                            </ItemTemplate> 
                </asp:TemplateField>
                <asp:BoundField DataField="abtype" />
                <asp:BoundField DataField="abname" />
                <asp:BoundField DataField="abnameTW" />
            </Columns>
            <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
            <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
            <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
            <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
            <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#FFF1D4" />
            <SortedAscendingHeaderStyle BackColor="#B95C30" />
            <SortedDescendingCellStyle BackColor="#F1E5CE" />
            <SortedDescendingHeaderStyle BackColor="#93451F" />
        </asp:GridView>
    </div>
</asp:Content>
