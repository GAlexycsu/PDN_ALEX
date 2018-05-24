<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMater/MyDocusND.Master" AutoEventWireup="true" CodeBehind="chitietphieudadichND.aspx.cs" Inherits="iOffice.presentationLayer.NguoiDich.chitietphieudadichND" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <table style="width: 1070px;  overflow:hidden">
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
                    <asp:Label ID="lblTieuDe" runat="server" Text=""></asp:Label><br />
             <asp:TextBox ID="txtTieuDe" runat="server" Width="975px"></asp:TextBox>

          </td>
    </tr>
          <tr>
              <td class="" style="height:15px"> Nội dung 内容:</td>
             
          </tr>
    <tr>
        <td >
       
           
                <asp:Label ID="lbNoiDung" runat="server" Text=""></asp:Label>
           
        </td>
       
    </tr>
   
     <tr>
          <td class="" style="text-align:right">  
         
             <asp:Label ID="lbNgay" runat="server" Text=""></asp:Label>
         
          </td>
  
     </tr>
       
   
   </table>
    
    <p style="color:red; width:933px; margin-left:100px;"> 
                  <asp:Label ID="lbThongBao" runat="server" Text=""></asp:Label> <br />
         <asp:Label ID="lbThongbaoloi" runat="server" ForeColor="Red"></asp:Label>
    </p>
    <div>
       
        <p>
            <ckeditor:ckeditorcontrol id="CKEditorControl1" runat="server" Height="280px" style="margin-bottom: 0px" OnTextChanged="CKEditorControl1_TextChanged" Width="1072px"></ckeditor:ckeditorcontrol>
        </p>
   
        <div class="button-wrap" style="width:1000px; text-align:center">
              <asp:Button ID="btnSua" runat="server" BackColor="#F0CCFF" ForeColor="Blue" CssClass="button edit" Text="Sửa" OnClick="btnSua_Click" Width="127px" />  &nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnLuu" runat="server" BackColor="#F0CCFF" ForeColor="Blue" CssClass="button save" Text="Lưu" OnClick="btnLuu_Click" Width="126px" Height="26px" />
        </div>
              
        
    </div>
</asp:Content>
