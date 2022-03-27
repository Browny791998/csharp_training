using System;
using System.Data;
using System.Data.SqlClient;

namespace JobPortal_DAOs.JobSeeker
{
    public class JobSeekerDao
    {
        #region Insert/Update/Delete

        /// <summary>
        /// Insert Data
        /// </summary>
        ///<returns></returns>
        public static bool Insert(JobPortal_Models.JobSeeker.JobSeeker jobseeker)
        {
            try
            {
                var arr = new object[18];
                arr[0] = jobseeker.Name;
                arr[1] = jobseeker.Address;
                arr[2] = jobseeker.Mobile;
                arr[3] = jobseeker.Gender;
                arr[4] = jobseeker.DOB;
                arr[5] = jobseeker.Skill;
                arr[6] = jobseeker.Experience;
                arr[7] = jobseeker.Degree;
                arr[8] = jobseeker.DegreeName;
                arr[9] = jobseeker.CVForm;
                arr[10] = jobseeker.Profile;
                arr[11] = jobseeker.Email;
                arr[12] = jobseeker.Password;
                arr[13] = jobseeker.Detail;
                arr[14] = jobseeker.Role;
                arr[15] = jobseeker.CreatedDate;
                arr[16] = jobseeker.UpdatedDate;
                bool num = Common.HelperDao.Insert(arr, "name,address,mobile,gender,dob,skill,experience,degree,degree_name,cvform,profile,email,password,detail,role,created_date,updated_date", "tbl_jobseeker");
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
        public static bool Update(JobPortal_Models.JobSeeker.JobSeeker jobseeker)
        {
            try
            {
                var arr = new object[15];
                arr[0] = jobseeker.Name;
                arr[1] = jobseeker.Address;
                arr[2] = jobseeker.Mobile;
                arr[3] = jobseeker.Gender;
                arr[4] = jobseeker.DOB;
                arr[5] = jobseeker.Skill;
                arr[6] = jobseeker.Experience;
                arr[7] = jobseeker.Degree;
                arr[8] = jobseeker.DegreeName;
                arr[9] = jobseeker.CVForm;
                arr[10] = jobseeker.Profile;
                arr[11] = jobseeker.Detail;
                arr[12] = jobseeker.UpdatedDate;
                arr[13] = jobseeker.ID;
                Common.HelperDao.Update("Update tbl_jobseeker set name=@1,address=@2,mobile=@3,gender=@4,dob=@5,skill=@6,experience=@7,degree=@8,degree_name=@9,cvform=@10,profile=@11,detail=@12,updated_date=@13 where id=@14", arr);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Update Data
        /// <paramref name="post"/>
        /// </summary>
        /// <returns></returns>
        public static bool UpdatebyEmail(JobPortal_Models.JobSeeker.JobSeeker jobseeker)
        {
            try
            {
                var arr = new object[3];
                arr[0] = jobseeker.Password;
                arr[1] = jobseeker.Email;
                Common.HelperDao.Update("Update tbl_jobseeker set password=@1 where email=@2", arr);
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
        public static DataTable GetData(string email)
        {
            try
            {
                return Common.HelperDao.GetData("Select id,email,name,password,role from tbl_jobseeker where email COLLATE Latin1_General_CS_AS='" + email + "'", CommandType.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable SearchAllJobSeeker(string search)
        {
            try
            {
                return Common.HelperDao.GetData("Select id,name,address,mobile,gender,CONVERT(varchar,dob,3) as dob,skill,experience,degree,degree_name,cvform,profile,email,password,detail,role,active,created_date,updated_date from tbl_jobseeker where name LIKE '%" + search + "%'", CommandType.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable GetAllJobSeeker()
        {
            try
            {
                return Common.HelperDao.GetData("Select id,name,address,mobile,gender,CONVERT(varchar,dob,3) as dob,skill,experience,degree,degree_name,cvform,profile,email,password,detail,role,active,created_date,updated_date from tbl_jobseeker", CommandType.Text);
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
        public static DataTable GetAllData(int id)
        {
            try
            {
                return Common.HelperDao.GetData("Select id,name,address,mobile,gender,CONVERT(varchar,dob,3) as dob,skill,experience,degree,degree_name,cvform,profile,email,password,detail,role,active,created_date,updated_date from tbl_jobseeker Where id='" + id + "'", CommandType.Text);
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
        public static DataTable GetChartData()
        {
            try
            {
                return Common.HelperDao.GetData("Select Count(id) as JobSeeker,DATENAME(WEEKDAY,created_date) as Day from tbl_jobseeker Group By DATENAME(WEEKDAY,created_date)", CommandType.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Read Data
        /// </summary>
        /// <returns></returns>
        public static SqlDataReader ReadData(int id)
        {
            try
            {
                return Common.HelperDao.ReadData("Select id,name,address,mobile,gender,dob,skill,experience,degree,degree_name,cvform,profile,email,password,detail,role,active,created_date,updated_date from tbl_jobseeker where id='" + id + "'", CommandType.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion Get Data
    }
}