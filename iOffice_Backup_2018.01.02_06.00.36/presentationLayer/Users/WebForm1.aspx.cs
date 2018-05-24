using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using iOffice.BUS;
namespace iOffice.presentationLayer.Users
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        string phong = "VTY01";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GridView1.DataSource = UserBUS.LayDanhSachNguoiDuyet(phong);
                GridView1.DataBind();
               // GetData();
            }
        }
        #region GetData

        // Some data to bind to the Gridview and DataList
        private DataTable GetData()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add(new DataColumn("Id", typeof(int)));
            dt.Columns.Add(new DataColumn("Task", typeof(string)));
            dt.Columns.Add(new DataColumn("IsDone", typeof(bool)));

            dt.Rows.Add(new object[] { 0, "Create a new project", true });
            dt.Rows.Add(new object[] { 1, "Build a demo applcation", true });
            dt.Rows.Add(new object[] { 2, "Test the demo applcation", true });
            dt.Rows.Add(new object[] { 3, "Deploy the demo applcation", false });
            dt.Rows.Add(new object[] { 4, "Support the demo applcation", false });

            return dt;
        }

        #endregion    
        // Register the dynamically created client scripts
        protected override void Render(HtmlTextWriter writer)
        {
            // The client scripts for GridView1 were created in GridView1_RowDataBound
            foreach (GridViewRow r in GridView1.Rows)
            {
                if (r.RowType == DataControlRowType.DataRow)
                {
                    Page.ClientScript.RegisterForEventValidation(r.UniqueID + "$ctl00");
                    Page.ClientScript.RegisterForEventValidation(r.UniqueID + "$ctl01");
                }
            }

            // The client scripts for DataList1 were created in DataList1_ItemDataBound
            foreach (DataListItem i in DataList1.Items)
            {
                if (i.ItemType == ListItemType.Item
                    || i.ItemType == ListItemType.AlternatingItem
                    || i.ItemType == ListItemType.SelectedItem)
                {
                    Page.ClientScript.RegisterForEventValidation(i.UniqueID + "$ctl00");
                    Page.ClientScript.RegisterForEventValidation(i.UniqueID + "$ctl01");
                }
            }

            base.Render(writer);
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // Get the LinkButton control in the first cell
                LinkButton _singleClickButton = (LinkButton)e.Row.Cells[0].Controls[0];
                // Get the javascript which is assigned to this LinkButton
                string _jsSingle = ClientScript.GetPostBackClientHyperlink(_singleClickButton, e.Row.Cells[0].Text.ToString());
                // To prevent the first click from posting back immediately 
                // (therefore giving the user a chance to double click) pause the 
                // postback for 300 milliseconds by using setTimeout
                _jsSingle = _jsSingle.Insert(11, "setTimeout(\"");
                _jsSingle += "\", 300)";
                // Add this javascript to the onclick Attribute of the row
                e.Row.Attributes["onclick"] = _jsSingle;

                // Get the LinkButton control in the second cell
                LinkButton _doubleClickButton = (LinkButton)e.Row.Cells[1].Controls[0];
                // Get the javascript which is assigned to this LinkButton
                string _jsDouble = ClientScript.GetPostBackClientHyperlink(_doubleClickButton, "");
                // Add this javascript to the ondblclick Attribute of the row
                e.Row.Attributes["ondblclick"] = _jsDouble;
            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridView _gridView = (GridView)sender;

            // Get the selected index and the command name
            int _selectedIndex = int.Parse(e.CommandArgument.ToString());
            string _commandName = e.CommandName;

            switch (_commandName)
            {
                case ("SingleClick"):
                    _gridView.SelectedIndex = _selectedIndex;
                    this.Message.Text += "Single clicked GridView row at index " + _selectedIndex.ToString() + "<br />";
                    break;
                case ("DoubleClick"):
                    this.Message.Text += "Double clicked GridView row at index " + _selectedIndex.ToString() + "<br />";
                    break;
            }
        }

        protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
        {
            DataList _dataList = (DataList)source;

            // Get the selected index and the command name
            int _selectedIndex = e.Item.ItemIndex;
            string _commandName = e.CommandName;

            switch (_commandName)
            {
                case ("SingleClick"):
                    _dataList.SelectedIndex = _selectedIndex;
                    this.Message.Text += "Single clicked DataList row at index " + _selectedIndex.ToString() + "<br />";
                    break;
                case ("DoubleClick"):
                    this.Message.Text += "Double clicked DataList row at index " + _selectedIndex.ToString() + "<br />";
                    break;
            } 
        }

        protected void DataList1_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                // Get the first LinkButton control
                LinkButton _singleClickButton = (LinkButton)e.Item.Controls[1];
                // Get the javascript which is assigned to this LinkButton
                string _jsSingle = ClientScript.GetPostBackClientHyperlink(_singleClickButton, "");
                // To prevent the first click from posting back immediately 
                // (therefore giving the user a chance to double click) pause the 
                // postback for 300 milliseconds by using setTimeout
                _jsSingle = _jsSingle.Insert(11, "setTimeout(\"");
                _jsSingle += "\", 300)";
                // Get the panel wrapping the item
                Panel itemPanelSingle = (Panel)e.Item.Controls[5];
                // Add this javascript to the onclick Attribute of the panel
                itemPanelSingle.Attributes["onclick"] = _jsSingle;

                // Get the second LinkButton control
                LinkButton _doubleClickButton = (LinkButton)e.Item.Controls[3];
                // Get the javascript which is assigned to this LinkButton
                string _jsDouble = ClientScript.GetPostBackClientHyperlink(_doubleClickButton, "");
                // Get the panel wrapping the item
                Panel _itemPanelDouble = (Panel)e.Item.Controls[5];
                // Add this javascript to the ondblclick Attribute of the panel
                _itemPanelDouble.Attributes["ondblclick"] = _jsDouble;
            }
        }

        protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox _listBox = (ListBox)sender;

            // Get the selected index and the command name
            int _selectedIndex = _listBox.SelectedIndex;
            string _commandName = Request.Form["__EventArgument"].ToString();

            switch (_commandName)
            {
                case ("SingleClick"):
                    this.Message.Text += "Single clicked ListBox row at index " + _selectedIndex.ToString() + "<br />";
                    break;
                case ("DoubleClick"):
                    this.Message.Text += "Double clicked ListBox row at index " + _selectedIndex.ToString() + "<br />";
                    break;
            }   
        }
    }
}