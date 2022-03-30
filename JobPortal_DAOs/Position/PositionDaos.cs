using System;
using System.Data;
using System.Data.SqlClient;

namespace JobPortal_DAOs.Position
{
    public class PositionDaos
    {
        #region Insert/Update/Delete

        /// <summary>
        /// Insert Data
        /// </summary>
        ///<returns></returns>
        public static bool Insert(JobPortal_Models.Position.Position position)
        {
            try
            {
                var arr = new object[2];
                arr[0] = position.Position_Name;
                bool num = Common.HelperDao.Insert(arr, "position", "tbl_position");
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
        public static bool Update(JobPortal_Models.Position.Position position)
        {
            try
            {
                var arr = new object[3];
                arr[0] = position.ID;
                arr[1] = position.Position_Name;
                Common.HelperDao.Update("Update tbl_position set position=@2 where ID=@1", arr);
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
        public static bool Delete(JobPortal_Models.Position.Position position)
        {
            try
            {
                var arr = new object[2];
                arr[0] = position.ID;
                Common.HelperDao.Delete("Delete from tbl_position where id=@1", arr);
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
                return Common.HelperDao.GetData("Select position from tbl_position where position COLLATE Latin1_General_CS_AS='" + job_nature + "'", CommandType.Text);
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
        public static DataTable GetUpdateData(string position, int id)
        {
            try
            {
                return Common.HelperDao.GetData("Select position from tbl_position where position='" + position + "' and id='" + id + "'", CommandType.Text);
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
                return Common.HelperDao.GetData("Select tbl_position.id,tbl_position.position  from tbl_position", CommandType.Text);
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
                    return Common.HelperDao.GetData("Select tbl_position.id,tbl_position.position  from tbl_position", CommandType.Text);
                }
                else
                {
                    return Common.HelperDao.GetData("Select tbl_position.id,tbl_position.position  from tbl_position where position LIKE '%" + str + "%'", CommandType.Text);
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
                return Common.HelperDao.ReadData("Select id,position from tbl_position where id='" + id + "'", CommandType.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion Get Data
    }
}