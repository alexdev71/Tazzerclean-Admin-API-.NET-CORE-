using System;
using System.Collections.Generic;
using System.Text;

namespace DataContracts.Entities
{
    public class BusinessInfo
    {
        public string BusinessName { get; set; }

        public string OwnerFirstName { get; set; }

        public string OwnerLastName { get; set; }

        public string BusinessNumber { get; set; }

        public string Phone { get; set; }

        public string Mobile { get; set; }

        public string Email { get; set; }

        public short? Miles { get; set; }//0 value means nationwide

        public short? WorkingDayFrom { get; set; }

        public short? WorkingDayTo { get; set; }

        public TimeSpan? WorkingTimeStart { get; set; }

        public TimeSpan? WorkingTimeEnd { get; set; }

        public string Description { get; set; }

        public Guid CategoryTypeId { get; set; }

        public double? Rating { get; set; }

        public Guid? AddressId { get; set; }

        public Guid UserId { get; set; }

        public Address Address { get; set; }


        public CategoryType CategoryType { get; set; }

        public List<Gallery> Galleries { get; set; }

        public List<Review> Reviews { get; set; }

        public User User { get; set; }

        public List<ServiceProviding> ServicesProviding { get; set; }

        public List<BusinessInfoCategory> BusinessInfoCategories { get; set; }

        public List<Offer> Quotes { get; set; }
    }
}
