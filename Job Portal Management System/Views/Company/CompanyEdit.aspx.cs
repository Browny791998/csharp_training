using System;
using System.Data;
using System.Data.SqlClient;

namespace Job_Portal_Management_System.Views.Company
{
    public partial class CompanyEdit : System.Web.UI.Page
    {
        #region variable declaration

        private JobPortal_Models.Company.Company companymodel = new JobPortal_Models.Company.Company();
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
            if (!IsPostBack)
            {
                bindCountry();
                int id = Convert.ToInt32(MyCrypto.GetDecryptedQueryString(Request.QueryString["ID"]));
                SqlDataReader dr = JobPortal_Services.Company.CompanyService.ReadData(id);
                while (dr.Read())
                {
                    txtName.Text = dr["name"].ToString();
                    ddlCountry.SelectedValue = dr["country_id"].ToString();
                    txtAddress.Text = dr["address"].ToString();
                    txtContactPerson.Text = dr["contact_person"].ToString();
                    txtMobile.Text = dr["mobile"].ToString();
                    txtWebsite.Text = dr["website"].ToString();
                    txtDetail.Text = dr["detail"].ToString();
                }
            }
        }

        /// <summary>
        /// binding data
        /// </summary>
        public void bindCountry()
        {
            da = JobPortal_Services.Country.CountryServices.GetAllData();
            if (da.Rows.Count > 0)
            {
                ddlCountry.DataSource = da;
                ddlCountry.DataValueField = "id";
                ddlCountry.DataTextField = "country";
                ddlCountry.DataBind();
            }
        }

        #endregion bind data

        #region UpdateData

        /// <summary>
        /// UpdateData
        /// </summary>
        private void UpdateData()
        {
            companymodel.ID = Convert.ToInt32(MyCrypto.GetDecryptedQueryString(Request.QueryString["ID"]));
            companymodel.Name = txtName.Text;
            companymodel.CountryID = Convert.ToInt32(ddlCountry.SelectedValue);
            companymodel.Address = txtAddress.Text;
            companymodel.ContactPerson = txtContactPerson.Text;
            companymodel.Mobile = Convert.ToInt64(txtMobile.Text);
            companymodel.Website = txtWebsite.Text;
            companymodel.Detail = txtDetail.Text;
            companymodel.UpdatedDate = DateTime.Now;
        }

        /// <summary>
        /// update company data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateData();
            bool IsUpdate = JobPortal_Services.Company.CompanyService.Update(companymodel);
            if (IsUpdate)
            {
                Session["alert"] = "Successfully updated your company information";
                Session["alert-type"] = "success";
                Response.Redirect("~/Views/Company/CompanyAccount.aspx");
            }
            else
            {
                Session["alert"] = "failed to update  your company information";
                Session["alert-type"] = "danger";
            }
        }

        #endregion UpdateData

        #region clear data

        /// <summary>
        /// clear all text in textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        /// <summary>
        /// clear all data
        /// </summary>
        private void ClearFields()
        {
            txtName.Text = string.Empty;
            ddlCountry.SelectedIndex = -1;
            txtAddress.Text = string.Empty;
            txtContactPerson.Text = string.Empty;
            txtMobile.Text = string.Empty;
            txtWebsite.Text = string.Empty;
            txtDetail.Text = string.Empty;
        }

        #endregion clear data
    }
}