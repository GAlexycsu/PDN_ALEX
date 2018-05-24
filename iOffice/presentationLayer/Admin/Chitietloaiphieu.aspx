<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMater/SiteAddmin.Master" AutoEventWireup="true" CodeBehind="Chitietloaiphieu.aspx.cs" Inherits="iOffice.presentationLayer.Admin.Chitietloaiphieu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   
    <script src="../../Scripts/jquery-1.7.1.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery-ui-1.8.20.js" type="text/javascript"></script>
    <script>
        $(function () {
            $("#txtNgayBatDau").datepicker();
            $("#txtNgayKT").datepicker();
        });
  </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
    </div>
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
                <asp:Label ID="Label3" runat="server" Text="Nhóm"></asp:Label></td>
            <td>
                <asp:TextBox ID="txtNhom" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Ngày bắt đầu"></asp:Label></td>
            <td>
                <asp:TextBox ID="txtNgayBatDau" runat="server" ClientIDMode="Static"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtNgayBatDau"
                ErrorMessage="Ngày bắt đầu bắt buộc nhập" Text="*" ForeColor="Red"
                    ></asp:RequiredFieldValidator>
                <asp:RangeValidator ID="RangeValidator1" ControlToValidate="txtNgayBatDau"
                    Type="Date" MinimumValue="01-01-2000" MaximumValue="01-01-3000"
                     runat="server" ErrorMessage="Ngày nhập không đúng định dạng" Text="*" ForeColor="Red">

                </asp:RangeValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label2" runat="server" Text="Ngày kết thúc"></asp:Label></td>
            <td>
                <asp:TextBox ID="txtNgayKT" runat="server" ClientIDMode="Static"></asp:TextBox></td>
        </tr>
        <tr>
            <td>
                <asp:CheckBox ID="cbThongQua" runat="server" Text="Thông qua đơn vị IT" AutoPostBack="True" OnCheckedChanged="cbThongQua_CheckedChanged"/></td>
            <td>
                <asp:DropDownList ID="DropDownBoPhan" runat="server" AutoPostBack="True">
                    <asp:ListItem Value="CDV">Chọn đơn vị</asp:ListItem>
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label4" runat="server" Text="Người ký"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="DropDownNguoiKy" runat="server" OnSelectedIndexChanged="DropDownNguoiKy_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
             <td>
                 <asp:Label ID="Label5" runat="server" Text="Chức vụ"></asp:Label>
             </td>
            <td>
                <asp:DropDownList ID="DropDownChucvu" runat="server">
                    <asp:ListItem Value="CCV">Chọn chức vụ</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label6" runat="server" Text="Người cố định"></asp:Label></td>
            <td>
                <asp:TextBox ID="txtNguoicodinh" runat="server"></asp:TextBox></td>
          <td>
                <asp:Label ID="lbNguoiCoDinh" runat="server" Text=""></asp:Label></td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnLuu" runat="server" Text="Lưu" OnClick="btnLuu_Click" />
            </td>
            <td>
                <asp:Button ID="btnQuaylai" runat="server" Text="Back" OnClick="btnQuaylai_Click" />
            </td>
        </tr>
    </table>
    </div>
    <div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="IDChiTiet" HeaderText="ID" />
                <asp:BoundField DataField="abtype" HeaderText="Loại phiếu" />
                <asp:BoundField DataField="NgayBatdau" HeaderText="Ngày bắt đầu" />
                <asp:BoundField DataField="NgayKetThuc" HeaderText="Ngày kết thúc" />
                <asp:BoundField DataField="DonViThongQua" HeaderText="Đơn vị thông qua" />
                <asp:BoundField DataField="IDNguoiKy" HeaderText="Người ký" />
                <asp:BoundField DataField="IDChucVu" HeaderText="Chức vụ" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
