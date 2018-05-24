<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMater/Site1.Master" AutoEventWireup="true" CodeBehind="frmTaoPhieu.aspx.cs" Inherits="iOffice.presentationLayer.ApproveUser.frmTaoPhieu" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit"
         TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <script src="../../Scripts/jquery-1.9.1.js"></script>
    <script src="../../Scripts/nhapso.js" type="text/javascript"></script>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%-- <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
                          </asp:ToolkitScriptManager>--%>
    <div style="margin-left:20px">
    <p></p>
    <table style="width: 766px">
        <tr>
              
             <td colspan="2"> <asp:Label ID="lbCty" runat="server" Text="Công ty TNHH Tỷ Hùng 億 雄 責 任 有 限 公 司"></asp:Label></td>
        </tr>
        <tr>
            
            <td style="width:120px">
                <asp:Label ID="lbLoaiPhieu" runat="server" Text="Loại phiếu 单别:"></asp:Label>
            </td>
            <td style="text-align:left;float:left"> <asp:DropDownList ID="DropLoaiPhieu" runat="server" OnSelectedIndexChanged="DropLoaiPhieu_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList></td>
        </tr>
        <tr>
            <td colspan="2"><asp:Label ID="lbTrinhBanLD" runat="server" Text="Trình ban lãnh đạo công ty TNHH Tỷ Hùng 呈亿雄公司主管部"></asp:Label> </td>
            
        </tr>
        <tr>
            <%--<td><%=hasLanguege["lbDonVi"].ToString() %></td>--%>
            <td class="auto-style1">
              
                <asp:Label ID="lbDonVi" runat="server" Text="Đơn vị đề nghị 提议单位 :"></asp:Label>
                
            </td>
            <td style="text-align:left;float:left"> <asp:DropDownList ID="DropDonVi" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDonVi_SelectedIndexChanged1"></asp:DropDownList></td>
        </tr>
        <tr>
           <%-- <td><%=hasLanguege["lbTieuDe"].ToString() %></td>--%>
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
           <table style="float:left" id="tablePMH1" runat="server">
               <tr >
                   <td class="auto-style2">
                       TÊN HÀNG 品名
                   </td>
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
                       <asp:TextBox ID="txtTenHang" runat="server" TextMode="MultiLine" Width="290px"></asp:TextBox>
                      
                       <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="" Text="*" ControlToValidate="txtTenHang" ForeColor="Red" ValidationGroup="groupthemmoi"></asp:RequiredFieldValidator>
                      
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
                   <td class="button-wrap">
                       <asp:Button ID="Button1" runat="server" BackColor="#F0CCFF" ForeColor="Blue" CssClass="button save" Text="Add" ValidationGroup ="groupthemmoi" OnClick="Button1_Click1" Height="35px" Width="96px" /></td>
               </tr>
           </table>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" ShowFooter="True" OnRowCommand="GridView1_RowCommand" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4" OnRowDeleting="GridView1_RowDeleting" OnRowUpdating="GridView1_RowUpdating" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowEditing="GridView1_RowEditing">
           
            <Columns>
               <asp:TemplateField HeaderText="STT &lt;br/&gt; 次序">
                      <ItemTemplate><%#GetSTT() %></ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Mã hàng" Visible="false">
                     <ItemTemplate>
                        <asp:Label ID="lblCustID" runat="server" Text='<%#Eval("IDOfSupplies") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:Label ID="lbladd" runat="server"></asp:Label>
                    </FooterTemplate>
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="TÊN HÀNG 品名" HeaderStyle-Width="30%">
                    <ItemTemplate>
                        <asp:Label ID="lblOfSuppliesName" runat="server" Text='<%#Eval("OfSuppliesName") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtOfSuppliesName" runat="server" Text='<%#Eval("OfSuppliesName") %>'></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="" ForeColor="Red" ControlToValidate="txtOfSuppliesName" Text="*" ValidationGroup="groupsua"></asp:RequiredFieldValidator>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="txtAddOfSuppliesName" runat="server" TextMode="MultiLine"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="" ValidationGroup="groupthem" Text="*" ForeColor="Red" ControlToValidate="txtAddOfSuppliesName"></asp:RequiredFieldValidator>
                    </FooterTemplate>
                    <HeaderStyle Width="15%"></HeaderStyle>
                </asp:TemplateField>
                  <asp:TemplateField HeaderText="QUY CÁCH-CHỦNG LOẠI 規格" HeaderStyle-Width="10%">
                    <ItemTemplate>
                        <asp:Label ID="lblBUnit" runat="server" Text='<%#Eval("BUnit") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtBUnit" runat="server" Text='<%#Eval("BUnit") %>'></asp:TextBox>
                         <asp:AutoCompleteExtender ID="txtName_AutoCompleteExtender" runat="server" 
                            DelimiterCharacters="" Enabled="True" ServiceMethod="GetCompletionList" 
                            TargetControlID="txtBUnit" UseContextKey="True" MinimumPrefixLength="1" CompletionInterval="10" EnableCaching="true" CompletionSetCount="3">
                         </asp:AutoCompleteExtender>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="" Text="*" ForeColor="Red" ControlToValidate="txtBUnit" ValidationGroup="groupsua"></asp:RequiredFieldValidator>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="txtAddBUnit" runat="server"></asp:TextBox>
                        <asp:AutoCompleteExtender ID="txtName_AutoCompleteExtender" runat="server" 
                            DelimiterCharacters="" Enabled="True" ServiceMethod="GetCompletionList" 
                            TargetControlID="txtAddBUnit" UseContextKey="True" MinimumPrefixLength="1" CompletionInterval="10" EnableCaching="true" CompletionSetCount="3">
                         </asp:AutoCompleteExtender>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="" Text="*" ForeColor="Red" ControlToValidate="txtAddBUnit" ValidationGroup="groupthem"></asp:RequiredFieldValidator>
                    </FooterTemplate>
                    <HeaderStyle Width="15%"></HeaderStyle>
                      <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                  <asp:TemplateField HeaderText="SỐ LƯỢNG 數量" HeaderStyle-Width="10%">
                    <ItemTemplate>
                        <asp:Label ID="lblBNumber" runat="server" Text='<%#Eval("BNumber") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtBNumber" runat="server" Text='<%#Eval("BNumber") %>' CssClass="groupOfTexbox"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ErrorMessage="" ForeColor="Red" ControlToValidate="txtBNumber" Text="*" ValidationGroup="groupsua"></asp:RequiredFieldValidator>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="txtAddBNumber" runat="server" CssClass="groupOfTexbox" ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="" Text="*" ForeColor="Red" ControlToValidate="txtAddBNumber" ValidationGroup="groupthem"></asp:RequiredFieldValidator>
                    </FooterTemplate>
                    <HeaderStyle Width="15%"></HeaderStyle>
                      <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="GHI CHÚ 備註" HeaderStyle-Width="10%">
                    <ItemTemplate>
                        <asp:Label ID="lblBCommnent" runat="server" Text='<%#Eval("BCommnent") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtBCommnent" runat="server" Text='<%#Eval("BCommnent") %>' TextMode="MultiLine"></asp:TextBox>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="txtAddBCommnent" runat="server" TextMode="MultiLine"></asp:TextBox>
                        
                    </FooterTemplate>
                    <HeaderStyle Width="15%"></HeaderStyle>
                </asp:TemplateField>
                
                 <asp:TemplateField HeaderText="Edit/Delete" HeaderStyle-Width="15%">
                    <ItemTemplate>
                        <asp:LinkButton ID="btnEdit" Text="Edit" runat="server" CommandName="Edit" />
                        <span onclick="return confirm('Are you sure want to delete?')">
                            <asp:LinkButton ID="btnDelete" Text="Delete" runat="server" CommandName="Delete" />
                        </span>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:LinkButton ID="btnUpdate" Text="Update" runat="server" CommandName="Update" ValidationGroup="groupsua" />
                        <asp:LinkButton ID="btnCancel" Text="Cancel" runat="server" CommandName="Cancel" />
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:Button ID="btnInsertRecord" runat="server" Text="Add" Height="30px" Width="60px" ValidationGroup="groupthem" CommandName="Insert"  />
                    </FooterTemplate>
                    <HeaderStyle Width="15%"></HeaderStyle>
                </asp:TemplateField>
            </Columns>

            <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
            <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
            <RowStyle BackColor="White" ForeColor="#330099" />
            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
            <SortedAscendingCellStyle BackColor="#FEFCEB" />
            <SortedAscendingHeaderStyle BackColor="#AF0101" />
            <SortedDescendingCellStyle BackColor="#F6F0C0" />
            <SortedDescendingHeaderStyle BackColor="#7E0000" />
        </asp:GridView>
    </div>
    <br />
    <table class="button-wrap" style="margin-left:200px">
        <tr>
            <td>
                <asp:Button ID="btnLuuTam" CssClass="button save" runat="server" Text="Lưu Tạm" OnClick="btnLuuTam_Click" Height="16px" Width="120px" />
            </td>
            <td>
                 <asp:Button ID="btnTiepTu" runat="server" CssClass="button Continue" Text="" OnClick="Button1_Click" Width="159px" />
            </td>
        </tr>
    </table>
    </div>
</asp:Content>
