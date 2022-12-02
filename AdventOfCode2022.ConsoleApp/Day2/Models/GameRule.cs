using AdventOfCode2022.ConsoleApp.Day2.Enums;

namespace AdventOfCode2022.ConsoleApp.Day2.Models
{
    public class GameRule
    {
        public GameRule(GameActionType gameAction, GameActionType winsFrom, GameActionType loosesFrom)
        {
            GameAction = gameAction;
            WinsFrom = winsFrom;
            LoosesFrom = loosesFrom;
        }

        public GameActionType GameAction { get; }
        public GameActionType WinsFrom { get; }
        public GameActionType LoosesFrom { get; }
    }
}