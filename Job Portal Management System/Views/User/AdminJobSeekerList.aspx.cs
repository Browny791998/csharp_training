using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Job_Portal_Management_System.Views.User
{
    public partial class AdminJobSeekerList : System.Web.UI.Page
    {
        JobPortal_Models.JobSeeker.JobSeeker jobseekermodel = new JobPortal_Models.JobSeeker.JobSeeker();
        JobPortal_Services.JobSeeker.JobSeekerService jobseekerservice = new JobPortal_Services.JobSeeker.JobSeekerService();
        DataTable da = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetData();
            }
        }

        #region Get Data
        /// <summary>
        /// Get Data
        /// </summary>
        public void GetData()
        {

            da = JobPortal_Services.JobSeeker.JobSeekerService.GetAllJobSeeker();
            if (da.Rows.Count > 0)
            {
                grvJobSeeker.DataSource = da;
                grvJobSeeker.DataBind();
                grvJobSeeker.Visible = true;
                grvJobSeeker.UseAccessibleHeader = true;
                grvJobSeeker.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            else
            {
                grvJobSeeker.DataSource = null;
                grvJobSeeker.DataBind();
            }

        }
        #endregion

        protected void grvJobSeeker_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvJobSeeker.PageIndex = e.NewPageIndex;
            this.GetData();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            da = JobPortal_Services.JobSeeker.JobSeekerService.SearchAllJobSeeker(txtSearch.Text);
            if (da.Rows.Count > 0)
            {
                grvJobSeeker.DataSource = da;
                grvJobSeeker.DataBind();
                grvJobSeeker.Visible = true;
            }
            else
            {
                grvJobSeeker.DataSource = null;
                grvJobSeeker.DataBind();
            }
            grvJobSeeker.UseAccessibleHeader = true;
            grvJobSeeker.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
    }
}