using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
namespace Services.Customer
{
    public class CustomerService
    {
       
        #region Insert/Update/Delete
        /// <summary>
        /// Insert Data
        /// <param name="post"></param>
        /// </summary>
        public static bool Insert(Models.Customer.Customer customer)
        {
            try
            {
                var mydt = new DAOs.Salutation.SalutationDao();
                return DAOs.Customer.CustomerDao.Insert(customer);
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
        public static bool Update(Models.Customer.Customer customer)
        {
            try
            {
                return DAOs.Customer.CustomerDao.Update(customer);
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
        public static bool Delete(Models.Customer.Customer customer)
        {
            try
            {
                return DAOs.Customer.CustomerDao.Delete(customer);
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
                return DAOs.Customer.CustomerDao.GetAllData();
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
                return DAOs.Customer.CustomerDao.GetSearchData(str);
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
                return DAOs.Customer.CustomerDao.ReadData(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
