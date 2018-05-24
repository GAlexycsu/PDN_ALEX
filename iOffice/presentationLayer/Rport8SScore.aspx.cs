using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Globalization;
using System.Collections;

namespace iOffice.presentationLayer
{
    public partial class Rport8SScore : System.Web.UI.Page
    {
        Stem8SDAL dalType = new Stem8SDAL();
        S8recDAL dal8Rec = new S8recDAL();
        string Congty = ConfigurationManager.AppSettings["Congty"].ToString();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindYear();
                BindMonth();
                HienThiTuanTrenDropDown();
                LayTuanTheoNgayTren();
                DropDownDClass.SelectedValue = "E";
            }
        }
        public void HienThiTuanTrenDropDown()
        {
            string Year = DateTime.Today.Year.ToString();
            int CWeek = DateTime.Today.Month;
            string month ="";
            if (CWeek < 10)
            {
                month = "0" + CWeek.ToString();

            }
            else
            {
                month = CWeek.ToString();
            }
            DataTable dt = dal8Rec.LayTuanTrenERP(Year, month);
            if (dt.Rows.Count > 0)
            {
                DropDownWeek.DataSource = dt;
                DropDownWeek.DataValueField = "CWEEK";
                DropDownWeek.DataTextField = "CWEEK";
                DropDownWeek.DataBind();


            }
            dropDownYear.SelectedValue = Year;
            dropDownMonth.SelectedValue = month;
        }
        public void BindYear()
        {
            int year = DateTime.Today.Year;
            for (int i = year; i >= 2000; i--)
            {
                dropDownYear.Items.Add(i.ToString());
            }

        }
        public void BindMonth()
        {
            for (int i = 1; i <= 12; i++)
            {
                if (i < 10)
                {
                    dropDownMonth.Items.Add("0" + i.ToString());
                }
                else
                {
                    dropDownMonth.Items.Add(i.ToString());
                }
            }
        }
        private ArrayList getWeeks(int iYear, int iMonth)
        {
            //first
            int dem = 0;
            int countDays = DateTime.DaysInMonth(iYear, iMonth);
            ArrayList arrWeeks = new ArrayList();
            for (int i = 1; i <= countDays; i = i + 7)
            {
                string sStartDate = iMonth.ToString()
                + "/" + i.ToString()
                + "/" + iYear.ToString();
                DateTime dt_start = DateTime.Parse(sStartDate);
                DateTime dt_finish = dt_start.AddDays(7);

                dem = dem + 1;
                string sReturn = dt_start.ToShortDateString()
                + " - " + dt_finish.ToShortDateString();
                arrWeeks.Add(dem.ToString());
            }
            //zero-based array
            return arrWeeks;
        }
        public void LayNgayThangTheoTuan(string Year, string Month, string Week)
        {
            DataTable dt = dal8Rec.LayNgayThangTheoTuan(Year, Month, Week);
            if (dt.Rows.Count > 0)
            {
                txtFromDate.Text = DateTime.Parse(dt.Rows[0]["WDAY1"].ToString()).ToString("yyyy/MM/dd");
                txtToDate.Text = DateTime.Parse(dt.Rows[0]["WDAY2"].ToString()).ToString("yyyy/MM/dd");

           
                DropDownWeek.SelectedValue = Week;
            }
        }
        public void LayTuanTheoNgayTren()
        {
            string Year = DateTime.Today.Year.ToString();
            int CMonth = DateTime.Today.Month;
            string month = "";
            if (CMonth < 10)
            {
                month = "0" + CMonth.ToString();
            }
            else
            {
                month = CMonth.ToString();
            }
            DateTime date = DateTime.Today;
            string CWeek = DropDownWeek.SelectedValue;
            DataTable dt = dal8Rec.LayTuanThangTheoNgayTrenERP(Year, month, CWeek);
            if (dt.Rows.Count > 0)
            {
                txtFromDate.Text = DateTime.Parse(dt.Rows[0]["WDAY1"].ToString()).ToString("yyyy/MM/dd");
                txtToDate.Text = DateTime.Parse(dt.Rows[0]["WDAY2"].ToString()).ToString("yyyy/MM/dd");
                DropDownWeek.SelectedValue = dt.Rows[0]["CWEEK"].ToString();
               
            }
            else
            {
                DateTime date1 = DateTime.Today.AddDays(-4);
                DataTable dt1 = dal8Rec.LayTuanThangTheoNgayTrenERP(Year, month, CWeek);
                if (dt1.Rows.Count > 0)
                {
                    txtFromDate.Text = DateTime.Parse(dt1.Rows[0]["WDAY1"].ToString()).ToString("yyyy/MM/dd");
                    txtToDate.Text = DateTime.Parse(dt1.Rows[0]["WDAY2"].ToString()).ToString("yyyy/MM/dd");
                    DropDownWeek.SelectedValue = dt1.Rows[0]["CWEEK"].ToString();
                    
                }
            }
        }

        public int GetWeekOfMonth(DateTime date)
        {
            DateTime beginningOfMonth = new DateTime(date.Year, date.Month, 1);

            while (date.Date.AddDays(1).DayOfWeek != CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek)
                date = date.AddDays(1);

            return (int)Math.Truncate((double)date.Subtract(beginningOfMonth).TotalDays / 7f) + 1;
        }
        public int GetWeekNumber(DateTime now)
        {
            CultureInfo ci = CultureInfo.CurrentCulture;
            int weekNumber = ci.Calendar.GetWeekOfYear(now, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
            return weekNumber;
        }

        public void HienTHiNgayTheoTuan(string Week)
        {
            string Year = DateTime.Today.Year.ToString();
            string month = DateTime.Today.Month.ToString();

            DataTable dt = dal8Rec.LayTuanThangTheoTuanTrenERP(Year, month, Week);
            if (dt.Rows.Count > 0)
            {
                txtFromDate.Text = DateTime.Parse(dt.Rows[0]["WDAY1"].ToString()).ToString("yyyy/MM/dd");
                txtToDate.Text = DateTime.Parse(dt.Rows[0]["WDAY2"].ToString()).ToString("yyyy/MM/dd");
                DropDownWeek.SelectedValue = dt.Rows[0]["CWEEK"].ToString();
            }
        }
        protected void btnExport_Click(object sender, EventArgs e)
        {
            string UserID = (string)Session["UserID"];
            string DClass=DropDownDClass.SelectedValue;
            if (txtFromDate.Text.Trim() != "" && txtToDate.Text.Trim() != "" && UserID != null)
            {

                Response.Redirect("WF_ReportT.aspx?Type=BaoCaoTuan8S&UserID=" + UserID + "&FromDate=" + txtFromDate.Text.Trim() + "&ToDate=" + txtToDate.Text.Trim()+"&DClass="+DClass);
            }
        }

        protected void dropDownMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownWeek.Items.Clear();
            int year = int.Parse(dropDownYear.SelectedValue);
            int month = int.Parse(dropDownMonth.SelectedValue);
            ArrayList list = getWeeks(year, month);
            for (int i = 1; i <= list.Count; i++)
            {

                DropDownWeek.Items.Add(i.ToString());
            }
            string ID = DropDownWeek.SelectedValue;
            LayNgayThangTheoTuan(year.ToString(), month.ToString(), ID);
        }

        protected void DropDownWeek_SelectedIndexChanged(object sender, EventArgs e)
        {
            string year = dropDownYear.SelectedValue;
            string month = dropDownMonth.SelectedValue;
            string Week = DropDownWeek.SelectedValue;
            // HienTHiNgayTheoTuan(Week);
            LayNgayThangTheoTuan(year, month, Week);
        }
    }
}