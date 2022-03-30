using System;
using System.Data;

namespace Job_Portal_Management_System.Views
{
    public partial class Reset : System.Web.UI.Page
    {
        #region variable declaration

        private string GUID;
        private string Role;
        private string Email;
        private JobPortal_Models.JobSeeker.JobSeeker jobseekermodel = new JobPortal_Models.JobSeeker.JobSeeker();
        private JobPortal_Models.Company.Company companymodel = new JobPortal_Models.Company.Company();
        private JobPortal_Models.ResetPassword.ResetPassword resetpassmodel = new JobPortal_Models.ResetPassword.ResetPassword();
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
            GUID = Request.QueryString["Uid"];
            if (GUID != null)
            {
                da = JobPortal_Services.ResetPassword.ResetPasswordService.GetGUI(GUID);
                if (da.Rows.Count > 0)
                {
                    Email = da.Rows[0]["email"].ToString();
                }
                else
                {
                    Session["alert"] = "Your Reset Password link is expired or invalid!";
                    Session["alert-type"] = "warning";
                }
            }
            else
            {
                Response.Redirect("~/Views/ResetPassword.aspx");
            }
            if (!IsPostBack)
            {
                if (da.Rows.Count > 0)
                {
                    txtNewPassword.Visible = true;
                    txtConfirmPass.Visible = true;
                    btnSubmit.Visible = true;
                }
            }
        }

        #endregion bind data

        #region reset password

        /// <summary>
        /// reset password
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            bool success;
            Role = Request.QueryString["Role"];
            string encyptpass;
            if (Role == "JobSeeker")
            {
                encyptpass = EncryptPassword(txtNewPassword.Text);
                jobseekermodel.Password = encyptpass;
                jobseekermodel.Email = Email;
                success = JobPortal_Services.JobSeeker.JobSeekerService.UpdatebyEmail(jobseekermodel);
                if (success)
                {
                    resetpassmodel.Email = Email;
                    success = JobPortal_Services.ResetPassword.ResetPasswordService.Delete(resetpassmodel);
                    if (success)
                    {
                        Session["alert"] = "Your Password is successfully changed";
                        Session["alert-type"] = "success";
                    }
                }
                else
                {
                    Session["alert"] = "Failed Password changing";
                    Session["alert-type"] = "danger";
                }
            }
            else if (Role == "Company")
            {
                encyptpass = EncryptPassword(txtNewPassword.Text);
                companymodel.Password = encyptpass;
                companymodel.Email = Email;
                success = JobPortal_Services.Company.CompanyService.UpdateByEmail(companymodel);
                if (success)
                {
                    resetpassmodel.Email = Email;
                    success = JobPortal_Services.ResetPassword.ResetPasswordService.Delete(resetpassmodel);
                    if (success)
                    {
                        Session["alert"] = "Your Password is successfully changed";
                        Session["alert-type"] = "success";
                    }
                }
                else
                {
                    Session["alert"] = "Failed Password changing";
                    Session["alert-type"] = "danger";
                }
            }
        }

        #endregion reset password

        #region encrpyt password

        /// <summary>
        /// encrypt password
        /// </summary>
        /// <param name="passEncrypted"></param>
        /// <returns></returns>
        public string EncryptPassword(string passEncrypted)
        {
            byte[] b = System.Text.ASCIIEncoding.ASCII.GetBytes(passEncrypted);
            string encrypted = Convert.ToBase64String(b);
            return encrypted;
        }

        #endregion encrpyt password
    }
}