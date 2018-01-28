using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlipFlop.Classes
{
    public static class FlipFlop
    {
        public static string DisplayValue(int n)
        {
            var flip = "Flip";
            var flop = "Flop";
            return MultipleOfFive(n) && MultipleOfSeven(n) 
                ? flip + " " + flop
                : MultipleOfFive(n) 
                    ? flip
                    : MultipleOfSeven(n) ? flop : n.ToString();
        }

        private static bool MultipleOfFive(int n)
        {
            return n % 5 == 0;
        }

        private static bool MultipleOfSeven(int n)
        {
            return n % 7 == 0;
        }
    }
}
