using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace WaterLoggic.Core.Dto
{
    public class MOrderDto
    {
        [StringLength(255)]
        [Display(Name = "First Name")]
        [Required(ErrorMessage = "First Name is required")]
        public string FirstName { get; set; }
        [StringLength(255)]
        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Last Name is required")]
        public string LastName { get; set; }
        [StringLength(255)]
        [Display(Name = "Address")]
        [Required(ErrorMessage = "Address is required")]
        public string AddressLine { get; set; }

        [StringLength(255)]
        [Display(Name = "City")]
        [Required(ErrorMessage = "City is required")]
        public string City { get; set; }

        [StringLength(255)]
        [Display(Name = "Phone")]
        [Required(ErrorMessage = "Phon is required")]
        public string PhoneNumber { get; set; }
    }
}
