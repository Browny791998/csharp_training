using System;

namespace JobPortal_Models.Specialization
{
    public class Specialization
    {
        #region Local variable and Constant Declaration

        /// <summary>
        /// Specialization Variables
        /// </summary>
        private int _id;
        private string _specialization;

        #endregion Local variable and Constant Declaration

        #region Constructor and Destructor

        /// <summary>
        ///Constructor and Destructor for Specialization Variables
        /// </summary>
        public void PostData()
        {
            _id = 0;
            _specialization = String.Empty;
        }

        public void PostData(int id, string specialization)
        {
            _id = id;
            _specialization = specialization;
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
        /// Gets or sets the <b>_specialization</b> attribute value.
        /// </summary>
        /// <value>The <b>_specialization</b> attribute value.</value>
        public string Specialization_Name
        {
            get
            {
                return _specialization;
            }

            set
            {
                _specialization = value;
            }
        }

        #endregion Properties Assigning and Retrieving
    }
}