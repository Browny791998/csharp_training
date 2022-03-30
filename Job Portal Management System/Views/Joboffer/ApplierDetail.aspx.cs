using System;
using System.Data;

namespace Job_Portal_Management_System.Views.Joboffer
{
    public partial class ApplierDetail : System.Web.UI.Page
    {
        #region variable declaration

        private JobPortal_Services.JobSeeker.JobSeekerService jobseekerservice = new JobPortal_Services.JobSeeker.JobSeekerService();
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
            if (Session["email"] == null)
            {
                Response.Redirect("~/Views/Login.aspx");
            }
            if (!IsPostBack)
            {
                GetApplier();
            }
        }

        #endregion bind data

        #region get data

        /// <summary>
        /// get data
        /// </summary>
        public void GetApplier()
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
                Session["alert"] = "Wrong Url";
                Session["alert-type"] = "warning";
                strReq = Session["url"].ToString();
            }
            if (!strReq.Equals(""))
            {
                strReq = DecryptQueryString(strReq);
                string[] arrMsgs = strReq.Split('&');
                string[] arrIndMsg;
                string CID = "";
                arrIndMsg = arrMsgs[0].Split('=');
                CID = arrIndMsg[1].ToString().Trim();
                int id = Convert.ToInt32(CID);
                //int id = Convert.ToInt32(MyCrypto.GetDecryptedQueryString(Request.QueryString["applierID"]));
                da = JobPortal_Services.JobSeeker.JobSeekerService.GetAllData(id);
                rptApplier.DataSource = da;
                rptApplier.DataBind();
            }
            else
            {
                Session["alert"] = "Wrong Url";
                Session["alert-type"] = "warning";
            }
        }

        private string DecryptQueryString(string strQueryString)
        {
            EncryptDecryptQueryString objEDQueryString = new EncryptDecryptQueryString();
            return objEDQueryString.Decrypt(strQueryString, "r0b1nr0y");
        }
        #endregion get data

        #region back to joboofferlist

        /// <summary>
        /// back to job offer list page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("JobOfferList.aspx");
        }

        #endregion back to joboofferlist
    }
}