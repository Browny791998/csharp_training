using System;
using System.Data;
using System.Data.SqlClient;

namespace JobPortal_Services.Jobnature
{
    public class JobnatureServices
    {
        #region Insert/Update/Delete

        /// <summary>
        /// Insert Data
        /// </summary>
        public static bool Insert(JobPortal_Models.Jobnature.Jobnature jobnature)
        {
            try
            {
                var mydt = new JobPortal_DAOs.Jobnature.JobnatureDaos();
                return JobPortal_DAOs.Jobnature.JobnatureDaos.Insert(jobnature);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Update Data
        /// </summary>
        public static bool Update(JobPortal_Models.Jobnature.Jobnature jobnature)
        {
            try
            {
                return JobPortal_DAOs.Jobnature.JobnatureDaos.Update(jobnature);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Delete Data
        /// </summary>
        public static bool Delete(JobPortal_Models.Jobnature.Jobnature jobnature)
        {
            try
            {
                return JobPortal_DAOs.Jobnature.JobnatureDaos.Delete(jobnature);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion Insert/Update/Delete

        #region Get Data

        /// <summary>
        /// Get Data
        /// </summary>
        public static DataTable GetData(string jobnature)
        {
            try
            {
                return JobPortal_DAOs.Jobnature.JobnatureDaos.GetData(jobnature);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get All Data
        /// </summary>
        public static DataTable GetAllData()
        {
            try
            {
                return JobPortal_DAOs.Jobnature.JobnatureDaos.GetAllData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get Search Data
        /// </summary>
        public static DataTable GetSearchData(string str)
        {
            try
            {
                return JobPortal_DAOs.Jobnature.JobnatureDaos.GetSearchData(str);
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
                return JobPortal_DAOs.Jobnature.JobnatureDaos.ReadData(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion Get Data
    }
}