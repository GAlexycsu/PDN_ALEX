<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMater/MyDocusND.Master" AutoEventWireup="true" CodeBehind="feedback.aspx.cs" Inherits="iOffice.presentationLayer.NguoiDich.feedback" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="Panel1" runat="server" >
         <table style="margin-left:400px">
             <tr>
                 <td>
                     <asp:RadioButton ID="RadioSendCreater" GroupName="Group1" runat="server" Text="Feedback" OnCheckedChanged="RadioSendCreater_CheckedChanged" AutoPostBack="True" />
                 </td>
             </tr>
             <tr>
                 <td>
                     <asp:RadioButton ID="RadioSendTranslator" GroupName="Group1" runat="server"  Text="Send Translator" AutoPostBack="True" Checked="True" OnCheckedChanged="RadioSendTranslator_CheckedChanged"/>
                 </td>
             </tr>
         </table>
        <br />
        <div id="Div1" runat="server" style="text-align:center; width:600px; margin-left:200px" >
             <table>
                 <tr>
                     <td>
                         <asp:Label ID="lblNguoiDich" runat="server" Text="Nhờ người dich"></asp:Label></td>
                     <td>
                        <asp:DropDownList ID="DropDownNguoiDich" runat="server"></asp:DropDownList>

                     </td>
                     <td class="button-wrap">
                       <asp:Button ID="Button1" runat="server" Text=" Send" CssClass="button Continue" BackColor="#F0CCFF" ForeColor="Blue" OnClick="Button1_Click" Width="62px" Height="18px" /> 
                   </td>
                      <td class="button-wrap">
                         <asp:Button ID="btnTroVe" runat="server" CssClass="button Cancel" BackColor="#F0CCFF" ForeColor="Blue" Text="Back" OnClick="btnTroVe_Click" Width="76px" />
                     </td>
                   
                    
                 </tr>
             </table>
           
        </div>
        <div id="Div2" runat="server" style="text-align:center; width:600px; margin-left:200px">
            <table style="text-align:left;">
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text="User"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtUser" runat="server" Text="" Enabled="False" ReadOnly="True"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td >
                        <asp:Label ID="lblEmail" runat="server" Text="Email"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtEmail" runat="server" Text=""></asp:TextBox>
                    </td>
                    <td></td>
                    <td></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblTitle" runat="server" Text="Tile"></asp:Label>
                    </td>
                    <td colspan="3">
                        <asp:TextBox ID="txtTile" runat="server" Text="" Width="430px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblComment" runat="server" Text=""></asp:Label>
                    </td>
                    <td colspan="3" style="width:100px">
                        <asp:TextBox ID="txtComment" runat="server" Text="" TextMode="MultiLine" Height="45px" Width="430px"></asp:TextBox>
                    </td>
                </tr>
            </table>
            <div class="button-wrap" style="text-align:center; width:600px;">
                <asp:Button ID="btnSendMail" runat="server" BackColor="#F0CCFF" CssClass="button Continue" ForeColor="Blue" Text="Send" OnClick="btnSendMail_Click" Width="65px" /> 
                <asp:Button ID="btnCancel" CssClass="button Cancel" runat="server" BackColor="#F0CCFF" ForeColor="Blue" Text="Cancel" OnClick="btnCancel_Click" Width="86px" />&nbsp; 
                
            </div>
            
        </div>
        
         <p style="width:928px; height:80px; margin-left:150px;line-height: normal; text-align:left;"><asp:Label ID="LbThongBao" runat="server" ForeColor="#0066FF" Font-Size="Large" Font-Overline="False"></asp:Label></p>
    </asp:Panel>
</asp:Content>
