namespace AdventOfCode2022.ConsoleApp.Day2
{
    public interface IScoreCalculator
    {
        int CalculateScore(GameRound gameRound);
    }

    public class Task1Calculator : IScoreCalculator
    {
        public int CalculateScore(GameRound gameRound)
        {
            int choosenActoinScore = (int)gameRound.MyAction;
            int gameScore = ScoreCalculator.Calculate(gameRound.MyAction, gameRound.OtherAction);
            return choosenActoinScore + gameScore;
        }
    }
    public class Task2Calculator : IScoreCalculator
    {
        public int CalculateScore(GameRound gameRound)
        {
            var myAction = gameRound.GetMyActionBasedOnResult();
            int choosenActoinScore = (int)myAction;
            int gameScore = ScoreCalculator.Calculate(myAction, gameRound.OtherAction);
            return choosenActoinScore + gameScore;
        }
    }

}
