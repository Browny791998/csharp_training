using System;

namespace JobPortal_Models.User
{
    public class User
    {
        #region Local variable and Constant Declaration

        /// <summary>
        /// User Variables
        /// </summary>
        private int _id;

        private string _name;
        private string _email;
        private string _password;
        private string _role;
        private DateTime _created_at;
        private DateTime _updated_at;

        #endregion Local variable and Constant Declaration

        #region Constructor and Destructor

        /// <summary>
        ///Constructor and Destructor for User Variables
        /// </summary>
        public void UserData()
        {
            _id = 0;
            _name = String.Empty;
            _email = String.Empty;
            _password = string.Empty;
            _role = string.Empty;
        }

        public void UserData(int id, string name, string email, string password, string role)
        {
            _id = id;
            _name = name;
            _email = email;
            _password = password;
            _role = role;
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
        /// Gets or sets the <b>Name</b> attribute value.
        /// </summary>
        /// <value>The <b>Name</b> attribute value.</value>
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
        /// Gets or sets the <b>Email</b> attribute value.
        /// </summary>
        /// <value>The <b>Email</b> attribute value.</value>
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
        /// Gets or sets the <b>Password</b> attribute value.
        /// </summary>
        /// <value>The <b>Password</b> attribute value.</value>
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
        /// Gets or sets the <b>Role</b> attribute value.
        /// </summary>
        /// <value>The <b>Role</b> attribute value.</value>
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
        /// Gets or sets the <b>Created_at</b> attribute value.
        /// </summary>
        /// <value>The <b>Role</b> attribute value.</value>
        public DateTime Created_at
        {
            get
            {
                return _created_at;
            }
            set
            {
                _created_at = value;
            }
        }

        /// <summary>
        /// Gets or sets the <b>Updated_at</b> attribute value.
        /// </summary>
        /// <value>The <b>Role</b> attribute value.</value>
        public DateTime Updated_at
        {
            get
            {
                return _updated_at;
            }
            set
            {
                _updated_at = value;
            }
        }

        #endregion Properties Assigning and Retrieving
    }
}