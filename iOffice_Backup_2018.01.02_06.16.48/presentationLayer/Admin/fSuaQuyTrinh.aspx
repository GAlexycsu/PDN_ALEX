<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMater/AdminMaster.Master" AutoEventWireup="true" CodeBehind="fSuaQuyTrinh.aspx.cs" Inherits="iOffice.presentationLayer.Admin.fSuaQuyTrinh" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <p><%=hasLanguege["lbsuaQPDNFlow"].ToString() %></p>

     <table style="width: 594px;margin-left:200px">
        
        <tr>
            <td>
                  <%=hasLanguege["lbCty"].ToString() %>          </td>
           <td> <asp:DropDownList ID="DropCty" runat="server" Enabled="False">
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
                <%--<%=hasLanguege["lblLieuPhieu"].ToString() %> --%> Loai Phieu</td>
            <td>
                <asp:DropDownList ID="DropDownLoaiPhieu" runat="server" Enabled="False">
                    
                </asp:DropDownList>
            </td>
           
        </tr>
        <tr>
            <td class="auto-style1">
              <%--  <%=hasLanguege["lbDonVi"].ToString() %>--%>
                Don Vi
            </td>
            <td class="auto-style1">
                <asp:DropDownList ID="DropDownLDonVi" runat="server" Height="16px" Enabled="False"></asp:DropDownList>
            </td>
           
        </tr>

        <tr>
            <td>
                <%=hasLanguege["lbNguoiDuyet"].ToString() %>
            </td>
            <td>
                <asp:TextBox ID="txtNguoiDuyet" runat="server"></asp:TextBox>
            </td>
        </tr>
      
       
        
    </table>
     <table style="width: 594px;margin-left:200px">
         <tr>
           <td style="width:165px"><%=hasLanguege["lblBuocDuyet"].ToString() %></td>
           <td class="auto-style4">
               <asp:DropDownList ID="DropDownABStep" runat="server" Enabled="False">
                   <asp:ListItem Value="1">Step 1</asp:ListItem>
                   <asp:ListItem Value="2">Step 2</asp:ListItem>
                   <asp:ListItem Value="3">Step 3</asp:ListItem>
                   <asp:ListItem Value="4">Step 4</asp:ListItem>
                   <asp:ListItem Value="5">Step 5</asp:ListItem>
                   <asp:ListItem Value="6">Step 6</asp:ListItem>
                   <asp:ListItem Value="7">Step 7</asp:ListItem>
                   <asp:ListItem Value="8">Step 8</asp:ListItem>
                   <asp:ListItem Value="9">Step 9</asp:ListItem>
               </asp:DropDownList>
               &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
               <asp:DropDownList ID="DropDownABPS" runat="server">
                   <asp:ListItem Value="1">ABPS 1</asp:ListItem>
                   <asp:ListItem Value="2">ABPS 2</asp:ListItem>
                   <asp:ListItem Value="3">ABPS 3</asp:ListItem>
                   <asp:ListItem Value="4">ABPS 4</asp:ListItem>
                   <asp:ListItem Value="5">ABPS 5</asp:ListItem>
               </asp:DropDownList>
           </td>
          
           
       </tr>
     </table>         
   
    <div>
        <p style="width:713px; margin-left:150px">
        <asp:Label ID="lbThongBao" runat="server" Text=""></asp:Label>
        </p>
    </div>
    <p style="width:763px; text-align:center">
        <asp:Button ID="Button1" runat="server" Text="Lưu" OnClick="Button1_Click" style="width: 37px" />
    </p>
</asp:Content>
