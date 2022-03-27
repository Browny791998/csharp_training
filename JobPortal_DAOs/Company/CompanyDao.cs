using System;
using System.Data;
using System.Data.SqlClient;

namespace JobPortal_DAOs.Company
{
    public class CompanyDao
    {
        #region Insert/Update/Delete

        /// <summary>
        /// Insert Data
        /// </summary>
        ///<returns></returns>
        public static bool Insert(JobPortal_Models.Company.Company company)
        {
            try
            {
                var arr = new object[13];
                arr[0] = company.Name;
                arr[1] = company.CountryID;
                arr[2] = company.Address;
                arr[3] = company.ContactPerson;
                arr[4] = company.Mobile;
                arr[5] = company.Email;
                arr[6] = company.Password;
                arr[7] = company.Website;
                arr[8] = company.Role;
                arr[9] = company.Detail;
                arr[10] = company.CreatedDate;
                arr[11] = company.UpdatedDate;
                bool num = Common.HelperDao.Insert(arr, "name,country_id,address,contact_person,mobile,email,password,website,role,detail,created_at,updated_at", "tbl_company");
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
        public static bool Update(JobPortal_Models.Company.Company company)
        {
            try
            {
                var arr = new object[10];
                arr[0] = company.Name;
                arr[1] = company.CountryID;
                arr[2] = company.Address;
                arr[3] = company.ContactPerson;
                arr[4] = company.Mobile;
                arr[5] = company.Website;
                arr[6] = company.Detail;
                arr[7] = company.UpdatedDate;
                arr[8] = company.ID;
                Common.HelperDao.Update("Update tbl_company set name=@1,country_id=@2,address=@3,contact_person=@4,mobile=@5,website=@6,detail=@7,updated_at=@8 where id=@9", arr);
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
        public static bool UpdatebyEmail(JobPortal_Models.Company.Company company)
        {
            try
            {
                var arr = new object[3];
                arr[0] = company.Password;
                arr[1] = company.Email;
                Common.HelperDao.Update("Update tbl_company set password=@1 where email=@2", arr);
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
                return Common.HelperDao.GetData("Select id,name,email,password,role from tbl_company where email COLLATE Latin1_General_CS_AS='" + email + "'", CommandType.Text);
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
        public static DataTable GetCompanyAllData()
        {
            try
            {
                return Common.HelperDao.GetData("Select tbl_company.id,name,country_id,country,address,contact_person,mobile,email,password,website,role,detail,active,created_at,updated_at from tbl_company join tbl_country on tbl_country.id=tbl_company.country_id", CommandType.Text);
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
                    return Common.HelperDao.GetData("Select tbl_company.id,name,country_id,country,address,contact_person,mobile,email,password,website,role,detail,active,created_at,updated_at from tbl_company join tbl_country on tbl_country.id=tbl_company.country_id", CommandType.Text);
                }
                else
                {
                    return Common.HelperDao.GetData("Select tbl_company.id,name,country_id,country,address,contact_person,mobile,email,password,website,role,detail,active,created_at,updated_at from tbl_company join tbl_country on tbl_country.id=tbl_company.country_id where name LIKE '%" + str + "%'", CommandType.Text);
                }
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
                return Common.HelperDao.GetData("Select tbl_company.id,name,country_id,country,address,contact_person,mobile,email,password,website,role,detail,active,created_at,updated_at from tbl_company join tbl_country on tbl_country.id=tbl_company.country_id Where tbl_company.id='" + id + "'", CommandType.Text);
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
                return Common.HelperDao.GetData("Select Count(id) as Company,DATENAME(WEEKDAY,created_at) as Day from tbl_company Group By DATENAME(WEEKDAY, created_at) ", CommandType.Text);
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
                return Common.HelperDao.ReadData("Select tbl_company.id,name,country_id,country,address,contact_person,mobile,email,password,website,role,detail,active,created_at,updated_at from tbl_company join tbl_country on tbl_country.id=tbl_company.country_id where tbl_company.id='" + id + "'", CommandType.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion Get Data
    }
}