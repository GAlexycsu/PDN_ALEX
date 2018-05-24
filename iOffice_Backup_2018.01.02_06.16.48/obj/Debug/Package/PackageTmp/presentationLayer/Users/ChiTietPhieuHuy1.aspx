<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMater/MyDocus.Master" AutoEventWireup="true" CodeBehind="ChiTietPhieuHuy1.aspx.cs" Inherits="iOffice.presentationLayer.Users.ChiTietPhieuHuy1" %>
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
        <asp:TextBox ID="txtTieuDeVN" runat="server" TextMode="MultiLine" Width="347px"></asp:TextBox> <asp:TextBox ID="txtTieuDeTW" runat="server" TextMode="MultiLine" Width="347px"></asp:TextBox></td>
    </tr>
   <tr>
       <td> Nội dung 内容:</td>
   </tr>
   </table>
    <div style="overflow:hidden; width:1073px; height: 153px;">
               <ckeditor:ckeditorcontrol id="CKEditorControl1" runat="server" Height="202px" style="margin-bottom: 0px" Width="1072px"></ckeditor:ckeditorcontrol>
            </div>
    <div > 
        <p style="width:257px; text-align:left">Nội dung dịch 翻译内容:</p>
         <ckeditor:ckeditorcontrol id="CKEditorControl2" runat="server" Height="162px" style="margin-bottom: 0px" Width="1072px"></ckeditor:ckeditorcontrol>
    </div>
    <p style="width:902px; margin-left:10px"> <%#hasLanguege["lblGuiNguoiDuyet"].ToString() %>
        <asp:TextBox ID="txtPhanHoi" runat="server" Width="760px"></asp:TextBox></p>
    <p style="width:902px; margin-left:100px"><asp:Label ID="lbThongBao" runat="server" ForeColor="Red"></asp:Label></p>
    <table style="margin-left:200px">
        <tr>
            <td></td>
        </tr>
        <tr>
            <td>
               <%#hasLanguege["lblNguoiĐangDuyet"].ToString() %> 
            </td>
            <td>
                <asp:TextBox ID="txtNguoiCoDUyet" runat="server" ReadOnly="True"></asp:TextBox>
            </td>
        </tr>
       
            
    </table>
         <table style="margin-left:250px">
        <tr>
            <td></td>
        </tr>
        <tr>
            <td>
                <asp:CheckBox ID="CheckChon" runat="server" Text="Gửi Người Dịch Phiếu" OnCheckedChanged="CheckChon_CheckedChanged" AutoPostBack="True" />
            </td>
            <td>
                <asp:DropDownList ID="DropDownNguoiDich" runat="server" AutoPostBack="true"></asp:DropDownList></td>
        </tr>
       
            
    </table>
    <div class="button-wrap" style="width:800px;text-align:center">
        <asp:Button ID="btnBack" runat="server" BackColor="#F0CCFF" ForeColor="Blue" CssClass="button Cancel" Text="Back" OnClick="btnBack_Click" />  &nbsp;  &nbsp; 
       
        <asp:Button ID="btnEdit" runat="server" BackColor="#F0CCFF" ForeColor="Blue" CssClass="button edit" Text="Sửa" Width="101px" OnClick="btnEdit_Click" /> &nbsp;  &nbsp; 
        <asp:Button ID="btnLuu" runat="server" BackColor="#F0CCFF" ForeColor="Blue" CssClass="button Continue" Text="Lưu Và Chuyển Tới Người Duyệt Phiếu" Width="242px" OnClick="btnLuu_Click" /> &nbsp;  &nbsp;
         <asp:Button ID="btnGuiNguoiDich" runat="server" BackColor="#F0CCFF" ForeColor="Blue" CssClass="button Translate"  Text="Gửi Người Dịch" OnClick="btnGuiNguoiDich_Click" />
    </div>
    <div id="divaa" style="display:none">
        <asp:TextBox ID="txtNguoiChoDuyetID" runat="server" ></asp:TextBox>
        <asp:TextBox ID="txtDepartID" runat="server"></asp:TextBox>
    </div>
      </div>
</asp:Content>
