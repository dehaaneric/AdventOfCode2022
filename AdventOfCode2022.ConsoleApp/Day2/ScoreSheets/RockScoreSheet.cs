using AdventOfCode2022.ConsoleApp.Day2.Enums;

namespace AdventOfCode2022.ConsoleApp.Day2.ScoreSheets
{
    public sealed class RockScoreSheet : ScoreBaseSheet
    {
        public override GameActionType GameAction => GameActionType.Rock;

        public override int GetScore(GameActionType other)
        {
            return other switch
            {
                GameActionType.Rock => DrawScore,
                GameActionType.Paper => LostScore,
                GameActionType.Scissors => WonScore,
                _ => throw new ArgumentException()
            };
        }
    }
}
