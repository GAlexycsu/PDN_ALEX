<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMater/MyDocus.Master" AutoEventWireup="true" CodeBehind="MyCreatePDN.aspx.cs" Inherits="iOffice.presentationLayer.ApproveUser.MyCreatePDN" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit"
         TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
 
 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <%--  <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
     </asp:ToolkitScriptManager>--%>
    <p></p>
   <div>
           <table style="width: 863px">
        <tr>
              
             <td colspan="2"> <asp:Label ID="lbCty" runat="server" Text="Công ty TNHH Tỷ Hùng 億 雄 責 任 有 限 公 司"></asp:Label></td>
        </tr>
        <tr>
            
            <td style="width:120px">
                <asp:Label ID="lbLoaiPhieu" runat="server" Text="Loại phiếu 单别:"></asp:Label>
            </td>
            <td style="text-align:left;float:left"> <asp:DropDownList ID="DropLoaiPhieu" runat="server" OnSelectedIndexChanged="DropLoaiPhieu_SelectedIndexChanged" AutoPostBack="True" Width="69px"></asp:DropDownList></td>
        </tr>
        <tr>
            <td colspan="2"><asp:Label ID="lbTrinhBanLD" runat="server" Text="Trình ban lãnh đạo công ty TNHH Tỷ Hùng 呈亿雄公司主管部"></asp:Label> </td>
            
        </tr>
        <tr>
           
            <td class="auto-style1">
              
                <asp:Label ID="lbDonVi" runat="server" Text="Đơn vị đề nghị 提议单位 :"></asp:Label>
                
            </td>
            <td style="text-align:left;float:left"> <asp:DropDownList ID="DropDonVi" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDonVi_SelectedIndexChanged1"></asp:DropDownList></td>
        </tr>
        <tr>
           
            <td class="auto-style1"> <asp:Label ID="lbTieuDe" runat="server" Text="Tiêu đề 题目: "></asp:Label>
                </td>
            <td style="text-align:left;float:left"><asp:TextBox ID="txtTieuDe" runat="server" Width="600px"></asp:TextBox>&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="*" Text="*" ForeColor="Red" ControlToValidate="txtTieuDe"></asp:RequiredFieldValidator></td>
        </tr>
        
    </table>
   
   <p style="text-align:left"> <asp:Label ID="lbthongbao" runat="server" BorderColor="Red" ForeColor="Red"></asp:Label></p>
    <div id="divPhieuDeNghi" runat="server">
         <p style="text-align:left"><asp:Label ID="lbNoiDung" runat="server" Text="Nội dung 内容: "></asp:Label>
            
         </p>
             <ckeditor:ckeditorcontrol id="CKEditorControl1" runat="server" Height="435px" style="margin-bottom: 0px"></ckeditor:ckeditorcontrol>
     
     </div>
       <div id="divPhieuMuaHang" runat="server">
           <table>
               <tr>
                   <td style="float:left">Mục đích sử dụng 使用目的: </td>
                   <td>
                      <asp:TextBox ID="txtMucDich" runat="server" Width="597px" TextMode="MultiLine"></asp:TextBox> 
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="" Text="*" ForeColor="Red" ControlToValidate="txtMucDich"></asp:RequiredFieldValidator>
                   </td>
               </tr>
           </table>
           <table style="float:left" id="tablePMH" runat="server">
               <tr >
                   <td class="auto-style2">
                       TÊN HÀNG 品名
                   </td>
                   <td>Size</td>
                    <td>
                       QUY CÁCH-CHỦNG LOẠI <br />
                        規格- 種類:
                   </td>
                    <td>
                      SỐ LƯỢNG <br />
                        數量
                   </td>
                    <td class="auto-style2">
                       GHI CHÚ<br />
                        備註
                   </td>
               </tr>
               <tr> 
               
                   <td class="auto-style2">
                       <asp:TextBox ID="txtTenHang"  runat="server" Class="autosuggest" TextMode="MultiLine" Width="487px" Height="31px" ></asp:TextBox>
                      
                       <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="" Text="*" ControlToValidate="txtTenHang" ForeColor="Red" ValidationGroup="groupthemmoi"></asp:RequiredFieldValidator>
                      
                   </td>
                   <td>
                       <asp:TextBox ID="txtSize" runat="server"></asp:TextBox>
                   </td>
                   <td>
                       
                       <asp:TextBox ID="txtdonvitinh" runat="server"></asp:TextBox>
                        <asp:AutoCompleteExtender ID="txtName_AutoCompleteExtender" runat="server" 
                            DelimiterCharacters="" Enabled="True" ServiceMethod="GetCompletionList" 
                            TargetControlID="txtdonvitinh" UseContextKey="True" MinimumPrefixLength="1" CompletionInterval="10" EnableCaching="true" CompletionSetCount="3">
                         </asp:AutoCompleteExtender>
                       <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="" Text="*" ControlToValidate="txtdonvitinh" ForeColor="Red" ValidationGroup="groupthemmoi"></asp:RequiredFieldValidator>
                   </td>
                   <td>
                       <asp:TextBox ID="txtSoLuong" runat="server" CssClass="groupOfTexbox"></asp:TextBox>
                       
                       <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="" Text="*" ControlToValidate="txtSoLuong" ForeColor="Red" ValidationGroup="groupthemmoi"></asp:RequiredFieldValidator>
                       
                   </td>
                   <td class="auto-style2">
                       <asp:TextBox ID="txtGhiChu" runat="server" style="margin-left: 0px" TextMode="MultiLine"></asp:TextBox></td>
                   <td>
                       <asp:Button ID="Button1" runat="server" Text="Add" ValidationGroup ="groupthemmoi" OnClick="Button1_Click1" Height="35px" Width="48px" /></td>
               </tr>
           </table>
           <p style="width:150px">
               <asp:Label ID="lblMaHang" runat="server" Text=""></asp:Label></p>
      
    </div>
    <table>
        <tr>
            <td>
                <asp:Button ID="btnLuuTam" runat="server" Text="Lưu Tạm" OnClick="btnLuuTam_Click" />
            </td>
            <td>
                 <asp:Button ID="btnTiepTu" runat="server" Text="" OnClick="Button1_Click" style="height: 26px" />
            </td>
        </tr>
    </table>
   </div>
</asp:Content>
