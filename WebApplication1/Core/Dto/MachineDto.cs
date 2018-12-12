using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WaterLoggic.Core.Dto
{
    public class MachineDto
    {

        public int Id { get; set; }

        [Required]
        [Display(Name = "Machine Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Short Description")]
        [MaxLength(50)]
        public string ShortDescription { get; set; }

        [Required]
        [Display(Name = "Long Description")]
        [MaxLength(255)]
        public string LongDescription { get; set; }

        [Required]
        [Display(Name = "Price")]
        public decimal Price { get; set; }

        [Required]
        [Display(Name = "Image Url")]
        public string ImageUrl { get; set; }
        [Timestamp]
        public byte[] Version { get; set; }
      

        [Display(Name = "Category")]
        public int CategoryId { get; set; }
    }
}
