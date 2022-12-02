using AdventOfCode2022.ConsoleApp.Day2.Enums;

namespace AdventOfCode2022.ConsoleApp.Day2.Parsers
{
    public class BaseParser
    {
        protected static GameActionType SimpelParse(ReadOnlySpan<char> readOnlySpan)
        {
            return readOnlySpan[0] switch
            {
                'A' or 'X' => GameActionType.Rock,
                'B' or 'Y' => GameActionType.Paper,
                'C' or 'Z' => GameActionType.Scissors,
                _ => throw new ArgumentOutOfRangeException(),
            };
        }
    }
}
