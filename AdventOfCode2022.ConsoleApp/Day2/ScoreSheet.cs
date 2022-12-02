namespace AdventOfCode2022.ConsoleApp.Day2
{
    public abstract class ScoreBaseSheet
    {
        public int WonScore = 6;
        public int DrawScore = 3;
        public int LostScore = 0;

        public abstract GameAction GameAction { get; }
        public abstract int GetScore(GameAction other);
    }
    public sealed class RockScoreSheet : ScoreBaseSheet
    {
        public override GameAction GameAction => GameAction.Rock;

        public override int GetScore(GameAction other)
        {
            return other switch
            {
                GameAction.Rock => DrawScore,
                GameAction.Paper => LostScore,
                GameAction.Scissors => WonScore,
                _ => throw new ArgumentException()
            };
        }
    }
    public sealed class PaperScoreSheet : ScoreBaseSheet
    {
        public override GameAction GameAction => GameAction.Paper;

        public override int GetScore(GameAction other)
        {
            return other switch
            {
                GameAction.Rock => WonScore,
                GameAction.Paper => DrawScore,
                GameAction.Scissors => LostScore,
                _ => throw new ArgumentException()
            };
        }
    }
    public sealed class ScissorsScoreSheet : ScoreBaseSheet
    {
        public override GameAction GameAction => GameAction.Scissors;

        public override int GetScore(GameAction other)
        {
            return other switch
            {
                GameAction.Rock => LostScore,
                GameAction.Paper => WonScore,
                GameAction.Scissors => DrawScore,
                _ => throw new ArgumentException()
            };
        }
    }
}
