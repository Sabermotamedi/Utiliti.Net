using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Utilities.Test.enumTests
{
    public enum WeekDays
    {
        [Description("شنبه")]
        Saturday = 0,
        [Description("یک شنبه")]
        Sunday = 1,
        [Description("دوشنبه")]
        Monday = 2,
        [Description("سه شنبه")]
        Tuesday = 3,
        [Description("چهار شنبه")]
        Wednesday = 4,
        [Description("پنج شنبه")]
        Thursday = 5,
        [Description("جمعه")]
        Friday = 6       
    }
}
