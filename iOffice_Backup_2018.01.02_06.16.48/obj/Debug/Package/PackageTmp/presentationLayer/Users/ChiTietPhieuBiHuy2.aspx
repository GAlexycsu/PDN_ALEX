<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMater/MyDocus.Master" AutoEventWireup="true" CodeBehind="ChiTietPhieuBiHuy2.aspx.cs" Inherits="iOffice.presentationLayer.Users.ChiTietPhieuBiHuy2" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit"
         TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <script src="../../Scripts/jquery-1.9.1.js"></script>
    <script src="../../Scripts/nhapso.js"></script>
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
                       url: "frmSuaphieumuahangNV.aspx/GetCategory",
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="margin-left:20px">
      <p style="text-align:left"> Công ty TNHH Tỷ Hùng 億 雄 責 任 有 限 公 司"</p>
       <p style="text-align:right; width:1082px">
           <asp:Label ID="lblsophieu" runat="server" Text=""></asp:Label> </p>
       <p style="text-align:center">
           <asp:Label ID="lblPhieuMuaHang" runat="server" Text=""></asp:Label></p>
    <p style="width:1098px"> Tiêu đề 题目:
        <asp:TextBox ID="txtTieuDe" runat="server" TextMode="MultiLine" Width="385px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtTieuDe" ForeColor="Red" ValidationGroup="groupThem" Text="Not Null"   ErrorMessage=""></asp:RequiredFieldValidator>
        <asp:TextBox ID="txtTieuDeTW" runat="server" TextMode="MultiLine" Width="472px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtTieuDeTW" ForeColor="Red" ValidationGroup="groupThem" Text="Not Null"   ErrorMessage=""></asp:RequiredFieldValidator>
    </p>
       <table style="float:left;width:1100px; border: 1px solid black;border-collapse: collapse;" >
           <tr style="width:800px;border: 1px solid black;border-collapse: collapse;">
               <td  style="border: 1px solid black;border-collapse: collapse;">
                   Đơn vị đề nghị:<br />
                      提议单位 :
                    <asp:Label ID="lbldonvidenghi" runat="server" Text=""></asp:Label>
               </td>
              <td style="border: 1px solid black;border-collapse: collapse;" >
                  <asp:Label ID="lblNgaytao" runat="server" Text=""></asp:Label></td>
           </tr>
           <tr style="width:800px;">
               <td colspan="2" style="text-align:left;">
                   Mục đích sử dụng: <br />
                   使用目的:
                   <asp:TextBox ID="txtMucDichSuDung" runat="server" TextMode="MultiLine" Width="939px"></asp:TextBox>
               </td>
              
           </tr>
       </table>
    <div style="width:1100px; float:left">
         <table style="float:left; width: 1100px;" id="tablePMH" runat="server">
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
                       <asp:TextBox ID="txtAutoComplete"  runat="server" ClientIDMode="Static" Class="autosuggest" TextMode="MultiLine" Width="439px" Height="31px"></asp:TextBox>

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
                       
                       
                       
                   </td>
                   <td  >
                       <asp:TextBox ID="txtGhiChu" runat="server" style="margin-left: 0px" Height="31px" TextMode="MultiLine"></asp:TextBox></td>
                   <td class="button-wrap">
                       <asp:Button ID="Button1" runat="server" BackColor="#F0CCFF" ForeColor="Blue" Text="Save" CssClass="button save" ValidationGroup ="groupthemmoi" OnClick="Button1_Click1" Height="35px" Width="70px" /></td>
               </tr>
               <tr>
                   <td>
                       <asp:TextBox ID="txtMaHang" runat="server" ClientIDMode="Static"></asp:TextBox>
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
    </div>
       <asp:GridView ID="GridView1" runat="server" Width="1100px" AutoGenerateColumns="False" OnRowEditing="GridView1_RowEditing" style="margin-right: 0px" OnRowDeleting="GridView1_RowDeleting">
               <Columns>
                   <asp:TemplateField HeaderText="Edit">
                       <ItemTemplate>
                        <asp:LinkButton ID="btnEdit" Text="" runat="server" CommandName="Edit" ><img src="../../Content/Icon/edit.gif" /> Edit</asp:LinkButton>
                        

                    </ItemTemplate>
                   <ItemStyle Width="6%" />
                   </asp:TemplateField>
                    <asp:TemplateField HeaderText=" Delete">
                       <ItemTemplate>
                      
                        <span onclick="return confirm('Are you sure want to delete?')">
                            <asp:LinkButton ID="btnDelete" Text="" runat="server" CommandName="Delete" ><img src="../../Content/Icon/delete.png" />Delete</asp:LinkButton>
                        </span>

                    </ItemTemplate>
                   <ItemStyle Width="6%" />
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

                   <asp:TemplateField HeaderText="Ma hang 品名 " Visible="false">
                       <ItemTemplate>
                           <asp:Label ID="lblCLBH" runat="server" Text='<%#Eval("CLBH") %>'></asp:Label>
                       </ItemTemplate>
                       
                   </asp:TemplateField>

                   <asp:TemplateField HeaderText=" Ten Hang 品名 ">
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
                        <ItemStyle HorizontalAlign="Center" />
                   </asp:TemplateField>

                   <asp:TemplateField  HeaderText="Quy Cach 規格- 種類:">
                       <ItemTemplate>
                           <asp:Label ID="lblDWBH" runat="server" Text='<%#Eval("dwbh") %>'></asp:Label>
                       </ItemTemplate>
                       <ItemStyle Width="50px" />
                        <ItemStyle HorizontalAlign="Center" />
                   </asp:TemplateField>

                   <asp:TemplateField HeaderText=" So luong 數量 ">
                       <ItemTemplate>
                           <asp:Label ID="lblQty" runat="server" Text='<%#Eval("Qty","{0:0,0}") %>'></asp:Label>
                       </ItemTemplate>
                       <ItemStyle Width="50px"  HorizontalAlign="Center"/>
                   </asp:TemplateField>

                   <asp:TemplateField HeaderText="Ghi Chu 備註 ">
                       <ItemTemplate>
                           <asp:Label ID="lblCLMemo" runat="server" Text='<%#Eval("CLmemo") %>'></asp:Label>
                       </ItemTemplate>
                       <ItemStyle Width="340px" />
                   </asp:TemplateField>
                   <asp:TemplateField Visible="false">
                       <ItemTemplate>
                           <asp:Label ID="lblCGNO" runat="server" Text='<%#Eval("CGNO") %>'></asp:Label>
                       </ItemTemplate>
                   </asp:TemplateField>
                   <asp:TemplateField Visible="false">
                       <ItemTemplate>
                           <asp:Label ID="lblZSBH" runat="server" Text='<%#Eval("ZSBH") %>'></asp:Label>
                       </ItemTemplate>
                   </asp:TemplateField>
               </Columns>
           </asp:GridView>
     <div id="divUpload2" runat="server" style="text-align:center;margin-left:150px; width: 987px;">
        <p style="width:587px; text-align:center;" > Attact File </p>
        <asp:GridView ID="gvDetails" CssClass="Gridview" runat="server" AutoGenerateColumns="False" DataKeyNames="FilePath" OnRowDeleting="gvDetails_RowDeleting">
            <HeaderStyle BackColor="#df5015" />
            <Columns>
                 <asp:TemplateField HeaderText="ID" Visible="false">
                     <ItemTemplate>
                        <asp:Label ID="lblIDAttactFile" runat="server" Text='<%#Eval("ID") %>'></asp:Label>
                    </ItemTemplate>
                   
                </asp:TemplateField>
            <asp:BoundField DataField="Filename" HeaderText="File Name" >
                <ItemStyle Width="200px" HorizontalAlign="Center" />
                
                </asp:BoundField>
            <asp:TemplateField HeaderText="Download File">
            <ItemTemplate>
               <asp:LinkButton ID="lnkDownload" runat="server" Text="" OnClick="lnkDownload_Click" ><img src="../../Content/Icon/download.png" /> Download</asp:LinkButton>
            </ItemTemplate>
                <ItemStyle Width="100px" HorizontalAlign="Center" />
            </asp:TemplateField>
               
            </Columns>
        </asp:GridView>
    </div>
    <p style="width:902px; margin-left:10px"> <%#hasLanguege["lblGuiNguoiDuyet"].ToString() %>
        <asp:TextBox ID="txtPhanHoi" runat="server" Width="760px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtPhanHoi" ForeColor="Red" ValidationGroup="groupThem" Text="Not Null" ErrorMessage="Not Null"></asp:RequiredFieldValidator>
    </p>
    <table style="margin-left:200px">
        <tr>
            <td></td>
        </tr>
        <tr>
            <td>
               <%#hasLanguege["lblNguoiĐangDuyet"].ToString() %> 
            </td>
            <td>
                <asp:TextBox ID="txtNguoiCoDUyet" runat="server" ReadOnly="True"></asp:TextBox>
            </td>
        </tr>
       
            
    </table>
     <table style="margin-left:250px">
        <tr>
            <td></td>
        </tr>
        <tr>
            <td>
                <asp:CheckBox ID="CheckChon" runat="server" Text="Gửi Người Dịch Phiếu" OnCheckedChanged="CheckChon_CheckedChanged" AutoPostBack="True" />
            </td>
            <td>
                <asp:DropDownList ID="DropDownNguoiDich" runat="server" AutoPostBack="true"></asp:DropDownList></td>
        </tr>
       
            
    </table>
    <br />
    <div style="width:900px;text-align:center" class="button-wrap">
        <asp:Button ID="btnBack" runat="server" BackColor="#F0CCFF" ForeColor="Blue" CssClass="button Cancel" Text="Back" OnClick="btnBack_Click" Width="69px" />  &nbsp;  &nbsp; 
       
        <asp:Button ID="btnEdit" runat="server" BackColor="#F0CCFF" ForeColor="Blue" CssClass="button edit" Text="Sửa" Width="101px" OnClick="btnEdit_Click" /> &nbsp;  &nbsp; 
        <asp:Button ID="btnLuu" runat="server" BackColor="#F0CCFF" ForeColor="Blue" CssClass="button Continue" ValidationGroup="groupThem" Text="Lưu Và Chuyển Tới Người Duyệt Phiếu" Width="264px" OnClick="btnLuu_Click" />&nbsp;  &nbsp;
        <asp:Button ID="btnGuiNguoiDich" runat="server" BackColor="#F0CCFF" ForeColor="Blue" CssClass="button Translate"   Text="Gửi Người Dịch" OnClick="btnGuiNguoiDich_Click" Width="130px" />
    </div>
    <div id="divaa" style="display:none">
        <asp:TextBox ID="txtNguoiChoDuyetID" runat="server" ></asp:TextBox>
        <asp:TextBox ID="txtDepartID" runat="server"></asp:TextBox>
    </div>
       
    </div>
</asp:Content>
