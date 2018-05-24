<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMater/MasterPage2.Master" AutoEventWireup="true" CodeBehind="WF_Projectm2.aspx.cs" Inherits="iOffice.presentationLayer.WF_Projectm2" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <telerik:RadCodeBlock ID="RadCodeBlock2" runat="server">
        <style type="text/css">
            .orderText
            {
                font: normal 12px Arial,Verdana;
                margin-top: 6px;
            }
        </style>
    </telerik:RadCodeBlock>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
           <script type="text/javascript">
               function ShowEditForm(id, rowIndex) {
                   var grid = $find("<%= RadGrid1.ClientID %>");

                var rowControl = grid.get_masterTableView().get_dataItems()[rowIndex].get_element();
                grid.get_masterTableView().selectItem(rowControl, true);

                window.radopen("EditForm_csharp.aspx?EmployeeID=" + id, "formProjectm");
                return false;
            }
            function ShowInsertForm() {
                window.radopen("EditForm_csharp.aspx", "formProjectm");
                return false;
            }
            function refreshGrid(arg) {
                if (!arg) {
                    $find("<%= RadAjaxManager1.ClientID %>").ajaxRequest("Rebind");
                    }
                    else {
                        $find("<%= RadAjaxManager1.ClientID %>").ajaxRequest("RebindAndNavigate");
                    }
                }
                function RowDblClick(sender, eventArgs) {
                    window.radopen("EditForm_csharp.aspx?EmployeeID=" + eventArgs.getDataKeyValue("EmployeeID"), "formProjectm");
                }
        </script>
    </telerik:RadCodeBlock>
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" OnAjaxRequest="RadAjaxManager1_AjaxRequest">
         <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="RadAjaxManager1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadGrid1" LoadingPanelID="gridLoadingPanel"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="RadGrid2" LoadingPanelID="gridLoadingPanel"></telerik:AjaxUpdatedControl>
                     <telerik:AjaxUpdatedControl ControlID="RadGrid3" LoadingPanelID="gridLoadingPanel"></telerik:AjaxUpdatedControl>
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="RadGrid1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadGrid1" LoadingPanelID="gridLoadingPanel"></telerik:AjaxUpdatedControl>
                      <telerik:AjaxUpdatedControl ControlID="RadGrid2" LoadingPanelID="gridLoadingPanel"></telerik:AjaxUpdatedControl>
                     <telerik:AjaxUpdatedControl ControlID="RadGrid3" LoadingPanelID="gridLoadingPanel"></telerik:AjaxUpdatedControl>
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Skin="Default"></telerik:RadAjaxLoadingPanel>
    <p>
        <asp:Button ID="Button1" runat="server" Text="Add" OnClientClick="return ShowInsertForm()" /></p>
    <telerik:RadGrid ID="RadGrid1"  runat="server" OnItemCreated="RadGrid1_ItemCreated" Height="225px">

        <MasterTableView AutoGenerateColumns="false" DataKeyNames="jsysid" ClientDataKeyNames="jsysid" NoMasterRecordsText="No project to display" Width="100%">
            <Columns>
                 <telerik:GridTemplateColumn UniqueName="TemplateEditColumn"  >
                                        <ItemTemplate>
                                            <asp:HyperLink ID="EditLink" runat="server" Text="Edit"><img src="../Images/View.png" /> Detail </asp:HyperLink>
                                           
                                        </ItemTemplate>
                                         
                                          <ItemStyle HorizontalAlign="Center" Width="6%" />
                                    </telerik:GridTemplateColumn>
                                     <telerik:GridTemplateColumn UniqueName="TemplateEditColumn"  >
                                        <ItemTemplate>
                                           
                                            <asp:LinkButton ID="linkDelete" runat="server" CommandName="Delete" > <img src="../Content/Icon/delete.png" />Delete </asp:LinkButton>
                                        </ItemTemplate>
                                         
                                          <ItemStyle HorizontalAlign="Center" Width="6%" />
                                    </telerik:GridTemplateColumn>
                                      <telerik:GridTemplateColumn UniqueName="TemplateEditColumn"  >
                                        <ItemTemplate>
                                             <asp:HyperLink ID="linkCreate" runat="server" Text="Create" NavigateUrl="~/presentationLayer/CreateMessage.aspx"><img src="../Content/Icon/add.gif" /> Create </asp:HyperLink>
                                           <%-- <asp:LinkButton ID="linkCreate" runat="server" CommandName="Select" > <img src="../Content/Icon/delete.png" />Create  </asp:LinkButton>--%>
                                        </ItemTemplate>
                                         
                                          <ItemStyle HorizontalAlign="Center" Width="6%" />
                                    </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn HeaderText="gsbh" Visible="false">
                    <ItemTemplate>
                        <asp:Label ID="lblgsbh" runat="server" Text='<%#Eval("gsbh") %>'></asp:Label>
                    </ItemTemplate>

                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn HeaderText="jsysid" Visible="false">
                    <ItemTemplate>
                        <asp:Label ID="lbljsysid" runat="server" Text='<%#Eval("jsysid") %>'></asp:Label>
                    </ItemTemplate>

                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn HeaderText="System Name">
                    <ItemTemplate>
                        <asp:Label ID="lblsysname" runat="server" Text='<%#Eval("sysname") %>'></asp:Label>
                    </ItemTemplate>

                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn HeaderText="Note">
                    <ItemTemplate>
                        <asp:Label ID="lblsysmemo" runat="server" Text='<%#Eval("sysmemo") %>'></asp:Label>
                    </ItemTemplate>

                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn HeaderText="System Name VN">
                    <ItemTemplate>
                        <asp:Label ID="lblsysnamevn" runat="server" Text='<%#Eval("sysnamevn") %>'></asp:Label>
                    </ItemTemplate>

                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn HeaderText="Note">
                    <ItemTemplate>
                        <asp:Label ID="lblsysmemovn" runat="server" Text='<%#Eval("sysmemovn") %>'></asp:Label>
                    </ItemTemplate>

                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn HeaderText="Begin Date">
                    <ItemTemplate>
                        <asp:Label ID="lbledates" runat="server" Text='<%#Eval("edates") %>'></asp:Label>
                    </ItemTemplate>

                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn HeaderText="End Date">
                    <ItemTemplate>
                        <asp:Label ID="lbledatee" runat="server" Text='<%#Eval("edatee") %>'></asp:Label>
                    </ItemTemplate>

                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn HeaderText="Percent">
                    <ItemTemplate>
                        <asp:Label ID="lblSpercent" runat="server" Text='<%#Eval("Spercent") %>'></asp:Label>
                    </ItemTemplate>

                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn HeaderText="yn" Visible="false">
                    <ItemTemplate>
                        <asp:Label ID="lblyn" runat="server" Text='<%#Eval("yn") %>'></asp:Label>
                    </ItemTemplate>

                </telerik:GridTemplateColumn>
                
            </Columns>
        </MasterTableView>
        <ClientSettings>
            <Selecting AllowRowSelect="true" />
            <Scrolling SaveScrollPosition="true" AllowScroll="true" UseStaticHeaders="true" />
        </ClientSettings>
    </telerik:RadGrid>
    <telerik:RadWindowManager ID="RadWindowManager1" runat="server" EnableShadow="true">
       <Windows>
            <telerik:RadWindow id="formProjectm" runat="server" Title="Insert Update Project" Height="600px" Width="900px" Left="150px" ReloadOnShow="true" ShowContentDuringLoad="false" Modal="true"></telerik:RadWindow>
       </Windows>
    </telerik:RadWindowManager>




        <telerik:RadCodeBlock ID="RadCodeBlock3" runat="server">
                <script type="text/javascript">
                    function ShowEditForm(id, rowIndex) {
                        var grid = $find("<%= RadGrid2.ClientID %>");

                   var rowControl = grid.get_masterTableView().get_dataItems()[rowIndex].get_element();
                   grid.get_masterTableView().selectItem(rowControl, true);

                   window.radopen("EditForm_csharp.aspx?EmployeeID=" + id, "formProjectn");
                   return false;
               }
               function ShowInsertForm() {
                   window.radopen("EditForm_csharp.aspx", "formProjectn");
                   return false;
               }
               function refreshGrid(arg) {
                   if (!arg) {
                       $find("<%= RadAjaxManager1.ClientID %>").ajaxRequest("Rebind");
                }
                else {
                    $find("<%= RadAjaxManager1.ClientID %>").ajaxRequest("RebindAndNavigate");
                }
            }
            function RowDblClick(sender, eventArgs) {
                window.radopen("EditForm_csharp.aspx?EmployeeID=" + eventArgs.getDataKeyValue("EmployeeID"), "formProjectn");
            }
        </script>
        </telerik:RadCodeBlock>
  <%--      <telerik:RadAjaxManager ID="RadAjaxManager2" runat="server">
                <AjaxSettings>
                <telerik:AjaxSetting AjaxControlID="RadAjaxManager2">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="RadGrid2" LoadingPanelID="gridLoadingPanel"></telerik:AjaxUpdatedControl>
                    </UpdatedControls>
                </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="RadGrid2">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="RadGrid2" LoadingPanelID="gridLoadingPanel"></telerik:AjaxUpdatedControl>
                    </UpdatedControls>
                </telerik:AjaxSetting>
            </AjaxSettings>
        </telerik:RadAjaxManager>--%>

        <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel2" runat="server" Skin="Default"></telerik:RadAjaxLoadingPanel>
        <telerik:RadGrid ID="RadGrid2" runat="server" OnItemCreated="RadGrid2_ItemCreated" Height="153px" Width="100%" OnSelectedIndexChanged="RadGrid2_SelectedIndexChanged" OnItemCommand="RadGrid2_ItemCommand">
            <MasterTableView AutoGenerateColumns="false" DataKeyNames="jsubid,jsysid,gsbh" ClientDataKeyNames="jsubid,jsysid,gsbh"  NoMasterRecordsText="No sub project to display" Width="100%">
                <Columns>
                    <telerik:GridTemplateColumn>
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Select">LinkButton</asp:LinkButton>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                       <telerik:GridTemplateColumn UniqueName="TemplateEditColumn"  >
                           <ItemTemplate>
                              <asp:HyperLink ID="EditLink" runat="server" Text="Edit"><img src="../Images/View.png" /> Detail </asp:HyperLink>
                                           
                           </ItemTemplate>
                                         
                            <ItemStyle HorizontalAlign="Center" Width="6%" />
                      </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn HeaderText="gsbh">
                        <ItemTemplate>
                            <asp:Label ID="lblgsbh" runat="server" Text='<%#Eval("gsbh") %>'></asp:Label>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                     <telerik:GridTemplateColumn HeaderText="jsysid">
                        <ItemTemplate>
                            <asp:Label ID="lbljsysid" runat="server" Text='<%#Eval("jsysid") %>'></asp:Label>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                     <telerik:GridTemplateColumn HeaderText="">
                        <ItemTemplate>
                            <asp:Label ID="lbljsubid" runat="server" Text='<%#Eval("jsubid") %>'></asp:Label>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                     <telerik:GridTemplateColumn HeaderText="System Name">
                        <ItemTemplate>
                            <asp:Label ID="lbljsubname" runat="server" Text='<%#Eval("jsubname") %>'></asp:Label>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                     <telerik:GridTemplateColumn HeaderText="Note">
                        <ItemTemplate>
                            <asp:Label ID="lbljsubmemo" runat="server" Text='<%#Eval("jsubmemo") %>'></asp:Label>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                     <telerik:GridTemplateColumn HeaderText="Sub System VN">
                        <ItemTemplate>
                            <asp:Label ID="lbljsubnamevn" runat="server" Text='<%#Eval("jsubnamevn") %>'></asp:Label>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                     <telerik:GridTemplateColumn HeaderText="Note">
                        <ItemTemplate>
                            <asp:Label ID="lbljsubmemovn" runat="server" Text='<%#Eval("jsubmemovn") %>'></asp:Label>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                     <telerik:GridTemplateColumn HeaderText="Begin Date">
                        <ItemTemplate>
                            <asp:Label ID="lbledates" runat="server" Text='<%#Eval("edates") %>'></asp:Label>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                     <telerik:GridTemplateColumn HeaderText="End Date">
                        <ItemTemplate>
                            <asp:Label ID="lbledatee" runat="server" Text='<%#Eval("edatee") %>'></asp:Label>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn HeaderText="Percent">
                        <ItemTemplate>
                            <asp:Label ID="lblSpercent" runat="server" Text='<%#Eval("Spercent") %>'></asp:Label>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                </Columns>
            </MasterTableView>
               <ClientSettings>
                    <Selecting AllowRowSelect="true" />
                    <Scrolling SaveScrollPosition="true" AllowScroll="true" UseStaticHeaders="true" />
                </ClientSettings>
        </telerik:RadGrid>
    <telerik:RadWindowManager ID="RadWindowManager2" runat="server">
        <Windows>
              <telerik:RadWindow id="formProjectn" runat="server" Title="Insert Update Project" Height="600px" Width="900px" Left="150px" ReloadOnShow="true" ShowContentDuringLoad="false" Modal="true"></telerik:RadWindow>
        </Windows>
    </telerik:RadWindowManager>


    <telerik:RadCodeBlock ID="RadCodeBlock4" runat="server">
         <script type="text/javascript">
             function ShowEditForm(id, rowIndex) {
                 var grid = $find("<%= RadGrid3.ClientID %>");

                        var rowControl = grid.get_masterTableView().get_dataItems()[rowIndex].get_element();
                        grid.get_masterTableView().selectItem(rowControl, true);

                        window.radopen("EditForm_csharp.aspx?EmployeeID=" + id, "RadWindow1");
                        return false;
                    }
                    function ShowInsertForm() {
                        window.radopen("EditForm_csharp.aspx", "RadWindow1");
                        return false;
                    }
                    function refreshGrid(arg) {
                        if (!arg) {
                            $find("<%= RadAjaxManager1.ClientID %>").ajaxRequest("Rebind");
                   }
                   else {
                       $find("<%= RadAjaxManager1.ClientID %>").ajaxRequest("RebindAndNavigate");
                   }
               }
               function RowDblClick(sender, eventArgs) {
                   window.radopen("EditForm_csharp.aspx?EmployeeID=" + eventArgs.getDataKeyValue("EmployeeID"), "RadWindow1");
               }
        </script>

    </telerik:RadCodeBlock>
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel3" runat="server" Skin="Default"></telerik:RadAjaxLoadingPanel>
    <telerik:RadGrid ID="RadGrid3" runat="server" OnItemCreated="RadGrid3_ItemCreated">
        <MasterTableView AutoGenerateColumns="false" DataKeyNames="gsbh,jsysid,jsubid,jobid" ClientDataKeyNames="gsbh,jsysid,jsubid,jobid" Width="100%">
            <Columns>
                 <telerik:GridTemplateColumn UniqueName="TemplateEditColumn"  >
                    <ItemTemplate>
                       <asp:HyperLink ID="EditLink" runat="server" Text="Edit"><img src="../Images/View.png" /> Detail </asp:HyperLink>
                                           
                  </ItemTemplate>
                                         
                  <ItemStyle HorizontalAlign="Center" Width="6%" />
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn>
                    <ItemTemplate>
                        <asp:Label ID="lblgsbh" runat="server" Text='<%#Eval("gsbh") %>'></asp:Label>
                    </ItemTemplate>

                </telerik:GridTemplateColumn>
                 <telerik:GridTemplateColumn>
                    <ItemTemplate>
                        <asp:Label ID="lbljsysid" runat="server" Text='<%#Eval("jsysid") %>'></asp:Label>
                    </ItemTemplate>

                </telerik:GridTemplateColumn>
                 <telerik:GridTemplateColumn>
                    <ItemTemplate>
                        <asp:Label ID="lbljsubid" runat="server" Text='<%#Eval("jsubid") %>'></asp:Label>
                    </ItemTemplate>

                </telerik:GridTemplateColumn>
                 <telerik:GridTemplateColumn>
                    <ItemTemplate>
                        <asp:Label ID="lbljobid" runat="server" Text='<%#Eval("jobid") %>'></asp:Label>
                    </ItemTemplate>

                </telerik:GridTemplateColumn>
                 <telerik:GridTemplateColumn HeaderText="Job Name">
                    <ItemTemplate>
                        <asp:Label ID="lbljobname" runat="server" Text='<%#Eval("jobname") %>'></asp:Label>
                    </ItemTemplate>

                </telerik:GridTemplateColumn>
                 <telerik:GridTemplateColumn HeaderText="Note">
                    <ItemTemplate>
                        <asp:Label ID="lbljobmemo" runat="server" Text='<%#Eval("jobmemo") %>'></asp:Label>
                    </ItemTemplate>

                </telerik:GridTemplateColumn>
                 <telerik:GridTemplateColumn HeaderText="Job Name VN">
                    <ItemTemplate>
                        <asp:Label ID="lbljobnamevn" runat="server" Text='<%#Eval("jobnamevn") %>'></asp:Label>
                    </ItemTemplate>

                </telerik:GridTemplateColumn>
                 <telerik:GridTemplateColumn HeaderText="Note">
                    <ItemTemplate>
                        <asp:Label ID="lbljobmemovn" runat="server" Text='<%#Eval("jobmemovn") %>'></asp:Label>
                    </ItemTemplate>

                </telerik:GridTemplateColumn>
                 <telerik:GridTemplateColumn HeaderText="Begin Date">
                    <ItemTemplate>
                        <asp:Label ID="lbledates" runat="server" Text='<%#Eval("edates") %>'></asp:Label>
                    </ItemTemplate>

                </telerik:GridTemplateColumn>
                 <telerik:GridTemplateColumn HeaderText="End Date">
                    <ItemTemplate>
                        <asp:Label ID="lbledatee" runat="server" Text='<%#Eval("edatee") %>'></asp:Label>
                    </ItemTemplate>

                </telerik:GridTemplateColumn>
               

            </Columns>
        </MasterTableView>
         <ClientSettings>
                    <Selecting AllowRowSelect="true" />
                    <Scrolling SaveScrollPosition="true" AllowScroll="true" UseStaticHeaders="true" />
        </ClientSettings>
    </telerik:RadGrid>
    <telerik:RadWindowManager ID="RadWindowManager3" runat="server">
        <Windows>
              <telerik:RadWindow id="RadWindow1" runat="server" Title="Insert Update Project" Height="600px" Width="900px" Left="150px" ReloadOnShow="true" ShowContentDuringLoad="false" Modal="true"></telerik:RadWindow>
        </Windows>
    </telerik:RadWindowManager>
</asp:Content>
