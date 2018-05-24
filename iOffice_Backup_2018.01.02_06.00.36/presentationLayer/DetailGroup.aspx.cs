using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
namespace iOffice.presentationLayer
{
    public partial class DetailGroup : System.Web.UI.Page
    {
        DAL_GroupShare dalGroup = new DAL_GroupShare();
        protected void Page_Load(object sender, EventArgs e)
        {
          string  strAction = Request.Headers["Action"].ToString();
         // string USID = Request.Headers["valueGroup"].ToString();
          string USID = "2015070004";
          DataTable dt = dalGroup.LayGroupMessage(USID);
          if (dt.Rows.Count > 0)
          {
              lblTitle.Text = dt.Rows[0]["UStitle"].ToString();
              lblMemo.Text = dt.Rows[0]["USmemo"].ToString();
              //  
              GridView1.DataSource = dt;
              GridView1.DataBind();
          }
        }
    }
}