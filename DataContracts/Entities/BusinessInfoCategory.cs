using System;
using System.Collections.Generic;
using System.Text;

namespace DataContracts.Entities
{
    public class BusinessInfoCategory
    {
        public Guid BusinessId { get; set; }

        public Guid CategoryId { get; set; }

        public virtual BusinessInfo Business { get; set; }

        public virtual Category Category { get; set; }
    }
}
