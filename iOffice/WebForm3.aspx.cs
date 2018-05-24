using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace iOffice
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        dalPDN dal = new dalPDN();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                HienThiDropBoxNhaCungUng();
            }
        }

        public void HienThiDropBoxNhaCungUng()
        {
            string macongty = "LTY";
            string idphieu = "201502111";
            DataTable dt = dal.DanhSachNhaCungUngTheoMaPhieu(macongty, idphieu);
            if (dt.Rows.Count != 0)
            {
                dropNhaCC.DataSource = dt;
                dropNhaCC.DataTextField = "zsywjc";
                dropNhaCC.DataValueField = "ZSBH";
                dropNhaCC.DataBind();
            }
            //else
            //{
            //    dropNhaCC.Items.Insert(0, " ");
            //}
        }
    }
}