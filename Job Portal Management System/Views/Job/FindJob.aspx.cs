using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Job_Portal_Management_System.Views.Job
{
    public partial class FindJob : System.Web.UI.Page
    {
        DataTable da = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindJob();
            }
        }

        public void BindJob()
        {
           
            da = JobPortal_Services.Job.JobService.GetActiveData();
            rptJoblist.DataSource = da;
            rptJoblist.DataBind();
        }
    }
}