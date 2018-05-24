<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMater/MyDocus.Master" AutoEventWireup="true" CodeBehind="chitietphieudadichNV.aspx.cs" Inherits="iOffice.presentationLayer.Users.chitietphieudadichNV" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../../Scripts/jquery.min.js"></script>
    <script src="../../Scripts/jquery-ui.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div style="border-style: solid; border-color: inherit; border-width: 1px; width: 99%; margin-left:20px">
<div id="divPhieuDeNghi" runat="server">
        <table style="width: 1070px;  overflow:hidden">
            <tr>
                <td class="auto-style4"  ><asp:Label ID="lbCty" runat="server" Text="Công ty TNHH Tỷ Hùng 億 雄 責 任 有 限 公 司"></asp:Label>
                    <asp:Label ID="lbSoPhieu" runat="server" Text="" style="float:right"></asp:Label>
                </td>
            </tr>
          <tr>
              <td style="text-align:center" class="auto-style8"> <asp:Label ID="lbLoaiPhieu" runat="server" Text="" ></asp:Label></td>
          </tr>
         <tr>
             <td class="auto-style6" ><asp:Label ID="Label3" runat="server" Text="Trình ban lãnh đạo công ty TNHH Tỷ Hùng 呈亿雄公司主管部"></asp:Label> </td>
         </tr>
         <tr>
             <td class="auto-style3" >Đơn vị đề nghị 提议单位 : <asp:Label ID="lbBoPhan" runat="server" Text=""></asp:Label> </td>
         </tr>
        <tr>
            <td class="auto-style2" >
               Nội dung 内容:&nbsp;&nbsp; 
            
                <div style="overflow:hidden; width:1039px">
                    <asp:Label ID="lbNoiDung" runat="server" Text=""></asp:Label>
                </div>
            </td>
        </tr>
        <tr>
            <td class="auto-style9">Nội dung dịch 翻译内容 :&nbsp;&nbsp; 
                <div style="overflow:hidden; width:1036px">
                    <asp:Label ID="LbNoiDungDich" runat="server" Text=""></asp:Label>
                </div>
            </td>
        </tr>
         <tr>
              <td  style="text-align:right" class="auto-style10">  
         
                 <asp:Label ID="lbNgay" runat="server" Text=""></asp:Label>
         
              </td>
  
          </tr>
          
   
       </table>
    </div>
    <div id="divPhieuMuaHang" runat="server">
         <p style="text-align:left"> Công ty TNHH Tỷ Hùng 億 雄 責 任 有 限 公 司"</p>
       <p style="text-align:right; width:1042px">
           <asp:Label ID="lblsophieu" runat="server" Text=""></asp:Label> </p>
       <p style="text-align:center">
           <asp:Label ID="TenLblLoaiPhieu" runat="server" Text=""></asp:Label></p>
        <table style="float:left;width:1070px; border: 1px solid black;border-collapse: collapse; margin-bottom:-1px;" >
           <tr style="width:1070px;">
               <td  style="border: 1px solid black;border-collapse: collapse; width:450px;">
                   Đơn vị đề nghị:<br />
                      提议单位 :
                    <asp:Label ID="lbldonvidenghi" runat="server" Text=""></asp:Label>
               </td>
              <td style="border: 1px solid black;border-collapse: collapse; text-align:center">
                  <asp:Label ID="lblNgaytao" runat="server" Text=""></asp:Label></td>
           </tr>
           <tr style="width:1070px;">
               <td colspan="2" style="text-align:left;border: 1px solid black;border-collapse: collapse;">
                   Mục đích sử dụng: <br />
                   使用目的:
                   <asp:Label ID="lblMucDichSuDung" runat="server" Text=""></asp:Label>
               </td>
              
           </tr>
       </table>
       <div style="width:800px; float:left">
           <asp:GridView ID="GridView1" runat="server" Width="1070px" AutoGenerateColumns="False" style="margin-right: 0px">
               <Columns>
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

                   <asp:TemplateField HeaderText=" TÊN HÀNG">
                       <ItemTemplate>
                           <asp:Label ID="lblMemo0" runat="server" Text='<%#Eval("Memo0") %>'></asp:Label>
                       </ItemTemplate>
                       <ItemStyle Width="500px" />
                   </asp:TemplateField>

                   <asp:TemplateField HeaderText=" Size">
                       <ItemTemplate>
                           <asp:Label ID="lblSize" runat="server" Text='<%#Eval("Size") %>'></asp:Label>
                       </ItemTemplate>
                       <ItemStyle Width="30px" />
                   </asp:TemplateField>

                   <asp:TemplateField  HeaderText="QUY CÁCH - CHỦNG LOẠI 規格">
                       <ItemTemplate>
                           <asp:Label ID="lblDWBH" runat="server" Text='<%#Eval("dwbh") %>'></asp:Label>
                       </ItemTemplate>
                       <ItemStyle Width="50px" />
                   </asp:TemplateField>

                   <asp:TemplateField HeaderText=" SỐ LƯỢNG 數量">
                       <ItemTemplate>
                           <asp:Label ID="lblQty" runat="server" Text='<%#Eval("Qty") %>'></asp:Label>
                       </ItemTemplate>
                       <ItemStyle Width="50px" />
                   </asp:TemplateField>

                   <asp:TemplateField HeaderText="GHI CHÚ 備註">
                       <ItemTemplate>
                           <asp:Label ID="lblCLMemo" runat="server" Text='<%#Eval("CLmemo") %>'></asp:Label>
                       </ItemTemplate>
                       <ItemStyle Width="340px" />
                   </asp:TemplateField>
                   
               </Columns>
           </asp:GridView>
    </div>
    </div>
        <br />
    <div class="button-wrap" style="width:1000px; text-align:center">
         <asp:Button ID="btnUndo" runat="server" BackColor="#F0CCFF" ForeColor="Blue" CssClass="button Cancel" Text="Quay lại" OnClick="btnUndo_Click" Width="109px" />
        <asp:Button ID="btnContinus" runat="server" BackColor="#F0CCFF" ForeColor="Blue" CssClass="button Continue" Text="Tiếp tục" OnClick="btnContinus_Click" Width="97px" />
    </div>
    </div>
</asp:Content>
