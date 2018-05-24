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
    public partial class ShareJobWith : System.Web.UI.Page
    {
        string Congty = ConfigurationManager.AppSettings["Congty"].ToString();
        departDAL dalDepart = new departDAL();

        userDAL dalUser = new userDAL();
        DAL_ProjectShare dal = new DAL_ProjectShare();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                HienThiDonViLenDropDowslist1();
                DropDownDonVi.Items.Insert(0, new ListItem("", "0"));
                HienThiThongTin();
                HienThiDanhSachShare();
            }
        }
        public void HienThiDonViLenDropDowslist1()
        {
            DataTable dt = dalDepart.QryDonVi(Congty);
            DropDownDonVi.DataSource = dt;
            DropDownDonVi.DataValueField = "ID";
            DropDownDonVi.DataTextField = "DepName";
            DropDownDonVi.DataBind();

        }
        public void HienThiThongTin()
        {
            string UserID = (string)Session["UserID"];
            string SystemID = (string)Request["SystemID"];
            string SubSystemID = (string)Request["SubsystemID"];
            string JobID = (string)Request["JobID"];
            if (UserID!=null&& SystemID != null && SubSystemID != null && JobID != null)
            {
                DataTable dt = dal.HienThiThongTiJobTheoID(Congty, SystemID, SubSystemID, JobID, UserID);
                if (dt.Rows.Count > 0)
                {
                    lblSystemName.Text = dt.Rows[0]["sysname"].ToString();
                    lblSubSystem.Text = dt.Rows[0]["jsubname"].ToString();
                    lblJobName.Text = dt.Rows[0]["jobname"].ToString();
                    lblSystemID.Text = dt.Rows[0]["jsysid"].ToString();
                    lblSubSystemID.Text = dt.Rows[0]["jsubid"].ToString();
                    lblJobID.Text = dt.Rows[0]["jobid"].ToString();
                }
            }
        }
        public void HienThiDonViLenDropDowslist()
        {
            DataTable dt = dalDepart.QryDonVi(Congty);
            DropDownDonVi.DataSource = dt;
            DropDownDonVi.DataValueField = "ID";
            DropDownDonVi.DataTextField = "DepName";
            DropDownDonVi.DataBind();

        }
        public void HienThiListTimTuDropDow()
        {
            string MaDV = DropDownDonVi.SelectedValue;
            DataTable dt = dalUser.TimNhanVienTheoMaDonVi(Congty, MaDV);
            if (dt.Rows.Count > 0)
            {
                ListQuery.Visible = true;
                listXuLy.Visible = true;
                ListQuery.DataSource = dt;
                ListQuery.DataBind();
                DivList.Visible = true;
            }
            else
            {
                ListQuery.DataSource = null;
                ListQuery.DataBind();
            }

        }
        public void HienThiListTimTuTextBox()
        {
            string MaNV = txtUserName.Text;
            DataTable dt = dalUser.TimNhanVienTheoMa(Congty, MaNV);
            if (dt.Rows.Count > 0)
            {
                ListQuery.Visible = true;
                listXuLy.Visible = true;
                ListQuery.DataSource = dt;
                ListQuery.DataBind();
                DivList.Visible = true;
            }
            else
            {
                ListQuery.DataSource = null;
                ListQuery.DataBind();
            }

        }
        public void HienThiListTimTuTextBox1()
        {
            string MaNV = txtUserName.Text;
            DataTable dt = dalUser.TImNguoiTheoDieuKien(MaNV);
            if (dt.Rows.Count > 0)
            {
                ListQuery.Visible = true;
                listXuLy.Visible = true;
                ListQuery.DataSource = dt;
                ListQuery.DataBind();
            }
            else
            {
                ListQuery.DataSource = null;
                ListQuery.DataBind();
            }

        }
        protected void btnLuu_Click(object sender, EventArgs e)
        {
            string SystemID = lblSystemID.Text.Trim();
            string Subsystem = lblSubSystemID.Text.Trim();
            string jobID = lblJobID.Text.Trim();

            string Subject = txtSubject.Text.Trim();
            string UserID = Session["UserID"].ToString();
            string yn = "0";
            for (int i = 0; i < listXuLy.Items.Count; i++)
            {
                if (listXuLy.Items[i].Selected == true)
                {
                    string UserID2 = listXuLy.Items[i].Value;
                    dal.ThemProjectShare(Congty, SystemID, Subsystem, jobID, Subject, UserID2, UserID, yn);

                }
            }
            HienThiDanhSachShare();
            
        }
        public void HienThiDanhSachShare()
        {
            string SystemID = lblSystemID.Text.Trim();
            string Subsystem = lblSubSystemID.Text.Trim();
            string jobID = lblJobID.Text.Trim();
            GridView1.DataSource = dal.QryNguoiDuocShareJob(Congty, SystemID, Subsystem, jobID);
            GridView1.DataBind();
        }
        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/presentationLayer/WF_Projectm.aspx");
        }

        protected void txtUserName_TextChanged(object sender, EventArgs e)
        {
            string NVMa = txtUserName.Text.Trim();
            if (NVMa != "")
            {
                HienThiListTimTuTextBox();
                txtUserName.Text = "";
            }
            else
            {
                ListQuery.DataSource = null;
                ListQuery.DataBind();
            }
        }

        protected void DropDownDonVi_SelectedIndexChanged(object sender, EventArgs e)
        {
            string drop = DropDownDonVi.SelectedValue.ToString().Trim();
            if (drop != "0")
            {
                HienThiListTimTuDropDow();
            }
            else
            {
                ListQuery.DataSource = null;
                ListQuery.DataBind();
            }
        }

        protected void btnThemList_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < ListQuery.Items.Count; i++)
            {
                if (ListQuery.Items[i].Selected == true || ListQuery.Items.Count == 1)
                {
                    listXuLy.Items.Add(ListQuery.Items[i]);
                    ListQuery.Items.RemoveAt(i);
                }
            }
        }

        protected void btnDeleteList_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listXuLy.Items.Count; i++)
            {
                if (listXuLy.Items[i].Selected == true || listXuLy.Items.Count == 1)
                {
                    ListQuery.Items.Add(listXuLy.Items[i]);
                    listXuLy.Items.RemoveAt(i);
                }
            }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Label lblUser = (Label)GridView1.Rows[e.RowIndex].FindControl("lblJuserid");
            dal.XoaNguoiTrongDanhSachShare(Congty, lblSystemID.Text.Trim(), lblSubSystemID.Text.Trim(), lblJobID.Text.Trim());
            HienThiDanhSachShare();
        }
    }
}