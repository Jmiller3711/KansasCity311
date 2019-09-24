using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KansasCity311
{
    public class Form311
    {
        public ContactInformation ContactInformation { get; set; }
        public string WhatToReport { get; set; }
        public string IncedentAddress { get; set; }
        public string Description { get; set; }

        public Form311(ContactInformation contactInformation, string whatToReport, string incedentAddress, string description)
        {
            ContactInformation = contactInformation;
            WhatToReport = whatToReport;
            IncedentAddress = incedentAddress;
            Description = description;
        }
    }
}
