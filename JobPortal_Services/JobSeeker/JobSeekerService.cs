using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal_Services.JobSeeker
{
    public class JobSeekerService
    {
        #region Insert/Update/Delete
        /// <summary>
        /// Insert Data
        /// </summary>
        public static bool Insert(JobPortal_Models.JobSeeker.JobSeeker jobseeker)
        {
            try
            {
                var mydt = new JobPortal_DAOs.JobSeeker.JobSeekerDao();
                return JobPortal_DAOs.JobSeeker.JobSeekerDao.Insert(jobseeker);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Update Data
        /// </summary>
        public static bool Update(JobPortal_Models.JobSeeker.JobSeeker jobseeker)
        {
            try
            {
                return JobPortal_DAOs.JobSeeker.JobSeekerDao.Update(jobseeker);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Update Data
        /// </summary>
        public static bool UpdatebyEmail(JobPortal_Models.JobSeeker.JobSeeker jobseeker)
        {
            try
            {
                return JobPortal_DAOs.JobSeeker.JobSeekerDao.UpdatebyEmail(jobseeker);
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
        public static DataTable GetData(string email)
        {
            try
            {
                return JobPortal_DAOs.JobSeeker.JobSeekerDao.GetData(email);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get Search Data
        /// </summary>
        public static DataTable SearchAllJobSeeker(string str)
        {
            try
            {
                return JobPortal_DAOs.JobSeeker.JobSeekerDao.SearchAllJobSeeker(str);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        

        /// <summary>
        /// Get All Data
        /// </summary>
        public static DataTable GetAllJobSeeker()
        {
            try
            {
                return JobPortal_DAOs.JobSeeker.JobSeekerDao.GetAllJobSeeker();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// Get All Data
        /// </summary>
        public static DataTable GetAllData(int id)
        {
            try
            {
                return JobPortal_DAOs.JobSeeker.JobSeekerDao.GetAllData(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get Search Data
        /// </summary>
        public static DataTable GetChartData()
        {
            try
            {
                return JobPortal_DAOs.JobSeeker.JobSeekerDao.GetChartData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Read Data
        /// </summary>
        public static SqlDataReader ReadData(int id)
        {
            try
            {
                return JobPortal_DAOs.JobSeeker.JobSeekerDao.ReadData(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
