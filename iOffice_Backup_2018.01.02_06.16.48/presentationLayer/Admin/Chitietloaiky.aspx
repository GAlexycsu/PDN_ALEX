<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMater/SiteAddmin.Master" AutoEventWireup="true" CodeBehind="Chitietloaiky.aspx.cs" Inherits="iOffice.presentationLayer.Admin.Chitietloaiky" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
          <table>
              <tr style="margin-top:10px">
      <%--     <td> <%=hasLanguege["lbCty"] %></td>--%>
                  <td></td>
            <td> <asp:DropDownList ID="DropCty" runat="server">
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
                <asp:Label ID="Label1" runat="server" Text="Loại phiếu"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="DropDownLoaiPhieu" runat="server"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label2" runat="server" Text="Bước ký"></asp:Label>
            </td>
            <td style="width:15px;">
                <asp:TextBox ID="txtBuocky" runat="server"></asp:TextBox></td>
            <td>
                <asp:TextBox ID="txtNhomKy" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>
                <asp:RadioButton ID="rbKyToanBo" runat="server" GroupName="group1" Text="Ký toàn bộ" />
            </td>
            <td>
                 <asp:RadioButton ID="rbChiCan1nguoi" runat="server" GroupName="group1"  Text="Chỉ cần 1 người ký"/>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnLuu" runat="server" Text="Lưu" OnClick="btnLuu_Click" /></td>
        </tr>
    </table>
    </div>
  <div>
      <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
          <Columns>
              <asp:CommandField ShowDeleteButton="True" />
              <asp:CommandField ShowEditButton="True" />
              <asp:CommandField ShowSelectButton="True" />
              <asp:BoundField DataField="IDChiTiet" HeaderText="ID" />
              <asp:BoundField DataField="abtype" HeaderText="mã loại phiếu" />
              <asp:BoundField DataField="abstep" HeaderText="Bước ký" />
              <asp:BoundField DataField="Nhom" HeaderText="Nhóm ký" />
              <asp:BoundField DataField="KyToanBo" HeaderText="Ký toàn bộ" />
          </Columns>
      </asp:GridView>
  </div>
</asp:Content>
