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

        /// <summary>
        /// Update Data
        /// </summary>
        public static bool Accept(JobPortal_Models.JobOffer.JobOffer joboffer)
        {
            try
            {
                return JobPortal_DAOs.JobOffer.JobOfferDao.Accept(joboffer);
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
        public static bool Delete(JobPortal_Models.JobOffer.JobOffer joboffer)
        {
            try
            {
                return JobPortal_DAOs.JobOffer.JobOfferDao.Delete(joboffer);
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
                return JobPortal_DAOs.JobOffer.JobOfferDao.GetAllData(companyId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Get All Data
        /// </summary>
        public static DataTable GetAllJobOffer()
        {
            try
            {
                return JobPortal_DAOs.JobOffer.JobOfferDao.GetAllJoboffer();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get Search Data
        /// </summary>
        public static DataTable GetSearchAllJoboffer(string str, string company)
        {
            try
            {
     return JobPortal_DAOs.JobOffer.JobOfferDao.GetSearchAllJoboffer(str.ToString().Replace("'", "''"), company);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get Search Data
        /// </summary>
        public static DataTable GetSearchAllAcceptData(int status, string search, string company)
        {
            try
            {
                return JobPortal_DAOs.JobOffer.JobOfferDao.GetSearchAllAccept(status,search.ToString().Replace("'", "''"), company);
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
        /// Get Search Data
        /// </summary>
        public static DataTable GetJobByJobseeker(int JobSeekerID)
        {
            try
            {
                return JobPortal_DAOs.JobOffer.JobOfferDao.GetJobByJobseeker(JobSeekerID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get Search Data
        /// </summary>
        public static DataTable GetSearchData(string str, int companyID)
        {
            try
            {
     return JobPortal_DAOs.JobOffer.JobOfferDao.GetSearchData(str.ToString().Replace("'", "''"), companyID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get Search Data
        /// </summary>
        public static DataTable GetSearchAcceptData(int status, int companyID)
        {
            try
            {
                return JobPortal_DAOs.JobOffer.JobOfferDao.GetSearchAcceptData(status, companyID);
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
