using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Job_Portal_Management_System.Views
{
    public partial class Login : System.Web.UI.Page
    {
       
        DataTable da = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (ddlRole.SelectedValue == "Job Seeker")
            {
                da = JobPortal_Services.JobSeeker.JobSeekerService.GetData(txtEmail.Text);
                if (da.Rows.Count > 0)
                {
                    if(txtPassword.Text == DecryptPassword(da.Rows[0]["password"].ToString()))
                    {
                        Session["email"] =da.Rows[0]["email"];
                        Session["name"] = da.Rows[0]["name"];
                        Session["role"] = da.Rows[0]["role"];
                        Session["id"] = da.Rows[0]["id"];
                        Response.Redirect("Home");
                    }
                    else
                    {
                        Session["alert"] = "Incorrect Password";
                        Session["alert-type"] = "danger";
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
                    if (txtPassword.Text == DecryptPassword(da.Rows[0]["password"].ToString()))
                    {
                        Session["email"] = da.Rows[0]["email"];
                        Session["name"] = da.Rows[0]["name"];
                        Session["role"] = da.Rows[0]["role"];
                        Session["id"] = da.Rows[0]["id"];
                        Response.Redirect("Home");
                    }
                    else
                    {
                        Session["alert"] = "Incorrect Password";
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

        public string DecryptPassword(string passDecrypted)
        {
            byte[] b;
            string decrypted;
            try
            {
                b = Convert.FromBase64String(passDecrypted);
                decrypted = System.Text.ASCIIEncoding.ASCII.GetString(b);
            }
            catch(FormatException fe)
            {
                decrypted = "";
            }
            return decrypted;
        }
    }
}