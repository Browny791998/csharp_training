using System;
using System.Data;
using System.Net;
using System.Net.Mail;

namespace Job_Portal_Management_System.Views
{
    public partial class ResetPassword : System.Web.UI.Page
    {
        #region variable declaration

        private JobPortal_Models.ResetPassword.ResetPassword resetpassmodel = new JobPortal_Models.ResetPassword.ResetPassword();
        private DataTable da = new DataTable();

        #endregion variable declaration

        #region bind data

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        #endregion bind data

        #region check data

        /// <summary>
        /// check data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string myGUID, email, Toemail, emailBody;
            bool success;
            if (ddlRole.SelectedValue == "Job Seeker")
            {
                da = JobPortal_Services.JobSeeker.JobSeekerService.GetData(txtEmail.Text);
                if (da.Rows.Count > 0)
                {
                    myGUID = Guid.NewGuid().ToString();
                    email = da.Rows[0]["email"].ToString();
                    resetpassmodel.Email = email;
                    resetpassmodel.UID = myGUID;
                    resetpassmodel.Requestdate = DateTime.Now;
                    success = JobPortal_DAOs.ResetPassword.ResetPasswordDao.Insert(resetpassmodel);
                    if (success)
                    {
                        Toemail = email;
                        emailBody = "<p>Click the follow Link to reset your password</p><br><br>https://localhost:44381/Views/Reset?Role=JobSeeker&Uid=" + myGUID;
                        MailMessage PassMail = new MailMessage("frompass@gmail.com", Toemail);
                        PassMail.Body = emailBody;
                        PassMail.IsBodyHtml = true;
                        PassMail.Subject = "Reset Password";
                        PassMail.Priority = MailPriority.High;
                        SmtpClient SMTP = new SmtpClient("smtp.gmail.com", 587);
                        SMTP.DeliveryMethod = SmtpDeliveryMethod.Network;
                        SMTP.UseDefaultCredentials = false;
                        SMTP.Credentials = new NetworkCredential()
                        {
                            UserName = "frompass@gmail.com",
                            Password = "Yourpassword"
                        };
                        SMTP.EnableSsl = true;
                        SMTP.Send(PassMail);
                        Session["alert"] = "Check your Email to reset your password";
                        Session["alert-type"] = "success";
                    }
                }
                else
                {
                    Session["alert"] = "Incorrect Email";
                    Session["alert-type"] = "danger";
                }
            }
            else if (ddlRole.SelectedValue == "Company")
            {
                da = JobPortal_Services.Company.CompanyService.GetData(txtEmail.Text);
                if (da.Rows.Count > 0)
                {
                    myGUID = Guid.NewGuid().ToString();
                    email = da.Rows[0]["email"].ToString();
                    resetpassmodel.Email = email;
                    resetpassmodel.UID = myGUID;
                    resetpassmodel.Requestdate = DateTime.Now;
                    success = JobPortal_DAOs.ResetPassword.ResetPasswordDao.Insert(resetpassmodel);
                    if (success)
                    {
                        Toemail = email;
                        emailBody = "<p>Click the follow Link to reset your password</p><br><br>https://localhost:44381/Views/Reset?Role=Company&Uid=" + myGUID;
                        MailMessage PassMail = new MailMessage("frompass@gmail.com", Toemail);
                        PassMail.Body = emailBody;
                        PassMail.IsBodyHtml = true;
                        PassMail.Subject = "Reset Password";
                        PassMail.Priority = MailPriority.High;
                        SmtpClient SMTP = new SmtpClient("smtp.gmail.com", 587);
                        SMTP.DeliveryMethod = SmtpDeliveryMethod.Network;
                        SMTP.UseDefaultCredentials = false;
                        SMTP.Credentials = new NetworkCredential()
                        {
                            UserName = "frompass@gmail.com",
                            Password = "Yourpassword"
                        };
                        SMTP.EnableSsl = true;
                        SMTP.Send(PassMail);
                        Session["alert"] = "Check your Email to reset your password";
                        Session["alert-type"] = "success";
                    }
                }
                else
                {
                    Session["alert"] = "Incorrect Email";
                    Session["alert-type"] = "danger";
                }
            }
        }

        #endregion check data
    }
}