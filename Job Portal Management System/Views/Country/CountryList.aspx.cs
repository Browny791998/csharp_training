using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Job_Portal_Management_System.Properties;
namespace Job_Portal_Management_System.Views.Country
{
    public partial class CountryList : System.Web.UI.Page
    {
        #region variable declaration

        private JobPortal_Models.Country.Country countrymodel = new JobPortal_Models.Country.Country();
        private JobPortal_Services.Country.CountryServices countryservice = new JobPortal_Services.Country.CountryServices();
        private DataTable da = new DataTable();

        #endregion variable declaration

        #region binding data

        /// <summary>
        /// binding data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["email"] == null)
            {
                Response.Redirect("~/Views/User/Login.aspx");
            }
            if (!Page.IsPostBack)
            {
                GetData();
            }
        }

        #endregion binding data

        #region Get Data

        /// <summary>
        /// Get Data
        /// </summary>
        public void GetData()
        {
            da = JobPortal_Services.Country.CountryServices.GetAllData();
            if (da.Rows.Count > 0)
            {
                grvCountry.DataSource = da;
                grvCountry.DataBind();
                grvCountry.Visible = true;
            }
            else
            {
                grvCountry.DataSource = null;
                grvCountry.DataBind();
            }
            grvCountry.UseAccessibleHeader = true;
            grvCountry.HeaderRow.TableSection = TableRowSection.TableHeader;
        }

        #endregion Get Data

        #region country add,update,delete

        /// <summary>
        /// go to add page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Session["label"] = "add";
            Response.Redirect("CountryCreate.aspx");
        }

        /// <summary>
        /// go to update page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grvCountry_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Session.Remove("url");
            Session["label"] = "update";
            int id = Convert.ToInt32(grvCountry.DataKeys[e.RowIndex].Value);
            string strURL = "CountryCreate.aspx?";
            string strURLWithData = strURL +
          EncryptQueryString(string.Format("id={0}",id));
            HttpContext.Current.Response.Redirect(strURLWithData);
         }
        public string EncryptQueryString(string strQueryString)
        {
            EncryptDecryptQueryString objEDQueryString = new EncryptDecryptQueryString();
            return objEDQueryString.Encrypt(strQueryString, "r0b1nr0y");
        }

        /// <summary>
        /// deleting customer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grvCountry_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int cid;
            int id = Convert.ToInt32(grvCountry.DataKeys[e.RowIndex].Value);
            da = JobPortal_Services.Company.CompanyService.GetCompanyAllData();
            for (int j = 0; j < da.Rows.Count; j++)
            {
                cid = Convert.ToInt32(da.Rows[j]["country_id"]);
                if (cid == id)
                {
                    Session["alert"] =Message.I0008;
                    Session["alert-type"] = "warning";
                    GetData();
                    return;
                }
            }
            countrymodel.ID = id;
            bool IsDelete = JobPortal_Services.Country.CountryServices.Delete(countrymodel);
            if (IsDelete)
            {
                Session["alert"] = Message.I0003;
                Session["alert-type"] = "success";
                GetData();
            }
            else
            {
                Session["alert"] = Message.I0007;
                Session["alert-type"] = "danger";
            }
        }

        #endregion country add,update,delete

        #region search country

        /// <summary>
        /// search customer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            da = JobPortal_Services.Country.CountryServices.GetSearchData(txtSearch.Text);
            if (da.Rows.Count > 0)
            {
                grvCountry.DataSource = da;
                grvCountry.DataBind();
                grvCountry.Visible = true;
            }
            else
            {
                grvCountry.DataSource = null;
                grvCountry.DataBind();
            }
            grvCountry.UseAccessibleHeader = true;
            grvCountry.HeaderRow.TableSection = TableRowSection.TableHeader;
        }

        #endregion search country

        #region paging

        /// <summary>
        /// paging
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grvCountry_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvCountry.PageIndex = e.NewPageIndex;
            this.GetData();
        }

        #endregion paging

        #region clear and search Text changed

        /// <summary>
        /// clear text
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtSearch.Text = string.Empty;
            this.GetData();
        }

        /// <summary>
        /// search text changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void txtSearch_TextChanged(object sender, EventArgs e)
        {
            da = JobPortal_Services.Country.CountryServices.GetSearchData(txtSearch.Text);
            if (da.Rows.Count > 0)
            {
                grvCountry.DataSource = da;
                grvCountry.DataBind();
                grvCountry.Visible = true;
            }
            else
            {
                grvCountry.DataSource = null;
                grvCountry.DataBind();
            }
            grvCountry.UseAccessibleHeader = true;
            grvCountry.HeaderRow.TableSection = TableRowSection.TableHeader;
        }

        #endregion clear and search Text changed
    }
}