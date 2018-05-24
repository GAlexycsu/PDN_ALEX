<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMater/MyDocus.Master" AutoEventWireup="true" CodeBehind="chinhsuaphieuNV.aspx.cs" Inherits="iOffice.presentationLayer.Users.chinhsuaphieuNV" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../../Scripts/jquery.min.js"></script>
    <script src="../../Scripts/jquery-ui.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="margin-left:20px">
     <table style="width: 99%;  overflow:hidden">
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
          <td>Tiêu đề 题目: <asp:TextBox ID="txtTieuDe" runat="server" TextMode="MultiLine" Width="80%"></asp:TextBox></td>
      </tr>
    <tr>
        <td class="auto-style2">
           Nội dung 内容:&nbsp;&nbsp; 
            
            <div style="overflow:hidden; width:95%">
                  <ckeditor:ckeditorcontrol id="CKEditorControl1" runat="server" Height="273px" style="margin-bottom: 0px" Width="1058px"></ckeditor:ckeditorcontrol>
            </div>
        </td>
    </tr>
    
   
   </table>
    <div style="width:80%;text-align:center" class="button-wrap" >
         <asp:Button ID="btnLuu" runat="server" BackColor="#F0CCFF" ForeColor="Blue" CssClass="button save" Text="Save" OnClick="btnLuu_Click" Width="72px" /> 
        &nbsp;&nbsp;&nbsp; 
        <asp:Button ID="btnCancel" runat="server" BackColor="#F0CCFF" ForeColor="Blue" CssClass="button Cancel " Text="Cancel" OnClick="btnCancel_Click" Width="78px" />
    </div>
    </div>   
</asp:Content>
