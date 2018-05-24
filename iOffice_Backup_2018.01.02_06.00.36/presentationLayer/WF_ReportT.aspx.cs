using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;
using System.Configuration;
using CrystalDecisions.CrystalReports;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
namespace iOffice.presentationLayer
{
    public partial class WF_ReportT : ViewReport
    {
        CommonFunction cmm = new CommonFunction();
        DAL_Calendar dalCalendar = new DAL_Calendar();
        DAL_System dalSystem = new DAL_System();
        userDAL dalUser = new userDAL();
        Stem8SDAL dalItem8S = new Stem8SDAL();
        S8recDAL dalS8R = new S8recDAL();
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
                case "BaoCaoTuan":
                    HienThiBaoCaoJobTuan();
                    break;
                case "BaoCaoProject":
                    HienThiBaoCaoProject();
                    break;
                case "BaoCao8STheoTuan":
                    HienThiBaoCao8STheoDonVi();
                    break;
                case "BaoCaoTuan8S":
                    HienThiBaoCao8STheoTuan();
                    break;

            }
        }
        public void HienThiBaoCaoProject()
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
                string chuoi=Us+'_'+homnay;
                string FromDate = (string)Request["FromDate"];
                string ToDate = (string)Request["ToDate"];
                DateTime pFromDate = DateTime.Parse(FromDate.ToString());
                DateTime pToDate = DateTime.Parse(ToDate.ToString());
                List<string> Path = new List<string>();
                Path.Add(@"~/Report/crtBaoCaoChuyenAnExcel.rpt");
                Hashtable htb = new Hashtable();
                DataSet ds = new DataSet();
                htb.Add("UserID", UserID);
                htb.Add("FromDate", pFromDate.ToString("dd/MM/yyyy"));
                htb.Add("ToDate", pToDate.ToString("dd/MM/yyyy"));
                ds = dalSystem.XuatBaoCaoTheoNgayThang(UserID, pFromDate, pToDate);
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
               // Path.Add("http://192.168.11.6:8000/presentationLayer/Report/crtBaoCaoTuanExcel.rpt");
                Path.Add(@"~/Report/crtBaoCaoTuanExcel.rpt");
                Hashtable htb = new Hashtable();
                DataSet ds = new DataSet();
                htb.Add("UserID", UserID);
                htb.Add("FromDate", pFromDate.ToString("dd/MM/yyyy"));
                htb.Add("ToDate", pToDate.ToString("dd/MM/yyyy"));
               
              ds=   dalCalendar.XuatBaoCaoCongViecTheoNgayThang(UserID, pFromDate, pToDate);
              if (ds.Tables.Count>0)
              {
                  ShowExecl(Path, ds, htb,chuoi);
              }
                
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public void HienThiBaoCao8STheoDonVi()
        {
            string pDepartmentID = (string)Request["DepartmentID"];
            string pFromDate = (string)Request["FromDate"];
            string pToDate = (string)Request["ToDate"];
            DateTime FromDate;
            DateTime ToDate;
            try
            {
                FromDate = DateTime.Parse(pFromDate);
                ToDate = DateTime.Parse(pToDate);
            }
            catch
            {
                FromDate = DateTime.Today.AddDays(-7);
                ToDate = DateTime.Today;
            }

            List<string> Path = new List<string>();
            string pathA = ConfigurationManager.AppSettings["attactFile"].ToString();
            string pathServer = pathA + @"\crtBaoCaoTuan_Excel.rpt";

            Path.Add(@"~/Report/CrystalReport4.rpt");
            Hashtable htb = new Hashtable();
            DataSet ds = new DataSet();
            DataSet ds1 = new DataSet();
            DataSet ds2 = new DataSet();
            DataSet ds3 = new DataSet();
            htb.Add("depid", pDepartmentID);
            htb.Add("FromDate", FromDate.ToString("dd/MM/yyyy"));
            htb.Add("ToDate", ToDate.ToString("dd/MM/yyyy"));
            ds1 = dalItem8S.QryDiem8STheoDonVi(FromDate, ToDate, pDepartmentID);
            ds2 = dalItem8S.LayItem8SVN();
            ds3 = dalItem8S.LayDiem8SCH();
            ds.Merge(ds1);
            ds.Merge(ds2);
            ds.Merge(ds3);
            if (ds1.Tables.Count > 0)
            {
                ShowExecl(Path, ds, htb);
            }
        }
        public void HienThiBaoCao8STheoTuan()
        {
            string pFromDate = (string)Request["FromDate"];
            string pToDate = (string)Request["ToDate"];
            string UserID = (string)Request["UserID"];
            string DClass = (string)Request["DClass"];
            if (pFromDate != null && pToDate != null && UserID != null && DClass != null)
            {
                DateTime FromDate=DateTime.Parse(pFromDate.Trim());
                DateTime ToDate=DateTime.Parse(pToDate.Trim());
                 List<string> Path = new List<string>();
            string pathA = ConfigurationManager.AppSettings["attactFile"].ToString();
            string pathServer = pathA + @"\crtSumScoreInWeek.rpt";

               Path.Add(@"~/Report/crtSumScoreInWeek.rpt");
               DataSet ds = new DataSet();
               switch (DClass)
               {
                   case  "B":
                     ds=dalS8R.QryTongDiem8STheoNgayThangClass_B(FromDate,ToDate);
                   break;
                   case "C":
                   ds = dalS8R.QryTongDiem8STheoNgayThangClass_C(FromDate, ToDate);
                   break;
                   case "D":
                   ds = dalS8R.QryTongDiem8STheoNgayThangClass_D(FromDate, ToDate);
                   break;
                   case "E":
                   ds = dalS8R.QryTongDiem8STheoNgayThangClass_E(FromDate, ToDate);
                   break;
               }
               Hashtable htb = new Hashtable();
               htb.Add("FromDate", FromDate.ToString("dd/MM/yyyy"));
               htb.Add("ToDate", ToDate.ToString("dd/MM/yyyy"));
               if (ds.Tables.Count > 0)
               {
                   ShowExecl(Path, ds, htb);
               }
            }
        }
    }
}