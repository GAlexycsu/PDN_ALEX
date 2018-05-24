<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="iOffice.presentationLayer.Users.WebForm1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Single & Double clicks</title>    
</head>
<body>
    <form id="form1" runat="server">
    <h2>Single & Double clicks with GridView, DataList and ListBox</h2>
    <p>Try single and double clicking on the GridView, DataList and ListBox rows.</p>
    <div>        
        <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#DEDFDE" 
            BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical" 
            OnRowDataBound="GridView1_RowDataBound" OnRowCommand="GridView1_RowCommand">
            <FooterStyle BackColor="#CCCC99" />
            <Columns>                
                <asp:ButtonField Text="SingleClick" CommandName="SingleClick" Visible="false"/>
                <asp:ButtonField Text="DoubleClick" CommandName="DoubleClick" Visible="false"/>
            </Columns>
            <RowStyle BackColor="#F7F7DE" />
            <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />            
            <AlternatingRowStyle BackColor="White" />
        </asp:GridView>
        <br /><br />
        <asp:DataList ID="DataList1" runat="server" width="400px"
        OnItemCommand="DataList1_ItemCommand" OnItemDataBound="DataList1_ItemDataBound">
            <HeaderTemplate>
                Tasks
            </HeaderTemplate>
            <ItemTemplate>
                <asp:LinkButton ID="LinkButton1" runat="server" Text="SingleClick" CommandName="SingleClick" Visible="false"/>
                <asp:LinkButton ID="LinkButton2" runat="server" Text="DoubleClick" CommandName="DoubleClick" Visible="false"/>
                <asp:Panel ID="Panel1" runat="server">
                    <span style="float:left;">
                        <b>Id: </b><%# Eval("Id") %>
                        &nbsp;&nbsp;<b>Task: </b><%# Eval("Task") %>
                    </span>
                    <span style="float:right;">
                        <b>IsDone: </b><%# Eval("IsDone") %>
                    </span>
                </asp:Panel>
            </ItemTemplate> 
            <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />    
            <ItemStyle BackColor="#F7F7DE" BorderStyle="Solid" BorderColor="lightgray" BorderWidth="1px" />
            <AlternatingItemStyle BackColor="white" />
            <SelectedItemStyle BackColor="#CE5D5A" /> 
        </asp:DataList>
        <br /><br />
        <asp:ListBox ID="ListBox1" runat="server" DataTextField="Task" DataValueField="Id" OnSelectedIndexChanged="ListBox1_SelectedIndexChanged"></asp:ListBox>
        <br /><br />
        <asp:Label id="Message" runat="server" ForeColor="Red" Font-Bold="true"></asp:Label>        
     </div>
    </form>
</body>
</html>

