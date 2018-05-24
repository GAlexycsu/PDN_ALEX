using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Xml;
using System.Xml.Linq;
using System.IO;
using iOffice.BUS;
using iOffice.DAO;
using iOffice.DTO;
using System.Globalization;
using System.Collections;
namespace iOffice.presentationLayer
{
    public partial class page8SDetail : LanguegeBus
    {
        Stem8SDAL dalType = new Stem8SDAL();
        S8recDAL dal8Rec = new S8recDAL();
        string Congty = ConfigurationManager.AppSettings["Congty"].ToString();
        protected void Page_Load(object sender, EventArgs e)
        {
            string UserID = (string)Session["UserID"];
            string ngonngu = (string)Session["languege"];
            if (UserID == null && ngonngu == null)
            {
                Response.Redirect("http://portal.footgear.com.vn/presentationLayer/Default.aspx");
            }
            else
            {
                LayngonNgu(41, ngonngu);
            }
            if (!IsPostBack)
            {
                Session.Remove("ThemThanhCong");
                BindYear();
                BindMonth();
                HienThiTuanTrenDropDown();
                LayTuanTheoNgayTren();
                PhanQuyen();
                //HienThiDropDonViERP();

                DropDownDonVi.Items.Insert(0, new ListItem("", "0"));
                string IDS8 = (string)Request["IDS8"];
                if (IDS8 != null)
                {
                    DropDownDonVi.SelectedValue = IDS8;
                    string RoleLogin = (string)Session["RoleLogin"];
                    if (RoleLogin != null)
                    {
                        switch (RoleLogin.Trim())
                        {
                            case "Full":
                                HienThiDanhSachTheoDieuKien1(IDS8);
                                break;
                            case "CR":
                                HienThiDanhSachTheoDieuKien1_CR(IDS8);
                                
                                break;
                            case "NS":
                                HienThiDanhSachTheoDieuKien1_NS(IDS8);
                                break;
                            case "TKTH":
                                HienThiDanhSachTheoDieuKien1_TKTH(IDS8);
                                break;
                        }
                    }
                   
                }
                else
                {
                   
                    HienThiDanhSachTheoDieuKienSession();
                }

              
               // btnConfirm.Attributes["OnClick"] = "return confirm('Are you sure?')";
                //txtFromDate.Text = DateTime.Today.AddDays(-6).ToString("yyyy/MM/dd");
                //txtToDate.Text = DateTime.Today.ToString("yyyy/MM/dd");

            }
        }
        public void HienThiTuanTrenDropDown()
        {
            string Year = DateTime.Today.Year.ToString();
            int CWeek = DateTime.Today.Month;
            string month="";
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
                
                //DateTime d = DateTime.Parse(dt.Rows[0]["WDAY1"].ToString()).AddDays(4);
                txtDate.Text = DateTime.Parse(dt.Rows[0]["WDAY1"].ToString()).ToString("yyyy/MM/dd");
                DropDownWeek.SelectedValue = Week;
            }
        }
        public void LayTuanTheoNgayTren()
        {
            string Year = DateTime.Today.Year.ToString();
            int Cmonth = DateTime.Today.Month;
            string month = "";
            if (Cmonth < 10)
            {
                month = "0" + Cmonth.ToString();
            }
            else
            {
                month = Cmonth.ToString();
            }
            DateTime date = DateTime.Today;
            string CWeek=DropDownWeek.SelectedValue;
            DataTable dt = dal8Rec.LayTuanThangTheoNgayTrenERP(Year, month,CWeek);
            if (dt.Rows.Count > 0)
            {
                txtFromDate.Text = DateTime.Parse(dt.Rows[0]["WDAY1"].ToString()).ToString("yyyy/MM/dd");
                txtToDate.Text = DateTime.Parse(dt.Rows[0]["WDAY2"].ToString()).ToString("yyyy/MM/dd");
                DropDownWeek.SelectedValue = dt.Rows[0]["CWEEK"].ToString();
              //  DateTime d = DateTime.Parse(dt.Rows[0]["WDAY1"].ToString()).AddDays(4);
                txtDate.Text = DateTime.Parse(dt.Rows[0]["WDAY1"].ToString()).ToString("yyyy/MM/dd");
            }
            else
            {
                DateTime date1 = DateTime.Today.AddDays(-4);
                DataTable dt1 = dal8Rec.LayTuanThangTheoNgayTrenERP(Year, month,CWeek);
                if (dt1.Rows.Count > 0)
                {
                    txtFromDate.Text = DateTime.Parse(dt1.Rows[0]["WDAY1"].ToString()).ToString("yyyy/MM/dd");
                    txtToDate.Text = DateTime.Parse(dt1.Rows[0]["WDAY2"].ToString()).ToString("yyyy/MM/dd");
                    DropDownWeek.SelectedValue = dt1.Rows[0]["CWEEK"].ToString();
                   // DateTime d = DateTime.Parse(dt.Rows[0]["WDAY1"].ToString()).AddDays(4);
                    txtDate.Text = DateTime.Parse(dt1.Rows[0]["WDAY1"].ToString()).ToString("yyyy/MM/dd");
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
    
        public void PhanQuyen()
        {
            string UserID = (string)Session["UserID"];
            string pathA = ConfigurationManager.AppSettings["attactFile"].ToString();
            string pathServer = pathA + @"\XMLFilePhanQuyen.xml";
            XDocument dov = XDocument.Load(pathServer);
            var list = dov.Root.Elements("PhanQuyenID").Where(p => p.Element("UserID").Value.Trim() == UserID).ToList();
            if (list.Count > 0)
            {
                foreach (var item in list)
                {
                    string RoleWrite = (string)item.Element("RoleWrite");
                    string RoleLogin = (string)item.Element("RoleLogin");
                    if (RoleLogin.Trim() != null)
                    {
                        Session["RoleLogin"] = RoleLogin.ToString();
                    }
                    btnAdd.Enabled = true;
                    btnAdd.Attributes.CssStyle.Add("opacity", "100");
                    lblQuyen.Text = "GHi";

                    btnAdd1Row.Enabled = true;
                    btnAdd1Row.Attributes.CssStyle.Add("opacity", "100");
                    if (RoleWrite.Trim() == "1")
                    {
                        
                        btnConfirm.Enabled = true;
                        btnConfirm.Attributes.CssStyle.Add("opacity", "100");
                        checkCreate.Enabled = false;
                        checkCreate.Visible = false;
                        checkConfirm.Enabled = true;
                        checkConfirm.Visible = true;
                        HienThiDropDownDonViCuaCanBo(false);
                        btnCopyDiem.Visible = false;
                    }
                    else
                    {
                        btnConfirm.Enabled = false;
                        btnConfirm.Attributes.CssStyle.Add("opacity", "0.3");
                        checkCreate.Enabled = true;
                        checkCreate.Visible = true;
                        checkConfirm.Enabled = false;
                        checkConfirm.Visible = false;
                        HienThiDropDonViCuaNhanVien(false);
                        btnCopyDiem.Visible = true;
                    }
                }
            }
            else
            {
                btnAdd.Enabled = false;
                btnAdd.Attributes.CssStyle.Add("opacity", "0.3");
                btnConfirm.Enabled = false;
                btnConfirm.Attributes.CssStyle.Add("opacity", "0.3");
                btnAdd1Row.Enabled = false;
                btnAdd1Row.Attributes.CssStyle.Add("opacity", "0.3");
                btnQuery.Enabled = false;
                btnQuery.Attributes.CssStyle.Add("opacity", "0.3");
                checkCreate.Enabled = false;
                checkConfirm.Enabled = false;
                btnGetData.Enabled = false;
                btnGetData.Attributes.CssStyle.Add("opacity", "0.3");
                btnExportDepart.Attributes.CssStyle.Add("opacity", "0.3");
                btnExportDepart.Enabled = false;
            }

        }

        public void HienThiDropDonViCuaNhanVien(bool check)
        {
            DateTime date = DateTime.Parse(txtDate.Text.Trim());
            string RoleLogin = (string)Session["RoleLogin"];

              if (check == false)
              {
                  if (RoleLogin != null)
                  {
                      if (RoleLogin.Trim() == "CR")
                      {
                          DataTable dt = dal8Rec.HienThiDanhSachChuaTaoCuaNhanVienCR(Congty, date);
                          DropDownDonVi.DataSource = dt;
                          DropDownDonVi.DataValueField = "ID";
                          DropDownDonVi.DataTextField = "DepName";
                          DropDownDonVi.DataBind();
                      }
                      else
                      {
                          if (RoleLogin.Trim() == "NS")
                          {
                              DataTable dt = dal8Rec.HienThiDanhSachChuaTaoCuaNhanVienNS(Congty, date);
                              DropDownDonVi.DataSource = dt;
                              DropDownDonVi.DataValueField = "ID";
                              DropDownDonVi.DataTextField = "DepName";
                              DropDownDonVi.DataBind();
                          }
                          else
                          {
                              DataTable dt = dal8Rec.HienThiDanhSachChuaTaoCuaNhanVienTKTH(Congty, date);
                              DropDownDonVi.DataSource = dt;
                              DropDownDonVi.DataValueField = "ID";
                              DropDownDonVi.DataTextField = "DepName";
                              DropDownDonVi.DataBind();
                          }
                      }
                  }
                  

              }
              else
              {
                  if (RoleLogin.Trim() != null)
                  {
                      if (RoleLogin.Trim() == "NS")
                      {
                          DataTable dt = dal8Rec.HienThiDanhSachDaTaoTaoCuaNhanVienNS(Congty, date);
                          DropDownDonVi.DataSource = dt;
                          DropDownDonVi.DataValueField = "ID";
                          DropDownDonVi.DataTextField = "DepName";
                          DropDownDonVi.DataBind();
                      }
                      else
                      {
                          if (RoleLogin.Trim() == "CR")
                          {
                              DataTable dt = dal8Rec.HienThiDanhSachDaTaoTaoCuaNhanVienCR(Congty, date);
                              DropDownDonVi.DataSource = dt;
                              DropDownDonVi.DataValueField = "ID";
                              DropDownDonVi.DataTextField = "DepName";
                              DropDownDonVi.DataBind();
                          }
                          else
                          {
                              DataTable dt = dal8Rec.HienThiDanhSachDaTaoTaoCuaNhanVienTKTH(Congty, date);
                              DropDownDonVi.DataSource = dt;
                              DropDownDonVi.DataValueField = "ID";
                              DropDownDonVi.DataTextField = "DepName";
                              DropDownDonVi.DataBind();
                          }
                      }
                  }
                 

              }
        }
        public void HienThiDropDownDonViCuaCanBo(bool check)
        {
            DateTime Date=DateTime.Parse(txtDate.Text.Trim());
            
            if (check == false)
            {
                DataTable dt = dal8Rec.HienThiDanhSachDonViChuaChuyenCuaCanBo(Congty, Date);
                DropDownDonVi.DataSource = dt;
                DropDownDonVi.DataValueField = "ID";
                DropDownDonVi.DataTextField = "DepName";
                DropDownDonVi.DataBind();
            }
            else
            {
                DataTable dt = dal8Rec.HienThiDanhSachDonViDaChuyenCuaCanBo(Congty,Date);
                DropDownDonVi.DataSource = dt;
                DropDownDonVi.DataValueField = "ID";
                DropDownDonVi.DataTextField = "DepName";
                DropDownDonVi.DataBind();
            }
        }
        public void HienThiDanhSachTheoDieuKien()
        {

            string tungay = txtFromDate.Text.Trim();
            string denngay = txtToDate.Text.Trim();
            DateTime FromDate;
            DateTime ToDate;
            string DepartID = DropDownDonVi.SelectedValue;

            if (tungay != "" && denngay != "" && DepartID != "0")
            {

                try
                {
                    FromDate = DateTime.Parse(tungay);
                    ToDate = DateTime.Parse(denngay);
                }
                catch
                {
                    FromDate = DateTime.Today.AddDays(-7);
                    ToDate = DateTime.Today;
                }
                string ngonngu = Session["languege"].ToString();
                if (ngonngu == "lbl_VN")
                {
                    DataTable dt = dalType.QryPhieu8TheoDieuKienVN1(FromDate, ToDate, DepartID);
                    if (dt.Rows.Count > 0)
                    {
                        divScore.Visible = true;
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                        Session["SFromDate"] = FromDate.ToString();
                        Session["SToDate"] = ToDate.ToString();
                        Session["SDepartID"] = DepartID.ToString();
                    }
                    else
                    {
                        GridView1.DataSource = null;
                        GridView1.DataBind();
                        divScore.Visible = false;
                    }
                }
                else if (ngonngu == "lbl_TW")
                {
                    DataTable dt = dalType.QryPhieu8TheoDieuKienTW1(FromDate, ToDate, DepartID);
                    if (dt.Rows.Count > 0)
                    {
                        divScore.Visible = true;
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                        Session["SFromDate"] = FromDate.ToString();
                        Session["SToDate"] = ToDate.ToString();
                        Session["SDepartID"] = DepartID.ToString();
                    }
                    else
                    {
                        GridView1.DataSource = null;
                        GridView1.DataBind();
                        divScore.Visible = false;
                    }
                }
                else if (ngonngu == "lbl_EN")
                {
                    DataTable dt = dalType.QryPhieu8TheoDieuKienEN1(FromDate, ToDate, DepartID);
                    if (dt.Rows.Count > 0)
                    {
                        divScore.Visible = true;
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                        Session["SFromDate"] = FromDate.ToString();
                        Session["SToDate"] = ToDate.ToString();
                        Session["SDepartID"] = DepartID.ToString();
                    }
                    else
                    {
                        GridView1.DataSource = null;
                        GridView1.DataBind();
                        divScore.Visible = false;
                    }
                }
                DataTable dtDiem = dalType.LayTongDiemTheoDonVi(DepartID, FromDate, ToDate);
                if (dtDiem.Rows.Count > 0)
                {
                    divScore.Visible = true;
                    string donvi = dtDiem.Rows[0]["depid"].ToString();
                    //lblDiemChuan.Text = "100 ";
                    decimal diem;
                    try
                    {
                        diem = decimal.Parse(dtDiem.Rows[0]["sub_score"].ToString());
                    }
                    catch
                    {
                        diem = 0;
                    }
                    decimal d;
                    DataTable dem = dalType.DemSoNgayDeTinhDiem(DepartID, FromDate, ToDate);
                    if (dem.Rows.Count > 0)
                    {

                        try
                        {
                            d = decimal.Parse(dem.Rows[0]["S8date"].ToString());
                        }
                        catch
                        {
                            d = 0;
                        }
                    }
                    else
                    {
                        d = 0;
                    }
                    decimal diem8s = diem / d;
                    lblDiem.Text = diem8s.ToString();
                    decimal diemchuan;
                    try
                    {
                        diemchuan = decimal.Parse(dtDiem.Rows[0]["Sitemscore"].ToString());
                    }
                    catch
                    {
                        diemchuan = 0;
                    }
                    decimal diemc = diemchuan / d;
                    lblDiemChuan.Text = diemc.ToString();
                }
                else
                {
                    divScore.Visible = false;
                }
            }
            else
            {

                FromDate = DateTime.Today.AddDays(-7);
                ToDate = DateTime.Today;
                string ngonngu = Session["languege"].ToString();
                if (ngonngu == "lbl_VN")
                {
                    DataTable dt = dalType.QryPhieu8TheoDieuKienVN1(FromDate, ToDate, DepartID);
                    if (dt.Rows.Count > 0)
                    {
                        divScore.Visible = true;
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                        Session["SFromDate"] = FromDate.ToString();
                        Session["SToDate"] = ToDate.ToString();
                        Session["SDepartID"] = DepartID.ToString();
                    }
                    else
                    {
                        GridView1.DataSource = null;
                        GridView1.DataBind();
                        divScore.Visible = false;
                    }
                }
                else if (ngonngu == "lbl_TW")
                {
                    DataTable dt = dalType.QryPhieu8TheoDieuKienTW1(FromDate, ToDate, DepartID);
                    if (dt.Rows.Count > 0)
                    {
                        divScore.Visible = true;
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                        Session["SFromDate"] = FromDate.ToString();
                        Session["SToDate"] = ToDate.ToString();
                        Session["SDepartID"] = DepartID.ToString();
                    }
                    else
                    {
                        GridView1.DataSource = null;
                        GridView1.DataBind();
                        divScore.Visible = false;
                    }
                }
                else if (ngonngu == "lbl_EN")
                {
                    DataTable dt = dalType.QryPhieu8TheoDieuKienEN1(FromDate, ToDate, DepartID);
                    if (dt.Rows.Count > 0)
                    {
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                        Session["SFromDate"] = FromDate.ToString();
                        Session["SToDate"] = ToDate.ToString();
                        Session["SDepartID"] = DepartID.ToString();
                        divScore.Visible = true;




                    }
                    else
                    {
                        GridView1.DataSource = null;
                        GridView1.DataBind();
                        divScore.Visible = false;
                    }
                }
                DataTable dtDiem = dalType.LayTongDiemTheoDonVi(DepartID, FromDate, ToDate);
                if (dtDiem.Rows.Count > 0)
                {
                    divScore.Visible = true;
                    string donvi = dtDiem.Rows[0]["depid"].ToString();
                    //lblDiemChuan.Text = "100 ";
                    decimal diem;
                    try
                    {
                        diem = decimal.Parse(dtDiem.Rows[0]["sub_score"].ToString());
                    }
                    catch
                    {
                        diem = 0;
                    }
                    decimal d;
                    DataTable dem = dalType.DemSoNgayDeTinhDiem(DepartID, FromDate, ToDate);
                    if (dem.Rows.Count > 0)
                    {

                        try
                        {
                            d = decimal.Parse(dem.Rows[0]["S8date"].ToString());
                        }
                        catch
                        {
                            d = 0;
                        }
                    }
                    else
                    {
                        d = 0;
                    }
                    decimal diem8s = diem / d;
                    lblDiem.Text = diem8s.ToString();
                    decimal diemchuan;
                    try
                    {
                        diemchuan = decimal.Parse(dtDiem.Rows[0]["Sitemscore"].ToString());
                    }
                    catch
                    {
                        diemchuan = 0;
                    }
                    decimal diemc = diemchuan / d;
                    lblDiemChuan.Text = diemc.ToString();
                }
                else
                {
                    divScore.Visible = false;
                }
            }

        }
        public void HienThiDanhSachTheoDieuKien_CR()
        {

            string tungay = txtFromDate.Text.Trim();
            string denngay = txtToDate.Text.Trim();
            DateTime FromDate;
            DateTime ToDate;
            string DepartID = DropDownDonVi.SelectedValue;

            if (tungay != "" && denngay != "" && DepartID != "0")
            {

                try
                {
                    FromDate = DateTime.Parse(tungay);
                    ToDate = DateTime.Parse(denngay);
                }
                catch
                {
                    FromDate = DateTime.Today.AddDays(-7);
                    ToDate = DateTime.Today;
                }
                string ngonngu = Session["languege"].ToString();
                if (ngonngu == "lbl_VN")
                {
                    DataTable dt = dalType.QryPhieu8TheoDieuKienVN1_CR(FromDate, ToDate, DepartID);
                    if (dt.Rows.Count > 0)
                    {
                        divScore.Visible = true;
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                        Session["SFromDate"] = FromDate.ToString();
                        Session["SToDate"] = ToDate.ToString();
                        Session["SDepartID"] = DepartID.ToString();
                    }
                    else
                    {
                        GridView1.DataSource = null;
                        GridView1.DataBind();
                        divScore.Visible = false;
                    }
                }
                else if (ngonngu == "lbl_TW")
                {
                    DataTable dt = dalType.QryPhieu8TheoDieuKienTW1_CR(FromDate, ToDate, DepartID);
                    if (dt.Rows.Count > 0)
                    {
                        divScore.Visible = true;
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                        Session["SFromDate"] = FromDate.ToString();
                        Session["SToDate"] = ToDate.ToString();
                        Session["SDepartID"] = DepartID.ToString();
                    }
                    else
                    {
                        GridView1.DataSource = null;
                        GridView1.DataBind();
                        divScore.Visible = false;
                    }
                }
                else if (ngonngu == "lbl_EN")
                {
                    DataTable dt = dalType.QryPhieu8TheoDieuKienEN1_CR(FromDate, ToDate, DepartID);
                    if (dt.Rows.Count > 0)
                    {
                        divScore.Visible = true;
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                        Session["SFromDate"] = FromDate.ToString();
                        Session["SToDate"] = ToDate.ToString();
                        Session["SDepartID"] = DepartID.ToString();
                    }
                    else
                    {
                        GridView1.DataSource = null;
                        GridView1.DataBind();
                        divScore.Visible = false;
                    }
                }
                DataTable dtDiem = dalType.LayTongDiemTheoDonVi_CR(DepartID, FromDate, ToDate);
                if (dtDiem.Rows.Count > 0)
                {
                    divScore.Visible = true;
                    string donvi = dtDiem.Rows[0]["depid"].ToString();
                    //lblDiemChuan.Text = "100 ";
                    decimal diem;
                    try
                    {
                        diem = decimal.Parse(dtDiem.Rows[0]["sub_score"].ToString());
                    }
                    catch
                    {
                        diem = 0;
                    }
                    decimal d;
                    DataTable dem = dalType.DemSoNgayDeTinhDiem(DepartID, FromDate, ToDate);
                    if (dem.Rows.Count > 0)
                    {

                        try
                        {
                            d = decimal.Parse(dem.Rows[0]["S8date"].ToString());
                        }
                        catch
                        {
                            d = 0;
                        }
                    }
                    else
                    {
                        d = 0;
                    }
                    decimal diem8s = diem / d;
                    lblDiem.Text = diem8s.ToString();
                    decimal diemchuan;
                    try
                    {
                        diemchuan = decimal.Parse(dtDiem.Rows[0]["Sitemscore"].ToString());
                    }
                    catch
                    {
                        diemchuan = 0;
                    }
                    decimal diemc = diemchuan / d;
                    lblDiemChuan.Text = diemc.ToString();
                }
                else
                {
                    divScore.Visible = false;
                }
            }
            else
            {

                FromDate = DateTime.Today.AddDays(-7);
                ToDate = DateTime.Today;
                string ngonngu = Session["languege"].ToString();
                if (ngonngu == "lbl_VN")
                {
                    DataTable dt = dalType.QryPhieu8TheoDieuKienVN1_CR(FromDate, ToDate, DepartID);
                    if (dt.Rows.Count > 0)
                    {
                        divScore.Visible = true;
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                        Session["SFromDate"] = FromDate.ToString();
                        Session["SToDate"] = ToDate.ToString();
                        Session["SDepartID"] = DepartID.ToString();
                    }
                    else
                    {
                        GridView1.DataSource = null;
                        GridView1.DataBind();
                        divScore.Visible = false;
                    }
                }
                else if (ngonngu == "lbl_TW")
                {
                    DataTable dt = dalType.QryPhieu8TheoDieuKienTW1_CR(FromDate, ToDate, DepartID);
                    if (dt.Rows.Count > 0)
                    {
                        divScore.Visible = true;
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                        Session["SFromDate"] = FromDate.ToString();
                        Session["SToDate"] = ToDate.ToString();
                        Session["SDepartID"] = DepartID.ToString();
                    }
                    else
                    {
                        GridView1.DataSource = null;
                        GridView1.DataBind();
                        divScore.Visible = false;
                    }
                }
                else if (ngonngu == "lbl_EN")
                {
                    DataTable dt = dalType.QryPhieu8TheoDieuKienEN1_CR(FromDate, ToDate, DepartID);
                    if (dt.Rows.Count > 0)
                    {
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                        Session["SFromDate"] = FromDate.ToString();
                        Session["SToDate"] = ToDate.ToString();
                        Session["SDepartID"] = DepartID.ToString();
                        divScore.Visible = true;




                    }
                    else
                    {
                        GridView1.DataSource = null;
                        GridView1.DataBind();
                        divScore.Visible = false;
                    }
                }
                DataTable dtDiem = dalType.LayTongDiemTheoDonVi_CR(DepartID, FromDate, ToDate);
                if (dtDiem.Rows.Count > 0)
                {
                    divScore.Visible = true;
                    string donvi = dtDiem.Rows[0]["depid"].ToString();
                    //lblDiemChuan.Text = "100 ";
                    decimal diem;
                    try
                    {
                        diem = decimal.Parse(dtDiem.Rows[0]["sub_score"].ToString());
                    }
                    catch
                    {
                        diem = 0;
                    }
                    decimal d;
                    DataTable dem = dalType.DemSoNgayDeTinhDiem(DepartID, FromDate, ToDate);
                    if (dem.Rows.Count > 0)
                    {

                        try
                        {
                            d = decimal.Parse(dem.Rows[0]["S8date"].ToString());
                        }
                        catch
                        {
                            d = 0;
                        }
                    }
                    else
                    {
                        d = 0;
                    }
                    decimal diem8s = diem / d;
                    lblDiem.Text = diem8s.ToString();
                    decimal diemchuan;
                    try
                    {
                        diemchuan = decimal.Parse(dtDiem.Rows[0]["Sitemscore"].ToString());
                    }
                    catch
                    {
                        diemchuan = 0;
                    }
                    decimal diemc = diemchuan / d;
                    lblDiemChuan.Text = diemc.ToString();
                }
                else
                {
                    divScore.Visible = false;
                }
            }

        }
        public void HienThiDanhSachTheoDieuKien_NS()
        {

            string tungay = txtFromDate.Text.Trim();
            string denngay = txtToDate.Text.Trim();
            DateTime FromDate;
            DateTime ToDate;
            string DepartID = DropDownDonVi.SelectedValue;

            if (tungay != "" && denngay != "" && DepartID != "0")
            {

                try
                {
                    FromDate = DateTime.Parse(tungay);
                    ToDate = DateTime.Parse(denngay);
                }
                catch
                {
                    FromDate = DateTime.Today.AddDays(-7);
                    ToDate = DateTime.Today;
                }
                string ngonngu = Session["languege"].ToString();
                if (ngonngu == "lbl_VN")
                {
                    DataTable dt = dalType.QryPhieu8TheoDieuKienVN1_NS(FromDate, ToDate, DepartID);
                    if (dt.Rows.Count > 0)
                    {
                        divScore.Visible = true;
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                        Session["SFromDate"] = FromDate.ToString();
                        Session["SToDate"] = ToDate.ToString();
                        Session["SDepartID"] = DepartID.ToString();
                    }
                    else
                    {
                        GridView1.DataSource = null;
                        GridView1.DataBind();
                        divScore.Visible = false;
                    }
                }
                else if (ngonngu == "lbl_TW")
                {
                    DataTable dt = dalType.QryPhieu8TheoDieuKienTW1_NS(FromDate, ToDate, DepartID);
                    if (dt.Rows.Count > 0)
                    {
                        divScore.Visible = true;
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                        Session["SFromDate"] = FromDate.ToString();
                        Session["SToDate"] = ToDate.ToString();
                        Session["SDepartID"] = DepartID.ToString();
                    }
                    else
                    {
                        GridView1.DataSource = null;
                        GridView1.DataBind();
                        divScore.Visible = false;
                    }
                }
                else if (ngonngu == "lbl_EN")
                {
                    DataTable dt = dalType.QryPhieu8TheoDieuKienEN1_NS(FromDate, ToDate, DepartID);
                    if (dt.Rows.Count > 0)
                    {
                        divScore.Visible = true;
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                        Session["SFromDate"] = FromDate.ToString();
                        Session["SToDate"] = ToDate.ToString();
                        Session["SDepartID"] = DepartID.ToString();
                    }
                    else
                    {
                        GridView1.DataSource = null;
                        GridView1.DataBind();
                        divScore.Visible = false;
                    }
                }
                DataTable dtDiem = dalType.LayTongDiemTheoDonVi_NS(DepartID, FromDate, ToDate);
                if (dtDiem.Rows.Count > 0)
                {
                    divScore.Visible = true;
                    string donvi = dtDiem.Rows[0]["depid"].ToString();
                    lblDiemChuan.Text = "100 ";
                    decimal diem;
                    try
                    {
                        diem = decimal.Parse(dtDiem.Rows[0]["sub_score"].ToString());
                    }
                    catch
                    {
                        diem = 0;
                    }
                    decimal d;
                    DataTable dem = dalType.DemSoNgayDeTinhDiem(DepartID, FromDate, ToDate);
                    if (dem.Rows.Count > 0)
                    {

                        try
                        {
                            d = decimal.Parse(dem.Rows[0]["S8date"].ToString());
                        }
                        catch
                        {
                            d = 0;
                        }
                    }
                    else
                    {
                        d = 0;
                    }
                    decimal diem8s = diem / d;
                    lblDiem.Text = diem8s.ToString();
                    decimal diemchuan;
                    try
                    {
                        diemchuan = decimal.Parse(dtDiem.Rows[0]["Sitemscore"].ToString());
                    }
                    catch
                    {
                        diemchuan = 0;
                    }
                    decimal diemc = diemchuan / d;
                    lblDiemChuan.Text = diemc.ToString();
                }
                else
                {
                    divScore.Visible = false;
                }
            }
            else
            {

                FromDate = DateTime.Today.AddDays(-7);
                ToDate = DateTime.Today;
                string ngonngu = Session["languege"].ToString();
                if (ngonngu == "lbl_VN")
                {
                    DataTable dt = dalType.QryPhieu8TheoDieuKienVN1_NS(FromDate, ToDate, DepartID);
                    if (dt.Rows.Count > 0)
                    {
                        divScore.Visible = true;
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                        Session["SFromDate"] = FromDate.ToString();
                        Session["SToDate"] = ToDate.ToString();
                        Session["SDepartID"] = DepartID.ToString();
                    }
                    else
                    {
                        GridView1.DataSource = null;
                        GridView1.DataBind();
                        divScore.Visible = false;
                    }
                }
                else if (ngonngu == "lbl_TW")
                {
                    DataTable dt = dalType.QryPhieu8TheoDieuKienTW1_NS(FromDate, ToDate, DepartID);
                    if (dt.Rows.Count > 0)
                    {
                        divScore.Visible = true;
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                        Session["SFromDate"] = FromDate.ToString();
                        Session["SToDate"] = ToDate.ToString();
                        Session["SDepartID"] = DepartID.ToString();
                    }
                    else
                    {
                        GridView1.DataSource = null;
                        GridView1.DataBind();
                        divScore.Visible = false;
                    }
                }
                else if (ngonngu == "lbl_EN")
                {
                    DataTable dt = dalType.QryPhieu8TheoDieuKienEN1_NS(FromDate, ToDate, DepartID);
                    if (dt.Rows.Count > 0)
                    {
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                        Session["SFromDate"] = FromDate.ToString();
                        Session["SToDate"] = ToDate.ToString();
                        Session["SDepartID"] = DepartID.ToString();
                        divScore.Visible = true;




                    }
                    else
                    {
                        GridView1.DataSource = null;
                        GridView1.DataBind();
                        divScore.Visible = false;
                    }
                }
                DataTable dtDiem = dalType.LayTongDiemTheoDonVi_NS(DepartID, FromDate, ToDate);
                if (dtDiem.Rows.Count > 0)
                {
                    divScore.Visible = true;
                    string donvi = dtDiem.Rows[0]["depid"].ToString();
                    lblDiemChuan.Text = "100 ";
                    decimal diem;
                    try
                    {
                        diem = decimal.Parse(dtDiem.Rows[0]["sub_score"].ToString());
                    }
                    catch
                    {
                        diem = 0;
                    }
                    decimal d;
                    DataTable dem = dalType.DemSoNgayDeTinhDiem(DepartID, FromDate, ToDate);
                    if (dem.Rows.Count > 0)
                    {

                        try
                        {
                            d = decimal.Parse(dem.Rows[0]["S8date"].ToString());
                        }
                        catch
                        {
                            d = 0;
                        }
                    }
                    else
                    {
                        d = 0;
                    }
                    decimal diem8s = diem / d;
                    lblDiem.Text = diem8s.ToString();
                    decimal diemchuan;
                    try
                    {
                        diemchuan = decimal.Parse(dtDiem.Rows[0]["Sitemscore"].ToString());
                    }
                    catch
                    {
                        diemchuan = 0;
                    }
                    decimal diemc = diemchuan / d;
                    lblDiemChuan.Text = diemc.ToString();
                }
                else
                {
                    divScore.Visible = false;
                }
            }

        }
        public void HienThiDanhSachTheoDieuKien_TKTH()
        {

            string tungay = txtFromDate.Text.Trim();
            string denngay = txtToDate.Text.Trim();
            DateTime FromDate;
            DateTime ToDate;
            string DepartID = DropDownDonVi.SelectedValue;

            if (tungay != "" && denngay != "" && DepartID != "0")
            {

                try
                {
                    FromDate = DateTime.Parse(tungay);
                    ToDate = DateTime.Parse(denngay);
                }
                catch
                {
                    FromDate = DateTime.Today.AddDays(-7);
                    ToDate = DateTime.Today;
                }
                string ngonngu = Session["languege"].ToString();
                if (ngonngu == "lbl_VN")
                {
                    DataTable dt = dalType.QryPhieu8TheoDieuKienVN1_TKTH(FromDate, ToDate, DepartID);
                    if (dt.Rows.Count > 0)
                    {
                        divScore.Visible = true;
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                        Session["SFromDate"] = FromDate.ToString();
                        Session["SToDate"] = ToDate.ToString();
                        Session["SDepartID"] = DepartID.ToString();
                    }
                    else
                    {
                        GridView1.DataSource = null;
                        GridView1.DataBind();
                        divScore.Visible = false;
                    }
                }
                else if (ngonngu == "lbl_TW")
                {
                    DataTable dt = dalType.QryPhieu8TheoDieuKienTW1_TKTH(FromDate, ToDate, DepartID);
                    if (dt.Rows.Count > 0)
                    {
                        divScore.Visible = true;
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                        Session["SFromDate"] = FromDate.ToString();
                        Session["SToDate"] = ToDate.ToString();
                        Session["SDepartID"] = DepartID.ToString();
                    }
                    else
                    {
                        GridView1.DataSource = null;
                        GridView1.DataBind();
                        divScore.Visible = false;
                    }
                }
                else if (ngonngu == "lbl_EN")
                {
                    DataTable dt = dalType.QryPhieu8TheoDieuKienEN1_TKTH(FromDate, ToDate, DepartID);
                    if (dt.Rows.Count > 0)
                    {
                        divScore.Visible = true;
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                        Session["SFromDate"] = FromDate.ToString();
                        Session["SToDate"] = ToDate.ToString();
                        Session["SDepartID"] = DepartID.ToString();
                    }
                    else
                    {
                        GridView1.DataSource = null;
                        GridView1.DataBind();
                        divScore.Visible = false;
                    }
                }
                DataTable dtDiem = dalType.LayTongDiemTheoDonVi_TKTH(DepartID, FromDate, ToDate);
                if (dtDiem.Rows.Count > 0)
                {
                    divScore.Visible = true;
                    string donvi = dtDiem.Rows[0]["depid"].ToString();
                    lblDiemChuan.Text = "100 ";
                    decimal diem;
                    try
                    {
                        diem = decimal.Parse(dtDiem.Rows[0]["sub_score"].ToString());
                    }
                    catch
                    {
                        diem = 0;
                    }
                    decimal d;
                    DataTable dem = dalType.DemSoNgayDeTinhDiem(DepartID, FromDate, ToDate);
                    if (dem.Rows.Count > 0)
                    {

                        try
                        {
                            d = decimal.Parse(dem.Rows[0]["S8date"].ToString());
                        }
                        catch
                        {
                            d = 0;
                        }
                    }
                    else
                    {
                        d = 0;
                    }
                    decimal diem8s = diem / d;
                    lblDiem.Text = diem8s.ToString();
                    decimal diemchuan;
                    try
                    {
                        diemchuan = decimal.Parse(dtDiem.Rows[0]["Sitemscore"].ToString());
                    }
                    catch
                    {
                        diemchuan = 0;
                    }
                    decimal diemc = diemchuan / d;
                    lblDiemChuan.Text = diemc.ToString();
                }
                else
                {
                    divScore.Visible = false;
                }
            }
            else
            {

                FromDate = DateTime.Today.AddDays(-7);
                ToDate = DateTime.Today;
                string ngonngu = Session["languege"].ToString();
                if (ngonngu == "lbl_VN")
                {
                    DataTable dt = dalType.QryPhieu8TheoDieuKienVN1_TKTH(FromDate, ToDate, DepartID);
                    if (dt.Rows.Count > 0)
                    {
                        divScore.Visible = true;
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                        Session["SFromDate"] = FromDate.ToString();
                        Session["SToDate"] = ToDate.ToString();
                        Session["SDepartID"] = DepartID.ToString();
                    }
                    else
                    {
                        GridView1.DataSource = null;
                        GridView1.DataBind();
                        divScore.Visible = false;
                    }
                }
                else if (ngonngu == "lbl_TW")
                {
                    DataTable dt = dalType.QryPhieu8TheoDieuKienTW1_TKTH(FromDate, ToDate, DepartID);
                    if (dt.Rows.Count > 0)
                    {
                        divScore.Visible = true;
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                        Session["SFromDate"] = FromDate.ToString();
                        Session["SToDate"] = ToDate.ToString();
                        Session["SDepartID"] = DepartID.ToString();
                    }
                    else
                    {
                        GridView1.DataSource = null;
                        GridView1.DataBind();
                        divScore.Visible = false;
                    }
                }
                else if (ngonngu == "lbl_EN")
                {
                    DataTable dt = dalType.QryPhieu8TheoDieuKienEN1_TKTH(FromDate, ToDate, DepartID);
                    if (dt.Rows.Count > 0)
                    {
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                        Session["SFromDate"] = FromDate.ToString();
                        Session["SToDate"] = ToDate.ToString();
                        Session["SDepartID"] = DepartID.ToString();
                        divScore.Visible = true;




                    }
                    else
                    {
                        GridView1.DataSource = null;
                        GridView1.DataBind();
                        divScore.Visible = false;
                    }
                }
                DataTable dtDiem = dalType.LayTongDiemTheoDonVi_TKTH(DepartID, FromDate, ToDate);
                if (dtDiem.Rows.Count > 0)
                {
                    divScore.Visible = true;
                    string donvi = dtDiem.Rows[0]["depid"].ToString();
                    lblDiemChuan.Text = "100 ";
                    decimal diem;
                    try
                    {
                        diem = decimal.Parse(dtDiem.Rows[0]["sub_score"].ToString());
                    }
                    catch
                    {
                        diem = 0;
                    }
                    decimal d;
                    DataTable dem = dalType.DemSoNgayDeTinhDiem(DepartID, FromDate, ToDate);
                    if (dem.Rows.Count > 0)
                    {

                        try
                        {
                            d = decimal.Parse(dem.Rows[0]["S8date"].ToString());
                        }
                        catch
                        {
                            d = 0;
                        }
                    }
                    else
                    {
                        d = 0;
                    }
                    decimal diem8s = diem / d;
                    lblDiem.Text = diem8s.ToString();
                    decimal diemchuan;
                    try
                    {
                        diemchuan = decimal.Parse(dtDiem.Rows[0]["Sitemscore"].ToString());
                    }
                    catch
                    {
                        diemchuan = 0;
                    }
                    decimal diemc = diemchuan / d;
                    lblDiemChuan.Text = diemc.ToString();
                }
                else
                {
                    divScore.Visible = false;
                }
            }

        }
        public void HienThiDanhSachTheoDieuKien1(string DepartID)
        {

            string tungay = txtFromDate.Text.Trim();
            string denngay = txtToDate.Text.Trim();
            DateTime FromDate;
            DateTime ToDate;

            if (tungay != "" && denngay != "" && DepartID != "0")
            {

                try
                {
                    FromDate = DateTime.Parse(tungay);
                    ToDate = DateTime.Parse(denngay);
                }
                catch
                {
                    FromDate = DateTime.Today.AddDays(-7);
                    ToDate = DateTime.Today;
                }
                string ngonngu = Session["languege"].ToString();
                if (ngonngu == "lbl_VN")
                {
                    DataTable dt = dalType.QryPhieu8TheoDieuKienVN1(FromDate, ToDate, DepartID);
                    if (dt.Rows.Count > 0)
                    {
                        divScore.Visible = true;
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                        Session["SFromDate"] = FromDate.ToString();
                        Session["SToDate"] = ToDate.ToString();
                        Session["SDepartID"] = DepartID.ToString();
                    }
                    else
                    {
                        GridView1.DataSource = null;
                        GridView1.DataBind();
                        divScore.Visible = false;
                    }
                }
                else if (ngonngu == "lbl_TW")
                {
                    DataTable dt = dalType.QryPhieu8TheoDieuKienTW1(FromDate, ToDate, DepartID);
                    if (dt.Rows.Count > 0)
                    {
                        divScore.Visible = true;
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                        Session["SFromDate"] = FromDate.ToString();
                        Session["SToDate"] = ToDate.ToString();
                        Session["SDepartID"] = DepartID.ToString();
                    }
                    else
                    {
                        GridView1.DataSource = null;
                        GridView1.DataBind();
                        divScore.Visible = false;
                    }
                }
                else if (ngonngu == "lbl_EN")
                {
                    DataTable dt = dalType.QryPhieu8TheoDieuKienEN1(FromDate, ToDate, DepartID);
                    if (dt.Rows.Count > 0)
                    {
                        divScore.Visible = true;
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                        Session["SFromDate"] = FromDate.ToString();
                        Session["SToDate"] = ToDate.ToString();
                        Session["SDepartID"] = DepartID.ToString();
                    }
                    else
                    {
                        GridView1.DataSource = null;
                        GridView1.DataBind();
                        divScore.Visible = false;
                    }
                }
                DataTable dtDiem = dalType.LayTongDiemTheoDonVi(DepartID, FromDate, ToDate);
                if (dtDiem.Rows.Count > 0)
                {
                    divScore.Visible = true;
                    string donvi = dtDiem.Rows[0]["depid"].ToString();
                    //lblDiemChuan.Text = "100 ";
                    lblDiemChuan.Text = dtDiem.Rows[0]["Sitemscore"].ToString();
                    decimal diem;
                    try
                    {
                        diem = decimal.Parse(dtDiem.Rows[0]["sub_score"].ToString());
                    }
                    catch
                    {
                        diem = 0;
                    }
                    decimal d;
                    DataTable dem = dalType.DemSoNgayDeTinhDiem(DepartID, FromDate, ToDate);
                    if (dem.Rows.Count > 0)
                    {

                        try
                        {
                            d = decimal.Parse(dem.Rows[0]["S8date"].ToString());
                        }
                        catch
                        {
                            d = 0;
                        }
                    }
                    else
                    {
                        d = 0;
                    }
                    decimal diem8s = diem / d;
                    lblDiem.Text = diem8s.ToString();
                    decimal diemchuan;
                    try
                    {
                        diemchuan = decimal.Parse(dtDiem.Rows[0]["Sitemscore"].ToString());
                    }
                    catch
                    {
                        diemchuan = 0;
                    }
                    decimal diemc = diemchuan / d;
                    lblDiemChuan.Text = diemc.ToString();
                }
                else
                {
                    divScore.Visible = false;
                }
            }
            else
            {

                FromDate = DateTime.Today.AddDays(-7);
                ToDate = DateTime.Today;
                string ngonngu = Session["languege"].ToString();
                if (ngonngu == "lbl_VN")
                {
                    DataTable dt = dalType.QryPhieu8TheoDieuKienVN1(FromDate, ToDate, DepartID);
                    if (dt.Rows.Count > 0)
                    {
                        divScore.Visible = true;
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                        Session["SFromDate"] = FromDate.ToString();
                        Session["SToDate"] = ToDate.ToString();
                        Session["SDepartID"] = DepartID.ToString();
                    }
                    else
                    {
                        GridView1.DataSource = null;
                        GridView1.DataBind();
                        divScore.Visible = false;
                    }
                }
                else if (ngonngu == "lbl_TW")
                {
                    DataTable dt = dalType.QryPhieu8TheoDieuKienTW1(FromDate, ToDate, DepartID);
                    if (dt.Rows.Count > 0)
                    {
                        divScore.Visible = true;
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                        Session["SFromDate"] = FromDate.ToString();
                        Session["SToDate"] = ToDate.ToString();
                        Session["SDepartID"] = DepartID.ToString();
                    }
                    else
                    {
                        GridView1.DataSource = null;
                        GridView1.DataBind();
                        divScore.Visible = false;
                    }
                }
                else if (ngonngu == "lbl_EN")
                {
                    DataTable dt = dalType.QryPhieu8TheoDieuKienEN1(FromDate, ToDate, DepartID);
                    if (dt.Rows.Count > 0)
                    {
                        divScore.Visible = true;
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                        Session["SFromDate"] = FromDate.ToString();
                        Session["SToDate"] = ToDate.ToString();
                        Session["SDepartID"] = DepartID.ToString();
                    }
                    else
                    {
                        GridView1.DataSource = null;
                        GridView1.DataBind();
                        divScore.Visible = false;
                    }
                }
                DataTable dtDiem = dalType.LayTongDiemTheoDonVi(DepartID, FromDate, ToDate);
                if (dtDiem.Rows.Count > 0)
                {
                    divScore.Visible = true;
                    string donvi = dtDiem.Rows[0]["depid"].ToString();
                    lblDiemChuan.Text = "100 ";
                    decimal diem;
                    try
                    {
                        diem = decimal.Parse(dtDiem.Rows[0]["sub_score"].ToString());
                    }
                    catch
                    {
                        diem = 0;
                    }
                    decimal d;
                    DataTable dem = dalType.DemSoNgayDeTinhDiem(DepartID, FromDate, ToDate);
                    if (dem.Rows.Count > 0)
                    {

                        try
                        {
                            d = decimal.Parse(dem.Rows[0]["S8date"].ToString());
                        }
                        catch
                        {
                            d = 0;
                        }
                    }
                    else
                    {
                        d = 0;
                    }
                    decimal diem8s = diem / d;
                    lblDiem.Text = diem8s.ToString();
                    decimal diemchuan;
                    try
                    {
                        diemchuan = decimal.Parse(dtDiem.Rows[0]["Sitemscore"].ToString());
                    }
                    catch
                    {
                        diemchuan = 0;
                    }
                    decimal diemc = diemchuan / d;
                    lblDiemChuan.Text = diemc.ToString();
                }
                else
                {
                    divScore.Visible = false;
                }
            }

        }
        public void HienThiDanhSachTheoDieuKien1_CR(string DepartID)
        {

            string tungay = txtFromDate.Text.Trim();
            string denngay = txtToDate.Text.Trim();
            DateTime FromDate;
            DateTime ToDate;

            if (tungay != "" && denngay != "" && DepartID != "0")
            {

                try
                {
                    FromDate = DateTime.Parse(tungay);
                    ToDate = DateTime.Parse(denngay);
                }
                catch
                {
                    FromDate = DateTime.Today.AddDays(-7);
                    ToDate = DateTime.Today;
                }
                string ngonngu = Session["languege"].ToString();
                if (ngonngu == "lbl_VN")
                {
                    DataTable dt = dalType.QryPhieu8TheoDieuKienVN1_CR(FromDate, ToDate, DepartID);
                    if (dt.Rows.Count > 0)
                    {
                        divScore.Visible = true;
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                        Session["SFromDate"] = FromDate.ToString();
                        Session["SToDate"] = ToDate.ToString();
                        Session["SDepartID"] = DepartID.ToString();
                    }
                    else
                    {
                        GridView1.DataSource = null;
                        GridView1.DataBind();
                        divScore.Visible = false;
                    }
                }
                else if (ngonngu == "lbl_TW")
                {
                    DataTable dt = dalType.QryPhieu8TheoDieuKienTW1_CR(FromDate, ToDate, DepartID);
                    if (dt.Rows.Count > 0)
                    {
                        divScore.Visible = true;
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                        Session["SFromDate"] = FromDate.ToString();
                        Session["SToDate"] = ToDate.ToString();
                        Session["SDepartID"] = DepartID.ToString();
                    }
                    else
                    {
                        GridView1.DataSource = null;
                        GridView1.DataBind();
                        divScore.Visible = false;
                    }
                }
                else if (ngonngu == "lbl_EN")
                {
                    DataTable dt = dalType.QryPhieu8TheoDieuKienEN1_CR(FromDate, ToDate, DepartID);
                    if (dt.Rows.Count > 0)
                    {
                        divScore.Visible = true;
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                        Session["SFromDate"] = FromDate.ToString();
                        Session["SToDate"] = ToDate.ToString();
                        Session["SDepartID"] = DepartID.ToString();
                    }
                    else
                    {
                        GridView1.DataSource = null;
                        GridView1.DataBind();
                        divScore.Visible = false;
                    }
                }
                DataTable dtDiem = dalType.LayTongDiemTheoDonVi_CR(DepartID, FromDate, ToDate);
                if (dtDiem.Rows.Count > 0)
                {
                    divScore.Visible = true;
                    string donvi = dtDiem.Rows[0]["depid"].ToString();
                    //lblDiemChuan.Text = "100 ";
                   // lblDiemChuan.Text = dtDiem.Rows[0]["Sitemscore"].ToString();
                    decimal diem;
                    try
                    {
                        diem = decimal.Parse(dtDiem.Rows[0]["sub_score"].ToString());
                    }
                    catch
                    {
                        diem = 0;
                    }
                    decimal d;
                    DataTable dem = dalType.DemSoNgayDeTinhDiem(DepartID, FromDate, ToDate);
                    if (dem.Rows.Count > 0)
                    {

                        try
                        {
                            d = decimal.Parse(dem.Rows[0]["S8date"].ToString());
                        }
                        catch
                        {
                            d = 0;
                        }
                    }
                    else
                    {
                        d = 0;
                    }
                    decimal diem8s = diem / d;
                    lblDiem.Text = diem8s.ToString();
                    decimal diemchuan;
                    try
                    {
                        diemchuan = decimal.Parse(dtDiem.Rows[0]["Sitemscore"].ToString());
                    }
                    catch
                    {
                        diemchuan = 0;
                    }
                    decimal diemc = diemchuan / d;
                    lblDiemChuan.Text = diemc.ToString();
                }
                else
                {
                    divScore.Visible = false;
                }
            }
            else
            {

                FromDate = DateTime.Today.AddDays(-7);
                ToDate = DateTime.Today;
                string ngonngu = Session["languege"].ToString();
                if (ngonngu == "lbl_VN")
                {
                    DataTable dt = dalType.QryPhieu8TheoDieuKienVN1_CR(FromDate, ToDate, DepartID);
                    if (dt.Rows.Count > 0)
                    {
                        divScore.Visible = true;
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                        Session["SFromDate"] = FromDate.ToString();
                        Session["SToDate"] = ToDate.ToString();
                        Session["SDepartID"] = DepartID.ToString();
                    }
                    else
                    {
                        GridView1.DataSource = null;
                        GridView1.DataBind();
                        divScore.Visible = false;
                    }
                }
                else if (ngonngu == "lbl_TW")
                {
                    DataTable dt = dalType.QryPhieu8TheoDieuKienTW1_CR(FromDate, ToDate, DepartID);
                    if (dt.Rows.Count > 0)
                    {
                        divScore.Visible = true;
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                        Session["SFromDate"] = FromDate.ToString();
                        Session["SToDate"] = ToDate.ToString();
                        Session["SDepartID"] = DepartID.ToString();
                    }
                    else
                    {
                        GridView1.DataSource = null;
                        GridView1.DataBind();
                        divScore.Visible = false;
                    }
                }
                else if (ngonngu == "lbl_EN")
                {
                    DataTable dt = dalType.QryPhieu8TheoDieuKienEN1_CR(FromDate, ToDate, DepartID);
                    if (dt.Rows.Count > 0)
                    {
                        divScore.Visible = true;
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                        Session["SFromDate"] = FromDate.ToString();
                        Session["SToDate"] = ToDate.ToString();
                        Session["SDepartID"] = DepartID.ToString();
                    }
                    else
                    {
                        GridView1.DataSource = null;
                        GridView1.DataBind();
                        divScore.Visible = false;
                    }
                }
                DataTable dtDiem = dalType.LayTongDiemTheoDonVi_CR(DepartID, FromDate, ToDate);
                if (dtDiem.Rows.Count > 0)
                {
                    divScore.Visible = true;
                    string donvi = dtDiem.Rows[0]["depid"].ToString();
                  //  lblDiemChuan.Text = "100 ";
                    decimal diem;
                    try
                    {
                        diem = decimal.Parse(dtDiem.Rows[0]["sub_score"].ToString());
                    }
                    catch
                    {
                        diem = 0;
                    }
                    decimal d;
                    DataTable dem = dalType.DemSoNgayDeTinhDiem(DepartID, FromDate, ToDate);
                    if (dem.Rows.Count > 0)
                    {

                        try
                        {
                            d = decimal.Parse(dem.Rows[0]["S8date"].ToString());
                        }
                        catch
                        {
                            d = 0;
                        }
                    }
                    else
                    {
                        d = 0;
                    }
                    decimal diem8s = diem / d;
                    lblDiem.Text = diem8s.ToString();
                    decimal diemchuan;
                    try
                    {
                        diemchuan = decimal.Parse(dtDiem.Rows[0]["Sitemscore"].ToString());
                    }
                    catch
                    {
                        diemchuan = 0;
                    }
                    decimal diemc = diemchuan / d;
                    lblDiemChuan.Text = diemc.ToString();
                }
                else
                {
                    divScore.Visible = false;
                }
            }

        }
        public void HienThiDanhSachTheoDieuKien1_NS(string DepartID)
        {

            string tungay = txtFromDate.Text.Trim();
            string denngay = txtToDate.Text.Trim();
            DateTime FromDate;
            DateTime ToDate;

            if (tungay != "" && denngay != "" && DepartID != "0")
            {

                try
                {
                    FromDate = DateTime.Parse(tungay);
                    ToDate = DateTime.Parse(denngay);
                }
                catch
                {
                    FromDate = DateTime.Today.AddDays(-7);
                    ToDate = DateTime.Today;
                }
                string ngonngu = Session["languege"].ToString();
                if (ngonngu == "lbl_VN")
                {
                    DataTable dt = dalType.QryPhieu8TheoDieuKienVN1_NS(FromDate, ToDate, DepartID);
                    if (dt.Rows.Count > 0)
                    {
                        divScore.Visible = true;
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                        Session["SFromDate"] = FromDate.ToString();
                        Session["SToDate"] = ToDate.ToString();
                        Session["SDepartID"] = DepartID.ToString();
                    }
                    else
                    {
                        GridView1.DataSource = null;
                        GridView1.DataBind();
                        divScore.Visible = false;
                    }
                }
                else if (ngonngu == "lbl_TW")
                {
                    DataTable dt = dalType.QryPhieu8TheoDieuKienTW1_NS(FromDate, ToDate, DepartID);
                    if (dt.Rows.Count > 0)
                    {
                        divScore.Visible = true;
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                        Session["SFromDate"] = FromDate.ToString();
                        Session["SToDate"] = ToDate.ToString();
                        Session["SDepartID"] = DepartID.ToString();
                    }
                    else
                    {
                        GridView1.DataSource = null;
                        GridView1.DataBind();
                        divScore.Visible = false;
                    }
                }
                else if (ngonngu == "lbl_EN")
                {
                    DataTable dt = dalType.QryPhieu8TheoDieuKienEN1_NS(FromDate, ToDate, DepartID);
                    if (dt.Rows.Count > 0)
                    {
                        divScore.Visible = true;
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                        Session["SFromDate"] = FromDate.ToString();
                        Session["SToDate"] = ToDate.ToString();
                        Session["SDepartID"] = DepartID.ToString();
                    }
                    else
                    {
                        GridView1.DataSource = null;
                        GridView1.DataBind();
                        divScore.Visible = false;
                    }
                }
                DataTable dtDiem = dalType.LayTongDiemTheoDonVi_NS(DepartID, FromDate, ToDate);
                if (dtDiem.Rows.Count > 0)
                {
                    divScore.Visible = true;
                    string donvi = dtDiem.Rows[0]["depid"].ToString();
                    //lblDiemChuan.Text = "100 ";
                   // lblDiemChuan.Text = dtDiem.Rows[0]["Sitemscore"].ToString();
                    decimal diem;
                    try
                    {
                        diem = decimal.Parse(dtDiem.Rows[0]["sub_score"].ToString());
                    }
                    catch
                    {
                        diem = 0;
                    }
                    decimal d;
                    DataTable dem = dalType.DemSoNgayDeTinhDiem(DepartID, FromDate, ToDate);
                    if (dem.Rows.Count > 0)
                    {

                        try
                        {
                            d = decimal.Parse(dem.Rows[0]["S8date"].ToString());
                        }
                        catch
                        {
                            d = 0;
                        }
                    }
                    else
                    {
                        d = 0;
                    }
                    decimal diem8s = diem / d;
                    lblDiem.Text = diem8s.ToString();
                    decimal diemchuan;
                    try
                    {
                        diemchuan = decimal.Parse(dtDiem.Rows[0]["Sitemscore"].ToString());
                    }
                    catch
                    {
                        diemchuan = 0;
                    }
                    decimal diemc = diemchuan / d;
                    lblDiemChuan.Text = diemc.ToString();
                }
                else
                {
                    divScore.Visible = false;
                }
            }
            else
            {

                FromDate = DateTime.Today.AddDays(-7);
                ToDate = DateTime.Today;
                string ngonngu = Session["languege"].ToString();
                if (ngonngu == "lbl_VN")
                {
                    DataTable dt = dalType.QryPhieu8TheoDieuKienVN1_NS(FromDate, ToDate, DepartID);
                    if (dt.Rows.Count > 0)
                    {
                        divScore.Visible = true;
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                        Session["SFromDate"] = FromDate.ToString();
                        Session["SToDate"] = ToDate.ToString();
                        Session["SDepartID"] = DepartID.ToString();
                    }
                    else
                    {
                        GridView1.DataSource = null;
                        GridView1.DataBind();
                        divScore.Visible = false;
                    }
                }
                else if (ngonngu == "lbl_TW")
                {
                    DataTable dt = dalType.QryPhieu8TheoDieuKienTW1_NS(FromDate, ToDate, DepartID);
                    if (dt.Rows.Count > 0)
                    {
                        divScore.Visible = true;
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                        Session["SFromDate"] = FromDate.ToString();
                        Session["SToDate"] = ToDate.ToString();
                        Session["SDepartID"] = DepartID.ToString();
                    }
                    else
                    {
                        GridView1.DataSource = null;
                        GridView1.DataBind();
                        divScore.Visible = false;
                    }
                }
                else if (ngonngu == "lbl_EN")
                {
                    DataTable dt = dalType.QryPhieu8TheoDieuKienEN1_NS(FromDate, ToDate, DepartID);
                    if (dt.Rows.Count > 0)
                    {
                        divScore.Visible = true;
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                        Session["SFromDate"] = FromDate.ToString();
                        Session["SToDate"] = ToDate.ToString();
                        Session["SDepartID"] = DepartID.ToString();
                    }
                    else
                    {
                        GridView1.DataSource = null;
                        GridView1.DataBind();
                        divScore.Visible = false;
                    }
                }
                DataTable dtDiem = dalType.LayTongDiemTheoDonVi_NS(DepartID, FromDate, ToDate);
                if (dtDiem.Rows.Count > 0)
                {
                    divScore.Visible = true;
                    string donvi = dtDiem.Rows[0]["depid"].ToString();
                    //lblDiemChuan.Text = "100 ";
                    decimal diem;
                    try
                    {
                        diem = decimal.Parse(dtDiem.Rows[0]["sub_score"].ToString());
                    }
                    catch
                    {
                        diem = 0;
                    }
                    decimal d;
                    DataTable dem = dalType.DemSoNgayDeTinhDiem(DepartID, FromDate, ToDate);
                    if (dem.Rows.Count > 0)
                    {

                        try
                        {
                            d = decimal.Parse(dem.Rows[0]["S8date"].ToString());
                        }
                        catch
                        {
                            d = 0;
                        }
                    }
                    else
                    {
                        d = 0;
                    }
                    decimal diem8s = diem / d;
                    lblDiem.Text = diem8s.ToString();
                    decimal diemchuan;
                    try
                    {
                        diemchuan = decimal.Parse(dtDiem.Rows[0]["Sitemscore"].ToString());
                    }
                    catch
                    {
                        diemchuan = 0;
                    }
                    decimal diemc = diemchuan / d;
                    lblDiemChuan.Text = diemc.ToString();
                }
                else
                {
                    divScore.Visible = false;
                }
            }

        }
        public void HienThiDanhSachTheoDieuKien1_TKTH(string DepartID)
        {

            string tungay = txtFromDate.Text.Trim();
            string denngay = txtToDate.Text.Trim();
            DateTime FromDate;
            DateTime ToDate;

            if (tungay != "" && denngay != "" && DepartID != "0")
            {

                try
                {
                    FromDate = DateTime.Parse(tungay);
                    ToDate = DateTime.Parse(denngay);
                }
                catch
                {
                    FromDate = DateTime.Today.AddDays(-7);
                    ToDate = DateTime.Today;
                }
                string ngonngu = Session["languege"].ToString();
                if (ngonngu == "lbl_VN")
                {
                    DataTable dt = dalType.QryPhieu8TheoDieuKienVN1_TKTH(FromDate, ToDate, DepartID);
                    if (dt.Rows.Count > 0)
                    {
                        divScore.Visible = true;
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                        Session["SFromDate"] = FromDate.ToString();
                        Session["SToDate"] = ToDate.ToString();
                        Session["SDepartID"] = DepartID.ToString();
                    }
                    else
                    {
                        GridView1.DataSource = null;
                        GridView1.DataBind();
                        divScore.Visible = false;
                    }
                }
                else if (ngonngu == "lbl_TW")
                {
                    DataTable dt = dalType.QryPhieu8TheoDieuKienTW1_TKTH(FromDate, ToDate, DepartID);
                    if (dt.Rows.Count > 0)
                    {
                        divScore.Visible = true;
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                        Session["SFromDate"] = FromDate.ToString();
                        Session["SToDate"] = ToDate.ToString();
                        Session["SDepartID"] = DepartID.ToString();
                    }
                    else
                    {
                        GridView1.DataSource = null;
                        GridView1.DataBind();
                        divScore.Visible = false;
                    }
                }
                else if (ngonngu == "lbl_EN")
                {
                    DataTable dt = dalType.QryPhieu8TheoDieuKienEN1_TKTH(FromDate, ToDate, DepartID);
                    if (dt.Rows.Count > 0)
                    {
                        divScore.Visible = true;
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                        Session["SFromDate"] = FromDate.ToString();
                        Session["SToDate"] = ToDate.ToString();
                        Session["SDepartID"] = DepartID.ToString();
                    }
                    else
                    {
                        GridView1.DataSource = null;
                        GridView1.DataBind();
                        divScore.Visible = false;
                    }
                }
                DataTable dtDiem = dalType.LayTongDiemTheoDonVi_TKTH(DepartID, FromDate, ToDate);
                if (dtDiem.Rows.Count > 0)
                {
                    divScore.Visible = true;
                    string donvi = dtDiem.Rows[0]["depid"].ToString();
                    //lblDiemChuan.Text = "100 ";
                    //lblDiemChuan.Text = dtDiem.Rows[0]["Sitemscore"].ToString();
                    decimal diem;
                    try
                    {
                        diem = decimal.Parse(dtDiem.Rows[0]["sub_score"].ToString());
                    }
                    catch
                    {
                        diem = 0;
                    }
                    decimal d;
                    DataTable dem = dalType.DemSoNgayDeTinhDiem(DepartID, FromDate, ToDate);
                    if (dem.Rows.Count > 0)
                    {

                        try
                        {
                            d = decimal.Parse(dem.Rows[0]["S8date"].ToString());
                        }
                        catch
                        {
                            d = 0;
                        }
                    }
                    else
                    {
                        d = 0;
                    }
                    decimal diem8s = diem / d;
                    lblDiem.Text = diem8s.ToString();
                    decimal diemchuan;
                    try
                    {
                        diemchuan = decimal.Parse(dtDiem.Rows[0]["Sitemscore"].ToString());
                    }
                    catch
                    {
                        diemchuan = 0;
                    }
                    decimal diemc = diemchuan / d;
                    lblDiemChuan.Text = diemc.ToString();
                }
                else
                {
                    divScore.Visible = false;
                }
            }
            else
            {

                FromDate = DateTime.Today.AddDays(-7);
                ToDate = DateTime.Today;
                string ngonngu = Session["languege"].ToString();
                if (ngonngu == "lbl_VN")
                {
                    DataTable dt = dalType.QryPhieu8TheoDieuKienVN1_TKTH(FromDate, ToDate, DepartID);
                    if (dt.Rows.Count > 0)
                    {
                        divScore.Visible = true;
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                        Session["SFromDate"] = FromDate.ToString();
                        Session["SToDate"] = ToDate.ToString();
                        Session["SDepartID"] = DepartID.ToString();
                    }
                    else
                    {
                        GridView1.DataSource = null;
                        GridView1.DataBind();
                        divScore.Visible = false;
                    }
                }
                else if (ngonngu == "lbl_TW")
                {
                    DataTable dt = dalType.QryPhieu8TheoDieuKienTW1_TKTH(FromDate, ToDate, DepartID);
                    if (dt.Rows.Count > 0)
                    {
                        divScore.Visible = true;
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                        Session["SFromDate"] = FromDate.ToString();
                        Session["SToDate"] = ToDate.ToString();
                        Session["SDepartID"] = DepartID.ToString();
                    }
                    else
                    {
                        GridView1.DataSource = null;
                        GridView1.DataBind();
                        divScore.Visible = false;
                    }
                }
                else if (ngonngu == "lbl_EN")
                {
                    DataTable dt = dalType.QryPhieu8TheoDieuKienEN1_TKTH(FromDate, ToDate, DepartID);
                    if (dt.Rows.Count > 0)
                    {
                        divScore.Visible = true;
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                        Session["SFromDate"] = FromDate.ToString();
                        Session["SToDate"] = ToDate.ToString();
                        Session["SDepartID"] = DepartID.ToString();
                    }
                    else
                    {
                        GridView1.DataSource = null;
                        GridView1.DataBind();
                        divScore.Visible = false;
                    }
                }
                DataTable dtDiem = dalType.LayTongDiemTheoDonVi_TKTH(DepartID, FromDate, ToDate);
                if (dtDiem.Rows.Count > 0)
                {
                    divScore.Visible = true;
                    string donvi = dtDiem.Rows[0]["depid"].ToString();
                   // lblDiemChuan.Text = "100 ";
                    decimal diem;
                    try
                    {
                        diem = decimal.Parse(dtDiem.Rows[0]["sub_score"].ToString());
                    }
                    catch
                    {
                        diem = 0;
                    }
                    decimal d;
                    DataTable dem = dalType.DemSoNgayDeTinhDiem(DepartID, FromDate, ToDate);
                    if (dem.Rows.Count > 0)
                    {

                        try
                        {
                            d = decimal.Parse(dem.Rows[0]["S8date"].ToString());
                        }
                        catch
                        {
                            d = 0;
                        }
                    }
                    else
                    {
                        d = 0;
                    }
                    decimal diem8s = diem / d;
                    lblDiem.Text = diem8s.ToString();
                    decimal diemchuan;
                    try
                    {
                        diemchuan = decimal.Parse(dtDiem.Rows[0]["Sitemscore"].ToString());
                    }
                    catch
                    {
                        diemchuan = 0;
                    }
                    decimal diemc = diemchuan / d;
                    lblDiemChuan.Text = diemc.ToString();
                }
                else
                {
                    divScore.Visible = false;
                }
            }

        }
        public void HienThiDanhSachTheoDieuKienSession()
        {
            //Session["SFromDate"] = FromDate.ToString();
            //Session["SToDate"] = ToDate.ToString();
            //Session["SDepartID"] = DepartID.ToString();
            string tungay = (string)Session["SFromDate"];
            string denngay = (string)Session["SToDate"];
            string DepartID = (string)Session["SDepartID"];
            DateTime FromDate;
            DateTime ToDate;
            if (tungay != null && denngay != null && DepartID != null)
            {

                if (DepartID != "0")
                {

                    try
                    {
                        FromDate = DateTime.Parse(tungay);
                        ToDate = DateTime.Parse(denngay);
                    }
                    catch
                    {
                        FromDate = DateTime.Today.AddDays(-7);
                        ToDate = DateTime.Today;
                    }
                    string ngonngu = Session["languege"].ToString();
                    if (ngonngu == "lbl_VN")
                    {
                        DataTable dt = dalType.QryPhieu8TheoDieuKienVN1(FromDate, ToDate, DepartID);
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                    }
                    else if (ngonngu == "lbl_TW")
                    {
                        DataTable dt = dalType.QryPhieu8TheoDieuKienTW1(FromDate, ToDate, DepartID);
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                    }
                    else if (ngonngu == "lbl_EN")
                    {
                        DataTable dt = dalType.QryPhieu8TheoDieuKienEN1(FromDate, ToDate, DepartID);
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                    }
                    DataTable dtDiem = dalType.LayTongDiemTheoDonVi(DepartID, FromDate, ToDate);
                    if (dtDiem.Rows.Count > 0)
                    {
                        divScore.Visible = true;
                        string donvi = dtDiem.Rows[0]["depid"].ToString();
                        // lblDiemChuan.Text = "100 ";
                        decimal diem;
                        try
                        {
                            diem = decimal.Parse(dtDiem.Rows[0]["sub_score"].ToString());
                        }
                        catch
                        {
                            diem = 0;
                        }
                        decimal d;
                        DataTable dem = dalType.DemSoNgayDeTinhDiem(DepartID, FromDate, ToDate);
                        if (dem.Rows.Count > 0)
                        {

                            try
                            {
                                d = decimal.Parse(dem.Rows[0]["S8date"].ToString());
                            }
                            catch
                            {
                                d = 0;
                            }
                        }
                        else
                        {
                            d = 0;
                        }
                        decimal diem8s = diem / d;
                        lblDiem.Text = diem8s.ToString();
                        decimal diemchuan;
                        try
                        {
                            diemchuan = decimal.Parse(dtDiem.Rows[0]["Sitemscore"].ToString());
                        }
                        catch
                        {
                            diemchuan = 0;
                        }
                        decimal diemc = diemchuan / d;
                        lblDiemChuan.Text = diemc.ToString();
                    }
                    else
                    {
                        divScore.Visible = false;
                    }
                }
                else
                {

                    FromDate = DateTime.Today.AddDays(-7);
                    ToDate = DateTime.Today;
                    string ngonngu = Session["languege"].ToString();
                    if (ngonngu == "lbl_VN")
                    {
                        DataTable dt = dalType.QryPhieu8TheoDieuKienVN1(FromDate, ToDate, DepartID);
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                    }
                    else if (ngonngu == "lbl_TW")
                    {
                        DataTable dt = dalType.QryPhieu8TheoDieuKienTW1(FromDate, ToDate, DepartID);
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                    }
                    else if (ngonngu == "lbl_EN")
                    {
                        DataTable dt = dalType.QryPhieu8TheoDieuKienEN1(FromDate, ToDate, DepartID);
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                    }
                    DataTable dtDiem = dalType.LayTongDiemTheoDonVi(DepartID, FromDate, ToDate);
                    if (dtDiem.Rows.Count > 0)
                    {
                        divScore.Visible = true;
                        string donvi = dtDiem.Rows[0]["depid"].ToString();
                        // lblDiemChuan.Text = "100 ";
                        decimal diem;
                        try
                        {
                            diem = decimal.Parse(dtDiem.Rows[0]["sub_score"].ToString());
                        }
                        catch
                        {
                            diem = 0;
                        }
                        decimal d;
                        DataTable dem = dalType.DemSoNgayDeTinhDiem(DepartID, FromDate, ToDate);
                        if (dem.Rows.Count > 0)
                        {

                            try
                            {
                                d = decimal.Parse(dem.Rows[0]["S8date"].ToString());
                            }
                            catch
                            {
                                d = 0;
                            }
                        }
                        else
                        {
                            d = 0;
                        }
                        decimal diem8s = diem / d;
                        lblDiem.Text = diem8s.ToString();
                        decimal diemchuan;
                        try
                        {
                            diemchuan = decimal.Parse(dtDiem.Rows[0]["Sitemscore"].ToString());
                        }
                        catch
                        {
                            diemchuan = 0;
                        }
                        decimal diemc = diemchuan / d;
                        lblDiemChuan.Text = diemc.ToString();
                    }
                    else
                    {
                        divScore.Visible = false;
                    }
                }
            }
        }
        public void HienThiDanhSachTheoDieuKienSession_CR()
        {
            //Session["SFromDate"] = FromDate.ToString();
            //Session["SToDate"] = ToDate.ToString();
            //Session["SDepartID"] = DepartID.ToString();
            string tungay = (string)Session["SFromDate"];
            string denngay = (string)Session["SToDate"];
            string DepartID = (string)Session["SDepartID"];
            DateTime FromDate;
            DateTime ToDate;
            if (tungay != null && denngay != null && DepartID != null)
            {

                if (DepartID != "0")
                {

                    try
                    {
                        FromDate = DateTime.Parse(tungay);
                        ToDate = DateTime.Parse(denngay);
                    }
                    catch
                    {
                        FromDate = DateTime.Today.AddDays(-7);
                        ToDate = DateTime.Today;
                    }
                    string ngonngu = Session["languege"].ToString();
                    if (ngonngu == "lbl_VN")
                    {
                        DataTable dt = dalType.QryPhieu8TheoDieuKienVN1_CR(FromDate, ToDate, DepartID);
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                    }
                    else if (ngonngu == "lbl_TW")
                    {
                        DataTable dt = dalType.QryPhieu8TheoDieuKienTW1_CR(FromDate, ToDate, DepartID);
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                    }
                    else if (ngonngu == "lbl_EN")
                    {
                        DataTable dt = dalType.QryPhieu8TheoDieuKienEN1_CR(FromDate, ToDate, DepartID);
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                    }
                    DataTable dtDiem = dalType.LayTongDiemTheoDonVi_CR(DepartID, FromDate, ToDate);
                    if (dtDiem.Rows.Count > 0)
                    {
                        divScore.Visible = true;
                        string donvi = dtDiem.Rows[0]["depid"].ToString();
                        // lblDiemChuan.Text = "100 ";
                        decimal diem;
                        try
                        {
                            diem = decimal.Parse(dtDiem.Rows[0]["sub_score"].ToString());
                        }
                        catch
                        {
                            diem = 0;
                        }
                        decimal d;
                        DataTable dem = dalType.DemSoNgayDeTinhDiem(DepartID, FromDate, ToDate);
                        if (dem.Rows.Count > 0)
                        {

                            try
                            {
                                d = decimal.Parse(dem.Rows[0]["S8date"].ToString());
                            }
                            catch
                            {
                                d = 0;
                            }
                        }
                        else
                        {
                            d = 0;
                        }
                        decimal diem8s = diem / d;
                        lblDiem.Text = diem8s.ToString();
                        decimal diemchuan;
                        try
                        {
                            diemchuan = decimal.Parse(dtDiem.Rows[0]["Sitemscore"].ToString());
                        }
                        catch
                        {
                            diemchuan = 0;
                        }
                        decimal diemc = diemchuan / d;
                        lblDiemChuan.Text = diemc.ToString();
                    }
                    else
                    {
                        divScore.Visible = false;
                    }
                }
                else
                {

                    FromDate = DateTime.Today.AddDays(-7);
                    ToDate = DateTime.Today;
                    string ngonngu = Session["languege"].ToString();
                    if (ngonngu == "lbl_VN")
                    {
                        DataTable dt = dalType.QryPhieu8TheoDieuKienVN1_CR(FromDate, ToDate, DepartID);
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                    }
                    else if (ngonngu == "lbl_TW")
                    {
                        DataTable dt = dalType.QryPhieu8TheoDieuKienTW1_CR(FromDate, ToDate, DepartID);
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                    }
                    else if (ngonngu == "lbl_EN")
                    {
                        DataTable dt = dalType.QryPhieu8TheoDieuKienEN1_CR(FromDate, ToDate, DepartID);
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                    }
                    DataTable dtDiem = dalType.LayTongDiemTheoDonVi_CR(DepartID, FromDate, ToDate);
                    if (dtDiem.Rows.Count > 0)
                    {
                        divScore.Visible = true;
                        string donvi = dtDiem.Rows[0]["depid"].ToString();
                        // lblDiemChuan.Text = "100 ";
                        decimal diem;
                        try
                        {
                            diem = decimal.Parse(dtDiem.Rows[0]["sub_score"].ToString());
                        }
                        catch
                        {
                            diem = 0;
                        }
                        decimal d;
                        DataTable dem = dalType.DemSoNgayDeTinhDiem(DepartID, FromDate, ToDate);
                        if (dem.Rows.Count > 0)
                        {

                            try
                            {
                                d = decimal.Parse(dem.Rows[0]["S8date"].ToString());
                            }
                            catch
                            {
                                d = 0;
                            }
                        }
                        else
                        {
                            d = 0;
                        }
                        decimal diem8s = diem / d;
                        lblDiem.Text = diem8s.ToString();
                        decimal diemchuan;
                        try
                        {
                            diemchuan = decimal.Parse(dtDiem.Rows[0]["Sitemscore"].ToString());
                        }
                        catch
                        {
                            diemchuan = 0;
                        }
                        decimal diemc = diemchuan / d;
                        lblDiemChuan.Text = diemc.ToString();
                    }
                    else
                    {
                        divScore.Visible = false;
                    }
                }
            }
        }
        public void HienThiDanhSachTheoDieuKienSession_NS()
        {
            //Session["SFromDate"] = FromDate.ToString();
            //Session["SToDate"] = ToDate.ToString();
            //Session["SDepartID"] = DepartID.ToString();
            string tungay = (string)Session["SFromDate"];
            string denngay = (string)Session["SToDate"];
            string DepartID = (string)Session["SDepartID"];
            DateTime FromDate;
            DateTime ToDate;
            if (tungay != null && denngay != null && DepartID != null)
            {

                if (DepartID != "0")
                {

                    try
                    {
                        FromDate = DateTime.Parse(tungay);
                        ToDate = DateTime.Parse(denngay);
                    }
                    catch
                    {
                        FromDate = DateTime.Today.AddDays(-7);
                        ToDate = DateTime.Today;
                    }
                    string ngonngu = Session["languege"].ToString();
                    if (ngonngu == "lbl_VN")
                    {
                        DataTable dt = dalType.QryPhieu8TheoDieuKienVN1_NS(FromDate, ToDate, DepartID);
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                    }
                    else if (ngonngu == "lbl_TW")
                    {
                        DataTable dt = dalType.QryPhieu8TheoDieuKienTW1_NS(FromDate, ToDate, DepartID);
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                    }
                    else if (ngonngu == "lbl_EN")
                    {
                        DataTable dt = dalType.QryPhieu8TheoDieuKienEN1_NS(FromDate, ToDate, DepartID);
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                    }
                    DataTable dtDiem = dalType.LayTongDiemTheoDonVi_NS(DepartID, FromDate, ToDate);
                    if (dtDiem.Rows.Count > 0)
                    {
                        divScore.Visible = true;
                        string donvi = dtDiem.Rows[0]["depid"].ToString();
                        // lblDiemChuan.Text = "100 ";
                        decimal diem;
                        try
                        {
                            diem = decimal.Parse(dtDiem.Rows[0]["sub_score"].ToString());
                        }
                        catch
                        {
                            diem = 0;
                        }
                        decimal d;
                        DataTable dem = dalType.DemSoNgayDeTinhDiem(DepartID, FromDate, ToDate);
                        if (dem.Rows.Count > 0)
                        {

                            try
                            {
                                d = decimal.Parse(dem.Rows[0]["S8date"].ToString());
                            }
                            catch
                            {
                                d = 0;
                            }
                        }
                        else
                        {
                            d = 0;
                        }
                        decimal diem8s = diem / d;
                        lblDiem.Text = diem8s.ToString();
                        decimal diemchuan;
                        try
                        {
                            diemchuan = decimal.Parse(dtDiem.Rows[0]["Sitemscore"].ToString());
                        }
                        catch
                        {
                            diemchuan = 0;
                        }
                        decimal diemc = diemchuan / d;
                        lblDiemChuan.Text = diemc.ToString();
                    }
                    else
                    {
                        divScore.Visible = false;
                    }
                }
                else
                {

                    FromDate = DateTime.Today.AddDays(-7);
                    ToDate = DateTime.Today;
                    string ngonngu = Session["languege"].ToString();
                    if (ngonngu == "lbl_VN")
                    {
                        DataTable dt = dalType.QryPhieu8TheoDieuKienVN1_NS(FromDate, ToDate, DepartID);
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                    }
                    else if (ngonngu == "lbl_TW")
                    {
                        DataTable dt = dalType.QryPhieu8TheoDieuKienTW1_NS(FromDate, ToDate, DepartID);
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                    }
                    else if (ngonngu == "lbl_EN")
                    {
                        DataTable dt = dalType.QryPhieu8TheoDieuKienEN1_NS(FromDate, ToDate, DepartID);
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                    }
                    DataTable dtDiem = dalType.LayTongDiemTheoDonVi_NS(DepartID, FromDate, ToDate);
                    if (dtDiem.Rows.Count > 0)
                    {
                        divScore.Visible = true;
                        string donvi = dtDiem.Rows[0]["depid"].ToString();
                        // lblDiemChuan.Text = "100 ";
                        decimal diem;
                        try
                        {
                            diem = decimal.Parse(dtDiem.Rows[0]["sub_score"].ToString());
                        }
                        catch
                        {
                            diem = 0;
                        }
                        decimal d;
                        DataTable dem = dalType.DemSoNgayDeTinhDiem(DepartID, FromDate, ToDate);
                        if (dem.Rows.Count > 0)
                        {

                            try
                            {
                                d = decimal.Parse(dem.Rows[0]["S8date"].ToString());
                            }
                            catch
                            {
                                d = 0;
                            }
                        }
                        else
                        {
                            d = 0;
                        }
                        decimal diem8s = diem / d;
                        lblDiem.Text = diem8s.ToString();
                        decimal diemchuan;
                        try
                        {
                            diemchuan = decimal.Parse(dtDiem.Rows[0]["Sitemscore"].ToString());
                        }
                        catch
                        {
                            diemchuan = 0;
                        }
                        decimal diemc = diemchuan / d;
                        lblDiemChuan.Text = diemc.ToString();
                    }
                    else
                    {
                        divScore.Visible = false;
                    }
                }
            }
        }
        public void HienThiDanhSachTheoDieuKienSession_TKTH()
        {
            //Session["SFromDate"] = FromDate.ToString();
            //Session["SToDate"] = ToDate.ToString();
            //Session["SDepartID"] = DepartID.ToString();
            string tungay = (string)Session["SFromDate"];
            string denngay = (string)Session["SToDate"];
            string DepartID = (string)Session["SDepartID"];
            DateTime FromDate;
            DateTime ToDate;
            if (tungay != null && denngay != null && DepartID != null)
            {

                if (DepartID != "0")
                {

                    try
                    {
                        FromDate = DateTime.Parse(tungay);
                        ToDate = DateTime.Parse(denngay);
                    }
                    catch
                    {
                        FromDate = DateTime.Today.AddDays(-7);
                        ToDate = DateTime.Today;
                    }
                    string ngonngu = Session["languege"].ToString();
                    if (ngonngu == "lbl_VN")
                    {
                        DataTable dt = dalType.QryPhieu8TheoDieuKienVN1_TKTH(FromDate, ToDate, DepartID);
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                    }
                    else if (ngonngu == "lbl_TW")
                    {
                        DataTable dt = dalType.QryPhieu8TheoDieuKienTW1_TKTH(FromDate, ToDate, DepartID);
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                    }
                    else if (ngonngu == "lbl_EN")
                    {
                        DataTable dt = dalType.QryPhieu8TheoDieuKienEN1_TKTH(FromDate, ToDate, DepartID);
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                    }
                    DataTable dtDiem = dalType.LayTongDiemTheoDonVi_TKTH(DepartID, FromDate, ToDate);
                    if (dtDiem.Rows.Count > 0)
                    {
                        divScore.Visible = true;
                        string donvi = dtDiem.Rows[0]["depid"].ToString();
                        // lblDiemChuan.Text = "100 ";
                        decimal diem;
                        try
                        {
                            diem = decimal.Parse(dtDiem.Rows[0]["sub_score"].ToString());
                        }
                        catch
                        {
                            diem = 0;
                        }
                        decimal d;
                        DataTable dem = dalType.DemSoNgayDeTinhDiem(DepartID, FromDate, ToDate);
                        if (dem.Rows.Count > 0)
                        {

                            try
                            {
                                d = decimal.Parse(dem.Rows[0]["S8date"].ToString());
                            }
                            catch
                            {
                                d = 0;
                            }
                        }
                        else
                        {
                            d = 0;
                        }
                        decimal diem8s = diem / d;
                        lblDiem.Text = diem8s.ToString();
                        decimal diemchuan;
                        try
                        {
                            diemchuan = decimal.Parse(dtDiem.Rows[0]["Sitemscore"].ToString());
                        }
                        catch
                        {
                            diemchuan = 0;
                        }
                        decimal diemc = diemchuan / d;
                        lblDiemChuan.Text = diemc.ToString();
                    }
                    else
                    {
                        divScore.Visible = false;
                    }
                }
                else
                {

                    FromDate = DateTime.Today.AddDays(-7);
                    ToDate = DateTime.Today;
                    string ngonngu = Session["languege"].ToString();
                    if (ngonngu == "lbl_VN")
                    {
                        DataTable dt = dalType.QryPhieu8TheoDieuKienVN1_TKTH(FromDate, ToDate, DepartID);
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                    }
                    else if (ngonngu == "lbl_TW")
                    {
                        DataTable dt = dalType.QryPhieu8TheoDieuKienTW1_TKTH(FromDate, ToDate, DepartID);
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                    }
                    else if (ngonngu == "lbl_EN")
                    {
                        DataTable dt = dalType.QryPhieu8TheoDieuKienEN1_TKTH(FromDate, ToDate, DepartID);
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                    }
                    DataTable dtDiem = dalType.LayTongDiemTheoDonVi_TKTH(DepartID, FromDate, ToDate);
                    if (dtDiem.Rows.Count > 0)
                    {
                        divScore.Visible = true;
                        string donvi = dtDiem.Rows[0]["depid"].ToString();
                        // lblDiemChuan.Text = "100 ";
                        decimal diem;
                        try
                        {
                            diem = decimal.Parse(dtDiem.Rows[0]["sub_score"].ToString());
                        }
                        catch
                        {
                            diem = 0;
                        }
                        decimal d;
                        DataTable dem = dalType.DemSoNgayDeTinhDiem(DepartID, FromDate, ToDate);
                        if (dem.Rows.Count > 0)
                        {

                            try
                            {
                                d = decimal.Parse(dem.Rows[0]["S8date"].ToString());
                            }
                            catch
                            {
                                d = 0;
                            }
                        }
                        else
                        {
                            d = 0;
                        }
                        decimal diem8s = diem / d;
                        lblDiem.Text = diem8s.ToString();
                        decimal diemchuan;
                        try
                        {
                            diemchuan = decimal.Parse(dtDiem.Rows[0]["Sitemscore"].ToString());
                        }
                        catch
                        {
                            diemchuan = 0;
                        }
                        decimal diemc = diemchuan / d;
                        lblDiemChuan.Text = diemc.ToString();
                    }
                    else
                    {
                        divScore.Visible = false;
                    }
                }
            }
        }


        protected void btnQuery_Click(object sender, EventArgs e)
        {
            string RoleLogin = (string)Session["RoleLogin"];
            if (RoleLogin.Trim() != null)
            {
                switch (RoleLogin.Trim())
                {
                    case "Full":
                        HienThiDanhSachTheoDieuKien();
                        break;
                    case "CR":
                        HienThiDanhSachTheoDieuKien_CR();
                        break;
                    case "NS":
                        HienThiDanhSachTheoDieuKien_NS();
                        break;
                    case "TKTH":
                        HienThiDanhSachTheoDieuKien_TKTH();
                        break;

                }
            }
           
        }
        #region HRM DOn Vi
        //public void HienThiDropDonViHRM()
        //{
        //    int Nam = int.Parse(DateTime.Today.Year.ToString());
        //    int Month = int.Parse(DateTime.Today.Month.ToString());
        //    DataTable dt = dal8Rec.QryDonViLenDropBox(Nam, Month);
        //    if (dt.Rows.Count > 0)
        //    {

        //        string ngonngu = (string)Session["languege"];
        //        if (ngonngu != null)
        //        {
        //            if (ngonngu == "lbl_VN")
        //            {
        //                DropDownDonVi.DataSource = dt;
        //                DropDownDonVi.DataValueField = "DV_MA";
        //                DropDownDonVi.DataTextField = "DV_TEN";
        //                DropDownDonVi.DataBind();
        //            }
        //            else
        //            {
        //                DropDownDonVi.DataSource = dt;
        //                DropDownDonVi.DataValueField = "DV_MA";
        //                DropDownDonVi.DataTextField = "TENDV_TAIWAN";
        //                DropDownDonVi.DataBind();
        //            }
        //        }


        //        //txtCQUserID0.Text = dt.Rows[0]["CQuserid0"].ToString();
        //        //txtCQUserID1.Text = dt.Rows[0]["CQUserid1"].ToString();

        //    }

        //}

        #endregion

        public void HienThiDropDonViERP()
        {
           
            DataTable dt = dal8Rec.QryDonViLenDropBoxTrenERP(Congty);
            if (dt.Rows.Count > 0)
            {

                string ngonngu = (string)Session["languege"];
                if (ngonngu != null)
                {
                    if (ngonngu == "lbl_VN")
                    {
                        DropDownDonVi.DataSource = dt;
                        DropDownDonVi.DataValueField = "ID";
                        DropDownDonVi.DataTextField = "DepName";
                        DropDownDonVi.DataBind();
                    }
                    else
                    {
                        DropDownDonVi.DataSource = dt;
                        DropDownDonVi.DataValueField = "ID";
                        DropDownDonVi.DataTextField = "DepName";
                        DropDownDonVi.DataBind();
                    }
                }


                //txtCQUserID0.Text = dt.Rows[0]["CQuserid0"].ToString();
                //txtCQUserID1.Text = dt.Rows[0]["CQUserid1"].ToString();

            }

        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblsh=(Label)e.Row.FindControl("lblsh");
                TextBox lb = (TextBox)e.Row.FindControl("txtScoreDB");
                lb.ForeColor = System.Drawing.Color.Blue;
                Label lblDiemChuan = (Label)e.Row.FindControl("lblDiemChuan");
                lblDiemChuan.ForeColor = System.Drawing.Color.Blue;
                Label lblYN = (Label)e.Row.FindControl("lblYn");
                LinkButton linkButton = (LinkButton)e.Row.FindControl("LinkEdit");
                if (lblQuyen.Text.Trim() == "")


                {
                    linkButton.Enabled = false;
                    linkButton.Attributes.CssStyle.Add("opacity", "0.3");
                }
                else
                {
                    if (lblYN.Text.Trim() == "2")
                    {
                        linkButton.Enabled = false;
                        linkButton.Attributes.CssStyle.Add("opacity", "0.3");
                        lb.Enabled = false;
                        lb.ForeColor = System.Drawing.Color.Red;
                    }
                    else
                    {
                        linkButton.Enabled = true;
                        linkButton.Attributes.CssStyle.Add("opacity", "100");
                        lb.Enabled = true;
                        lb.ForeColor = System.Drawing.Color.Blue;
                    }
                }
               
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["Sua8S"] = "Sua";
            GridViewRow row = GridView1.SelectedRow;
            Label lblsh = (Label)row.FindControl("lblsh");
            Label lbldepid = (Label)row.FindControl("lblDepartID");
            Label lblSitemno = (Label)row.FindControl("lblSitemno");
            Label lblSitemtp = (Label)row.FindControl("lblSitemtp");



            Response.Redirect("Edit8S.aspx?ID=" + lblsh.Text.Trim() + "&DepartID=" + lbldepid.Text.Trim() + "&Sitemno=" + lblSitemno.Text.Trim() + "&Sitemtp="+lblSitemtp.Text.Trim());
           
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            //Response.Redirect("AddNew8S.aspx");

            DateTime date = DateTime.Parse(txtDate.Text.Trim());
            string ID = DropDownDonVi.SelectedValue;
            string UserID = (string)Session["UserID"];
            if (UserID != null)
            {
                try
                {
                    string RoleLogin = (string)Session["RoleLogin"];
                    if (RoleLogin != null)
                    {
                        switch (RoleLogin.Trim())
                        {
                            case "CR":
                                dal8Rec.Them8SVaoTrongbangS8Rec_CR(Congty, ID, UserID, date);
                                HienThiDropDonViCuaNhanVien(true);
                                HienThiDanhSachTheoDieuKien_CR();
                                break;
                            case "NS":
                                 dal8Rec.Them8SVaoTrongbangS8Rec_NS(Congty, ID, UserID, date);
                                HienThiDropDonViCuaNhanVien(true);
                                HienThiDanhSachTheoDieuKien_NS();
                                break;
                            case "TKTH":
                                 dal8Rec.Them8SVaoTrongbangS8Rec_TKTH(Congty, ID, UserID, date);
                                HienThiDropDonViCuaNhanVien(true);
                                HienThiDanhSachTheoDieuKien_TKTH();
                                break;
                        }
                    }
                    
                    
                   
                    btnAdd.Enabled = false;
                    DropDownDonVi.SelectedValue = ID;
                    checkCreate.Checked = true;
                    // 
                }
                catch
                {

                }
            }
        }

        protected void DropDownDonVi_SelectedIndexChanged(object sender, EventArgs e)
        {
            string ID = DropDownDonVi.SelectedValue;
            if (ID.Trim() != "0")
            {
                txtBDepartID.Text = ID;
                //HienThiDanhSachTheoDieuKien();

                DateTime date;
               
                try
                {
                    date = DateTime.Parse(txtDate.Text.Trim());
                    
                }
                catch
                {
                    date = DateTime.Today;
                    
                }
                DataTable dt = dal8Rec.KiemTraDonViTruocKhiThem1(ID, date);
                if (dt.Rows.Count > 0)
                {
                    btnAdd.Enabled = false;
                    btnAdd.Attributes.CssStyle.Add("opacity", "0.3");
                    HienThiDanhSachTheoDieuKien();
                    string RoleLogin = (string)Session["RoleLogin"];
                    if (RoleLogin != null)
                    {
                        switch (RoleLogin.Trim())
                        {
                            case "Full":
                                HienThiDanhSachTheoDieuKien();
                                break;
                            case "CR":
                                HienThiDanhSachTheoDieuKien_CR();
                                break;
                            case "NS":
                                HienThiDanhSachTheoDieuKien_NS();
                                break;
                            case "TKTH":
                                HienThiDanhSachTheoDieuKien_TKTH();
                                break;
                        }
                    }
                }
                else
                {
                   // txtBDepartID.Text = "";
                    divScore.Visible = false;
                    lblDiem.Text = "";
                    lblDiemChuan.Text = "";
                    GridView1.DataSource = null;
                    GridView1.DataBind();
                    btnAdd.Enabled = true;
                    btnAdd.Attributes.CssStyle.Add("opacity", "100");

                }
            }
            else
            {
                txtBDepartID.Text = "";
                GridView1.DataSource = null;
                GridView1.DataBind();
            }
            lblThongBao.Text = "";
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            string UserID = (string)Session["UserID"];
            if (UserID == null)
            {
                Response.Redirect("http://portal.footgear.com.vn/presentationLayer/Default.aspx");

            }
            else
            {
                decimal DIem = 0;
                try
                {
                    DIem = decimal.Parse(lblDiem.Text.Trim());
                }
                catch
                {
                    DIem = 0;
                }
                if (DIem > 0)
                {
                    string Year = DateTime.Today.Year.ToString();
                    string Mont = DateTime.Today.Month.ToString();
                    DateTime date = DateTime.Today;
                    //string Week = "";
                    //DataTable dt = dal8Rec.LayTuanThangTheoNgay(date);
                    //if (dt.Rows.Count > 0)
                    //{
                    //    Week = dt.Rows[0]["TUAN_MA"].ToString();
                    //}
                    string donvi = DropDownDonVi.SelectedValue;
                    DateTime fromdate = DateTime.Parse(txtFromDate.Text.Trim());
                    DateTime todate = DateTime.Parse(txtToDate.Text.Trim());
                    decimal Score = 0;
                    try
                    {
                        Score = decimal.Parse(lblDiem.Text.Trim());
                    }
                    catch
                    {
                        Score = 0;
                    }
                    //HienThiDanhSachTheoDieuKien1(donvi);
                    //dal8Rec.ChuyenDiemQuaBangProScore(Year, Mont, Week, donvi, Congty, Score, fromdate, todate);
                    //lblThongBao.Text = "Update successful";
                    dal8Rec.CapNhatVaKhoaDiemCuaDonVi(UserID,donvi, Congty, fromdate, todate);
                    HienThiDropDownDonViCuaCanBo(false);
                    HienThiDanhSachTheoDieuKien1(donvi);
                }
            }
        }

        protected void btnExportDepart_Click(object sender, EventArgs e)
        {
            string UserID = (string)Session["UserID"];
            string DepartID = DropDownDonVi.SelectedValue;
            string FromDate;
            string ToDate;
            if (txtFromDate.Text.Trim() != "" && txtToDate.Text.Trim() != "" && UserID != null && DepartID!="0")
            {
                try
                {
                    FromDate = DateTime.Parse(txtFromDate.Text.Trim()).ToString();
                    ToDate = DateTime.Parse(txtToDate.Text.Trim()).ToString();
                }
                catch
                {
                    FromDate = DateTime.Today.AddDays(-7).ToString();
                    ToDate = DateTime.Today.ToString();
                }
                Response.Redirect("WF_ReportT.aspx?Type=BaoCao8STheoTuan&DepartmentID=" + DepartID + "&FromDate=" + FromDate + "&ToDate=" + ToDate);
            }
        }

        protected void btnAdd1Row_Click(object sender, EventArgs e)
        {
            string ID=DropDownDonVi.SelectedValue;
            Response.Redirect("AddNew8S.aspx?S8Depart=" + ID);
        }
        public void HienThiDanhSach8SChuaDatTheoTungDonVi(string departID)
        {
            DateTime FromDate;
            DateTime ToDate;
            try
            {
                FromDate = DateTime.Parse(txtFromDate.Text.Trim());
                ToDate = DateTime.Parse(txtToDate.Text.Trim());
            }
            catch
            {
                FromDate = DateTime.Today.AddDays(-6);
                ToDate = DateTime.Today;
            }
            string ngonngu = (string)Session["languege"];
            if (ngonngu != null)
            {
                if (ngonngu == "lbl_VN")
                {
                    DataTable dt = dalType.Qry8SCoDiemThapHonDiemChuanVN(FromDate, ToDate, departID);
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
                else
                {
                    DataTable dt = dalType.Qry8SCoDiemThapHonDiemChuanCH(FromDate, ToDate, departID);
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
            }
            lblDiem.Text = "";
            lblDiemChuan.Text = "";
            divScore.Visible = false;
        }
        public void HienThiDanhSach8SChuaDatTheoTatCaDonVi()
        {
            DateTime FromDate;
            DateTime ToDate;
            try
            {
                FromDate = DateTime.Parse(txtFromDate.Text.Trim());
                ToDate = DateTime.Parse(txtToDate.Text.Trim());
            }
            catch
            {
                FromDate = DateTime.Today.AddDays(-6);
                ToDate = DateTime.Today;
            }
            string ngonngu = (string)Session["languege"];
            if (ngonngu != null)
            {
                if (ngonngu == "lbl_VN")
                {
                    DataTable dt = dalType.Qry8SCoDiemThapHonDiemChuanVNAll(FromDate, ToDate);
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
                else
                {
                    DataTable dt = dalType.Qry8SCoDiemThapHonDiemChuanCHAll(FromDate, ToDate);
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
            }
            lblDiem.Text = "";
            lblDiemChuan.Text = "";
            divScore.Visible = false;
        }
        protected void btnGetData_Click(object sender, EventArgs e)
        {
            string ID = DropDownDonVi.SelectedValue;
            if (ID.Trim() != "0")
            {
                HienThiDanhSach8SChuaDatTheoTungDonVi(ID);
            }
            else
            {
                HienThiDanhSach8SChuaDatTheoTatCaDonVi();
            }
        }

        protected void txtScoreDB_TextChanged(object sender, EventArgs e)
        {
            TextBox grid = (TextBox)sender;
           
           // TextBox txtsh = (TextBox)grid.FindControl("txtsh");
            Label lblsh = (Label)grid.FindControl("lblsh");
            TextBox txtScoreDB = (TextBox)grid.FindControl("txtScoreDB");
           decimal score=0;
            try
            {
                score=decimal.Parse(txtScoreDB.Text.Trim());
            }
            catch
            {
                score=0;
            }
            Label lblDepartID=(Label)grid.FindControl("lblDepartID");
            int ID=int.Parse(lblsh.Text.Trim());
            string Department = lblDepartID.Text.Trim();
            dalType.CapNhatDiem(ID, score);
            string RoleLogin = (string)Session["RoleLogin"];
            if (RoleLogin != null)
            {
                switch (RoleLogin.Trim())
                {
                    case "CR":
                        HienThiDanhSachTheoDieuKien1_CR(Department);
                        break;
                    case "NS":
                        HienThiDanhSachTheoDieuKien1_NS(Department);
                        break;
                    case "TKTH":
                        HienThiDanhSachTheoDieuKien1_TKTH(Department);
                        break;
                }
            }
           
            grid.Focus();
            checkCreate.Checked = true;
            HienThiDropDonViCuaNhanVien(true);
            DropDownDonVi.SelectedValue = Department;
            
        }

       
        

        protected void checkCreate_CheckedChanged(object sender, EventArgs e)
        {
            string ID = DropDownDonVi.SelectedValue;
            if (checkCreate.Checked == true)
            {
                HienThiDropDonViCuaNhanVien(true);
               
                string RoleLogin = (string)Session["RoleLogin"];
                if (RoleLogin != null)
                {
                    switch (RoleLogin.Trim())
                    {
                        case "CR":
                            HienThiDanhSachTheoDieuKien1_CR(ID);
                            break;
                        case "NS":
                            HienThiDanhSachTheoDieuKien1_NS(ID);
                            break;
                        case "TKTH":
                            HienThiDanhSachTheoDieuKien1_TKTH(ID);
                            break;
                    }
                }
                if (ID.Trim() != "0")
                {
                    txtBDepartID.Text = ID;

                }
            }
            else
            {
                HienThiDropDonViCuaNhanVien(false);
                GridView1.DataSource = null;
                GridView1.DataBind();
                txtBDepartID.Text = "";
            }
            
        }

        protected void checkConfirm_CheckedChanged(object sender, EventArgs e)
        {
          
            if (checkConfirm.Checked == true)
            {
                btnConfirm.Enabled = false;
                btnConfirm.Attributes.CssStyle.Add("opacity", "0.3");
                HienThiDropDownDonViCuaCanBo(true);
                string IDDonvi = DropDownDonVi.SelectedValue;
                if (IDDonvi.Trim() != "0")
                {
                    txtBDepartID.Text = ID;

                    HienThiDanhSachTheoDieuKien1(IDDonvi);
                }
                else
                {
                    txtBDepartID.Text = "";
                }
               
               
            }
            else
            {
                HienThiDropDownDonViCuaCanBo(false);
                btnConfirm.Enabled = true;
                btnConfirm.Attributes.CssStyle.Add("opacity", "100");
                string IDDonvi = DropDownDonVi.SelectedValue;
                if (IDDonvi.Trim() != "0")
                {
                    txtBDepartID.Text = ID;
                    HienThiDanhSachTheoDieuKien1(IDDonvi);
                }
                else
                {
                    txtBDepartID.Text = "";
                }
                
            }
        }

        protected void DropDownWeek_SelectedIndexChanged(object sender, EventArgs e)
        {
            string year=dropDownYear.SelectedValue;
            string month=dropDownMonth.SelectedValue;
            string Week = DropDownWeek.SelectedValue;
           // HienTHiNgayTheoTuan(Week);
            LayNgayThangTheoTuan(year, month, Week);
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

        protected void btnCopyDiem_Click(object sender, EventArgs e)
        {
            Response.Redirect("CopyScore.aspx");
        }

      

       
    }
}