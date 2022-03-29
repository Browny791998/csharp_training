﻿using System;
using System.Data;
using System.Web.UI.WebControls;

namespace Job_Portal_Management_System.Views.Company
{
    public partial class CompanyAccount : System.Web.UI.Page
    {
        #region variable declaration

        private JobPortal_Services.Company.CompanyService companyservice = new JobPortal_Services.Company.CompanyService();
        private DataTable da = new DataTable();

        #endregion variable declaration

        #region bind data

        /// <summary>
        /// page load event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["email"] == null)
            {
                Response.Redirect("~/Views/Login.aspx");
            }
            GetAcc();
        }

        /// <summary>
        /// binding data
        /// </summary>
        public void GetAcc()
        {
            int id = Convert.ToInt32(Session["id"]);
            da = JobPortal_Services.Company.CompanyService.GetAllData(id);
            rptCompany.DataSource = da;
            rptCompany.DataBind();
        }

        #endregion bind data

        #region edit data

        /// <summary>
        /// edit company data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnEdit_Click(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            var item = (RepeaterItem)btn.NamingContainer;
            var IdValue = ((Label)item.FindControl("companyId")).Text;

            Response.Redirect("CompanyEdit.aspx?ID=" + MyCrypto.GetEncryptedQueryString(IdValue));
        }

        #endregion edit data
    }
}