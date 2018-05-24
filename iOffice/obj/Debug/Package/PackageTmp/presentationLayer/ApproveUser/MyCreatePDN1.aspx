<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMater/MyDocus.Master" AutoEventWireup="true" CodeBehind="MyCreatePDN1.aspx.cs" Inherits="iOffice.presentationLayer.ApproveUser.MyCreatePDN1" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit"
         TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../Style/jquery-ui.css" rel="stylesheet" />
    <script src="../../Scripts/jquery.min.js"></script>
    <script src="../../Scripts/jquery-ui.min.js"></script>
   <script type="text/javascript">

       $(document).ready(function () {
           $("#txtAutoComplete").autocomplete({
               source: function (request, response) {
                   $.ajax({
                       type: "POST",
                       contentType: "application/json; charset=utf-8",
                       url: "MyCreatePDN1.aspx/GetCategory",
                       data: "{'term':'" + $("#txtAutoComplete").val() + "'}",
                       dataType: "json",
                       success: function (data) {
                           response($.map(data.d, function (item) {
                               return {
                                   label: item.split('^^')[0],
                                   val: item.split('^^')[1]
                               }
                           }));
                       },
                       error: function (result) {
                           alert("Error");
                       }
                   });

               },
               select: function (event, ui) {
                   $('#txtMaHang').val(ui.item.val);
               }
           });
       });

    </script>
   <script type="text/javascript">
       $(document).ready(function () {
           $("#txtTenNhaCC").autocomplete({
               source: function (request, response) {
                   $.ajax({
                       type: "POST",
                       contentType: "application/json; charset=utf-8",
                       url: "MyCreatePDN1.aspx/DanhSachNhaCungUng",
                       data: "{'dieukien':'" + $("#txtTenNhaCC").val() + "'}",
                       dataType: "json",
                       success: function (data) {
                           response($.map(data.d, function (item) {
                               return {
                                   label: item.split('^^')[0],
                                   val: item.split('^^')[1]
                               }
                           }));
                       },
                       error: function (result) {
                           alert("Error");
                       }
                   });

               },
               select: function (event, ui) {
                   $('#txtMaNhaCC').val(ui.item.val);
               }
           });
       });

   </script>
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <%--<asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
     </asp:ToolkitScriptManager>--%>
    <p></p>
   <div  style="margin-left:20px">
           <table style="width: 1063px">
        <tr>
              
             <td colspan="2"> <asp:Label ID="lbCty" runat="server" Text="Công ty TNHH Tỷ Hùng 億 雄 責 任 有 限 公 司"></asp:Label></td>
        </tr>
        <tr>
            
            <td style="width:128px;text-align:left">
                <asp:Label ID="lbLoaiPhieu" runat="server" Text="Loại phiếu 单别:"></asp:Label>
            </td>
            <td style="text-align:left;float:left"> <asp:DropDownList ID="DropLoaiPhieu" runat="server" OnSelectedIndexChanged="DropLoaiPhieu_SelectedIndexChanged" AutoPostBack="True" Width="200px"></asp:DropDownList></td>
        </tr>
        <tr>
            <td colspan="2"><asp:Label ID="lbTrinhBanLD" runat="server" Text="Trình ban lãnh đạo công ty TNHH Tỷ Hùng 呈亿雄公司主管部"></asp:Label> </td>
            
        </tr>
        <tr>
           
            <td class="auto-style1">
              
                <asp:Label ID="lbDonVi" runat="server" Text="Đơn vị đề nghị 提议单位 :"></asp:Label>
                
            </td>
            <td style="text-align:left;float:left"> <asp:DropDownList ID="DropDonVi" runat="server" AutoPostBack="True" ></asp:DropDownList></td>
        </tr>
        <tr>
           
            <td class="auto-style1"> <asp:Label ID="lbTieuDe" runat="server" Text="Tiêu đề 题目: "></asp:Label>
                </td>
            <td style="text-align:left;float:left"><asp:TextBox ID="txtTieuDe" ValidationGroup="grThucHien" runat="server" Width="900px"></asp:TextBox>&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="*" Text="*" ForeColor="Red" ControlToValidate="txtTieuDe"></asp:RequiredFieldValidator></td>
        </tr>
        
    </table>
   
   <p style="text-align:left"> <asp:Label ID="lbthongbao" runat="server" BorderColor="Red" ForeColor="Red"></asp:Label></p>
    <div id="divPhieuDeNghi" runat="server">
         <p style="text-align:left"><asp:Label ID="lbNoiDung" runat="server" Text="Nội dung 内容: "></asp:Label>
            
         </p>
             <ckeditor:ckeditorcontrol id="CKEditorControl1" runat="server" Height="376px" style="margin-bottom: 0px" Width="1072px"></ckeditor:ckeditorcontrol>
     
     </div>
       <div id="divPhieuMuaHang" runat="server">
           <table>
               <tr>
                   <td style="width:128px;text-align:left"><%--Mục đích sử dụng 使用目的: --%><asp:Label ID="lblMucDich" runat="server" Text=""></asp:Label></td>
                   <td>
                      <asp:TextBox ID="txtMucDich" runat="server" Width="900px" ValidationGroup="grThucHien" TextMode="MultiLine"></asp:TextBox> 
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="" Text="*" ForeColor="Red" ControlToValidate="txtMucDich"></asp:RequiredFieldValidator>
                   </td>
               </tr>
           </table>
        <%--      <table>
               <tr>
                   <td style="width:128px;text-align:left">
                      <asp:Label ID="lbTenNhaCC" runat="server" Text=""></asp:Label>
                   </td>
                   <td>
                       <asp:TextBox ID="txtTenNhaCC" runat="server" ClientIDMode="Static" TextMode="MultiLine" Width="204px"></asp:TextBox>
                   </td>

                   <td>   <asp:Label ID="lblMaNhaCC" runat="server" Text=""></asp:Label>
                   </td>
                   <td>
                       <asp:TextBox ID="txtMaNhaCC" runat="server" ClientIDMode="Static"></asp:TextBox>
                   </td>
               </tr>
               
           </table>
            <p style="width:850px;text-align:left; margin-left:150px"> <asp:Button ID="btnChonNhaCC" runat="server" BackColor="#F0CCFF" ForeColor="Blue" Text="Chọn Nhà Cung Ứng" OnClick="btnChonNhaCC_Click" /></p>
         --%>
           <table style="float:left; width: 1112px;" id="tablePMH" runat="server">
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
               <tr style="text-align:center"> 
               
                   <td  >
                       <asp:TextBox ID="txtAutoComplete"  runat="server" ClientIDMode="Static" Class="autosuggest" TextMode="MultiLine" Width="400px" Height="31px" ></asp:TextBox>

                   </td>
                   <td >
                       <asp:TextBox ID="txtSize" runat="server" Height="31px" Width="136px"></asp:TextBox>
                   </td>
                   <td style="text-align:center">
                       
                       <asp:TextBox ID="txtdonvitinh" runat="server" Height="31px" ></asp:TextBox>
                        <asp:AutoCompleteExtender ID="txtName_AutoCompleteExtender" runat="server" 
                            DelimiterCharacters="" Enabled="True" ServiceMethod="GetCompletionList" 
                            TargetControlID="txtdonvitinh" UseContextKey="True" MinimumPrefixLength="1" CompletionInterval="10" EnableCaching="true" CompletionSetCount="3">
                         </asp:AutoCompleteExtender>
                      
                   </td>
                   <td >
                       <asp:TextBox ID="txtSoLuong" runat="server" CssClass="groupOfTexbox" Height="31px"></asp:TextBox>
                       <%-- <asp:FilteredTextBoxExtender ID="Fileter1" runat="server" Enabled="true" TargetControlID="txtSoLuong" FilterType="Numbers" FilterMode="ValidChars"></asp:FilteredTextBoxExtender>--%>
                       <asp:FilteredTextBoxExtender ID="fileter1" runat="server" Enabled="true" TargetControlID="txtSoLuong" FilterType="Numbers" FilterMode="ValidChars"></asp:FilteredTextBoxExtender>
                       
                   </td>
                   <td  >
                       <asp:TextBox ID="txtGhiChu" runat="server" style="margin-left: 0px" Height="31px" TextMode="MultiLine"></asp:TextBox></td>
                   <td class="button-wrap">
                       <asp:Button ID="Button1" runat="server" CssClass="button save" BackColor="#F0CCFF" ForeColor="Blue" Text="Save" ValidationGroup ="groupthemmoi" OnClick="Button1_Click1" Height="35px" Width="66px" /></td>
               </tr>
               <tr>
                   <td>
                       <asp:TextBox ID="txtMaHang" runat="server" ClientIDMode="Static" Width="16px" ForeColor="White" BorderColor="White" BorderStyle="None"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="" Text="*" ControlToValidate="txtAutoComplete" ForeColor="Red" ValidationGroup="groupthemmoi"></asp:RequiredFieldValidator>
                   </td>
                   <td>

                   </td>
                   <td>
                       <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="" Text="*" ControlToValidate="txtdonvitinh" ForeColor="Red" ValidationGroup="groupthemmoi"></asp:RequiredFieldValidator>--%>
                   </td>
                   <td>
                       <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="" Text="*" ControlToValidate="txtSoLuong" ForeColor="Red" ValidationGroup="groupthemmoi"></asp:RequiredFieldValidator>
                   </td>
                   <td>

                   </td>
               </tr>
           </table>
           <asp:GridView ID="GridView1" runat="server" Width="1112px" AutoGenerateColumns="False" OnRowEditing="GridView1_RowEditing" style="margin-right: 0px" OnRowDeleting="GridView1_RowDeleting">
               <Columns>
                   <asp:TemplateField HeaderText="Edit / Delete">
                       <ItemTemplate>
                        <asp:LinkButton ID="btnEdit" Text="Edit" runat="server" CommandName="Edit" />
                        <span onclick="return confirm('Are you sure want to delete?')">
                            <asp:LinkButton ID="btnDelete" Text="Delete" runat="server" CommandName="Delete" />
                        </span>

                    </ItemTemplate>
                    <ItemStyle Width="80px" />
                   </asp:TemplateField>

                 <asp:TemplateField HeaderText="STT &lt;br/&gt; 次序">
                      <ItemTemplate><%#GetSTT() %></ItemTemplate>
                     <ItemStyle Width="30px" />
                  </asp:TemplateField>

                   <asp:TemplateField HeaderText="Cong ty" Visible="false">
                       <ItemTemplate>
                           <asp:Label ID="lblGSBH" runat="server" Text='<%#Eval("GSBH") %>'></asp:Label>
                       </ItemTemplate>
                   </asp:TemplateField>

                   <asp:TemplateField  HeaderText="Ma Phieu" Visible="false">
                       <ItemTemplate>
                           <asp:Label ID="lblPDNO" runat="server" Text='<%#Eval("pdNO") %>'></asp:Label>
                       </ItemTemplate>
                   </asp:TemplateField>

                   <asp:TemplateField HeaderText="Ma hang" Visible="false">
                       <ItemTemplate>
                           <asp:Label ID="lblCLBH" runat="server" Text='<%#Eval("CLBH") %>'></asp:Label>
                       </ItemTemplate>
                       
                   </asp:TemplateField>

                   <asp:TemplateField HeaderText="  TÊN HÀNG 品名">
                       <ItemTemplate>
                           <asp:Label ID="lblMemo0" runat="server" Text='<%#Eval("Memo0") %>'></asp:Label>
                       </ItemTemplate>
                       <ItemStyle Width="400px" />
                   </asp:TemplateField>

                   <asp:TemplateField HeaderText=" Size">
                       <ItemTemplate>
                           <asp:Label ID="lblSize" runat="server" Text='<%#Eval("Size") %>'></asp:Label>
                       </ItemTemplate>
                       <ItemStyle Width="30px" />
                   </asp:TemplateField>

                   <asp:TemplateField  HeaderText="Quy Cach 規格- 種類">
                       <ItemTemplate>
                           <asp:Label ID="lblDWBH" runat="server" Text='<%#Eval("dwbh") %>'></asp:Label>
                       </ItemTemplate>
                       <ItemStyle Width="50px" />
                   </asp:TemplateField>

                   <asp:TemplateField HeaderText=" So luong  數量">
                       <ItemTemplate>
                           <asp:Label ID="lblQty" runat="server" Text='<%#Eval("Qty","{0:0,0}") %>'></asp:Label>
                       </ItemTemplate>
                       <ItemStyle Width="50px" />
                   </asp:TemplateField>

                   <asp:TemplateField HeaderText="Ghi Chu 備註">
                       <ItemTemplate>
                           <asp:Label ID="lblCLMemo" runat="server" Text='<%#Eval("CLmemo") %>'></asp:Label>
                       </ItemTemplate>
                       <ItemStyle Width="340px" />
                   </asp:TemplateField>
                    <asp:TemplateField Visible="false">
                       <ItemTemplate>
                           <asp:Label ID="lblZSBH" runat="server" Text='<%#Eval("ZSBH") %>'></asp:Label>
                       </ItemTemplate>
                       
                   </asp:TemplateField>
               </Columns>
           </asp:GridView>
      
    </div>
      <br />

       <div class="button-wrap" style="width:800px; float:left; text-align:center">  <asp:Button ID="btnLuuTam" runat="server" BackColor="#F0CCFF" CssClass="button save" ForeColor="Blue" ValidationGroup="grThucHien" Text="Lưu Tạm" OnClick="btnLuuTam_Click" Width="93px" /> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnTiepTu" runat="server" BackColor="#F0CCFF" ForeColor="Blue" CssClass="button Continue" ValidationGroup="grThucHien" Text="" OnClick="Button1_Click" Width="137px" /></div>
   </div>

</asp:Content>
