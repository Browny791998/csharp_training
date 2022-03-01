using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SampleTaskList.Views.Customer
{
    public partial class CustomerEdit : System.Web.UI.Page
    {
        DataTable da = new DataTable();
        Models.Customer.Customer customermodel = new Models.Customer.Customer();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadSalutation();
                int id = Convert.ToInt32(Request.QueryString["id"]);
                SqlDataReader dr = Services.Customer.CustomerService.ReadData(id);
                while (dr.Read())
                {
                    string ID = dr["id"].ToString();
                    int salutation_id = Convert.ToInt32(dr["salutation_id"].ToString());
                    string name = dr["full_name"].ToString();
                    string address = dr["address"].ToString();
                    hfCustomer.Value = ID;
                    txtName.Text = name;
                    txtAddress.Text = address;
                    ddlSalutation.SelectedValue = salutation_id.ToString(); ;
                }
            }
        }

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

        #region UpdateData
        /// <summary>
        /// UpdateData
        /// </summary>
        private void UpdateData()
        {
            customermodel.ID = Convert.ToInt32(hfCustomer.Value);
            customermodel.SalutationID = Convert.ToInt32(ddlSalutation.SelectedValue);
            customermodel.FullName = txtName.Text;
            customermodel.Address = txtAddress.Text;
        }
        #endregion

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            UpdateData();
            bool IsUpdate = Services.Customer.CustomerService.Update(customermodel);
            if (IsUpdate)
            {
                Response.Write("Updated successfully");
            }
            else
            {
                Response.Write("Updating failed");
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            ddlSalutation.SelectedIndex = -1;
            txtAddress.Text = string.Empty;
            txtName.Text = string.Empty;
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("CustomerList.aspx");
        }
    }
}