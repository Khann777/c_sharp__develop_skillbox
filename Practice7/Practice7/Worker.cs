using System;

namespace Practice7
{
    struct Worker
    {
        #region Constructors
        /// <summary>
        /// Creating worker
        /// </summary>
        /// <param name="Id">Integer number not less than 0 refers for a worker id</param>
        /// <param name="FullName">First name and Last name of a worker</param>
        /// <param name="Age">Integer number not less than 0 refers for a worker age</param>
        /// <param name="BirthDate">"dd.MM.yyyy" for birth date of a worker</param>
        /// <param name="Height">Integer number not less than 0 refers for a worker height</param>
        /// <param name="BirthPlace">City name where worker wasa born</param>
        /// <param name="RecordDate">Readonly parameter for creation time of a record</param>
        public Worker(uint Id, string FullName, uint Age, DateTime BirthDate,uint Height, string BirthPlace, DateTime RecordDate)
        {
            this.id = Id;
            this.fullName = FullName;
            this.age = Age;
            this.birthDate = BirthDate;
            this.birthPlace = BirthPlace;
            this.height = Height;
            this.recordDate = RecordDate;
        }
        #endregion

        #region Properties
        public uint Id { get { return this.id; } set { this.id = value; } }
        public uint Age { get { return this.age; } set { this.age = value; } }
        public uint Height { get { return this.height; } set { this.height = value; } }
        public string FullName { get { return this.fullName; } set { this.fullName = value; } }
        public string BirthPlace { get { return this.birthPlace; } set { this.birthPlace = value; } }
        public DateTime BirthDate { get { return this.birthDate; } set { this.birthDate = value; } }
        public DateTime RecordDate { get { return this.recordDate; }  set { this.recordDate = value;  } }
        #endregion

        #region Fields
        private uint id;
        private uint age;
        private uint height;
        private string fullName;
        private string birthPlace;
        private DateTime birthDate;
        private DateTime recordDate;
        #endregion
    }
}
