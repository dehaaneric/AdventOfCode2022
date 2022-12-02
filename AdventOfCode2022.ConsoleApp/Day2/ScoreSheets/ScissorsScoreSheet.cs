using AdventOfCode2022.ConsoleApp.Day2.Enums;

namespace AdventOfCode2022.ConsoleApp.Day2.ScoreSheets
{
    public sealed class ScissorsScoreSheet : ScoreBaseSheet
    {
        public override GameActionType GameAction => GameActionType.Scissors;

        public override int GetScore(GameActionType other)
        {
            return other switch
            {
                GameActionType.Rock => LostScore,
                GameActionType.Paper => WonScore,
                GameActionType.Scissors => DrawScore,
                _ => throw new ArgumentException()
            };
        }
    }
}
