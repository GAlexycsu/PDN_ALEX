using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Collections;
namespace iOffice.presentationLayer.Users
{
    public partial class ReportPhieuMuaHang : ViewReport
    {
        CommonFunction cmm = new CommonFunction();
        dalPDN dal = new dalPDN();
      
        protected void Page_Load(object sender, EventArgs e)
        {
            string type = "";
            if (cmm.IsNullOrEmpty(Request["Type"]))
            {
                Response.Redirect("Default.aspx");
            }
            else
            {
                type = Request["Type"].ToString();
            }
            switch (type)
            {
                case "PhieuDatMuaHangNoSize":
                    PhieuDatMuaHangNoSize();
                    break;
            }
        }
        public void PhieuDatMuaHangNoSize()
        {
            try
            {
                string pdno = (string)Request["maphieu"];
                string GSBH = (string)Request["macongty"];
                string CGNO = (string)Request["CGNO"];
                string ZSBH = (string)Request["ZSBH"];
                List<string> Path = new List<string>();
                Path.Add("~/presentationLayer/Report/PhieuDatMuaHangNoSize.rpt");
                Hashtable htb = new Hashtable();
                DataSet ds = new DataSet();
                htb.Add("pdNO", pdno);
                htb.Add("GSBH", GSBH);
                htb.Add("CGNO", CGNO);
                htb.Add("ZSBH", ZSBH);

                ds = dal.QryPhieuDatMuaHangNoSize(pdno, GSBH, CGNO, ZSBH);
                if (ds.Tables.Count != 0)
                {
                    ShowPDF(Path, ds, htb);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}