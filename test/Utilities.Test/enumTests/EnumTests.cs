using System;
using System.Collections.Generic;
using System.Text;
using Utilities.Test.enumTests.Models;

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
        public List<EnumLst> ConvertEnumToList()
        {
            List<EnumLst> enumLsts = new List<EnumLst>();



            return enumLsts;
        }
    }
}
