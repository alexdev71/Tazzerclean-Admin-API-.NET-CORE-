using System;
using System.Collections.Generic;
using System.Text;

namespace DataContracts.Entities
{
    public class CategoryType
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string IconPath { get; set; }
        public string CatCode { get; set; }
        public string Description { get; set; }
        public byte[] Icon { get; set; }

        public int? Priority { get; set; }
        public string SubcatCode { get; set; }
        public MainCategoryType Type { get; set; }
        public int TypeOrder { get; set; }
        public List<Category> Categories { get; set; }
        public List<BusinessInfo> Businesses { get; set; }
        public bool Deleted { get; set; }
        public bool IsPrimary { get; set; }
        public Guid PrimaryType { get; set; }
        public bool HasSubTypes { get; set; }
    }
}
