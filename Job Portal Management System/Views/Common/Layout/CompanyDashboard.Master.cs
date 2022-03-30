﻿using System;

namespace Job_Portal_Management_System.Views.Common.Layout
{
    public partial class CompanyDashboard : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["role"] == null || Session["role"].ToString() != "Company")
            {
                Response.Redirect("~/Views/Login.aspx");
            }
        }

        protected void btnCreateJob_Click(object sender, EventArgs e)
        {
            Session.Remove("label");
            Response.Redirect("~/Views/Job/CreateJob.aspx");
        }
    }
}