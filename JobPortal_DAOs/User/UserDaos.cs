using System;
using System.Data;

namespace JobPortal_DAOs.User
{
    public class UserDaos
    {
        #region Insert/Update/Delete

        /// <summary>
        /// Insert Data
        /// </summary>
        ///<returns></returns>
        public static bool Insert(JobPortal_Models.User.User user)
        {
            try
            {
                var arr = new object[4];
                arr[0] = user.Email;
                arr[1] = user.Password;
                arr[2] = user.Role;
                bool num = Common.HelperDao.Insert(arr, "email,password,role", "tbl_user");
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
        public static bool Update(JobPortal_Models.User.User user)
        {
            try
            {
                var arr = new object[8];
                arr[0] = user.ID;
                arr[1] = user.Name;
                arr[2] = user.Email;
                arr[3] = user.Password;
                arr[4] = user.Role;
                arr[5] = user.Created_at;
                arr[6] = user.Updated_at;
                Common.HelperDao.Update("Update tbl_user set id=@1,name=@2,email=@3,password=@4,role=@5,created_at=@6,updated_at=@7 where ID=@8", arr);
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
        public static bool Delete(JobPortal_Models.User.User user)
        {
            try
            {
                var arr = new object[2];
                arr[0] = user.ID;
                Common.HelperDao.Delete("Delete from tbl_user where id=@1", arr);
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
        public static DataTable GetData(string email, string password)
        {
            try
            {
                return Common.HelperDao.GetData("Select id,name,email,password,role from tbl_user where  email='" + email + "' and password ='" + password + "'", CommandType.Text);
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
        public static DataTable GetAllData()
        {
            try
            {
                return Common.HelperDao.GetData("Select id,name,email,password,role from tbl_user", CommandType.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion Get Data
    }
}