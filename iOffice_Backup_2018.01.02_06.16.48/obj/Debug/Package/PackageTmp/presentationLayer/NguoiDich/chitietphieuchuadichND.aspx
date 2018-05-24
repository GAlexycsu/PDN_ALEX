<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMater/MyDocusND.Master" AutoEventWireup="true" CodeBehind="chitietphieuchuadichND.aspx.cs" Inherits="iOffice.presentationLayer.NguoiDich.chitietphieuchuadichND" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../../Scripts/jquery.min.js"></script>
    <script src="../../Scripts/jquery-ui.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <table style="width: 1070px;  overflow:hidden; ">
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
      <tr>
          <td style="text-align:left;">Tiêu đề 题目:
             <asp:Label ID="lblTieuDe" runat="server" Text=""></asp:Label> <br />
              <asp:TextBox ID="txtTieuDe" runat="server" Width="1023px"></asp:TextBox>
              <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtTieuDe" runat="server" Text="*" ForeColor="Red" ErrorMessage=""></asp:RequiredFieldValidator>
           </td>
      </tr>
          <tr>
              <td style="text-align:left;"> Nội dung 内容:</td>
           
          </tr>
    <tr>
        <td style="text-align:left;">
       
            <div style="overflow:hidden; width:1029px">
                <asp:Label ID="lbNoiDung" runat="server" Text=""></asp:Label>
            </div>
        </td>
        
    </tr>
     <tr>
          <td  style="text-align:right">  
         
             <asp:Label ID="lbNgay" runat="server" Text=""></asp:Label>
         
          </td>
  
            </tr>
   
   </table>
    
    <p style="height: 16px; width: 752px; margin-left:100px"><asp:Label ID="lbThongBao" runat="server" ForeColor="Red"></asp:Label></p>
  
    <div>
        <p style="text-align:left;"> Nội dung dịch 翻译内容 :<br /><ckeditor:ckeditorcontrol id="CKEditorControl1" runat="server" Height="365px" style="margin-bottom: 0px; margin-top: 0px;" OnTextChanged="CKEditorControl1_TextChanged" Width="1072px"></ckeditor:ckeditorcontrol>
        </p>
        <div class="button-wrap" style="width:1000px;text-align:center">
            <asp:Button ID="btnLuu" runat="server" BackColor="#F0CCFF" CssClass="button save" ForeColor="Blue" Text="" OnClick="btnLuu_Click" Width="93px" /></div>
    </div>
</asp:Content>
