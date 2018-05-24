<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMater/MyDocusND.Master" AutoEventWireup="true" CodeBehind="frmSuaphieumuahangND.aspx.cs" Inherits="iOffice.presentationLayer.NguoiDich.frmSuaphieumuahangND" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit"
         TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../Content/Site.css" rel="stylesheet" />
    <script src="../../Scripts/jquery.min.js"></script>
    <script src="../../Scripts/jquery-ui.min.js"></script>
    <script src="../../Scripts/jquery-1.9.1.js"></script>
    <script src="../../Scripts/nhapso.js"></script>
    
  

  
    <style type="text/css">
        .auto-style1 {
            height: 36px;
        }
    </style>

  

  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <p style="text-align:left"> Công ty TNHH Tỷ Hùng 億 雄 責 任 有 限 公 司"</p>
       <p style="text-align:right; width:1058px">
           <asp:Label ID="lblsophieu" runat="server" Text=""></asp:Label> </p>
       <p style="text-align:center; width: 1099px; height: 17px;">
           <asp:Label ID="lbLoaiPhieu" runat="server" Text=""></asp:Label></p>
    <p style="text-align:left;">Tiêu đề 题目:
              
                    <asp:Label ID="lblTieuDe" runat="server" ForeColor="Blue"></asp:Label><br />
                    <asp:TextBox ID="txtTieuDe" runat="server" Width="1084px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="groupHoanTat" ControlToValidate="txtTieuDe" Text="(*)" ForeColor="Red" ErrorMessage=""></asp:RequiredFieldValidator>
   </p>
       <table style="float:left;width:1100px; border: 1px solid black;border-collapse: collapse;" >
           <tr style="width:800px;border: 1px solid black;border-collapse: collapse;">
               <td  class="auto-style1" style="border: 1px solid black;border-collapse: collapse;">
                   Đơn vị đề nghị:<br />
                      提议单位 :
                    <asp:Label ID="lbldonvidenghi" runat="server" ForeColor="#9966FF"></asp:Label>
               </td>
              <td class="auto-style1" style="border: 1px solid black;border-collapse: collapse;" >
                  <asp:Label ID="lblNgaytao" runat="server" Text=""></asp:Label></td>
           </tr>
           <tr  style="border: 1px solid black;border-collapse: collapse;">
               <td   style="text-align:left;border: 1px solid black;border-collapse: collapse; ">
                   Mục đích sử dụng: 
                   
                   <asp:Label ID="lblMucDich" runat="server" ForeColor="#0066FF"></asp:Label>
                 
              </td>
               <td style="text-align:left;border: 1px solid black;border-collapse: collapse;" >
                  Translate <br />
                   <asp:TextBox ID="txtDichMucDich" runat="server" TextMode="MultiLine" Width="573px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"  ErrorMessage="" Text="(*)" ForeColor="Red" ControlToValidate="txtDichMucDich" ValidationGroup="groupHoanTat"></asp:RequiredFieldValidator>
               </td>
           </tr>

       </table>
    <div style="width:1101px; text-align:left">
      <div style="width:1100px;  text-align:left">
         <table style="float:left; width: 1100px;text-align:left" id="tablePMH" runat="server">
               <tr >
                 
                   <td class="auto-style1">
                       TÊN HÀNG 品名
                   </td>
                   
                    <td class="auto-style1">
                       GHI CHÚ<br />
                        備註
                   </td>
                   <td class="auto-style1"></td>
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
                   <td  class="button-wrap">
                       <asp:Button ID="Button1" runat="server" Text="Save" ValidationGroup ="groupthemmoi" OnClick="Button1_Click1" Height="43px" Width="63px" CssClass=" button save" /></td>
               </tr>
               <tr>
                   <td class="auto-style5">
                       
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="" Text="(*)" ControlToValidate="txtAutoComplete" ForeColor="Red" ValidationGroup="groupthemmoi"></asp:RequiredFieldValidator>
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
       <asp:GridView ID="GridView1" runat="server" Width="1100px" AutoGenerateColumns="False" OnRowEditing="GridView1_RowEditing" style="margin-right: 0px">
               <Columns>
                   <asp:TemplateField HeaderText="Edit ">
                       <ItemTemplate>
                        <asp:LinkButton ID="btnEdit" Text="Edit" runat="server" CommandName="Edit" />
                        
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

                   <asp:TemplateField HeaderText=" Tên Hàng">
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

                   <asp:TemplateField  HeaderText="Quy Cách">
                       <ItemTemplate>
                           <asp:Label ID="lblDWBH" runat="server" Text='<%#Eval("dwbh") %>'></asp:Label>
                       </ItemTemplate>
                       <ItemStyle Width="50px" />
                   </asp:TemplateField>

                   <asp:TemplateField HeaderText=" Số Lượng">
                       <ItemTemplate>
                           <asp:Label ID="lblQty" runat="server" Text='<%#Eval("Qty","{0:0,0}") %>'></asp:Label>
                       </ItemTemplate>
                       <ItemStyle Width="50px" />
                   </asp:TemplateField>

                   <asp:TemplateField HeaderText="Ghi Chú">
                       <ItemTemplate>
                           <asp:Label ID="lblCLMemo" runat="server" Text='<%#Eval("CLmemo") %>'></asp:Label>
                       </ItemTemplate>
                       <ItemStyle Width="340px" />
                   </asp:TemplateField>
                   
               </Columns>
           </asp:GridView>
        </div>
    <br />
    <p class="button-wrap" style="text-align:center; width:1000px;">
        <asp:Button ID="btncomplete" runat="server" BackColor="#F0CCFF" ForeColor="Blue" Text="Hoàn tất/完整" ValidationGroup="groupHoanTat" CssClass="button Complete" OnClick="btncomplete_Click" />  &nbsp; &nbsp;
      
        <asp:Button ID="btnCancel" runat="server" CssClass="button Cancel" BackColor="#F0CCFF" ForeColor="Blue" Text="Cancel" OnClick="btnCancel_Click" />
    </p>
</asp:Content>
