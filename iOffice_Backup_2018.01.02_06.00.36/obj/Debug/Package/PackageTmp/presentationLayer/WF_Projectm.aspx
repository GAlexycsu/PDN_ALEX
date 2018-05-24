<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMater/MasterPage2.Master" AutoEventWireup="true" CodeBehind="WF_Projectm.aspx.cs" Inherits="iOffice.presentationLayer.WF_Projectm" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Content/FormatModal.css" rel="stylesheet" />
    <link href="../Content/Site.css" rel="stylesheet" />
    <link href="../Style/jquery-ui-1.8.19.custom.css" rel="stylesheet" />
    <link href="../Style/GridviewScroll.css" rel="stylesheet" />
     <script src="../../Scripts/jquery.min.js"></script>
    <script src="../../Scripts/jquery-ui.min.js"></script>
    <script src="../Scripts/jquery-ui-1.8.19.custom.min.js"></script>
    <script src="../Scripts/gridviewScroll.min.js"></script>
    <script src="../Scripts/JavaScriptFormatDate.js"></script>
  
    <script type="text/javascript">
        $(document).ready(function () {
            gridviewScroll();
        });

        function gridviewScroll() {
            $('#<%=GridView1.ClientID%>').gridviewScroll({
                  width: 1024,
                  height: 700
              });
          }
    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            gridviewScroll1();
        });

        function gridviewScroll1() {
            $('#<%=GridView2.ClientID%>').gridviewScroll({
            width: 1024,
            height: 700
        });
    }
    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            gridviewScroll2();
        });

        function gridviewScroll2() {
            $('#<%=GridView3.ClientID%>').gridviewScroll({
            width: 1024,
            height: 700
        });
    }
    </script>
    <script type="text/javascript">
        function hideshow(which) {

            if (!document.getElementById)
                return
            if (which.style.display == "block")
                which.style.display = "none"
            else
                which.style.display = "block"
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />
    <asp:UpdatePanel ID="uppen" runat="server">
        <ContentTemplate>


            <div style="overflow-y: auto; margin-left: 25px">
                <table>
                    <tr>
                        <td style="width: 71px;">GSBH
                         
                        </td>
                        <td>
                            <asp:DropDownList ID="DropDownGSBH" runat="server">
                                <asp:ListItem>LTY</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>System</td>
                        <td>
                            <asp:DropDownList ID="DropDownSystem" runat="server">
                            </asp:DropDownList>
                        </td>
                    </tr>
                </table>
                <table>

                    <tr>

                        <td>From Date
                        </td>
                        <td>
                            <%--<asp:TextBox ID="txtTuNgay" runat="server" ClientIDMode="Static" ></asp:TextBox>--%>
                            <telerik:RadDatePicker ID="RadDatePicker1" runat="server"></telerik:RadDatePicker>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Text="(*)" ForeColor="Red" ControlToValidate="RadDatePicker1" ValidationGroup="groupExport" ErrorMessage=""></asp:RequiredFieldValidator>
                        </td>

                        <td>~
           <%-- <asp:TextBox ID="txtDenNgay" runat="server" ClientIDMode="Static" ></asp:TextBox>--%>
                            <telerik:RadDatePicker ID="RadDatePicker2" runat="server"></telerik:RadDatePicker>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Text="(*)" ForeColor="Red" ControlToValidate="RadDatePicker2" ValidationGroup="groupExport" ErrorMessage=""></asp:RequiredFieldValidator>
                        </td>
                        <td class="button-wrap">
                            <asp:Button ID="btnExport" runat="server" CssClass="button export" ValidationGroup="groupExport" Text="Export Exel" OnClick="btnExport_Click" /></td>
                    </tr>
                    <tr>
                        <td> <asp:CheckBox ID="checkCancel" runat="server" Text="Cancel" />
                            <asp:CheckBox ID="checkHide" runat="server" Text="Hide" />
                        </td>

                        <td class="button-wrap">
                            <asp:Button ID="Button1" runat="server" CssClass="button find" BackColor="#F0CCFF" ForeColor="Blue" Text="Query" OnClick="Button1_Click" Width="68px" /></td>
                        

                    </tr>
                </table>
            </div>

            <br />
            <div id="divSystem" runat="server" style="margin-left: 25px">
            
                    <p >
                        <asp:Button ID="btnAddSystem" runat="server" CssClass="button add" BackColor="#F0CCFF" ForeColor="Blue"
                            Text="Add System" OnClick="btnAddSystem_Click1" Width="109px" />
                        &nbsp;&nbsp; 
                     <asp:Button ID="btnBack" runat="server" BackColor="#F0CCFF" CssClass="button Cancel" ForeColor="Blue" Text="Back" OnClick="btnBack_Click" Width="68px" />
                        &nbsp;&nbsp; 
                      <asp:Button ID="btnShareJob" runat="server" CssClass="button merge" BackColor="#F0CCFF" ForeColor="Blue" Text="Share Job" OnClick="btnShareJob_Click" />
                        &nbsp;&nbsp;
                     <input id="Button4" type="button" runat="server"  value="Hide/ Show System" onclick="return hideshow(document.getElementById('divHideSystem')) " />
                    </p>
                    <div id="divHideSystem">

                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="99%"
                            CellPadding="3"
                            OnRowEditing="GridView1_RowEditing" OnRowDeleting="GridView1_RowDeleting"
                            OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnRowDataBound="GridView1_RowDataBound" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellSpacing="2">
                            <Columns>

                                <asp:TemplateField HeaderText="Select">
                                    <ItemTemplate>
                                     
                                        <asp:LinkButton ID="btbxoagr121" runat="server" CommandName="Select"><img src="../Images/View.png" /> Select</asp:LinkButton>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="6%" />
                                      <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Edit">
                                    <ItemTemplate>
                                        
                                        <asp:LinkButton ID="btbxoagr12" runat="server" CommandName="Edit"><img src="../Images/Icon/edit.gif" /> Edit</asp:LinkButton>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="6%" />
                                      <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Delete">
                                    <ItemTemplate>
                                      
                                        <asp:LinkButton ID="btbxoagr112" runat="server" CommandName="Delete" ><img src="../Images/Icon/delete.png" /> Delete</asp:LinkButton>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="6%" />
                                      <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblGSBH" runat="server" Text='<%#Eval("gsbh") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>


                                <asp:TemplateField Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lbljsysid" runat="server" Text='<%#Eval("jsysid") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="System Name">
                                    <ItemTemplate>
                                        <asp:Label ID="lblsysname" runat="server" Text='<%#Eval("sysname") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Width="20%" />
                                      <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Memo">
                                    <ItemTemplate>
                                        <asp:Label ID="lblsysmemo" runat="server" Text='<%#Eval("sysmemo") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Width="15%" />
                                      <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Name - VN">
                                    <ItemTemplate>
                                        <asp:Label ID="lblsysnamevn" runat="server" Text='<%#Eval("sysnamevn") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Width="15%" />
                                      <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Memo - VN">
                                    <ItemTemplate>
                                        <asp:Label ID="lblsysmemovn" runat="server" Text='<%#Eval("sysmemovn") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Width="15%" />
                                      <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lbluserid" runat="server" Text='<%#Eval("userid") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lbluserdate" runat="server" Text='<%#Eval("userdate","{0:dd/MM/yyyy}") %>'></asp:Label>
                                    </ItemTemplate>

                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Yn" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblyn" runat="server" Text='<%#Eval("yn") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblsLeaderid" runat="server" Text='<%#Eval("sLeaderid") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Full Name" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblUSERNAME" runat="server" Text='<%#Eval("USERNAME") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="From Date">
                                    <ItemTemplate>
                                        <asp:Label ID="lbledates" runat="server" Text='<%#Eval("edates","{0:dd/MM/yyyy}") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Width="7%" HorizontalAlign="Center" />
                                      <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="To Date">
                                    <ItemTemplate>
                                        <asp:Label ID="lbledatee" runat="server" Text='<%#Eval("edatee","{0:dd/MM/yyyy}") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Width="7%" HorizontalAlign="Center" />
                                      <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Spercent">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSpercent" runat="server" Text='<%#Eval("Spercent","{0:0}") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Width="5%" HorizontalAlign="Center" />
                                      <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                     <asp:TemplateField HeaderText="EndMark">
                                    <ItemTemplate>
                                        <asp:Label ID="lblEndMark" runat="server" Text='<%#Eval("yn") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Width="5%" HorizontalAlign="Center" />
                                      <HeaderStyle HorizontalAlign="Center" />
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
            <br />

            <div id="divsubSystem" runat="server" style="margin-left: 25px">
                <p class="button-wrap">
                    <asp:Button ID="btnThem" runat="server" CssClass="button add" BackColor="#F0CCFF" ForeColor="Blue" Text="Add Project"
                        OnClick="btnThem_Click" Style="height: 26px" />
                    &nbsp;&nbsp;
         <input id="btnShowSubSystem" type="button" runat="server" value="Hide/ Show Sub System" onclick="return hideshow(document.getElementById('divHideSub')) " />
                </p>
                <div id="divHideSub">


                    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" Width="99%"
                        CellPadding="3"
                        OnRowEditing="GridView2_RowEditing"
                        OnSelectedIndexChanged="GridView2_SelectedIndexChanged1"
                        OnRowDeleting="GridView2_RowDeleting" OnRowDataBound="GridView2_RowDataBound" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px">
                        <Columns>
                          
                            <asp:TemplateField HeaderText="Select">
                                <ItemTemplate>
                                   
                                    <asp:LinkButton ID="btbxoagr221" runat="server" CommandName="Select"><img src="../Images/View.png" /> Select</asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="6%" />
                                  <HeaderStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Edit">
                                <ItemTemplate>
                                   
                                    <asp:LinkButton ID="btbxoagr22" runat="server" CommandName="Edit"><img src="../Images/Icon/edit.gif" /> Edit </asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="6%" />
                                  <HeaderStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Delete">
                                <ItemTemplate>
                                  
                                    <asp:LinkButton ID="btbxoagr2" runat="server" CommandName="Delete" ><img src="../Images/Icon/delete.png" /> Delete </asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="6%" />
                                  <HeaderStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblGSBH" runat="server" Text='<%#Eval("gsbh") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lbljsysid" runat="server" Text='<%#Eval("jsysid") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="jsubid" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lbljsubid" runat="server" Text='<%#Eval("jsubid") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Sub System">
                                <ItemTemplate>
                                    <asp:Label ID="lbljsubname" runat="server" Text='<%#Eval("jsubname") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="15%" />
                                  <HeaderStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Memo">
                                <ItemTemplate>
                                    <asp:Label ID="lbljsubmemo" runat="server" Text='<%#Eval("jsubmemo") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="10%" />
                                  <HeaderStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Sub System VN">
                                <ItemTemplate>
                                    <asp:Label ID="lbljsubnamevn" runat="server" Text='<%#Eval("jsubnamevn") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="15%" />
                                  <HeaderStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="jsubmemovn">
                                <ItemTemplate>
                                    <asp:Label ID="lbljsubmemovn" runat="server" Text='<%#Eval("jsubmemovn") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="15%" />
                                  <HeaderStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lbluserid" runat="server" Text='<%#Eval("userid") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lbluserdate" runat="server" Text='<%#Eval("userdate") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Yn" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblyn" runat="server" Text='<%#Eval("yn") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblsLeaderid" runat="server" Text='<%#Eval("sLeaderid") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Leader">
                                <ItemTemplate>
                                    <asp:Label ID="lblUSERNAME" runat="server" Text='<%#Eval("USERNAME") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="15%" />
                                  <HeaderStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="From Date">
                                <ItemTemplate>
                                    <asp:Label ID="lbledates" runat="server" Text='<%#Eval("edates","{0:dd/MM/yyyy}") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="7%" />
                                  <HeaderStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="To Date">
                                <ItemTemplate>
                                    <asp:Label ID="lbledatee" runat="server" Text='<%#Eval("edatee","{0:dd/MM/yyyy}") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="7%" />
                                  <HeaderStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Spercent">
                                <ItemTemplate>
                                    <asp:Label ID="lblSpercent" runat="server" Text='<%#Eval("Spercent","{0:0}") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="5%" />
                                  <HeaderStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="PDNO" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblPDNO" runat="server" Text='<%#Eval("PDNO") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="EndMark">
                                <ItemTemplate>
                                    <asp:Label ID="lblEndMark" runat="server" Text='<%#Eval("yn") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="5%" />
                                  <HeaderStyle HorizontalAlign="Center" />
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
            <br />

            <div id="divJob" runat="server" style="margin-left: 25px">
                <p class="button-wrap">
                    <asp:Button ID="btnAddSubproject" runat="server" CssClass="button add"  Text="Add Job" BackColor="#F0CCFF" ForeColor="Blue" OnClick="btnAddSubproject_Click" />
                    &nbsp;&nbsp;<input id="Button3" type="button" runat="server" value="Hide/ Show Job" onclick="return hideshow(document.getElementById('divHideJob')) " />
                </p>
                <div id="divHideJob">


                    <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" Width="99%"
                        CellPadding="3"
                        OnRowEditing="GridView3_RowEditing" OnRowDeleting="GridView3_RowDeleting" OnRowDataBound="GridView3_RowDataBound" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellSpacing="2" OnSelectedIndexChanged="GridView3_SelectedIndexChanged">
                        <Columns>
                            <asp:TemplateField HeaderText="Share Job">
                                <ItemTemplate>
                                    <asp:LinkButton ID="linkShare" runat="server" CommandName="Select"><img src="../Content/Icon/share.png" /> Share Job</asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="5%" />
                                  <HeaderStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Edit">
                                <ItemTemplate>
                                    <asp:LinkButton ID="btbxoagr32" runat="server" CommandName="Edit"><img src="../Images/Icon/edit.gif" /> Edit</asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="5%" />
                                  <HeaderStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Delete">
                                <ItemTemplate>
                                <%--    <asp:Button ID="btbxoagr3" runat="server" CommandName="Delete" Text="Delete"
                                        OnClientClick="return confirm('Are you sure you want to delete this event?');" />--%>
                                    <asp:LinkButton ID="btbxoagr3" runat="server" CommandName="Delete"> Delete </asp:LinkButton>
                                </ItemTemplate>
                                   <ItemStyle HorizontalAlign="Center" Width="6%" />
                                  <HeaderStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblgsbh" runat="server" Text='<%#Eval("gsbh") %>'></asp:Label>
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
                            <asp:TemplateField HeaderText="" Visible="false" >
                                <ItemTemplate>
                                    <asp:Label ID="lblticketid" runat="server" Text='<%#Eval("ticketid") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Job Name">
                                <ItemTemplate>
                                    <asp:Label ID="lbljobname" runat="server" Text='<%#Eval("jobname") %>'></asp:Label>
                                </ItemTemplate>
                                  <ItemStyle  Width="15%" />
                                  <HeaderStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="Job Name Vn">
                                <ItemTemplate>
                                    <asp:Label ID="lbljobnamevn" runat="server" Text='<%#Eval("jobnamevn") %>'></asp:Label>
                                </ItemTemplate>
                                   <ItemStyle  Width="15%" />
                                   <HeaderStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Job Name CH">
                                <ItemTemplate>
                                    <asp:Label ID="lbljobmemovn" runat="server" Text='<%#Eval("jobmemovn") %>'></asp:Label>
                                </ItemTemplate>
                                  <ItemStyle  Width="15%" />
                                  <HeaderStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Note">
                                <ItemTemplate>
                                    <asp:Label ID="lbljobmemo" runat="server" Text='<%#Eval("jobmemo") %>'></asp:Label>
                                </ItemTemplate>
                                   <ItemStyle  Width="15%" />
                                  <HeaderStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="userid" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lbluserid" runat="server" Text='<%#Eval("userid") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="userdate" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lbluserdate" runat="server" Text='<%#Eval("userdate","{0:yyyy/MM/dd}") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        
                            <asp:TemplateField HeaderText="Jleaderid" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblJleaderid" runat="server" Text='<%#Eval("Jleaderid") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="From Date">
                                <ItemTemplate>
                                    <asp:Label ID="lbledates" runat="server" Text='<%#Eval("edates","{0:dd/MM/yyyy}") %>'></asp:Label>
                                </ItemTemplate>
                                   <ItemStyle HorizontalAlign="Center" Width="5%" />
                                  <HeaderStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="To Date">
                                <ItemTemplate>
                                    <asp:Label ID="lbledatee" runat="server" Text='<%#Eval("edatee","{0:dd/MM/yyyy}") %>'></asp:Label>
                                </ItemTemplate>
                                   <ItemStyle HorizontalAlign="Center" Width="5%" />
                                  <HeaderStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Percent">
                                <ItemTemplate>
                                    <asp:Label ID="lbljpercent" runat="server" Text='<%#Eval("jpercent","{0:0}") %>'></asp:Label>
                                </ItemTemplate>
                                   <ItemStyle HorizontalAlign="Center" Width="5%" />
                                 <HeaderStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="PDNO" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblPDNO" runat="server" Text='<%#Eval("PDNO") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                               <asp:TemplateField HeaderText="EndMark">
                                <ItemTemplate>
                                    <asp:Label ID="lblyn" runat="server" Text='<%#Eval("yn") %>'></asp:Label>
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
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
