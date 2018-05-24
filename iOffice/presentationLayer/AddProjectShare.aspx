
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddProjectShare.aspx.cs" Inherits="iOffice.presentationLayer.AddProjectShare" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Content/Site.css" rel="stylesheet" />
    <link href="../Style/XPForm.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <br />
        <br />
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="panenInser" runat="server">
            <ContentTemplate>

       
    <div>
        <table>
            <tr>
                <td>
                  SystemName 
                </td>
                <td>
                    <asp:DropDownList ID="DropDownSystem" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownSystem_SelectedIndexChanged"></asp:DropDownList>
                </td>
                <td>
                    Sub System 
                </td>
                <td>
                    <asp:DropDownList ID="DropDownSubSystem" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownSubSystem_SelectedIndexChanged"></asp:DropDownList>
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
                    <asp:TextBox ID="txtSubject" runat="server"  Width="538px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Text="(*)" ForeColor="Red" ControlToValidate="txtSubject" ValidationGroup="groupThem" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>
                </td>
            </tr>
                 <tr>
                 <td>
                     User Name
                 </td>
                 <td class="auto-style1">
                     <asp:TextBox ID="txtUserName" runat="server" placeholder="Input" OnTextChanged="txtUserName_TextChanged" AutoPostBack="True"></asp:TextBox>
                 </td>
                 <td>Derpartment Name</td>
                 <td class="button-wrap">
                     <asp:DropDownList ID="DropDownDonVi" runat="server" OnSelectedIndexChanged="DropDownDonVi_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                     <asp:Button ID="btnQuery" runat="server" CssClass="button find" Text="Query" Width="78px" />
                 </td>
             </tr>
        </table>
        
    <div id="DivList" runat="server">
        <table>
            <tr>
                <td>
                    <asp:ListBox ID="ListQuery" runat="server" DataTextField="USERNAME" DataValueField="USERID" SelectionMode="Multiple"></asp:ListBox>
                </td>
                <td>
                    <asp:Button ID="btnThemList" ForeColor="Blue" runat="server" Text=">>" OnClick="btnThemList_Click" /> <br />
                    <asp:Button ID="btnDeleteList" ForeColor="Red" runat="server" Text="<<" OnClick="btnDeleteList_Click" />
                </td>
                <td>
                    <asp:ListBox ID="listXuLy" runat="server" DataTextField="USERNAME" DataValueField="USERID" SelectionMode="Multiple"></asp:ListBox>
                </td>
            </tr>
        </table>
        </div>
        <br />
        <div class="button-wrap">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnLuu" runat="server" ValidationGroup="groupThem" CssClass="button save" Text="Save And Continues" OnClick="btnLuu_Click" /> &nbsp;&nbsp;&nbsp;<asp:Button ID="btnBack" CssClass="button Cancel" runat="server" Text="Back" OnClick="btnBack_Click" Width="102px" />
        </div>
    </div>
         </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
