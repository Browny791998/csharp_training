using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
namespace Services.Salutation
{
    public class SalutationService
    {

        #region Insert/Update/Delete
        /// <summary>
        /// Insert Data
        /// <param name="post"></param>
        /// </summary>
        public static bool Insert(Models.Salutation.Salutation salutation)
        {
            try
            {
                var mydt = new DAOs.Salutation.SalutationDao();
                return DAOs.Salutation.SalutationDao.Insert(salutation);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Update Data
        /// <param name="post"></param>
        /// </summary>
        public static bool Update(Models.Salutation.Salutation salutation)
        {
            try
            {
                return DAOs.Salutation.SalutationDao.Update(salutation);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Delete Data
        /// <param name="post"></param>
        /// </summary>
        public static bool Delete(Models.Salutation.Salutation salutation)
        {
            try
            {
                return DAOs.Salutation.SalutationDao.Delete(salutation);
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
        /// <param name="id"></param>
        /// </summary>
        public static DataTable GetData(int id)
        {
            try
            {
                return DAOs.Salutation.SalutationDao.GetData(id);
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
                return DAOs.Salutation.SalutationDao.GetAllData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get Search Data
        /// <param name="str"></param>
        /// </summary>
        public static DataTable GetSearchData(string str)
        {
            try
            {
                return DAOs.Salutation.SalutationDao.GetSearchData(str);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static SqlDataReader ReadData(int id)
        {
            try
            {
                return DAOs.Salutation.SalutationDao.ReadData(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
