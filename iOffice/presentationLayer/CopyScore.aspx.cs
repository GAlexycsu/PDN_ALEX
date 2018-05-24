using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using iOffice.BUS;
namespace iOffice.presentationLayer
{
    public partial class CopyScore :LanguegeBus
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
            GanNgonNguVaoGridView();
            if (!IsPostBack)
            {
                string datehh = (string)Session["dateHH"];
                string donvihh = (string)Session["donvihh"];
                if (datehh != null && donvihh!=null)
                {
                    DateTime date = DateTime.Parse(datehh);
                    txtDate.Text = date.ToString("yyyy/MM/dd");
                    DropDownDonViCopy.SelectedValue = donvihh;
                }
                else
                {
                    txtDate.Text = DateTime.Today.ToString("yyyy/MM/dd");
                }

                HienThiDropDonviChuaTao();
                HienThiDropDonViDaTao();
            }

        }
        public override void GanNgonNguVaoGridView()
        {
           GridView1.Columns[4].HeaderText=hasLanguege["lblDonVi"].ToString();
             GridView1.Columns[7].HeaderText=hasLanguege["lblMaSo"].ToString();
             GridView1.Columns[8].HeaderText=hasLanguege["lblVanDe"].ToString();
             GridView1.Columns[9].HeaderText=hasLanguege["lblDiemChuan"].ToString();
             GridView1.Columns[10].HeaderText=hasLanguege["lblDiem"].ToString();
             GridView1.Columns[12].HeaderText=hasLanguege["lblHinhAnh1"].ToString();
             GridView1.Columns[13].HeaderText=hasLanguege["lblHinhAnh2"].ToString();
            
        }
        public void HienThiDropDonviChuaTao()
        {
            DateTime date = DateTime.Parse(txtDate.Text.Trim());
            string RoleLogin = (string)Session["RoleLogin"];
            if (RoleLogin != null)
            {
                if (RoleLogin.Trim() == "CR")
                {
                    DataTable dt = dal8Rec.HienThiDanhSachChuaTaoCuaNhanVienCR(Congty, date);
                    DropDownDonViCopy.DataSource = dt;
                    DropDownDonViCopy.DataValueField = "ID";
                    DropDownDonViCopy.DataTextField = "DepName";
                    DropDownDonViCopy.DataBind();
                }
                else
                {
                    if (RoleLogin.Trim() == "NS")
                    {
                        DataTable dt = dal8Rec.HienThiDanhSachChuaTaoCuaNhanVienNS(Congty, date);
                        DropDownDonViCopy.DataSource = dt;
                        DropDownDonViCopy.DataValueField = "ID";
                        DropDownDonViCopy.DataTextField = "DepName";
                        DropDownDonViCopy.DataBind();
                    }
                    else
                    {
                        DataTable dt = dal8Rec.HienThiDanhSachChuaTaoCuaNhanVienTKTH(Congty, date);
                        DropDownDonViCopy.DataSource = dt;
                        DropDownDonViCopy.DataValueField = "ID";
                        DropDownDonViCopy.DataTextField = "DepName";
                        DropDownDonViCopy.DataBind();
                    }
                }
            }
        }
        public void HienThiDropDonViDaTao()
        {
            DateTime date = DateTime.Parse(txtDate.Text.Trim());
            string RoleLogin = (string)Session["RoleLogin"];
            if (RoleLogin.Trim() != null)
            {
                if (RoleLogin.Trim() == "NS")
                {
                    DataTable dt = dal8Rec.HienThiDanhSachDaTaoTaoCuaNhanVienNS(Congty, date);
                    DropDownDonViDau.DataSource = dt;
                    DropDownDonViDau.DataValueField = "ID";
                    DropDownDonViDau.DataTextField = "DepName";
                    DropDownDonViDau.DataBind();
                }
                else
                {
                    if (RoleLogin.Trim() == "CR")
                    {
                        DataTable dt = dal8Rec.HienThiDanhSachDaTaoTaoCuaNhanVienCR(Congty, date);
                        DropDownDonViDau.DataSource = dt;
                        DropDownDonViDau.DataValueField = "ID";
                        DropDownDonViDau.DataTextField = "DepName";
                        DropDownDonViDau.DataBind();
                    }
                    else
                    {
                        DataTable dt = dal8Rec.HienThiDanhSachDaTaoTaoCuaNhanVienTKTH(Congty, date);
                        DropDownDonViDau.DataSource = dt;
                        DropDownDonViDau.DataValueField = "ID";
                        DropDownDonViDau.DataTextField = "DepName";
                        DropDownDonViDau.DataBind();
                    }
                }
            }
        }
        public void HienThiDanhSach()
        {
             DateTime date = DateTime.Parse(txtDate.Text.Trim());
             string DonViDen = DropDownDonViCopy.SelectedValue;
            string ngonNgu=(string)Session["languege"];
            if(ngonNgu!=null)
            {
                switch(ngonNgu.Trim())
                {
                    case "lbl_VN":
                        DataTable dt = dalType.QryPhieu8SauKhiCopy_VN(date, DonViDen, Congty);
                        if (dt.Rows.Count > 0)
                        {
                            GridView1.DataSource = dt;
                            GridView1.DataBind();
                        }
                        else
                        {
                            GridView1.DataSource = null;
                            GridView1.DataBind();
                        }
                        break;
                    case "lbl_TW":
                         DataTable dt1 = dalType.QryPhieu8SauKhiCopy_TW(date, DonViDen, Congty);
                         if (dt1.Rows.Count > 0)
                         {
                             GridView1.DataSource = dt1;
                             GridView1.DataBind();
                         }
                         else
                         {
                             GridView1.DataSource = null;
                             GridView1.DataBind();
                         }
                        break;
                    case "lbl_EN":
                         DataTable dt2 = dalType.QryPhieu8SauKhiCopy_EN(date, DonViDen, Congty);
                         if (dt2.Rows.Count > 0)
                         {
                             GridView1.DataSource = dt2;
                             GridView1.DataBind();
                         }
                         else
                         {
                             GridView1.DataSource = null;
                             GridView1.DataBind();
                         }
                        break;
                }
                DataTable dtDiem = dalType.LayTongDiemTheoDonViCopy(DonViDen, date);
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
                    DataTable dem = dalType.DemSoNgayDeTinhDiemCopy(DonViDen,date);
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
        protected void btnCopy_Click(object sender, EventArgs e)
        {

            DateTime date = DateTime.Parse(txtDate.Text.Trim());
            string DonViDau = DropDownDonViDau.SelectedValue;
            string UserID = (string)Session["UserID"];
            string DonViDen = DropDownDonViCopy.SelectedValue;
            dal8Rec.CopyDiemGIongNhau(Congty, DonViDau, DonViDen, UserID, date);
            HienThiDanhSach();
        }

        protected void txtDate_TextChanged(object sender, EventArgs e)
        {
            Session["dateHH"] = txtDate.Text.Trim();
            HienThiDropDonViDaTao();
        }

        protected void btnQry_Click(object sender, EventArgs e)
        {
            Session["dateHH"] = txtDate.Text.Trim();
            Session["donvihh"] = DropDownDonViCopy.SelectedValue;
            HienThiDanhSach();
        }
        
    }
}