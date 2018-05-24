<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMater/AdminMaster.Master" AutoEventWireup="true" CodeBehind="frmBoPhan.aspx.cs" Inherits="iOffice.presentationLayer.Admin.frmBoPhan" %>
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
                width: 825,
                height: 600
            });
        }
</script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p><%=hasLanguege["lblDSDonVi"].ToString() %></p>
    <table  style="width:auto;  border-bottom-style: dotted; border-bottom-color: blue; border-bottom-width: thin;">
         <tr>
               <td><%=hasLanguege["GSBH"].ToString() %></td>
                 <td> <asp:DropDownList ID="DropCty" runat="server" AutoPostBack="True" Height="16px" OnSelectedIndexChanged="DropCty_SelectedIndexChanged1">
                <asp:ListItem Value="LTY"></asp:ListItem>
                
            </asp:DropDownList></td>
            <td>
               <%=hasLanguege["lbDonVi"].ToString() %></td>
            <td>
                <asp:DropDownList ID="DropDownBoPhan" runat="server"></asp:DropDownList></td>
            <td> <%=hasLanguege["lblLoaiDonVi"].ToString() %></td>
            <td>
                <asp:DropDownList ID="DropDownLoaiDonVi" runat="server"></asp:DropDownList></td>
           <td>
               <asp:Button ID="btnQuery" runat="server" Text="Query " OnClick="btnQuery_Click" /></td>
        </tr>
    </table>
    <table>
       
       
        <tr>
            <td>
                <%=hasLanguege["lblChuQuan"].ToString() %></td>
            <td>
                <asp:TextBox ID="txtChuQuan" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtChuQuan" ValidationGroup="groupThem" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td></td>
            <td>
                <asp:Button ID="btnLuu" runat="server" Text="Lưu" ValidationGroup="groupThem" OnClick="btnLuu_Click" /></td>
            
            <td>
                <asp:TextBox ID="txtTimkiem" runat="server" OnTextChanged="txtTimkiem_TextChanged" AutoPostBack="True"></asp:TextBox></td>
            <td>
                <asp:Button ID="btnTimKiem" runat="server" Text="Search" OnClick="btnTimKiem_Click" /></td>
            <td>
                <asp:Button ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click" /></td>
        </tr>
    </table>
    <p>
        <asp:Label ID="lblThongBao" runat="server" ForeColor="#FF3300"></asp:Label>
    </p>
    <div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnPageIndexChanging="GridView1_PageIndexChanging" OnSelectedIndexChanging="GridView1_SelectedIndexChanging" PageSize="20" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2" Width="800px">
            <Columns>
                <asp:TemplateField HeaderText="STT">
                    <ItemTemplate><%#GetSTT() %></ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Label ID="lblGSBH" runat="server" Text='<%#Eval("GSBH") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ID">
                    <ItemTemplate>
                        <asp:Label ID="lblID" runat="server" Text='<%#Eval("ID") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
              
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Label ID="lblDepName" runat="server" Text='<%#Eval("DepName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="" Visible="false">
                    <ItemTemplate>
                        <asp:Label ID="lblDepartmentTypeID" runat="server" Text='<%#Eval("DepartmentTypeID") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Label ID="lblDepartmentTypeNameTW" runat="server" Text='<%#Eval("DepartmentTypeNameTW") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                
                <asp:TemplateField Visible="false">
                    <ItemTemplate>
                        <asp:Label ID="lblIdUserChuQuan" runat="server" Text='<%#Eval("IdUserChuQuan") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Label ID="lblUSERNAME" runat="server" Text='<%#Eval("USERNAME") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:CommandField ShowSelectButton="True" HeaderText="Modify" SelectText="Modify" />
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
