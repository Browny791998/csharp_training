using System;
using System.Data;
using System.Web.UI;

namespace Job_Portal_Management_System.Views.User
{
    public partial class Login : System.Web.UI.Page
    {
        #region variable declaration

        private DataTable da = new DataTable();
        private JobPortal_Services.User.UserServices userservice = new JobPortal_Services.User.UserServices();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        #endregion variable declaration

        #region checkuser

        /// <summary>
        /// Login user
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            string password = txtPassword.Text;
            string name,role;
            da = JobPortal_Services.User.UserServices.GetData(email.ToString().Replace("'", "''"), password);
            if (da.Rows.Count > 0)
            {
                name = da.Rows[0]["name"].ToString();
                role= da.Rows[0]["role"].ToString();
                Session["name"] = name;
                Session["email"] = txtEmail.Text;
                Session["role"] = role;
                Response.Redirect("~/Views/User/AdminHome");
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMesage", "alert('Email or Password is Invalid')", true);
            }
        }

        #endregion checkuser
    }
}