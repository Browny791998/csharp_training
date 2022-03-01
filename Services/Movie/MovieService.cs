using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Movie
{
    public class MovieService
    {
        #region Insert/Update/Delete
        /// <summary>
        /// Insert Data
        /// <param name="movie"></param>
        /// </summary>
        public static bool Insert(Models.Movie.Movie movie)
        {
            try
            {
                var mydt = new DAOs.Movie.MovieDao();
                return DAOs.Movie.MovieDao.Insert(movie);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Update Data
        /// <param name="movie"></param>
        /// </summary>
        public static bool Update(Models.Movie.Movie movie)
        {
            try
            {
                return DAOs.Movie.MovieDao.Update(movie);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Delete Data
        /// <param name="customer"></param>
        /// </summary>
        public static bool Delete(Models.Movie.Movie movie)
        {
            try
            {
                return DAOs.Movie.MovieDao.Delete(movie);
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
                return DAOs.Movie.MovieDao.GetData(id);
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
                return DAOs.Movie.MovieDao.GetAllData();
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
                return DAOs.Movie.MovieDao.GetSearchData(str);
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
                return DAOs.Movie.MovieDao.ReadData(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
