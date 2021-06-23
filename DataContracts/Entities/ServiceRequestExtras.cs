using System;
using System.Collections.Generic;
using System.Text;

namespace DataContracts.Entities
{
    public class ServiceRequestExtras
    {
        public decimal extraRequestHour { get; set; }
        public decimal extraRequestPerHourPrice { get; set; }
        public decimal extraFinalPrice { get; set; }
        public Guid ServiceRequestId { get; set; }
        public Guid CategoryId { get; set; }
        public virtual Category Categoris { get; set; }
    }
}
