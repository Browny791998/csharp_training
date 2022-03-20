using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal_DAOs.JobOffer
{
    public class JobOfferDao
    {
        #region Insert/Update/Delete
        /// <summary>
        /// Insert Data
        /// </summary>
        ///<returns></returns>
        public static bool Insert(JobPortal_Models.JobOffer.JobOffer joboffer)
        {
            try
            {
                var arr = new object[5];
                arr[0] = joboffer.JobSeekerID;
                arr[1] = joboffer.CompanyID;
                arr[2] = joboffer.JobID;
                arr[3] = joboffer.AppliedDate;
                bool num = Common.HelperDao.Insert(arr, "job_seeker_id,company_id,job_id,applied_date", "tbl_joboffer");
                if (num)
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }

        /// <summary>
        /// Update Data
        /// <paramref name="post"/>
        /// </summary>
        /// <returns></returns>
        //public static bool Update(JobPortal_Models.Job.Job job)
        //{
        //    try
        //    {
        //        var arr = new object[14];
        //        arr[0] = job.Title;
        //        arr[1] = job.Degree;
        //        arr[2] = job.Skill;
        //        arr[3] = job.Experience;
        //        arr[4] = job.Vacancy;
        //        arr[5] = job.Company_id;
        //        arr[6] = job.Position_id;
        //        arr[7] = job.Jobnature_id;
        //        arr[8] = job.Salary;
        //        arr[9] = job.Detail;
        //        arr[10] = job.UpdatedDate;
        //        arr[11] = job.Active;
        //        arr[12] = job.ID;
        //        Common.HelperDao.Update("Update tbl_job set title=@1,degree=@2,skill=@3,experience=@4,vacancy=@5,company_id=@6,position_id=@7,job_nature_id=@8,salary=@9,detail=@10,updated_at=@11,active=@12 where id=@13", arr);
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        /// <summary>
        /// Delete Data
        /// </summary>
        /// <returns></returns>
        //public static bool Delete(JobPortal_Models.Job.Job job)
        //{
        //    try
        //    {
        //        var arr = new object[2];
        //        arr[0] = job.ID;
        //        Common.HelperDao.Delete("Delete from tbl_job where id=@1", arr);
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        #endregion

        #region Get Data
        /// <summary>
        /// Get Data
        /// </summary>
        /// <returns></returns>
        public static DataTable GetData(int JobID)
        {
            try
            {
                return Common.HelperDao.GetData("Select tbl_job.id,title,degree,skill,experience,vacancy,company_id,name,country,position_id,position,job_nature_id,job_nature,salary,tbl_job.detail,tbl_job.active,CONVERT(varchar,tbl_job.created_at,3) as created_at,tbl_job.updated_at from tbl_job join tbl_position on tbl_position.id = tbl_job.position_id join tbl_jobnature on tbl_jobnature.id = tbl_job.job_nature_id join tbl_company on tbl_company.id=tbl_job.company_id join tbl_country on tbl_country.id = tbl_company.country_id Where tbl_job.id='" + JobID + "'", CommandType.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get All Data
        /// </summary>
        /// <returns></returns>
        public static DataTable GetAllData(int companyId)
        {
            try
            {
                return Common.HelperDao.GetData("Select tbl_job.id,title,degree,skill,experience,vacancy,company_id,position_id,position,job_nature_id,job_nature,salary,detail,(CASE WHEN active = 1 THEN 'Active' ELSE 'Inactive' END)as active,created_at,updated_at from tbl_job join tbl_position on tbl_position.id = tbl_job.position_id join tbl_jobnature on tbl_jobnature.id = tbl_job.job_nature_id Where tbl_job.company_id='" + companyId + "'", CommandType.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


       


        /// <summary>
        /// Get Search Data
        /// </summary>
        /// <returns></returns>
        public static DataTable GetSearchData(string str)
        {
            try
            {
                if (str == "")
                {
                    return Common.HelperDao.GetData("Select tbl_job.id,title,degree,skill,experience,vacancy,company_id,position_id,position,job_nature_id,job_nature,salary,detail,(CASE WHEN active = 1 THEN 'Active' ELSE 'Inactive' END)as active,created_at,updated_at from tbl_job join tbl_position on tbl_position.id = tbl_job.position_id join tbl_jobnature on tbl_jobnature.id = tbl_job.job_nature_id Where tbl_job.company_id=1", CommandType.Text);
                }
                else
                {
                    return Common.HelperDao.GetData("Select tbl_job.id,title,degree,skill,experience,vacancy,company_id,position_id,position,job_nature_id,job_nature,salary,detail,(CASE WHEN active = 1 THEN 'Active' ELSE 'Inactive' END)as active,created_at,updated_at from tbl_job join tbl_position on tbl_position.id = tbl_job.position_id join tbl_jobnature on tbl_jobnature.id = tbl_job.job_nature_id Where tbl_job.company_id=1 and title LIKE '%" + str + "%'", CommandType.Text);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Read Data
        /// </summary>
        /// <returns></returns>
        public static SqlDataReader ReadData(int id)
        {
            try
            {
                return Common.HelperDao.ReadData("Select tbl_job.id,title,degree,skill,experience,vacancy,company_id,position_id,position,job_nature_id,job_nature,salary,detail,(CASE WHEN active = 1 THEN 'Active' ELSE 'Inactive' END)as active,created_at,updated_at from tbl_job join tbl_position on tbl_position.id = tbl_job.position_id join tbl_jobnature on tbl_jobnature.id = tbl_job.job_nature_id Where tbl_job.id='" + id + "'", CommandType.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}
