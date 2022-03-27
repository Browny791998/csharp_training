using System;

namespace JobPortal_Models.JobOffer
{
    public class JobOffer
    {
        #region Local variable and Constant Declaration

        /// <summary>
        /// Movie Variables
        /// </summary>
        private int _id;

        private int _jobseekerid;
        private int _companyid;
        private int _jobid;
        private DateTime _applieddate;
        private Int16 _isaccept;

        #endregion Local variable and Constant Declaration

        #region Constructor and Destructor

        /// <summary>
        ///Constructor and Destructor for Movie Variables
        /// </summary>
        public void PostJobOffer()
        {
            _id = 0;
            _jobseekerid = 0;
            _companyid = 0;
            _jobid = 0;
            _applieddate = DateTime.Now;
            _isaccept = 0;
        }

        public void PostData(int id, int jobseekerID, int companyID, int jobID, DateTime applieddate, Int16 isaccept)
        {
            _id = id;
            _jobseekerid = jobseekerID;
            _companyid = companyID;
            _jobid = jobID;
            _applieddate = applieddate;
            _isaccept = isaccept;
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
        public int JobSeekerID
        {
            get
            {
                return _jobseekerid;
            }
            set
            {
                _jobseekerid = value;
            }
        }

        /// <summary>
        /// Gets or sets the <b>_movie</b> attribute value.
        /// </summary>
        /// <value>The <b>_movie</b> attribute value.</value>
        public int CompanyID
        {
            get
            {
                return _companyid;
            }
            set
            {
                _companyid = value;
            }
        }

        /// <summary>
        /// Gets or sets the <b>_movie</b> attribute value.
        /// </summary>
        /// <value>The <b>_movie</b> attribute value.</value>
        public int JobID
        {
            get
            {
                return _jobid;
            }
            set
            {
                _jobid = value;
            }
        }

        /// <summary>
        /// Gets or sets the <b>_movie</b> attribute value.
        /// </summary>
        /// <value>The <b>_movie</b> attribute value.</value>
        public DateTime AppliedDate
        {
            get
            {
                return _applieddate;
            }
            set
            {
                _applieddate = value;
            }
        }

        /// <summary>
        /// Gets or sets the <b>_movie</b> attribute value.
        /// </summary>
        /// <value>The <b>_movie</b> attribute value.</value>
        public Int16 IsAccept
        {
            get
            {
                return _isaccept;
            }
            set
            {
                _isaccept = value;
            }
        }

        #endregion Properties Assigning and Retrieving
    }
}