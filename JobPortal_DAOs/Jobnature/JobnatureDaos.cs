using System;
using System.Data;
using System.Data.SqlClient;

namespace JobPortal_DAOs.Jobnature
{
    public class JobnatureDaos
    {
        #region Insert/Update/Delete

        /// <summary>
        /// Insert Data
        /// </summary>
        ///<returns></returns>
        public static bool Insert(JobPortal_Models.Jobnature.Jobnature jobnature)
        {
            try
            {
                var arr = new object[2];
                arr[0] = jobnature.Job_Nature;
                bool num = Common.HelperDao.Insert(arr, "job_nature", "tbl_jobnature");
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
        public static bool Update(JobPortal_Models.Jobnature.Jobnature jobnature)
        {
            try
            {
                var arr = new object[3];
                arr[0] = jobnature.Job_Nature;
                arr[1] = jobnature.ID;
                Common.HelperDao.Update("Update tbl_jobnature set job_nature=@1 where ID=@2", arr);
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
        public static bool Delete(JobPortal_Models.Jobnature.Jobnature jobnature)
        {
            try
            {
                var arr = new object[2];
                arr[0] = jobnature.ID;
                Common.HelperDao.Delete("Delete from tbl_jobnature where id=@1", arr);
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
        public static DataTable GetData(string job_nature)
        {
            try
            {
                return Common.HelperDao.GetData("Select job_nature from tbl_jobnature where job_nature COLLATE Latin1_General_CS_AS='" + job_nature + "'", CommandType.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get Data
        /// </summary>
        /// <returns></returns>
        public static DataTable GetUpdateData(string job_nature,int id)
        {
            try
            {
                return Common.HelperDao.GetData("Select job_nature from tbl_jobnature where job_nature ='" + job_nature + "' and id='"+id+"'", CommandType.Text);
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
                return Common.HelperDao.GetData("Select tbl_jobnature.id,tbl_jobnature.job_nature  from tbl_jobnature", CommandType.Text);
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
                    return Common.HelperDao.GetData("Select tbl_jobnature.id,tbl_jobnature.job_nature  from tbl_jobnature", CommandType.Text);
                }
                else
                {
                    return Common.HelperDao.GetData("Select tbl_jobnature.id,tbl_jobnature.job_nature  from tbl_jobnature where job_nature LIKE '%" + str + "%'", CommandType.Text);
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
                return Common.HelperDao.ReadData("Select id,job_nature from tbl_jobnature where id='" + id + "'", CommandType.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion Get Data
    }
}