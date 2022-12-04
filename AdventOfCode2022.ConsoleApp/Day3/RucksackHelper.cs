namespace AdventOfCode2022.ConsoleApp.Day3
{
    public static class RucksackHelper
    {
        public static int GetRucksackValue(char[] chars)
        {
            int total = 0;

            foreach (char c in chars)
            {
                total += AsciiHelper.GetPuzzleAsciiValue(c);
            }

            return total;
        }
    }
}
