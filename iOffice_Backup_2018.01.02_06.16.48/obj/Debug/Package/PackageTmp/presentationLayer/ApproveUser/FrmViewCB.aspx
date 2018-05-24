<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMater/MyDocus.Master" AutoEventWireup="true" CodeBehind="FrmViewCB.aspx.cs" Inherits="iOffice.presentationLayer.ApproveUser.FrmViewCB" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../../Scripts/jquery.min.js"></script>
    <script src="../../Scripts/jquery-ui.min.js"></script>
    <script>
        function myFunction() {
            window.print(Content2);
        }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="border-style: solid; border-color: inherit; width:99%; border-width:1px; margin-left:20px">
      <div id="divPhieuDeNghi" runat="server">
         <table style="width: 1074px;  overflow:hidden">
            <tr>
                <td class="auto-style4"  ><asp:Label ID="lbCty" runat="server" Text="Công ty TNHH Tỷ Hùng 億 雄 責 任 有 限 公 司"></asp:Label>
                    <asp:Label ID="lbSoPhieu" runat="server" Text="" style="float:right"></asp:Label>
                </td>
            </tr>
            <tr> <td style="float:right">
              <a href="frmchitietphieu.aspx" <asp:Label ID="Label1Sophieucu" runat="server" Text="Số phiếu cũ 旧的单号 :"></asp:Label> <asp:Label ID="Label2cophieucu" runat="server" Text=""></asp:Label>
                  </a></td></tr>
          <tr>
              <td class="auto-style2" style="text-align:center"> <asp:Label ID="lbLoaiPhieu" runat="server" Text="" ></asp:Label></td>
          </tr>
         <tr>
             <td class="auto-style3"><asp:Label ID="Label3" runat="server" Text="Trình ban lãnh đạo công ty TNHH Tỷ Hùng 呈亿雄公司主管部"></asp:Label> </td>
         </tr>
         <tr>
             <td class="auto-style2">Đơn vị đề nghị 提议单位 : <asp:Label ID="lbBoPhan" runat="server" Text=""></asp:Label> </td>
         </tr>
        <tr>
            <td>
                Tiêu đề 题目: <asp:Label ID="lblTieuDe" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">
               Nội dung 内容:&nbsp;&nbsp; 
            
                <div style="overflow:hidden; width:800px">
                    <asp:Label ID="lbNoiDung" runat="server" Text=""></asp:Label>
                </div>
            </td>
        </tr>
         <tr>
              <td class="auto-style2" style="text-align:right">  
         
                 <asp:Label ID="lbNgay" runat="server" Text=""></asp:Label>
         
              </td>
  
          </tr>
          
   
     </table>
    </div>
   <div id="divPhieuMuaHang" runat="server">
       <p style="text-align:left"> Công ty TNHH Tỷ Hùng 億 雄 責 任 有 限 公 司"</p>
       <p style="text-align:right; width:1059px">
           <asp:Label ID="lblsophieu" runat="server" Text=""></asp:Label> </p>
        <p id="phieumuahangcu" runat="server" style="float:right">
              <a href="frmchitietphieu1.aspx?lblsoPhieucu1" <asp:Label ID="Labelsophieucu1" runat="server" Text="Số phiếu cũ 旧的单号 :"></asp:Label> <asp:Label ID="lblsoPhieucu1" runat="server" Text=""></asp:Label>
                  </a></p>
       <p style="text-align:center">
           <asp:Label ID="lblloaiphieumh" runat="server" Text=""></asp:Label></p>
       <p>
           Tiêu đề 题目:<asp:Label ID="lbTieuDe" runat="server" Text=""></asp:Label>
       </p>
       <table style="float:left;width:1100px; border-collapse: collapse; " >
           <tr style="width:870px;">
               <td  class="auto-style5" style="border: 1px solid black;border-collapse: collapse;">
                   Đơn vị đề nghị:<br />
                      提议单位 :
                    <asp:Label ID="lbldonvidenghi" runat="server" Text=""></asp:Label>
               </td>
              <td style="border: 1px solid black;border-collapse: collapse;">
                  <asp:Label ID="lblNgaytao" runat="server" Text=""></asp:Label></td>
           </tr>
           <tr style="width:870px;">
               <td colspan="2" style="text-align:left;border: 1px solid black;border-collapse: collapse;">
                   Mục đích sử dụng: <br />
                   <asp:Label ID="lblMucDichSuDung" runat="server" Text=""></asp:Label>
               </td>
              
           </tr>
       </table>
       <div style="width:870px; float:left;">
