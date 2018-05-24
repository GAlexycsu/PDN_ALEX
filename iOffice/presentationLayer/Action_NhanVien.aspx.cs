using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
namespace iOffice.presentationLayer
{
    public partial class Action_NhanVien : System.Web.UI.Page
    {
        userDAL dal = new userDAL();
        string congty = ConfigurationManager.AppSettings["Congty"].ToString();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void LayTenNhanVien()
        {
            try
            {
                string NhanVienMa = Request.Headers["NhanVienMa"].ToString();
                DataTable dt = dal.TimNhanVienTheoMa(congty, NhanVienMa);
                if (dt.Rows.Count > 0)
                {

                    string TenNhanVien = dt.Rows[0]["UserName"].ToString();
                    Response.Write(TenNhanVien);
                }
            }
            catch
            {
                Response.Write("Error!");
            }
        }
    }
}