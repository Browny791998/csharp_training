using System;
using System.Data;
using System.Data.SqlClient;

namespace JobPortal_Services.Position
{
    public class PositionServices
    {
        #region Insert/Update/Delete

        /// <summary>
        /// Insert Data
        /// </summary>
        public static bool Insert(JobPortal_Models.Position.Position position)
        {
            try
            {
                var mydt = new JobPortal_DAOs.Position.PositionDaos();
                return JobPortal_DAOs.Position.PositionDaos.Insert(position);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Update Data
        /// </summary>
        public static bool Update(JobPortal_Models.Position.Position position)
        {
            try
            {
                return JobPortal_DAOs.Position.PositionDaos.Update(position);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Delete Data
        /// </summary>
        public static bool Delete(JobPortal_Models.Position.Position position)
        {
            try
            {
                return JobPortal_DAOs.Position.PositionDaos.Delete(position);
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
        public static DataTable GetData(string position)
        {
            try
            {
                return JobPortal_DAOs.Position.PositionDaos.GetData(position.ToString().Replace("'", "''"));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get Data
        /// </summary>
        public static DataTable GetAddData(string position)
        {
            try
            {
                return JobPortal_DAOs.Position.PositionDaos.GetAddData(position.ToString().Replace("'", "''"));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get Data
        /// </summary>
        public static DataTable GetUpdateData(string position,int id)
        {
            try
            {
                return JobPortal_DAOs.Position.PositionDaos.GetUpdateData(position.ToString().Replace("'", "''"),id);
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
                return JobPortal_DAOs.Position.PositionDaos.GetAllData();
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
                return JobPortal_DAOs.Position.PositionDaos.GetSearchData(str.ToString().Replace("'", "''"));
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
                return JobPortal_DAOs.Position.PositionDaos.ReadData(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion Get Data
    }
}