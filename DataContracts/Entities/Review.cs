using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataContracts.Entities
{
    public class Review
    {
        [Range(0, 5)]
        public byte Rating { get; set; }
        public string Comment { get; set; }
        public Guid BusinessId { get; set; }
        public Guid UserId { get; set; }
        public Guid QuoteId { get; set; }
        public virtual User User { get; set; }
        public virtual BusinessInfo Business { get; set; }
        public virtual Quotation Quote { get; set; }
    }
}
