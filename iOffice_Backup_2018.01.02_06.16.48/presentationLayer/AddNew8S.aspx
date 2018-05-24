<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddNew8S.aspx.cs" Inherits="iOffice.presentationLayer.AddNew8S" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    
         <link href="../Content/Site.css" rel="stylesheet" />
    <link href="../Content/FormatDiv.css" rel="stylesheet" />
    <link href="../Style/jquery-ui-1.8.19.custom.css" rel="stylesheet" />
    <script src="../Scripts/jquery-1.9.1.js"></script>
    <script src="../Scripts/jquery-1.7.2.min.js"></script>
    <script src="../Scripts/jquery-ui-1.8.19.custom.min.js"></script>
    <script src="../Scripts/FormatextBox.js"></script>
    <script src="../Scripts/nhapso.js"></script>
    <script src="../Scripts/jquery.tooltip.min.js"></script>
    <script type="text/javascript">
        function InitializeToolTip() {
            $(".gridViewToolTip").tooltip({
                track: true,
                delay: 0,
                showURL: false,
                fade: 100,
                bodyHandler: function () {
                    return $($(this).next().html());
                },
                showURL: false
            });
        }
</script>
<script type="text/javascript">
    $(function () {
        InitializeToolTip();
    })
</script>
    <style type="text/css">
#tooltip {
position: fixed;
z-index: 15000;
border: 1px solid #111;
background-color: #FEFFFF;
padding: 5px;
opacity: 1.55;
}
#tooltip h3, #tooltip div { margin: 0; }
      
        .auto-style1 {
            height: 45px;
        }
      
    </style>
