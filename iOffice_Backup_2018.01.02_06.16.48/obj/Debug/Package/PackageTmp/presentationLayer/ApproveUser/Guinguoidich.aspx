<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMater/MyDocus.Master" AutoEventWireup="true" CodeBehind="Guinguoidich.aspx.cs" Inherits="iOffice.presentationLayer.ApproveUser.Guinguoidich" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../../Scripts/jquery.min.js"></script>
    <script src="../../Scripts/jquery-ui.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="text-align:left;float:left; width:800px;margin-left:200px">

          <table style="width: 700px; margin-left: 0px;">
              <tr>
                  <%-- <td> <asp:Label ID="lbUutien" runat="server" Text="Độ ưu tiên"></asp:Label></td>--%>
               <td>  <%=hasLanguege["lbUutien"] %></td>
                   <td>
                       <asp:DropDownList ID="DropDoUuTien" runat="server"></asp:DropDownList></td>
              </tr>
               <tr>
                  <%-- <td> <asp:Label ID="lbnguoidich" runat="server" Text="Người dịch"></asp:Label></td>--%>
                  <td>  <%=hasLanguege["lbnguoidich"] %></td>
                   <td>
                       <asp:DropDownList ID="DropDownNguoiDich" runat="server"></asp:DropDownList></td>
                  
               </tr>
        
           </table>
        <div class="button-wrap" style="margin-left:20px">
            
                       <asp:Button ID="Button1" runat="server" CssClass="button Continue " BackColor="#F0CCFF" ForeColor="Blue" Text="" OnClick="Button1_Click" Width="138px" />&nbsp;
                       <asp:Button ID="Button2" runat="server" CssClass="button Cancel" BackColor="#F0CCFF" ForeColor="Blue" OnClick="Button2_Click" Text="Button" Width="108px" />
                 
        </div>
    </div>
   <div>
        <p style="width:800px;margin-left:200px"><asp:Label ID="LbThongBao" runat="server" ForeColor="#0066FF"></asp:Label></p>
   </div>
  
</asp:Content>
