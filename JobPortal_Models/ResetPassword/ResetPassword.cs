using System;

namespace JobPortal_Models.ResetPassword
{
    public class ResetPassword
    {
        #region Local variable and Constant Declaration

        /// <summary>
        /// Reset Password Variables
        /// </summary>
        private int _id;
        private string _uid;
        private string _email;
        private DateTime _requestdate;

        #endregion Local variable and Constant Declaration

        #region Constructor and Destructor

        /// <summary>
        ///Constructor and Destructor for Reset Password Variables
        /// </summary>
        public void PostData()
        {
            _id = 0;
            _uid = string.Empty;
            _email = string.Empty;
            _requestdate = DateTime.Now;
        }

        public void PostData(int id, string uid, string email, DateTime requestdate)
        {
            _id = id;
            _uid = uid;
            _email = email;
            _requestdate = requestdate;
        }

        #endregion Constructor and Destructor

        #region Properties Assigning and Retrieving

        /// <summary>
        /// Gets or sets the <b> _id</b> attribute value.
        /// </summary>
        /// <value>The <b> _id</b> attribute value.</value>
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
        /// Gets or sets the <b>_uid</b> attribute value.
        /// </summary>
        /// <value>The <b>_uid</b> attribute value.</value>
        public string UID
        {
            get
            {
                return _uid;
            }
            set
            {
                _uid = value;
            }
        }

        /// <summary>
        /// Gets or sets the <b>_email</b> attribute value.
        /// </summary>
        /// <value>The <b>_email</b> attribute value.</value>
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
        /// Gets or sets the <b>_requestdate</b> attribute value.
        /// </summary>
        /// <value>The <b>_requestdate</b> attribute value.</value>
        public DateTime Requestdate
        {
            get
            {
                return _requestdate;
            }
            set
            {
                _requestdate = value;
            }
        }

        #endregion Properties Assigning and Retrieving
    }
}