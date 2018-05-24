<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMater/Site8S.Master" AutoEventWireup="true" CodeBehind="Main8S.aspx.cs" Inherits="iOffice.presentationLayer.Main8S" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
      
    <link href="../Content/Site.css" rel="stylesheet" />
    <link href="../Content/CSSForm1.css" rel="stylesheet" />
     <style type="text/css">
        .tooltip
        {
            display: none;
            border: solid 1px #708069;
            background-color: #289642;
            color: #fff;
            line-height: 25px;
            border-radius: 5px;
            padding: 5px 10px;
            position: fixed;
            margin-left:40px;
            z-index:1001;
        }
    </style>
    

    
    <link href="../Style/GridviewScroll.css" rel="stylesheet" />
    <link href="../Style/jquery-ui-1.8.19.custom.css" rel="stylesheet" />
       <script src="../../Scripts/jquery.min.js"></script>
    <script src="../../Scripts/jquery-ui.min.js"></script>
    <script src="../../Scripts/gridviewScroll.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            gridviewScroll1();
        });

        function gridviewScroll1() {
            $('#<%=GridView1.ClientID%>').gridviewScroll({
                width: '100%',
                height: 200
            });
        }
</script>
        
      
      <script src="../Scripts/jquery-1.9.1.min.js"></script>
      <script  type="text/javascript">
          $(document).ready(function () {
              $(".tooltip").closest("tr").mousemove(function (event) {
                  $(this).find(".tooltip").css({
                      "left": event.pageX + 1,
                      "top": event.pageY + 1
                  }).show();
              }).mouseout(function () { $(this).find(".tooltip").hide(); });;
          });
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  
      
     <div>
        <table>
            
            <tr>
                <td>
                       
                    <%=hasLanguege["lblLoai8S"].ToString() %>
                </td>
                <td>
                    <asp:DropDownList ID="DropDownDD" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownDD_SelectedIndexChanged"></asp:DropDownList>
                    <asp:Label ID="lblAA" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                     <%=hasLanguege["lblMaSo"].ToString() %>
                </td>
                <td>
                    <asp:TextBox ID="txtSitemNo" runat="server" MaxLength="10" ></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtSitemNo" ForeColor="Red" Text="(*)" ValidationGroup="groupThem" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>
                </td>

            </tr>
            <tr>
                <td>
                  
                     <%=hasLanguege["lblVanDe"].ToString() %> VN
                </td>
                <td>
                    <asp:TextBox ID="txtSitemVN" runat="server" Rows="4" Width="900px"  MaxLength="490" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                  
                     <%=hasLanguege["lblVanDe"].ToString() %> CH
                </td>
                <td>
                    <asp:TextBox ID="txtSitemTW" runat="server" Rows="3" Width="900px"  MaxLength="490" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                   
                     <%=hasLanguege["lblVanDe"].ToString() %> EN
                </td>
                <td>
                    <asp:TextBox ID="txtSitemEN" runat="server" Rows="3" Width="900px"  MaxLength="490" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    
                     <%=hasLanguege["lblDiemChuan"].ToString() %>
                </td>
                <td>
                    <asp:TextBox ID="txtScore" runat="server" MaxLength="100" ></asp:TextBox>
                </td>
            </tr>
        </table>
        <p class="button-wrap" style="margin-left:30px"> <asp:Button ID="btnSave" runat="server" CssClass="button save" BackColor="#F0CCFF"  ForeColor="Blue"  ValidationGroup="groupThem" Text="Save" OnClick="btnSave_Click" />

            <%--<asp:Button ID="btnCanCel" runat="server" Text="Button" CssClass="button delete" OnClick="Button1_Click" />--%>
        </p>
    </div>
           <table id="abc" style="width:99%;background-color:tomato; color:white;">
              <tr>
                  <th style="width:7%"></th>
                   <th style="width:5%"><%=hasLanguege["lblMaSo"].ToString() %></th>
                   <th style="width:12%"><%=hasLanguege["lblLoai8S"].ToString() %></th>
                   <th style="width:5%"><%=hasLanguege["lblMaSo"].ToString() %></th>
                   <th style="width:62%"> <%=hasLanguege["lblVanDe"].ToString() %></th>
                   <th style="width:7%"> <%=hasLanguege["lblDiemChuan"].ToString() %></th>
              </tr>
          </table>
      <div style="height:600px; overflow:scroll">
       
          <asp:GridView ID="GridView1" runat="server" Width="99%"  ShowHeader="false"  AutoGenerateColumns="False" BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" CellPadding="4" GridLines="Horizontal" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnRowDataBound="GridView1_RowDataBound">
              <Columns>
                  <asp:TemplateField>
                      <ItemTemplate>
                          <asp:LinkButton ID="LinkEdit" runat="server"  CommandName="Select" ><img src="../Content/Icon/edit.gif" /> Edit</asp:LinkButton>
                      </ItemTemplate>
                       <ItemStyle HorizontalAlign="Center" Width="7%" />
                  </asp:TemplateField>
                   <asp:TemplateField>
                      <ItemTemplate>
                          <asp:Label ID="lblSitemtp" runat="server" Text='<%#Eval("Sitemtp") %>'></asp:Label>

                      </ItemTemplate>
                       <ItemStyle HorizontalAlign="Center" Width="5%" />
                  </asp:TemplateField>
                   <asp:TemplateField>
                      <ItemTemplate>
                          <asp:Label ID="lblStpnamevn" runat="server" Text='<%#Eval("Stpnamevn") %>'></asp:Label>

                      </ItemTemplate>
                       <ItemStyle  Width="12%" />
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="ID">
                      <ItemTemplate>
                          <asp:Label ID="lblSitemno" runat="server" Text='<%#Eval("Sitemno") %>'></asp:Label>
                      </ItemTemplate>
                      <ItemStyle HorizontalAlign="Center" Width="7%" />
                  </asp:TemplateField>
                  <%--<asp:TemplateField HeaderText="" Visible="false" >
                      <ItemTemplate>
                          <asp:Label ID="lblSitemtp" runat="server" Text='<%#Eval("Sitemtp") %>'></asp:Label>
                      </ItemTemplate>
                  </asp:TemplateField>--%>
                  <asp:TemplateField HeaderText="VN">
                      <ItemTemplate>
                          <asp:Label ID="lblSnamevn" runat="server" Text='<%#Eval("Snamevnn") %>'></asp:Label>
                      </ItemTemplate>
                  </asp:TemplateField>

                  <asp:TemplateField HeaderText="Score">
                      <ItemTemplate>
                          <asp:Label ID="lblSitemscore" runat="server" Text='<%#Eval("Sitemscore") %>'></asp:Label>
                      </ItemTemplate>
                      <ItemStyle HorizontalAlign="Center" Width="7%" />
                  </asp:TemplateField>
                  <asp:TemplateField Visible="false">
                      <ItemTemplate>
                          <asp:Label ID="lblSnamech" runat="server" Text='<%#Eval("Snamech") %>'></asp:Label>
                      </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField Visible="false">
                      <ItemTemplate>
                          <asp:Label ID="lblSnameen" runat="server" Text='<%#Eval("Snameen") %>'></asp:Label>
                      </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField  >
                      <ItemTemplate>
                          <div class="tooltip">
                              <%=hasLanguege["lblLoai8S"].ToString() %>:
                              <%#Eval("Stpnamevn") %><br />
                              <%=hasLanguege["lblMaSo"].ToString() %>:
                              <%#Eval("Sitemno") %><br />
                               <%=hasLanguege["lblVanDe"].ToString() %> VN :
                              <%#Eval("Snamevn") %><br />
                               <%=hasLanguege["lblVanDe"].ToString() %> CH :
                              <%#Eval("Snamech") %><br />
                               <%=hasLanguege["lblVanDe"].ToString() %> EN:
                              <%#Eval("Snameen") %><br />
                               <%=hasLanguege["lblDiemChuan"].ToString() %> :
                              <%#Eval("Sitemscore") %>

                          </div>
                      </ItemTemplate>
                  </asp:TemplateField>
              </Columns>
              <FooterStyle BackColor="White" ForeColor="#333333" />
              <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
              <PagerStyle ForeColor="White" HorizontalAlign="Center" BackColor="#336666" />
              <RowStyle BackColor="White" ForeColor="#333333" />
              <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
              <SortedAscendingCellStyle BackColor="#F7F7F7" />
              <SortedAscendingHeaderStyle BackColor="#487575" />
              <SortedDescendingCellStyle BackColor="#E5E5E5" />
              <SortedDescendingHeaderStyle BackColor="#275353" />
          </asp:GridView>
          <table id="Table1" style="width:99%;background-color:darkseagreen; color:white;">
              <tr>
                  <th style="width:7%"></th>
                   <th style="width:5%"></th>
                   <th style="width:72%"> </th>
                   <th style="width:7%">
                       <asp:Label ID="lblPhanTram" runat="server" ForeColor="#FF0066"></asp:Label> </th>
              </tr>
      </div>
        <div style="display:none">
            <asp:TextBox ID="txtIDTemp" runat="server"></asp:TextBox>
        </div>
      
</asp:Content>
