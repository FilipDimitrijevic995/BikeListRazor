using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BikeListRazor.Model
{
    public class Bike
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string Brand { get; set; }
    }
}
