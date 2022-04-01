using System;
using System.Data;

namespace JobPortal_Services.User
{
    public class UserServices
    {
        #region Get Data

        /// <summary>
        /// Get Data
        /// </summary>
        public static DataTable GetData(string email, string password)
        {
            try
            {
                return JobPortal_DAOs.User.UserDaos.GetData(email, password);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get Data
        /// </summary>
        public static DataTable GetAllData()
        {
            try
            {
                return JobPortal_DAOs.User.UserDaos.GetAllData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion Get Data
    }
}