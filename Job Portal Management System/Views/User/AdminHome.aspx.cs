using System;
using System.Data;
using System.Text;

namespace Job_Portal_Management_System.Views
{
    public partial class AdminHome : System.Web.UI.Page
    {
        #region variable declaration

        private DataTable da = new DataTable();

        #endregion variable declaration

        #region bind data

        /// <summary>
        /// bind data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["email"] == null || Session["role"] == null)
            {
                Response.Redirect("~/Views/User/Login.aspx");
            }
            da = JobPortal_Services.JobSeeker.JobSeekerService.GetAllJobSeeker();
            lblJobseeker.Text = da.Rows.Count.ToString();
            da = JobPortal_Services.Company.CompanyService.GetCompanyAllData();
            lblCompany.Text = da.Rows.Count.ToString();
            da = JobPortal_Services.Job.JobService.GetActiveData();
            lblJob.Text = da.Rows.Count.ToString();

            da = JobPortal_Services.JobSeeker.JobSeekerService.GetChartData();

            if (da.Rows.Count > 0)
            {
                string ChartData = "";
                string views = "";
                StringBuilder sb = new StringBuilder();
                ChartData += "<script>";
                for (int i = 0; i < da.Rows.Count; i++)
                {
                    views += da.Rows[i]["JobSeeker"] + ",";
                    sb.AppendFormat("'{0}'" + ",", da.Rows[i]["Day"]);
                }

                views = views.Substring(0, views.Length - 1);
                ChartData += " chartLabels=[" + sb + "];chartData=[" + views + "]";
                ChartData += "</script>";
                ltChartData.Text = ChartData;
            }

            da = JobPortal_Services.Company.CompanyService.GetChartData();
            if (da.Rows.Count > 0)
            {
                string CompanyData = "";
                string totalcompany = "";
                StringBuilder sb = new StringBuilder();
                CompanyData += "<script>";
                for (int i = 0; i < da.Rows.Count; i++)
                {
                    totalcompany += da.Rows[i]["Company"] + ",";
                    sb.AppendFormat("'{0}'" + ",", da.Rows[i]["Day"]);
                }
                totalcompany = totalcompany.Substring(0, totalcompany.Length - 1);
                CompanyData += "companyWeek=[" + sb + "];totalcompany=[" + totalcompany + "]";
                CompanyData += "</script>";
                ltCompanyData.Text = CompanyData;
            }

            da = JobPortal_Services.JobOffer.JobOfferService.GetChartData();
            if (da.Rows.Count > 0)
            {
                string JobOfferData = "";
                string applier = "";
                StringBuilder sb = new StringBuilder();
                JobOfferData += "<script>";
                for (int i = 0; i < da.Rows.Count; i++)
                {
                    applier += da.Rows[i]["applier"] + ",";
                    sb.AppendFormat("'{0}'" + ",", da.Rows[i]["Company"]);
                }

                applier = applier.Substring(0, applier.Length - 1);
                JobOfferData += "company=[" + sb + "];applier=[" + applier + "]";
                JobOfferData += "</script>";
                ltApplierData.Text = JobOfferData;
            }
        }

        #endregion bind data
    }
}