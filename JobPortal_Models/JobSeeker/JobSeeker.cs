using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal_Models.JobSeeker
{
    public class JobSeeker
    {
        #region Local variable and Constant Declaration
        /// <summary>
        /// Movie Variables
        /// </summary>		
        private int _id;
        private string _name;
        private string _address;
        private int _mobile;
        private string _gender;
        private DateTime _dob;
        private string _skill;
        private string _experience;
        private string _degree;
        private string _degreename;
        private string _cvform;
        private string _profile;
        private string _email;
        private string _password;
        private string _detail;
        private string _role;
        private DateTime _createddate;
        private DateTime _updatedddate;
        #endregion

        #region Constructor and Destructor
        /// <summary>
        ///Constructor and Destructor for Movie Variables 
        /// </summary>
        public void PostJobSeeker()
        {
        _id = 0;
        _name=string.Empty;
        _address= string.Empty;
        _mobile=0;
        _gender=string.Empty;
        _dob=DateTime.Now;
        _skill=string.Empty;
        _experience=string.Empty;
        _degree=string.Empty;
        _degreename=string.Empty;
        _cvform=string.Empty;
        _profile=string.Empty;
        _email=string.Empty;
        _password=string.Empty;
        _detail=string.Empty;
        _role=string.Empty;
        _createddate=DateTime.Now;
        _updatedddate=DateTime.Now;
    }

        public void PostData(int id, string name,string address,int mobile,string gender,DateTime dob,string skill,string experience,string degree,string degreename,string cvform,string profile,string email,string password,string detail,string role,DateTime createddate,DateTime updateddate)
        {
            _id = id;
            _name = name;
            _address = address;
            _mobile = mobile;
            _gender = gender;
            _dob = dob;
            _skill = skill;
            _experience = experience;
            _degree = degree;
            _degreename = degreename;
            _cvform = cvform;
            _profile =profile;
            _email = email;
            _password = password;
            _detail = detail;
            _role = role;
            _createddate = createddate;
            _updatedddate = updateddate;
        }
        #endregion

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
        public int Mobile
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
        public string Gender
        {
            get
            {
                return _gender;
            }
            set
            {
                _gender = value;
            }
        }


        /// <summary>
        /// Gets or sets the <b>_movie</b> attribute value.
        /// </summary>
        /// <value>The <b>_movie</b> attribute value.</value>
        public DateTime DOB
        {
            get
            {
                return _dob;
            }
            set
            {
                _dob = value;
            }
        }

        /// <summary>
        /// Gets or sets the <b>_movie</b> attribute value.
        /// </summary>
        /// <value>The <b>_movie</b> attribute value.</value>
        public string Skill
        {
            get
            {
                return _skill;
            }
            set
            {
                _skill= value;
            }
        }

        /// <summary>
        /// Gets or sets the <b>_movie</b> attribute value.
        /// </summary>
        /// <value>The <b>_movie</b> attribute value.</value>
        public string Experience
        {
            get
            {
                return _experience;
            }
            set
            {
                _experience = value;
            }
        }

        /// <summary>
        /// Gets or sets the <b>_movie</b> attribute value.
        /// </summary>
        /// <value>The <b>_movie</b> attribute value.</value>
        public string Degree
        {
            get
            {
                return _degree;
            }
            set
            {
                _degree = value;
            }
        }

        /// <summary>
        /// Gets or sets the <b>_movie</b> attribute value.
        /// </summary>
        /// <value>The <b>_movie</b> attribute value.</value>
        public string DegreeName
        {
            get
            {
                return _degreename;
            }
            set
            {
                _degreename = value;
            }
        }

        /// <summary>
        /// Gets or sets the <b>_movie</b> attribute value.
        /// </summary>
        /// <value>The <b>_movie</b> attribute value.</value>
        public string CVForm
        {
            get
            {
                return _cvform;
            }
            set
            {
                _cvform = value;
            }
        }

        /// <summary>
        /// Gets or sets the <b>_movie</b> attribute value.
        /// </summary>
        /// <value>The <b>_movie</b> attribute value.</value>
        public string Profile
        {
            get
            {
                return _profile;
            }
            set
            {
                _profile = value;
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

        #endregion
    }
}
