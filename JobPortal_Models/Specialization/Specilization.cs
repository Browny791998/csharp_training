using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal_Models.Specialization
{
    public class Specialization
    {
        #region Local variable and Constant Declaration

        /// <summary>
        /// Customer Variables
        /// </summary>
        private int _id;

        private string _specialization;

        #endregion Local variable and Constant Declaration

        #region Constructor and Destructor

        /// <summary>
        ///Constructor and Destructor for Customer Variables
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
        /// Gets or sets the <b>Specification</b> attribute value.
        /// </summary>
        /// <value>The <b>Specification</b> attribute value.</value>
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