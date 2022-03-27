using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Job_Portal_Management_System.Views.Skill
{
    public partial class SkillCreate : System.Web.UI.Page
    {
        #region variable declaration

        private JobPortal_Models.Skill.Skill skillmodel = new JobPortal_Models.Skill.Skill();
        private DataTable da = new DataTable();

        #endregion variable declaration

        #region binding data and getting data

        /// <summary>
        /// binding data and getting data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["action"] == "add")
            {
                Session.Remove("label");
                lblSkill.Text = "Add Skill";
            }
            if (Session["label"] != null)
            {
                string label = Session["label"].ToString();
                if (label == "add")
                {
                    lblSkill.Text = "Add Skill";
                    lblSkillbreadcrumb.Text = "Add Skill";
                    if (!IsPostBack)
                    {
                    }
                }
                else if (label == "update")
                {
                    lblSkill.Text = "Update Skill";
                    lblSkillbreadcrumb.Text = "Update Skill";
                    if (!IsPostBack)
                    {
                        int id = Convert.ToInt32(Request.QueryString["id"]);
                        SqlDataReader dr = JobPortal_Services.Skill.SkillServices.ReadData(id);
                        while (dr.Read())
                        {
                            string ID = dr["id"].ToString();
                            string skill = dr["skill"].ToString();
                            hfSkill.Value = ID;
                            txtSkill.Text = skill;
                        }
                    }
                }
            }
        }

        #endregion binding data and getting data

        #region InsertData

        /// <summary>
        /// InsertData
        /// </summary>
        private void InsertData()
        {
            skillmodel.Skill_Name = txtSkill.Text;
        }

        #endregion InsertData

        #region UpdateData

        /// <summary>
        /// UpdateData
        /// </summary>
        private void UpdateData()
        {
            skillmodel.ID = Convert.ToInt32(hfSkill.Value);
            skillmodel.Skill_Name = txtSkill.Text;
        }

        #endregion UpdateData

        #region creating and updating country

        /// <summary>
        /// creating and updating country
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (hfSkill.Value == "")
            {
                da = JobPortal_Services.Skill.SkillServices.GetData(txtSkill.Text);
                if (da.Rows.Count > 0)
                {
                    Session["alert"] = "Data already exist";
                    Session["alert-type"] = "warning";
                    Response.Redirect("SkillList.aspx");
                }
                else
                {
                    InsertData();
                    bool success = JobPortal_Services.Skill.SkillServices.Insert(skillmodel);
                    if (success)
                    {
                        Session["alert"] = "Added Skill Successfully";
                        Session["alert-type"] = "success";
                        Response.Redirect("SkillList.aspx");
                        txtSkill.Text = string.Empty;
                    }
                    else
                    {
                        Session["alert"] = "Adding failed. Try again!!";
                        Session["alert-type"] = "danger";
                        Response.Redirect("SkillList.aspx");
                    }
                }
            }
            else
            {
                da = JobPortal_Services.Skill.SkillServices.GetData(txtSkill.Text);
                if (da.Rows.Count > 0)
                {
                    Session["alert"] = "Data already exist";
                    Session["alert-type"] = "warning";
                    Response.Redirect("SkillList.aspx");
                }
                else
                {
                    UpdateData();
                    bool IsUpdate = JobPortal_Services.Skill.SkillServices.Update(skillmodel);
                    if (IsUpdate)
                    {
                        Session["alert"] = "Updated successfully";
                        Session["alert-type"] = "success";
                        Response.Redirect("SkillList.aspx");
                    }
                    else
                    {
                        Session["alert"] = "Updating failed";
                        Session["alert-type"] = "danger";
                        Response.Redirect("SkillList.aspx");
                    }
                }
            }
        }

        #endregion creating and updating country

        #region back and clear

        /// <summary>
        /// clear form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtSkill.Text = string.Empty;
        }

        /// <summary>
        ///  back to list page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("SkillList.aspx");
        }

        #endregion back and clear
    }
}