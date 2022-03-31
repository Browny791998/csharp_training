using System;
using System.Data;
using System.Web;
using System.Web.UI.WebControls;
using Job_Portal_Management_System.Properties;
namespace Job_Portal_Management_System.Views.Joboffer
{
    public partial class JobOfferList : System.Web.UI.Page
    {
        #region variable declaration

        private JobPortal_Models.JobOffer.JobOffer joboffermodel = new JobPortal_Models.JobOffer.JobOffer();
        private JobPortal_Services.JobOffer.JobOfferService jobofferservice = new JobPortal_Services.JobOffer.JobOfferService();
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
                Response.Redirect("~/Views/Login.aspx");
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
            int companyID = Convert.ToInt32(Session["id"]);
            da = JobPortal_Services.JobOffer.JobOfferService.GetAllData(companyID);
            if (da.Rows.Count > 0)
            {
                grvJobOffer.DataSource = da;
                grvJobOffer.DataBind();
                grvJobOffer.Visible = true;
                grvJobOffer.UseAccessibleHeader = true;
                grvJobOffer.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            else
            {
                grvJobOffer.DataSource = null;
                grvJobOffer.DataBind();
            }
        }

        #endregion Get Data

        #region check jobseeker

        /// <summary>
        /// check jobseeker
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grvJobOffer_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = grvJobOffer.Rows[rowIndex];
            int jobseekerID = Convert.ToInt32((row.FindControl("lbljobseekerId") as Label).Text);
            int jobID = Convert.ToInt32((row.FindControl("lbljobId") as Label).Text);
            if (e.CommandName == "Accept")
            {
                joboffermodel.JobSeekerID = jobseekerID;
                joboffermodel.IsAccept = 1;
                joboffermodel.JobID = jobID;
                bool IsAccept = JobPortal_Services.JobOffer.JobOfferService.Accept(joboffermodel);
                if (IsAccept)
                {
                    Session["alert"] = Message.I0027;
                    Session["alert-type"] = "success";
                    GetData();
                }
                else
                {
                    Session["alert"] = Message.I0028;
                    Session["alert-type"] = "danger";
                }
            }
            else if (e.CommandName == "Reject")
            {
                joboffermodel.JobSeekerID = jobseekerID;
                joboffermodel.IsAccept = 0;
                joboffermodel.JobID = jobID;
                bool IsAccept = JobPortal_Services.JobOffer.JobOfferService.Accept(joboffermodel);
                if (IsAccept)
                {
                    Session["alert"] =Message.I0029;
                    Session["alert-type"] = "success";
                    GetData();
                }
                else
                {
                    Session["alert"] = Message.I0030;
                    Session["alert-type"] = "danger";
                }
            }
            else if (e.CommandName == "Detail")
            {
                Session.Remove("url");
                string strURL = "ApplierDetail.aspx?";
                string strURLWithData = strURL + EncryptQueryString(string.Format("id={0}",jobseekerID));
                HttpContext.Current.Response.Redirect(strURLWithData);
            }
        }

        public string EncryptQueryString(string strQueryString)
        {
            EncryptDecryptQueryString objEDQueryString = new EncryptDecryptQueryString();
            return objEDQueryString.Encrypt(strQueryString, "r0b1nr0y");
        }

        #endregion check jobseeker

        #region search and clear data

        /// <summary>
        /// search data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            rdoAccept.Checked = false;
            rdoReject.Checked = false;
            da = JobPortal_Services.JobOffer.JobOfferService.GetSearchData(txtSearch.Text, Convert.ToInt32(Session["id"]));
            if (da.Rows.Count > 0)
            {
                grvJobOffer.DataSource = da;
                grvJobOffer.DataBind();
                grvJobOffer.Visible = true;
            }
            else
            {
                grvJobOffer.DataSource = null;
                grvJobOffer.DataBind();
            }
            grvJobOffer.UseAccessibleHeader = true;
            grvJobOffer.HeaderRow.TableSection = TableRowSection.TableHeader;
        }

        /// <summary>
        /// clear data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtSearch.Text = string.Empty;
            rdoAccept.Checked = false;
            rdoReject.Checked = false;
            this.GetData();
        }

        #endregion search and clear data

        #region accept and reject

        /// <summary>
        /// data bind to datagrid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grvJobOffer_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvJobOffer.PageIndex = e.NewPageIndex;
            this.GetData();
        }

        /// <summary>
        /// check jobseeker accept or reject
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grvJobOffer_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataRowView drv = e.Row.DataItem as DataRowView;
                if (drv["Accept"].ToString().Equals("Accepted"))
                {
                    e.Row.BackColor = System.Drawing.Color.PaleGreen;
                    Button btnaccept = (Button)e.Row.FindControl("btnAccept");
                    btnaccept.Enabled = false;
                }
                else if (drv["Accept"].ToString().Equals("Rejected"))
                {
                    e.Row.BackColor = System.Drawing.Color.Tomato;
                    Button btnreject = (Button)e.Row.FindControl("btnReject");
                    btnreject.Enabled = false;
                }
                else
                {
                    e.Row.BackColor = System.Drawing.Color.Orange;
                }
            }
        }

        /// <summary>
        /// check jobseeker accept or not
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void rdoAccept_CheckedChanged(object sender, EventArgs e)
        {
            da = JobPortal_Services.JobOffer.JobOfferService.GetSearchAcceptData(1, Convert.ToInt32(Session["id"]));
            if (da.Rows.Count > 0)
            {
                grvJobOffer.DataSource = da;
                grvJobOffer.DataBind();
                grvJobOffer.Visible = true;
            }
            else
            {
                grvJobOffer.DataSource = null;
                grvJobOffer.DataBind();
            }
            grvJobOffer.UseAccessibleHeader = true;
            grvJobOffer.HeaderRow.TableSection = TableRowSection.TableHeader;
        }

        /// <summary>
        /// check jobseeker reject or not
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void rdoReject_CheckedChanged(object sender, EventArgs e)
        {
            da = JobPortal_Services.JobOffer.JobOfferService.GetSearchAcceptData(0, Convert.ToInt32(Session["id"]));
            if (da.Rows.Count > 0)
            {
                grvJobOffer.DataSource = da;
                grvJobOffer.DataBind();
                grvJobOffer.Visible = true;
            }
            else
            {
                grvJobOffer.DataSource = null;
                grvJobOffer.DataBind();
            }
            grvJobOffer.UseAccessibleHeader = true;
            grvJobOffer.HeaderRow.TableSection = TableRowSection.TableHeader;
        }

        #endregion accept and reject
    }
}