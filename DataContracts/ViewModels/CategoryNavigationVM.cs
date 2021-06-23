using DataContracts.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataContracts.ViewModels
{
    public class CategoryNavigationVM
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
        public string IconPath { get; set; }
        public string Type { get; set; }
        public int? Priority { get; set; }
        public List<Category> Categories { get; set; }
        public bool HasSubTypes { get; set; }

        public List<CategoryType> SubTypes { get; set; }
    }
}
