using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace DataContracts.Entities
{
    public enum StartingType
    {
        Asap = 1,
        Emergency = 2,
        [Description("Next few days")]
        FewDays = 3,
        Flexible = 4,
        Other = 5
    }
}
