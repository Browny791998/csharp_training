using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Job_Portal_Management_System.Views.User
{
    public partial class AdminCompanyList : System.Web.UI.Page
    {

    
        JobPortal_Services.Company.CompanyService companyservice = new  JobPortal_Services.Company.CompanyService();
        DataTable da = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetData();
            }
        }


        #region Get Data
        /// <summary>
        /// Get Data
        /// </summary>
        public void GetData()
        {

            da = JobPortal_Services.Company.CompanyService.GetCompanyAllData();
            if (da.Rows.Count > 0)
            {
               grvCompany.DataSource = da;
                grvCompany.DataBind();
                grvCompany.Visible = true;
                grvCompany.UseAccessibleHeader = true;
                grvCompany.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            else
            {
                grvCompany.DataSource = null;
                grvCompany.DataBind();
            }

        }
        #endregion


        protected void btnSearch_Click(object sender, EventArgs e)
        {
            da = JobPortal_Services.Company.CompanyService.GetSearchData(txtSearch.Text);
            if (da.Rows.Count > 0)
            {
            grvCompany.DataSource = da;
              grvCompany.DataBind();
                grvCompany.Visible = true;
            }
            else
            {
                grvCompany.DataSource = null;
                grvCompany.DataBind();
            }
            grvCompany.UseAccessibleHeader = true;
            grvCompany.HeaderRow.TableSection = TableRowSection.TableHeader;
        }

        protected void grvCompany_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvCompany.PageIndex = e.NewPageIndex;
            this.GetData();
        }
    }
}