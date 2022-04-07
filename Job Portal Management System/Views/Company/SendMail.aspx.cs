using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Job_Portal_Management_System.Properties;
namespace Job_Portal_Management_System.Views.Company
{
    public partial class SendMail : System.Web.UI.Page
    {
        DataTable da = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        #region Send Email
        /// <summary>
        /// Send Mail function
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSend_Click(object sender, EventArgs e)
        {
            string company, subject, job, email, message, password;
            company = txtCompanyName.Text;
            subject = txtSubject.Text;
            job = txtJob.Text;
            email = txtEmail.Text;
            message = txtMessage.InnerText;
            password = txtPassword.Text;
            da = JobPortal_Services.User.UserServices.GetAllData();
            for (int i = 0; i < da.Rows.Count; i++)
            {
                string mails = da.Rows[i]["email"].ToString();
                SendEmail(subject, company, job, email, password, message, mails);
            }
        }

        /// <summary>
        /// send email to admin
        /// </summary>
        /// <param name="subject"></param>
        /// <param name="company"></param>
        /// <param name="job"></param>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <param name="message"></param>
        /// <param name="mails"></param>
        private void SendEmail(string subject, string company, string job, string email, string password, string message, string mails)
        {   
            DataTable dt = new DataTable();
            MailDefinition md = new MailDefinition();
            md.From = "test@domain.com";
            md.IsBodyHtml = true;
            md.Subject = subject;
            ListDictionary replacements = new ListDictionary();
            replacements.Add("{company}", company);
            replacements.Add("{job}", job);
            replacements.Add("{message}", message);
            string body;
            body = "<center><h1>Job Appointment</h1></center>";
            body += "<h3>Hello Admin </h3>";
            body += "<p>{message}</p>";
            body += "<p>Job Title - {job}</p>";
            body += "<p>From</p>";
            body += "<p>{company}</p>";
            MailMessage msg = md.CreateMailMessage(mails, replacements, body, new System.Web.UI.Control());
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.EnableSsl = true;
            NetworkCredential NetworkCred = new NetworkCredential(email,password);
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = NetworkCred;
            smtp.Port = 587;
            smtp.Send(msg);
            Session["alert"] = Message.I0010;
            Session["alert-type"] = "success";
        }

        #endregion
    }
}