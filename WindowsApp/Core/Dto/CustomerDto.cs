using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MainClient.Core.Dto
{
    public class CustomerDto
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Email")]
        [MaxLength(50)]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Phone")]
        [MaxLength(50)]
        public string Phone { get; set; }

        [Required]
        [Display(Name = "Address")]
        [MaxLength(50)]
        public string Address { get; set; }

        [Timestamp]
        public byte[] Version { get; set; }

    }
}
