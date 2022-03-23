using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Job_Portal_Management_System.Views.User
{
    public partial class AdminJobOffer : System.Web.UI.Page
    {
        JobPortal_Models.JobOffer.JobOffer joboffermodel = new JobPortal_Models.JobOffer.JobOffer();
        JobPortal_Services.JobOffer.JobOfferService jobofferservice = new JobPortal_Services.JobOffer.JobOfferService();
        DataTable da = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetData();
                bindCompany();
            }
        }

        int status;
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if(rdoAccept.Checked==false && rdoReject.Checked == false)
            {
                da = JobPortal_Services.JobOffer.JobOfferService.GetSearchAllJoboffer(txtSearch.Text,ddlCompany.SelectedItem.ToString());
            }else if (rdoAccept.Checked == true)
            {
                status = 1;
                da = JobPortal_Services.JobOffer.JobOfferService.GetSearchAllAcceptData(status,txtSearch.Text, ddlCompany.SelectedItem.ToString());
            }else if(rdoReject.Checked == true)
            {
                status = 0;
                da = JobPortal_Services.JobOffer.JobOfferService.GetSearchAllAcceptData(status, txtSearch.Text, ddlCompany.SelectedItem.ToString());
            }
           
            if (da.Rows.Count > 0)
            {
                grvJoboffer.DataSource = da;
                grvJoboffer.DataBind();
                grvJoboffer.Visible = true;
            }
            else
            {
                grvJoboffer.DataSource = null;
                grvJoboffer.DataBind();
            }
            grvJoboffer.UseAccessibleHeader = true;
            grvJoboffer.HeaderRow.TableSection = TableRowSection.TableHeader;
        }

        #region Get Data
        /// <summary>
        /// Get Data
        /// </summary>
        public void GetData()
        {

            da = JobPortal_Services.JobOffer.JobOfferService.GetAllJobOffer();
            if (da.Rows.Count > 0)
            {
                grvJoboffer.DataSource = da;
                grvJoboffer.DataBind();
               grvJoboffer.Visible = true;
                grvJoboffer.UseAccessibleHeader = true;
               grvJoboffer.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            else
            {
                grvJoboffer.DataSource = null;
                grvJoboffer.DataBind();
            }

        }
        #endregion



        public void bindCompany()
        {
            da = JobPortal_Services.Company.CompanyService.GetCompanyAllData();
            if (da.Rows.Count > 0)
            {
                ddlCompany.DataSource = da;
                ddlCompany.DataValueField = "id";
                ddlCompany.DataTextField = "name";
                ddlCompany.DataBind();
            }
        }
        protected void grvJoboffer_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvJoboffer.PageIndex = e.NewPageIndex;
            this.GetData();
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtSearch.Text = string.Empty;
            rdoAccept.Checked = false;
            rdoReject.Checked = false;
            this.GetData();
        }
    }
}