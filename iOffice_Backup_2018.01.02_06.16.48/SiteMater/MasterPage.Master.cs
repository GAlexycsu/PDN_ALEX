﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
namespace iOffice.SiteMater
{
    public partial class MasterPage : System.Web.UI.MasterPage
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
            }
        }

        protected void linkHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("pageMain3.aspx");
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("http://portal.footgear.com.vn/presentationLayer/Default.aspx");
        }
    }
}