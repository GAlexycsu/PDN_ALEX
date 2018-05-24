<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMater/AdminMaster.Master" AutoEventWireup="true" CodeBehind="frmNghiPhep.aspx.cs" Inherits="iOffice.presentationLayer.Admin.frmNghiPhep" %>
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
                width: 1010,
                height: 600
            });
        }
</script>



</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p><%=hasLanguege["lblVanMat"].ToString() %></p>
    <div style="width:auto;text-align:left">
       
             <table style="text-align:left;margin-left:50px; width: auto;">
        <tr>
            <td class="auto-style1">
                <%=hasLanguege["lbCty"].ToString() %></td>
            <td class="auto-style1"> <asp:DropDownList ID="DropCty" runat="server">
                <asp:ListItem Value="LTY"></asp:ListItem>
                <asp:ListItem>LBT</asp:ListItem>
                <asp:ListItem Value="LMY"></asp:ListItem>
                <asp:ListItem>LPM</asp:ListItem>
                <asp:ListItem Value="LYY"></asp:ListItem>
                <asp:ListItem Value="TST"></asp:ListItem>
            </asp:DropDownList></td>
        </tr>
        <tr>
            <td>
               <%=hasLanguege["lblTuNgay"].ToString() %>
            </td>
            <td>
                <asp:TextBox ID="txtFromDate" ClientIDMode="Static" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Ngày bắt đầu bắt buộc phải nhập" ControlToValidate="txtFromDate" ValidationGroup="groupThem" Text="*" ForeColor="Red"> 

                </asp:RequiredFieldValidator>
                <asp:RangeValidator ID="RangeValidator1" runat="server" ValidationGroup="grouThem" ControlToValidate="txtFromDate" Type="Date" MinimumValue="01-01-2000" MaximumValue="01-01-3000" ErrorMessage=""></asp:RangeValidator>
            </td>
            <td class="auto-style2">
                     <%=hasLanguege["lblDenNgay"].ToString() %>
                    </td>
                    <td>
                       <asp:TextBox ID="txtToDate" runat="server" ClientIDMode="Static" ></asp:TextBox>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Ngày bắt đầu bắt buộc phải nhập" ValidationGroup="groupThem" ControlToValidate="txtToDate" Text="*" ForeColor="Red"> 

                        </asp:RequiredFieldValidator>
                        <asp:RangeValidator ID="RangeValidator2" runat="server" ControlToValidate="txtToDate" Type="Date" MinimumValue="01-01-2000" MaximumValue="01-01-3000" ErrorMessage=""></asp:RangeValidator>

                    </td>
                    <td>
                        <asp:Button ID="btnQuery" runat="server" Text="Query" OnClick="btnQuery_Click" />
                        &nbsp;&nbsp;
                        <asp:Button ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click" />
            </td>

        </tr>
        <tr>
            <td>
                <%=hasLanguege["lblNguoiDuyet"].ToString() %>
            </td>
            <td>
                <asp:TextBox ID="txtNguoiDuyet" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtNguoiDuyet" ValidationGroup="groupThem" Text="*" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
              <td>
                <%=hasLanguege["lblMaNguoiDuocUyQuyen"].ToString() %>
              </td>
               <td>
                  <asp:TextBox ID="txtNguoiDuocUyQuyen" runat="server"></asp:TextBox>
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtNguoiDuocUyQuyen" ValidationGroup="groupThem" Text="*" ForeColor="Red"></asp:RequiredFieldValidator>
               </td>

        </tr>
        <tr>
            <td>
                <%=hasLanguege["lblKhiVangMat"].ToString() %>
            </td>
            <td>
                <asp:DropDownList ID="DropDownVangMat" runat="server"></asp:DropDownList></td>
        </tr>
    </table>
        
       
    </div>
   
    <p  style="text-align:center; width: 429px;"> <asp:Button ID="Button1" runat="server" Text="Lưu" ValidationGroup="groupThem" OnClick="Button1_Click" Width="64px" /></p>
    <p style="width:700px;text-align:left;margin-left:150px">
        <asp:Label ID="lblThongBao" runat="server" ForeColor="Red"></asp:Label></p>
    <div style="width: 1001px">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2" OnPageIndexChanging="GridView1_PageIndexChanging" PageSize="20" style="margin-top: 0px" Width="1000px" OnRowDeleting="GridView1_RowDeleting">
            <Columns>
                <asp:TemplateField Visible="false">
                    <ItemTemplate>
                        <asp:Label ID="lblID" runat="server" Text='<%#Eval("ID") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                
                <asp:TemplateField Visible="false">
                    <ItemTemplate>
                        <asp:Label ID="lblGSBH" runat="server" Text='<%#Eval("GSBH") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="TuNgay" HeaderText="Từ ngày" DataFormatString="{0:dd/MM/yyyy}" />
                <asp:BoundField DataField="DenNgay" HeaderText="Đến ngày" DataFormatString="{0:dd/MM/yyyy}" />
                <asp:BoundField DataField="IDNguoiDuyet" HeaderText="Mã Người Ủy Quyền" />
                <asp:BoundField DataField="tennguoiuyquyen" HeaderText="Người Duyệt" />
                <asp:BoundField DataField="IDNguoiDuocUyQuyen" HeaderText="Mã Người Được Ủy Quyền" />
                <asp:BoundField DataField="tennguoithaythe" HeaderText="Tên Người Được Ủy Quyền" />
                <asp:TemplateField Visible="false">
                    <ItemTemplate>
                        <asp:Label ID="lblThongQua" runat="server" Text='<%#Eval("ThongQua") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="TenThongQua" />
                <asp:CommandField ShowSelectButton="True" SelectText="Modify"  HeaderText="Modify"/>
                 
                <asp:TemplateField HeaderText="Delete">
                    
                            <ItemTemplate> 
                                <asp:Button ID="Button1" runat="server" CommandName="Delete" Text="Delete"  
                                    onclientclick="return confirm('Are you sure you want to delete this event?');" /> 
                            </ItemTemplate> 
                </asp:TemplateField>
                 
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
