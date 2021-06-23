using System;
using System.Collections.Generic;
using System.Text;

namespace DataContracts.Entities
{
    public class Category
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public string Type { get; set; }

        public string WorkingHours { get; set; }
        public decimal Price { get; set; }
        public bool Deleted { get; set; }
        public Guid TypeId { get; set; }
        public Guid? SubType { get; set; }
        public bool PayPerHour { get; set; }
        public bool PayPerSize { get; set; }
    }
}
