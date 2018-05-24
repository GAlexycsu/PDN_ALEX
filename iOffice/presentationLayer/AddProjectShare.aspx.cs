using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
namespace iOffice.presentationLayer
{
    public partial class AddProjectShare : System.Web.UI.Page
    {
        departDAL dalDepart = new departDAL();

        userDAL dalUser = new userDAL();
        DAL_ProjectShare dal = new DAL_ProjectShare();
        string congty = ConfigurationManager.AppSettings["Congty"].ToString();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                HienThiDropDowSystem();
                HienThiDonViLenDropDowslist();
                DropDownSystem.Items.Insert(0, new ListItem("","0"));
                DropDownDonVi.Items.Insert(0,new ListItem("","0"));
                string SystemChange = (string)Session["SystemChange"];
                string SubSystemChange = (string)Session["SubSystemChange"];
                string jobChange = (string)Session["jobChange"];
                if (SystemChange != null)
                {
                    DropDownSystem.SelectedValue = SystemChange;
                }
                if(SubSystemChange!=null)
                {
                    DropDownSubSystem.SelectedValue = SubSystemChange;
                }
                if (jobChange != null)
                {
                    DropDownJob.SelectedValue = jobChange;
                }
                DivList.Visible = false;
            }
        }

        public void HienThiDonViLenDropDowslist()
        {
            DataTable dt = dalDepart.QryDonVi(congty);
            DropDownDonVi.DataSource = dt;
            DropDownDonVi.DataValueField = "ID";
            DropDownDonVi.DataTextField = "DepName";
            DropDownDonVi.DataBind();

        }
        public void HienThiListTimTuDropDow()
        {
            string MaDV = DropDownDonVi.SelectedValue;
            DataTable dt = dalUser.TimNhanVienTheoMaDonVi(congty, MaDV);
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
            DataTable dt = dalUser.TimNhanVienTheoMa(congty, MaNV);
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
        public void HienThiDropDowSystem()
        {
            string UserID = (string)Session["UserID"];
            string GSBH = (string)Session["congty"];
            DataTable dt = dal.HienThiDropDowSystemTheoUserID(GSBH, UserID);
            if (dt.Rows.Count > 0)
            {
                DropDownSystem.DataSource = dt;
                DropDownSystem.DataValueField = "jsysid";
                DropDownSystem.DataTextField = "SysTemName";
                DropDownSystem.DataBind();
            }
            else
            {
                DropDownSystem.DataSource = dt;
               
                DropDownSystem.DataBind();
            }
        }
        public void HienThiDropDowSubSystem()
        {
            string UserID = (string)Session["UserID"];
            string GSBH = (string)Session["congty"];
            string System = DropDownSystem.SelectedValue.ToString().Trim();
            if (System != "")
            {
                DataTable dt = dal.HienThiDropDowSubSystemTheoUserID(GSBH, UserID, System);
                if (dt.Rows.Count > 0)
                {
                    DropDownSubSystem.DataSource = dt;
                    DropDownSubSystem.DataValueField = "jsubid";
                    DropDownSubSystem.DataTextField = "jsubname";
                    DropDownSubSystem.DataBind();
                }
                else
                {
                    DropDownSubSystem.DataSource = dt;

                    DropDownSubSystem.DataBind();
                }
            }
            else
            {
                DropDownSubSystem.DataSource = null;
                DropDownSubSystem.DataBind();
            }
        }
        public void HienThiJoblenDrop()
        {
            string UserID = (string)Session["UserID"];
            string GSBH = (string)Session["congty"];
            string System = DropDownSystem.SelectedValue.ToString().Trim();
            string SubSystem = DropDownSubSystem.SelectedValue;
            if (System != "0")
            {
                DataTable dt=dal.HienThiDropJobBySubSystem(GSBH,UserID,System,SubSystem);
                if (dt.Rows.Count > 0)
                {
                    DropDownJob.DataSource = dt;
                    DropDownJob.DataValueField = "jobid";
                    DropDownJob.DataTextField = "jobname";
                    DropDownJob.DataBind();
                }
                else
                {
                    DropDownJob.DataSource = dt;
                    DropDownJob.DataBind();
                }
            }
            else
            {
                DropDownJob.DataSource = null;
                DropDownJob.DataBind();
            }

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

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("ShareProject.aspx");
        }

        protected void DropDownSystem_SelectedIndexChanged(object sender, EventArgs e)
        {
            string systemID=DropDownSystem.SelectedValue.ToString();

            if (systemID != "0")
            {
                string SystemChange = DropDownSystem.SelectedValue.ToString();
                Session["SystemChange"] = SystemChange;
                HienThiDropDowSubSystem();
                HienThiJoblenDrop();
               
            }
            else
            {
                DropDownSubSystem.DataSource = null;
                DropDownSubSystem.DataBind();
                DropDownJob.DataSource = null;
                DropDownJob.DataBind();
            }
        }

        protected void DropDownSubSystem_SelectedIndexChanged(object sender, EventArgs e)
        {
            string SubSystem = DropDownSubSystem.SelectedValue.ToString();
            Session["SubSystemChange"] = SubSystem;
            HienThiJoblenDrop();
           
        }

        protected void DropDownJob_SelectedIndexChanged(object sender, EventArgs e)
        {
            string jobChange = DropDownJob.SelectedValue.ToString();
            Session["jobChange"] = jobChange;
        }

        protected void btnLuu_Click(object sender, EventArgs e)
        {
            string SystemID=DropDownSystem.SelectedValue;
            string Subsystem=DropDownSubSystem.SelectedValue;
            string jobID=DropDownJob.SelectedValue;
         
            string Subject=txtSubject.Text.Trim();
            string UserID=Session["UserID"].ToString();
            string yn="0";
             for (int i = 0; i < listXuLy.Items.Count; i++)
            {
                if (listXuLy.Items[i].Selected == true)
                {
                    string UserID2 = listXuLy.Items[i].Value;
                    dal.ThemProjectShare(congty, SystemID, Subsystem, jobID, Subject, UserID2, UserID, yn);
                    
                }
            }
           
        }

    }
}