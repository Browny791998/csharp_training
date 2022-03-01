using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAOs.Customer
{
    public class CustomerDao
    {

        #region Insert/Update/Delete
        /// <summary>
        /// Insert Data
        /// </summary>
        /// <param name="post"></param>
        ///<returns></returns>
        public static bool Insert(Models.Customer.Customer customer)
        {
            try
            {
                var arr = new object[4];
                arr[0] = customer.SalutationID;
                arr[1] = customer.FullName;
                arr[2] = customer.Address;
                bool num = Common.HelperDao.Insert(arr, "salutation_id,full_name,address", "tbl_customer");
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
        public static bool Update(Models.Customer.Customer customer)
        {
            try
            {
                var arr = new object[5];
                arr[0] = customer.SalutationID;
                arr[1] = customer.FullName;
                arr[2] = customer.Address;
                arr[3] = customer.ID;
                Common.HelperDao.Update("Update tbl_customer set salutation_id=@1,full_name=@2,address=@3 where ID=@4", arr);
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
        public static bool Delete(Models.Customer.Customer customer)
        {
            try
            {
                var arr = new object[2];
                arr[0] = customer.ID;
                Common.HelperDao.Delete("Delete from tbl_customer where id=@1", arr);
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
                return Common.HelperDao.GetData("Select tbl_customer.id,tbl_customer.salutation_id,tbl_customer.full_name,tbl_customer.address,tbl_salutation.id,tbl_salutation.salutation  from tbl_customer  join tbl_salutation  on tbl_customer.salutation_id=tbl_salutation.id", CommandType.Text);
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
                    return Common.HelperDao.GetData("Select tbl_customer.id,tbl_customer.salutation_id,tbl_customer.full_name,tbl_customer.address,tbl_salutation.id,tbl_salutation.salutation  from tbl_customer  join tbl_salutation  on tbl_customer.salutation_id=tbl_salutation.id", CommandType.Text);
                }
                else
                {
                    return Common.HelperDao.GetData("Select tbl_customer.id,tbl_customer.salutation_id,tbl_customer.full_name,tbl_customer.address,tbl_salutation.id,tbl_salutation.salutation  from tbl_customer  join tbl_salutation  on tbl_customer.salutation_id=tbl_salutation.id where full_name ='" + str + "'", CommandType.Text);
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
                return Common.HelperDao.ReadData("Select id,salutation_id,full_name,address from tbl_customer where id='" + id + "'", CommandType.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}
