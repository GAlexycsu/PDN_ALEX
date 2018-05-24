<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMater/MasterPage.Master" AutoEventWireup="true" CodeBehind="pageMain2.aspx.cs" Inherits="iOffice.presentationLayer.pageMain2" %>


<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   
    <link href="../Style/jquery-ui-1.8.19.custom.css" rel="stylesheet" />

    
   <script  src='<%#ResolveClientUrl("~/Scripts/jquery.min.js") %>' type="text/javascript"></script>


      <script type="text/javascript" id="telerikClientEvents1">
          //<![CDATA[

          function RadScheduler1_TimeSlotContextMenu(sender, args) {
              //Add JavaScript handler code here
          }
          //]]>

</script> 

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <telerik:RadStyleSheetManager ID="RadStyleSheetManager1" runat="server">
     </telerik:RadStyleSheetManager>
     <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
         <Scripts>
             <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.Core.js">
             </asp:ScriptReference>
             <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQuery.js">
             </asp:ScriptReference>
             <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQueryInclude.js">
             </asp:ScriptReference>
         </Scripts>
     </telerik:RadScriptManager>
     <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" OnAjaxRequest="RadAjaxManager1_AjaxRequest">
           <AjaxSettings>
             <telerik:AjaxSetting AjaxControlID="Panel1">
                <UpdatedControls>
                   <telerik:AjaxUpdatedControl ControlID="RadScheduler1" LoadingPanelID="RadAjaxLoadingPanel1" />
                    <telerik:AjaxUpdatedControl ControlID="ConfiguratorPanel1" LoadingPanelID="RadAjaxLoadingPanel1"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="RadGrid1" LoadingPanelID="gridLoadingPanel"></telerik:AjaxUpdatedControl>
                </UpdatedControls>
             </telerik:AjaxSetting>
            <%-- <telerik:AjaxSetting AjaxControlID="RadScheduler1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadScheduler1" LoadingPanelID="RadAjaxLoadingPanel1"></telerik:AjaxUpdatedControl>
                </UpdatedControls>
            </telerik:AjaxSetting>--%>
          </AjaxSettings>
     </telerik:RadAjaxManager>
     <telerik:RadAjaxLoadingPanel runat="server" ID="RadAjaxLoadingPanel1">
    </telerik:RadAjaxLoadingPanel>
    <telerik:RadScriptBlock ID="RadScriptBlock1" runat="server">
        <script type="text/javascript">

            Sys.Application.add_load(function () {
                demo.schedulerId = "<%= RadScheduler1.ClientID %>";

                demo.tooltip = $find('<%=RadToolTip1.ClientID %>');
                demo.hiddenInputAppointmentInfo = "<%=HiddenInputAppointmentInfo.ClientID%>";
                demo.treenode = "<%= RadTreeView1.ClientID%>"
            });

        </script>

        <script src="../Scripts/JScriptMoveTreeview2.js"></script>
          <script type="text/javascript">
                  function ShowEditForm(id, rowIndex) {
                      var grid = $find("<%= RadGrid1.ClientID %>");

                    var rowControl = grid.get_masterTableView().get_dataItems()[rowIndex].get_element();
                    grid.get_masterTableView().selectItem(rowControl, true);

                    window.radopen("Action_Group.aspx?USID=" + id, "UserListDialog");
                    return false;
                }
                function ShowInsertForm() {
                    window.radopen("Action_Group.aspx", "UserListDialog");
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
                        window.radopen("Action_Group.aspx?USID=" + eventArgs.getDataKeyValue("USID"), "UserListDialog");
                    }
        </script>
    </telerik:RadScriptBlock>
     <div  style="height: 35px; background: #cecece; width:100%;  padding: 7px 7px 7px 7px;border: 1px solid #cecece; text-align:center;overflow:hidden">
      <style>
                    .cnMatKhau{list-style: none; margin: 0px; padding: 0px 0px 0px 0px;font-size:small}
                    .cnMatKhau li{display: inline-block;
                width: auto;
                margin-left:20px;
            }
                    .cnMatKhau li a{text-decoration: none; color:#1D19A9; }
                    .sub{position: absolute;  background: #E5ECF0; list-style: none; display:none;width:200px; text-align:left}
                    .sub li{display: list-item; border-bottom: 1px solid #fff; width:330px; }
                    .cnMatKhau > li:hover > .sub{display: block;}
            
            
               </style>
        <ul class="cnMatKhau">

            <li>
                <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="">Web <ul class="sub">
                    <li id="liLinkProvider" runat="server" style="text-align:left; color:#fff">
                       <asp:LinkButton ID="LinkProvider" runat="server" onclick="LinkProvider_Click"> Web Portal Vender</asp:LinkButton></li><li id="liLinkSIS" runat="server" style="text-align:left; color:#fff">
                       <asp:LinkButton ID="LinkSIS" runat="server" onclick="LinkSIS_Click"> SIS</asp:LinkButton></li><li id="liLinkImportData" runat="server" style="text-align:left; color:#fff">
                       <asp:LinkButton ID="LinkImportData" runat="server" 
                             onclick="LinkImportData_Click">Import Data</asp:LinkButton></li><li id="liLinkKswiss" runat="server" style="text-align:left; color:#fff">
                       <asp:LinkButton ID="LinkKswiss" runat="server" onclick="LinkKswiss_Click"> ImportData for Kswiss</asp:LinkButton></li><li id="liLinkPMBOM" runat="server" style="text-align:left; color:#fff">
                         <asp:LinkButton ID="LinkPMBOM" runat="server" onclick="LinkPMBOM_Click">Import Data for PM- BOM</asp:LinkButton></li><li id="liLinkImportBOMTest" runat="server" style="text-align:left; color:#fff">
                         <asp:LinkButton ID="LinkImportBOMTest" runat="server" 
                               onclick="LinkImportBOMTest_Click">PM-BOM - Test</asp:LinkButton></li></ul></asp:HyperLink>       
                     
            </li>
        </ul>
       <ul class="cnMatKhau">

            <li>
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="">FUNCTION PDN <ul class="sub">
                        <li style="text-align:left; color:#fff">
                            <%--<asp:HyperLink ID="HyperLinkForgotPass" runat="server" NavigateUrl="http://192.168.11.8/PDN/presentationLayer/FrmQuenmatkhauxetduyet.aspx">Forgot Password Aprroval</asp:HyperLink>--%>
                           <asp:LinkButton ID="linkQuenMatKhau" runat="server" 
                            onclick="linkQuenMatKhau_Click">Forgot Password Aprroval</asp:LinkButton></li><li style="text-align:left; color:#fff">
                           <%-- <asp:HyperLink ID="HyperChangePass" runat="server" NavigateUrl="http://192.168.11.8/PDN/presentationLayer/frmDoiMatKhauXetDuyet.aspx">Change Password Aprroval</asp:HyperLink>--%>
                           <asp:LinkButton ID="linkChangPass" runat="server" 
                             onclick="linkChangPass_Click"  >Change Password Aprroval</asp:LinkButton></li><li  style="text-align:left; color:#fff">
                               <asp:LinkButton ID="LinkChangPassLogin" runat="server" onclick="LinkChangPassLogin_Click" 
                                 >Change Password Login</asp:LinkButton></li><li style="text-align:left; color:#fff">
                           <%-- <asp:HyperLink ID="HyperChangeSig" runat="server" NavigateUrl="http://192.168.11.8/PDN/presentationLayer/changesignature.aspx">Change Signature</asp:HyperLink>--%>
                          <asp:LinkButton ID="linkChuKy" runat="server" onclick="linkChuKy_Click">Change Signature</asp:LinkButton></li></ul></asp:HyperLink>
            </li>
        </ul>
         <ul class="cnMatKhau">

            <li>
                <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="">Google <ul class="sub">
                        <li style="text-align:left; color:#fff">
                          <asp:LinkButton ID="LinkMail" runat="server" onclick="LinkMail_Click">Google Mail</asp:LinkButton></li><li style="text-align:left; color:#fff">
                           <asp:LinkButton ID="LinkTranslate" runat="server" onclick="LinkTranslate_Click">Google Translate</asp:LinkButton></li><li style="text-align:left; color:#fff">
                           <asp:LinkButton ID="LinkMap" runat="server" onclick="LinkMap_Click">Google Map</asp:LinkButton></li><li style="text-align:left; color:#fff">
                           
                            <asp:LinkButton ID="LinkDocument" runat="server" onclick="LinkDocument_Click">Google Document</asp:LinkButton></li></ul></asp:HyperLink>
            </li>
        </ul>
        <div id="divMyEmail">
           <%-- <asp:Button ID="btnMyEmail" runat="server" Text=" My Emails"  Width=100px Height="40px" OnClick="btnMyEmail_Click"/>--%>
            <asp:LinkButton ID="btnMyEmail" runat="server" onclick="btnMyEmail_Click1"><img src="../Images/email_icon_small1.jpg" /> Email</asp:LinkButton>
        </div>
        <div id= "divTucQuaDi" >
                <asp:LinkButton ID="LinkMyCheck" runat="server" onclick="LinkMyCheck_Click"><img src="../Images/OK.png" /> My Check </asp:LinkButton> 
                             <asp:Label ID="lblCheck1" runat="server" Text="("></asp:Label>   
                             <asp:Label ID="lblCheck2" runat="server" Text=""></asp:Label>
                             <asp:Label ID="lblCheck3" runat="server" Text=")"></asp:Label>
        </div>
        <div id="divMyDoc" >
            <asp:LinkButton ID="LinkMyDocus" runat="server" onclick="LinkMyDocus_Click"><img src="../Images/Message.png" /> My Document</asp:LinkButton>
                             <asp:Label ID="lblDoc1" runat="server" Text="("></asp:Label>
                             <asp:Label ID="lblDoc2" runat="server" Text=""></asp:Label>
                             <asp:Label ID="lblDoc3" runat="server" Text=")"></asp:Label>
        </div>
        <div id="divAdmin">
              <asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click"><img src="../Images/Setting.png" /> Admin</asp:LinkButton>
        </div>
        <div id="div11"  style="height: 13px">
              <asp:LinkButton ID="LinkCreateUser" runat="server"  Text=""
                  onclick="LinkCreateUser_Click" ><img src="../Images/Create.png" /> Create User</asp:LinkButton>
        </div>
        <div id="DivProject">
           <asp:LinkButton ID="linkProject" runat="server" onclick="linkProject_Click"><img src="../Images/project.png" height="15px" width="15px" /> Project</asp:LinkButton>
        </div>
         <div id="DivGroup">
           <asp:LinkButton ID="LinkGroup" runat="server" onclick="LinkGroup_Click"><img src="../Images/User-group.png" /> Group</asp:LinkButton>
        </div>
        <div id="login1" style="width:auto;text-align:left; float:right; height: 14px;margin-right:100px" > 
           
            <asp:LinkButton ID="LinkButton2" runat="server"  ValidationGroup="logout" 
                onclick="LinkButton2_Click"><img src="../Images/Turn-off.png" /> Logout</asp:LinkButton>

        </div>
      
       </div>
   

     
     <div  style="border: 0px solid #cecece; padding: 7px 7px 7px 7px; width: 100%;">
                 <div  style=" display: table-cell;  width:80%; float:right;">
                    
                     <div style="height:150px; border: 1px solid red;">

                         <telerik:RadAjaxLoadingPanel runat="server" ID="gridLoadingPanel"></telerik:RadAjaxLoadingPanel>
                         <telerik:RadGrid ID="RadGrid1" runat="server" OnItemCreated="RadGrid1_ItemCreated" Skin="Simple">
                             <MasterTableView AutoGenerateColumns="false" DataKeyNames="USID" ClientDataKeyNames="USID" Width="100%">
                                 <Columns>
                                     <telerik:GridTemplateColumn UniqueName="TemplateEditColumn">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="EditLink" runat="server" Text="Edit"><img src="../Images/View.png" /> </asp:HyperLink>

                                        </ItemTemplate>
                                          <ItemStyle HorizontalAlign="Center" Width="6%" />
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridBoundColumn DataField="GSBH" HeaderText="" Visible="false" SortExpression="GSBH" UniqueName="GSBH"></telerik:GridBoundColumn>
                                     <telerik:GridBoundColumn DataField="Userid" HeaderText="" Visible="false" SortExpression="Userid" UniqueName="Userid"></telerik:GridBoundColumn>
                                     <telerik:GridBoundColumn DataField="USID" HeaderText="USID" Visible="false" SortExpression="USID" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" UniqueName="USID"></telerik:GridBoundColumn>
                                     <telerik:GridBoundColumn DataField="UGno" HeaderText="" Visible="false" SortExpression="UGno" UniqueName="UGno"></telerik:GridBoundColumn>
                                     <telerik:GridBoundColumn DataField="UStitle" HeaderText="Title"  SortExpression="UStitle" HeaderStyle-HorizontalAlign="Center" UniqueName="UStitle"></telerik:GridBoundColumn>
                                    <%-- <telerik:GridBoundColumn DataField="sdate" HeaderText=" From Date"   SortExpression="sdate" UniqueName="sdate"></telerik:GridBoundColumn>
                                     <telerik:GridBoundColumn DataField="edate" HeaderText="End Date" SortExpression="edate" UniqueName="edate"></telerik:GridBoundColumn>--%>
                                     <telerik:GridTemplateColumn HeaderText="From Date">
                                         <ItemTemplate>
                                              <asp:Label ID="lblsdate" runat="server" Text='<%#Eval("sdate","{0:dd/MM/yyyy}") %>'></asp:Label>
                                         </ItemTemplate>
                                         <ItemStyle HorizontalAlign="Center" Width="10%" />
                                            <HeaderStyle HorizontalAlign="Center" />
                                     </telerik:GridTemplateColumn>
                                     <telerik:GridTemplateColumn HeaderText="TO Date">
                                         <ItemTemplate>
                                              <asp:Label ID="lbledate" runat="server" Text='<%#Eval("edate","{0:dd/MM/yyyy}") %>'></asp:Label>
                                         </ItemTemplate>
                                          <ItemStyle HorizontalAlign="Center" Width="10%" />
                                         <HeaderStyle HorizontalAlign="Center" />
                                     </telerik:GridTemplateColumn>
                                 </Columns>
                             </MasterTableView>
                             <ClientSettings>
                                 <Selecting AllowRowSelect="true" />
                                 <ClientEvents OnRowClick="RowDblClick" />
                             </ClientSettings>

                         </telerik:RadGrid>
                         <telerik:RadWindowManager  ID="RadWindowManager1" runat="server" EnableShadow="true">
                             <Windows>
                                 <telerik:RadWindow ID="UserListDialog" runat="server" Title="Details Group"  Height="600px" Width="800px" Left="150px" ReloadOnShow="true" ShowContentDuringLoad="false" Modal="true">

                                 </telerik:RadWindow>
                             </Windows>
                         </telerik:RadWindowManager>
                       </div>
                     <div style="height:500px; width:100%;">
                    
                        <div class="list wp-form" id="WorkAssignment">

     
                            
         <div class="form1">
             

             <telerik:RadScheduler ID="RadScheduler1" runat="server"
                 ResolvedRenderMode="Classic" DataDescriptionField="Description" 
                    DataEndField="End" DataKeyField="ID" DataStartField="Start" 
                    DataSubjectField="Subject" 
                    onappointmentcommand="RadScheduler1_AppointmentCommand" 
                  
                    WeekView-GroupingDirection="Horizontal" 
                    onclienttimeslotcontextmenu="RadScheduler1_TimeSlotContextMenu" 
                  onformcreated="RadScheduler1_FormCreated" 
                  onappointmentdelete="RadScheduler1_AppointmentDelete" 
                  Width="99%" 
                  OnClientAppointmentMoving="appointmentMoving"
                    OnClientFormCreated="formCreated" EnableDescriptionField="true" 
                
                 onappointmentinsert="RadScheduler1_AppointmentInsert" Height="549px" OnAppointmentDataBound="RadScheduler1_AppointmentDataBound" CustomAttributeNames="jobpercent" DayEndTime="17:00:00" OnDataBound="RadScheduler1_DataBound"

                 >
                     <Localization AdvancedAllDayEvent="All Day" AdvancedCalendarCancel="Cancel"
                     AdvancedClose="Close" AdvancedDaily="Daily" AdvancedDay="Day"
                      AdvancedDescription="Description" AdvancedEditAppointment="Edit Appointment"
                      AllDay="All Day" Cancel="Cancel" ConfirmCancel="Cancel"
                       ConfirmDeleteText="Do you want to delete?" ConfirmDeleteTitle="Confirm Delete"  ConfirmOK="OK"
                       ContextMenuAddAppointment="Add Appointment" ContextMenuDelete="Delete"
                       ContextMenuEdit="Edit" HeaderDay="Day" HeaderMonth="Month"
                       HeaderNextDay="Next Day" HeaderPrevDay="Preview day" 
                       HeaderTimeline="Time Line" HeaderToday="Today" HeaderWeek="Week"
                       Save="Save" ShowAdvancedForm="Options" AdvancedDone="Done"
                       AdvancedNewAppointment="New Appointment" ContextMenuGoToToday="Go To Today" Show24Hours="Show 24 Hours" 
                       ShowBusinessHours="Show Business Hours" ShowMore="Show More"
                    />

                    <AdvancedForm  DateFormat="MM/dd/yyyy" />
                    <TimeSlotContextMenuSettings EnableDefault="true" />
                    <AppointmentContextMenuSettings EnableDefault="true" />
                    <MonthView GroupingDirection="Vertical" />
                    <AdvancedEditTemplate>
                      <div class="rsAdvancedEdit1">
                          <div class="rsAdvInnerTitle1"> Edit Appointment </div>
                          <br />
                      </div>
                      <div class="rsAdvContentWrapper1">
                          <div class="rsAdvOptionsScroll1">
                             <div class="rsAdvOptions">
                                <div class="rsAdvBasicControls1">
                                    <div class="rsAdvOptionsPanel1">
                                        <table width="100%">
                                            <tr>
                                               <td align="right" width="135px">
                                                   Appointment Name
                                                   <br />
                                               </td>
                                               <td> 
                                                   <asp:HiddenField runat="server" ID="hdfID" />
                                                   <asp:TextBox runat="server" ID="SubjectTextBox" Width="100%" CssClass="txt"></asp:TextBox>
                                                   <br />
                                                   <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="SubjectTextBox" ErrorMessage=""></asp:RequiredFieldValidator>
                                               </td>
                                            </tr>
                                            <tr>
                                               <td > 
                                                  Begin date
                                               </td>
                                               <td>
                                                   <telerik:RadDateTimePicker ID="StartInput" runat="server">
                                                     <Calendar UseRowHeadersAsSelectors="false" UseColumnHeadersAsSelectors="false" ViewSelectorText="x"></Calendar>
                                                     <TimeView CellSpacing="-1" Columns="2" RenderDirection="Vertical">
                                                     </TimeView>
                                                     <TimePopupButton ImageUrl="" HoverImageUrl="" />
                                                     <DatePopupButton ImageUrl="" HoverImageUrl="" />
                                                     <DateInput ID="TimeBegin" runat="server" DisplayDateFormat="MM/dd/yyyy HH:mm:ss" DateFormat="MM/dd/yyyy HH:mm:ss"></DateInput>

                                                   </telerik:RadDateTimePicker>
                                                   <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="StartInput" ErrorMessage="Begin date"></asp:RequiredFieldValidator>
                                               </td>
                                               
                                            </tr>
                                            <tr>
                                               <td> End date
                                                  
                                               </td>
                                               <td>
                                                   <telerik:RadDateTimePicker ID="EndInput" runat="server">
                                                      <Calendar UseRowHeadersAsSelectors="false" UseColumnHeadersAsSelectors="false" ViewSelectorText="x"></Calendar>
                                                      <TimeView CellSpacing="-1" Columns="2" RenderDirection="Vertical"></TimeView>
                                                      <TimePopupButton ImageUrl="" HoverImageUrl="" />
                                                      <DatePopupButton ImageUrl="" HoverImageUrl="" />
                                                      <DateInput DisplayDateFormat="MM/dd/yyyy HH:mm:ss" DateFormat="MM/dd/yyyy HH:mm:ss" runat="server" ID="dateStart"></DateInput>

                                                   </telerik:RadDateTimePicker>
                                                   <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="EndInput" ErrorMessage="End date"></asp:RequiredFieldValidator>
                                                   <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="StartInput" ControlToValidate="EndInput" ErrorMessage="End date > Begin date" Operator="GreaterThanEqual"></asp:CompareValidator>
                                               </td>
                                            </tr>
                                            <tr>
                                               <td> Description
                                               </td>
                                               <td>
                                                     <telerik:RadTextBox ID="txtDescription" runat="server" CssClass="riTextBox riFocused" BorderColor="#C3D9F9" BorderStyle="Solid" BorderWidth="1px" Columns="150"  TextMode="MultiLine">

                                                    </telerik:RadTextBox>
                                               </td>
                                            </tr>
                                            <tr>
                                                <td> Link
                                                </td>
                                                <td>
                                                    <telerik:RadTextBox ID="txtLink" runat="server" CssClass="riTextBox riFocused" BorderColor="#C3D9F9" BorderStyle="Solid" BorderWidth="1px" Columns="150"  TextMode="MultiLine">

                                                    </telerik:RadTextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                               <td>Percent</td>
                                               <td>
                                                   <telerik:RadNumericTextBox ID="txtPhanTram" runat="server" Type="Percent" ShowSpinButtons="true" MaxLength="3" MaxValue="100" BackColor="peachpuff" ForeColor="Blue" >
                                                      <NumberFormat AllowRounding="True" KeepNotRoundedValue="False" DecimalDigits="0"></NumberFormat>
                                                   </telerik:RadNumericTextBox>
                                               </td>
                                            </tr>
                                            <tr>
                                               <td></td>
                                               <td>
                                                  <asp:Button  ID="UpdateButton" runat="server" CommandName="Update" Text="Update" /> &nbsp &nbsp
                                                   <asp:Button ID="UpdateCancelButton" runat="server" Text="Cancel" CausesValidation="false" CommandName="Cancel" />
                                               </td>
                                            </tr>
                                        </table>
                                    </div>
                                </div>
                             </div>
                          </div>
                      </div>
                    </AdvancedEditTemplate>
                    <AdvancedInsertTemplate>
                        <div class="rsAdvancedEdit1">
                             <div class="rsAdvTitle1">
                                        <div class="rsAdvInnerTitle1"> Add Appointment </div>
                                </div>
                        </div>
                        <br />
                        <div class="rsAdvContentWrapper1">
                            <div class="rsAdvOptionsScroll1">
                                <div class="rsAdvOptions1">
                                    <div class="rsAdvBasicControls1">
                                        <div class="rsAdvOptionsPanel1">
                                            <table width="90%">
                                                <tr>
                                                    <td align="right" width="135px">Appointment Name:</td>
                                                    <td>
                                                         <asp:TextBox runat="server" ID="SubjectTextBox" Width="90%" CssClass="txt"></asp:TextBox>
                                                          <br />
                                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="SubjectTextBox" ErrorMessage="Thông tin cần nhập"></asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                      <td align="right"> Begin date
                                                      </td>
                                                      <td>
                                                          <telerik:RadDateTimePicker ID="StartInput" runat="server">
                                                             <Calendar UseRowHeadersAsSelectors="false" UseColumnHeadersAsSelectors="false" ViewSelectorText="x" ></Calendar>
                                                             <TimeView CellSpacing="-1" Columns="2" RenderDirection="Vertical"></TimeView>
                                                             <TimePopupButton ImageUrl="" HoverImageUrl="" />
                                                             <DatePopupButton ImageUrl="" HoverImageUrl="" />
                                                             <DateInput DisplayDateFormat="MM/dd/yyyy HH:mm:ss" DateFormat="MM/dd/yyyy HH:mm:ss"></DateInput>

                                                          </telerik:RadDateTimePicker>
                                                      </td>
                                                     
                                                </tr>
                                                <tr>
                                                     <td align="right"> End date
                                                     </td>
                                                     <td>
                                                         <telerik:RadDateTimePicker ID="EndInput" runat="server">
                                                             <Calendar ID="Calendar1" runat="server" UseColumnHeadersAsSelectors="false" UseRowHeadersAsSelectors="false" ViewSelectorText="x"></Calendar>
                                                             <TimeView ID="TimeView1" runat="server" CellSpacing="-1" Columns="2" RenderDirection="Vertical"></TimeView>
                                                             <TimePopupButton ImageUrl="" HoverImageUrl="" />
                                                             <DatePopupButton ImageUrl="" HoverImageUrl="" />
                                                             <DateInput DisplayDateFormat="MM/dd/yyyy HH:mm:ss" DateFormat="MM/dd/yyyy HH:mm:ss" runat="server" ID="dateStart"></DateInput>
                                                             
                                                            
                                                         </telerik:RadDateTimePicker>
                                                     </td>
                                                </tr>
                                                 <tr>
                                               <td> Description
                                               </td>
                                               <td>
                                                     <telerik:RadTextBox ID="txtDescription" runat="server" CssClass="riTextBox riFocused" BorderColor="#C3D9F9" BorderStyle="Solid" BorderWidth="1px" Columns="150"  TextMode="MultiLine">

                                                    </telerik:RadTextBox>
                                               </td>
                                            </tr>
                                                 <tr>
                                                    <td> Link
                                                    </td>
                                                    <td>
                                                        <telerik:RadTextBox ID="txtLink" runat="server" CssClass="riTextBox riFocused" BorderColor="#C3D9F9" BorderStyle="Solid" BorderWidth="1px" Columns="150"  TextMode="MultiLine">

                                                        </telerik:RadTextBox>
                                                    </td>
                                                 </tr>
                                            <tr>
                                               <td>Percent</td>
                                               <td>
                                                   <telerik:RadNumericTextBox ID="txtPhanTram" runat="server" Type="Percent" ShowSpinButtons="true" MaxLength="3" MaxValue="100" BackColor="peachpuff" ForeColor="Blue">
                                                        <NumberFormat AllowRounding="True" KeepNotRoundedValue="False" DecimalDigits="0"></NumberFormat>
                                                   </telerik:RadNumericTextBox>
                                               </td>
                                            </tr>
                                            <tr>
                                               <td></td>
                                               <td >
                                                  <asp:Button  ID="InsertButton" runat="server" CommandName="Insert" Text="Save" /> &nbsp &nbsp
                                                   <asp:Button ID="InsertCancelButton" runat="server" Text="Cancel" CausesValidation="false" CommandName="Cancel" />
                                               </td>
                                            </tr>
                                            </table>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                    </AdvancedInsertTemplate>
                   <InlineInsertTemplate>
                       <div>
                          <table>
                              <tr>
                                 <td>
                                    <telerik:RadTextBox ID="txtName" runat="server" EmptyMessage="Appointment Name" 
                                      TextMode="MultiLine"  Columns="150" Rows="5" 
                                       >
                                     </telerik:RadTextBox>
                                 </td>
                                  
                              </tr>
                              <tr>
                                 <td>
                                      <div class="rsEditOptions">
                                             <asp:LinkButton ID="btnSave" runat="server" CommandName="Insert" Text="Save" class="rsAptEditConfirm" />
                                            <asp:LinkButton ID="btnCancel" runat="server" CommandName="Cancel" Text="Cancel"
                                               class="rsAptEditCancel" />
                                             <asp:LinkButton ID="btnOptions" runat="server" CommandName="More" Text="Options" class="rsAptEditMore" />
                                       </div>
                                 </td>
                              </tr>
                          </table>
                       </div>
                   </InlineInsertTemplate>
             </telerik:RadScheduler>
                  <input id="HiddenInputAppointmentInfo" name="HiddenInputAppointmentInfo" type="hidden"
                    runat="server" />
                  <telerik:RadToolTip ID="RadToolTip1" runat="server" RelativeTo="Element" Position="BottomCenter"
                AutoCloseDelay="0" ShowEvent="FromCode" Width="250px">
                <div id="contentContainer">
                    <div id="pdates">
                    </div>
                    <div id="pdatee">
                    </div>
                    <div id="Subject">
                    </div>
                  
                </div>
            </telerik:RadToolTip>
         
                 <asp:HiddenField ID="HiddenField1" runat="server" /> 
                  <script type="text/javascript">
                      function OnValueChanged(sender) {
                          var txbValue = document.getElementById("HiddenField1");
                          txbValue.value = sender.get_editValue();
                      }
                   </script> 
         </div>
                                 
    </div>
  
     <asp:HiddenField runat="server" ID="hdf1" />
             <script type="text/javascript">
                 function OnClientTimeSlotClick(sender, eventArgs) {
                     var Messages = $get('<%=hdf1.ClientID%>');
                     Messages.value = eventArgs.get_time().format('yyyy/MM/dd hh:mm:ss');
                 }
                 function onTimeSlotContextMenu(sender, eventArgs) {
                     var Messages = $get('<%=hdf1.ClientID%>');
                     Messages.value = eventArgs.get_time().format('yyyy/MM/dd hh:mm:ss');
                     eventArgs.get_domEvent().preventDefault();
                 }
            </script>
                     </div>
                 </div>
              
                 <div  style="height: 700px; background: #ddd; display: table-cell; width: 20%; float:left;">
                        
                       
                     <div class="demo-settings1">
                       

                           <div class="divTree" style="border:Red;color:Blue; overflow-y:auto">
                              <p>My Job</p>
                               <telerik:RadTreeView ID="RadTreeView1" runat="server" EnableDragAndDrop="true" ForeColor="Blue" OnClientNodeDropping="nodeDropping"></telerik:RadTreeView>
                         </div>
                         <div>
                             <p>Job Share </p>
                                <div>
                                    <table>
                                           <tr>
                                             <td>
                                                 User Name
                                             </td>
                
                                             <td>
                                                 <asp:DropDownList ID="DropDownUserName" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownUserName_SelectedIndexChanged"></asp:DropDownList>
                                                 <asp:Button ID="btnQuery" runat="server"  BackColor="#F0CCFF"  ForeColor="Blue" Text="Query" OnClick="btnQuery_Click" />
                                                 
                                             </td>
                                         </tr>
                                    </table>
                                </div>
                             <telerik:RadTreeView ID="RadTreeView2" runat="server" EnableDragAndDrop="true" ForeColor="Blue" OnClientNodeDropping="nodeDropping"></telerik:RadTreeView>
                         </div>
                     </div>
                 </div>
               <div style="display:none">
                     <div id="divDanhSachProduct" style="overflow:auto; max-height:500px" >
               
                   </div>
                </div>
             </div>
      
     

</asp:Content>