</head>
<body>
    <form id="form1" runat="server">
          <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
         <div>
        <div >
         
            
            <table >
                  <tr>
                        <td>
                            Date
                        </td>
                        <td>
                            <asp:TextBox ID="txtDate" runat="server"></asp:TextBox>
                        </td>
                  </tr>
                 <tr>
                         <td>
                             
                               <%=hasLanguege["lblDonVi"].ToString() %>
                         </td>
                         <td>
                             <asp:DropDownList ID="DropDownDonVi" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownDonVi_SelectedIndexChanged"></asp:DropDownList>
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="" ControlToValidate="txtDepartmentTemp" Text="(*)" ForeColor="Red" ValidationGroup="groupThem" ></asp:RequiredFieldValidator>
                         </td>
                        
                     </tr>
                <tr>
                    <td>
                        <%=hasLanguege["lblLoai8S"].ToString() %>
                    </td>
                     <td >
                      <asp:DropDownList ID="DropDown" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDown_SelectedIndexChanged" ></asp:DropDownList>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtTypeID" Text="(*)" ForeColor="Red" ValidationGroup="groupThem" ErrorMessage=""></asp:RequiredFieldValidator>
                          &nbsp;&nbsp;
                          <asp:Label ID="lblPercent" runat="server" Text=""></asp:Label>
                         <%--<asp:TextBox ID="txtPercent" runat="server"></asp:TextBox>--%>
                   </td>
                </tr>
               <tr>
                   <td class="auto-style1">
                      
                       <%=hasLanguege["lblMaSo"].ToString() %>
                   </td>
                     <td  class="button-wrap">
                       <asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList> 
                         
                    </td>
               </tr>
                <tr>
                    <td>
                          <%=hasLanguege["lblVanDe"].ToString() %>
                    </td>
               
                    <td >
                        <asp:Label ID="lblChiTiet" runat="server" Text="" ForeColor="#0066ff"></asp:Label>
                    </td>
              </tr>
               <tr>
                   <td>
                      
                         <%=hasLanguege["lblDiemChuan"].ToString() %>
                   </td>
                   <td>
                       <asp:TextBox ID="txtScoreMau" runat="server" BackColor="#CCFFFF" ForeColor="Blue" ReadOnly="True"></asp:TextBox>
                   </td>
               </tr>
                <tr  >
                    <td >
                       
                        Memo VN
                    </td>
                    <td >
                           <asp:TextBox ID="txtMemoVN" runat="server" MaxLength="200" Width="900px" Rows="4" ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ForeColor="Red" Text="(*)" ControlToValidate="txtMemoVN" ValidationGroup="groupThem" ErrorMessage=""></asp:RequiredFieldValidator>
                    </td>
                 
                </tr>
                <tr>
                    <td>
                        Memo TW
                    </td>
                    <td>
                        <asp:TextBox ID="txtMemoTW" runat="server" MaxLength="200" Width="900px" Rows="4"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Auditor Answer
                    </td>
                    <td>
                        <asp:TextBox ID="txtAnswer" runat="server" MaxLength="200" Width="900px" Rows="4"></asp:TextBox>
                    </td>
                </tr>
            </table>
          
          
          
        </div>
        

          

        <div style="width:100%">
            <div class="left" style="float:left; width:15%; text-align:left;" >
             <asp:Image ID="ImagePic1" runat="server"  class="gridViewToolTip"   Width="100px"   Height="100px" /> 
             
                <div class="tooltip" style="display:none">
                    <table>
                        <tr>
                            <td>
                                <asp:Image ID="ImagePic1Tooltrip" runat="server"  Width="600px" Height="500px" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblImagePic1" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                    </table>
                </div>
          
                  
             <asp:Image ID="ImagePic2" runat="server" Class="gridViewToolTip" Width="100px" Height="100px" />
                
         
               
                <div class="tooltip" style="display:none">
                    <table>
                        <tr>
                            <td>
                                <asp:Image ID="ImagePic2Tootrip" runat="server" Width="600px" Height="500px" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblImagePic2" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                    </table>
                </div>
                 
              
                <table>
                    <tr>
                        <td>  <%=hasLanguege["lblDiem"].ToString() %></td>
                        <td> <asp:TextBox ID="txtScore1" CssClass="groupOfTexbox" ClientIDMode="Static" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="" ControlToValidate="txtScore1" Text="(*)" ForeColor="Red" ValidationGroup="groupThem"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style2"><asp:CheckBox ID="CheckBox1" runat="server"   ToolTip="Ok then continues else 0 scrore" Checked="True"/> </td>
                        <td class="auto-style2">OK</td>
                    </tr>
                   
                </table>
                <table style="margin-left:50px">
                     <tr>
                        <td class="button-wrap"> <asp:Button ID="Button1" runat="server" Text="Save"  CssClass="button save"  BackColor="#F0CCFF"  ForeColor="Blue"  ValidationGroup="groupThem" OnClick="Button1_Click" /></td>
                         <td class="button-wrap">
                            <asp:Button ID="btnBack" runat="server" BackColor="#F0CCFF"  ForeColor="Blue"  CssClass="button back" Text="Back" OnClick="btnBack_Click" />
                        </td>
                        
                    </tr>
                </table>
            </div>
            <div class="left" style="float:left; width:80%; text-align:left;">
                <br />
                   <table>
                 <tr>
                    
                     <td class="auto-style1">

                              <asp:FileUpload ID="FileUpload1" runat="server" />
                       </td>
                       <td class="button-wrap">
                          <asp:Button ID="btnUpload1" runat="server" BackColor="#F0CCFF"  ForeColor="Blue" CssClass="button Up" Text="Upload File" OnClick="btnUpload1_Click" />
                       </td>
                 </tr>
                
             </table>
                <br />
                <br />
                <br />
                <table>
                     <tr>
                    
                      <td>
                              <asp:FileUpload ID="FileUpload2" runat="server" />
                       </td>
                       <td class="button-wrap">
                          <asp:Button ID="btnUpload2" runat="server" BackColor="#F0CCFF"  ForeColor="Blue" CssClass="button Up" Text="Upload File" OnClick="btnUpload2_Click" />
                       </td>
                       
                 </tr>
                </table>
            </div>
        </div>
   
    
        <div style="display:none">
            <asp:TextBox ID="txtIDTemp" runat="server" Text=""></asp:TextBox>
            <asp:Label ID="lblImageTem1" runat="server" Text=""></asp:Label>
              <asp:TextBox ID="txtDepartmentTemp" runat="server"></asp:TextBox>
            <asp:TextBox ID="txtTypeID" runat="server"></asp:TextBox>
             <asp:TextBox ID="txtFromDate" runat="server"></asp:TextBox>
            <asp:TextBox ID="txtToDate" runat="server"></asp:TextBox>
            <asp:TextBox ID="txtCQUserID0" runat="server"></asp:TextBox>
             <asp:TextBox ID="txtCQUserID1" runat="server"></asp:TextBox>
           
        </div>
     
    </div>  
    </form>
</body>
</html>
