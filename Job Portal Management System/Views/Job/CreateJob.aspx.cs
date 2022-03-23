using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Job_Portal_Management_System.Views.Job
{
    public partial class CreateJob : System.Web.UI.Page
    {
        JobPortal_Models.Job.Job jobmodel = new JobPortal_Models.Job.Job();
        JobPortal_Services.Job.JobService jobservice = new JobPortal_Services.Job.JobService();
        DataTable da = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["email"] == null)
            {
                Response.Redirect("~/Views/Login.aspx");
            }
            if (Request.QueryString["action"]=="update" )
            {
                if (!IsPostBack)
                {
                    bindSkill();
                    bindPosition();
                    bindJobType();
                    bindSpecialization();
                    int id = Convert.ToInt32(Request.QueryString["id"]);
                    SqlDataReader dr = JobPortal_Services.Job.JobService.ReadData(id);
                    while (dr.Read())
                    {
                        txtTitle.Text = dr["title"].ToString();
                        ddlDegree.SelectedValue = dr["degree"].ToString();
                        string skills = dr["skill"].ToString();
                        string[] skillList = skills.Split(',');
                        foreach (string s in skillList)
                        {
                            foreach (ListItem item in lbSkill.Items)
                            {
                                if (s == item.Text)
                                {
                                    item.Selected = true;
                                }
                            }
                        }
                        txtExperience.Text = dr["experience"].ToString();
                        txtVacancy.Text = dr["vacancy"].ToString();
                        ddlPosition.SelectedValue = dr["position_id"].ToString();
                        ddlJobtype.SelectedValue = dr["job_nature_id"].ToString();
                        ddlSpecialization.SelectedValue = dr["specialization_id"].ToString();
                        txtSalary.Text = dr["salary"].ToString();
                        txtDetail.Text = dr["detail"].ToString();
                        string active = dr["active"].ToString();
                        if(active == "Active")
                        {
                            customSwitch1.Checked = true;
                        }
                    }
                }
            }
            else
            {
                if (!IsPostBack)
                {
                    bindSkill();
                    bindPosition();
                    bindJobType();
                    bindSpecialization();
                }
            }
        }

        public void bindSkill()
        {
            da = JobPortal_Services.Skill.SkillServices.GetAllData();
            if (da.Rows.Count > 0)
            {
                lbSkill.DataSource = da;
                lbSkill.DataValueField = "id";
                lbSkill.DataTextField = "skill";
                lbSkill.DataBind();
            }
        }

        public void bindPosition()
        {
            da = JobPortal_Services.Position.PositionServices.GetAllData();
            if (da.Rows.Count > 0)
            {
                ddlPosition.DataSource = da;
                ddlPosition.DataValueField = "id";
                ddlPosition.DataTextField = "position";
                ddlPosition.DataBind();
            }
        }

        public void bindJobType()
        {
            da = JobPortal_Services.Jobnature.JobnatureServices.GetAllData();
            if (da.Rows.Count > 0)
            {
                ddlJobtype.DataSource = da;
                ddlJobtype.DataValueField = "id";
                ddlJobtype.DataTextField = "job_nature";
                ddlJobtype.DataBind();
            }
        }
        public void bindSpecialization()
        {
            da = JobPortal_Services.Specialization.SpecializationServices.GetAllData();
            if (da.Rows.Count > 0)
            {
                ddlSpecialization.DataSource = da;
                ddlSpecialization.DataValueField = "id";
                ddlSpecialization.DataTextField = "specialization";
                ddlSpecialization.DataBind();
            }
        }


        #region InsertData
        /// <summary>
        /// InsertData
        /// </summary>
        private void InsertData()
        {
           jobmodel.Title = txtTitle.Text;
            jobmodel.Degree = ddlDegree.SelectedValue;
            string strskill = string.Empty;
            foreach (ListItem item in lbSkill.Items)
            {
                if (item.Selected)
                {
                    strskill += item.Text + ",";
                }
            }
            jobmodel.Skill = strskill.Remove(strskill.Length - 1);
            jobmodel.Experience = txtExperience.Text;
            jobmodel.Vacancy = Convert.ToInt32(txtVacancy.Text);
            jobmodel.Company_id = Convert.ToInt32(Session["id"]);
            jobmodel.Position_id =Convert.ToInt32(ddlPosition.SelectedValue);
            jobmodel.Jobnature_id = Convert.ToInt32(ddlJobtype.SelectedValue);
            jobmodel.Specialization_id = Convert.ToInt32(ddlSpecialization.SelectedValue);
            jobmodel.Salary = Convert.ToInt32(txtSalary.Text);
            jobmodel.Detail = txtDetail.Text;    
            jobmodel.CreatedDate = DateTime.Now;
            jobmodel.UpdatedDate = DateTime.Now;
        }
        #endregion

        #region UpdateData
        /// <summary>
        /// UpdateData
        /// </summary>
        private void UpdateData()
        {
           jobmodel.ID = Convert.ToInt32(Request.QueryString["id"]);
            jobmodel.Title = txtTitle.Text;
            jobmodel.Degree = ddlDegree.SelectedValue;
            string strskill = string.Empty;
            foreach (ListItem item in lbSkill.Items)
            {
                if (item.Selected)
                {
                    strskill += item.Text + ",";
                }
            }
            jobmodel.Skill = strskill.Remove(strskill.Length - 1);
            jobmodel.Experience = txtExperience.Text;
            jobmodel.Vacancy = Convert.ToInt32(txtVacancy.Text);
            jobmodel.Company_id = Convert.ToInt32(Session["id"]);
            jobmodel.Position_id = Convert.ToInt32(ddlPosition.SelectedValue);
            jobmodel.Jobnature_id = Convert.ToInt32(ddlJobtype.SelectedValue);
            jobmodel.Specialization_id= Convert.ToInt32(ddlSpecialization.SelectedValue);
            jobmodel.Salary = Convert.ToInt32(txtSalary.Text);
            jobmodel.Detail = txtDetail.Text;           
            if (customSwitch1.Checked)
            {
                jobmodel.Active = 1;
            }
            else
            {
                jobmodel.Active = 0;
            }
            jobmodel.UpdatedDate = DateTime.Now;
        }
        #endregion
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["action"] == "update")
            {
                UpdateData();
                bool IsUpdate = JobPortal_Services.Job.JobService.Update(jobmodel);
                if (IsUpdate)
                {
                    Session["alert"] = "Updated successfully";
                    Session["alert-type"] = "success";
                    Response.Redirect("JobList.aspx");
                }
                else
                {
                    Session["alert"] = "Updating failed";
                    Session["alert-type"] = "danger";
                    Response.Redirect("JobList.aspx");
                }
            }
            else
            {
                InsertData();
                bool success = JobPortal_Services.Job.JobService.Insert(jobmodel);
                if (success)
                {
                    Session["alert"] = "Successfully created";
                    Session["alert-type"] = "success";
                    ClearFields();
                }
                else
                {
                    Session["alert"] = "Failed Creating";
                    Session["alert-type"] = "danger";
                }
            }
            
        }

        private void ClearFields()
        {
            txtTitle.Text = string.Empty;
            ddlDegree.SelectedIndex = -1;
            lbSkill.SelectedIndex = -1;
            txtExperience.Text = string.Empty;
            txtVacancy.Text = string.Empty;
            ddlPosition.SelectedIndex = -1;
            ddlJobtype.SelectedIndex = -1;
            ddlSpecialization.SelectedIndex = -1;
            txtSalary.Text = string.Empty;
            txtDetail.Text = string.Empty;

        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();

        }
    }
}