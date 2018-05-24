<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMater/MyDocusND.Master" AutoEventWireup="true" CodeBehind="frmTaoPhieuND.aspx.cs" Inherits="iOffice.presentationLayer.NguoiDich.frmTaoPhieuND" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../../Scripts/jquery.min.js"></script>
    <script src="../../Scripts/jquery-ui.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <p></p>
    <table style="width: 1070px">
        <tr>
              
             <td colspan="2"> <asp:Label ID="lbCty" runat="server" Text="Công ty TNHH Tỷ Hùng 億 雄 責 任 有 限 公 司"></asp:Label></td>
        </tr>
        <tr>
            
            <td style="width:120px">
                <asp:Label ID="lbLoaiPhieu" runat="server" Text="Loại phiếu 单别:"></asp:Label>
            </td>
            <td style="text-align:left;float:left"> <asp:DropDownList ID="DropLoaiPhieu" runat="server" OnSelectedIndexChanged="DropLoaiPhieu_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList></td>
        </tr>
        <tr>
            <td colspan="2"><asp:Label ID="lbTrinhBanLD" runat="server" Text="Trình ban lãnh đạo công ty TNHH Tỷ Hùng 呈亿雄公司主管部"></asp:Label> </td>
            
        </tr>
        <tr>
            <%--<td><%=hasLanguege["lbDonVi"].ToString() %></td>--%>
            <td class="auto-style1">
              
                <asp:Label ID="lbDonVi" runat="server" Text="Đơn vị đề nghị 提议单位 :"></asp:Label>
                
            </td>
            <td style="text-align:left;float:left"> s<asp:DropDownList ID="DropDonVi" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDonVi_SelectedIndexChanged1"></asp:DropDownList></td>
        </tr>
        <tr>
           <%-- <td><%=hasLanguege["lbTieuDe"].ToString() %></td>--%>
            <td class="auto-style1"> <asp:Label ID="lbTieuDe" runat="server" Text="Tiêu đề 题目: "></asp:Label>
                </td>
            <td style="text-align:left;float:left"><asp:TextBox ID="txtTieuDe" runat="server" Width="827px"></asp:TextBox>&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="*" Text="*" ForeColor="Red" ControlToValidate="txtTieuDe"></asp:RequiredFieldValidator></td>
        </tr>
        
    </table>
   
   <p style="text-align:left; width:800px; margin-left:100px"> <asp:Label ID="lbthongbao" runat="server" BorderColor="Red" ForeColor="Red"></asp:Label></p>
   
    <div>
             <ckeditor:ckeditorcontrol id="CKEditorControl1" runat="server" Height="300px" style="margin-bottom: 0px" Width="1072px"></ckeditor:ckeditorcontrol>
     
     </div>
     <p style="float:left">
         <asp:Label ID="Label1" runat="server" Text="Nội dung dịch 翻译内容 :"></asp:Label></p>
     <div>
             <ckeditor:ckeditorcontrol id="CKEditorControl2" runat="server" Height="300px" style="margin-bottom: 0px" Width="1072px"></ckeditor:ckeditorcontrol>
     
     </div>

    <p style="width:1000px;text-align:center">
        <asp:Button ID="btnLuuTam" runat="server" Text="Lưu Tạm" OnClick="btnLuuTam_Click" />&nbsp;&nbsp;
         <asp:Button ID="btnTiepTu" runat="server" Text="" OnClick="Button1_Click" style="height: 26px" />
    </p>
</asp:Content>
