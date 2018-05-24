using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using iOffice.DTO;
using iOffice.BUS;
using iOffice.Share;
using System.Data.Linq;
using iOffice.DAO;
namespace iOffice.presentationLayer.Admin
{
    public partial class frmEditUser : LanguegeBus
    {
        iOfficeDataContext db = new iOfficeDataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("http://portal.footgear.com.vn");
            }
            if (!IsPostBack)
            {
                HienThiDropDownList();
                HienThiChucVu();
                //string str = Request.QueryString.Get("USERID");
                //string idcongty = Request.QueryString.Get("GSBH");
                string str = Session["manhanvien"].ToString();

                string idcongty = Session["idcongty"].ToString();
                string bophan = DropBoPhan.SelectedValue.ToString();
                Busers2 user = db.Busers2s.Where(p => p.USERID == str && p.GSBH==idcongty).FirstOrDefault();
                txtMaNV.Text = str;
                DropCty.SelectedValue = user.GSBH;
                txtTenNV.Text = user.USERNAME;
                txtNguoiQuanLyTT.Text = user.IdUserQuanLyTT;
                txtEmail.Text = user.EMAIL;
                //txtmatkhau2.Text = libraly.Decryption(user.Password2);
                if (user.isSep == true)
                {
                    checkCanBo.Checked = true;
                }
                else
                {
                    checkCanBo.Checked = false;
                }
                
                DropBoPhan.SelectedValue = user.BADEPID;
                DropDownChucVu.SelectedValue = user.IDChucVu;
                DropBoPhan.Enabled = false;
                
            }

            string strNgonngu = (string)Session["languege"];
            if (strNgonngu != null)
            {
                LayngonNgu(20, strNgonngu);
            }
            else
            {
                Response.Redirect("http://portal.footgear.com.vn");
            }
            GanNgonNguVaoConTrol();
        }
        private void HienThiChucVu()
        {
            string ngonngu = Session["languege"].ToString();
            DropDownChucVu.DataSource = ChucVuBUS.Qrychucvu();
            DropDownChucVu.DataValueField = "IDChucVu";

            if (ngonngu == "lbl_VN")
            {
                DropDownChucVu.DataTextField = "TenChucVu";
            }
            else if (ngonngu == "lbl_TW")
            {
                DropDownChucVu.DataTextField = "TenChucVuTiengHoa";
            }
            else if (ngonngu == "lbl_EN")
            {
                DropDownChucVu.DataTextField = "TenChucVu";
            }
            DropDownChucVu.DataBind();
        }
        public override void GanNgonNguVaoConTrol()
        {
            
            btnEdit.Text = hasLanguege["btnEdit"].ToString();
            checkBophan.Text = hasLanguege["lbBoPhan"].ToString();
            checkCanBo.Text = hasLanguege["lblLaCanBo"].ToString();
            
        }
        private void HienThiDropDownList()
        {
           // string congty = Session["congty"].ToString();
            string congty = DropCty.SelectedValue.ToString();
            DropBoPhan.DataSource = BDepartmentBUS.DanhSachBoPhan(congty);
            DropBoPhan.DataValueField = "ID";
            DropBoPhan.DataTextField = "DepName";
            DropBoPhan.DataBind();
        }
       

        protected void btnSua_Click(object sender, EventArgs e)
        {
            
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            string idnguoidung = txtMaNV.Text;
            string hoten = txtTenNV.Text;
            //string matkhau = txtmatkhau.Text;
           // string matkhau2 = txtmatkhau2.Text;
            string matkhau2 = "123456";
            string match = @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";
            string ngonngu = Session["languege"].ToString();
            string macongty = "LTY";
            string cty = DropCty.SelectedValue.ToString();
            string bophan = DropBoPhan.SelectedValue.ToString();
            string congty = DropCty.SelectedValue.ToString();
            
            string chucvu = DropDownChucVu.SelectedValue.ToString();
            string nguoiquanlyTT = txtNguoiQuanLyTT.Text;
            byte[] fileByte = FileUpload1.FileBytes;
            Binary binaryObj = new Binary(fileByte);
            ChucVu chuc = ChucVuDAO.TimMaChucVu(chucvu, macongty);
            Busers2 user = new Busers2();
            if (checkBophan.Checked == true)
            {
                user.BADEPID = bophan;
            }
            else
            {
                user.BADEPID = null;
            }
            if (checkCanBo.Checked == true)
            {
                user.isSep = true;
            }
            else
            {
                user.isSep = false;
            }
            Regex reg = new Regex(match);
            if (reg.IsMatch(this.txtEmail.Text))
            {
                user.EMAIL = txtEmail.Text;
            }
            else
            {
                if (ngonngu == "lbl_VN")
                {
                    lbthongbaoloi .Text = "Email nhập không đúng định dạng, vui lòng nhập lại. Ví dụ: tuan-it@footgear.com.vn";
                }
                else if (ngonngu == "lbl_TW")
                {
                    lbthongbaoloi.Text = "邮件地址不真确，重新输入，例如：tuan-it@footgear.com.vn";
                }
                else if (ngonngu == "lbl_EN")
                {
                    lbthongbaoloi.Text = "Enter email not valid, please re-enter. Example:tuan-it@footgear.com.vn ";
                }
            }
            user.GSBH = congty;
            user.USERID = idnguoidung;
            user.USERNAME = hoten;
            //user.PWD = matkhau;
            if (txtmatkhau2.Text.Trim() == "")
            {
                Busers2 laynguoidung = UserDAO.TimNhanVienTheoMa(idnguoidung, congty);
                user.Password2 = laynguoidung.Password2;
            }
            else
            {
               user.Password2 = libraly.Encryption(matkhau2);
            }
            
            //user.BADEPID = bophan;
            user.GSBH = cty;
            user.IdUserQuanLyTT = nguoiquanlyTT;
            user.IDCapDuyet = chuc.IDCapDuyet;
            //user.abstep = buocduyet;
            user.IDChucVu = chucvu;
            if (FileUpload1.FileName.Trim() == "")
            {
                Busers2 laynguoidung = UserDAO.TimNhanVienTheoMa(idnguoidung, congty);
                user.signatue = laynguoidung.signatue;
            }
            else
            {
                user.signatue = binaryObj;
            }
           
            
            //db.Busers.InsertOnSubmit(user);
            UserBUS.UpdateUser(user);
            Response.Redirect("~/presentationLayer/Admin/frmAddUsers.aspx");
        }

        protected void checkthuocbophan_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBophan.Checked == true)
            {
                DropBoPhan.Enabled = true;
            }
            else
            {
                DropBoPhan.Enabled = false;
            }
        }

        protected void checkBophan_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBophan.Checked == true)
            {
                DropBoPhan.Enabled = true;
            }
            else
            {
                DropBoPhan.Enabled = false;
            }
        }

        protected void checkCanBo_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}