using System;
using System.Collections.Generic;
using System.Text;

namespace DataContracts.Entities
{
    public class Quotation
    {
        public Guid CategoryId { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Name { get; set; }

        public Guid? UserId { get; set; }

        public string Description { get; set; }

        public string Subject { get; set; }

        public bool Expired { get; set; }

        public StartingType StartingType { get; set; }

        public bool IsCommercial { get; set; }

        public BudgetType Budget { get; set; }

        public QuoteStatus Status { get; set; } = QuoteStatus.Hiring;

        public Guid PostalAddressId { get; set; }

        public List<Message> Messages { get; set; }

        public User User { get; set; }

        public Category Category { get; set; }

        public PostalLookup PostalAddress { get; set; }
    }
}
