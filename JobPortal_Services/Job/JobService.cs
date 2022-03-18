﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal_Services.Job
{
    public class JobService
    {
        #region Insert/Update/Delete
        /// <summary>
        /// Insert Data
        /// </summary>
        public static bool Insert(JobPortal_Models.Job.Job job)
        {
            try
            {
                var mydt = new JobPortal_DAOs.Job.JobDao();
                return JobPortal_DAOs.Job.JobDao.Insert(job);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Update Data
        /// </summary>
        public static bool Update(JobPortal_Models.Job.Job job)
        {
            try
            {
                return JobPortal_DAOs.Job.JobDao.Update(job);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Delete Data
        /// </summary>
        public static bool Delete(JobPortal_Models.Job.Job job)
        {
            try
            {
                return JobPortal_DAOs.Job.JobDao.Delete(job);
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
                return JobPortal_DAOs.Job.JobDao.GetAllData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get Search Data
        /// </summary>
        public static DataTable GetSearchData(string str)
        {
            try
            {
                return JobPortal_DAOs.Job.JobDao.GetSearchData(str);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Read Data
        /// </summary>
        public static SqlDataReader ReadData(int id)
        {
            try
            {
                return JobPortal_DAOs.Job.JobDao.ReadData(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
