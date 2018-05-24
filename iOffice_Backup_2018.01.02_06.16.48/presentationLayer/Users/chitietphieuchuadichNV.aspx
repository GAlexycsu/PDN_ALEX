<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMater/MyDocus.Master" AutoEventWireup="true" CodeBehind="chitietphieuchuadichNV.aspx.cs" Inherits="iOffice.presentationLayer.Users.chitietphieuchuadichNV" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../../Scripts/jquery.min.js"></script>
    <script src="../../Scripts/jquery-ui.min.js"></script>
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="margin-left:20px">
     &nbsp;<table style="width: 99%;">
        <tr>
            <td class="" style="height:20px" ><asp:Label ID="lbCty" runat="server" Text="Công ty TNHH Tỷ Hùng 億 雄 責 任 有 限 公 司"></asp:Label>
                <asp:Label ID="lbSoPhieu" runat="server" Text="" style="float:right"></asp:Label>
            </td>
        </tr>
      <tr>
          <td class="auto-style3" style= "height:20px; text-align:center";> <asp:Label ID="lbLoaiPhieu" runat="server" Text="" ></asp:Label></td>
      </tr>
     <tr>
         <td class="auto-style4" style="height:20px"><asp:Label ID="Label3" runat="server" Text="Trình ban lãnh đạo công ty TNHH Tỷ Hùng 呈亿雄公司主管部"></asp:Label> 
             <asp:TextBox ID="TextBox1" runat="server" Width="16px" Visible="false"></asp:TextBox>
         </td>
     </tr>
     <tr>
         <td class="auto-style5" style="height:20px">Đơn vị đề nghị 提议单位 : <asp:Label ID="lbBoPhan" runat="server" Text=""></asp:Label> </td>
     </tr>
         
     <tr style="height:10px">
          <td  style="text-align:right">  
         
             <asp:Label ID="lbNgay" runat="server" Text=""></asp:Label>
         
          </td>
  
       </tr>
     <tr>
        <td>Tiêu đề 题目:
        <asp:TextBox ID="txtTieuDe" runat="server" Width="926px"></asp:TextBox></td>
    </tr>
   <tr>
       <td> Nội dung 内容:</td>
   </tr>
   </table>
    <div style="overflow:hidden; width:1073px">
               <ckeditor:ckeditorcontrol id="CKEditorControl1" runat="server" Height="292px" style="margin-bottom: 0px" Width="1072px"></ckeditor:ckeditorcontrol>
            </div>
    <p style="width:902px; margin-left:100px"><asp:Label ID="lbThongBao" runat="server" ForeColor="Red"></asp:Label></p>
    <table style="margin-left:250px">
        <tr>
            <td></td>
        </tr>
        <tr>
            <td>
                <asp:CheckBox ID="CheckChon" runat="server" Text="Chọn người dịch khác" OnCheckedChanged="CheckChon_CheckedChanged" AutoPostBack="True" />
            </td>
            <td>
                <asp:DropDownList ID="DropDownNguoiDich" runat="server" AutoPostBack="true"></asp:DropDownList></td>
        </tr>
       
            
    </table>
    <div class="button-wrap" style="width:800px;text-align:center">
        <asp:Button ID="btnBack" runat="server" BackColor="#F0CCFF" CssClass="button Cancel" ForeColor="Blue" Text="Back" OnClick="btnBack_Click" Width="84px" />  &nbsp;  &nbsp; 
       
        <asp:Button ID="btnEdit" runat="server" BackColor="#F0CCFF" ForeColor="Blue" CssClass="button edit" Text="Sửa" Width="101px" OnClick="btnEdit_Click" /> &nbsp;  &nbsp; 
        <asp:Button ID="btnLuu" runat="server" BackColor="#F0CCFF" ForeColor="Blue" CssClass="button save" Text="Lưu" Width="100px" OnClick="btnLuu_Click" style="height: 26px" />
    </div>
        </div>
</asp:Content>
