<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMater/Site8S.Master" AutoEventWireup="true" CodeBehind="them8S.aspx.cs" Inherits="iOffice.presentationLayer.them8S" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="pn1Add" runat="server">
        <ContentTemplate>

     
        <div>
         
        <table>
                 <tr>
                    <td><%-- <%=hasLanguege["lblTuNgay"].ToString() %>--%>
                        FromDate
                    </td>
                    <td>
                        <asp:TextBox ID="txtFromDate" runat="server" ClientIDMode="Static"></asp:TextBox>
                    </td>
                    <td>
                        
                       <%--  <%=hasLanguege["lblDenNgay"].ToString() %>--%>
                        To Date
                    </td>
                    <td>
                        <asp:TextBox ID="txtToDate" runat="server" ClientIDMode="Static"></asp:TextBox>
                    </td>
                    
                </tr>
        </table>
           
             
           
        <table>
             <tr>
                         <td class="auto-style2">
                             
                              <%-- <%=hasLanguege["lblDonVi"].ToString() %>--%>
                             Department 
                         </td>
                         <td class="auto-style2">
                             <asp:DropDownList ID="DropDownDonVi" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownDonVi_SelectedIndexChanged"></asp:DropDownList>
                             
                         </td>
                         <td>
                             <asp:Button ID="btnAdd" runat="server" Text="Add 8S" />
                         </td>
            </tr>
        </table>
    </div>
       </ContentTemplate>
    </asp:UpdatePanel>
    <div >
        <%if(dt.Rows.Count>0){ %>
        <div style="overflow:auto;max-height:600px">
            <table style="width:100%;" id="GridView2" >
               <%for(int i=0;i<dt.Rows.Count;i++)
                 { %>
                <tr style="background-color:#f6e0e0;color:#0026ff">
                    <td>
                        <input type="text" id="Date<%=i.ToString() %>" size="4" value="<%=dt.Rows[i]["S8date"].ToString() %>" onchange="Change8Score(<%=i.ToString() %>)" />

                    </td>
                    <td style="display:none">
                        <input type="text" id="sh<%=i.ToString() %>" size="2" value="<%=dt.Rows[i]["sh"].ToString() %>" />
                    </td>
                    <td>
                        <input type="text" id="depid<%=i.ToString() %>" size="4" value="<%=dt.Rows[i]["depid"].ToString() %>" />

                    </td>
                    <td>
                        <input type="text" id="DepName<%=i.ToString() %>" size="8" value="<%=dt.Rows[i]["DepName"] %>" />
                    </td>
                    <td>
                        <input type="text" id="Sitemtp<%=i.ToString() %>" size="5" value="<%=dt.Rows[i]["Sitemtp"].ToString() %>" />
                    </td>
                     <td>
                        <input type="text" id="Stpnamevn<%=i.ToString() %>" size="5" value="<%=dt.Rows[i]["Stpnamevn"].ToString() %>" />
                    </td>
                     <td>
                        <input type="text" id="Sitemno<%=i.ToString() %>" size="5" value="<%=dt.Rows[i]["Sitemno"].ToString() %>" />
                    </td>
                     <td>
                        <input type="text" id="Snamevn<%=i.ToString() %>" size="5" value="<%=dt.Rows[i]["Snamevn"].ToString() %>" />
                    </td>
                     <td>
                        <input type="text" id="Sitemscore<%=i.ToString() %>" size="5" value="<%=dt.Rows[i]["Sitemscore"].ToString() %>" />
                    </td>
                     <td>
                        <input type="text" id="QCmemo<%=i.ToString() %>" size="5" value="<%=dt.Rows[i]["QCmemo"].ToString() %>" />
                    </td>
                     <td>
                        <input type="text" id="QVmemo<%=i.ToString() %>" size="5" value="<%=dt.Rows[i]["QVmemo"].ToString() %>" />
                    </td>
                     
                     <td>
                        <input type="text" id="sub_score<%=i.ToString() %>" size="5" value="<%=dt.Rows[i]["sub_score"].ToString() %>" />
                    </td>
                     <td>
                        <input type="text" id="yn<%=i.ToString() %>" size="2" value="<%=dt.Rows[i]["yn"].ToString() %>" />
                    </td>
                     <td>
                        <input type="text" id="Text8" size="5" value="<%=dt.Rows[i][""].ToString() %>" />
                    </td>
                     <td>
                        <input type="text" id="Text9" size="5" value="<%=dt.Rows[i][""].ToString() %>" />
                    </td>
                     <td>
                        <input type="text" id="Text10" size="5" value="<%=dt.Rows[i][""].ToString() %>" />

                    </td>
                     <td>
                        <input type="text" id="Text11" size="5" value="<%=dt.Rows[i][""].ToString() %>" />
                    </td>

                </tr>
            </table>

        </div>

        <%} %>
    </div>
</asp:Content>
