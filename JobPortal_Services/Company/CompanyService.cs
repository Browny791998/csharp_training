﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal_Services.Company
{
   public class CompanyService
    {
        #region Insert/Update/Delete
        /// <summary>
        /// Insert Data
        /// </summary>
        public static bool Insert(JobPortal_Models.Company.Company company)
        {
            try
            {
                var mydt = new JobPortal_DAOs.Company.CompanyDao();
                return JobPortal_DAOs.Company.CompanyDao.Insert(company);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Update Data
        /// </summary>
        public static bool Update(JobPortal_Models.Company.Company company)
        {
            try
            {
                return JobPortal_DAOs.Company.CompanyDao.Update(company);
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
        public static DataTable GetData(string email)
        {
            try
            {
                return JobPortal_DAOs.Company.CompanyDao.GetData(email);
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
                return JobPortal_DAOs.Company.CompanyDao.GetAllData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get Search Data
        /// </summary>
        //public static DataTable GetSearchData(string str)
        //{
        //    try
        //    {
        //        return DAOs.Movie.MovieDao.GetSearchData(str);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        /// <summary>
        /// Read Data
        /// </summary>
        public static SqlDataReader ReadData(int id)
        {
            try
            {
                return JobPortal_DAOs.Company.CompanyDao.ReadData(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
