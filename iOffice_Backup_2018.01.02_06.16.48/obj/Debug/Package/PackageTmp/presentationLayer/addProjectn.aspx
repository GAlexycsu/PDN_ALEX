<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="addProjectn.aspx.cs" Inherits="iOffice.presentationLayer.addProjectn" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Style/XPForm.css" rel="stylesheet" />
    <link href="../Content/Site.css" rel="stylesheet" />
    <link href="../Style/jquery.datepick.css" rel="stylesheet" />
    <script src="../Scripts/jquery-1.4.1.js"></script>
    <script src="../Scripts/jquery.datepick.js"></script>
   
    <script type="text/javascript">
        $(function () {
            $('#txtFromDate').datepick({ dateFormat: 'yyyy/MM/dd' });
            $('#txtToDate').datepick({ dateFormat: 'yyyy/MM/dd' });
            $("#content").animate({
                marginTop: "80px"
            }, 600);
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
              <telerik:RadStyleSheetManager ID="RadStyleSheetManager1" runat="server">
</telerik:RadStyleSheetManager>
<telerik:RadScriptManager ID="RadScriptManager1" runat="server">
   
</telerik:RadScriptManager>
        <br />
        <br />
    <div>
        <table>
           <tr>
             <td>
               System Name
             </td>
             <td>
                 <asp:DropDownList ID="DropDownSystem" runat="server" OnSelectedIndexChanged="DropDownSystem_SelectedIndexChanged">
                 </asp:DropDownList>
             </td>
           </tr>
           <tr>
                <td>
                  Sub ID
                </td>
                <td>
                    <asp:TextBox ID="txtjsubid" runat="server"  ForeColor="Fuchsia" ReadOnly="True"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtjsubid" Text="(*)" ForeColor="Red" ValidationGroup="groupThem" ErrorMessage=""></asp:RequiredFieldValidator>
                </td>
                <td>
                  Sub System
                </td>
                <td>
                    <asp:TextBox ID="txtjsubname" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtjsubname" ValidationGroup="groupThem" Text="*" ForeColor="Red" ErrorMessage="Not Null"></asp:RequiredFieldValidator>
                </td>
                <td>
                  Sub System VN
                </td>
                <td>
                    <asp:TextBox ID="txtjsubnamevn" runat="server"></asp:TextBox>
                </td>
              
           </tr>
           <tr>
                <td>
                  Note
                </td>
                <td>
                    <asp:TextBox ID="txtjsubmemo" runat="server"></asp:TextBox>
                </td>
               <td>
                   Note VN
               </td>
               <td>
                   <asp:TextBox ID="txtjsubmemovn" runat="server"></asp:TextBox>
               </td>
           </tr>
           <tr>
              <td class="style1">
                 Leader ID
              </td>
              <td class="style1">
                  <asp:TextBox ID="txtsLeaderid" runat="server" BackColor="#CCFFFF" ReadOnly="True"></asp:TextBox>
              </td>
              <td class="style1">
                  Leader Name
              </td>
               <td class="style1">
                   <asp:TextBox ID="txtFuleName" runat="server" BackColor="#CCFFFF" ReadOnly="True"></asp:TextBox>
               </td>
           </tr>
           <tr>
              <td>
                 Begin Date
              </td>
              <td>
                  <asp:TextBox ID="txtFromDate" runat="server"></asp:TextBox>
              </td>
              <td>
                 End Date
              </td>
              <td>
                  <asp:TextBox ID="txtToDate" runat="server"></asp:TextBox>
              </td>
           </tr>
           <tr>
              <td>
                 Spercent
              </td>
              <td>
                  <telerik:RadNumericTextBox ID="txtPhanTram" runat="server" Type="Percent" MaxLength="3" MaxValue="100" ShowSpinButtons="true" BackColor="peachpuff" ForeColor="Blue">
                           <NumberFormat AllowRounding="True" KeepNotRoundedValue="False" DecimalDigits="0"></NumberFormat>
                    </telerik:RadNumericTextBox>
              </td>
              <td>
                  PDNO
              </td>
              <td>
                  <asp:TextBox ID="txtPDNO" runat="server"></asp:TextBox>
              </td>
           </tr>
             <tr>
                 <td>Attact File</td>
                 <td>
                     <asp:FileUpload ID="FileUpload1" runat="server" /></td>
                 <td class="button-wrap">
                     <asp:Button ID="btnUpload" runat="server" CssClass="button Up" Text="UpLoad" OnClick="btnUpload_Click" Width="117px" /></td>
             </tr>
               <tr>
                 <td>EndMark <asp:CheckBox ID="checkEndMark" runat="server" /></td>  
             </tr>
        </table> 
        <br />
        <div >
           <div class="button-wrap" style="text-align:center;width:400px">
               <asp:Button ID="btnSave" runat="server"  Text="Save" CssClass="button save" ValidationGroup="groupThem" BackColor="#F0CCFF"  ForeColor="Blue" onclick="btnSave_Click"  Width="72px" />
               &nbsp;&nbsp;
               <asp:Button ID="btnCancel" runat="server"  CssClass="button Cancel" BackColor="#F0CCFF"  ForeColor="Blue" Text="Back" 
                   onclick="btnCancel_Click"  Width="108px" />
               
           </div>

        </div>
          <p style="margin-left:50px;width:600px">
            <asp:Label ID="lblThongBao" runat="server" Text=""></asp:Label>
        </p>
           <div id="divAttact" runat="server" style="margin-left:100px;width:600px">
               <p style="margin-left:50px">Attact File</p>
            <div id="divTemp" runat="server">
                <asp:GridView ID="GridView1" runat="server" Width="600px"  AutoGenerateColumns="False" BackColor="White" BorderColor="#CC9966" BorderWidth="1px" CellPadding="4" BorderStyle="None" OnRowDeleting="GridView1_RowDeleting">
               <Columns>
                    <asp:TemplateField HeaderText="ID" Visible="false">
                       <ItemTemplate>
                           <asp:Label ID="lblID" runat="server" Text='<%#Eval("ID") %>'></asp:Label>
                       </ItemTemplate>
                     
                   </asp:TemplateField>
                   <asp:TemplateField HeaderText="File Name">
                       <ItemTemplate>
                           <asp:Label ID="lblFileName" runat="server" Text='<%#Eval("FileName") %>'></asp:Label>
                       </ItemTemplate>
                       <ItemStyle Width="80%" />
                   </asp:TemplateField>
                   <asp:TemplateField HeaderText="Delete">
                       <ItemTemplate>
                           <asp:LinkButton ID="linkDelete" runat="server" CommandName="Delete" OnClientClick="return confirm('Are you sure?')"><img src="../Content/Icon/delete.png"  /> Delete</asp:LinkButton>
                       </ItemTemplate>
                       <ItemStyle HorizontalAlign="Center" />
                   </asp:TemplateField>
               </Columns>
               <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
               <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
               <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
               <RowStyle BackColor="White" ForeColor="#330099" />
               <SelectedRowStyle BackColor="#FFCC66" ForeColor="#663399" Font-Bold="True" />
               <SortedAscendingCellStyle BackColor="#FEFCEB" />
               <SortedAscendingHeaderStyle BackColor="#AF0101" />
               <SortedDescendingCellStyle BackColor="#F6F0C0" />
               <SortedDescendingHeaderStyle BackColor="#7E0000" />
           </asp:GridView>
           </div>
           <div id="divAtt" runat="server">
               <asp:GridView ID="GridView2" Width="600px" runat="server" AutoGenerateColumns="False" OnRowDeleting="GridView2_RowDeleting" DataKeyNames="FilePath" OnSelectedIndexChanged="GridView2_SelectedIndexChanged">
                 <Columns>

                   <asp:TemplateField Visible="false">
                       <ItemTemplate>
                           <asp:Label ID="lblID11" runat="server" Text='<%#Eval("ID") %>'></asp:Label>
                       </ItemTemplate>
                   </asp:TemplateField>
                   <asp:TemplateField HeaderText="File Name">
                       <ItemTemplate>
                           <asp:Label ID="lblFileName" runat="server" Text='<%#Eval("FileName") %>'></asp:Label>
                       </ItemTemplate>
                       <ItemStyle Width="60%" />

 
                   </asp:TemplateField>
                     <asp:TemplateField HeaderText="File Path" Visible="false">
                       <ItemTemplate>
                           <asp:Label ID="lblFilePath" runat="server" Text='<%#Eval("FilePath") %>'></asp:Label>
                       </ItemTemplate>
                      

 
                   </asp:TemplateField>
                     <asp:TemplateField>
                         <ItemTemplate>
                           
                           <asp:LinkButton ID="linkDownLoad" runat="server" OnClick="linkDownLoad_Click"><img src="../Content/Icon/download.png"  /> Download</asp:LinkButton>
                       </ItemTemplate>
                       
                     </asp:TemplateField>
                      <asp:TemplateField HeaderText="Delete">
                       <ItemTemplate>
                           <asp:LinkButton ID="linkDelete1" runat="server" CommandName="Select"   OnClientClick="return confirm('Are you sure?')"><img src="../Content/Icon/delete.png"  /> Delete</asp:LinkButton>
                       </ItemTemplate>
                      
                       <ItemStyle HorizontalAlign="Center" />
                   </asp:TemplateField>
                  
                  
               </Columns>
               </asp:GridView>
           </div>
       </div>
    </div>
    
    </form>
</body>
</html>
