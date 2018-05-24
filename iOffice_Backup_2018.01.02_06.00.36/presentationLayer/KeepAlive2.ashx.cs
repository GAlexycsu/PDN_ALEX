using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
namespace iOffice.presentationLayer
{
    /// <summary>
    /// Summary description for KeepAlive2
    /// </summary>
    public class KeepAlive2 : IHttpHandler,IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Session["KeepAlive2"] = DateTime.Now;
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}