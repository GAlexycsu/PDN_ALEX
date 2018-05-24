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
    public partial class EditProjectShare : System.Web.UI.Page
    {
        DAL_ProjectShare dal = new DAL_ProjectShare();
        departDAL dalDepart = new departDAL();

        userDAL dalUser = new userDAL();
        
        string congty = ConfigurationManager.AppSettings["Congty"].ToString();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string UserID = (string)Session["UserID"];
                string jSystem = (string)Request["jSystem"];
                string jsubsystem = (string)Request["jsubsystem"];
                string jJobid = (string)Request["jJobid"];
                string jUserShare = (string)Request["jUserShare"];
                if (jSystem != null && jsubsystem != null && jJobid != null && jUserShare != null)
                {
                    Session["jSystem"] = jSystem;
                    Session["jsubsystem"] = jsubsystem;
                    Session["jJobid"] = jJobid;
                    Session["jUserShare"] = jUserShare;
                   
                }
                Qry();
                HienThiDropDowSystem();
                HienThiDropDowSubSystem();
                HienThiJoblenDrop();
                DropDownJob.DataValueField = jJobid;
                string SystemChange = (string)Session["SystemChange"];
                string SubSystemChange = (string)Session["SubSystemChange"];
                string jobChange = (string)Session["jobChange"];
                if (SystemChange != null)
                {
                    DropDownSystem.SelectedValue = SystemChange;
                }
                if (SubSystemChange != null)
                {
                    DropDownSubSystem.SelectedValue = SubSystemChange;
                }
                if (jobChange != null)
                {
                    DropDownJob.SelectedValue = jobChange;
                }
                
            }
        }
        public void HienThiDropDowSystem()
        {
            string UserID = (string)Session["UserID"];
            string GSBH = (string)Session["congty"];
            string jSystem = (string)Session["jSystem"];
            DataTable dt = dal.HienThiDropDowSystemTheoUserIDSua(GSBH, UserID,jSystem);
            if (dt.Rows.Count > 0)
            {
                DropDownSystem.DataSource = dt;
                DropDownSystem.DataValueField = "jsysid";
                DropDownSystem.DataTextField = "SysTemName";
                DropDownSystem.DataBind();
                // 
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
            string SubSystem = Session["jsubsystem"].ToString();
            
                DataTable dt = dal.HienThiDropDowSubSystemTheoUserIDByID(GSBH, UserID, SubSystem);
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
        public void HienThiJoblenDrop()
        {
            string UserID = (string)Session["UserID"];
            string GSBH = (string)Session["congty"];
            string System = DropDownSystem.SelectedValue.ToString().Trim();
            string SubSystem = DropDownSubSystem.SelectedValue;
            string jJobid = Session["jJobid"].ToString();
            if (System != "0")
            {
                DataTable dt = dal.HienThiDropJobBySubSystem(GSBH, UserID, System, SubSystem);
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
        public void Qry()
        {
            string UserID = (string)Session["UserID"];
            string jSystem = (string)Session["jSystem"];
            string jsubsystem = (string)Session["jsubsystem"];
            string jJobid = (string)Session["jJobid"];
            string jUserShare = (string)Session["jUserShare"];
            // 
            DataTable dt = dal.LayProjectUSua(congty, jSystem, jsubsystem, jJobid, jUserShare, UserID);
            if (dt.Rows.Count > 0)
            {
                txtFullName.Text = dt.Rows[0]["USERNAME"].ToString();
                txtSubject.Text = dt.Rows[0]["juamemo"].ToString();
                txtUserName.Text = dt.Rows[0]["Juserid"].ToString();
                txtUserTemp.Text = dt.Rows[0]["Juserid"].ToString();
                txtJobTemp.Text = dt.Rows[0]["Jodid"].ToString();

            }
        }
        public void HienThiListTimTuTextBox()
        {
            string MaNV = txtUserName.Text;
            DataTable dt = dalUser.TimNhanVienTheoMa(congty, MaNV);
            if (dt.Rows.Count > 0)
            {
                txtUserName.Text = dt.Rows[0]["USERID"].ToString();
                txtFullName.Text = dt.Rows[0]["USERNAME"].ToString();
            }
            else
            {
                txtFullName.Text = "";
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

        protected void txtUserName_TextChanged(object sender, EventArgs e)
        {
            string NVMa = txtUserName.Text.Trim();
            if (NVMa != "")
            {
                HienThiListTimTuTextBox();
               
            }
            
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
             string UserID = (string)Session["UserID"];
            string Jsystem=DropDownSystem.SelectedValue.ToString().Trim();
            string JSubsystem=DropDownSubSystem.SelectedValue.ToString().Trim();
            string JobNew=DropDownJob.SelectedValue.ToString().Trim();
            string USerShareNew=txtUserName.Text.Trim();;
            string memo=txtSubject.Text.Trim();
            dal.SuaProjectShare(congty, Jsystem, JSubsystem, txtJobTemp.Text.Trim(),txtUserTemp.Text.Trim(), UserID, memo, USerShareNew, JobNew);
            Response.Redirect("ShareProject.aspx");
        }
    }
}