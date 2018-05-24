<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="test3.aspx.cs" Inherits="iOffice.presentationLayer.Users.test3" %>

<%@ Register assembly="DevExpress.Web.v13.1, Version=13.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxTreeView" tagprefix="dx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text="Độ ưu tiên của phiếu"></asp:Label></td>
                    <td>
                        <asp:DropDownList ID="DropUutien" runat="server"></asp:DropDownList></td>
                </tr>
            </table>
        </div>
    <div>
        <table>
            <tr>
                <td>
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" HeaderStyle-BackColor="#3AC0F2" HeaderStyle-ForeColor="White" OnSelectedIndexChanged="OnSelectedIndexChanged">
                    <Columns>
                                <asp:BoundField DataField="USERID" HeaderText="Mã NV" ItemStyle-Width="30">
                     <ItemStyle Width="30px"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="USERNAME" HeaderText="Tên NV" ItemStyle-Width="150">
                    <ItemStyle Width="150px"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="BADEPID" HeaderText="Bộ phận" />
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkSelect" runat="server" CommandName="Select" Text="Select" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>

                    <HeaderStyle BackColor="#3AC0F2" ForeColor="White"></HeaderStyle>
                    </asp:GridView>
                </td>
                <td>
                     <asp:TreeView ID="TreeView1" runat="server">
                        <Nodes>
                            <asp:TreeNode Text="Danh Sach Nguoi Duyet" Value="Danh Sach Nguoi Duyet"></asp:TreeNode>
                         </Nodes>
                    </asp:TreeView>
                </td>
            </tr>
        </table>
    </div>
        <div>
           
        
        </div>
        <asp:Button ID="btnTrinhDuyet" runat="server" OnClick="btnTrinhDuyet_Click" Text="Tạo Phiếu Và Trình Duyệt" />&nbsp;&nbsp; <asp:Button ID="btnLuu" runat="server" Text="Lưu Tạm" />
        <br />
        <br />
        <asp:Label ID="LbThongBao" runat="server" Text=""></asp:Label>
        <br />
        <asp:RadioButton ID="RadioButton1" GroupName="gri" runat="server" Checked="True" />
        &nbsp;<asp:RadioButton ID="RadioButton2" GroupName="gri" runat="server" />
        &nbsp;<asp:RadioButton ID="RadioButton3" GroupName="gri" runat="server" />
    </form>
</body>
</html>
