using AdventOfCode2022.ConsoleApp.Day2.Enums;

namespace AdventOfCode2022.ConsoleApp.Day2.ScoreSheets
{
    public sealed class PaperScoreSheet : ScoreBaseSheet
    {
        public override GameActionType GameAction => GameActionType.Paper;

        public override int GetScore(GameActionType other)
        {
            return other switch
            {
                GameActionType.Rock => WonScore,
                GameActionType.Paper => DrawScore,
                GameActionType.Scissors => LostScore,
                _ => throw new ArgumentException()
            };
        }
    }
}
