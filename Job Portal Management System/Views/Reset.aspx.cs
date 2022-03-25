using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Job_Portal_Management_System.Views
{
    public partial class Reset : System.Web.UI.Page
    {
        string GUID;
        string Role;
        string Email;
        JobPortal_Models.JobSeeker.JobSeeker jobseekermodel = new JobPortal_Models.JobSeeker.JobSeeker();
        JobPortal_Models.Company.Company companymodel = new JobPortal_Models.Company.Company();
    JobPortal_Models.ResetPassword.ResetPassword resetpassmodel = new JobPortal_Models.ResetPassword.ResetPassword();
        DataTable da = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            GUID = Request.QueryString["Uid"];
            if(GUID != null)
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

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            bool success;
            Role= Request.QueryString["Role"];
            if (Role == "JobSeeker")
            {
                jobseekermodel.Password = txtNewPassword.Text;
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
            }else if(Role == "Company")
            {
                companymodel.Password = txtNewPassword.Text;
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
    }
}