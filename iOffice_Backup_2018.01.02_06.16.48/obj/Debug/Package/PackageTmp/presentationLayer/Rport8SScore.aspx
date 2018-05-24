<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Rport8SScore.aspx.cs" Inherits="iOffice.presentationLayer.Rport8SScore" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
       <link href="../Style/XPForm.css" rel="stylesheet" />
    <link href="../Content/Site.css" rel="stylesheet" />
    <link href="../Style/jquery-ui-1.8.19.custom.css" rel="stylesheet" />
    <script src="../Scripts/jquery-1.7.2.min.js"></script>
    <script src="../Scripts/jquery-ui-1.8.19.custom.min.js"></script>
    <script src="../Scripts/formatdate1.js"></script>
</head>
<body>
    <form id="form1" runat="server">
      <div>
            <table>
          <tr>
              <td>
                  Year
              </td>
              <td>
                  <asp:DropDownList ID="dropDownYear" runat="server"></asp:DropDownList>
              </td>
              <td>
                  Month
              </td>
              <td>
                  <asp:DropDownList ID="dropDownMonth" runat="server" AutoPostBack="True" OnSelectedIndexChanged="dropDownMonth_SelectedIndexChanged"></asp:DropDownList>
              </td>
              <td>
                  Week
              </td>
              <td>
                  <asp:DropDownList ID="DropDownWeek" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownWeek_SelectedIndexChanged"></asp:DropDownList>
              </td>
          </tr>

      </table>
      <table>
          <tr>
              <td>DDClass  </td>
              <td> 
                  <asp:DropDownList ID="DropDownDClass" runat="server">
                   <asp:ListItem>B</asp:ListItem>
                   <asp:ListItem>C</asp:ListItem>
                   <asp:ListItem>D</asp:ListItem>
                   <asp:ListItem>E</asp:ListItem>
                </asp:DropDownList></td>
              <td> <asp:Button ID="btnExport" runat="server" Text="Export Excel" OnClick="btnExport_Click" /></td>
          </tr>
      </table>

         
    </div>
    <div style="display:none">

          <asp:TextBox ID="txtFromDate" runat="server" Height="22px"></asp:TextBox>  
        <asp:TextBox ID="txtToDate" runat="server" Height="22px"></asp:TextBox>
    </div>
    </form>
</body>
</html>
