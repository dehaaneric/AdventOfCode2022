using AdventOfCode2022.ConsoleApp.Day2.Enums;

namespace AdventOfCode2022.ConsoleApp.Day2.ScoreSheets
{
    public abstract class ScoreBaseSheet
    {
        public int WonScore = 6;
        public int DrawScore = 3;
        public int LostScore = 0;

        public abstract GameActionType GameAction { get; }
        public abstract int GetScore(GameActionType other);
    }
}
