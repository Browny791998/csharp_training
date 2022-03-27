using System;
using System.Data;
using System.Data.SqlClient;

namespace JobPortal_DAOs.Specialization
{
    public class SpecializationDaos
    {
        #region Insert/Update/Delete

        /// <summary>
        /// Insert Data
        /// </summary>
        ///<returns></returns>
        public static bool Insert(JobPortal_Models.Specialization.Specialization specialization)
        {
            try
            {
                var arr = new object[2];
                arr[0] = specialization.Specialization_Name;
                bool num = Common.HelperDao.Insert(arr, "specialization", "tbl_specialization");
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
        public static bool Update(JobPortal_Models.Specialization.Specialization specialization)
        {
            try
            {
                var arr = new object[3];
                arr[0] = specialization.Specialization_Name;
                arr[1] = specialization.ID;
                Common.HelperDao.Update("Update tbl_specialization set specialization=@1 where ID=@2", arr);
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
        public static bool Delete(JobPortal_Models.Specialization.Specialization specialization)
        {
            try
            {
                var arr = new object[2];
                arr[0] = specialization.ID;
                Common.HelperDao.Delete("Delete from tbl_specialization where id=@1", arr);
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
        public static DataTable GetData(string specialization)
        {
            try
            {
                return Common.HelperDao.GetData("Select specialization from tbl_specialization where specialization COLLATE Latin1_General_CS_AS='" + specialization + "'", CommandType.Text);
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
                return Common.HelperDao.GetData("Select tbl_specialization.id,tbl_specialization.specialization  from tbl_specialization", CommandType.Text);
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
                    return Common.HelperDao.GetData("Select tbl_specialization.id,tbl_specialization.specilization  from tbl_specialization", CommandType.Text);
                }
                else
                {
                    return Common.HelperDao.GetData("Select tbl_specialization.id,tbl_specialization.specialization  from tbl_specialization where specialization LIKE '%" + str + "%'", CommandType.Text);
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
                return Common.HelperDao.ReadData("Select id,specialization from tbl_specialization where id='" + id + "'", CommandType.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion Get Data
    }
}