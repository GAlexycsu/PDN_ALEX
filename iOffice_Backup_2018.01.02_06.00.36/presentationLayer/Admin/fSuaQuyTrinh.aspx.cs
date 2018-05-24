using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using iOffice.BUS;
using iOffice.DTO;
using iOffice.DAO;
using iOffice.Share;
using System.Data;
using System.Data.SqlClient;
namespace iOffice.presentationLayer.Admin
{
    public partial class fSuaQuyTrinh : LanguegeBus
    {
       
        quytrinhDal dal = new quytrinhDal();
        abconDAL dalabcon = new abconDAL();
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (!IsPostBack)
            {
                string id = Session["id"].ToString();
                string macongty = Session["macongty"].ToString();
                string maloaiphieu = Session["maloaiphieu"].ToString();
                string madonvi = Session["madonvi"].ToString();
                string manguoiduyet = Session["manguoiduyet"].ToString();
                string macapduyet = Session["macapduyet"].ToString();
                string abstep = Session["abstep"].ToString();
                string abps = Session["abps"].ToString();
                txtNguoiDuyet.Text = manguoiduyet;
                DropCty.SelectedValue = macongty;
                DropDownLoaiPhieu.SelectedValue = maloaiphieu;
                DropDownLDonVi.SelectedValue = madonvi;
                DropDownABStep.SelectedValue = abstep;
                DropDownABPS.SelectedValue = abps;
                 HienThiLoaiPhieu();
                
                 HienThiDonVi();






                 string strNgonngu = (string)Session["languege"];
                 if (strNgonngu != null)
                 {
                     LayngonNgu(35, strNgonngu);
                 }
                 else
                 {
                     Response.Redirect("http://portal.footgear.com.vn");
                 }
                GanNgonNguVaoConTrol();
            }
        }
        public override void GanNgonNguVaoConTrol()
        {
           
            Button1.Text = hasLanguege["Button1"].ToString();
        }
       
       

        private void HienThiDonVi()
        {
            string madonvi = (string)Session["madonvi"];
            if (madonvi == "All")
            {
                DropDownLDonVi.Items.Insert(0, "All");
            }
            else
            {
                DropDownLDonVi.DataSource = BDepartmentBUS.DanhSachBoPhan();
                DropDownLDonVi.DataValueField = "ID";
                DropDownLDonVi.DataTextField = "DepName";
                DropDownLDonVi.DataBind();
            }
           
        }
        
        private void HienThiLoaiPhieu()
        {
            string ngonngu = Session["languege"].ToString();
            DropDownLoaiPhieu.DataSource = abillBUS.ListBill();
            DropDownLoaiPhieu.DataValueField = "abtype";

            if (ngonngu == "lbl_VN")
            {
                DropDownLoaiPhieu.DataTextField = "abname";
            }
            else if (ngonngu == "lbl_TW")
            {
                DropDownLoaiPhieu.DataTextField = "abnameTW";
            }
            else if (ngonngu == "lbl_EN")
            {
                DropDownLoaiPhieu.DataTextField = "abname";
            }
            DropDownLoaiPhieu.DataBind();
        }
       


