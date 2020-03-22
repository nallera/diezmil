using System;
using System.Collections.Generic;

namespace DiezMil
{
    internal class TestParameters
    {
        private List<int> parameterList;
        private int times;

        public TestParameters()
        {
            parameterList = new List<int>();
            times = 1;
        }

        internal void DefineParams()
        {
            Console.WriteLine("Let's define the test parameters.");

            Console.WriteLine("Enter the risk factor list, separate the values by commas:");
            Console.ReadLine();

            //parse list
        }
    }
}