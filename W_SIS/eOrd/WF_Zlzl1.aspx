<%@ Page Language="C#" AutoEventWireup="true"   MasterPageFile="~/Gui/MasterPage/Site.master" CodeFile="WF_zlzl1.cs" Inherits="WF_Zlzl1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
     <link href="Styles/GridviewScrol1l.css" rel="stylesheet" type="text/css" />
    <script src="Scripts/jquery.min.js" type="text/javascript"></script>
    <script src="Scripts/jquery-ui.min.js" type="text/javascript"></script>
    <script src="Scripts/gridviewScroll.min.js" type="text/javascript"></script>
    <link href="Styles/Style_DonVi.css" rel="stylesheet" type="text/css" />
        <script type="text/javascript">
            $(document).ready(function () {
                gridviewScroll();
            });

            function gridviewScroll() {
                $('#<%=GridView1.ClientID%>').gridviewScroll({
                    width: '95%',
                    height: 500
                });
            }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <center>        
         <p style="font-family: Times New Roman, Arial; font-size:x-large;">        
             SysScreens   
         </p>
     </center>
     <div>
                <table style="width: 104px">
                    <tr>
                    <td> 
                       DBase 
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlDBase" runat="server"  AutoPostBack="true" Height="16px">
                        <asp:ListItem >LTY</asp:ListItem>
                        <asp:ListItem >LY_ERP</asp:ListItem>
                        </asp:DropDownList>  
                    </td>
                    <td>
                    ID
                    </td>
                    <td>
                       <asp:TextBox ID="txtID" runat="server" Width="60px"  ></asp:TextBox>
                    </td>
                </tr>                    
                <tr>
                <td>
                    FID
                </td>
                <td>
                    <asp:TextBox ID="txtFID" runat="server" Width="300px" ></asp:TextBox>
                </td>
                <td>
                    Fname
                </td>
                <td>
                    <asp:TextBox ID="txtFNA" runat="server" Width="300px" ></asp:TextBox>
                </td>
                </tr>
                <tr>
                <td>
                    memo
                </td>
                <td>
                    <asp:TextBox ID="txtSmemo" runat="server" Width="300px" ></asp:TextBox>
                </td>
                <td>
                    EN
                </td>
                <td>
                    <asp:TextBox ID="txtEN" runat="server" Width="300px" ></asp:TextBox>
                </td>
                </tr>
                <tr>
                <td>
                    VN
                </td>
               <td> 
                   <asp:TextBox ID="txtVN" runat="server" Width="300px"  ></asp:TextBox>
               </td>
             
                <td>
                    CH
                </td>
                <td>
                    <asp:TextBox ID="txtCH" runat="server" Width="300px" ></asp:TextBox>
                </td>
                </tr>
            </table>                
     </div>
         <div>
        <asp:Button runat="server" ID="btnLayDanhSach" Text="Query-Lấy Danh Sách" 
             onclick="btnLayDanhSach_Click" />
     &nbsp
     </div>
          <asp:UpdatePanel ID="pn1" runat="server">
       <ContentTemplate>
    <br />   
             <asp:GridView ID="GridView1" Width="100%" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" 
                onrowdeleting="GridView1_RowDeleting" 
                 onrowdatabound="GridView1_RowDataBound" style="margin-bottom: 0px" 
                 AllowPaging="True"  
                 onpageindexchanging="GridView1_PageIndexChanging" ShowFooter="True" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating"   
                >
                 <AlternatingRowStyle BackColor="White" />
                 <Columns>                     
                     <asp:TemplateField ShowHeader="False" >
                         <FooterTemplate>
                             <asp:TextBox ID="txtID" runat="server" Width="70px"></asp:TextBox>
                             <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator0" runat="server" ControlToValidate="txtID" ForeColor="Red" Text="(*)" ValidationGroup="GroupThem" Width="10%"></asp:RequiredFieldValidator>--%>
                         </FooterTemplate>
                         <EditItemTemplate>
                             <asp:LinkButton ID="LinkButtonU" runat="server" CausesValidation="True" CommandName="Update" Text="更新"></asp:LinkButton>
                             &nbsp;<asp:LinkButton ID="LinkButtonC" runat="server" CausesValidation="False" CommandName="Cancel" Text="取消"></asp:LinkButton>
                         </EditItemTemplate>
                         <ItemTemplate>
                             <asp:LinkButton ID="LinkButtonE" runat="server" CausesValidation="False" CommandName="Edit" Text="編輯"></asp:LinkButton>
                         </ItemTemplate> 
                     </asp:TemplateField >
                     <asp:TemplateField HeaderText="Delete">
                         <ItemTemplate>
                             <asp:LinkButton ID="LinkButtonD" runat="server" CommandName="Delete">Delete</asp:LinkButton>
                        
                         </ItemTemplate>
                         <FooterTemplate>
                            <asp:Button ID="btnInsert" runat="server"  Text="Insert"  
                                    ValidationGroup="GroupThem"  Width="70px" onclick="btnInsert_Click"   /> 
                         </FooterTemplate>
                      </asp:TemplateField>
                     <asp:TemplateField HeaderText="ID">
                           <ItemTemplate>
                               <%# Container.DataItemIndex + 1 %>
                           </ItemTemplate>
                     </asp:TemplateField>
                     <asp:TemplateField HeaderText="SystemID /Sub-Menu" >
                         <ItemTemplate>
                            <asp:TextBox  ID="lblDBase" Width="60px" runat="server" Text='<%#Eval("SystemID")%>'></asp:TextBox> <br />
                             <asp:TextBox ID="txtSSID_" Width="60px" runat="server" Text='<%#Eval("SubSysID")%>'></asp:TextBox>
                             <asp:TextBox ID="txtMID_" Width="60px" runat="server" Text='<%#Eval("MenuID")%>'></asp:TextBox>
                         </ItemTemplate> 
                         <FooterTemplate>                          
                             <asp:DropDownList ID="ddlDBaseF" runat="server"  AutoPostBack="true" Width="70%">
                              <asp:ListItem>HRM</asp:ListItem>
                              <asp:ListItem>ERP</asp:ListItem>
                             </asp:DropDownList>
                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"  Width="10%" Text="(*)" ForeColor="Red" 
                                    ValidationGroup="GroupThem" ControlToValidate="ddlDBaseF">
                           </asp:RequiredFieldValidator>--%>    <br />
                             <asp:TextBox ID="txtSSID" Width="100px" runat="server"></asp:TextBox> 
                             <asp:TextBox ID="txtMID" Width="100px" runat="server"></asp:TextBox>
                         </FooterTemplate>                                      
                     </asp:TemplateField >   
 <%--                    <asp:TemplateField HeaderText="SubSysID" >
                         <FooterTemplate>
                         </FooterTemplate>
                         <ItemTemplate>
                         </ItemTemplate>
                     </asp:TemplateField >--%>
                     <%--<asp:TemplateField HeaderText="MenuID" >
                         <FooterTemplate>
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"  Width="10%" Text="(*)" ForeColor="Red" 
                                 ValidationGroup="GroupThem" ControlToValidate="txtMID"></asp:RequiredFieldValidator>
                         </FooterTemplate>
                         <ItemTemplate>
                         </ItemTemplate>
                     </asp:TemplateField >--%>
                     <asp:TemplateField HeaderText="FunctionID / URL" >
                         <FooterTemplate>
                             <asp:TextBox ID="txtFID" Width="100px" runat="server"></asp:TextBox> <br />
                             <asp:TextBox ID="txtLUrl" Width="100px" runat="server"></asp:TextBox>
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"  Width="10%" Text="(*)" ForeColor="Red" 
                                 ValidationGroup="GroupThem" ControlToValidate="txtFID"></asp:RequiredFieldValidator>
                         </FooterTemplate>
                         <ItemTemplate>
                             <asp:TextBox ID="txtFID_" runat="server" Text='<%#Eval("FunctionID")%>'></asp:TextBox> <br />
                             <asp:TextBox ID="txtLUrl_" runat="server" Text='<%#Eval("Link_Url")%>'></asp:TextBox>
                         </ItemTemplate>
                     </asp:TemplateField >
