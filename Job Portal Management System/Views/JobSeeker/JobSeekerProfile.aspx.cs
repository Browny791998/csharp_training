using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Job_Portal_Management_System.Views.JobSeeker
{
    public partial class JobSeekerProfile : System.Web.UI.Page
    {
     
        JobPortal_Services.JobSeeker.JobSeekerService jobseekerservice = new JobPortal_Services.JobSeeker.JobSeekerService();
        DataTable da = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["email"] == null)
            {
                Response.Redirect("~/Views/Login.aspx");
            }
            GetAcc();
        }

        public void GetAcc()
        {
            int id = Convert.ToInt32(Session["id"]);
            da = JobPortal_Services.JobSeeker.JobSeekerService.GetAllData(id);
            rptJobseeker.DataSource = da;
           rptJobseeker.DataBind();
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            
            var btn = (Button)sender;
            var item = (RepeaterItem)btn.NamingContainer;
            var IdValue = ((Label)item.FindControl("jobseekerId")).Text;

            Response.Redirect("JobSeekerEdit.aspx?ID=" + IdValue);
        }
    }
}