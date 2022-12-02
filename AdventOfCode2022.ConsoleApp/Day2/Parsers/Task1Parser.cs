using AdventOfCode2022.ConsoleApp.Day2.Enums;

namespace AdventOfCode2022.ConsoleApp.Day2.Parsers
{
    /// <summary>
    /// Parse by story 1
    /// </summary>
    public class Task1Parser : BaseParser, IDay2DataParser
    {
        public (GameActionType, GameActionType) ParseGameAction(ReadOnlySpan<char> line)
        {
            GameActionType opponentAction = SimpelParse(line[..1]);
            GameActionType myAction = SimpelParse(line.Slice(2, 1));

            return (opponentAction, myAction);
        }
    }
}
