<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMater/SiteUser.Master" AutoEventWireup="true" CodeBehind="frmTrinhKy.aspx.cs" Inherits="iOffice.presentationLayer.Users.frmTrinhKy" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
            <div>
            <table>
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text="Độ ưu tiên của phiếu"></asp:Label></td>
                    <td>
                        <asp:DropDownList ID="DropUutien" runat="server">
                            <asp:ListItem Selected="True" Value="1">Bình thường</asp:ListItem>
                            <asp:ListItem Value="2">Rất Gấp</asp:ListItem>
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td><asp:RadioButton ID="rdDungQuyTrinhMau" Text="Dùng quy trình mẫu" runat="server" /></td>
                </tr>
                <tr>
                    <td>
                        <asp:RadioButton ID="rdTaoMoiQuyTrinh" Text="Tạo quy trình mới" runat="server" /></td>

                </tr>
            </table>
        </div>
     
    <div>
        <asp:GridView ID="GridDSNguoiDuyet" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="GSBH" HeaderText="Công ty" />
                <asp:BoundField DataField="USERNAME" HeaderText="Nhân viên" />
                <asp:BoundField DataField="BADEPID" HeaderText="Bộ phận" />
                <asp:BoundField DataField="ABJOB" HeaderText="Chức vụ" />
                <asp:BoundField DataField="abstep" HeaderText="Bước duyệt" />
            </Columns>
        </asp:GridView>
        

    </div>
</asp:Content>
