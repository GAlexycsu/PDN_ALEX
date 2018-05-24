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
using System.Configuration;
namespace iOffice.presentationLayer.Users
{
    public partial class WF_ReportPDN : ViewReport
    {
        CommonFunction cmm = new CommonFunction();
        dalPDN dal = new dalPDN();
          
        DAL_Calendar dalCalendar = new DAL_Calendar();
        DAL_System dalSystem = new DAL_System();
        userDAL dalUser = new userDAL();
        string congty = ConfigurationManager.AppSettings["Congty"].ToString();
        
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
                case "PhieuDatMuaHangNoSizeNoTitle":
                    PhieuDatMuaHangNoSizeNoTitle();
                    break;
                case "BaoCaoTuan":
                    HienThiBaoCaoJobTuan();
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
        public void PhieuDatMuaHangNoSizeNoTitle()
        {
            try
            {
                string pdno = (string)Request["maphieu"];
                string GSBH = (string)Request["macongty"];
                string CGNO = (string)Request["CGNO"];
                string ZSBH = (string)Request["ZSBH"];
                List<string> Path = new List<string>();
                Path.Add("~/presentationLayer/Report/PhieuDatMuaHangNoSizeNoTitle.rpt");
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
        public void HienThiBaoCaoJobTuan()
        {
            try
            {
                string UserID = (string)Request["UserID"];
                DataTable dt = dalUser.TimNhanVienTheoMa(congty, UserID);
                string Us = "";
                if (dt.Rows.Count > 0)
                {
                    Us = dt.Rows[0]["USERNAME"].ToString();
                }
                else
                {
                    Us = UserID;
                }
                string homnay = DateTime.Today.ToString("ddMMyyyy");
                string chuoi = Us + '_' + homnay;
                string FromDate = (string)Request["FromDate"];
                string ToDate = (string)Request["ToDate"];
                DateTime pFromDate = DateTime.Parse(FromDate.ToString());
                DateTime pToDate = DateTime.Parse(ToDate.ToString());
                List<string> Path = new List<string>();
                string pathA = ConfigurationManager.AppSettings["attactFile"].ToString();
                string pathServer = pathA + @"\crtBaoCaoTuan_Excel.rpt";
                // Path.Add("~/presentationLayer/Report/crtBaoCaoTuan_Excel.rpt");
                // Path.Add("http://192.168.11.6:8000/presentationLayer/Report/crtBaoCaoTuanExcel1.rpt");
                Path.Add("~/Report/crtBaoCaoTuanExcel.rpt");
                Hashtable htb = new Hashtable();
                DataSet ds = new DataSet();
                htb.Add("UserID", UserID);
                htb.Add("FromDate", pFromDate.ToString("yyyy/MM/dd"));
                htb.Add("ToDate", pToDate.ToString("yyyy/MM/dd"));

                ds = dalCalendar.XuatBaoCaoCongViecTheoNgayThang(UserID, pFromDate, pToDate);
                if (ds.Tables.Count > 0)
                {
                    ShowExecl(Path, ds, htb,chuoi);
                }

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}