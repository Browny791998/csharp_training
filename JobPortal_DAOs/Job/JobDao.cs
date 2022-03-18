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
        public static bool Update(JobPortal_Models.Company.Company company)
        {
            try
            {
                var arr = new object[10];
                arr[0] = company.Name;
                arr[1] = company.CountryID;
                arr[2] = company.Address;
                arr[3] = company.ContactPerson;
                arr[4] = company.Mobile;
                arr[5] = company.Website;
                arr[6] = company.Detail;
                arr[7] = company.UpdatedDate;
                arr[8] = company.ID;
                Common.HelperDao.Update("Update tbl_company set name=@1,country_id=@2,address=@3,contact_person=@4,mobile=@5,website=@6,detail=@7,updated_at=@8 where id=@9", arr);
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
        //public static DataTable GetSearchData(string str)
        //{
        //    try
        //    {
        //        if (str == "")
        //        {
        //            return Common.HelperDao.GetData("Select id,movie from tbl_movie", CommandType.Text);
        //        }
        //        else
        //        {
        //            //return Common.HelperDao.GetData("Select id,movie from tbl_movie where movie LIKE '" + str + "'", CommandType.Text);
        //            return Common.HelperDao.GetData("Select id,movie from tbl_movie where movie LIKE '%" + str + "%'", CommandType.Text);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        /// <summary>
        /// Read Data
        /// </summary>
        /// <returns></returns>
        public static SqlDataReader ReadData(int id)
        {
            try
            {
                return Common.HelperDao.ReadData("Select tbl_company.id,name,country_id,country,address,contact_person,mobile,email,password,website,role,detail,(CASE WHEN active = 1 THEN 'Active' ELSE 'Inactive' END)as active,created_at,updated_at from tbl_company join tbl_country on tbl_country.id=tbl_company.country_id where tbl_company.id='" + id + "'", CommandType.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}
