﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
namespace iOffice.presentationLayer
{
    /// <summary>
    /// Summary description for KeepAlive
    /// </summary>
    public class KeepAlive : IHttpHandler,IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Session["KeepAlive"] = DateTime.Now;
        }

        public bool IsReusable
        {
            get
            {
                return false
;
            }
        }
    }



}