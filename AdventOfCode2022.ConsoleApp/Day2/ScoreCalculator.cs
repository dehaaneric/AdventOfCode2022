namespace AdventOfCode2022.ConsoleApp.Day2
{
    public static class ScoreCalculator
    {
        static List<ScoreBaseSheet> _scoreSheets = new List<ScoreBaseSheet> {
            new RockScoreSheet(),
            new PaperScoreSheet(),
            new ScissorsScoreSheet()
        };

        internal static int Calculate(GameAction left, GameAction right)
        {
            var scoreSheetToUse = _scoreSheets.Where(x => x.GameAction == left).First();
            return scoreSheetToUse.GetScore(right);
        }
    }
}