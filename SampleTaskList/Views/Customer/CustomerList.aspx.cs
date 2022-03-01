using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SampleTaskList.Views.Customer
{
    public partial class CustomerList : System.Web.UI.Page
    {
        Models.Customer.Customer customermodel = new Models.Customer.Customer();
        Services.Customer.CustomerService customerservice = new Services.Customer.CustomerService();
        DataTable da = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                GetData();
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("CustomerCreate.aspx");
        }

        #region Get Data
        /// <summary>
        /// Get Data
        /// </summary>
        public void GetData()
        {
            da = Services.Customer.CustomerService.GetAllData();
            if (da.Rows.Count > 0)
            {
                grvCustomer.DataSource = da;
                grvCustomer.DataBind();
                grvCustomer.Visible = true;
            }
            else
            {
                grvCustomer.DataSource = null;
            }
        }

        #endregion

        protected void grvCustomer_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int id = Convert.ToInt32(grvCustomer.DataKeys[e.RowIndex].Value);
            Response.Redirect("CustomerEdit.aspx?id=" + id);
        }

        protected void grvCustomer_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(grvCustomer.DataKeys[e.RowIndex].Value);
            customermodel.ID = id;
            bool IsDelete = Services.Customer.CustomerService.Delete(customermodel);
            if (IsDelete)
            {
                Response.Write("Deleting suuccessfully");
                GetData();
            }
            else
            {
                Response.Write("Deleting failed");
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            da = Services.Customer.CustomerService.GetSearchData(txtSearch.Text);
            if (da.Rows.Count > 0)
            {
                grvCustomer.DataSource = da;
                grvCustomer.DataBind();
                grvCustomer.Visible = true;
            }
            else
            {
                grvCustomer.DataSource = null;
            }
        }
    }
}