using System;
using System.Collections.Generic;
using System.Text;

namespace DataContracts.Entities
{
    public class Role
    {
        public string Name { get; set; }

        public string Description { get; set; }
        public Guid Id { get; set; }
    }
}
