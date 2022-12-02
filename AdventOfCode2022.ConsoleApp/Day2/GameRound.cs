namespace AdventOfCode2022.ConsoleApp.Day2
{
    internal class GameRound
    {
        public GameRound(GameAction otherAction, GameAction myAction)
        {
            OtherAction = otherAction;
            MyAction = myAction;
        }

        public GameAction OtherAction { get; }
        public GameAction MyAction { get; }

        public int CalculateScore()
        {
            int choosenActoinScore = (int)MyAction;
            int gameScore = ScoreCalculator.Calculate(MyAction, OtherAction);
            return choosenActoinScore + gameScore;
        }
    }
}