<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="addProjects.aspx.cs" Inherits="iOffice.presentationLayer.addProjects" %>
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
            $('#txtedates').datepick({ dateFormat: 'yyyy/MM/dd' });
            $('#txtedatee').datepick({ dateFormat: 'yyyy/MM/dd' });
            $("#content").animate({
                marginTop: "80px"
            }, 600);
        });
    </script>
    <style type="text/css">
        .auto-style1 {
            height: 48px;
        }
    </style>
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
              <td class="auto-style1">
                  Sub System</td>
              <td class="auto-style1">
                  <asp:DropDownList ID="DropDownSubSystem" runat="server" AutoPostBack="True" 
                      onselectedindexchanged="DropDownSubSystem_SelectedIndexChanged">
                  </asp:DropDownList>
              </td>
               <td class="auto-style1">System  Name</td>
               <td class="auto-style1">
                   <asp:TextBox ID="txtSystemname" runat="server" ReadOnly="True"></asp:TextBox> </td>
               <td style="display:none;" class="auto-style1">
                   <asp:TextBox ID="txtSystemID" runat="server"></asp:TextBox></td>
           </tr>
           <tr>
                <td> 
               Job ID
              </td>
             <td>
                 <asp:TextBox ID="txtJobID" runat="server"  ReadOnly="True" ForeColor="Fuchsia"></asp:TextBox>
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"  ControlToValidate="txtJobID" ForeColor="red" Text="*" ValidationGroup="groupThem" ErrorMessage="Not Null"></asp:RequiredFieldValidator>
             </td>
              <td>
                jobname
              </td>
              <td>
                  <asp:TextBox ID="txtjobname" runat="server"></asp:TextBox>
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtjobname" ForeColor="red" Text="*" ValidationGroup="groupThem" ErrorMessage="Not Null"></asp:RequiredFieldValidator>
              </td>
              
           </tr>
           <tr>
                 <td>
                Job Name VN
              </td>
               <td>
                   <asp:TextBox ID="txtjobnamevn" runat="server"></asp:TextBox>
               </td>
               <td>
                Note
               </td>
               <td>
                   <asp:TextBox ID="txtjobmemo" runat="server"></asp:TextBox>
               </td>
               <td>
                 Note VN
               </td>
               <td>
                   <asp:TextBox ID="txtjobmemovn" runat="server"></asp:TextBox>
               </td>
           </tr>
            <tr>
              <td>
                Begin Date
              </td>
              <td>
                  <asp:TextBox ID="txtedates" runat="server"></asp:TextBox>
              </td>
              <td>
                End Date
              </td>
              <td>
                  <asp:TextBox ID="txtedatee" runat="server"></asp:TextBox>
              </td>
           </tr>
           <tr>
              <td>
                Leader ID
              </td>
              <td>
                  <asp:TextBox ID="txtJleaderid" runat="server" BackColor="#CCFFFF" ReadOnly="True"></asp:TextBox>
              </td>
              <td>
                 Leader Name
              </td>
              <td>
                  <asp:TextBox ID="txtFullname" runat="server" BackColor="#CCFFFF" ReadOnly="True"></asp:TextBox>
              </td>
           </tr>
           <tr>
              <td>
                 Spercent
              </td>
              <td>
                  <telerik:RadNumericTextBox ID="txtPhanTram" runat="server" Type="Percent" ShowSpinButtons="true" MaxLength="3" MaxValue="100" BackColor="peachpuff" ForeColor="Blue">
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
                     <asp:Button ID="btnUpload" runat="server" CssClass="button Up" Text="UpLoad" OnClick="btnUpload_Click" Width="117px" /> </td>
             </tr>
             <tr>
                 <td>EndMark <asp:CheckBox ID="checkEndMark" runat="server" /></td>  
             </tr>
        </table>
        <br />
        <div  class="button-wrap" style="margin-left:100px">
          
                     <asp:Button ID="btnSave" runat="server" Text="Save" BackColor="#F0CCFF"  ForeColor="Blue"  CssClass=" button save" ValidationGroup="groupThem" onclick="btnSave_Click" Width="73px" Height="24px" /> 
              
               <asp:Button ID="btnCancel" runat="server" BackColor="#F0CCFF"  ForeColor="Blue"  CssClass="button Cancel"  Text="Back" 
                   onclick="btnCancel_Click1" Height="24px" Width="104px" />
           
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
               <asp:GridView ID="GridView2" Width="600px" runat="server" AutoGenerateColumns="False" OnRowDeleting="GridView2_RowDeleting" DataKeyNames="FilePath" OnSelectedIndexChanged="GridView2_SelectedIndexChanged" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3">
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
                      <asp:TemplateField HeaderText="File Path">
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
                   <FooterStyle BackColor="White" ForeColor="#000066" />
                   <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                   <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                   <RowStyle ForeColor="#000066" />
                   <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                   <SortedAscendingCellStyle BackColor="#F1F1F1" />
                   <SortedAscendingHeaderStyle BackColor="#007DBB" />
                   <SortedDescendingCellStyle BackColor="#CAC9C9" />
                   <SortedDescendingHeaderStyle BackColor="#00547E" />
               </asp:GridView>
           </div>
       </div>
    </form>
</body>
</html>
