using System;
using System.Data;

namespace Job_Portal_Management_System.Views.Company
{
    public partial class RegisterCompany : System.Web.UI.Page
    {
        #region variable declaration

        private JobPortal_Models.Company.Company companymodel = new JobPortal_Models.Company.Company();
        private JobPortal_Services.Company.CompanyService companyservice = new JobPortal_Services.Company.CompanyService();
        private DataTable da = new DataTable();

        #endregion variable declaration

        #region bind data

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindCountry();
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

        #region InsertData

        /// <summary>
        /// InsertData
        /// </summary>
        private void InsertData()
        {
            companymodel.Name = txtName.Text;
            companymodel.CountryID = Convert.ToInt32(ddlCountry.SelectedValue);
            companymodel.Address = txtAddress.Text;
            companymodel.ContactPerson = txtContactPerson.Text;
            companymodel.Mobile = Convert.ToInt64(txtMobile.Text);
            companymodel.Email = txtEmail.Text;
            companymodel.Password = EncryptPassword(txtPassword.Text);
            companymodel.Website = txtWebsite.Text;
            companymodel.Detail = txtDetail.Text;
            companymodel.Role = "Company";
            companymodel.CreatedDate = DateTime.Now;
            companymodel.UpdatedDate = DateTime.Now;
        }

        #endregion InsertData

        #region register account

        /// <summary>
        /// register company account
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnRegister_Click(object sender, EventArgs e)
        {
            da = JobPortal_Services.Company.CompanyService.GetData(txtEmail.Text);
            if (da.Rows.Count > 0)
            {
                Session["alert"] = "Data already exist";
                Session["alert-type"] = "warning";
            }
            else
            {
                InsertData();
                bool success = JobPortal_Services.Company.CompanyService.Insert(companymodel);
                if (success)
                {
                    Session["alert"] = "Successfully registered";
                    Session["alert-type"] = "success";
                    ClearFields();
                }
                else
                {
                    Session["alert"] = "Failed registering";
                    Session["alert-type"] = "danger";
                }
            }
        }

        #endregion register account

        #region clear data and encrypt password

        /// <summary>
        /// clear data
        /// </summary>
        private void ClearFields()
        {
            txtName.Text = string.Empty;
            ddlCountry.SelectedIndex = -1;
            txtAddress.Text = string.Empty;
            txtContactPerson.Text = string.Empty;
            txtMobile.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtPassword.Text = string.Empty;
            txtWebsite.Text = string.Empty;
            txtDetail.Text = string.Empty;
        }

        /// <summary>
        /// clear datda
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

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

        #endregion clear data and encrypt password
    }
}