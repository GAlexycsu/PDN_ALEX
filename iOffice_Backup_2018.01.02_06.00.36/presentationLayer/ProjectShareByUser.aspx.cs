using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using Telerik.Web.UI;
namespace iOffice.presentationLayer
{
    public partial class ProjectShareByUser : System.Web.UI.Page
    {
        DAL_ProjectShare dal = new DAL_ProjectShare();
        string Status = string.Empty;
        string congty = ConfigurationManager.AppSettings["Congty"].ToString();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                HienThiUserLenDropDow();
                RaScheduler_Load();
              
            }
        }
        public void HienThiUserLenDropDow()
        {
            string UserID = Session["UserID"].ToString();
            DataTable dt = dal.QryUserLenDropBoxShare(congty, UserID);
            if (dt.Rows.Count > 0)
            {
                DropDownUserName.DataSource = dt;
                DropDownUserName.DataValueField = "userid";
                DropDownUserName.DataTextField = "USERNAME";
                DropDownUserName.DataBind();
            }
        }
        private void RaScheduler_Load()
        {
            string UserID = Session["UserID"].ToString();
            // string UserID = "27276";
            string UserShare=DropDownUserName.SelectedValue;
            DataTable dt = dal.QryTheoAuditor_Calendar(UserShare,UserID,congty);
            List<OCanlendar> list = new List<OCanlendar>();
            list = Common.ConvertTo<OCanlendar>(dt).ToList();
            RadScheduler1.DataSource = list;
            RadScheduler1.DataBind();
        }

        protected void RadScheduler1_FormCreated(object sender, Telerik.Web.UI.SchedulerFormCreatedEventArgs e)
        {
            string UserID = (string)Session["UserID"].ToString();
            //string UserID = "27276";
          
            if (UserID == null)
            {
                Response.Redirect("http://portal.footgear.com.vn/");
            }
            else
            {
                if (e.Container.Mode == SchedulerFormMode.Insert)
                {
                    Status = "Insert";

                }
                if (e.Container.Mode == SchedulerFormMode.AdvancedInsert)
                {
                    Status = "AdvancedInsert";
                    RadDateTimePicker startInput = (RadDateTimePicker)e.Container.FindControl("StartInput");
                    RadDateTimePicker endInput = (RadDateTimePicker)e.Container.FindControl("EndInput");
                    startInput.SelectedDate = e.Appointment.Start;
                    endInput.SelectedDate = e.Appointment.End;


                }

                if (e.Container.Mode == SchedulerFormMode.AdvancedEdit)
                {
                    HiddenField hdffID = ((HiddenField)e.Container.FindControl("hdfID"));
                    hdffID.Value = e.Appointment.ID.ToString();
                    DataTable dt = dal.QryTheoTheoID(int.Parse(hdffID.Value));
                    TextBox subjectBox = (TextBox)e.Container.FindControl("SubjectTextBox");
                    subjectBox.Text = e.Appointment.Subject;
                    RadDateTimePicker startInput = (RadDateTimePicker)e.Container.FindControl("StartInput");
                    startInput.SelectedDate = RadScheduler1.DisplayToUtc(e.Appointment.Start);
                    RadDateTimePicker endInput = (RadDateTimePicker)e.Container.FindControl("EndInput");
                    endInput.SelectedDate = RadScheduler1.DisplayToUtc(e.Appointment.End);

                    RadTextBox txtDescription = (RadTextBox)e.Container.FindControl("txtDescription");
                    txtDescription.Text = e.Appointment.Description;
                    RadTextBox txtLink = (RadTextBox)e.Container.FindControl("txtLink");
                    RadNumericTextBox txtPhanTram = (RadNumericTextBox)e.Container.FindControl("txtPhanTram");
                    OCanlendar objec = new OCanlendar();
                    txtLink.Text = dt.Rows[0]["wklink"].ToString();
                    txtPhanTram.Text = dt.Rows[0]["jobpercent"].ToString();
                }
            }
        }

      

        protected void btnQuery_Click(object sender, EventArgs e)
        {
            RaScheduler_Load();
        }

       

      

        protected void RadScheduler1_AppointmentDataBound(object sender, SchedulerEventArgs e)
        {
            DateTime ngayhomnay = DateTime.Today;
            //string ngaybatdau = DateTime.Parse(e.Appointment.Start.ToString()).ToString("dd-MM-yyyy");
            //string ngayketthuc = DateTime.Parse(e.Appointment.End.ToString()).ToString("dd-MM-yyyy");
            //DateTime end = DateTime.Parse(ngayketthuc);

            string p1 = e.Appointment.Attributes["jobpercent"];
            if (p1 == null)
            {
                p1 = "0";
            }

            string aa = "";
            aa += e.Appointment.Subject;
            aa += " Start:" + e.Appointment.Start.ToString("dd/MM/yyyy") + " End: " + e.Appointment.End.ToString("dd/MM/yyyy");
            aa += " Complete: " + p1 + " %";
            decimal phantram;
            try
            {
                phantram = decimal.Parse(p1);
            }
            catch
            {
                phantram = 0;
            }

            e.Appointment.ForeColor = System.Drawing.Color.Blue;

            e.Appointment.ToolTip = aa;

            if (ngayhomnay > e.Appointment.End)
            {
                if (phantram == 100)
                {
                    e.Appointment.BackColor = System.Drawing.Color.Turquoise;
                }
                else
                {
                    e.Appointment.BackColor = System.Drawing.Color.Tomato;
                }
            }
            else
            {
                if (phantram == 100)
                {
                    e.Appointment.BackColor = System.Drawing.Color.Turquoise;
                }
                else
                {
                    e.Appointment.BackColor = System.Drawing.Color.Silver;
                }
            }
        }

        protected void btnView_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewShare.aspx");
        }
    }
}