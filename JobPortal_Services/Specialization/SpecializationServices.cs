using System;
using System.Data;
using System.Data.SqlClient;

namespace JobPortal_Services.Specialization
{
    public class SpecializationServices
    {
        #region Insert/Update/Delete

        /// <summary>
        /// Insert Data
        /// </summary>
        public static bool Insert(JobPortal_Models.Specialization.Specialization specialization)
        {
            try
            {
                var mydt = new JobPortal_DAOs.Specialization.SpecializationDaos();
                return JobPortal_DAOs.Specialization.SpecializationDaos.Insert(specialization);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Update Data
        /// </summary>
        public static bool Update(JobPortal_Models.Specialization.Specialization specialization)
        {
            try
            {
                return JobPortal_DAOs.Specialization.SpecializationDaos.Update(specialization);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Delete Data
        /// </summary>
        public static bool Delete(JobPortal_Models.Specialization.Specialization specialization)
        {
            try
            {
                return JobPortal_DAOs.Specialization.SpecializationDaos.Delete(specialization);
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
        public static DataTable GetData(string specialization)
        {
            try
            {
                return JobPortal_DAOs.Specialization.SpecializationDaos.GetData(specialization.ToString().Replace("'", "''"));
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
                return JobPortal_DAOs.Specialization.SpecializationDaos.GetAllData();
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
                return JobPortal_DAOs.Specialization.SpecializationDaos.GetSearchData(str.ToString().Replace("'", "''"));
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
                return JobPortal_DAOs.Specialization.SpecializationDaos.ReadData(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion Get Data
    }
}