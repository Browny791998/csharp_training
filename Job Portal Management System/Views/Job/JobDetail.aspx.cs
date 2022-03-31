using System;
using System.Data;
using Job_Portal_Management_System.Properties;
namespace Job_Portal_Management_System.Views.Job
{
    public partial class JobDetail : System.Web.UI.Page
    {
        #region variable declaration

        private JobPortal_Models.JobOffer.JobOffer joboffermodel = new JobPortal_Models.JobOffer.JobOffer();
        private JobPortal_Services.JobOffer.JobOfferService jobofferservice = new JobPortal_Services.JobOffer.JobOfferService();
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
            if (!IsPostBack)
            {
                string strReq = "";
                strReq = Request.RawUrl;
                strReq = strReq.Substring(strReq.IndexOf('?') + 1);
                if (Session["url"] == null)
                {
                    Session["url"] = strReq;
                }
                else if (strReq != Session["url"].ToString())
                {
                    Session["alert"] = Message.I0009;
                    Session["alert-type"] = "warning";
                    strReq = Session["url"].ToString();
                }
                if (!strReq.Equals(""))
                {
                    strReq = DecryptQueryString(strReq);
                    string[] arrMsgs = strReq.Split('&');
                    string[] arrIndMsg;
                    string JobID = "";
                    string CID = "";
                    arrIndMsg = arrMsgs[0].Split('=');
                   JobID = arrIndMsg[1].ToString().Trim();
                    arrIndMsg = arrMsgs[1].Split('=');
                    CID = arrIndMsg[1].ToString().Trim();
                    hfJobID.Value = JobID;
                    hfCID.Value= CID;
                    BindJob();
                    BindCompany();
                }
                else
                {
                    Session["alert"] = Message.I0009;
                    Session["alert-type"] = "warning";
                }
             }
        }

        /// <summary>
        /// bind job data
        /// </summary>
        public void BindJob()
        {
            int Jobid = Convert.ToInt32(hfJobID.Value);
            da = JobPortal_Services.Job.JobService.GetData(Jobid);
            rptJob.DataSource = da;
            rptJob.DataBind();
        }

        private string DecryptQueryString(string strQueryString)
        {
            EncryptDecryptQueryString objEDQueryString = new EncryptDecryptQueryString();
            return objEDQueryString.Decrypt(strQueryString, "r0b1nr0y");
        }

        /// <summary>
        /// bind company data
        /// </summary>
        public void BindCompany()
        {
            int companyid = Convert.ToInt32(hfCID.Value);
            da = JobPortal_Services.Company.CompanyService.GetAllData(companyid);
            rptcompany.DataSource = da;
            rptcompany.DataBind();
        }

        #endregion bind data

        #region InsertData

        /// <summary>
        /// InsertData
        /// </summary>
        private void InsertData()
        {
            joboffermodel.JobSeekerID = Convert.ToInt32(Session["id"]);
            joboffermodel.CompanyID = Convert.ToInt32(hfCID.Value);
            joboffermodel.JobID = Convert.ToInt32(hfJobID.Value);
            joboffermodel.AppliedDate = DateTime.Now;
        }

        #endregion InsertData

        #region check user

        /// <summary>
        /// check user or not
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnApply_Click(object sender, EventArgs e)
        {
            if (Session["email"] == null)
            {
                Response.Redirect("~/Views/Login.aspx");
            }
            else if (Session["role"].ToString() == "Company" && Session["role"].ToString() != "Job Seeker")
            {
                Session["alert"] = Message.I0017;
                Session["alert-type"] = "warning";
            }
            else
            {
             da = JobPortal_Services.JobOffer.JobOfferService.GetJobandSeeker(Convert.ToInt32(hfJobID.Value), Convert.ToInt32(Session["id"]));
                if (da.Rows.Count > 0)
                {
                    Session["alert"] = Message.I0018;
                    Session["alert-type"] = "danger";
                }
                else
                {
                    InsertData();
                    bool success = JobPortal_Services.JobOffer.JobOfferService.Insert(joboffermodel);
                    if (success)
                    {
                        Session["alert"] = Message.I0019;
                        Session["alert-type"] = "success";
                    }
                    else
                    {
                        Session["alert"] = Message.I0020;
                        Session["alert-type"] = "danger";
                    }
                }
            }
        }

        #endregion check user
    }
}