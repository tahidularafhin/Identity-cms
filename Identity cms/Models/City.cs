using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Identity_cms.Models
{
    public class City
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        [Required]
        public int CountryId { get; set; }
        //[ForeignKey("CountryId")]
        public virtual Country Country { get; set; }
    }
}
