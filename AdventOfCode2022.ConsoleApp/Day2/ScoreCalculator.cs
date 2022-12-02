using AdventOfCode2022.ConsoleApp.Day2.Enums;
using AdventOfCode2022.ConsoleApp.Day2.ScoreSheets;

namespace AdventOfCode2022.ConsoleApp.Day2
{
    public static class ScoreCalculator
    {
        static readonly List<ScoreBaseSheet> _scoreSheets = new()
        {
            new RockScoreSheet(),
            new PaperScoreSheet(),
            new ScissorsScoreSheet()
        };

        internal static int Calculate(GameActionType opponentAction, GameActionType myAction)
        {
            var scoreSheetToUse = _scoreSheets.First(x => x.GameAction == myAction);
            int scoreBySheet = scoreSheetToUse.GetScore(opponentAction);
            int valueFromActionType = (int)myAction;

            return scoreBySheet + valueFromActionType;
        }
    }
}