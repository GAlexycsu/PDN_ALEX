using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
namespace iOffice.SiteMater
{
    public partial class Site8S : System.Web.UI.MasterPage
    {
        userDAL dalUser = new userDAL();
        string macongty = ConfigurationManager.AppSettings["Congty"];
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                
                string UserID = (string)Session["UserID"];
                if (UserID == null)
                {
                    Response.Redirect("Default.aspx");
                }
                else
                {
                    DataTable dtUs = dalUser.TimNhanVienTheoMa(macongty, UserID);
                    if (dtUs.Rows.Count > 0)
                    {
                        lblNhanVien.Text = dtUs.Rows[0]["USERNAME"].ToString();
                    }
                }
                //
            }
        }

        protected void linkHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("pageMain3.aspx");
        }

       

        protected void link8S_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/presentationLayer/Main8S.aspx");
        }

        protected void link8SDetail_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/presentationLayer/page8SDetail.aspx");
            //Response.Redirect("~/presentationLayer/them8S.aspx");
        }

        protected void linkLogout_Click(object sender, EventArgs e)
        {
            Response.Redirect("http://portal.footgear.com.vn/presentationLayer/Default.aspx");
        }

        protected void LinkNews8S_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/presentationLayer/bantin8S.aspx");
        }

        protected void dropDowLanguege_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Lange = dropDowLanguege.SelectedValue.ToString().Trim();
            if (Lange != "select")
            {
                string url = HttpContext.Current.Request.Url.AbsoluteUri;

                string keyVN = "_VN";
                string keyTW = "_TW";
                string keyEN = "_EN";
                Response.Cookies["DropLang"].Expires = DateTime.Now.AddDays(30);
                Response.Cookies["DropLang"].Value = dropDowLanguege.SelectedValue;
                string[] url1 = url.Split('_');
                if (url1.Length > 1)
                {

                    string urlMain = url1[0];
                    //string[] lang1 = Lange.Split('_');
                    string langmain = url1[1];
                    string ABC = "";
                    Session["languege"] = Lange;
                    if (Lange == "lbl_VN")
                    {
                        ABC = (urlMain + keyVN).ToString();

                        Response.Redirect(ABC);


                    }
                    else
                    {
                        if (Lange == "lbl_TW")
                        {
                            ABC = (urlMain + keyTW).ToString();
                            Response.Redirect(ABC);
                        }
                        else
                        {
                            if (Lange == "lbl_EN")
                            {
                                ABC = (urlMain + keyEN).ToString();
                                Response.Redirect(ABC);
                            }
                            else
                            {
                                Response.Redirect(url);
                            }
                        }

                    }
                }
                else
                {
                    Session["languege"] = Lange;
                    Response.Redirect(url);
                }
            }
        }

        protected void LinkScore_Click(object sender, EventArgs e)
        {
            //erver.Transfer("Rport8SScore.aspx");
            Response.Redirect("Rport8SScore.aspx");
        }
    }
}