        protected void Button1_Click(object sender, EventArgs e)
        {
            if(lbThongBao.Text!="")
            {
                lbThongBao.Text="";
            }
            string manguoiduyet1 = Session["manguoiduyet"].ToString();
            int id = int.Parse(Session["id"].ToString());
           
            if (lbThongBao.Text.Trim() != "")
            {
                lbThongBao.Text = "";
            }
            string macongty = DropCty.SelectedValue.ToString();

            string madonvi = DropDownLDonVi.SelectedValue.ToString();

            string manguoiduyet = txtNguoiDuyet.Text;
            int AbStep = int.Parse(DropDownABStep.SelectedValue);
            int ABPS = int.Parse(DropDownABPS.SelectedValue);
            QPDNFlow quytrinh = new QPDNFlow();
            if (manguoiduyet == "ZZZZZZ")
            {
                quytrinh.ABPS = 1;
                quytrinh.ABstep = 1;
                if (DropDownLoaiPhieu.SelectedValue.ToString().Trim() == "")
                {
                    quytrinh.abtype = "PDN1";
                    abill timloai = abillBUS.SearchAbillByID(quytrinh.abtype);
                    quytrinh.abtypenameTW = timloai.abnameTW;
                }
                else
                {
                    quytrinh.abtype = DropDownLoaiPhieu.SelectedValue.ToString();
                    abill timloai = abillBUS.SearchAbillByID(DropDownLoaiPhieu.SelectedValue.ToString());
                    quytrinh.abtypenameTW = timloai.abnameTW;
                }
                quytrinh.BADEPID = "All";
                quytrinh.DepartmentTypeNameTW = "间接单位";
                quytrinh.GSBH = macongty;
                quytrinh.IDCapDuyet = 7;
                quytrinh.IDChucVu = "CQDV";
                quytrinh.IDLoaiDonVi = 2;
                quytrinh.NguoiDuyet = "ZZZZZZ";
                quytrinh.USERNAME = "";
                quytrinh.TenChucVuTiengHoa = "单位主管";
                quytrinh.tendonviTW = "All";
              
               dal.CapNhatQuyTrinh(macongty, quytrinh.abtype, madonvi, AbStep, ABPS, quytrinh.NguoiDuyet, quytrinh.USERNAME, quytrinh.abtypenameTW, quytrinh.tendonviTW, int.Parse(quytrinh.IDLoaiDonVi.ToString()), quytrinh.DepartmentTypeNameTW, int.Parse(quytrinh.IDCapDuyet.ToString()));
      
            }
            else
            {
                if (madonvi == "All")
                {
                    quytrinh.BADEPID = "All";
                    quytrinh.tendonviTW = "All";
                    quytrinh.GSBH = macongty;
                    quytrinh.IDLoaiDonVi = 2;
                    quytrinh.DepartmentTypeNameTW = "间接单位";
                }
                else
                {
                    BDepartment donvi = BDepartmentDAO.TimMaDonVi(madonvi, macongty);
                    AbDepartmentType loaidonvi = LoaiDonViDAO.TimMaLoaiDonVi(int.Parse(donvi.DepartmentTypeID.ToString()), macongty);

                    quytrinh.BADEPID = madonvi;
                    quytrinh.tendonviTW = donvi.DepName;
                    quytrinh.GSBH = macongty;
                    quytrinh.IDLoaiDonVi = loaidonvi.DepartmentTypeID;
                    quytrinh.DepartmentTypeNameTW = loaidonvi.DepartmentTypeNameTW;
                }
                if (DropDownLoaiPhieu.SelectedValue.ToString().Trim() == "")
                {
                    quytrinh.abtype = "PDN1";
                    abill timloai = abillBUS.SearchAbillByID(quytrinh.abtype);
                    quytrinh.abtypenameTW = timloai.abnameTW;
                }
                else
                {
                    quytrinh.abtype = DropDownLoaiPhieu.SelectedValue.ToString();
                    abill timloai = abillBUS.SearchAbillByID(DropDownLoaiPhieu.SelectedValue.ToString());
                    quytrinh.abtypenameTW = timloai.abnameTW;
                }
                quytrinh.DonViThongQua = null;
                quytrinh.NguoiDuyet = txtNguoiDuyet.Text;
                Busers2 nguoi = UserDAO.TimNhanVienTheoMa(manguoiduyet, macongty);
                int idcapduyet = int.Parse(nguoi.IDCapDuyet.ToString());
                quytrinh.USERNAME = nguoi.USERNAME;
                ChucVu chuc = ChucVuDAO.TimMaChucVu(nguoi.IDChucVu, macongty);
                quytrinh.IDChucVu = chuc.IDChucVu;
                quytrinh.tendonvithongqua = chuc.TenChucVuTiengHoa;
                quytrinh.IDCapDuyet = nguoi.IDCapDuyet;
                quytrinh.ABstep = AbStep;
                quytrinh.ABPS = ABPS;

                QPDNFlow tim = QPDNFlowDAO.TimNguoiTrongQuyTrinh(nguoi.USERID, quytrinh.abtype, quytrinh.BADEPID, macongty);
                if (tim != null)
                {
                    dal.CapNhatQuyABPS(macongty, quytrinh.abtype, madonvi, id, AbStep, ABPS);
                }
                else
                {
                    QPDNFlow timbuoccansua = QPDNFlowDAO.TimBuocKyCanSua(macongty, quytrinh.abtype, quytrinh.BADEPID, AbStep, ABPS);
                    if (timbuoccansua != null)
                    {

                        dal.CapNhatQuyTrinh(macongty, quytrinh.abtype, madonvi, AbStep, ABPS, quytrinh.NguoiDuyet, quytrinh.USERNAME, quytrinh.abtypenameTW, quytrinh.tendonviTW, int.Parse(quytrinh.IDLoaiDonVi.ToString()), quytrinh.DepartmentTypeNameTW, int.Parse(quytrinh.IDCapDuyet.ToString()));
                    }
                    List<Abcon> dsPhieuChuaDuyet = AbconDAO.dsPhieuChuaDuyetTheoBuocDuyetCapDuyet(macongty, madonvi, quytrinh.abtype, AbStep, ABPS);
                    foreach (Abcon phieu in dsPhieuChuaDuyet)
                    {
                        Abcon timnguoi = AbconDAO.TimNguoiDuyetTrongPhieu(madonvi, macongty, quytrinh.abtype, phieu.pdno, nguoi.USERID);
                        if (timnguoi == null)
                        {
                            dalabcon.CapNhatAbcon(macongty, quytrinh.abtype, phieu.pdno, nguoi.USERID, phieu.IDCT, AbStep, idcapduyet, ABPS);
                        }
                    }

                }
            }
            Response.Redirect("FQPDNFlow.aspx");
        }
    }
}