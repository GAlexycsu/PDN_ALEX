using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using iOffice.BUS;
using iOffice.DAO;
using iOffice.DTO;
namespace iOffice.presentationLayer
{
    public partial class test : LanguegeBus
    {
        DAL_GroupShare dalGroup = new DAL_GroupShare();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                HienThiMessage();
            }
        }
        public void HienThiMessage()
        {
            string CongTy = "LTY";
            string UserID = "27276";
            DateTime date = DateTime.Today;
            DataTable dt = dalGroup.LayDanhSachMessgage(date, CongTy, UserID);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
    }
}