using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal_Services.JobOffer
{
    public class JobOfferService
    {
        #region Insert/Update/Delete
        /// <summary>
        /// Insert Data
        /// </summary>
        public static bool Insert(JobPortal_Models.JobOffer.JobOffer joboffer)
        {
            try
            {
                var mydt = new JobPortal_DAOs.JobOffer.JobOfferDao();
                return JobPortal_DAOs.JobOffer.JobOfferDao.Insert(joboffer);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        ///// <summary>
        ///// Update Data
        ///// </summary>
        //public static bool Update(JobPortal_Models.Job.Job job)
        //{
        //    try
        //    {
        //        return JobPortal_DAOs.Job.JobDao.Update(job);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        /// <summary>
        /// Delete Data
        /// </summary>
        //public static bool Delete(JobPortal_Models.Job.Job job)
        //{
        //    try
        //    {
        //        return JobPortal_DAOs.Job.JobDao.Delete(job);
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
        public static DataTable GetData(int JobID)
        {
            try
            {
                return JobPortal_DAOs.Job.JobDao.GetData(JobID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get All Data
        /// </summary>
        public static DataTable GetAllData(int companyId)
        {
            try
            {
                return JobPortal_DAOs.Job.JobDao.GetAllData(companyId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// Get Search Data
        /// </summary>
        public static DataTable GetJobandSeeker(int JobID, int JobSeekerID)
        {
            try
            {
                return JobPortal_DAOs.JobOffer.JobOfferDao.GetJobandSeeker(JobID,JobSeekerID);
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
                return JobPortal_DAOs.Job.JobDao.ReadData(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
