using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity_cms.Models
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Area { get; set; }
        public virtual List<City> Cities { get; set; }
    }
}
