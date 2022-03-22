using System;
using System.Data;
using System.Data.SqlClient;

namespace JobPortal_DAOs.Skill
{
    public class SkillDaos
    {
        #region Insert/Update/Delete

        /// <summary>
        /// Insert Data
        /// </summary>
        ///<returns></returns>
        public static bool Insert(JobPortal_Models.Skill.Skill skill)
        {
            try
            {
                var arr = new object[2];
                arr[0] = skill.Skill_Name;
                bool num = Common.HelperDao.Insert(arr, "skill", "tbl_skill");
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
        public static bool Update(JobPortal_Models.Skill.Skill skill)
        {
            try
            {
                var arr = new object[3];
                arr[0] = skill.Skill_Name;
                arr[1] = skill.ID;
                Common.HelperDao.Update("Update tbl_skill set skill=@1 where ID=@2", arr);
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
        public static bool Delete(JobPortal_Models.Skill.Skill skill)
        {
            try
            {
                var arr = new object[2];
                arr[0] = skill.ID;
                Common.HelperDao.Delete("Delete from tbl_skill where id=@1", arr);
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
        public static DataTable GetData(string job_nature)
        {
            try
            {
                return Common.HelperDao.GetData("Select skill from tbl_skill where skill='" + job_nature + "'", CommandType.Text);
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
                return Common.HelperDao.GetData("Select tbl_skill.id,tbl_skill.skill  from tbl_skill", CommandType.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get Search Data
        /// </summary>
        /// <returns></returns>
        public static DataTable GetSearchData(string str)
        {
            try
            {
                if (str == "")
                {
                    return Common.HelperDao.GetData("Select tbl_skill.id,tbl_skill.skill  from tbl_skill", CommandType.Text);
                }
                else
                {
                    return Common.HelperDao.GetData("Select tbl_skill.id,tbl_skill.skill  from tbl_skill where skill LIKE '%" + str + "%'", CommandType.Text);
                }
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
                return Common.HelperDao.ReadData("Select id,skill from tbl_skill where id='" + id + "'", CommandType.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion Get Data
    }
}