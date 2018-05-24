<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMater/MasterPage.Master" AutoEventWireup="true" CodeBehind="pageMain3.aspx.cs" Inherits="iOffice.presentationLayer.pageMain3" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 
    <link href="../Style/formatmenu.css" rel="stylesheet" />
    <script src="../Scripts/jquery-1.3.2.min.js"></script>
    <script src="../Scripts/dropdown.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <script src='<%#ResolveClientUrl("~/Scripts/jquery.min.js") %>' type="text/javascript"></script>


      <script type="text/javascript" id="telerikClientEvents1">
          //<![CDATA[

          function RadScheduler1_TimeSlotContextMenu(sender, args) {
              //Add JavaScript handler code here0
          }
          //]]>

</script> 
     <telerik:RadStyleSheetManager ID="RadStyleSheetManager1" runat="server">
     </telerik:RadStyleSheetManager>
     <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
         <Scripts>
             <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.Core.js">
             </asp:ScriptReference>
             <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Tel
                 erik.Web.UI.Common.jQuery.js">
             </asp:ScriptReference>
             <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQueryInclude.js">
             </asp:ScriptReference>
         </Scripts>
     </telerik:RadScriptManager>
     <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" OnAjaxRequest="RadAjaxManager1_AjaxRequest">

           <AjaxSettings>
             <telerik:AjaxSetting AjaxControlID="Panel1">
                <UpdatedControls>
                   <telerik:AjaxUpdatedControl ControlID="RadScheduler1" LoadingPanelID="RadAjaxLoadingPanel2" />
                    <telerik:AjaxUpdatedControl ControlID="ConfiguratorPanel1" LoadingPanelID="RadAjaxLoadingPanel1"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="RadGrid1" LoadingPanelID="gridLoadingPanel"></telerik:AjaxUpdatedControl>
                </UpdatedControls>
             </telerik:AjaxSetting>
             
          </AjaxSettings>
         
             
        
     </telerik:RadAjaxManager>
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Skin="Default"></telerik:RadAjaxLoadingPanel>
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel2" runat="server" Skin="Default"></telerik:RadAjaxLoadingPanel>
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

       <div  style="height: 25px; background: #cecece; width:100%;  padding: 7px 7px 7px 7px;border: 1px solid #cecece; text-align:center;">
    

        
           <div id="wrapper">

               <ul id="nav" style="text-align:left">
                    
                   <li><a href="#">Web</a>
                       <ul>
                           <li>
                               <asp:LinkButton ID="LinkProvider" runat="server" onclick="LinkProvider_Click"> Web Portal Vender</asp:LinkButton>
                           </li>
                           <li>
                                <asp:LinkButton ID="Link_WebErp" runat="server" onclick="LinkWebErp_Click"> Web_Erp</asp:LinkButton>
                           </li>
                            <li>
                                <asp:LinkButton ID="LinkImportData" runat="server" onclick="LinkImportData_Click">Import BOM Usage</asp:LinkButton>
                           </li>
                            <li>
                                <asp:LinkButton ID="LinkKswiss" runat="server" onclick="LinkKswiss_Click"> ImportData for Kswiss</asp:LinkButton>
                           </li>
                            <li>
                                <asp:LinkButton ID="LinkPMBOM" runat="server" onclick="LinkPMBOM_Click">Import Data for PM- BOM</asp:LinkButton>
                           </li>
                            <li>
                                <asp:LinkButton ID="LinkImportBOMTest" runat="server" onclick="LinkImportBOMTest_Click">PM-BOM - Test</asp:LinkButton>
                           </li>
                           <li>
                               <asp:LinkButton ID="Link8S" runat="server" OnClick="Link8S_Click">8 S</asp:LinkButton>
                           </li>
                           <li>
                               <asp:LinkButton ID="Link_HRM" runat="server" OnClick="Link_HRM_Click">HRM</asp:LinkButton>
                           </li>
                       </ul>
                   </li>
                   <li><a href="#">Setting PDN</a>
                       <ul>
                           <li>
                               <asp:LinkButton ID="linkQuenMatKhau" runat="server" 
                            onclick="linkQuenMatKhau_Click">Forgot Password Aprroval</asp:LinkButton>
                           </li>
                           <li>
                               <asp:LinkButton ID="linkChangPass" runat="server" 
                             onclick="linkChangPass_Click"  >Change Password Aprroval</asp:LinkButton>
                           </li>
                           <li>
                               <asp:LinkButton ID="LinkChangPassLogin" runat="server" onclick="LinkChangPassLogin_Click" 
                                 >Change Password Login</asp:LinkButton>
                           </li>
                           <li>
                                <asp:LinkButton ID="linkChuKy" runat="server" onclick="linkChuKy_Click">Change Signature</asp:LinkButton>
                           </li>
                       </ul>
                   </li>
                   <li> <a href="#"> Project</a>
                       <ul>
                           <li>
                                <asp:LinkButton ID="linkProject" runat="server" onclick="linkProject_Click"><img src="../Images/project.png" height="15px" width="15px" />My Project</asp:LinkButton>
                           </li>
                           <li>
                                <asp:LinkButton ID="LinkGroup" runat="server" onclick="LinkGroup_Click"><img src="../Images/User-group.png" /> Group</asp:LinkButton>
                           </li>
                           <li>
                                <asp:LinkButton ID="LinkExportJob" runat="server" onclick="LinkExportJob_Click"><img src="../Content/menu/calender.png" /> Report Job</asp:LinkButton>
                           </li>
                            <li>
                                 <asp:LinkButton ID="LinkExportProject" runat="server" onclick="LinkExportProject_Click"><img src="../Content/menu/excel-export.png" /> Report Project</asp:LinkButton>
                           </li>
                       </ul>
                   </li>
                   <li><a href="#">Google</a>
                       <ul>
                           <li>
                               <asp:LinkButton ID="LinkMail" runat="server" onclick="LinkMail_Click">Google Mail</asp:LinkButton>
                           </li>
                            <li>
                                <asp:LinkButton ID="LinkTranslate" runat="server" onclick="LinkTranslate_Click">Google Translate</asp:LinkButton>
                           </li>
                            <li>
                                <asp:LinkButton ID="LinkMap" runat="server" onclick="LinkMap_Click">Google Map</asp:LinkButton>
                           </li>
                            <li>
                                 <asp:LinkButton ID="LinkDocument" runat="server" onclick="LinkDocument_Click">Google Document</asp:LinkButton>
                           </li>
                       </ul>
                   </li>
                   
               </ul>

           </div>

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
       
         
           
        
      
       </div>
   
     <div  style="border: 0px solid #cecece; padding: 7px 7px 7px 7px; width: 100%;">
       

       
                 <div  style=" display: table-cell;  width:80%; float:right;">
                    
                     <div  style="height:150px; border: 1px solid red; ">

                         <telerik:RadAjaxLoadingPanel runat="server" ID="gridLoadingPanel"></telerik:RadAjaxLoadingPanel>
                         <telerik:RadGrid ID="RadGrid1" runat="server" Height="150px"   OnItemCreated="RadGrid1_ItemCreated" Skin="Forest" ToolTip="No message to display" OnDeleteCommand="RadGrid1_DeleteCommand" OnItemDataBound="RadGrid1_ItemDataBound">
                             <MasterTableView AutoGenerateColumns="false" DataKeyNames="USID" ClientDataKeyNames="USID" NoMasterRecordsText="No message to display." Width="100%">
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
                                    <telerik:GridTemplateColumn Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblUserID" runat="server" Text='<%#Eval("Userid") %>'></asp:Label>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                       <telerik:GridTemplateColumn Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblUSID" runat="server" Text='<%#Eval("USID") %>'></asp:Label>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridBoundColumn DataField="GSBH" HeaderText="" Visible="false" SortExpression="GSBH" UniqueName="GSBH"></telerik:GridBoundColumn>
                                    
                                     <telerik:GridBoundColumn DataField="UGno" HeaderText="" Visible="false" SortExpression="UGno" UniqueName="UGno"></telerik:GridBoundColumn>
                                     <telerik:GridBoundColumn DataField="UStitle" HeaderText="Title"  SortExpression="UStitle" HeaderStyle-HorizontalAlign="Center" UniqueName="UStitle"></telerik:GridBoundColumn>
                                    
                                     <telerik:GridTemplateColumn HeaderText="From Date">
                                         <ItemTemplate>
                                              <asp:Label ID="lblsdate" runat="server" Text='<%#Eval("sdate","{0:yyyy/MM/dd}") %>'></asp:Label>
                                         </ItemTemplate>
                                         <ItemStyle HorizontalAlign="Center" Width="10%" />
                                            <HeaderStyle HorizontalAlign="Center" />
                                     </telerik:GridTemplateColumn>
                                     <telerik:GridTemplateColumn HeaderText="TO Date">
                                         <ItemTemplate>
                                              <asp:Label ID="lbledate" runat="server" Text='<%#Eval("edate","{0:yyyy/MM/dd}") %>'></asp:Label>
                                         </ItemTemplate>
                                          <ItemStyle HorizontalAlign="Center" Width="10%" />
                                         <HeaderStyle HorizontalAlign="Center" />
                                     </telerik:GridTemplateColumn>
                                 </Columns>
                             </MasterTableView>
                             <ClientSettings>
                                 <Selecting AllowRowSelect="true" />
                                <%-- <ClientEvents OnRowClick="RowDblClick" />--%>
                                 <Scrolling AllowScroll="true" UseStaticHeaders="true" SaveScrollPosition="true" />
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
                    OnClientAppointmentResizing="RadScheduler1_TimeSlotContextMenu"
                    WeekView-GroupingDirection="Horizontal" 
                    onclienttimeslotcontextmenu="RadScheduler1_TimeSlotContextMenu" 
                  onformcreated="RadScheduler1_FormCreated" 
                  onappointmentdelete="RadScheduler1_AppointmentDelete" 
                  Width="100%"
                    OnClientFormCreated="formCreated" EnableDescriptionField="True" 
                
                 onappointmentinsert="RadScheduler1_AppointmentInsert" Height="600px" OnAppointmentDataBound="RadScheduler1_AppointmentDataBound" CustomAttributeNames="jobpercent" DayEndTime="17:00:00" OnDataBound="RadScheduler1_DataBound" EditFormDateFormat="MM/dd/yyyy" OnAppointmentCreated="RadScheduler1_AppointmentCreated" OnAppointmentUpdate="RadScheduler1_AppointmentUpdate" Skin="Office2007" DayStartTime="07:30:00"

                 >
                     <Localization AdvancedAllDayEvent="All Day" AdvancedCalendarCancel="Cancel"
                     AdvancedClose="Close" AdvancedDaily="Daily" AdvancedDay="Day"
                      AdvancedDescription="Description" AdvancedEditAppointment="Edit Job"
                      AllDay="All Day" Cancel="Cancel" ConfirmCancel="Cancel"
                       ConfirmDeleteText="Do you want to delete?" ConfirmDeleteTitle="Confirm Delete"  ConfirmOK="OK"
                       ContextMenuAddAppointment="Add Job" ContextMenuDelete="Delete"
                       ContextMenuEdit="Edit" HeaderDay="Day" HeaderMonth="Month"
                       HeaderNextDay="Next Day" HeaderPrevDay="Preview day" 
                       HeaderTimeline="Time Line" HeaderToday="Today" HeaderWeek="Week"
                       Save="Save" ShowAdvancedForm="Options" AdvancedDone="Done"
                       AdvancedNewAppointment="New Job" ContextMenuGoToToday="Go To Today"  Show24Hours="Show 24 Hours" 
                       ShowBusinessHours="Show Business Hours" ShowMore="Show More"
                     
                    />

                    <AdvancedForm  DateFormat="MM/dd/yyyy" />
                    <TimeSlotContextMenuSettings EnableDefault="true" />
                    <AppointmentContextMenuSettings EnableDefault="true" />
                    <MonthView GroupingDirection="Vertical" />
                    <AdvancedEditTemplate>
                      <div class="rsAdvancedEdit1">
                          <div class="rsAdvInnerTitle1" style="margin:10px"> Edit Job </div>
                          <br />
                      </div>
                      <div class="rsAdvContentWrapper1">
                          <div class="rsAdvOptionsScroll1">
                             <div class="rsAdvOptions">
                                <div class="rsAdvBasicControls1" style="width:100%">
                                    <div class="rsAdvOptionsPanel1" style="float:left;width:50%">
                                        <table width="100%" style="margin:10px">
                                            <tr>
                                               <td >
                                                   Appointment Name
                                                   <br />
                                               </td>
                                               <td> 
                                                   <asp:HiddenField runat="server" ID="hdfID"  />
                                                   <asp:TextBox runat="server" ID="SubjectTextBox" Width="50%" CssClass="txt"></asp:TextBox>
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
                                                     <telerik:RadTextBox ID="txtDescription" runat="server" CssClass="riTextBox riFocused" Width="50%" BorderColor="#C3D9F9" BorderStyle="Solid" BorderWidth="1px" Columns="50"  TextMode="MultiLine">

                                                    </telerik:RadTextBox>
                                               </td>
                                            </tr>
                                            <tr>
                                                <td> Attact File  
                                                </td>
                                                
                                                <td class="button-wrap">
                                                 <asp:FileUpload ID="FileUpload1" runat="server" />&nbsp;
                                                   
                                                     <asp:Button ID="btnUpload" runat="server" BackColor="#F0CCFF"  ForeColor="Blue" CommandName="UploadFile" CssClass="button Up" Text="UpLoad"  />
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
                                            
                                           
                                        </table>
                                        <br />
                                        <div style="margin-left:40px" class="button-wrap">
                                            
                                                  <asp:Button  ID="UpdateButton" runat="server" BackColor="#F0CCFF"  ForeColor="Blue" CssClass="button save" CommandName="Update" Text="Save" /> &nbsp &nbsp
                                                   <asp:Button ID="UpdateCancelButton" runat="server" BackColor="#F0CCFF"  ForeColor="Blue" CssClass="button Cancel" Text="Cancel" CausesValidation="false" CommandName="Cancel" />
                                              
                                        </div>
                                        <br />
                                        <p style="margin-left:20px"> Attact File</p>
                                        <div id="divAtt" runat="server" style="margin-left:10px">
                                              <asp:GridView ID="GridView2" Width="600px" runat="server"  ClientIDMode="Static" AutoGenerateColumns="False" DataKeyNames="FilePath" OnSelectedIndexChanged="GridView2_SelectedIndexChanged1" OnRowDeleting="GridView2_RowDeleting"  BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px"  CellPadding="3" >
                                                 <Columns>

                                                   <asp:TemplateField Visible="false">
                                                       <ItemTemplate>
                                                           <asp:Label ID="lblID11" ClientIDMode="Static" runat="server" Text='<%#Eval("ID") %>'></asp:Label>
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
                                                     <asp:TemplateField HeaderText="Download" >
                                                         <ItemTemplate>
                           
                                                           <asp:LinkButton ID="linkDownLoad" runat="server" CommandName="Delete"><img src="../Content/Icon/download.png"  /> Download</asp:LinkButton>
                                                          </ItemTemplate>
                                                          <ItemStyle HorizontalAlign="Center" />
                                                         <HeaderStyle HorizontalAlign="Center" />
                                                     </asp:TemplateField>
                                                      <asp:TemplateField HeaderText="Delete">
                                                       <ItemTemplate>
                                                           <asp:LinkButton ID="linkDelete1" runat="server" CommandName="Select"   OnClientClick="return confirm('Are you sure?')"><img src="../Content/Icon/delete.png"  /> Delete</asp:LinkButton>
                                                       </ItemTemplate>
                      
                                                      <ItemStyle HorizontalAlign="Center" />
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
                                    <div style="width:50%; float:right; font-size:large" >
                                        
                                           <panel id="pndGrid" runat="server">
                                                 <div style="width:100%; float:left">
                                                     
                                                    <telerik:RadGrid ID="RadGrid2" Width="100%" runat="server" Skin="Forest" ToolTip="No project to display " OnItemDataBound="RadGrid2_ItemDataBound" >
                                                        <MasterTableView AutoGenerateColumns="false" DataKeyNames="jsysid" ClientDataKeyNames="jsysid">
                                                            <Columns>
                                                                <telerik:GridTemplateColumn HeaderText="System ID">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lbljsysid" runat="server" Text='<%#Eval("jsysid") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Center" Width="30%" />
                                                                </telerik:GridTemplateColumn>
                                                                 <telerik:GridTemplateColumn HeaderText="System Name">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblsysname" runat="server" Text='<%#Eval("sysname") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                      <ItemStyle Width="70%" />
                                                                </telerik:GridTemplateColumn>
                                                            </Columns>
                                                        </MasterTableView>
                                                    </telerik:RadGrid>
                                                </div>
                                                 <div style="float:left; width:100%">
                                                    <telerik:RadGrid ID="RadGrid3"  runat="server" Width="100%" Skin="Office2007" OnItemDataBound="RadGrid3_ItemDataBound">
                                                        <MasterTableView AutoGenerateColumns="false" DataKeyNames="jsubid" BackColor="#ccffcc" AlternatingItemStyle-ForeColor="#0000ff" ClientDataKeyNames="jsubid">
                                                            <Columns>
                                                                <telerik:GridTemplateColumn Visible="false">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lbljsysid" runat="server" Text='<%#Eval("jsysid") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                  

                                                                </telerik:GridTemplateColumn>
                                                                <telerik:GridTemplateColumn HeaderText="Sub System ID">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lbljsubid" runat="server" Text='<%#Eval("jsubid") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                       <ItemStyle Width="30%" HorizontalAlign="Center" />
                                                                </telerik:GridTemplateColumn>
                                                                <telerik:GridTemplateColumn  HeaderText="Sub System Name">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lbljsubname" runat="server" Text='<%#Eval("jsubname") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                      <ItemStyle Width="70%" />
                                                                </telerik:GridTemplateColumn>
                                                            </Columns>
                                                        </MasterTableView>
                                                    </telerik:RadGrid>
                                                 </div>
                                               <div style="float:left;width:100%">
                                                   <telerik:RadGrid ID="RadGrid4" runat="server" Width="100%" Skin="Sunset" OnItemDataBound="RadGrid4_ItemDataBound">
                                                       <MasterTableView AutoGenerateColumns="false" DataKeyNames="jobid" ClientDataKeyNames="jobid">
                                                           <Columns>
                                                               <telerik:GridTemplateColumn Visible="false">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lbljsysid" runat="server" Text='<%#Eval("jsysid") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                  

                                                                </telerik:GridTemplateColumn>
                                                                <telerik:GridTemplateColumn HeaderText="Sub System ID" Visible="false">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lbljsubid" runat="server" Text='<%#Eval("jsubid") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                     
                                                                </telerik:GridTemplateColumn>
                                                               <telerik:GridTemplateColumn HeaderText="Job ID">
                                                                   <ItemTemplate>
                                                                          <asp:Label ID="lbljobid" runat="server" Text='<%#Eval("jobid") %>'></asp:Label>
                                                                   </ItemTemplate>
                                                                    <ItemStyle Width="30%" HorizontalAlign="Center" />
                                                                </telerik:GridTemplateColumn>
                                                               <telerik:GridTemplateColumn HeaderText="Job Name">
                                                                   <ItemTemplate>
                                                                       <asp:Label ID="lbljobname" runat="server" Text='<%#Eval("jobname") %>'></asp:Label>
                                                                   </ItemTemplate>
                                                                   <ItemStyle Width="70%" />
                                                               </telerik:GridTemplateColumn>
                                                           </Columns>
                                                       </MasterTableView>
                                                   </telerik:RadGrid>
                                               </div>
                                           </panel>
                                           
                                      
                                    </div>
                                </div>
                             </div>
                          </div>
                      </div>
                    </AdvancedEditTemplate>
                    <AdvancedInsertTemplate>
                        <div class="rsAdvancedEdit1">
                             <div class="rsAdvTitle1">
                                        <div class="rsAdvInnerTitle1" style="margin:10px"> Add Job </div>
                                </div>
                        </div>
                        <br />
                        <div class="rsAdvContentWrapper1">
                            <div class="rsAdvOptionsScroll1">
                                <div class="rsAdvOptions1">
                                    <div class="rsAdvBasicControls1">
                                        <div class="rsAdvOptionsPanel1">
                                            <table width="90%" style="margin-left:10px">
                                                <tr>
                                                    <td >Job Name:</td>
                                                    <td>
                                                         <asp:TextBox runat="server" ID="SubjectTextBox" Width="90%" CssClass="txt"></asp:TextBox>
                                                          <br />
                                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="SubjectTextBox" ForeColor="Red" Text="(*)" ValidationGroup="groupThem" ErrorMessage="Thông tin cần nhập"></asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                      <td > Begin date
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
                                                     <td > End date
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
                                                    <td> Attact File  
                                                    </td>
                                                   
                                                    <td class="button-wrap"> <asp:FileUpload ID="FileUpload12" runat="server" />&nbsp;
                                                         <asp:Button ID="btnUpload12" runat="server" BackColor="#F0CCFF"  ForeColor="Blue" CommandName="UploadFile12" CssClass="button Up" Text="UpLoad"  /></td>
                                                </tr>
                                            <tr>
                                               <td>Percent</td>
                                               <td>
                                                   <telerik:RadNumericTextBox ID="txtPhanTram" runat="server" Type="Percent" ShowSpinButtons="true" MaxLength="3" MaxValue="100" BackColor="peachpuff" ForeColor="Blue">
                                                        <NumberFormat AllowRounding="True" KeepNotRoundedValue="False" DecimalDigits="0"></NumberFormat>
                                                   </telerik:RadNumericTextBox>
                                               </td>
                                            </tr>
                                           
                                            </table>
                                             <div  class="button-wrap" style="margin-left:40px">
                                                  <asp:Button  ID="InsertButton" BackColor="#F0CCFF"  ForeColor="Blue" runat="server" CssClass="button save" ValidationGroup="groupThem" CommandName="Insert" Text="Save" /> &nbsp &nbsp
                                                   <asp:Button ID="InsertCancelButton" runat="server" BackColor="#F0CCFF"  ForeColor="Blue" CssClass="button Cancel" Text="Cancel" CausesValidation="false" CommandName="Cancel" />
                                               </div>
                                                 <p style="margin-left:20px"> Attact File</p>
                                            <panel id="divTemp" runat="server">
                                                <asp:GridView ID="GridView1" runat="server" Width="600px" ClientIDMode="Static"  AutoGenerateColumns="False" BackColor="White" BorderColor="#CC9966" BorderWidth="1px" CellPadding="4" BorderStyle="None" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" >
                                               <Columns>
                                                    <asp:TemplateField HeaderText="ID" Visible="false">
                                                       <ItemTemplate>
                                                           <asp:Label ID="lblID" runat="server" Text='<%#Eval("ID") %>'></asp:Label>
                                                       </ItemTemplate>
                     
                                                   </asp:TemplateField>
                                                   <asp:TemplateField HeaderText="File Name">
                                                       <ItemTemplate>
                                                           <asp:Label ID="lblFileName" runat="server" Text='<%#Eval("FileName") %>'></asp:Label>
                                                       </ItemTemplate>
                                                       <ItemStyle Width="80%" />
                                                   </asp:TemplateField>
                                                   <asp:TemplateField HeaderText="Delete">
                                                       <ItemTemplate>
                                                           <asp:LinkButton ID="linkDelete" runat="server" CommandName="Select" OnClientClick="return confirm('Are you sure?')"><img src="../Content/Icon/delete.png"  /> Delete</asp:LinkButton>
                                                       </ItemTemplate>
                                                       <ItemStyle HorizontalAlign="Center" />
                                                   </asp:TemplateField>
                                               </Columns>
                                               <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
                                               <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
                                               <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
                                               <RowStyle BackColor="White" ForeColor="#330099" />
                                               <SelectedRowStyle BackColor="#FFCC66" ForeColor="#663399" Font-Bold="True" />
                                               <SortedAscendingCellStyle BackColor="#FEFCEB" />
                                               <SortedAscendingHeaderStyle BackColor="#AF0101" />
                                               <SortedDescendingCellStyle BackColor="#F6F0C0" />
                                               <SortedDescendingHeaderStyle BackColor="#7E0000" />
                                           </asp:GridView>
                                           </panel>
                                         
                                        </div>
                                        <p style="margin-left:20px">
                                            <asp:Label ID="lblThongBao" runat="server" ForeColor="Red" Text=""></asp:Label></p>
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
                                    <telerik:RadTextBox ID="txtName" runat="server" EmptyMessage="Job Name" 
                                      TextMode="MultiLine"  Columns="150" Rows="5" 
                                       >
                                     </telerik:RadTextBox>
                                 </td>
                                  
                              </tr>
                              <tr>
                                 <td>
                                      <div class="rsEditOptions">
                                          <div class="button-wrap">
                                             <asp:LinkButton ID="btnSave" runat="server" CssClass="button save" BackColor="#F0CCFF"  ForeColor="Blue" CommandName="Insert" Text="Save" class="rsAptEditConfirm" />
                                            <asp:LinkButton ID="btnCancel" runat="server" CssClass="button Cancel" BackColor="#F0CCFF"  ForeColor="Blue" CommandName="Cancel" Text="Cancel"
                                               class="rsAptEditCancel" />
                                             <asp:LinkButton ID="btnOptions" runat="server" CssClass="button Detail" BackColor="#F0CCFF"  ForeColor="Blue" CommandName="More" Text="Options" class="rsAptEditMore" />
                                          </div>
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
              
                 <div  style=" background: #e2edec;  display: table-cell; width: 20%; float:left;">
                        
                          
                              <p>My Job</p>
                               <asp:UpdatePanel ID="pnnMyJob" runat="server" ClientIDMode="Static">
                                   <ContentTemplate>
                                        <table>
                                           <tr>
                                             <td>
                                                 User Name
                                             </td>
                
                                             <td>
                                                 <asp:DropDownList ID="DropDownUserName" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownUserName_SelectedIndexChanged" style="width: 77px"></asp:DropDownList>
                                                 <%--<asp:Button ID="btnQuery" runat="server"  BackColor="#F0CCFF"  ForeColor="Blue" Text="Query" OnClick="btnQuery_Click" />--%>
                                                 
                                             </td>
                                         </tr>
                                    </table>
                                
                                     <telerik:RadTreeView ID="RadTreeView1" runat="server" EnableDragAndDrop="true"  ForeColor="Blue" Height="500px" OnClientNodeDropping="nodeDropping" Skin="Hay" OnNodeClick="RadTreeView1_NodeClick"></telerik:RadTreeView>
                               </ContentTemplate>
                                   <Triggers>
                                       <asp:AsyncPostBackTrigger ControlID="RadTreeView1" />
                                   </Triggers>
                               </asp:UpdatePanel>
                       
                    
                     
                 </div>
                    <div style="display:none">
                   <p>
                       <asp:Label ID="lblABC" runat="server" Text="Label"></asp:Label>
                      <asp:TextBox ID="txtjsubid" runat="server"></asp:TextBox>
                       <asp:TextBox ID="txtjsysid" runat="server"></asp:TextBox>
                   </p>
                     <div id="divDanhSachProduct" style="overflow:auto; max-height:500px" >
               
                   </div>
                </div>
         
             </div>
   
</asp:Content>
