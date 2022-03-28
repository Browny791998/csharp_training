using System;
using System.Data;
using System.Web.UI.WebControls;

namespace Job_Portal_Management_System.Views.User
{
    public partial class AdminCompanyList : System.Web.UI.Page
    {
        #region variable declaration

        private JobPortal_Services.Company.CompanyService companyservice = new JobPortal_Services.Company.CompanyService();
        private DataTable da = new DataTable();

        #endregion variable declaration

        #region bind data

        /// <summary>
        /// bind data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["email"] == null)
            {
                Response.Redirect("~/Views/User/Login.aspx");
            }
            if (!IsPostBack)
            {
                GetData();
            }
        }

        #endregion bind data

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

        #endregion Get Data

        #region search data

        /// <summary>
        /// search data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// bind data to datagrid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grvCompany_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvCompany.PageIndex = e.NewPageIndex;
            this.GetData();
        }

        #endregion search data
    }
}