<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMater/AdminMaster.Master" AutoEventWireup="true" CodeBehind="frmAddUsers.aspx.cs" Inherits="iOffice.presentationLayer.Admin.frmAddUsers" %>
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
                width: 1030,
                height: 600
            });
        }
</script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
     <div style="margin: 0 auto; width: 800px;">
         <p>
             <%=hasLanguege["lbNhanVien"].ToString() %></p>
         <div style="width:700px;">
             <table  style="width:auto;  border-bottom-style: dotted; border-bottom-color: blue; border-bottom-width: thin;">
                  <tr style="margin-top:10px">
           <td> <%=hasLanguege["lbCty1"] %></td>
            <td> <asp:DropDownList ID="DropCty" runat="server">
                <asp:ListItem Value="LTY"></asp:ListItem>
                <asp:ListItem>LBT</asp:ListItem>
                <asp:ListItem Value="LMY"></asp:ListItem>
                <asp:ListItem>LPM</asp:ListItem>
                <asp:ListItem Value="LYY"></asp:ListItem>
                <asp:ListItem Value="TST"></asp:ListItem>
            </asp:DropDownList></td>
             <td>
                <asp:CheckBox ID="checkBophan" runat="server" Text="Thuộc bộ phận" AutoPostBack="True" OnCheckedChanged="checkBophan_CheckedChanged" /></td>
            <td><asp:DropDownList ID="DropBoPhan" runat="server"></asp:DropDownList></td>
            <td>
                <asp:Button ID="btnQuery" runat="server" Text="Query" OnClick="btnQuery_Click" style="height: 26px; width: 53px" /></td>
         </tr>
        <tr style="margin-top: 10px;">
           <%--<td> <%=hasLanguege["lbBoPhan"] %></td>--%>
           
         </tr>
             </table>
         </div>
         <div id="divLeft" runat="server" style="width:400px;text-align:left;float:left">
                  <table>

        <tr style="margin-top:10px">
           <td> <%=hasLanguege["lbMaNV"] %></td>
           
            <td class="auto-style2"><asp:TextBox ID="txtMaNV" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="" ControlToValidate="txtMaNV" ForeColor="Red" Text="*" ValidationGroup="groupThem"></asp:RequiredFieldValidator>
            </td></tr>
        <tr style="margin-top: 10px;">
          <td>  <%=hasLanguege["lbTenNV"] %></td>
            
            <td><asp:TextBox ID="txtTenNV" runat="server" Height="22px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="" ControlToValidate="txtTenNV" ForeColor="Red" Text="*" ValidationGroup="groupThem"></asp:RequiredFieldValidator>
            </td></tr>
         <tr>
             <td class="auto-style2">
                 <%=hasLanguege["lbChucVu"] %></td>
             <td class="auto-style2">
                 <asp:DropDownList ID="DropDownChucVu" runat="server"></asp:DropDownList></td>
         </tr>
             <tr>
                 <td>
                     <%=hasLanguege["lblLaCanBo"] %>
                 </td>
                 <td>
                     <asp:CheckBox ID="checkCanBo" runat="server" OnCheckedChanged="checkCanBo_CheckedChanged" /></td>
             </tr>
       
           
        </table>
         </div>
          <div id="div1" runat="server" style="width:400px;text-align:left;float:right">
              <table>
                     <tr>
              <td>
                  <%=hasLanguege["lbLaCanBoTT"] %></td>
              <td>
                  <asp:TextBox ID="txtNguoiQuanLyTT" runat="server"></asp:TextBox>
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtNguoiQuanLyTT" ValidationGroup="groupThem" Text="*" ForeColor="Red"></asp:RequiredFieldValidator>
              </td>
          </tr>
         <tr>
             <td>
                 <%=hasLanguege["lbmatkhau1"] %></td>
             <td>
                 <asp:TextBox ID="txtmatkhau" runat="server"></asp:TextBox>
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtmatkhau" ValidationGroup="groupThem" Text="*" ForeColor="Red"></asp:RequiredFieldValidator>
             </td>
         </tr>
          <tr>
              <td>
                  <%=hasLanguege["lbmatkhau2"] %></td>
                 
              <td>
                  <asp:TextBox ID="txtmatkhau2" runat="server"></asp:TextBox>
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtmatkhau2" ValidationGroup="groupThem" Text="*" ForeColor="Red"></asp:RequiredFieldValidator>
              </td>
          </tr>
            <tr>
                 <td>Email</td>
                 <td>
                     <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtEmail" ValidationGroup="groupThem" Text="*" ForeColor="Red"></asp:RequiredFieldValidator>
                 </td>
                 
             </tr>
        <tr style="margin-top:10px ;">
          <td>  <%=hasLanguege["signatue"] %></td>
           
           <td> <asp:FileUpload ID="FileUpload1" runat="server" /></td>
        </tr>
              </table>
         </div>
    <div>
        <%--<p style="text-align:left; width:700px; margin-left:70px"> </p>--%>
        <table>
            <tr>
               <td style="width:100px"> <asp:Button ID="btnThem" runat="server" Text="Thêm" ValidationGroup="groupThem" OnClick="btnThem_Click" />    </td>
              <td>  <%=hasLanguege["lbTimKiem"] %></td>
               <td>
                   <asp:TextBox ID="txtTimKiem" runat="server" AutoPostBack="True" OnTextChanged="txtTimKiem_TextChanged" Height="22px"></asp:TextBox>
               </td>
               <td>
                   <asp:Button ID="btnTimKiem" runat="server" Text="Tìm kiếm" OnClick="btnTimKiem_Click" /></td>
           </tr>
        </table>
    </div>
      
    </div>
      
      <p style="width:814px; margin-left:150px">
          <asp:Label ID="lbthongbaoloi" runat="server" Text=""></asp:Label>
      </p>      

    <div style="width:1000px">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnPageIndexChanging="GridView1_PageIndexChanging"  OnSelectedIndexChanged="GridView1_SelectedIndexChanged1" BackColor="#DEBA84" BorderColor="#DEBA84" CellPadding="3" CellSpacing="2" Width="999px">
            <Columns>
                <asp:TemplateField HeaderText="">
                    <ItemTemplate>
                        <asp:Label ID="lblGSBH" runat="server" Text='<%#Eval("GSBH") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField Visible="false" HeaderText="">
                    <ItemTemplate>
                        <asp:Label ID="lblBADEPID" runat="server" Text='<%#Eval("BADEPID") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Label ID="lblDepName" runat="server" Text='<%#Eval("DepName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="">
                    <ItemTemplate>
                        <asp:Label ID="lblUSERID" runat="server" Text='<%#Eval("USERID") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="">
                    <ItemTemplate>
                        <asp:Label ID="lblUSERNAME" runat="server" Text='<%#Eval("USERNAME") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField Visible="false" HeaderText="">
                    <ItemTemplate>
                        <asp:Label ID="lblIDChucVu" runat="server" Text='<%#Eval("IDChucVu") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="">
                    <ItemTemplate>
                        <asp:Label ID="lblTenChucVu" runat="server" Text='<%#Eval("TenChucVu") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="">
                    <ItemTemplate>
                        <asp:Label ID="lblTenChucVuTiengHoa" runat="server" Text='<%#Eval("TenChucVuTiengHoa") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="" Visible="false">
                    <ItemTemplate>
                        <asp:Label ID="lblIDCapDuyet" runat="server" Text='<%#Eval("IDCapDuyet") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField> 
                <asp:TemplateField HeaderText="">
                    <ItemTemplate>
                        <asp:Label ID="lblIdUserQuanLyTT" runat="server" Text='<%#Eval("IdUserQuanLyTT") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
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
