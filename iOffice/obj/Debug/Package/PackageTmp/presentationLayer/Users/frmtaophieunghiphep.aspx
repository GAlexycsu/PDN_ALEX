<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMater/SiteUser.Master" AutoEventWireup="true" CodeBehind="frmtaophieunghiphep.aspx.cs" Inherits="iOffice.presentationLayer.Users.frmtaophieunghiphep" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width: 766px">
        <tr>
              
             <td> <asp:Label ID="lbCty" runat="server" Text="Công ty TNHH Tỷ Hùng 億 雄 責 任 有 限 公 司"></asp:Label></td>
        </tr>
        <tr>
            
            <td class="auto-style1">
                <asp:Label ID="lbLoaiPhieu" runat="server" Text="Loại Nghĩ:"></asp:Label><asp:DropDownList ID="DropLoaiNghi" runat="server"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td><asp:Label ID="lbTrinhBanLD" runat="server" Text="Trình ban lãnh đạo công ty TNHH Tỷ Hùng 呈亿雄公司主管部"></asp:Label> </td>
            
        </tr>
        <tr>
            <%--<td><%=hasLanguege["lbDonVi"].ToString() %></td>--%>
            <td>
                &nbsp;&nbsp;
                <asp:Label ID="lbDonVi" runat="server" Text="Đơn vị đề nghị 提议单位 :"></asp:Label> <asp:DropDownList ID="DropDonVi" runat="server"></asp:DropDownList>
                
            </td>
        </tr>
        <tr>
           <%-- <td><%=hasLanguege["lbTieuDe"].ToString() %></td>--%>
            <td> <asp:Label ID="lbTieuDe" runat="server" Text="Tiêu đề 题目: "></asp:Label><asp:TextBox ID="txtTieuDe" runat="server" Width="447px"></asp:TextBox> </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Số thẻ người nghĩ"></asp:Label></td>
          <td>
              <asp:TextBox ID="txtSoNguoiNghi" runat="server"></asp:TextBox></td>
            <td>
                <asp:Label ID="lblTenNguoiNghi" runat="server" Text=""></asp:Label></td>
        </tr>
        <tr>
              <td>
                <asp:Label ID="Label2" runat="server" Text="Số thẻ người thay thế"></asp:Label></td>
            <td>
                <asp:TextBox ID="txtSoTheThayThe" runat="server"></asp:TextBox></td>
            <td>
                <asp:Label ID="lblTenNguoiThayThe" runat="server" Text=""></asp:Label></td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label3" runat="server" Text="Lý Do"></asp:Label></td>
            <td>
                <asp:TextBox ID="txtLyDo" runat="server" TextMode="MultiLine" Width="167px"></asp:TextBox></td>
        </tr>
        <
    </table>
</asp:Content>
