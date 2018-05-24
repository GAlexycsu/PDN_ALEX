<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMater/MasterPage2.Master" AutoEventWireup="true" CodeBehind="ProjectShareByUser.aspx.cs" Inherits="iOffice.presentationLayer.ProjectShareByUser" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Style/StyleSheet1.css" rel="stylesheet" />
    <link href="../Content/Site.css" rel="stylesheet" />
           <script type="text/javascript" id="telerikClientEvents1">
               //<![CDATA[

               function RadScheduler1_TimeSlotContextMenu(sender, args) {
                   //Add JavaScript handler code here
               }
               //]]>

</script>  
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
            <AjaxSettings>
             <telerik:AjaxSetting AjaxControlID="Panel1">
                <UpdatedControls>
                   <telerik:AjaxUpdatedControl ControlID="Panel1" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
             </telerik:AjaxSetting>

          </AjaxSettings>
    </telerik:RadAjaxManager>
    <br />
    <br />

    <div>
        <table>
               <tr>
                 <td>
                     User Name
                 </td>
                
                 <td class="button-wrap">
                     <asp:DropDownList ID="DropDownUserName" runat="server" AutoPostBack="True"></asp:DropDownList>
                     <asp:Button ID="btnQuery" runat="server"  CssClass="button find"  BackColor="#F0CCFF"  ForeColor="Blue" Text="Query" OnClick="btnQuery_Click" Width="86px" />
                     <asp:Button ID="btnView" runat="server"  CssClass="button View" BackColor="#F0CCFF"  ForeColor="Blue" Text="View Detail" OnClick="btnView_Click" Width="141px" />
                 </td>
             </tr>
        </table>
    </div>
    <br />
    <br />
      <div class="form">
              <telerik:RadScheduler ID="RadScheduler1" runat="server" 
                    ResolvedRenderMode="Classic" DataDescriptionField="wkmemo" 
                    DataEndField="pdatee" DataKeyField="ID" DataStartField="pdates" 
                    DataSubjectField="Subject" 
                    WeekView-GroupingDirection="Horizontal" 
                    onclienttimeslotcontextmenu="RadScheduler1_TimeSlotContextMenu" 
                  onformcreated="RadScheduler1_FormCreated" Height="575px"
                  Width="98%" AllowDelete="False" AllowInsert="False" OnAppointmentDataBound="RadScheduler1_AppointmentDataBound">
                    <Localization AdvancedAllDayEvent="All Day" AdvancedCalendarCancel="Cancel"
                     AdvancedClose="Close" AdvancedDaily="Daily" AdvancedDay="Day"
                      AdvancedDescription="Description" AdvancedEditAppointment="Edit Appointment"
                      AllDay="All Day" 
                       ConfirmDeleteText="Do you want to delete?" ConfirmDeleteTitle="Confirm Delete"  ConfirmOK="OK"
                       ContextMenuDelete="Delete"
                       ContextMenuEdit="Edit" HeaderDay="Day" HeaderMonth="Month"
                       HeaderNextDay="Next Day" HeaderPrevDay="Preview day" 
                       HeaderTimeline="Time Line" HeaderToday="Today" HeaderWeek="Week"
                      AdvancedDone="Done"
                      ContextMenuGoToToday="Go To Today" Show24Hours="Show 24 Hours" 
                       ShowBusinessHours="Show Business Hours" ShowMore="Show More"
                    />
                    <AdvancedForm DateFormat="MM/dd/yyyy" />
                    <TimeSlotContextMenuSettings EnableDefault="true" />
                    <AppointmentContextMenuSettings EnableDefault="false" />
                    <MonthView GroupingDirection="Vertical" />
                    <AdvancedEditTemplate>
                      <div class="rsAdvancedEdit">
                          <div class="rsAdvInnerTitle"> Edit Appointment </div>
                          <br />
                      </div>
                      <div class="rsAdvContentWrapper">
                          <div class="rsAdvOptionsScroll">
                             <div class="rsAdvOptions">
                                <div class="rsAdvBasicControls">
                                    <div class="rsAdvOptionsPanel">
                                        <table width="100%">
                                            <tr>
                                               <td align="right" width="135px">
                                                   Appointment Name
                                                   <br />
                                               </td>
                                               <td> 
                                                   <asp:HiddenField runat="server" ID="hdfID" />
                                                   <asp:TextBox runat="server" ID="SubjectTextBox" ReadOnly="true" Width="100%" CssClass="txt"></asp:TextBox>
                                                  
                                               </td>
                                            </tr>
                                            <tr>
                                               <td > 
                                                  Begin date
                                               </td>
                                               <td>
                                                   <telerik:RadDateTimePicker ID="StartInput" runat="server" DateInput-ReadOnly="true">
                                                    
                                                   </telerik:RadDateTimePicker>
                                                 
                                               </td>
                                               
                                            </tr>
                                            <tr>
                                               <td> End date
                                                  
                                               </td>
                                               <td>
                                                   <telerik:RadDateTimePicker ID="EndInput" runat="server" DateInput-ReadOnly="true">
                                                     
                                                    

                                                   </telerik:RadDateTimePicker>
                                                  
                                               </td>
                                            </tr>
                                            <tr>
                                               <td> Description
                                               </td>
                                               <td>
                                                     <telerik:RadTextBox ID="txtDescription" runat="server" CssClass="riTextBox riFocused" ReadOnly="true" BorderColor="#C3D9F9" BorderStyle="Solid" BorderWidth="1px" Columns="150"  TextMode="MultiLine">

                                                    </telerik:RadTextBox>
                                               </td>
                                            </tr>
                                            <tr>
                                                <td> Link
                                                </td>
                                                <td>
                                                    <telerik:RadTextBox ID="txtLink" runat="server" CssClass="riTextBox riFocused" ReadOnly="true" BorderColor="#C3D9F9" BorderStyle="Solid" BorderWidth="1px" Columns="150"  TextMode="MultiLine">

                                                    </telerik:RadTextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                               <td>Percent</td>
                                               <td>
                                                   <telerik:RadNumericTextBox ID="txtPhanTram" runat="server"  Type="Percent" ShowSpinButtons="true" ReadOnly="true"  BackColor="peachpuff" ForeColor="Blue" >
                                                      <NumberFormat AllowRounding="True" KeepNotRoundedValue="False"  DecimalDigits="0"></NumberFormat>
                                                   </telerik:RadNumericTextBox>
                                               </td>
                                            </tr>
                                           <%-- <tr>
                                               <td></td>
                                               <td>
                                                  <asp:Button  ID="UpdateButton" runat="server" CommandName="Update" Text="Update" /> &nbsp &nbsp
                                                   <asp:Button ID="UpdateCancelButton" runat="server" Text="Cancel" CausesValidation="false" CommandName="Cancel" />
                                               </td>
                                            </tr>--%>
                                        </table>
                                    </div>
                                </div>
                             </div>
                          </div>
                      </div>
                    </AdvancedEditTemplate>
             
                </telerik:RadScheduler>

                 <asp:HiddenField ID="HiddenField1" runat="server" /> 
                  <script type="text/javascript">
                      function OnValueChanged(sender) {
                          var txbValue = document.getElementById("HiddenField1");
                          txbValue.value = sender.get_editValue();
                      }
                   </script> 
         </div>
             <asp:HiddenField runat="server" ID="hdf" />
             <script type="text/javascript">
                 function OnClientTimeSlotClick(sender, eventArgs) {
                     var Messages = $get('<%=hdf.ClientID%>');
                     Messages.value = eventArgs.get_time().format('yyyy/MM/dd hh:mm:ss');
                 }
                 function onTimeSlotContextMenu(sender, eventArgs) {
                     var Messages = $get('<%=hdf.ClientID%>');
                     Messages.value = eventArgs.get_time().format('yyyy/MM/dd hh:mm:ss');
                     eventArgs.get_domEvent().preventDefault();
                 }
            </script>    
    
</asp:Content>
