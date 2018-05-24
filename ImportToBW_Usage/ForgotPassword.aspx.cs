using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Net.Mail;
using System.Net.Sockets;

public partial class ForgotPassword : System.Web.UI.Page
{
    BLL_BUsers bll = new BLL_BUsers();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSend_Click(object sender, EventArgs e)
    {
        string mmail=ConfigurationManager.AppSettings["mail_of_addmin"].ToString();
        string company=ConfigurationManager.AppSettings["Company"].ToString();
        string hostmail = ConfigurationManager.AppSettings["hostmail"].ToString();
        string subject = "[Notify] requirement forget security code";
        string noidung = "";
        string UserID=txtUser.Text.Trim();
        DataTable dt = bll.GetUserByID(UserID, company);
        if (dt.Rows.Count > 0)
        {
            string password=dt.Rows[0]["PWD"].ToString();
            string amail=dt.Rows[0]["EMAIL"].ToString();
          noidung+="Notify : " +UserID+"requirement forgot security code";
          noidung += "Your password is: " + password;
          bool sent = SendMail(mmail, amail, subject, noidung, hostmail);
          if (sent)
          {
              lblThongBao.Text = "Message Sent Successfully. Please check email!";
          }
          else
          {
              lblThongBao.Text = "Failed";
          }
        }
    }

    public  bool SendMail(string from_mail, string listmail, string subject, string body,string hostmail)
    {
        try
        {
            MailMessage mail = new MailMessage(from_mail, listmail);
           
            SmtpClient client = new SmtpClient();
            client.Port = 25;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Host = "mail.footgear.com.vn";
            mail.Subject = subject;
            mail.Body = body;
            mail.IsBodyHtml = true;
            client.Send(mail);
            return true;
        }
        catch (Exception)
        {
            throw;
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("WF_Login.aspx");
    }
}