
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace WaterLoggic.Core.Models
{
    public class MOrder
    {

        public int Id { get; set; }

        public DateTime OrderPlacedTime { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string AddressLine { get; set; }


        public string City { get; set; }


        public string PhoneNumber { get; set; }


        public decimal OrderTotal { get; set; }

        public string UserId { get; set; }
        public IdentityUser User { get; set; }

        public ICollection<MOrderDetail> MOrderDetails { get; set; }

        public MOrder()
        {
            MOrderDetails = new Collection<MOrderDetail>();
        }
    }
}
