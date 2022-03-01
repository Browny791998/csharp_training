using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAOs.Movie
{
    public class MovieDao
    {
        #region Insert/Update/Delete
        /// <summary>
        /// Insert Data
        /// </summary>
        /// <param name="post"></param>
        ///<returns></returns>
        public static bool Insert(Models.Movie.Movie movie)
        {
            try
            {
                var arr = new object[2];
                arr[0] = movie.MOVIE;
                bool num = Common.HelperDao.Insert(arr, "movie", "tbl_movie");
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
        public static bool Update(Models.Movie.Movie movie)
        {
            try
            {
                var arr = new object[3];
                arr[0] = movie.MOVIE;
                arr[1] = movie.ID;
                Common.HelperDao.Update("Update tbl_movie set movie=@1 where ID=@2", arr);
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
        public static bool Delete(Models.Movie.Movie movie)
        {
            try
            {
                var arr = new object[2];
                arr[0] = movie.ID;
                Common.HelperDao.Delete("Delete from tbl_movie where ID=@1", arr);
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
                return Common.HelperDao.GetData("Select id,movie from tbl_movie", CommandType.Text);
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
                    return Common.HelperDao.GetData("Select id,movie from tbl_movie", CommandType.Text);
                }
                else
                {
                    return Common.HelperDao.GetData("Select id,movie from tbl_movie where movie ='" + str + "'", CommandType.Text);
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
                return Common.HelperDao.ReadData("Select id,movie from tbl_movie where id='" + id + "'", CommandType.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}
