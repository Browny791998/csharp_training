﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace DAOs.Salutation
{
    public class SalutationDao
    {

        #region Insert/Update/Delete
        /// <summary>
        /// Insert Data
        /// </summary>
        /// <param name="post"></param>
        ///<returns></returns>
        public static bool Insert(Models.Salutation.Salutation salutation)
        {
            try
            {
                var arr = new object[2];
                arr[0] = salutation.SALUTATION;
               bool num = Common.HelperDao.Insert(arr, "salutation", "tbl_salutation");
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
        /// <paramref name="post"/>
        /// </summary>
        /// <returns></returns>
        public static bool Update(Models.Salutation.Salutation salutation)
        {
            try
            {
                var arr = new object[3];
                arr[0] = salutation.SALUTATION;
                arr[1] = salutation.ID;
                Common.HelperDao.Update("Update tbl_salutation set salutation=@1 where ID=@2", arr);
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
        /// <param name="post"></param>
        /// <returns></returns>
        public static bool Delete(Models.Salutation.Salutation salutation)
        {
            try
            {
                var arr = new object[2];
                arr[0] = salutation.ID;
                Common.HelperDao.Delete("Delete from tbl_salutation where ID=@1", arr);
                return true;
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
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static DataTable GetData(int id)
        {
            try
            {
                return Common.HelperDao.GetData("Select Post.ID,Post.Title,Post.Description,[User].Name,convert(varchar,  Post.Created_At, 111)As PostedDate from Post Inner Join [User] on Post.Created_User_ID =[User].Created_User_ID where Post.Status=1 and Post.Created_User_ID='" + id + "'", CommandType.Text);
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
                return Common.HelperDao.GetData("Select id,salutation from tbl_salutation", CommandType.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get Search Data
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static DataTable GetSearchData(string str)
        {
            try
            {
                if (str == "")
                {
                    return Common.HelperDao.GetData("Select id,salutation from tbl_salutation", CommandType.Text);
                }
                else
                {
                    return Common.HelperDao.GetData("Select id,salutation from tbl_salutation where salutation ='" + str + "'", CommandType.Text);
                }
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
                return Common.HelperDao.ReadData("Select id,salutation from tbl_salutation where id='" + id + "'", CommandType.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}
