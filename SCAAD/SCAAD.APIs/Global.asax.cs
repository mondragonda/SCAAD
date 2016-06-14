using SCAAD.APIs.Migrations;
using System;


namespace SCAAD.APIs
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //GlobalConfiguration.Configure(WebApiConfig.Register);
            DBMigrationsManager.Configure();
        }
        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            if (Request.HttpMethod == "OPTIONS")
            {
                Response.AddHeader("Cache-Control", "no-cache");
                Response.AddHeader("Access-Control-Allow-Methods", "GET, POST, PUT, DELETE");
                Response.AddHeader("Access-Control-Allow-Headers", "Content-Type, Accept, Authorization");
                Response.AddHeader("Access-Control-Max-Age", "1728000");
                Response.End();
            }
        }




    }
}
