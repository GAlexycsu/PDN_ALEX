<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMater/MyDocus.Master" AutoEventWireup="true" CodeBehind="frmSuaphieumuahang.aspx.cs" Inherits="iOffice.presentationLayer.ApproveUser.frmSuaphieumuahang" %>
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
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--<asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
                          </asp:ToolkitScriptManager>--%>
    <div style="margin-left:20px">
      <p style="text-align:left"> Công ty TNHH Tỷ Hùng 億 雄 責 任 有 限 公 司"</p>
       <p style="text-align:right; width:1082px">
           <asp:Label ID="lblsophieu" runat="server" Text=""></asp:Label> </p>
       <p style="text-align:center">
           <asp:Label ID="lblPhieuMuaHang" runat="server" Text=""></asp:Label></p>
    <p style="width:1060px"> Tiêu đề 题目:
        <asp:TextBox ID="txtTieuDe" runat="server" TextMode="MultiLine" Width="926px"></asp:TextBox>
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
                   <asp:Label ID="lblMucDichSuDung" runat="server" Text=""></asp:Label>
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
                       <asp:TextBox ID="txtAutoComplete"  runat="server" ClientIDMode="Static" Class="autosuggest" TextMode="MultiLine" Width="439px" Height="31px" ></asp:TextBox>

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
                       <asp:Button ID="Button1" runat="server" Text="Save" CssClass="button save" ValidationGroup ="groupthemmoi" OnClick="Button1_Click1" Height="35px" Width="72px" /></td>
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
                   <asp:TemplateField HeaderText="Edit ">
                       <ItemTemplate>
                        <asp:LinkButton ID="btnEdit" Text="Edit" runat="server" CommandName="Edit" ><img src="../../Content/Icon/edit.gif" />Edit</asp:LinkButton>
                        

                    </ItemTemplate>
                    <ItemStyle Width="7%" />
                   </asp:TemplateField>
                   <asp:TemplateField HeaderText="Delete">
                       <ItemTemplate>
                        
                        <span onclick="return confirm('Are you sure want to delete?')">
                            <asp:LinkButton ID="btnDelete" Text="Delete" runat="server" CommandName="Delete" ><img src="../../Content/Icon/delete.png" />Delete </asp:LinkButton>
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

                   <asp:TemplateField HeaderText=" Ten Hang">
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

                   <asp:TemplateField  HeaderText="Quy Cach">
                       <ItemTemplate>
                           <asp:Label ID="lblDWBH" runat="server" Text='<%#Eval("dwbh") %>'></asp:Label>
                       </ItemTemplate>
                       <ItemStyle Width="50px" />
                        <ItemStyle HorizontalAlign="Center" />
                   </asp:TemplateField>

                   <asp:TemplateField HeaderText=" So luong">
                       <ItemTemplate>
                           <asp:Label ID="lblQty" runat="server" Text='<%#Eval("Qty","{0:0,0}") %>'></asp:Label>
                       </ItemTemplate>
                       <ItemStyle Width="50px" />
                        <ItemStyle HorizontalAlign="Center" />
                   </asp:TemplateField>

                   <asp:TemplateField HeaderText="Ghi Chu">
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
    <div id="divUpload2" runat="server">
        <p style="width:771px; text-align:center;" > Attact File </p>
        <asp:GridView ID="gvDetails" CssClass="Gridview" runat="server" AutoGenerateColumns="False" DataKeyNames="FilePath" Width="446px">
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
        <br />
    <div class="button-wrap" style="text-align:center; width:900px"> 
        <asp:Button ID="btnTroLai" runat="server" BackColor="#F0CCFF" CssClass="button Cancel" ForeColor="Blue" Text="Trở lại/脊背" OnClick="btnTroLai_Click" Width="124px" />
&nbsp; <asp:Button ID="btnComplete" runat="server" BackColor="#F0CCFF" ForeColor="Blue" CssClass="button Complete" Text="Hoàn tất / 完毕" OnClick="btnComplete_Click" Width="156px" /></div>
    </div>
</asp:Content>
