using System;
using System.Collections.Generic;
using System.Text;

namespace DataContracts.Entities
{
    public class DashboardStats
    {
        public int UserCount { get; set; }
        public int ProfessionalsCount { get; set; }
        public int CategoriesCount { get; set; }
        public int ZipCodesCount { get; set; }
        public int OrdersCount { get; set; }
        public int CompletedOrdersCount { get; set; }
        public int CanceledOrdersCount { get; set; }
        public int PartnersCount { get; set; }
    }
}
