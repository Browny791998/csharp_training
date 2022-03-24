using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Job_Portal_Management_System.Views.Joboffer
{
    public partial class JobOfferList : System.Web.UI.Page
    {

        JobPortal_Models.JobOffer.JobOffer joboffermodel = new JobPortal_Models.JobOffer.JobOffer();
        JobPortal_Services.JobOffer.JobOfferService jobofferservice = new JobPortal_Services.JobOffer.JobOfferService();
        DataTable da = new DataTable();
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



        #endregion

        protected void grvJobOffer_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = grvJobOffer.Rows[rowIndex];
            int jobseekerID = Convert.ToInt32((row.FindControl("lbljobseekerId") as Label).Text);
            if (e.CommandName == "Accept")
            {

                joboffermodel.JobSeekerID = jobseekerID;
                joboffermodel.IsAccept = 1;
                bool IsAccept = JobPortal_Services.JobOffer.JobOfferService.Accept(joboffermodel);
                if (IsAccept)
                {
                    Session["alert"] = "You accept this applier";
                    Session["alert-type"] = "success";
                    GetData();
                }
                else
                {
                    Session["alert"] = "fail to accept";
                    Session["alert-type"] = "danger";
                }
                
            }
            else if (e.CommandName == "Reject")
            {
                joboffermodel.JobSeekerID = jobseekerID;
                joboffermodel.IsAccept = 0;
                bool IsAccept = JobPortal_Services.JobOffer.JobOfferService.Accept(joboffermodel);
                if (IsAccept)
                {
                    Session["alert"] = "You reject this applier";
                    Session["alert-type"] = "success";
                    GetData();
                }
                else
                {
                    Session["alert"] = "fail to reject";
                    Session["alert-type"] = "danger";
                }
            }
            else if (e.CommandName == "Detail")
            {
                Response.Redirect("ApplierDetail.aspx?applierID=" + jobseekerID);
            }

        }



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

        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtSearch.Text = string.Empty;
            rdoAccept.Checked = false;
            rdoReject.Checked = false;
            this.GetData();
        }

        protected void grvJobOffer_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvJobOffer.PageIndex = e.NewPageIndex;
            this.GetData();
        }

        protected void grvJobOffer_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataRowView drv = e.Row.DataItem as DataRowView;
                if (drv["Accept"].ToString().Equals("Accepted"))
                {
                    e.Row.BackColor = System.Drawing.Color.PaleGreen;
                    Button btnaccept= (Button)e.Row.FindControl("btnAccept"); 
                    btnaccept.Enabled = false;
                }
                else if(drv["Accept"].ToString().Equals("Rejected"))
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
    }
}
