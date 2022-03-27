using System;

namespace JobPortal_Models.Company
{
    public class Company
    {
        #region Local variable and Constant Declaration

        /// <summary>
        /// Movie Variables
        /// </summary>
        private int _id;

        private string _name;
        private int _countryid;
        private string _address;
        private string _contactperson;
        private Int64 _mobile;
        private string _email;
        private string _password;
        private string _website;
        private string _role;
        private string _detail;
        private DateTime _createddate;
        private DateTime _updatedddate;

        #endregion Local variable and Constant Declaration

        #region Constructor and Destructor

        /// <summary>
        ///Constructor and Destructor for Movie Variables
        /// </summary>
        public void PostCompany()
        {
            _id = 0;
            _name = string.Empty;
            _countryid = 0;
            _address = string.Empty;
            _contactperson = string.Empty;
            _mobile = 0;
            _email = string.Empty;
            _password = string.Empty;
            _website = string.Empty;
            _role = string.Empty;
            _detail = string.Empty;
            _createddate = DateTime.Now;
            _updatedddate = DateTime.Now;
        }

        public void PostData(int id, string name, int country_id, string address, string contact_person, Int64 mobile, string email, string password, string website, string role, string detail, DateTime createddate, DateTime updateddate)
        {
            _id = id;
            _name = name;
            _countryid = country_id;
            _address = address;
            _contactperson = contact_person;
            _mobile = mobile;
            _email = email;
            _password = password;
            _website = website;
            _role = role;
            _detail = detail;
            _createddate = createddate;
            _updatedddate = updateddate;
        }

        #endregion Constructor and Destructor

        #region Properties Assigning and Retrieving

        /// <summary>
        /// Gets or sets the <b>_ID</b> attribute value.
        /// </summary>
        /// <value>The <b>_ID</b> attribute value.</value>
        public int ID
        {
            get
            {
                return _id;
            }

            set
            {
                _id = value;
            }
        }

        /// <summary>
        /// Gets or sets the <b>_movie</b> attribute value.
        /// </summary>
        /// <value>The <b>_movie</b> attribute value.</value>
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        /// <summary>
        /// Gets or sets the <b>_movie</b> attribute value.
        /// </summary>
        /// <value>The <b>_movie</b> attribute value.</value>
        public int CountryID
        {
            get
            {
                return _countryid;
            }
            set
            {
                _countryid = value;
            }
        }

        /// <summary>
        /// Gets or sets the <b>_movie</b> attribute value.
        /// </summary>
        /// <value>The <b>_movie</b> attribute value.</value>
        public string Address
        {
            get
            {
                return _address;
            }
            set
            {
                _address = value;
            }
        }

        /// <summary>
        /// Gets or sets the <b>_movie</b> attribute value.
        /// </summary>
        /// <value>The <b>_movie</b> attribute value.</value>
        public string ContactPerson
        {
            get
            {
                return _contactperson;
            }
            set
            {
                _contactperson = value;
            }
        }

        /// <summary>
        /// Gets or sets the <b>_movie</b> attribute value.
        /// </summary>
        /// <value>The <b>_movie</b> attribute value.</value>
        public Int64 Mobile
        {
            get
            {
                return _mobile;
            }
            set
            {
                _mobile = value;
            }
        }

        /// <summary>
        /// Gets or sets the <b>_movie</b> attribute value.
        /// </summary>
        /// <value>The <b>_movie</b> attribute value.</value>
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
            }
        }

        /// <summary>
        /// Gets or sets the <b>_movie</b> attribute value.
        /// </summary>
        /// <value>The <b>_movie</b> attribute value.</value>
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
            }
        }

        /// <summary>
        /// Gets or sets the <b>_movie</b> attribute value.
        /// </summary>
        /// <value>The <b>_movie</b> attribute value.</value>
        public string Website
        {
            get
            {
                return _website;
            }
            set
            {
                _website = value;
            }
        }

        /// <summary>
        /// Gets or sets the <b>_movie</b> attribute value.
        /// </summary>
        /// <value>The <b>_movie</b> attribute value.</value>
        public string Role
        {
            get
            {
                return _role;
            }
            set
            {
                _role = value;
            }
        }

        /// <summary>
        /// Gets or sets the <b>_movie</b> attribute value.
        /// </summary>
        /// <value>The <b>_movie</b> attribute value.</value>
        public string Detail
        {
            get
            {
                return _detail;
            }
            set
            {
                _detail = value;
            }
        }

        /// <summary>
        /// Gets or sets the <b>_movie</b> attribute value.
        /// </summary>
        /// <value>The <b>_movie</b> attribute value.</value>
        public DateTime CreatedDate
        {
            get
            {
                return _createddate;
            }
            set
            {
                _createddate = value;
            }
        }

        /// <summary>
        /// Gets or sets the <b>_movie</b> attribute value.
        /// </summary>
        /// <value>The <b>_movie</b> attribute value.</value>
        public DateTime UpdatedDate
        {
            get
            {
                return _updatedddate;
            }
            set
            {
                _updatedddate = value;
            }
        }

        #endregion Properties Assigning and Retrieving
    }
}