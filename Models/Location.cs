using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudyroomBookingZealand.Models
{
    public class Location
    {
        public int LocationId { get; set; }
        [Required(ErrorMessage = "The name is required")]
        [StringLength(30)]
        public string Name { get; set; }
        [Required(ErrorMessage = "The address is required")]
        [StringLength(30)]
        public string Address { get; set; }
        public string ImageName { get; set; }
    }
}
