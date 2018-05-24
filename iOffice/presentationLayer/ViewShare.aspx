<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewShare.aspx.cs" Inherits="iOffice.presentationLayer.ViewShare"  EnableEventValidation="false"%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Content/Site.css" rel="stylesheet" />
   <link href="../Style/jquery.datepick.css" rel="stylesheet" />
    <script src="../Scripts/jquery-1.4.1.js"></script>
    <script src="../Scripts/jquery.datepick.js"></script>
    <script type="text/javascript">
        $(function () {
            $('#txtFromDate').datepick({ dateFormat: 'dd/MM/yyyy' });
            $('#txtToDate').datepick({ dateFormat: 'dd/MM/yyyy' });
            $("#content").animate({
                marginTop: "80px"
            }, 600);
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <br />
    <br />
     <table>
               <tr>
                 <td>
                     User Name
                 </td>
                
                 <td class="button-wrap">
                     <asp:DropDownList ID="DropDownUserName" runat="server" AutoPostBack="True"></asp:DropDownList>
                    <asp:Button ID="btnQuery" runat="server"  CssClass="button find" BackColor="#F0CCFF"   ForeColor="Blue" Text="Query" OnClick="btnQuery_Click" Width="75px" /> &nbsp;&nbsp;&nbsp;
                     <asp:Button ID="btnExport" runat="server"  CssClass="button export" BackColor="#F0CCFF"   ForeColor="Blue" Text="Export To Excel" OnClick="btnExport_Click" Width="121px" /> &nbsp;&nbsp;&nbsp;
                     <asp:Button ID="btnBack" runat="server"  CssClass="button Cancel" BackColor="#F0CCFF"   ForeColor="Blue"  Text="Back" OnClick="btnBack_Click" Width="101px" />
                 </td>
             </tr>
        </table>
    <table>
        <tr>
              <td>
                 From Date
              </td>
              <td>
                  <asp:TextBox ID="txtFromDate" runat="server" ClientIDMode="Static"></asp:TextBox>
              </td>
              <td>
                 To Date
              </td>
              <td>
                  <asp:TextBox ID="txtToDate" runat="server" ClientIDMode="Static"></asp:TextBox>
              </td>
           </tr>
    </table>
        <br />
        <br />

    <div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="3" OnRowDataBound="GridView1_RowDataBound" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellSpacing="2">
            <Columns>
                <asp:TemplateField  HeaderText="Company" Visible="false">
                    <ItemTemplate>
                        <asp:Label ID="lblGSBH" runat="server" Text='<%#Eval("GSBH") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                  <asp:TemplateField  HeaderText="" Visible="false" >
                    <ItemTemplate>
                        <asp:Label ID="lblJsysid" runat="server" Text='<%#Eval("Jsysid") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                 <asp:TemplateField  HeaderText="" Visible="false" >
                    <ItemTemplate>
                        <asp:Label ID="lblJsubid" runat="server" Text='<%#Eval("Jsubid") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                  <asp:TemplateField  HeaderText="" Visible="false" >
                    <ItemTemplate>
                        <asp:Label ID="lblJodid" runat="server" Text='<%#Eval("Jodid") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                  <asp:TemplateField  HeaderText="System Name" >
                    <ItemTemplate>
                        <asp:Label ID="lblSystemName" runat="server" Text='<%#Eval("SystemName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                  <asp:TemplateField  HeaderText="From Date" >
                    <ItemTemplate>
                        <asp:Label ID="lbledates0" runat="server" Text='<%#Eval("edates","{0:dd/MM/yyyy}") %>'></asp:Label>
                    </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                  <asp:TemplateField  HeaderText="To Date" >
                    <ItemTemplate>
                        <asp:Label ID="lbledatee0" runat="server" Text='<%#Eval("edatee","{0:dd/MM/yyyy}") %>'></asp:Label>
                    </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                  <asp:TemplateField  HeaderText="Spercent" >
                    <ItemTemplate>
                        <asp:Label ID="lblSpercent0" runat="server" Text='<%#Eval("Spercent","{0:0}") %>'></asp:Label>
                    </ItemTemplate>
                      <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                  <asp:TemplateField  HeaderText="Sub System Name" >
                    <ItemTemplate>
                        <asp:Label ID="lbljsubname" runat="server" Text='<%#Eval("jsubname") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                  <asp:TemplateField  HeaderText="From Date" >
                    <ItemTemplate>
                        <asp:Label ID="lbledates1" runat="server" Text='<%#Eval("edates","{0:dd/MM/yyyy}") %>'></asp:Label>
                    </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                  <asp:TemplateField  HeaderText="To Date" >
                    <ItemTemplate>
                        <asp:Label ID="lbledatee1" runat="server" Text='<%#Eval("edatee","{0:dd/MM/yyyy}") %>'></asp:Label>
                    </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                  <asp:TemplateField  HeaderText="Spercent" >
                    <ItemTemplate>
                        <asp:Label ID="lblSpercent1" runat="server" Text='<%#Eval("Spercent","{0:0}") %>'></asp:Label>
                    </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                  <asp:TemplateField  HeaderText="Job Name" >
                    <ItemTemplate>
                        <asp:Label ID="lbljobname" runat="server" Text='<%#Eval("jobname") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                  <asp:TemplateField  HeaderText="From Date" >
                    <ItemTemplate>
                        <asp:Label ID="lbledates2" runat="server" Text='<%#Eval("edates","{0:dd/MM/yyyy}") %>'></asp:Label>
                    </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                  <asp:TemplateField  HeaderText="To Date" >
                    <ItemTemplate>
                        <asp:Label ID="lbledatee2" runat="server" Text='<%#Eval("edatee","{0:dd/MM/yyyy}") %>'></asp:Label>
                    </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                  <asp:TemplateField  HeaderText="Percent" >
                    <ItemTemplate>
                        <asp:Label ID="lbljpercent2" runat="server" Text='<%#Eval("jpercent","{0:0}") %>'></asp:Label>
                    </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                  <asp:TemplateField  HeaderText="userid" Visible="false">
                    <ItemTemplate>
                        <asp:Label ID="lbluserid" runat="server" Text='<%#Eval("userid") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                  <asp:TemplateField  HeaderText="USERNAME" >
                    <ItemTemplate>
                        <asp:Label ID="lblUSERNAME" runat="server" Text='<%#Eval("USERNAME") %>'></asp:Label>
                    </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                 
            </Columns>
            <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
            <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
            <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
            <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
            <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#FFF1D4" />
            <SortedAscendingHeaderStyle BackColor="#B95C30" />
            <SortedDescendingCellStyle BackColor="#F1E5CE" />
            <SortedDescendingHeaderStyle BackColor="#93451F" />
        </asp:GridView>
    </div>
    </div>
    </form>
</body>
</html>
