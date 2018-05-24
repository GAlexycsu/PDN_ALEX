using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
namespace iOffice.presentationLayer
{
    /// <summary>
    /// Summary description for KeepAlive3
    /// </summary>
    public class KeepAlive3 : IHttpHandler,IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Session["KeepAlive3"] = DateTime.Now;
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