<%--                     <asp:TemplateField HeaderText="Link_Url" >
                         <FooterTemplate>
                             <asp:TextBox ID="txtLUrl" Width="100px" runat="server"></asp:TextBox>
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server"  Width="10%" Text="(*)" ForeColor="Red" 
                                 ValidationGroup="GroupThem" ControlToValidate="txtLUrl"></asp:RequiredFieldValidator>
                         </FooterTemplate>
                         <ItemTemplate>
                             <asp:TextBox ID="txtLUrl_" runat="server" Text='<%#Eval("Link_Url")%>'></asp:TextBox>
                         </ItemTemplate>
                     </asp:TemplateField >--%>
                     <asp:TemplateField HeaderText="Sname /Smemo"  >
                        <ItemTemplate>
                               <asp:TextBox ID="txtFNA" runat="server" Text='<%#Eval("Sname")%>'></asp:TextBox>  <br />
                             <asp:TextBox ID="txtSMemo" runat="server" AutoPostBack="true" Text='<%#Eval("SMemo") %>'></asp:TextBox>
                        </ItemTemplate>   
                        <FooterTemplate>
                            <asp:TextBox ID="txtFNA_" runat="server"></asp:TextBox>  <br />
                             <asp:TextBox ID="txtSMemo_" runat="server"></asp:TextBox>
                        </FooterTemplate>                            
                     </asp:TemplateField>
                     <asp:TemplateField HeaderText="VN /EN">
                        <ItemTemplate>
                          <asp:TextBox ID="txtVN"   runat="server" Text='<%#Eval("VN") %>' AutoPostBack="true" ></asp:TextBox>  <br />
                        <asp:TextBox ID="txtEN" runat="server"  AutoPostBack="true"
                            Text='<%#Eval("EN") %>' 
                                ></asp:TextBox>
                        </ItemTemplate> 
                        <FooterTemplate>
                            <asp:TextBox ID="txtVN_" runat="server"></asp:TextBox>  <br />
                            <asp:TextBox ID="txtEN_" runat="server"></asp:TextBox>
                        </FooterTemplate>  
                     </asp:TemplateField>  
