<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMater/Site1.Master" AutoEventWireup="true" CodeBehind="MyPreviewPDN.aspx.cs" Inherits="iOffice.presentationLayer.ApproveUser.MyPreviewPDN" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
      <style type="text/css">
        .auto-style2 {
            width: 589px;
        }
        .auto-style3 {
            width: 589px;
            height: 22px;
        }
        .auto-style4 {
            width: 589px;
            height: 74px;
        }
    </style>
    <script>
        function myFunction() {
            window.print(Content2);
        }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div style="border-style: solid; border-color: inherit; width:1148px; border-width:1px; ">
      <div id="divPhieuDeNghi" runat="server">
         <table style="width: 1066px;  overflow:hidden">
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
       <table style="float:left;width:1080px; border-collapse: collapse; " >
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
       <div style="width:1080px; float:left;">
           <asp:GridView ID="GridView1" runat="server" Width="1080" AutoGenerateColumns="False" BorderColor="Black" Font-Size="Small" CellPadding="5" CellSpacing="1" Font-Names="Arial"  >
               <AlternatingRowStyle Font-Size="Small" />
           <Columns>
              
               <asp:BoundField DataField="OfSuppliesName" HeaderText="TÊN HÀNG" >
               <ItemStyle Width="370px" />
               </asp:BoundField>
               <asp:BoundField DataField="BUnit" HeaderText="QUY CÁCH - CHỦNG LOẠI 規格" >
              <%-- <HeaderStyle Width="99px" />--%>
                   <ItemStyle HorizontalAlign="Center" Width="100px" />
               </asp:BoundField>
               <asp:BoundField DataField="BNumber" HeaderText="SỐ LƯỢNG 數量" >
              <%-- <HeaderStyle Width="90px" />--%>
                   <ItemStyle HorizontalAlign="Center" Width="100px" />
               </asp:BoundField>
               <asp:BoundField DataField="BCommnent" HeaderText="GHI CHÚ 備註" >
               <ItemStyle Width="250px" />
               </asp:BoundField>
           </Columns>

       </asp:GridView>
     
       </div>
        <table id="tabletam" runat="server" style="width:1080px; float:left;border: 1px solid black;border-collapse: collapse; border-top:hidden;" >
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
             <tr >
              <td style="text-align:left;border: 1px solid black;border-collapse: collapse; width:57px;height:25px"></td>
              <td style="text-align:left;border: 1px solid black;border-collapse: collapse; width:357px;height:25px"></td>
              <td style="text-align:left;border: 1px solid black;border-collapse: collapse; width:106px;height:25px"></td>
              <td style="text-align:left;border: 1px solid black;border-collapse: collapse; width:106px;height:25px"></td>
              <td style="text-align:left;border: 1px solid black;border-collapse: collapse; width:244px;height:25px"></td>
          </tr>

      </table>
   </div>
 </div>
     <p style="width:500px; text-align:center; color:white;"> Choose file</p>
    <div id="divUpload1" runat="server">
        <asp:FileUpload ID="fileUpload1" runat="server" /><br />
         <asp:Button ID="btnUpload" runat="server" Text="Upload" onclick="btnUpload_Click" />
    </div>
    <div id="divUpload2" runat="server">
        <p style="width:400px;text-align:center;" > Attact File </p>
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
               <asp:LinkButton ID="lnkDownload" runat="server" Text="Download" OnClick="lnkDownload_Click" ></asp:LinkButton>
            </ItemTemplate>
                <ItemStyle Width="100px" HorizontalAlign="Center" />
            </asp:TemplateField>
                 <asp:CommandField ShowDeleteButton="True" />
            </Columns>
        </asp:GridView>
    </div>
    <br />
    <br />
    <table>
         <tr>
             <td><asp:Button ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click" /></td>
             <td>
                 
                 <asp:Button ID="btnEdit" runat="server" Text="Edit" OnClick="btnEdit_Click" />
             </td>
            <td>
               <asp:Button ID="Button2" runat="server" Text="Nhờ người dịch" OnClick="btnNhoNguoi_Click" /></td>
           <td>  <asp:Button ID="Button3" runat="server" Text="" OnClick="Button1_Click1" style="width: 90px" /></td>
          
       </tr>  
    </table>
</asp:Content>
