using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice11
{
    internal class ClientData
    {
        /// <summary>
        /// Clients last name
        /// </summary>
        public string LastName { get; private set; }

        /// <summary>
        /// Clients first name
        /// </summary>
        public string FirstName { get; private set; }

        /// <summary>
        /// Clients fathers name or second name
        /// </summary>
        public string FathersName { get; private set; }

        /// <summary>
        /// Clients phone number
        /// </summary>
        public uint PhoneNumber { get; set; }

        /// <summary>
        /// Clients passport series
        /// </summary>
        public uint PassportSeries { get; set; }

        /// <summary>
        /// Clients passport number
        /// </summary>
        public uint PassportNumber { get; set; }

        public virtual void ViewInformation()
        {

        }
    }
}
