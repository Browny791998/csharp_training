using System;

namespace JobPortal_Models.Position
{
    public class Position
    {
        #region Local variable and Constant Declaration

        /// <summary>
        /// Customer Variables
        /// </summary>
        private int _id;

        private string _position;

        #endregion Local variable and Constant Declaration

        #region Constructor and Destructor

        /// <summary>
        ///Constructor and Destructor for Customer Variables
        /// </summary>
        public void PostData()
        {
            _id = 0;
            _position = String.Empty;
        }

        public void PostData(int id, string position)
        {
            _id = id;
            _position = position;
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
        /// Gets or sets the <b>Position</b> attribute value.
        /// </summary>
        /// <value>The <b>Position</b> attribute value.</value>
        public string Position_Name
        {
            get
            {
                return _position;
            }
            set
            {
                _position = value;
            }
        }

        #endregion Properties Assigning and Retrieving
    }
}