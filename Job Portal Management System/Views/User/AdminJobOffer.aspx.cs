using System;
using System.Collections.Specialized;
using System.Data;
using System.Net;
using System.Net.Mail;
using System.Web.UI.WebControls;

namespace Job_Portal_Management_System.Views.User
{
    public partial class AdminJobOffer : System.Web.UI.Page
    {
        private JobPortal_Models.JobOffer.JobOffer joboffermodel = new JobPortal_Models.JobOffer.JobOffer();
        private JobPortal_Services.JobOffer.JobOfferService jobofferservice = new JobPortal_Services.JobOffer.JobOfferService();
        private DataTable da = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["email"] == null)
            {
                Response.Redirect("~/Views/User/Login.aspx");
            }
            if (!IsPostBack)
            {
                GetData();
                bindCompany();
            }
        }

        private int status;

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (rdoAccept.Checked == false && rdoReject.Checked == false)
            {
                da = JobPortal_Services.JobOffer.JobOfferService.GetSearchAllJoboffer(txtSearch.Text, ddlCompany.SelectedItem.ToString());
            }
            else if (rdoAccept.Checked == true)
            {
                status = 1;
                da = JobPortal_Services.JobOffer.JobOfferService.GetSearchAllAcceptData(status, txtSearch.Text, ddlCompany.SelectedItem.ToString());
            }
            else if (rdoReject.Checked == true)
            {
                status = 0;
                da = JobPortal_Services.JobOffer.JobOfferService.GetSearchAllAcceptData(status, txtSearch.Text, ddlCompany.SelectedItem.ToString());
            }

            if (da.Rows.Count > 0)
            {
                grvJoboffer.DataSource = da;
                grvJoboffer.DataBind();
                grvJoboffer.Visible = true;
            }
            else
            {
                grvJoboffer.DataSource = null;
                grvJoboffer.DataBind();
            }
            grvJoboffer.UseAccessibleHeader = true;
            grvJoboffer.HeaderRow.TableSection = TableRowSection.TableHeader;
        }

        #region Get Data

        /// <summary>
        /// Get Data
        /// </summary>
        public void GetData()
        {
            da = JobPortal_Services.JobOffer.JobOfferService.GetAllJobOffer();
            if (da.Rows.Count > 0)
            {
                grvJoboffer.DataSource = da;
                grvJoboffer.DataBind();
                grvJoboffer.Visible = true;
                grvJoboffer.UseAccessibleHeader = true;
                grvJoboffer.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            else
            {
                grvJoboffer.DataSource = null;
                grvJoboffer.DataBind();
            }
        }

        #endregion Get Data

        public void bindCompany()
        {
            da = JobPortal_Services.Company.CompanyService.GetCompanyAllData();
            if (da.Rows.Count > 0)
            {
                ddlCompany.DataSource = da;
                ddlCompany.DataValueField = "id";
                ddlCompany.DataTextField = "name";
                ddlCompany.DataBind();
            }
        }

        protected void grvJoboffer_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvJoboffer.PageIndex = e.NewPageIndex;
            this.GetData();
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtSearch.Text = string.Empty;
            rdoAccept.Checked = false;
            rdoReject.Checked = false;
            this.GetData();
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            bool accept;
            if (rdoAccept.Checked == true)
            {
                status = 1;
            }
            else if (rdoReject.Checked == true)
            {
                status = 0;
            }
            da = JobPortal_Services.JobOffer.JobOfferService.GetSearchAllAcceptData(status, txtSearch.Text, ddlCompany.SelectedItem.ToString());
            for (int i = 0; i < da.Rows.Count; i++)
            {
                string applier = da.Rows[i]["seeker"].ToString();
                string mails = da.Rows[i]["seekermail"].ToString();
                string company = da.Rows[i]["company"].ToString();
                if (da.Rows[i]["Accept"].ToString() == "Accepted")
                {
                    accept = true;
                }
                else
                {
                    accept = false;
                }
                SendEmail(applier, mails, company, accept);
            }
        }

        private void SendEmail(string name, string email, string company, bool accept)
        {
            DataTable dt = new DataTable();

            MailDefinition md = new MailDefinition();
            md.From = "test@domain.com";
            md.IsBodyHtml = true;
            md.Subject = "Job Reply";

            ListDictionary replacements = new ListDictionary();
            replacements.Add("{name}", name);
            replacements.Add("{company}", company);
            string body;
            if (accept)
            {
                body = "<center><h1>Job Reply</h1></center>";
                body += "<h3>Hello {name} </h3>";
                body += "<p><b>{company}</b> reviewed your cv and agree to make an appointment with you</p>";
                body += "<p>Best Regards</p>";
                body += "<p>🏢Brilliant Job</p>";
            }
            else
            {
                body = "<center><h1>Job Reply</h1></center>";
                body += "<h3>Hello {name} </h3>";
                body += "<p><b>{company}</b> reviewd your CV</p>";
                body += "<p>We are really sorry.</p>";
                body += "<p>Unfortunately,you are rejected</p>";
                body += "<p>Please try again next time,Good Luck!</p>";
                body += "<p>Best Regards</p>";
                body += "<p>🏢Brilliant Job</p>";
            }
            MailMessage msg = md.CreateMailMessage(email, replacements, body, new System.Web.UI.Control());
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.EnableSsl = true;
            NetworkCredential NetworkCred = new NetworkCredential("sender@gmail.com", "password");
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = NetworkCred;
            smtp.Port = 587;
            smtp.Send(msg);
        }
    }
}