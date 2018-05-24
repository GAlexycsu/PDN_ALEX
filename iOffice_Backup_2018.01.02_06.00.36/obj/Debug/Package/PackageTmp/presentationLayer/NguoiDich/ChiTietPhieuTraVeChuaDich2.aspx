<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMater/MyDocusND.Master" AutoEventWireup="true" CodeBehind="ChiTietPhieuTraVeChuaDich2.aspx.cs" Inherits="iOffice.presentationLayer.NguoiDich.ChiTietPhieuTraVeChuaDich2" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit"
         TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <script src="../../Scripts/jquery.min.js"></script>
    <script src="../../Scripts/jquery-ui.min.js"></script>
    <script src="../../Scripts/jquery-1.9.1.js"></script>
    <script src="../../Scripts/nhapso.js"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <p style="text-align:left"> Công ty TNHH Tỷ Hùng 億 雄 責 任 有 限 公 司"</p>
       <p style="text-align:right; width:1058px">
           <asp:Label ID="lblsophieu" runat="server" Text=""></asp:Label> </p>
       <p style="text-align:center; width: 1099px; height: 17px;">
           <asp:Label ID="lbLoaiPhieu" runat="server" Text=""></asp:Label></p>
    <p style="text-align:left;">Tiêu đề 题目:
              
                    <asp:Label ID="lblTieuDe" runat="server" Text=""></asp:Label><br />
                    <asp:TextBox ID="txtTieuDe" runat="server" Width="1084px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="groupHoanTat" ControlToValidate="txtTieuDe" Text="*" ForeColor="Red" ErrorMessage=""></asp:RequiredFieldValidator>
   </p>
       <table style="float:left;width:1100px; border: 1px solid black;border-collapse: collapse;" >
           <tr style="width:800px;border: 1px solid black;border-collapse: collapse;">
               <td  class="auto-style1" style="border: 1px solid black;border-collapse: collapse;">
                   Đơn vị đề nghị:<br />
                      提议单位 :
                    <asp:Label ID="lbldonvidenghi" runat="server" Text=""></asp:Label>
               </td>
              <td class="auto-style1" style="border: 1px solid black;border-collapse: collapse;" >
                  <asp:Label ID="lblNgaytao" runat="server" Text=""></asp:Label></td>
           </tr>
           <tr  style="border: 1px solid black;border-collapse: collapse;">
               <td colspan="2"  style="text-align:left;border: 1px solid black;border-collapse: collapse; ">
                   Mục đích sử dụng: <br />
                   
                  <asp:TextBox ID="txtMucDich" runat="server" TextMode="MultiLine" Width="1074px"></asp:TextBox>
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"  ErrorMessage="" Text="*" ForeColor="Red" ControlToValidate="txtMucDich" ValidationGroup="groupHoanTat"></asp:RequiredFieldValidator>
              </td>
           </tr>

       </table>
    <div style="width:1101px; text-align:left">
      <div style="width:1100px;  text-align:left">
         <table style="float:left; width: 1100px;text-align:left" id="tablePMH" runat="server">
               <tr >
                 
                   <td class="auto-style6">
                       TÊN HÀNG 品名
                   </td>
                   
                    <td class="auto-style7">
                       GHI CHÚ<br />
                        備註
                   </td>
                   <td class="auto-style8"></td>
               </tr>
             <tr>
                 
                 <td class="auto-style5">
                     <asp:Label ID="lblTenHangD" runat="server" Text=""></asp:Label>
                 </td>
                 <td class="auto-style9">
                     <asp:Label ID="lblGhiChuD" runat="server" Text=""></asp:Label>
                 </td>
                 <td class="auto-style2"></td>
             </tr>
               <tr style="text-align:center"> 
               
                   
                   <td  style="text-align:left" class="auto-style5" >
                       <asp:TextBox ID="txtAutoComplete"  runat="server" ClientIDMode="Static" Class="autosuggest" TextMode="MultiLine" Width="611px" Height="48px" ></asp:TextBox>

                   </td>
                  
                   <td class="auto-style9"  >
                       <asp:TextBox ID="txtGhiChu" runat="server" style="margin-left: 0px" Height="48px" TextMode="MultiLine" Width="326px"></asp:TextBox></td>
                   <td class="button-wrap">
                       <asp:Button ID="Button1" runat="server" Text="Save" CssClass="button save" ValidationGroup ="groupthemmoi" OnClick="Button1_Click1" Height="43px" Width="71px" /></td>
               </tr>
               <tr>
                   <td class="auto-style5">
                       
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="" Text="*" ControlToValidate="txtAutoComplete" ForeColor="Red" ValidationGroup="groupthemmoi"></asp:RequiredFieldValidator>
                   </td>
                   <td class="auto-style9">

                   </td>
                   <td>
                       <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="" Text="*" ControlToValidate="txtdonvitinh" ForeColor="Red" ValidationGroup="groupthemmoi"></asp:RequiredFieldValidator>--%>
                   </td>
                   <td>
                       
                   </td>
                   <td>

                   </td>
               </tr>
           </table>
    </div>
       <asp:GridView ID="GridView1" runat="server" Width="1100px" AutoGenerateColumns="False" OnRowEditing="GridView1_RowEditing" style="margin-right: 0px" OnRowDataBound="GridView1_RowDataBound" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4">
               <Columns>
                   <asp:TemplateField HeaderText="Dịch Phiếu">
                       <ItemTemplate>
                        <asp:LinkButton ID="btnEdit" Text="" runat="server" CommandName="Edit"><img src="../../Content/img/edit16x16.png" />Translate </asp:LinkButton>
                        
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

                   <asp:TemplateField HeaderText=" Tên Hàng 品名 ">
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

                   <asp:TemplateField  HeaderText="Quy Cách 規格- 種類: ">
                       <ItemTemplate>
                           <asp:Label ID="lblDWBH" runat="server" Text='<%#Eval("dwbh") %>'></asp:Label>
                       </ItemTemplate>
                       <ItemStyle Width="50px" />
                   </asp:TemplateField>

                   <asp:TemplateField HeaderText=" Số Lượng數量">
                       <ItemTemplate>
                           <asp:Label ID="lblQty" runat="server" Text='<%#Eval("Qty","{0:0,0}") %>'></asp:Label>
                       </ItemTemplate>
                       <ItemStyle Width="50px" />
                   </asp:TemplateField>

                   <asp:TemplateField HeaderText="Ghi Chú備註  ">
                       <ItemTemplate>
                           <asp:Label ID="lblCLMemo" runat="server" Text='<%#Eval("CLmemo") %>'></asp:Label>
                       </ItemTemplate>
                       <ItemStyle Width="340px" />
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

    <div class="button-wrap" style="text-align:center; width:1000px;">
        <asp:Button ID="btncomplete" runat="server" CssClass="button Complete" BackColor="#F0CCFF" ForeColor="Blue" Text="Hoàn tất/完整" ValidationGroup="groupHoanTat" OnClick="btncomplete_Click" Height="18px" Width="111px" />  &nbsp; &nbsp;
      
        <asp:Button ID="btnCancel" runat="server" CssClass="button Cancel" BackColor="#F0CCFF" ForeColor="Blue" Text="Cancel" OnClick="btnCancel_Click" Width="92px" />
    </div>
    <div style="display:none">
        <asp:TextBox ID="txtNguoiDUyet" runat="server"></asp:TextBox>
    </div>
</asp:Content>
