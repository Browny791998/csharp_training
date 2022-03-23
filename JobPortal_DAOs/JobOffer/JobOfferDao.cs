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

        public static bool Accept(JobPortal_Models.JobOffer.JobOffer joboffer)
        {
            try
            {
                var arr = new object[3];
                arr[0] = joboffer.IsAccept;
                arr[1] = joboffer.JobSeekerID;
                Common.HelperDao.Update("Update tbl_joboffer set is_accept=@1 where job_seeker_id=@2", arr);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
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
        public static bool Delete(JobPortal_Models.JobOffer.JobOffer joboffer)
        {
            try
            {
                var arr = new object[2];
                arr[0] = joboffer.ID;
                Common.HelperDao.Delete("Delete from tbl_joboffer where id=@1", arr);
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
        public static DataTable GetJobandSeeker(int JobID,int JobSeekerID)
        {
            try
            {
                return Common.HelperDao.GetData("Select job_id,job_seeker_id from tbl_joboffer where job_id='"+JobID+"' and job_seeker_id='"+JobSeekerID+"'", CommandType.Text);
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
        public static DataTable GetAllJoboffer()
        {
            try
            {
                return Common.HelperDao.GetData("Select tbl_joboffer.id,job_id,job_seeker_id,tbl_joboffer.company_id,CONVERT(varchar,applied_date,3) as applied_date,(CASE WHEN is_accept= 1 THEN 'Accepted' When is_accept= 0 THEN 'Rejected' ELSE 'Applying' END)as Accept,title,tbl_jobseeker.name as seeker,tbl_company.name as company,cvform,vacancy,tbl_jobseeker.email as seekermail,tbl_jobseeker.mobile,tbl_job.active from tbl_joboffer join tbl_job on tbl_job.id = tbl_joboffer.job_id join tbl_jobseeker on tbl_jobseeker.id = tbl_joboffer.job_seeker_id join tbl_company on tbl_company.id = tbl_joboffer.company_id Where tbl_job.active = 1", CommandType.Text);
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
        public static DataTable GetSearchAllJoboffer(string str, string company)
        {
            try
            {
                if (str == "")
                {
                    return Common.HelperDao.GetData("Select tbl_joboffer.id,job_id,job_seeker_id,tbl_joboffer.company_id,CONVERT(varchar,applied_date,3) as applied_date,(CASE WHEN is_accept= 1 THEN 'Accepted' When is_accept= 0 THEN 'Rejected' ELSE 'Applying' END)as Accept,title,tbl_jobseeker.name as seeker,tbl_company.name as company,cvform,vacancy,tbl_jobseeker.email as seekermail,tbl_jobseeker.mobile,tbl_job.active from tbl_joboffer join tbl_job on tbl_job.id = tbl_joboffer.job_id join tbl_jobseeker on tbl_jobseeker.id = tbl_joboffer.job_seeker_id join tbl_company on tbl_company.id = tbl_joboffer.company_id Where tbl_job.active = 1 and tbl_company.name='" + company + "'", CommandType.Text);
                }
                else
                {
                    return Common.HelperDao.GetData("Select tbl_joboffer.id,job_id,job_seeker_id,tbl_joboffer.company_id,CONVERT(varchar,applied_date,3) as applied_date,(CASE WHEN is_accept= 1 THEN 'Accepted' When is_accept= 0 THEN 'Rejected' ELSE 'Applying' END)as Accept,title,tbl_jobseeker.name as seeker,tbl_company.name as company,cvform,vacancy,tbl_jobseeker.email as seekermail,tbl_jobseeker.mobile,tbl_job.active from tbl_joboffer join tbl_job on tbl_job.id = tbl_joboffer.job_id join tbl_jobseeker on tbl_jobseeker.id = tbl_joboffer.job_seeker_id join tbl_company on tbl_company.id = tbl_joboffer.company_id Where tbl_company.name='" + company + "' and tbl_job.active = 1 and  title LIKE '%" + str + "%'", CommandType.Text);
                }
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
        public static DataTable GetSearchAllAccept(int status, string search, string company)
        {
            try
            {
                return Common.HelperDao.GetData("Select tbl_joboffer.id,job_id,job_seeker_id,tbl_joboffer.company_id,CONVERT(varchar,applied_date,3) as applied_date,(CASE WHEN is_accept= 1 THEN 'Accepted' When is_accept= 0 THEN 'Rejected' ELSE 'Applying' END)as Accept,title,tbl_jobseeker.name as seeker,tbl_company.name as company,cvform,vacancy,tbl_jobseeker.email as seekermail,tbl_jobseeker.mobile,tbl_job.active from tbl_joboffer join tbl_job on tbl_job.id = tbl_joboffer.job_id join tbl_jobseeker on tbl_jobseeker.id = tbl_joboffer.job_seeker_id join tbl_company on tbl_company.id = tbl_joboffer.company_id Where tbl_company.name='" + company + "' and  tbl_job.active = 1 and is_accept='" + status + "' and title LIKE '%" + search + "%'", CommandType.Text);
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
                return Common.HelperDao.GetData("Select tbl_joboffer.id,job_id,job_seeker_id,tbl_joboffer.company_id,CONVERT(varchar,applied_date,3) as applied_date,(CASE WHEN is_accept= 1 THEN 'Accepted' When is_accept= 0 THEN 'Rejected' ELSE 'Applying' END)as Accept,title,name,cvform,vacancy,email,mobile,tbl_job.active from tbl_joboffer join tbl_job on tbl_job.id = tbl_joboffer.job_id join tbl_jobseeker on tbl_jobseeker.id = tbl_joboffer.job_seeker_id Where tbl_job.active=1 and tbl_joboffer.company_id='" + companyId + "'", CommandType.Text);
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
        public static DataTable GetJobByJobseeker(int JobSeekerId)
        {
            try
            {
                return Common.HelperDao.GetData("Select tbl_joboffer.id,job_id,job_seeker_id,tbl_joboffer.company_id,CONVERT(varchar,applied_date,3) as applied_date,(CASE WHEN is_accept= 1 THEN 'Accepted' When is_accept= 0 THEN 'Rejected' ELSE 'Applying' END)as Accept,title,tbl_company.name,cvform,vacancy,tbl_company.email,tbl_company.mobile,country,position,job_nature,specialization,tbl_job.active from tbl_joboffer join tbl_job on tbl_job.id = tbl_joboffer.job_id join tbl_jobseeker on tbl_jobseeker.id = tbl_joboffer.job_seeker_id join tbl_company on tbl_company.id = tbl_joboffer.company_id join tbl_country on tbl_country.id = tbl_company.country_id join tbl_position on tbl_position.id = tbl_job.position_id join tbl_jobnature on tbl_jobnature.id = tbl_job.job_nature_id join tbl_specialization on tbl_specialization.id = tbl_job.specialization_id Where tbl_job.active = 1 and tbl_joboffer.job_seeker_id = '" + JobSeekerId+ "'", CommandType.Text);
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
        public static DataTable GetSearchData(string str, int companyId)
        {
            try
            {
                if (str == "")
                {
                    return Common.HelperDao.GetData("Select tbl_joboffer.id,job_id,job_seeker_id,tbl_joboffer.company_id,CONVERT(varchar,applied_date,3) as applied_date,(CASE WHEN is_accept= 1 THEN 'Accepted' When is_accept= 0 THEN 'Rejected' ELSE 'Applying' END)as Accept,title,name,cvform,vacancy,email,mobile,tbl_job.active from tbl_joboffer join tbl_job on tbl_job.id = tbl_joboffer.job_id join tbl_jobseeker on tbl_jobseeker.id = tbl_joboffer.job_seeker_id Where tbl_job.active=1 and tbl_joboffer.company_id='" + companyId + "'", CommandType.Text);
                }
                else
                {
                    return Common.HelperDao.GetData("Select tbl_joboffer.id,job_id,job_seeker_id,tbl_joboffer.company_id,CONVERT(varchar,applied_date,3) as applied_date,(CASE WHEN is_accept= 1 THEN 'Accepted' When is_accept= 0 THEN 'Rejected' ELSE 'Applying' END)as Accept,title,name,cvform,vacancy,email,mobile,tbl_job.active from tbl_joboffer join tbl_job on tbl_job.id = tbl_joboffer.job_id join tbl_jobseeker on tbl_jobseeker.id = tbl_joboffer.job_seeker_id Where tbl_job.active=1 and tbl_joboffer.company_id='" + companyId + "' and title LIKE '%" + str + "%'", CommandType.Text);
                }
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
        public static DataTable GetSearchAcceptData(int status, int companyId)
        {
            try
            {
              return Common.HelperDao.GetData("Select tbl_joboffer.id,job_id,job_seeker_id,tbl_joboffer.company_id,CONVERT(varchar,applied_date,3) as applied_date,(CASE WHEN is_accept= 1 THEN 'Accepted' When is_accept= 0 THEN 'Rejected' ELSE 'Applying' END)as Accept,title,name,cvform,vacancy,email,mobile,tbl_job.active from tbl_joboffer join tbl_job on tbl_job.id = tbl_joboffer.job_id join tbl_jobseeker on tbl_jobseeker.id = tbl_joboffer.job_seeker_id Where tbl_job.active=1 and tbl_joboffer.company_id='" + companyId + "' and is_accept='"+status+"'", CommandType.Text);
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
