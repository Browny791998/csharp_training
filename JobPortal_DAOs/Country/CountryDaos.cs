using System;
using System.Data;
using System.Data.SqlClient;

namespace JobPortal_DAOs.Country
{
    public class CountryDaos
    {
        #region Insert/Update/Delete

        /// <summary>
        /// Insert Data
        /// </summary>
        ///<returns></returns>
        public static bool Insert(JobPortal_Models.Country.Country country)
        {
            try
            {
                var arr = new object[2];
                arr[0] = country.Country_Name;
                bool num = Common.HelperDao.Insert(arr, "country", "tbl_country");
                if (num)
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }

        /// <summary>
        /// Update Data
        /// </summary>
        /// <returns></returns>
        public static bool Update(JobPortal_Models.Country.Country country)
        {
            try
            {
                var arr = new object[3];
                arr[0] = country.Country_Name;
                arr[1] = country.ID;
                Common.HelperDao.Update("Update tbl_country set country=@1 where ID=@2", arr);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Delete Data
        /// </summary>
        /// <returns></returns>
        public static bool Delete(JobPortal_Models.Country.Country country)
        {
            try
            {
                var arr = new object[2];
                arr[0] = country.ID;
                Common.HelperDao.Delete("Delete from tbl_country where id=@1", arr);
                return true;
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
        /// <returns></returns>
        public static DataTable GetData(string country)
        {
            try
            {
                return Common.HelperDao.GetData("Select country from tbl_country where country COLLATE Latin1_General_CS_AS='" + country + "'", CommandType.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get All Data
        /// </summary>
        /// <returns></returns>
        public static DataTable GetAllData()
        {
            try
            {
                return Common.HelperDao.GetData("Select tbl_country.id,tbl_country.country  from tbl_country", CommandType.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get Search Data
        /// </summary>
        /// <returns></returns>
        public static DataTable GetSearchData(string str)
        {
            try
            {
                if (str == "")
                {
                    return Common.HelperDao.GetData("Select tbl_country.id,tbl_country.country  from tbl_country", CommandType.Text);
                }
                else
                {
                    return Common.HelperDao.GetData("Select tbl_country.id,tbl_country.country  from tbl_country where country LIKE '%" + str + "%'", CommandType.Text);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        ///Read Data
        /// </summary>
        /// <returns></returns>
        public static SqlDataReader ReadData(int id)
        {
            try
            {
                return Common.HelperDao.ReadData("Select id,country from tbl_country where id='" + id + "'", CommandType.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion Get Data
    }
}