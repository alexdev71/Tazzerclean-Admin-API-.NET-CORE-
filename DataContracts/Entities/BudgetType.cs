using System.ComponentModel;

namespace DataContracts.Entities
{
    public enum BudgetType
    {
        [Description("Under £1000")]
        Range1 = 1,
        [Description("£1000 - £5000")]
        Range2 = 2,
        [Description("£5000 - £10000")]
        Range3 = 3,
        [Description("More than £10000")]
        Range4 = 4,
        [Description("Not Sure")]
        None = 5
    }
}
