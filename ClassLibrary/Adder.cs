using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Adder : IAdder
    {
        public int AddUp(int a)
        {
            // Implement the functionality of the dependency
            return a + 1;
        }
    }

}
