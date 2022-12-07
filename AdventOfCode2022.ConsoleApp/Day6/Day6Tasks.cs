using AdventOfCode2022.ConsoleApp.Shared;
using Iced.Intel;

namespace AdventOfCode2022.ConsoleApp.Day6
{
    internal class Day6Tasks : BaseTask
    {
        private string _code;

        public Day6Tasks()
        {
            string[] input = GetInput("Day6/Day6Input1.txt");
            _code = input[0];
        }
        public int Task1()
        {
            return SearchAfterUniqueCount(4);
        }

        private int SearchAfterUniqueCount(int uniqueCharacterCount)
        {
            ReadOnlySpan<char> span = _code.AsSpan();
            int length = span.Length;

            for (int index = 0; index < length; index++)
            {
                ReadOnlySpan<char> charactersSlice = span.Slice(index, uniqueCharacterCount);

                if (charactersSlice.ToArray().Distinct().Count() == uniqueCharacterCount)
                {
                    return index + uniqueCharacterCount;
                }
            }

            return -1;
        }

        internal int Task2()
        {
            return SearchAfterUniqueCount(14);
        }
    }
}
