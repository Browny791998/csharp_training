using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SampleTaskList.Views.Customer
{
    public partial class CustomerCreate : System.Web.UI.Page
    {
        Models.Customer.Customer customermodel = new Models.Customer.Customer();
        DataTable da = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadSalutation();
            }
        }


        #region InsertData
        /// <summary>
        /// InsertData
        /// </summary>
        private void InsertData()
        {
            customermodel.SalutationID = Convert.ToInt32(ddlSalutation.SelectedValue);
            customermodel.FullName = txtName.Text;
            customermodel.Address = txtAddress.Text;
        }
        #endregion


        public void LoadSalutation()
        {
            da = Services.Salutation.SalutationService.GetAllData();
            if (da.Rows.Count > 0)
            {
                ddlSalutation.DataSource = da;
                ddlSalutation.DataValueField = "id";
                ddlSalutation.DataTextField = "salutation";
                ddlSalutation.DataBind();
             
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            InsertData();
            bool success = Services.Customer.CustomerService.Insert(customermodel);
            if (success)
            {
                Response.Redirect("~/Views/Customer/CustomerList", true);

            }
            else
            {
                Response.Write("added failed");
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("CustomerList.aspx");
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            ddlSalutation.SelectedIndex = -1;
            txtAddress.Text = string.Empty;
            txtName.Text = string.Empty;
        }
    }
}