<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreateUser.aspx.cs" Inherits="iOffice.presentationLayer.CreateUser" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Style/StyleSheet2.css" rel="stylesheet" />
    <link href="../Style/GridviewScroll.css" rel="stylesheet" />
    <link href="../Style/jquery-ui.css" rel="stylesheet" />
<%--    <script src="../Scripts/jquery-ui.js"></script>
    <script src="../Scripts/jquery.min.js"></script>
    <script src="../Scripts/jquery-ui.min.js"></script>
    <link href="../Style/css/bootstrap.css" rel="stylesheet" />
    <script src="../Scripts/bootstrap.min.js"></script>
    <link href="../Style/css/bootstrap-multiselect.css" rel="stylesheet" />
    <script src="../Scripts/bootstrap-multiselect.js"></script>
    <script src="../Scripts/gridviewScroll.min.js"></script>--%>
<%--        <script type="text/javascript">
            //             $(function () {
            //                 $('[id*=ListBox1]').multiselex({
            //                     includeSelectAllOption: true
            //                 });
            //             });
            $(function () {
                $('[id*=ListBox1]').multiselex({
                    includeSelectAllOption: true
                })
            })
    </script>
        <script type="text/javascript">
            $(document).ready(function () {
                gridviewScroll();
            });

            function gridviewScroll() {
                $('#<%=GridView1.ClientID%>').gridviewScroll({
                    width: 600,
                    height: 400
                });
            }
</script>--%>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        
       <table>
         <tr>
            <td>
              User ID
            </td>
            <td>
                <asp:TextBox ID="txtUserID" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtUserID" ValidationGroup="groupS" Text="*" ForeColor="Red" ErrorMessage=""></asp:RequiredFieldValidator>
            </td>
            <td> 
              User Name
            </td>
            <td>
                <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtUserName"  ValidationGroup="groupS" Text="*" ForeColor="Red"  ErrorMessage=""></asp:RequiredFieldValidator>
            </td>
         </tr>
         <tr>
           <td>
              Email
           </td>
           <td>
               <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
               <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtEmail"  ValidationGroup="groupS" Text="*" ForeColor="Red" ErrorMessage=""></asp:RequiredFieldValidator>
           </td>
           <td>
             Password
           </td>
           <td>
               <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
               <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"  ControlToValidate="txtPassword"  ValidationGroup="groupS" Text="*" ForeColor="Red"  ErrorMessage=""></asp:RequiredFieldValidator>
           </td>
         </tr>
         <tr>
            <td>
                Login 
            </td>
            <td colspan="2">
               <asp:ListBox ID="ListBox1" runat="server"  SelectionMode="Multiple" 
                             Height="64px" Width="200px">
                             </asp:ListBox>
            </td>
         </tr>
       </table>
       <p style="width:500px;margin-left:50px"> 
           <asp:Button ID="btnSave" runat="server" Text="Save" ValidationGroup="groupS" onclick="btnSave_Click" />
           &nbsp;&nbsp;&nbsp;
           <asp:Button ID="btnBack" runat="server" Text="Back " onclick="btnBack_Click" />
       </p>
   <p style="width:700px;margin-left:50px " >
       <asp:Label ID="lblThongBao" runat="server" ForeColor="Blue"></asp:Label>
   </p>
   <table>
      <tr>
          <td>  User ID:&nbsp;&nbsp; 
              <asp:TextBox ID="txtTimKiem" runat="server" 
                  ontextchanged="txtTimKiem_TextChanged" AutoPostBack="True"></asp:TextBox>
          </td>
          <td>
              <asp:Button ID="btnSearch" runat="server" Text="Search" 
                  onclick="btnSearch_Click" />
          </td>
      </tr>
   </table>
   <div>
       <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
           Width="565px" onrowdeleting="GridView1_RowDeleting">
          <Columns>
             <asp:TemplateField HeaderText="UserID" >
                <ItemTemplate >
                    <asp:Label ID="lblUserID" runat="server" Text='<%#Eval("UserID") %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle HorizontalAlign=Center Width=20% />
             </asp:TemplateField>
              <asp:TemplateField HeaderText="User Name" >
                <ItemTemplate >
                    <asp:Label ID="lblUserName" runat="server" Text='<%#Eval("UserName") %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle HorizontalAlign=Center Width=30% />
             </asp:TemplateField>
             <asp:TemplateField Visible="false">
               <ItemTemplate>
                   <asp:Label ID="lblSystemID" runat="server" Text='<%#Eval("SystemID") %>'></asp:Label>
               </ItemTemplate>
             </asp:TemplateField>
             <asp:TemplateField HeaderText="System Name">
                <ItemTemplate>
                    <asp:Label ID="lblSystemName" runat="server" Text='<%#Eval("Name") %>'></asp:Label>
                </ItemTemplate>
             </asp:TemplateField>
              <asp:TemplateField HeaderText="Delete">
                  
                            <ItemTemplate> 
                                <asp:Button ID="Button1" runat="server" CommandName="Delete" Text="Delete"  
                                    onclientclick="return confirm('Are you sure you want to delete this event?');" /> 
                            </ItemTemplate> 
                            <ItemStyle HorizontalAlign=Center />
                </asp:TemplateField>
          </Columns>
           <HeaderStyle BackColor="Tomato" CssClass="FixedHeader"></HeaderStyle>
       </asp:GridView>
   </div>
    </div>
    </form>
</body>
</html>
