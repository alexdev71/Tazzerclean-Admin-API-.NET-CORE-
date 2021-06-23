using System;
using System.Collections.Generic;
using System.Text;

namespace DataContracts.Entities
{
    public class Offer
    {
        public Guid QuoteId { get; set; }

        public Guid BusinessId { get; set; }

        public double QuotePrice { get; set; }

        public string Description { get; set; }

        public BusinessInfo Business { get; set; }

        public Quotation Quotation { get; set; }
    }
}
