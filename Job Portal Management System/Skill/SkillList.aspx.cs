using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Job_Portal_Management_System.Views.Skill
{
    public partial class SkillList : System.Web.UI.Page
    {
        #region variable declaration

        private JobPortal_Models.Skill.Skill skillmodel = new JobPortal_Models.Skill.Skill();
        private JobPortal_Services.Skill.SkillServices skillservice = new JobPortal_Services.Skill.SkillServices();
        private DataTable da = new DataTable();
        SqlDataReader dr;

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
            da = JobPortal_Services.Skill.SkillServices.GetAllData();
            if (da.Rows.Count > 0)
            {
                grvSkill.DataSource = da;
                grvSkill.DataBind();
                grvSkill.Visible = true;
            }
            else
            {
                grvSkill.DataSource = null;
                grvSkill.DataBind();
            }
            grvSkill.UseAccessibleHeader = true;
            grvSkill.HeaderRow.TableSection = TableRowSection.TableHeader;
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
            Response.Redirect("SkillCreate.aspx");
        }

        /// <summary>
        /// go to update page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grvSkill_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Session["label"] = "update";
            int id = Convert.ToInt32(grvSkill.DataKeys[e.RowIndex].Value);
            Response.Redirect("SkillCreate.aspx?id=" + id);
        }

        /// <summary>
        /// deleting customer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        string[] skillList;
        protected void grvSkill_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            int id = Convert.ToInt32(grvSkill.DataKeys[e.RowIndex].Value);
            dr = JobPortal_Services.Skill.SkillServices.ReadData(id);
            while (dr.Read())
            {

                da = JobPortal_Services.Job.JobService.GetAllJObData();

                for (int j = 0; j < da.Rows.Count; j++)
                {
                    skillList = da.Rows[j]["skill"].ToString().Split(',');

                    foreach (string s in skillList)
                    {
                        if (s == dr["skill"].ToString())
                        {
                            Session["alert"] = "Data Exist You can't delete this";
                            Session["alert-type"] = "warning";
                            GetData();
                            return;
                        }
                    }
                }

                da = JobPortal_Services.JobSeeker.JobSeekerService.GetAllJobSeeker();
                for (int j = 0; j < da.Rows.Count; j++)
                {
                    skillList = da.Rows[j]["skill"].ToString().Split(',');

                    foreach (string s in skillList)
                    {
                        if (s == dr["skill"].ToString())
                        {
                            Session["alert"] = "Data Exist You can't delete this";
                            Session["alert-type"] = "warning";
                            GetData();
                            return;
                        }
                    }
                }
            }
            skillmodel.ID = id;
            bool IsDelete = JobPortal_Services.Skill.SkillServices.Delete(skillmodel);
            if (IsDelete)
            {
                Session["alert"] = "Deleted successfully";
                Session["alert-type"] = "success";
                GetData();
            }
            else
            {
                Session["alert"] = "Deleting failed";
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
            da = JobPortal_Services.Skill.SkillServices.GetSearchData(txtSearch.Text);
            if (da.Rows.Count > 0)
            {
                grvSkill.DataSource = da;
                grvSkill.DataBind();
                grvSkill.Visible = true;
            }
            else
            {
                grvSkill.DataSource = null;
                grvSkill.DataBind();
            }
            grvSkill.UseAccessibleHeader = true;
            grvSkill.HeaderRow.TableSection = TableRowSection.TableHeader;
        }

        #endregion search country

        #region paging

        /// <summary>
        /// paging
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grvSkill_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvSkill.PageIndex = e.NewPageIndex;
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
            da = JobPortal_Services.Skill.SkillServices.GetSearchData(txtSearch.Text);
            if (da.Rows.Count > 0)
            {
                grvSkill.DataSource = da;
                grvSkill.DataBind();
                grvSkill.Visible = true;
            }
            else
            {
                grvSkill.DataSource = null;
                grvSkill.DataBind();
            }
            grvSkill.UseAccessibleHeader = true;
            grvSkill.HeaderRow.TableSection = TableRowSection.TableHeader;
        }

        #endregion clear and search Text changed
    }
}