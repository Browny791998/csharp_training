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
    public partial class CustomerCreate : System.Web.UI.Page
    {
        Models.Customer.Customer customermodel = new Models.Customer.Customer();
        DataTable da = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["label"] != null)
            {
                string label = Session["label"].ToString();
                if (label == "add")
                {
                    lblCustomer.Text = "Add Customer";
                    if (!IsPostBack)
                    {
                        LoadSalutation();
                    }
                }
                else if (label == "update")
                {
                    lblCustomer.Text = "Update Customer";
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

        /// <summary>
        /// binding salutation
        /// </summary>
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

        /// <summary>
        /// creating customer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (hfCustomer.Value == "")
            {
                da = Services.Customer.CustomerService.GetData(txtName.Text, txtAddress.Text);
                if (da.Rows.Count > 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMesage", "alert('Data already existed')", true);
                }
                else
                {
                    InsertData();
                    bool success = Services.Customer.CustomerService.Insert(customermodel);
                    if (success)
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMesage", "alert('Created successfully')", true);
                        txtName.Text = string.Empty;
                        txtAddress.Text = string.Empty;
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMesage", "alert('Creeating failed')", true);
                    }
                }
            }
            else
            {
                UpdateData();
                bool IsUpdate = Services.Customer.CustomerService.Update(customermodel);
                if (IsUpdate)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMesage", "alert('Updated successfully')", true);
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMesage", "alert('Updating failed')", true);
                }
            }
         }

        /// <summary>
        /// back to list page
        /// </summary>
        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("CustomerList.aspx");
        }

        /// <summary>
        /// clear form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnClear_Click(object sender, EventArgs e)
        {
            ddlSalutation.SelectedIndex = -1;
            txtAddress.Text = string.Empty;
            txtName.Text = string.Empty;
        }
    }
}