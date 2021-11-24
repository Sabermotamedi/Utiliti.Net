using System;
using System.Collections.Generic;
using System.Text;

namespace Utilities.Attributes
{
    public class EnglishDescriptionAttribute : Attribute
    {
        public string EnglishDescription { get; private set; }

        public EnglishDescriptionAttribute(string description)
        {
            EnglishDescription = description;
        }
    }
}
