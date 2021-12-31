using System;
using System.Collections.Generic;
using System.Text;

namespace Utilities.Test.enumTests
{
    public class EnumTests
    {
        public string GetEnumDescription()
        {
            return WeekDays.Saturday.ToDescriptionString();
        }
        public string GetEnumEnglishDescription()
        {
            return WeekDays.Saturday.ToEnglishDescriptionString();
        }
    }
}
