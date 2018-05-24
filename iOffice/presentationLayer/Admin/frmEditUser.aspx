<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmEditUser.aspx.cs" Inherits="iOffice.presentationLayer.Admin.frmEditUser" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
   <%--<div style="margin: 0 auto; width: 800px;">
       <p><%=hasLanguege["lblSuaUser"].ToString() %></p>
         <table>
              <tr>
            <%=hasLanguege["lbNhanVien"] %></tr>
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
         </tr>
        <tr style="margin-top: 10px;">
           <td> <%=hasLanguege["lbBoPhan"] %></td>
            <td>
                <asp:CheckBox ID="checkthuocbophan" runat="server" Text="Thuộc bộ phận" AutoPostBack="True" OnCheckedChanged="checkthuocbophan_CheckedChanged"/></td>
            <td><asp:DropDownList ID="DropBoPhan" runat="server"></asp:DropDownList></td>
         </tr>
      
       
        <tr style="margin-top:10px">
           <td> <%=hasLanguege["lbMaNV"] %></td>
            <td><asp:TextBox ID="txtMaNV" runat="server" ReadOnly="True"></asp:TextBox></td></tr>
        <tr style="margin-top: 10px;">
          <td>  <%=hasLanguege["lbTenNV"] %></td>
            <td><asp:TextBox ID="txtTenNV" runat="server"></asp:TextBox></td></tr>
             <td>
                 </td>
        <tr>
            <td></td>
            <td>
                <asp:CheckBox ID="checkissep" runat="server" Text="Là người cán bộ" /></td>
        </tr>

          <tr>
             <td>
                 <%=hasLanguege["lbChucVu"] %></td>
             <td>
                 <asp:DropDownList ID="DropDownChucVu" runat="server"></asp:DropDownList></td>
         </tr>
          <tr>
              <td>
                  <%=hasLanguege["lbLaCanBoTT"] %></td>
              <td>
                  <asp:TextBox ID="txtNguoiQuanLyTT" runat="server"></asp:TextBox></td>
          </tr>
        
          <tr>
              <td>
                  <%=hasLanguege["lbmatkhau2"] %></td>
              <td>
                  <asp:TextBox ID="txtmatkhau2" runat="server" TextMode="Password"></asp:TextBox></td>
          </tr>
             <tr>
                 <td>Email</td>
                 <td>
                     <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox></td>
                   <td>
                     <asp:Label ID="lbthongbaoloi" runat="server" Text=""></asp:Label></td>
             </tr>
        <tr style="margin-top:10px ;">
          <td>  <%=hasLanguege["signatue"] %></td>
            <td>&nbsp;</td>
           <td> <asp:FileUpload ID="FileUpload1" runat="server" />
               <br />
            </td>
        </tr>
           
        </table>
       <asp:Button ID="btnEdit" runat="server" Text="Sửa" OnClick="btnEdit_Click" style="width: 39px; height: 26px;" />
    </div>--%>

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
            
         </tr>
        <tr style="margin-top: 10px;">
           <%--<td> <%=hasLanguege["lbBoPhan"] %></td>--%>
           
         </tr>
             </table>
         </div>
         <div id="divLeft" runat="server" style="width:400px;text-align:left;float:left; height: 142px;">
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
           <tr style="margin-top:10px ;">
              <td>  <%=hasLanguege["signatue"] %></td>
           
               <td> <asp:FileUpload ID="FileUpload1" runat="server" /></td>
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
       
              </table>
         </div>
    <div>
        <%--<p style="text-align:left; width:700px; margin-left:70px"> </p>--%>
       <%-- <table>
            <tr>
               <td style="width:100px"> <asp:Button ID="btnThem" runat="server" Text="Thêm" ValidationGroup="groupThem" OnClick="btnThem_Click" />    </td>
              <td>  <%=hasLanguege["lbTimKiem"] %></td>
               <td>
                   <asp:TextBox ID="txtTimKiem" runat="server" AutoPostBack="True" OnTextChanged="txtTimKiem_TextChanged" Height="22px"></asp:TextBox>
               </td>
               <td>
                   <asp:Button ID="btnTimKiem" runat="server" Text="Tìm kiếm" OnClick="btnTimKiem_Click" /></td>
           </tr>
        </table>--%>
        <p  style="width:800px; margin-left:100px; text-align:left; margin-bottom: 0px;"> <asp:Button ID="btnEdit" runat="server" Text="Sửa" OnClick="btnEdit_Click" style="width: 39px; height: 26px;" /></p>
           <p style="width:814px; margin-left:150px">
          <asp:Label ID="lbthongbaoloi" runat="server" Text=""></asp:Label>
      </p>    
    </div>
      
    </div>
    </form>
</body>
</html>
