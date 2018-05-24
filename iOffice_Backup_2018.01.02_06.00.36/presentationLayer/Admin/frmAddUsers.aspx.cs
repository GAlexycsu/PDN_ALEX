using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using iOffice.DTO;
using iOffice.BUS;
using System.Data.Linq;
using iOffice.Share;
using iOffice.DAO;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
namespace iOffice.presentationLayer.Admin
{
    public partial class frmAddUsers : LanguegeBus
    {
        iOfficeDataContext db = new iOfficeDataContext();
        int STT = 1;
        userDAL dal = new userDAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            string User = (string)Request["UserID"];
            string languege = (string)Request["languege"];
            if (User != null && languege != null)
            {
                Session["congty"] = "LTY";
                Session["user"] = User;
                Session["UserID"] = User;
                Session["languege"] = languege;
            }
            if (Session["user"] == null)
            {
                Response.Redirect("http://portal.footgear.com.vn/");
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
            GanNgonNguVaoGridView();
            if (!IsPostBack)
            {
                HienThiDropDownList();
                HienThiDanhSach();
                HienThiChucVu();
                DropBoPhan.Enabled = false;
                DropBoPhan.Items.Insert(0, "All");
            }
           
            

        }
        protected void GetContactDetails(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager
                        .ConnectionStrings["TheLogiS"].ConnectionString;
                using (SqlCommand cmd = new SqlCommand())
                {
                    string str = "select bu.GSBH,bu.BADEPID,bd.DepName,bu.USERID,bu.USERNAME,bu.IDCapDuyet,bu.IdUserQuanLyTT";
                    str += " from Busers2 bu ";
                    str += " left join BDepartment bd on bd.ID=bu.BADEPID and bd.GSBH=bu.GSBH";
                    str += " where" + " bu.USERID=@SearchText or bu.USERNAME=@SearchText1  ";
                    cmd.CommandText = str;
                    cmd.Parameters.AddWithValue("@SearchText", this.txtTimKiem.Text.Trim());
                    cmd.Parameters.AddWithValue("@SearchText1", this.txtTimKiem.Text.Trim());
                    cmd.Connection = conn;
                    conn.Open();

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataSet ds = new DataSet();
                        da.Fill(ds);
                        this.GridView1.DataSource = ds;
                        this.GridView1.DataBind();

                    }
                    conn.Close();

                }
            }
        }
        [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
        public static string[] GetCompletionList(string prefixText, int count, string contextKey)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["TheLogiS"].ConnectionString;
            SqlConnection conn = new SqlConnection(connectionString);
            // Try to use parameterized inline query/sp to protect sql injection
            string str="select bu.GSBH,bu.BADEPID,bd.DepName,bu.USERID,bu.USERNAME,bu.IDCapDuyet,bu.IdUserQuanLyTT";
                str +=" from Busers2 bu ";
                str +=" left join BDepartment bd on bd.ID=bu.BADEPID and bd.GSBH=bu.GSBH";
                str +=" where bu.USERID like '%"+prefixText+"%' or bu.USERNAME like '%"+prefixText+"%'";
            SqlCommand cmd = new SqlCommand(str, conn);
            SqlDataReader oReader;
            conn.Open();
            List<string> CompletionSet = new List<string>();
            oReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            while (oReader.Read())
                CompletionSet.Add(oReader["USERID"].ToString());
            CompletionSet.Add(oReader["USERNAME"].ToString());
            return CompletionSet.ToArray();
        }
        public override void GanNgonNguVaoConTrol()
        {
            btnThem.Text = hasLanguege["btnThem"].ToString();
            checkBophan.Text = hasLanguege["lbBoPhan"].ToString();
            btnTimKiem.Text = hasLanguege["btnTimKiem"].ToString();
            checkCanBo.Text = hasLanguege["lblLaCanBo"].ToString();
        }
        public override void GanNgonNguVaoGridView()
        {
            GridView1.Columns[0].HeaderText = hasLanguege["GSBH"].ToString();
            GridView1.Columns[1].HeaderText  = hasLanguege["BADEPID"].ToString();
            GridView1.Columns[2].HeaderText = hasLanguege["lbBoPhan"].ToString();
            GridView1.Columns[3].HeaderText  = hasLanguege["USERID"].ToString();
            GridView1.Columns[4].HeaderText  = hasLanguege["USERNAME"].ToString();
            GridView1.Columns[5].HeaderText = hasLanguege["lbChucVu"].ToString();
            GridView1.Columns[6].HeaderText = hasLanguege["lbChucVu"].ToString()+"VN";
            GridView1.Columns[7].HeaderText = hasLanguege["lbChucVu"].ToString()+"TW";
            GridView1.Columns[8].HeaderText  = hasLanguege["IDCapDuyet"].ToString();
            GridView1.Columns[9].HeaderText = hasLanguege["lbLaCanBoTT"].ToString();
           
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
        private void HienThiDanhSach()
        {
           string congty = Session["congty"].ToString();
           GridView1.DataSource = dal.QryUser(congty);
            GridView1.DataBind();
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
        protected void btnThem_Click(object sender, EventArgs e)
        {
            string match = @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";
            //string ngonngu = Session["languege"].ToString();
           // string macongty = Session["congty"].ToString();
            string macongty = "LTY";
            string idnguoidung = txtMaNV.Text;
            string hoten =  txtTenNV.Text;
            string matkhau = txtmatkhau.Text;
            string matkhau2 = txtmatkhau2.Text;
            string nguoiquanlyTT = txtNguoiQuanLyTT.Text;
          
            string cty = DropCty.SelectedValue.ToString();
            string bophan = DropBoPhan.SelectedValue.ToString();
            string machucvu = DropDownChucVu.SelectedValue.ToString();
            string congty = DropCty.SelectedValue.ToString();
            string fileName = FileUpload1.FileName;

            byte[] fileByte = FileUpload1.FileBytes;
            ChucVu chuc = ChucVuDAO.TimMaChucVu(machucvu, macongty);
            Binary binaryObj = new Binary(fileByte);

            Busers2 user = new Busers2();
            Regex reg = new Regex(match);

            if (reg.IsMatch(this.txtEmail.Text))
            {
                user.EMAIL = txtEmail.Text;
            }
            else
            {
                //if (ngonngu == "lbl_VN")
                //{
                //    lbthongbaoloi.Text = "Email nhập không đúng định dạng, vui lòng nhập lại. Ví dụ: tuan-it@footgear.com.vn";
                //}
                //else if (ngonngu == "lbl_TW")
                //{
                //    lbthongbaoloi.Text = "邮件地址不真确，重新输入，例如: tuan-it@footgear.com.vn";
                //}
                //else if (ngonngu == "lbl_EN")
                //{
                //    lbthongbaoloi.Text = "Enter email not valid, please re-enter. Example:tuan-it@footgear.com.vn ";
                //}
            }
            if (checkCanBo.Checked == true)
            {
                user.isSep = true;
            }
            else
            { user.isSep = false; }
            if (checkBophan.Checked == true)
            {
                user.BADEPID = bophan;
            }
            else
            {
                user.BADEPID = null;
            }
            user.GSBH = congty;
            user.USERID = idnguoidung;
            user.USERNAME = hoten;
            user.PWD = matkhau;
            user.Password2 = libraly.Encryption(matkhau2);
           
            //user.isSep = issep;
            //user.abde = capduyet;
            //user.abstep = buocduyet;
            user.IDCapDuyet = chuc.IDCapDuyet;
            user.IDChucVu = machucvu;
            user.IdUserQuanLyTT = nguoiquanlyTT;
            user.signatue = binaryObj;
            db.Busers2s.InsertOnSubmit(user);
            db.SubmitChanges();
            Response.Redirect("~/presentationLayer/Admin/frmAddUsers.aspx");
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = GridView1.SelectedRow;
            string macongty = row.Cells[1].Text;
            Session["idcongty"] = macongty;
            string manhanvien = row.Cells[3].Text;
        }
        public string GetSTT()
        {
            return Convert.ToString(STT++);
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            int trangthu = e.NewPageIndex;
            int sodong = GridView1.PageSize;
            STT = trangthu * sodong + 1;
            HienThiDanhSach();
        }

        protected void btnQuery_Click(object sender, EventArgs e)
        {
            string macongty = Session["congty"].ToString();
            if (DropBoPhan.SelectedValue.ToString().Trim() == "All")
            {
                GridView1.DataSource = dal.QryUser(macongty);
                GridView1.DataBind();
            }
            else
            {
                string mabophan = DropBoPhan.SelectedValue.ToString();
                GridView1.DataSource = dal.QryUserByDepart(macongty, mabophan);
                GridView1.DataBind();
            }
          
        }

        protected void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            if (txtTimKiem.Text.Trim() == "")
            {
                HienThiDanhSach();
            }
            else
            {

                DataTable dt = dal.TImNguoiTheoDieuKien(txtTimKiem.Text.Trim());
                if (dt.Rows.Count > 0)
                {
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
            }
        }

        protected void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (txtTimKiem.Text.Trim() != "")
            {
                DataTable dt = dal.TImNguoiTheoDieuKien(txtTimKiem.Text.Trim());
                if (dt.Rows.Count > 0)
                {
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
            }
        }

        protected void checkBophan_CheckedChanged(object sender, EventArgs e)
        {
            DropBoPhan.Enabled = true;
        }

        protected void checkCanBo_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void GridView1_SelectedIndexChanged1(object sender, EventArgs e)
        {
            GridViewRow row = GridView1.SelectedRow;
            Label lblMaCT = (Label)row.FindControl("lblGSBH");
            string macongty = lblMaCT.Text.Trim();
            Session["idcongty"] = macongty;
            Label lblMaNV = (Label)row.FindControl("lblUSERID");
            string manhanvien = lblMaNV.Text.Trim();
            Session["manhanvien"] = manhanvien;
            Response.Redirect("frmEditUser.aspx");
            
        }
    }
}