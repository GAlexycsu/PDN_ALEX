<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMater/MyDocus.Master" AutoEventWireup="true" 
CodeBehind="chinhsuaphieu.aspx.cs" Inherits="iOffice.presentationLayer.ApproveUser.chinhsuaphieu" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../../Scripts/jquery.min.js"></script>
    <script src="../../Scripts/jquery-ui.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <table style="width: 1089px;  overflow:hidden">
        <tr>
            <td class="auto-style4"  ><asp:Label ID="lbCty" runat="server" Text="Công ty TNHH Tỷ Hùng 億 雄 責 任 有 限 公 司"></asp:Label>
                <asp:Label ID="lbSoPhieu" runat="server" Text="" style="float:right"></asp:Label>
            </td>
        </tr>
      <tr>
          <td class="auto-style2" style="text-align:center"> <asp:Label ID="lbLoaiPhieu" runat="server" Text="" ></asp:Label></td>
      </tr>
     <tr>
         <td class="auto-style3"><asp:Label ID="Label3" runat="server" Text="Trình ban lãnh đạo công ty TNHH Tỷ Hùng 呈亿雄公司主管部"></asp:Label> </td>
     </tr>
     <tr>
         <td class="auto-style2">Đơn vị đề nghị 提议单位 : <asp:Label ID="lbBoPhan" runat="server" Text=""></asp:Label> </td>
     </tr>
         <tr>
          <td>Tiêu đề 题目: <asp:TextBox ID="txtTieuDe" runat="server" TextMode="MultiLine" Width="897px"></asp:TextBox></td>
      </tr>
    <tr>
        <td class="auto-style2">
           Nội dung 内容:&nbsp;&nbsp; 
            
            <div style="overflow:hidden; width:1037px">
                  <ckeditor:ckeditorcontrol id="CKEditorControl1" runat="server" Height="393px" style="margin-bottom: 0px" Width="1020px"></ckeditor:ckeditorcontrol>
            </div>
        </td>
    </tr>
    
   
   </table>
    <br />
    <div class="button-wrap" style="width:1000px ; text-align:center"  >
        <p> <asp:Button ID="btnLuu" runat="server" Text="Save" CssClass="button save" OnClick="btnLuu_Click"  BackColor="#F0CCFF" ForeColor="Blue" Width="76px" /> &nbsp;&nbsp;&nbsp; <asp:Button ID="btnCalcel" runat="server" CssClass="button Cancel" Text="Cancel" OnClick="btnCalcel_Click" Width="118px" BackColor="#F0CCFF" ForeColor="Blue" /></p>
    </div>
</asp:Content>
