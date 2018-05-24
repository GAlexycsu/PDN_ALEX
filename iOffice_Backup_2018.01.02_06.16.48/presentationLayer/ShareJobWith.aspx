<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShareJobWith.aspx.cs" Inherits="iOffice.presentationLayer.ShareJobWith" %>

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
                <td class="auto-style1">
                    SystemName:&nbsp; 
                </td>
                <td class="auto-style1">
                    <asp:Label ID="lblSystemName" runat="server" ForeColor="Red"></asp:Label>
                </td>
               
            </tr>
            <tr>
                <td>
                    Sub System :</td>
                <td>
                    <asp:Label ID="lblSubSystem" runat="server" ForeColor="#CC00FF"></asp:Label>
                </td>
            </tr>
            <tr>
                 
                <td>
                    Job Name :</td>
                <td>

                    <asp:Label ID="lblJobName" runat="server" Text=""></asp:Label>
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
                    <asp:ListBox ID="ListQuery" runat="server" Width="170px" DataTextField="USERNAME" DataValueField="USERID" SelectionMode="Multiple"></asp:ListBox>
                </td>
                <td>
                    <asp:Button ID="btnThemList" ForeColor="Blue" runat="server" Text=">>" OnClick="btnThemList_Click" /> <br />
                    <asp:Button ID="btnDeleteList" ForeColor="Red" runat="server" Text="<<" OnClick="btnDeleteList_Click" />
                </td>
                <td>
                    <asp:ListBox ID="listXuLy" runat="server" Width="170px" DataTextField="USERNAME" DataValueField="USERID" SelectionMode="Multiple"></asp:ListBox>
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
    <div>
        <asp:GridView ID="GridView1" runat="server" Width="1000px" AutoGenerateColumns="False" BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Horizontal" OnRowDeleting="GridView1_RowDeleting">
            <AlternatingRowStyle BackColor="#F7F7F7" />
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="linkDelete" runat="server" CommandName="Delete" OnClientClick="return confirm('Are you sure?')"><img src="../Content/Icon/delete.png" /> Delete</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="" Visible="false">
                    <ItemTemplate>
                        <asp:Label ID="lbljsysid" runat="server" Text='<%#Eval("jsysid") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="" Visible="false">
                    <ItemTemplate>
                        <asp:Label ID="lbljsubid" runat="server" Text='<%#Eval("jsubid") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="" Visible="false">
                    <ItemTemplate>
                        <asp:Label ID="lbljobid" runat="server" Text='<%#Eval("jobid") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText=""  Visible="false">
                    <ItemTemplate>
                        <asp:Label ID="lblJuserid" runat="server" Text='<%#Eval("Juserid") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="System Name">
                    <ItemTemplate>
                        <asp:Label ID="lblsysname" runat="server" Text='<%#Eval("sysname") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Sub System ">
                    <ItemTemplate>
                        <asp:Label ID="lbljsubname" runat="server" Text='<%#Eval("jsubname") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Job Name">
                    <ItemTemplate>
                        <asp:Label ID="lbljobname" runat="server" Text='<%#Eval("jobname") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="User Share">
                    <ItemTemplate>
                        <asp:Label ID="lblUSERNAME" runat="server" Text='<%#Eval("USERNAME") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="Note">
                    <ItemTemplate>
                        <asp:Label ID="lbljuamemo" runat="server" Text='<%#Eval("juamemo") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
            <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
            <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
            <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
            <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
            <SortedAscendingCellStyle BackColor="#F4F4FD" />
            <SortedAscendingHeaderStyle BackColor="#5A4C9D" />
            <SortedDescendingCellStyle BackColor="#D8D8F0" />
            <SortedDescendingHeaderStyle BackColor="#3E3277" />
        </asp:GridView>

       
    </div>
         </ContentTemplate>
        </asp:UpdatePanel>
        <div style="display:none">
            <asp:Label ID="lblSystemID" runat="server" Text=""></asp:Label>
            <asp:Label ID="lblSubSystemID" runat="server" Text=""></asp:Label>
            <asp:Label ID="lblJobID" runat="server" Text=""></asp:Label>
        </div>
    </form>
</body>
</html>
