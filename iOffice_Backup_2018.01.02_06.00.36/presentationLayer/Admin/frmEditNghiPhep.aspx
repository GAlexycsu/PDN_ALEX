<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMater/AdminMaster.Master" AutoEventWireup="true" CodeBehind="frmEditNghiPhep.aspx.cs" Inherits="iOffice.presentationLayer.Admin.frmEditNghiPhep" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link href="../../Style/jquery-ui.css" rel="stylesheet" />
    <script src="../../Scripts/jquery-1.7.1.js"></script>
    <script src="../../Scripts/jquery-ui.js"></script>
    <script src="../../Scripts/NgayThang.js"></script>
    <script src="../../Scripts/NgayNghi.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p style="margin-left:200px; width:auto"><%=hasLanguege["lblsuanghiphep"].ToString() %></p>
    <table style="margin-left:200px; width:auto">
        <tr>
            <td>
                <%=hasLanguege["lbCty"].ToString() %></td>
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
               <%=hasLanguege["lblTuNgay"].ToString() %>
            </td>
            <td>
                <asp:TextBox ID="txtTuNgay" ClientIDMode="Static" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Ngày bắt đầu bắt buộc phải nhập" ControlToValidate="txtTuNgay" Text="*" ForeColor="Red"> 

                </asp:RequiredFieldValidator>
                <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtTuNgay" Type="Date" MinimumValue="01-01-2000" MaximumValue="01-01-3000" ErrorMessage=""></asp:RangeValidator>
            </td>
             <td>
                 <%=hasLanguege["lblDenNgay"].ToString() %>
            </td>
            <td>
                <asp:TextBox ID="txtDenNgay" ClientIDMode="Static" runat="server"></asp:TextBox>
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Ngày bắt đầu bắt buộc phải nhập" ControlToValidate="txtDenNgay" Text="*" ForeColor="Red"> 

                </asp:RequiredFieldValidator>
                <asp:RangeValidator ID="RangeValidator2" runat="server" ControlToValidate="txtDenNgay" Type="Date" MinimumValue="01-01-2000" MaximumValue="01-01-3000" ErrorMessage=""></asp:RangeValidator>
            </td>

        </tr>
        <tr>
            <td>
                <%=hasLanguege["lblNguoiDuyet"].ToString() %>
            </td>
            <td>
                <asp:TextBox ID="txtNguoiDuyet" runat="server"></asp:TextBox></td>
             <td>
                 <%=hasLanguege["lblMaNguoiDuocUyQuyen"].ToString() %>
            </td>
            <td>
                <asp:TextBox ID="txtNguoiDuocUyQuyen" runat="server"></asp:TextBox></td>

        </tr>
        <tr>
            <td>
                <%=hasLanguege["lblKhiVangMat"].ToString() %>
            </td>
            <td>
                <asp:DropDownList ID="DropDownVangMat" runat="server"></asp:DropDownList></td>
        </tr>
    </table>

    <p style="width:550px;text-align:center">
         <asp:Button ID="Button1" runat="server" Text="Lưu" OnClick="Button1_Click" style="width: 37px" />
    </p>

    <p style="margin-left:100px;width:848px">
        <asp:Label ID="lblThongBao" runat="server" ForeColor="Red"></asp:Label></p>
</asp:Content>
