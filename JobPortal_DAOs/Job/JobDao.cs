using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal_DAOs.Job
{
    public class JobDao
    {
        #region Insert/Update/Delete
        /// <summary>
        /// Insert Data
        /// </summary>
        ///<returns></returns>
        public static bool Insert(JobPortal_Models.Job.Job job)
        {
            try
            {
                var arr = new object[13];
                arr[0] = job.Title;
                arr[1] = job.Degree;
                arr[2] = job.Skill;
                arr[3] = job.Experience;
                arr[4] = job.Vacancy;
                arr[5] = job.Company_id;
                arr[6] = job.Position_id;
                arr[7] = job.Jobnature_id;
                arr[8] = job.Salary;
                arr[9] = job.Detail;
                arr[10] = job.CreatedDate;
                arr[11] = job.UpdatedDate;
                bool num = Common.HelperDao.Insert(arr, "title,degree,skill,experience,vacancy,company_id,position_id,job_nature_id,salary,detail,created_at,updated_at", "tbl_job");
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
        public static bool Update(JobPortal_Models.Job.Job job)
        {
            try
            {
                var arr = new object[14];
                arr[0] = job.Title;
                arr[1] = job.Degree;
                arr[2] = job.Skill;
                arr[3] = job.Experience;
                arr[4] = job.Vacancy;
                arr[5] = job.Company_id;
                arr[6] = job.Position_id;
                arr[7] = job.Jobnature_id;
                arr[8] = job.Salary;
                arr[9] = job.Detail;
                arr[10] = job.UpdatedDate;
                arr[11] = job.Active;
                arr[12] = job.ID;
                Common.HelperDao.Update("Update tbl_job set title=@1,degree=@2,skill=@3,experience=@4,vacancy=@5,company_id=@6,position_id=@7,job_nature_id=@8,salary=@9,detail=@10,updated_at=@11,active=@12 where id=@13", arr);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Delete Data
        /// </summary>
        /// <returns></returns>
        public static bool Delete(JobPortal_Models.Job.Job job)
        {
            try
            {
                var arr = new object[2];
                arr[0] = job.ID;
                Common.HelperDao.Delete("Delete from tbl_job where id=@1", arr);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Get Data
        /// <summary>
        /// Get Data
        /// </summary>
        /// <returns></returns>
        public static DataTable GetData(string email)
        {
            try
            {
                return Common.HelperDao.GetData("Select email from tbl_company where email COLLATE Latin1_General_CS_AS='" + email + "'", CommandType.Text);
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
        public static DataTable GetAllData()
        {
            try
            {
                return Common.HelperDao.GetData("Select tbl_job.id,title,degree,skill,experience,vacancy,company_id,position_id,position,job_nature_id,job_nature,salary,detail,(CASE WHEN active = 1 THEN 'Active' ELSE 'Inactive' END)as active,created_at,updated_at from tbl_job join tbl_position on tbl_position.id = tbl_job.position_id join tbl_jobnature on tbl_jobnature.id = tbl_job.job_nature_id Where tbl_job.company_id=1", CommandType.Text);
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
