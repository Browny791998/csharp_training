using System;

namespace JobPortal_Models.Jobnature
{
    public class Jobnature
    {
        #region Local variable and Constant Declaration

        /// <summary>
        /// Customer Variables
        /// </summary>
        private int _id;

        private string _job_nature;

        #endregion Local variable and Constant Declaration

        #region Constructor and Destructor

        /// <summary>
        ///Constructor and Destructor for Customer Variables
        /// </summary>
        public void PostData()
        {
            _id = 0;
            _job_nature = String.Empty;
        }

        public void PostData(int id, string jobnature)
        {
            _id = id;
            _job_nature = jobnature;
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
        /// Gets or sets the <b>Job_Nature</b> attribute value.
        /// </summary>
        /// <value>The <b>Job_Nature</b> attribute value.</value>
        public string Job_Nature
        {
            get
            {
                return _job_nature;
            }
            set
            {
                _job_nature = value;
            }
        }

        #endregion Properties Assigning and Retrieving
    }
}