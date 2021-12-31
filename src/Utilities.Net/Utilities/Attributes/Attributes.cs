using System;
using System.Collections.Generic;
using System.Text;

namespace Utilities.Attributes
{
    public class EnglishDescriptionAttribute : Attribute
    {
        public string EnglishDescription { get; private set; }

        /// <summary>
        /// Add more Attribute
        /// </summary>
        /// <param name="description"></param>
        public EnglishDescriptionAttribute(string description)
        {
            EnglishDescription = description;
        }
    }
}
