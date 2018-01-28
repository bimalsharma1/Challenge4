
namespace FlipFlop.Classes
{
    public static class FlipFlop
    {
        public static string DisplayFlipFlop()
        {
            var flipFlopData = "";
            var maxNum = 100;
            for (int i = 1; i <= maxNum; i++)
            {
                flipFlopData += DisplayValue(i);
                if (i != maxNum)
                {
                    flipFlopData += ", ";
                }
            }

            return flipFlopData;
        }

        private static string DisplayValue(int n)
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
