using System;
using System.Data;
using System.Data.SqlClient;

namespace JobPortal_Services.Skill
{
    public class SkillServices
    {
        #region Insert/Update/Delete

        /// <summary>
        /// Insert Data
        /// </summary>
        public static bool Insert(JobPortal_Models.Skill.Skill skill)
        {
            try
            {
                var mydt = new JobPortal_DAOs.Skill.SkillDaos();
                return JobPortal_DAOs.Skill.SkillDaos.Insert(skill);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Update Data
        /// </summary>
        public static bool Update(JobPortal_Models.Skill.Skill skill)
        {
            try
            {
                return JobPortal_DAOs.Skill.SkillDaos.Update(skill);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Delete Data
        /// </summary>
        public static bool Delete(JobPortal_Models.Skill.Skill skill)
        {
            try
            {
                return JobPortal_DAOs.Skill.SkillDaos.Delete(skill);
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
        public static DataTable GetData(string skill)
        {
            try
            {
                return JobPortal_DAOs.Skill.SkillDaos.GetData(skill.ToString().Replace("'", "''"));
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
                return JobPortal_DAOs.Skill.SkillDaos.GetAllData();
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
                return JobPortal_DAOs.Skill.SkillDaos.GetSearchData(str.ToString().Replace("'", "''"));
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
                return JobPortal_DAOs.Skill.SkillDaos.ReadData(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion Get Data
    }
}