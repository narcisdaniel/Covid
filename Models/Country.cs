using System;
using System.Collections.Generic;

namespace DawApp.Models
{
    public partial class Country
    {
        public Country()
        {
            Cases = new HashSet<Cases>();
        }

        public int CountryId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Cases> Cases { get; set; }
    }
}
