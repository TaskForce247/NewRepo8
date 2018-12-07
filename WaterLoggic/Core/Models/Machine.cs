using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WaterLoggic.Core.Models
{
    public class Machine
    {
        public int Id { get; set; }
     
        public string Name { get; set; }
      
        public string ShortDescription { get; set; }
        
        public string ImageUrl { get; set; }

        public string LongDescription { get; set; }

        public decimal Price { get; set; }

        public int stock { get; set; }
        public bool available { get; set; }

       
        public int CategoryId { get; set; }
        public MCategory Category { get; set; }
        [Timestamp]
        public byte[] Version { get; set; }
        

    }
}