<%--                     <asp:TemplateField HeaderText="VN">
                        <ItemTemplate>
                        </ItemTemplate>  
                        <FooterTemplate>
                        </FooterTemplate> 
                     </asp:TemplateField>--%>
                     <asp:TemplateField HeaderText="CH / status">                
                         <ItemTemplate>
                             <asp:TextBox ID="txtCH" Width="60px" runat="server" AutoPostBack="true" Text='<%#Eval("CH") %>'></asp:TextBox> <br />
                             <asp:TextBox ID="txtStatus" Width="60px" runat="server" AutoPostBack="true" Text='<%#Eval("Status") %>'></asp:TextBox>
                         </ItemTemplate>
                         <FooterTemplate>
                             <asp:TextBox ID="txtCH_" Width="60px" runat="server"></asp:TextBox> <br />
                             <asp:TextBox ID="txtStatus_" Width="60px" runat="server"></asp:TextBox>
                         </FooterTemplate>
                     </asp:TemplateField>
<%--                     <asp:TemplateField HeaderText="SMemo">        
                         <ItemTemplate>
                         </ItemTemplate>
                         <FooterTemplate>
                         </FooterTemplate>
                     </asp:TemplateField>--%>
<%--                     <asp:TemplateField HeaderText="Status">
                         <ItemTemplate>
                         </ItemTemplate>
                         <FooterTemplate>
                         </FooterTemplate>
                     </asp:TemplateField>--%>
                 </Columns>
            <HeaderStyle CssClass="GridviewScrollHeader" BackColor="#6699FF" 
                     BorderColor="#3366FF" /> 
            <RowStyle CssClass="GridviewScrollItem" /> 
            <PagerStyle CssClass="GridviewScrollPager" /> 
            <HeaderStyle BackColor="#0066FF" CssClass="FixedHeader"></HeaderStyle>      
            </asp:GridView>                     
     <br />  
     <center>
     <div>
       <asp:Label ID="lblMessage"  runat="server"    ForeColor="Red" Text=""></asp:Label>
     </div>
     </center>  
     <br />
      </ContentTemplate>
     </asp:UpdatePanel>
         <div  >    </div> 
</asp:Content>





