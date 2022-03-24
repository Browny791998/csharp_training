using System;
using System.Data;
using System.Data.SqlClient;

namespace JobPortal_Services.Country
{
    public class CountryServices
    {
        #region Insert/Update/Delete

        /// <summary>
        /// Insert Data
        /// </summary>
        public static bool Insert(JobPortal_Models.Country.Country country)
        {
            try
            {
                var mydt = new JobPortal_DAOs.Country.CountryDaos();
                return JobPortal_DAOs.Country.CountryDaos.Insert(country);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Update Data
        /// </summary>
        public static bool Update(JobPortal_Models.Country.Country country)
        {
            try
            {
                return JobPortal_DAOs.Country.CountryDaos.Update(country);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Delete Data
        /// </summary>
        public static bool Delete(JobPortal_Models.Country.Country country)
        {
            try
            {
                return JobPortal_DAOs.Country.CountryDaos.Delete(country);
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
        public static DataTable GetData(string country)
        {
            try
            {
              return JobPortal_DAOs.Country.CountryDaos.GetData(country.ToString().Replace("'", "''"));
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
                return JobPortal_DAOs.Country.CountryDaos.GetAllData();
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
         return JobPortal_DAOs.Country.CountryDaos.GetSearchData(str.ToString().Replace("'", "''"));
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
                return JobPortal_DAOs.Country.CountryDaos.ReadData(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion Get Data
    }
}