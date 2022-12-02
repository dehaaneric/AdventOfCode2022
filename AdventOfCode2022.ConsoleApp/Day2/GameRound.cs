namespace AdventOfCode2022.ConsoleApp.Day2
{
    public class GameRound
    {
        public GameRound(GameAction otherAction, GameAction myAction, GameResult gameResult)
        {
            OtherAction = otherAction;
            MyAction = myAction;
            GameResult = gameResult;
        }

        public GameAction OtherAction { get; }
        public GameAction MyAction { get; }
        public GameResult GameResult { get; }

        public GameAction GetMyActionBasedOnResult()
        {
            if (GameResult == GameResult.Draw)
                return OtherAction;

            if(GameResult == GameResult.Loose)
            {
                return OtherAction switch
                {
                    GameAction.Rock => GameAction.Scissors,
                    GameAction.Paper => GameAction.Rock,
                    GameAction.Scissors => GameAction.Paper,
                    _ => throw new ArgumentOutOfRangeException(),
                };
            }

            if (GameResult == GameResult.Win)
            {
                return OtherAction switch
                {
                    GameAction.Rock => GameAction.Paper,
                    GameAction.Paper => GameAction.Scissors,
                    GameAction.Scissors => GameAction.Rock,
                    _ => throw new ArgumentOutOfRangeException(),
                };
            }

            throw new ArgumentOutOfRangeException();
        }

        public int CalculateScore(IScoreCalculator scoreCalculator)
        {
            return scoreCalculator.CalculateScore(this);
        }
    }
}