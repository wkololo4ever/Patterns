﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Text;

namespace Caching
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {

        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }

        public override string GetVaryByCustomString(HttpContext context, string custom)
        {
            if(custom=="formdata")
            {
                var keys = context.Request.Form.AllKeys.Where(k => !k.StartsWith("__")).OrderBy(k => k);

                StringBuilder sb = new StringBuilder(Request.FilePath);
                foreach(string key in keys)
                {
                    sb.AppendFormat("&{0}={1}", key, context.Request.Form[key]);
                }
                return sb.ToString();

            }
            else
            {
                return base.GetVaryByCustomString(context, custom);
            }
        }

        public override string GetOutputCacheProviderName(HttpContext context)
        {
            return Request.RequestType == "POST" ? "AspNetInternalProvider" : "custom";
        }
    }
}