<%--           <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BorderColor="Black" Font-Size="Small" CellPadding="5" CellSpacing="1" Font-Names="Arial"  >
               <AlternatingRowStyle Font-Size="Small" />
           <Columns>
               <asp:TemplateField HeaderText="STT">
                      <ItemTemplate><%#GetSTT() %></ItemTemplate>
                      <ItemStyle Width="50px" />
                </asp:TemplateField>
               <asp:BoundField DataField="OfSuppliesName" HeaderText="TÊN HÀNG" >
               <ItemStyle Width="370px" />
               </asp:BoundField>
               <asp:BoundField DataField="BUnit" HeaderText="QUY CÁCH - CHỦNG LOẠI 規格" >
             
                   <ItemStyle HorizontalAlign="Center" Width="100px" />
               </asp:BoundField>
               <asp:BoundField DataField="BNumber" HeaderText="SỐ LƯỢNG 數量" >
         
                   <ItemStyle HorizontalAlign="Center" Width="100px" />
               </asp:BoundField>
               <asp:BoundField DataField="BCommnent" HeaderText="GHI CHÚ 備註" >
               <ItemStyle Width="250px" />
               </asp:BoundField>
           </Columns>

       </asp:GridView>--%>
       <asp:GridView ID="GridView1" runat="server" Width="1100px" AutoGenerateColumns="False" style="margin-right: 0px">
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
                        <ItemStyle HorizontalAlign="Center" />
                   </asp:TemplateField>

                   <asp:TemplateField  HeaderText="QUY CÁCH - CHỦNG LOẠI 規格">
                       <ItemTemplate>
                           <asp:Label ID="lblDWBH" runat="server" Text='<%#Eval("dwbh") %>'></asp:Label>
                       </ItemTemplate>
                       <ItemStyle Width="50px" />
                        <ItemStyle HorizontalAlign="Center" />
                   </asp:TemplateField>

                   <asp:TemplateField HeaderText=" SỐ LƯỢNG 數量">
                       <ItemTemplate>
                           <asp:Label ID="lblQty" runat="server" Text='<%#Eval("Qty","{0:0,0}") %>'></asp:Label>
                       </ItemTemplate>
                       <ItemStyle Width="50px" />
                        <ItemStyle HorizontalAlign="Center" />
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
      <%--  <table id="tabletam" runat="server" style="border-left: 1px solid black; border-right: 1px solid black; border-bottom: 1px solid black; width:1080px; float:left; border-collapse: collapse; border-top-style: hidden; border-top-color: inherit; border-top-width: medium;" >
          <tr >
              <td style="text-align:left;border: 1px solid black;border-collapse: collapse; width:30px;height:25px"></td>
              <td style="text-align:left;border: 1px solid black;border-collapse: collapse; width:500px;height:25px"></td>
              <td style="text-align:left;border: 1px solid black;border-collapse: collapse; width:30px;height:25px"></td>
              <td style="text-align:left;border: 1px solid black;border-collapse: collapse; width:50px;height:25px"></td>
              <td style="text-align:left;border: 1px solid black;border-collapse: collapse; width:50px;height:25px"></td>
              <td style="text-align:left;border: 1px solid black;border-collapse: collapse; width:340px;height:25px"></td>
          </tr>
          <tr >
              <td style="text-align:left;border: 1px solid black;border-collapse: collapse; width:57px;height:25px"></td>
              <td style="text-align:left;border: 1px solid black;border-collapse: collapse; width:357px;height:25px"></td>
              <td style="text-align:left;border: 1px solid black;border-collapse: collapse; width:106px;height:25px"></td>
              <td style="text-align:left;border: 1px solid black;border-collapse: collapse; width:106px;height:25px"></td>
              <td style="text-align:left;border: 1px solid black;border-collapse: collapse; width:244px;height:25px"></td>
          </tr>
             <tr >
              <td style="text-align:left;border: 1px solid black;border-collapse: collapse; width:57px;height:25px"></td>
              <td style="text-align:left;border: 1px solid black;border-collapse: collapse; width:357px;height:25px"></td>
              <td style="text-align:left;border: 1px solid black;border-collapse: collapse; width:106px;height:25px"></td>
              <td style="text-align:left;border: 1px solid black;border-collapse: collapse; width:106px;height:25px"></td>
              <td style="text-align:left;border: 1px solid black;border-collapse: collapse; width:244px;height:25px"></td>
          </tr>
             <tr >
              <td style="text-align:left;border: 1px solid black;border-collapse: collapse; width:57px;height:25px"></td>
              <td style="text-align:left;border: 1px solid black;border-collapse: collapse; width:357px;height:25px"></td>
              <td style="text-align:left;border: 1px solid black;border-collapse: collapse; width:106px;height:25px"></td>
              <td style="text-align:left;border: 1px solid black;border-collapse: collapse; width:106px;height:25px"></td>
              <td style="text-align:left;border: 1px solid black;border-collapse: collapse; width:244px;height:25px"></td>
          </tr>
             <tr >
              <td style="text-align:left;border: 1px solid black;border-collapse: collapse; width:57px;height:25px"></td>
              <td style="text-align:left;border: 1px solid black;border-collapse: collapse; width:357px;height:25px"></td>
              <td style="text-align:left;border: 1px solid black;border-collapse: collapse; width:106px;height:25px"></td>
              <td style="text-align:left;border: 1px solid black;border-collapse: collapse; width:106px;height:25px"></td>
              <td style="text-align:left;border: 1px solid black;border-collapse: collapse; width:244px;height:25px"></td>
          </tr>
             <tr >
              <td style="text-align:left;border: 1px solid black;border-collapse: collapse; width:57px;height:25px"></td>
              <td style="text-align:left;border: 1px solid black;border-collapse: collapse; width:357px;height:25px"></td>
              <td style="text-align:left;border: 1px solid black;border-collapse: collapse; width:106px;height:25px"></td>
              <td style="text-align:left;border: 1px solid black;border-collapse: collapse; width:106px;height:25px"></td>
              <td style="text-align:left;border: 1px solid black;border-collapse: collapse; width:244px;height:25px"></td>
          </tr>
             <tr >
              <td style="text-align:left;border: 1px solid black;border-collapse: collapse; width:57px;height:25px"></td>
              <td style="text-align:left;border: 1px solid black;border-collapse: collapse; width:357px;height:25px"></td>
              <td style="text-align:left;border: 1px solid black;border-collapse: collapse; width:106px;height:25px"></td>
              <td style="text-align:left;border: 1px solid black;border-collapse: collapse; width:106px;height:25px"></td>
              <td style="text-align:left;border: 1px solid black;border-collapse: collapse; width:244px;height:25px"></td>
          </tr>

      </table>--%>
   </div>
 </div>
     <p style="width:500px; text-align:center; color:white;"> Choose file</p>
    <div class="button-wrap" id="divUpload1" runat="server" style="text-align:left; float:none; margin-left:120px">
        <asp:FileUpload ID="fileUpload1" runat="server" /><br />
         <asp:Button ID="btnUpload" CssClass="button Up" runat="server" Text="Upload" onclick="btnUpload_Click" Height="16px" Width="123px" />
    </div>
    <br />
    <div id="divUpload2" runat="server" style="text-align:center;float:none; margin-left:20px">
        <p style="width:1131px; text-align:center;" > Attact File </p>
        <asp:GridView ID="gvDetails" CssClass="Gridview" runat="server"  AutoGenerateColumns="False" DataKeyNames="FilePath" OnRowDeleting="gvDetails_RowDeleting" Width="622px">
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
             <%--    <asp:CommandField ShowDeleteButton="True" />--%>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID="linkDelete" runat="server" CommandName="Delete" OnClientClick="return confirm('Are you sure?')"><img src="../../Content/Icon/delete.png" /> Delete</asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
    <br />
    <div class="button-wrap" style="width:1024px;text-align:center;float:none"> 
        <asp:Button ID="btnBack" runat="server" CssClass="button Cancel" BackColor="#F0CCFF" ForeColor="Blue" Text="Back" OnClick="btnBack_Click" Width="91px" /> &nbsp; &nbsp;  
         <asp:Button ID="btnDelete" runat="server" CssClass="button delete" BackColor="#F0CCFF" ForeColor="Blue" Text="Delete" OnClick="btnDelete_Click" Width="85px" />&nbsp; &nbsp;  
        <asp:Button ID="btnEdit" runat="server" CssClass="button edit" BackColor="#F0CCFF" ForeColor="Blue" Text="Edit" OnClick="btnEdit_Click" Width="109px" Height="16px" />&nbsp; &nbsp; 
        <asp:Button ID="Button2" runat="server" CssClass="button Translate" BackColor="#F0CCFF" ForeColor="Blue" Text="Nhờ người dịch" OnClick="btnNhoNguoi_Click" Width="200px" />&nbsp; &nbsp; 
        <asp:Button ID="Button3" runat="server" CssClass="button Continue" BackColor="#F0CCFF" ForeColor="Blue" Text="" OnClick="Button1_Click1" Width="194px" />
    </div>
</asp:Content>
