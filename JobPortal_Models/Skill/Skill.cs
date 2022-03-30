using System;

namespace JobPortal_Models.Skill
{
    public class Skill
    {
        #region Local variable and Constant Declaration

        /// <summary>
        /// Skill Variables
        /// </summary>
        private int _id;
        private string _skill;

        #endregion Local variable and Constant Declaration

        #region Constructor and Destructor

        /// <summary>
        ///Constructor and Destructor for Skill Variables
        /// </summary>
        public void PostData()
        {
            _id = 0;
            _skill = String.Empty;
        }

        public void PostData(int id, string skill)
        {
            _id = id;
            _skill = skill;
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
        /// Gets or sets the <b>_skill</b> attribute value.
        /// </summary>
        /// <value>The <b>_skill</b> attribute value.</value>
        public string Skill_Name
        {
            get
            {
                return _skill;
            }
            set
            {
                _skill = value;
            }
        }

        #endregion Properties Assigning and Retrieving
    }
}