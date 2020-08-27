using System;
using System.Collections.Generic;

namespace DawApp.Models
{
    public partial class Cases
    {
        public int CaseId { get; set; }
        public int NoCases { get; set; }
        public int NoRecovered { get; set; }
        public int NoDeath { get; set; }
        public int CountryId { get; set; }

        public virtual Country Country { get; set; }
    }
}
