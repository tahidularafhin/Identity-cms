using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Identity_cms.Models
{
    public class Person
    {
        public int Id{ get; set; }
        public string Name { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        public int CityId { get; set; }
        public virtual City City { get; set; }
        //public int PersonCountry { get; set; }
        public string CreatorId;

    }
}
