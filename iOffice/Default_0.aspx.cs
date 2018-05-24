using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace iOffice
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Redirect("~/presentationLayer/Default.aspx");
        }

    }
        //static void  Main(string[] args)
        //{
        //    //AuthConfig.RegisterOpenAuth();  
        //}
}