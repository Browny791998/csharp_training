using System;

namespace Job_Portal_Management_System.Views.Common.Layout
{
    public partial class AdminDashboard : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["role"] == null || Session["role"].ToString() != "admin")
            {
                Response.Redirect("~/Views/User/Login.aspx");
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Session.Abandon();
            Response.Redirect("~/Views/User/Login.aspx");
        }
    }
}