﻿using System;
using System.Data;
using System.Data.SqlClient;

namespace JobPortal_Services.ResetPassword
{
    public class ResetPasswordService
    {
        #region Insert/Update/Delete

        /// <summary>
        /// Insert Data
        /// </summary>
        public static bool Insert(JobPortal_Models.ResetPassword.ResetPassword restpass)
        {
            try
            {
                var mydt = new JobPortal_DAOs.ResetPassword.ResetPasswordDao();
                return JobPortal_DAOs.ResetPassword.ResetPasswordDao.Insert(restpass);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Update Data
        /// </summary>
        public static bool Update(JobPortal_Models.ResetPassword.ResetPassword restpass)
        {
            try
            {
                return JobPortal_DAOs.ResetPassword.ResetPasswordDao.Update(restpass);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Delete Data
        /// </summary>
        public static bool Delete(JobPortal_Models.ResetPassword.ResetPassword restpass)
        {
            try
            {
                return JobPortal_DAOs.ResetPassword.ResetPasswordDao.Delete(restpass);
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
        public static DataTable GetData(string email)
        {
            try
            {
                return JobPortal_DAOs.ResetPassword.ResetPasswordDao.GetData(email);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get Data
        /// </summary>
        public static DataTable GetGUI(string gui)
        {
            try
            {
                return JobPortal_DAOs.ResetPassword.ResetPasswordDao.GetGUI(gui);
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
                return JobPortal_DAOs.ResetPassword.ResetPasswordDao.GetAllData();
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
                return JobPortal_DAOs.ResetPassword.ResetPasswordDao.ReadData(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion Get Data
    }
}