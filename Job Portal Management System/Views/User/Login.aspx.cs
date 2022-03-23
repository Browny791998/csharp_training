using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
            da = JobPortal_Services.User.UserServices.GetData(email, password);
            if (da.Rows.Count > 0)
            {
                Session["email"] = txtEmail.Text;
                Response.Redirect("~/Views/Country/CountryList");
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMesage", "alert('Email or Password is Invalid')", true);
            }
        }

        #endregion checkuser
    }
}