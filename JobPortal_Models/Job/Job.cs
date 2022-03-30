﻿using System;

namespace JobPortal_Models.Job
{
    public class Job
    {
        #region Local variable and Constant Declaration

        /// <summary>
        /// Job Variables
        /// </summary>
        private int _id;
        private string _title;
        private string _degree;
        private string _skill;
        private string _experience;
        private int _vacancy;
        private int _companyid;
        private int _positionid;
        private int _jobnatureid;
        private int _specializationid;
        private int _salary;
        private string _detail;
        private Int16 _active;
        private DateTime _createddate;
        private DateTime _updatedddate;

        #endregion Local variable and Constant Declaration

        #region Constructor and Destructor

        /// <summary>
        ///Constructor and Destructor for Job Variables
        /// </summary>
        public void PostCompany()
        {
            _id = 0;
            _title = string.Empty;
            _degree = string.Empty;
            _skill = string.Empty;
            _experience = string.Empty;
            _vacancy = 0;
            _companyid = 0;
            _positionid = 0;
            _jobnatureid = 0;
            _specializationid = 0;
            _salary = 0;
            _detail = string.Empty;
            _active = 0;
            _createddate = DateTime.Now;
            _updatedddate = DateTime.Now;
        }

        public void PostData(int id, string title, string degree, string skill, string experience, int vacancy, int company_id, int position_id, int jobnature_id, int specialization_id, int salary, string detail, Int16 active, DateTime createddate, DateTime updateddate)
        {
            _id = id;
            _title = title;
            _degree = degree;
            _skill = skill;
            _experience = experience;
            _vacancy = vacancy;
            _companyid = company_id;
            _positionid = position_id;
            _jobnatureid = jobnature_id;
            _specializationid = specialization_id;
            _salary = salary;
            _detail = detail;
            _createddate = createddate;
            _updatedddate = updateddate;
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
        /// Gets or sets the <b>_title</b> attribute value.
        /// </summary>
        /// <value>The <b>_title</b> attribute value.</value>
        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                _title = value;
            }
        }

        /// <summary>
        /// Gets or sets the <b>_degree</b> attribute value.
        /// </summary>
        /// <value>The <b>_degree</b> attribute value.</value>
        public string Degree
        {
            get
            {
                return _degree;
            }
            set
            {
                _degree = value;
            }
        }

        /// <summary>
        /// Gets or sets the <b>_skill</b> attribute value.
        /// </summary>
        /// <value>The <b>_skill</b> attribute value.</value>
        public string Skill
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

        /// <summary>
        /// Gets or sets the <b>_experience</b> attribute value.
        /// </summary>
        /// <value>The <b>_experience</b> attribute value.</value>
        public string Experience
        {
            get
            {
                return _experience;
            }
            set
            {
                _experience = value;
            }
        }

        /// <summary>
        /// Gets or sets the <b>_vacancy</b> attribute value.
        /// </summary>
        /// <value>The <b>_vacancy</b> attribute value.</value>
        public int Vacancy
        {
            get
            {
                return _vacancy;
            }
            set
            {
                _vacancy = value;
            }
        }

        /// <summary>
        /// Gets or sets the <b>_companyid</b> attribute value.
        /// </summary>
        /// <value>The <b>_companyid</b> attribute value.</value>
        public int Company_id
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
        /// Gets or sets the <b>_positionid</b> attribute value.
        /// </summary>
        /// <value>The <b>_positionid</b> attribute value.</value>
        public int Position_id
        {
            get
            {
                return _positionid;
            }
            set
            {
                _positionid = value;
            }
        }

        /// <summary>
        /// Gets or sets the <b>_jobnatureid</b> attribute value.
        /// </summary>
        /// <value>The <b>_jobnatureid</b> attribute value.</value>
        public int Jobnature_id
        {
            get
            {
                return _jobnatureid;
            }
            set
            {
                _jobnatureid = value;
            }
        }

        /// <summary>
        /// Gets or sets the <b>_specializationid</b> attribute value.
        /// </summary>
        /// <value>The <b>_specializationid</b> attribute value.</value>
        public int Specialization_id
        {
            get
            {
                return _specializationid;
            }
            set
            {
                _specializationid = value;
            }
        }

        /// <summary>
        /// Gets or sets the <b>_salary</b> attribute value.
        /// </summary>
        /// <value>The <b>_salary</b> attribute value.</value>
        public int Salary
        {
            get
            {
                return _salary;
            }
            set
            {
                _salary = value;
            }
        }

        /// <summary>
        /// Gets or sets the <b>_detail</b> attribute value.
        /// </summary>
        /// <value>The <b>_detail</b> attribute value.</value>
        public string Detail
        {
            get
            {
                return _detail;
            }
            set
            {
                _detail = value;
            }
        }

        /// <summary>
        /// Gets or sets the <b>_active</b> attribute value.
        /// </summary>
        /// <value>The <b>_active</b> attribute value.</value>
        public Int16 Active
        {
            get
            {
                return _active;
            }
            set
            {
                _active = value;
            }
        }

        /// <summary>
        /// Gets or sets the <b>_createddate</b> attribute value.
        /// </summary>
        /// <value>The <b>_createddate</b> attribute value.</value>
        public DateTime CreatedDate
        {
            get
            {
                return _createddate;
            }
            set
            {
                _createddate = value;
            }
        }

        /// <summary>
        /// Gets or sets the <b>_updatedddate</b> attribute value.
        /// </summary>
        /// <value>The <b>_updatedddate</b> attribute value.</value>
        public DateTime UpdatedDate
        {
            get
            {
                return _updatedddate;
            }
            set
            {
                _updatedddate = value;
            }
        }

        #endregion Properties Assigning and Retrieving
    }
}