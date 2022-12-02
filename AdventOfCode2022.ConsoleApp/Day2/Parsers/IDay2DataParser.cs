using AdventOfCode2022.ConsoleApp.Day2.Enums;

namespace AdventOfCode2022.ConsoleApp.Day2.Parsers
{
    /// <summary>
    /// A contract that let the implementation decide what way to parse the incoming data
    /// </summary>
    public interface IDay2DataParser
    {
        (GameActionType, GameActionType) ParseGameAction(ReadOnlySpan<char> line);
    }
}
