<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditProjectShare.aspx.cs" Inherits="iOffice.presentationLayer.EditProjectShare" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Style/XPForm.css" rel="stylesheet" />
    <link href="../Content/Site.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
           <table>
            <tr>
                <td>
                  System Name 
                </td>
                <td>
                    <asp:DropDownList ID="DropDownSystem" runat="server" AutoPostBack="True" Enabled="False"></asp:DropDownList>
                </td>
                <td>
                    Sub System 
                </td>
                <td>
                    <asp:DropDownList ID="DropDownSubSystem" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownSubSystem_SelectedIndexChanged" Enabled="False"></asp:DropDownList>
                </td>
                <td>
                    Job Name
                </td>
                <td>
                    <asp:DropDownList ID="DropDownJob" runat="server" OnSelectedIndexChanged="DropDownJob_SelectedIndexChanged"></asp:DropDownList>

                </td>
            </tr>

        </table>
        <table>
            <tr>
              
                <td>
                    Subject</td>
                <td colspan="3">
                    <asp:TextBox ID="txtSubject" runat="server" Width="430px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Text="(*)" ForeColor="Red" ControlToValidate="txtSubject" ValidationGroup="groupthem" ErrorMessage=""></asp:RequiredFieldValidator>
                </td>
               
            </tr>
                 <tr>
                 <td>
                     User Name
                 </td>
                 <td>
                     <asp:TextBox ID="txtUserName" runat="server" placeholder="Input" OnTextChanged="txtUserName_TextChanged" AutoPostBack="True"></asp:TextBox>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtUserName" Text="(*)" ForeColor="Red" ValidationGroup="groupthem" ErrorMessage=""></asp:RequiredFieldValidator>
                 </td>
                 <td>
                     <asp:TextBox ID="txtFullName" runat="server"></asp:TextBox></td>
             </tr>
        </table>
        <div class="button-wrap" style="text-align:left; margin-left:30px">
            <asp:Button ID="btnSave" runat="server" ValidationGroup="groupthem" CssClass="button save" Text="Save" OnClick="btnSave_Click" Height="24px" Width="128px" /></div>
        <p style="display:none" >
            <asp:TextBox ID="txtUserTemp" runat="server"></asp:TextBox> <asp:TextBox ID="txtJobTemp" runat="server"></asp:TextBox></p>
    </div>
    </form>
</body>
</html>
