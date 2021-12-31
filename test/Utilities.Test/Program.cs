using System;
using Utilities.Test.enumTests;

namespace Utilities.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            EnumTests enumTests = new EnumTests();        
            
            Console.WriteLine(enumTests.GetEnumDescription());
            Console.WriteLine(enumTests.GetEnumEnglishDescription());

        }
    }
}
