using AdventOfCode2022.ConsoleApp.Day2.Enums;

namespace AdventOfCode2022.ConsoleApp.Day2.Models
{
    public class GameRound
    {
        public GameRound(GameActionType otherAction, GameActionType myAction)
        {
            OtherAction = otherAction;
            MyAction = myAction;
        }

        public GameActionType OtherAction { get; }
        public GameActionType MyAction { get; }
        public int CalculateScore()
        {
            return ScoreCalculator.Calculate(OtherAction, MyAction);
        }
    }
}