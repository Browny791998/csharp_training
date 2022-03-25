using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal_DAOs.ResetPassword
{
    public class ResetPasswordDao
    {
        #region Insert/Update/Delete

        /// <summary>
        /// Insert Data
        /// </summary>
        ///<returns></returns>
        public static bool Insert(JobPortal_Models.ResetPassword.ResetPassword resetpass)
        {
            try
            {
                var arr = new object[4];
                arr[0] = resetpass.UID;
                arr[1] = resetpass.Email;
                arr[2] = resetpass.Requestdate;
                bool num = Common.HelperDao.Insert(arr, "uid,email,requestdatetime", "tbl_reset_password");
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
        public static bool Update(JobPortal_Models.ResetPassword.ResetPassword resetpass)
        {
            try
            {
                var arr = new object[5];
                arr[0] = resetpass.UID;
                arr[1] = resetpass.Email;
                arr[2] = resetpass.Requestdate;
                arr[3] = resetpass.ID;
                Common.HelperDao.Update("Update tbl_reset_password set uid=@1,email=@2,requestdatetime=@3 where ID=@4", arr);
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
        public static bool Delete(JobPortal_Models.ResetPassword.ResetPassword resetpass)
        {
            try
            {
                var arr = new object[2];
                arr[0] = resetpass.Email;
                Common.HelperDao.Delete("Delete from tbl_reset_password where email=@1", arr);
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
        public static DataTable GetData(string email)
        {
            try
            {
                return Common.HelperDao.GetData("Select id,uid,email,requestdatetime  where email='" + email + "'", CommandType.Text);
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
                return Common.HelperDao.GetData("Select id,uid,email,requestdatetime  from tbl_reset_password", CommandType.Text);
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
        public static DataTable GetGUI(string gui)
        {
            try
            {
                return Common.HelperDao.GetData("Select id,uid,email,requestdatetime  from tbl_reset_password Where uid ='"+gui+"'", CommandType.Text);
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
                return Common.HelperDao.ReadData("Select id,uid,email,requestdatetime where id='" + id + "'", CommandType.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion Get Data
    }
}
