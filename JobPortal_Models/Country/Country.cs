using System;

namespace JobPortal_Models.Country
{
    public class Country
    {
        #region Local variable and Constant Declaration

        /// <summary>
        /// Cuountry Variables
        /// </summary>
        private int _id;
        private string _country;

        #endregion Local variable and Constant Declaration

        #region Constructor and Destructor

        /// <summary>
        ///Constructor and Destructor for Country Variables
        /// </summary>
        public void PostData()
        {
            _id = 0;
            _country = String.Empty;
        }

        public void PostData(int id, string country)
        {
            _id = id;
            _country = country;
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
        /// Gets or sets the <b>_country</b> attribute value.
        /// </summary>
        /// <value>The <b>_country</b> attribute value.</value>
        public string Country_Name
        {
            get
            {
                return _country;
            }
            set
            {
                _country = value;
            }
        }

        #endregion Properties Assigning and Retrieving
    }
}