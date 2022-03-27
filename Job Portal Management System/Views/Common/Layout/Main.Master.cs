﻿using System;
using System.Threading;

namespace Job_Portal_Management_System.Views.Common.Layout
{
    public partial class Main : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void onclick_btnlogout(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Session.Abandon();
            Response.Redirect("~/Views/Home.aspx");
        }
    }
}