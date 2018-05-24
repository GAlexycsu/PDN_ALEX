<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm4.aspx.cs" Inherits="iOffice.presentationLayer.Users.WebForm4" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 150px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <table style="width:800px" >
         <tr>
             <td style="text-align:left">
                 <asp:Label ID="Label1" runat="server" Text="Công ty TNHH Tỷ Hùng 億 雄 責 任 有 限 公 司"></asp:Label>
             </td>
             <td style="text-align:center">
                 <asp:Label ID="Label2" runat="server" Text="Đơn Xin Nghĩ"></asp:Label>
             </td>
         </tr>
     </table>
        <table style="width:800px; border: 1px solid red">
            <tr>
                <td class="auto-style1">
                    <asp:Label ID="lblHoVaTen" runat="server" Text="Họ và tên"></asp:Label></td>
                <td style="width:250px">
                    <asp:Label ID="lblHTHoVaTen" runat="server" Text="Cao Văn Tuấn"></asp:Label></td>
                <td style="width:150px">
                    <asp:Label ID="lblDonVi" runat="server" Text="Đơn Vị"></asp:Label></td>
                <td >
                    <asp:Label ID="lblHTDonVi" runat="server" Text="IT"></asp:Label></td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <asp:Label ID="Label3" runat="server" Text="Loại Nghĩ"></asp:Label>
                </td>
                 <td>
                    <asp:Label ID="lblLoaiNghi" runat="server" Text="RO"></asp:Label>
                </td>
                 <td>
                    <asp:Label ID="Label5" runat="server" Text="Label"></asp:Label>
                </td>
                 <td>
                    <asp:Label ID="Label6" runat="server" Text="Người thay thế"></asp:Label>
                     
                </td>
                 <td>
                    <asp:Label ID="lblNguoiThayThe" runat="server" Text="Huy"></asp:Label>
                </td>
                
            </tr>
            <tr>
                <td class="auto-style1">
                    <asp:Label ID="Label4" runat="server" Text="Lý do"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblLyDo" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <table>
                        <tr>
                            <td>Thời gian nghĩ</td>
                            <td>
                                <asp:Label ID="lblNamVN" runat="server" Text=""></asp:Label></td>
                            <td>Năm</td>
                            <td>
                                <asp:Label ID="lblThangVN" runat="server" Text=""></asp:Label></td>
                            <td>Tháng</td>
                            <td>
                                <asp:Label ID="lblNgayVN" runat="server" Text=""></asp:Label></td>
                            <td>Ngày</td>
                            <td>
                                <asp:Label ID="lblGioVN" runat="server" Text=""></asp:Label></td>
                            <td>Đến</td>
                            <td>
                                <asp:Label ID="lblDenThang" runat="server" Text=""></asp:Label></td>
                            <td>Tháng</td>
                            <td>
                                <asp:Label ID="lblNgay" runat="server" Text=""></asp:Label></td>
                            <td>Ngày</td>
                            <td>
                                <asp:Label ID="lblGioVN1" runat="server" Text=""></asp:Label></td>
                            <td>Giờ ngưng</td>
                            <td>
                                Tổng cộng</td>
                            <td>
                                <asp:Label ID="lblNgayNgung" runat="server" Text=""></asp:Label></td>
                            <td>Ngày</td>
                            <td>
                                <asp:Label ID="lblGioNgung" runat="server" Text=""></asp:Label></td>
                        </tr>
                         <tr>
                            <td>Thời gian nghĩ</td>
                            <td>
                                <asp:Label ID="Label7" runat="server" Text=""></asp:Label></td>
                            <td>Năm</td>
                            <td>
                                <asp:Label ID="Label8" runat="server" Text=""></asp:Label></td>
                            <td>Tháng</td>
                            <td>
                                <asp:Label ID="Label9" runat="server" Text=""></asp:Label></td>
                            <td>Ngày</td>
                            <td>
                                <asp:Label ID="Label10" runat="server" Text=""></asp:Label></td>
                            <td>Đến</td>
                            <td>
                                <asp:Label ID="Label11" runat="server" Text=""></asp:Label></td>
                            <td>Tháng</td>
                            <td>
                                <asp:Label ID="Label12" runat="server" Text=""></asp:Label></td>
                            <td>Ngày</td>
                            <td>
                                <asp:Label ID="Label13" runat="server" Text=""></asp:Label></td>
                            <td>Giờ ngưng</td>
                            <td>
                                Tổng cộng</td>
                            <td>
                                <asp:Label ID="Label14" runat="server" Text=""></asp:Label></td>
                            <td>Ngày</td>
                            <td>
                                <asp:Label ID="Label15" runat="server" Text=""></asp:Label></td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <table>
                        <tr>
                            <td>
                                <asp:Label ID="Label16" runat="server" Text="Điền đơn"></asp:Label></td>
                            <td>
                                <asp:Label ID="Label17" runat="server" Text="Label"></asp:Label></td>
                            <td>
                                <asp:Label ID="Label18" runat="server" Text="Năm"></asp:Label></td>
                            <td>
                                <asp:Label ID="Label19" runat="server" Text="Label"></asp:Label></td>
                            <td>
                                <asp:Label ID="Label20" runat="server" Text="Tháng"></asp:Label></td>
                            <td>
                                <asp:Label ID="Label21" runat="server" Text="Label"></asp:Label></td>
                            <td>
                                <asp:Label ID="Label22" runat="server" Text="Ngày"></asp:Label></td>
                        </tr>
                    </table>
                </td>
                <td>
                    <table>
                        <tr>
                            <td>Người điền đơn</td>
                           <td> <asp:Label ID="lblNguoiDienDon" runat="server" Text="Label"></asp:Label></td>
                        </tr>
                         <tr>
                            <td>Người điền đơn</td>
                           <td> <asp:Label ID="lblNguoiDienDonTW" runat="server" Text="Label"></asp:Label></td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">Ghi Chú</td>
                <td>
                    <asp:Label ID="lblGhiChu" runat="server" Text="Ghi Chú"></asp:Label></td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
