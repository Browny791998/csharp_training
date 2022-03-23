using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Job_Portal_Management_System.Views.User
{
    public partial class AdminJobOffer : System.Web.UI.Page
    {
        JobPortal_Models.JobOffer.JobOffer joboffermodel = new JobPortal_Models.JobOffer.JobOffer();
        JobPortal_Services.JobOffer.JobOfferService jobofferservice = new JobPortal_Services.JobOffer.JobOfferService();
        DataTable da = new DataTable();
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

        int status;
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if(rdoAccept.Checked==false && rdoReject.Checked == false)
            {
                da = JobPortal_Services.JobOffer.JobOfferService.GetSearchAllJoboffer(txtSearch.Text,ddlCompany.SelectedItem.ToString());
            }else if (rdoAccept.Checked == true)
            {
                status = 1;
                da = JobPortal_Services.JobOffer.JobOfferService.GetSearchAllAcceptData(status,txtSearch.Text, ddlCompany.SelectedItem.ToString());
            }else if(rdoReject.Checked == true)
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
        #endregion



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
            da = JobPortal_Services.JobOffer.JobOfferService.GetAllJobOffer();
          for(int i = 0; i < da.Rows.Count; i++)
            {
             
                string applier = da.Rows[i]["seeker"].ToString();
                string mails = da.Rows[i]["seekermail"].ToString();
                string company = da.Rows[i]["company"].ToString();
                SendEmail(applier, mails,company);
            }
        }

        private void SendEmail(string name,string email,string company)
        {
            DataTable dt = new DataTable();

            MailDefinition md = new MailDefinition();
            md.From = "test@domain.com";
            md.IsBodyHtml = true;
            md.Subject = "Job Reply";

            ListDictionary replacements = new ListDictionary();
            replacements.Add("{name}",name);
            replacements.Add("{company}", company);

            string body = "<center><h1>Job Reply</h1></center>";
            body += "<h3>Hello {name} </h3>";
            body += "<p>{company} reviewed your cv and agree to make an appointment with you</p>";
            body += "<p>Best Regards</p>";
            body += "<p>Brilliant Job</p>";

            MailMessage msg = md.CreateMailMessage(email, replacements, body, new System.Web.UI.Control());
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.EnableSsl = true;
            NetworkCredential NetworkCred = new NetworkCredential("sender@gmail.com", "password");
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = NetworkCred;
            smtp.Port = 587;
            smtp.Send(msg);

            //StringBuilder sb = new StringBuilder();
            //sb.Append("<center><h1>Job Reply</h1></center>");
            //sb.Append("<h3>Hello {name} </h3>");
            //sb.Append("<p>{company} reviewed your cv and agree to make an appointment with you</p>");
            //sb.Append("<p>Best Regards</p>");
            //sb.Append("<p>Brilliant Job</p>");
            //sb = sb.Replace("{name}", name);
            //sb = sb.Replace("{company}",company);

            //using (MailMessage mm = new MailMessage("sender@gmail.com", email))
            //{
            //    mm.Subject = "Job Reply";
            //    mm.Body = sb.ToString();
            //    SmtpClient smtp = new SmtpClient();
            //    smtp.Host = "smtp.gmail.com";
            //    smtp.EnableSsl = true;
            //    NetworkCredential NetworkCred = new NetworkCredential("sender@gmail.com", "password");
            //    smtp.UseDefaultCredentials = true;
            //    smtp.Credentials = NetworkCred;
            //    smtp.Port = 587;
            //    smtp.Send(mm);

            //}


        }
    }
}