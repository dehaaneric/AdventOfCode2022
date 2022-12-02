using AdventOfCode2022.ConsoleApp.Day2.Enums;
using AdventOfCode2022.ConsoleApp.Day2.Models;

namespace AdventOfCode2022.ConsoleApp.Day2.Parsers
{
    /// <summary>
    /// Parse by story 2
    /// </summary>
    public class Task2Parser : BaseParser, IDay2DataParser
    {
        public (GameActionType, GameActionType) ParseGameAction(ReadOnlySpan<char> line)
        {
            GameActionType opponentAction = SimpelParse(line[..1]);
            GameResultType gameResultType = ParseGameResult(line.Slice(2, 1));

            var gameRuleByOpponent = GameActionRuleBook.GetGameRuleForAction(opponentAction);

            var myActionBasedOnResult = gameResultType switch
            {
                GameResultType.Loose => gameRuleByOpponent.WinsFrom,
                GameResultType.Draw => opponentAction,
                GameResultType.Win => gameRuleByOpponent.LoosesFrom,
                _ => throw new ArgumentOutOfRangeException(),
            };

            return (opponentAction, myActionBasedOnResult);
        }

        private static GameResultType ParseGameResult(ReadOnlySpan<char> readOnlySpan)
        {
            return readOnlySpan[0] switch
            {
                'X' => GameResultType.Loose,
                'Y' => GameResultType.Draw,
                'Z' => GameResultType.Win,
                _ => throw new ArgumentOutOfRangeException(),
            };
        }
    }
}
