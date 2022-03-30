using System;

namespace JobPortal_Models.Jobnature
{
    public class Jobnature
    {
        #region Local variable and Constant Declaration

        /// <summary>
        /// Jobnature Variables
        /// </summary>
        private int _id;
        private string _job_nature;

        #endregion Local variable and Constant Declaration

        #region Constructor and Destructor

        /// <summary>
        ///Constructor and Destructor for Jobnature Variables
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
        /// Gets or sets the <b>_id</b> attribute value.
        /// </summary>
        /// <value>The <b>_id</b> attribute value.</value>
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
        /// Gets or sets the <b>_job_nature</b> attribute value.
        /// </summary>
        /// <value>The <b>_job_nature</b> attribute value.</value>
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