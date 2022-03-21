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
            if (!IsPostBack)
            {
                if (Request.Cookies["Email"] != null && Request.Cookies["Password"] != null)
                {
                    txtEmail.Text = Request.Cookies["Email"].Value;
                    txtPassword.Attributes["value"] = Request.Cookies["Password"].Value;
                }
            }
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
                        if (chkMe.Checked)
                        {
                            Response.Cookies["Email"].Expires = DateTime.Now.AddDays(30);
                            Response.Cookies["Password"].Expires = DateTime.Now.AddDays(30);
                        }
                        else
                        {
                            Response.Cookies["Email"].Expires = DateTime.Now.AddDays(-1);
                            Response.Cookies["Password"].Expires = DateTime.Now.AddDays(-1);
                        }
                        Response.Cookies["Email"].Value = txtEmail.Text.Trim();
                        Response.Cookies["Password"].Value = txtPassword.Text.Trim();

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