﻿<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMater/MyDocus.Master" AutoEventWireup="true" CodeBehind="chitietphieudadich.aspx.cs" Inherits="iOffice.presentationLayer.ApproveUser.chitietphieudadich" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../../Scripts/jquery.min.js"></script>
    <script src="../../Scripts/jquery-ui.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="border-style: solid; border-color: inherit; width:99%; border-width:1px; margin-left:20px ">

    
       <table style="width: 1070px;  overflow:hidden">
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
       <td style="text-align:left;">Tiêu đề 题目:
           <asp:Label ID="lblTieuDe" runat="server" Text=""></asp:Label>
       </td>
  </tr>
    <tr>
        <td class="auto-style2">
           Nội dung 内容:&nbsp;&nbsp; 
            
            <div style="overflow:hidden; width:800px">
                <asp:Label ID="lbNoiDung" runat="server" Text=""></asp:Label>
            </div>
        </td>
    </tr>
    <tr>
        <td>Nội dung dịch 翻译内容 :&nbsp;&nbsp; 
            <div style="overflow:hidden; width:800px">
                <asp:Label ID="LbNoiDungDich" runat="server" Text=""></asp:Label>
            </div>
        </td>
    </tr>
     <tr>
          <td class="auto-style2" style="text-align:right">  
         
             <asp:Label ID="lbNgay" runat="server" Text=""></asp:Label>
         
          </td>
  
      </tr>
          
   
   </table>
    </div>
    <br />
    <div class="button-wrap" style="width:1000px;text-align:center">
        <asp:Button ID="btnUndo" runat="server" Text="Quay lại" CssClass="button Cancel" OnClick="btnUndo_Click" Width="109px" BackColor="#F0CCFF" ForeColor="Blue"/>
        &nbsp;&nbsp;
        <asp:Button ID="btnContinus" runat="server" Text="Tiếp tục" CssClass="button Continue" OnClick="btnContinus_Click" Width="97px" BackColor="#F0CCFF" ForeColor="Blue" />
    </div>
</asp:Content>
