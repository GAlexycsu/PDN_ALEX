<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmBUser.aspx.cs" Inherits="iOffice.presentationLayer.Admin.frmBUser" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="margin: 0 auto; width: 800px;">
        <div>
            <asp:Label ID="lbNhanVien" runat="server" Text="Danh mục nhân viên"></asp:Label></div>
        <div style="margin-top:10px">
            <asp:Label ID="lbCty" runat="server" Text="Công Ty"></asp:Label> &nbsp;<asp:DropDownList ID="DropCty" runat="server">
                <asp:ListItem Value="LTY"></asp:ListItem>
                <asp:ListItem>LBT</asp:ListItem>
                <asp:ListItem Value="LMY"></asp:ListItem>
                <asp:ListItem>LPM</asp:ListItem>
                <asp:ListItem Value="LYY"></asp:ListItem>
                <asp:ListItem Value="TST"></asp:ListItem>
            </asp:DropDownList></div>
        <div style="margin-top: 10px;">
            <asp:Label ID="lbBoPhan" runat="server" Text="Bộ Phận"></asp:Label>&nbsp;<asp:DropDownList ID="DropBoPhan" runat="server"></asp:DropDownList></div>
      
       
        <div style="margin-top:10px">
            <asp:Label ID="lbMaNV" runat="server" Text="Mã nhân viên"></asp:Label> &nbsp;<asp:TextBox ID="txtMaNV" runat="server"></asp:TextBox></div>
        <div style="margin-top: 10px;">
            <asp:Label ID="lbTenNV" runat="server" Text="Họ Tên"></asp:Label>&nbsp;<asp:TextBox ID="txtTenNV" runat="server"></asp:TextBox></div>
        <div style="margin-top:10px ;">
            <asp:Label ID="lbAnh" runat="server" Text="Ảnh"></asp:Label>&nbsp;<asp:Image ID="ImageNhanVien" runat="server" Height="57px" Width="105px" />
            <asp:FileUpload ID="FileUpload1" runat="server" />
        </div>
        
      
    </div>
        <div style="margin: 0 auto; width: 800px;">
            <asp:Button ID="btnThem" runat="server" Text="Thêm" OnClick="btnThem_Click" />
        &nbsp;<asp:Button ID="btnSua" runat="server" Text="Cập nhật" OnClick="btnSua_Click" />
&nbsp;<asp:Button ID="btnXoa" runat="server" Text="btnXoa" />

        </div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowUpdating="GridView1_RowUpdating" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowEditing="GridView1_RowEditing">
            <Columns>
                <asp:BoundField DataField="GSBH" HeaderText="Công Ty" />
                <asp:BoundField DataField="BADEPID" HeaderText="Bộ phận" />
                <asp:BoundField DataField="USERID" HeaderText="Mã nhân viên" />
                <asp:BoundField DataField="USERNAME" HeaderText="Họ tên" />
                <asp:BoundField DataField="signatue" HeaderText="Chữ ký" Visible="False" />
                <asp:TemplateField HeaderText="Sửa">
                    <ItemTemplate>
                        <a href='frmEditUser.aspx?USERID=<%#Eval("USERID") %>' OnClientClick="javascript:return confirm('Bạn có muốn sửa?');" >Sửa</a>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Xóa">
                    <ItemTemplate>
                    <%-- <a href='DeleteSP.aspx?ID=<%#Eval("IdSP") %>' OnClientClick="javascript:return confirm('Bạn có muốn xóa?');">Xóa</a>--%>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </form>
</body>
</html>
