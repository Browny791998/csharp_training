using System;
using System.Data;
using Job_Portal_Management_System.Properties;
namespace Job_Portal_Management_System.Views
{
    public partial class Login : System.Web.UI.Page
    {
        #region variable delcaration

        private DataTable da = new DataTable();

        #endregion variable delcaration

        #region bind data

        /// <summary>
        /// bind data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        #endregion bind data

        #region check jobseeker

        /// <summary>
        /// check jobseeker email and password
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (ddlRole.SelectedValue == "Job Seeker")
            {
                da = JobPortal_Services.JobSeeker.JobSeekerService.GetData(txtEmail.Text);
                if (da.Rows.Count > 0)
                {
                    if (txtPassword.Text == DecryptPassword(da.Rows[0]["password"].ToString()))
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

                        Session["email"] = da.Rows[0]["email"];
                        Session["name"] = da.Rows[0]["name"];
                        Session["role"] = da.Rows[0]["role"];
                        Session["id"] = da.Rows[0]["id"];
                        Response.Redirect("Home");
                    }
                    else
                    {
                        Session["alert"] = Message.I0021;
                        Session["alert-type"] = "danger";
                    }
                }
                else
                {
                    Session["alert"] = Message.I0022;
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
                        Session["alert"] = Message.I0021;
                        Session["alert-type"] = "danger";
                    }
                }
                else
                {
                    Session["alert"] = Message.I0022;
                    Session["alert-type"] = "danger";
                }
            }
        }

        #endregion check jobseeker

        #region decrypt password

        /// <summary>
        /// decrypt password
        /// </summary>
        /// <param name="passDecrypted"></param>
        /// <returns></returns>
        public string DecryptPassword(string passDecrypted)
        {
            byte[] b;
            string decrypted;
            try
            {
                b = Convert.FromBase64String(passDecrypted);
                decrypted = System.Text.ASCIIEncoding.ASCII.GetString(b);
            }
            catch (FormatException fe)
            {
                decrypted = "";
            }
            return decrypted;
        }

        #endregion decrypt password
    }
}