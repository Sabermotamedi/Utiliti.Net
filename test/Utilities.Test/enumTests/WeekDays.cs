using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Utilities.Attributes;

namespace Utilities.Test.enumTests
{
    public enum WeekDays
    {
        [Description("دوشنبه")]
        [EnglishDescription("Monday")]
        Monday = 0,
        [Description("سه شنبه")]
        [EnglishDescription("Tuesday")]
        Tuesday = 1,
        [Description("چهار شنبه")]
        [EnglishDescription("Wednesday")]
        Wednesday = 2,
        [Description("پنج شنبه")]
        [EnglishDescription("Thursday")]
        Thursday = 3,
        [Description("جمعه")]
        [EnglishDescription("Friday")]
        Friday = 4,
        [Description("شنبه")]
        [EnglishDescription("Saturday")]
        Saturday = 5,
        [Description("یک شنبه")]
        [EnglishDescription("Sunday")]
        Sunday = 6
    }
}
