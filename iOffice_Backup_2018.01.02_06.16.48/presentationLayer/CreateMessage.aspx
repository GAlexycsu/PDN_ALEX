<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreateMessage.aspx.cs" Inherits="iOffice.presentationLayer.CreateMessage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Content/Site.css" rel="stylesheet" />
    <link href="../Style/XPForm.css" rel="stylesheet" />
    <link href="../Style/jquery-ui-1.8.19.custom.css" rel="stylesheet" />
    <link href="../Style/jquery-ui.css" rel="stylesheet" />
    <script src="../Scripts/jquery-1.8.3.js"></script>
    <script src="../Scripts/jquery-ui.js"></script>
    <script src="../Scripts/jquery-1.7.2.min.js"></script>
    <script src="../Scripts/jquery-ui-1.8.19.custom.min.js"></script>
    <script src="../Scripts/formatdate1.js"></script>
    <script src="../Scripts/getGroup.js"></script>
  
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table>
            <tr>
                <td>
                    Group Name
                </td>
                <td>
                    <asp:DropDownList ID="DropDownGroupName" runat="server"></asp:DropDownList>
                    &nbsp;
                    <%--<asp:LinkButton ID="LinkButton1" runat="server" OnClientClick="return GetSelectedRow()"><img src="../Images/View.png" /> Details Group</asp:LinkButton>--%>
                  
                    &nbsp;
                    <asp:LinkButton ID="linkAddgroup" runat="server" OnClick="linkAddgroup_Click"><img src="../Images/Icon/add.gif" /> Add Group</asp:LinkButton>
                </td>
            </tr>
           <%-- <tr>
                <td>
                    ID <span style="color:red">(*)</span>
                </td>
                <td>
                    <asp:TextBox ID="txtID" runat="server" MaxLength="2"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtID" ValidationGroup="groupThem" ErrorMessage=""></asp:RequiredFieldValidator>
                </td>
            </tr>--%>
            <tr>
                <td>Title<span style="color:red">(*)</span></td>
                <td>
                    <asp:TextBox ID="txtTitle" runat="server" ClientIDMode="Static" TextMode="MultiLine" Height="61px" Width="705px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtTitle" ValidationGroup="groupThem" ErrorMessage=""></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    Message<span style="color:red">(*)</span>
                </td>
                <td>
                    <asp:TextBox ID="txtMessage" runat="server" ClientIDMode="Static" TextMode="MultiLine" Height="110px" Width="709px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtMessage" ValidationGroup="groupThem" ErrorMessage=""></asp:RequiredFieldValidator>
                </td>
            </tr>
        </table>
        <table>
            <tr>
                <td>
                    Begin Share
                </td>
                <td>
                    <asp:TextBox ID="txtFromDate" runat="server" ClientIDMode="Static"></asp:TextBox>
                </td>
                <td>
                    End
                </td>
                <td>
                    <asp:TextBox ID="txtToDate" runat="server" ClientIDMode="Static"></asp:TextBox>
                </td>
            </tr>
        </table>
        <div id="divUpload1" class="button-wrap" runat="server" style="text-align:center; float:none">
        <asp:FileUpload ID="fileUpload1" runat="server" /><br />
         <asp:Button ID="btnUpload" runat="server" CssClass="button Up" Text="Upload" onclick="btnUpload_Click" Width="110px" />
    </div>
    <div id="divUpload2" runat="server" style="text-align:center;margin-left:150px; margin-top: 18px;">
    
        <p style="width:700px; text-align:center;" > Attact File </p>
        
        <asp:GridView ID="GridView2" Width="600px" runat="server" AutoGenerateColumns="False"  DataKeyNames="FilePath" OnSelectedIndexChanged="GridView2_SelectedIndexChanged">
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
                           
                           <asp:LinkButton ID="linkDownLoad" runat="server" OnClick="lnkDownload_Click"><img src="../Content/Icon/download.png"  /> Download</asp:LinkButton>
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
        <p>
            <asp:LinkButton ID="LinkThem" runat="server" OnClick="LinkThem_Click"><img src="../Images/Icon/save.png" /> Save</asp:LinkButton>
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:LinkButton ID="linkBack" runat="server" OnClick="linkBack_Click"><img src="../Images/Icon/back.png" />Back</asp:LinkButton>
        </p>
    </div>
       <div style="display:none">
             <div id="divDanhSachProduct" style="overflow:auto; max-height:500px" >
               
           </div>
    </div>
    </form>
</body>
</html>
