using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Job_Portal_Management_System.Views
{
    public partial class ResetPassword : System.Web.UI.Page
    {
        JobPortal_Models.ResetPassword.ResetPassword resetpassmodel = new JobPortal_Models.ResetPassword.ResetPassword();
        DataTable da = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string myGUID,email,Toemail,emailBody;
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
                        emailBody = "<p>Click the follow Link to reset your password</p><br><br>"+myGUID;
                    }
                }
                else
                {
                    Session["alert"] = "Incorrect Email";
                    Session["alert-type"] = "danger";
                }
            }else if(ddlRole.SelectedValue == "Company")
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
                        Session["alert"] = "Success";
                        Session["alert-type"] = "danger";
                    }
                }
                else
                {
                    Session["alert"] = "Incorrect Email";
                    Session["alert-type"] = "danger";
                }
            }
               
        }
    }
}