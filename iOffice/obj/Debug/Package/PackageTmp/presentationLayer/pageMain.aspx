<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMater/MasterPage.Master" AutoEventWireup="true" CodeBehind="pageMain.aspx.cs" Inherits="iOffice.presentationLayer.pageMain" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Style/StyleSheet1.css" rel="stylesheet" />
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
       <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
            <AjaxSettings>
             <telerik:AjaxSetting AjaxControlID="Panel1">
                <UpdatedControls>
                   <telerik:AjaxUpdatedControl ControlID="RadScheduler1" LoadingPanelID="RadAjaxLoadingPanel1" />
                    <telerik:AjaxUpdatedControl ControlID="ConfiguratorPanel1" LoadingPanelID="RadAjaxLoadingPanel1"></telerik:AjaxUpdatedControl>
                </UpdatedControls>
             </telerik:AjaxSetting>
            <%-- <telerik:AjaxSetting AjaxControlID="RadScheduler1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadScheduler1" LoadingPanelID="RadAjaxLoadingPanel1"></telerik:AjaxUpdatedControl>
                </UpdatedControls>
            </telerik:AjaxSetting>--%>
          </AjaxSettings>
       </telerik:RadAjaxManager>
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
    </telerik:RadScriptBlock>
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Skin="Default"></telerik:RadAjaxLoadingPanel>

     <div style="border: 0px solid #cecece; padding: 7px 7px 7px 7px; width: 100%;">
                 <div  style=" display: table-cell;  width:80%; float:right;">
                    
                     <div style="height:150px; border: 1px solid red;">
                         News  or Message List to me</div>
                     <div style="height:500px; width:100%;">
                    
                        <div class="list wp-form" id="WorkAssignment">

     
                            
         <div class="form">
             <telerik:RadScheduler ID="RadScheduler1" runat="server"
                  ResolvedRenderMode="Classic" DataDescriptionField="wkmemo" 
                    DataEndField="pdatee" DataKeyField="ID" DataStartField="pdates" 
                    DataSubjectField="Subject" 
                   
                  
                    WeekView-GroupingDirection="Horizontal" 
                
                  Width="99%" 
                  OnClientAppointmentMoving="appointmentMoving"
                    OnClientFormCreated="formCreated" EnableDescriptionField="true" 
                  OverflowBehavior="Auto" 
                 Height="549px"
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
             </telerik:RadScheduler>
                 
             <telerik:RadToolTip ID="RadToolTip1" runat="server"></telerik:RadToolTip>
                  <input id="HiddenInputAppointmentInfo" name="HiddenInputAppointmentInfo" type="hidden"
                    runat="server" />
             
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
              
                 <div  style="height: 600px; background: #ddd; display: table-cell; width: 20%; float:left;">
                        
                       
                     <div class="demo-settings">
                       

                           <div class="divTree" style="border:Red;color:Blue">
                              <p>My Job</p>
                               <telerik:RadTreeView ID="RadTreeView1" runat="server" EnableDragAndDrop="true" ForeColor="Blue" OnClientNodeDropping="nodeDropping"></telerik:RadTreeView>
                         </div>
                     </div>
                 </div>
              
             </div>

</asp:Content>
