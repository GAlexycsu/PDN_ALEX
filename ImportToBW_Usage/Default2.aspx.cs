using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Default2 : System.Web.UI.Page
{
    BLL_Import _bll = new BLL_Import();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string XieXing = "KPL301-A0";
            DataTable dt = _bll.TimMaMauTheoDangDay(XieXing);
            foreach (DataRow dr in dt.Rows)
            {
                string SheHao = dr["SheHao"].ToString();
                ListBox1.Items.Add(new ListItem(SheHao, SheHao));
            }
        }
    }
    protected void Submit(object sender, EventArgs e)
    {
        string message = "";
        foreach (ListItem item in ListBox1.Items)
        {
            if (item.Selected)
            {
                message += item.Text + " " + item.Value + "\\n";
            }
        }
        ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "alert('" + message + "');", true);
    }
}