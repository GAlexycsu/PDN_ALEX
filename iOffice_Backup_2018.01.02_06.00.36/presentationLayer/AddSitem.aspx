<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddSitem.aspx.cs" Inherits="iOffice.presentationLayer.AddSitem" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    
    
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

</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table>
            
            <tr>
                <td>
                       Title 
                </td>
                <td>
                    <asp:DropDownList ID="DropDownDD" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownDD_SelectedIndexChanged"></asp:DropDownList>
                    <asp:Label ID="lblAA" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>Sitem No</td>
                <td>
                    <asp:TextBox ID="txtSitemNo" runat="server" MaxLength="10" ></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtSitemNo" ForeColor="Red" Text="(*)" ValidationGroup="groupThem" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>
                </td>

            </tr>
            <tr>
                <td>
                    Sitem Name
                </td>
                <td>
                    <asp:TextBox ID="txtSitemVN" runat="server" Rows="4" Width="900px"  MaxLength="490" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Sitem Name TW
                </td>
                <td>
                    <asp:TextBox ID="txtSitemTW" runat="server" Rows="3" Width="900px"  MaxLength="490" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Sitem Name EN
                </td>
                <td>
                    <asp:TextBox ID="txtSitemEN" runat="server" Rows="3" Width="900px"  MaxLength="490" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Score
                </td>
                <td>
                    <asp:TextBox ID="txtScore" runat="server" MaxLength="100" ></asp:TextBox>
                </td>
            </tr>
        </table>
        <p class="button-wrap"> <asp:Button ID="btnSave" runat="server" CssClass="button save" ValidationGroup="groupThem" Text="Save" OnClick="btnSave_Click" />

            <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
        </p>
    </div>
           <table id="abc" style="width:99%;background-color:tomato; color:white;">
              <tr>
                  <th style="width:7%"></th>
                   <th style="width:5%">ID</th>
                   <th style="width:72%">Name VN</th>
                   <th style="width:7%">Score</th>
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
                  </asp:TemplateField>
                   <asp:TemplateField>
                      <ItemTemplate>
                          <asp:Label ID="lblStpnamevn" runat="server" Text='<%#Eval("Stpnamevn") %>'></asp:Label>

                      </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="ID">
                      <ItemTemplate>
                          <asp:Label ID="lblSitemno" runat="server" Text='<%#Eval("Sitemno") %>'></asp:Label>
                      </ItemTemplate>
                      <ItemStyle HorizontalAlign="Center" Width="7%" />
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="" Visible="false" >
                      <ItemTemplate>
                          <asp:Label ID="lblSitemtp" runat="server" Text='<%#Eval("Sitemtp") %>'></asp:Label>
                      </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="VN">
                      <ItemTemplate>
                          <asp:Label ID="lblSnamevn" runat="server" Text='<%#Eval("Snamevn") %>'></asp:Label>
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
                              Tile:
                              <%#Eval("Stpnamevn") %><br />
                              ID:
                              <%#Eval("Sitemno") %><br />
                              Snamevn:
                              <%#Eval("Snamevn") %><br />
                              Snamech :
                              <%#Eval("Snamech") %><br />
                              Snameen:
                              <%#Eval("Snameen") %><br />
                              Sitemscore:
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
      </div>
        <div style="display:none">
            <asp:TextBox ID="txtIDTemp" runat="server"></asp:TextBox>
        </div>
    </form>
</body>
</html>
