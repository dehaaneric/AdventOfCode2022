using AdventOfCode2022.ConsoleApp.Day2.Enums;

namespace AdventOfCode2022.ConsoleApp.Day2.Models
{
    public static class GameActionRuleBook
    {
        public static List<GameRule> Rules = new()
        {
                new GameRule(GameActionType.Rock, GameActionType.Scissors, GameActionType.Paper),
                new GameRule(GameActionType.Paper, GameActionType.Rock, GameActionType.Scissors),
                new GameRule(GameActionType.Scissors, GameActionType.Paper, GameActionType.Rock),
        };

        public static GameRule GetGameRuleForAction(GameActionType action)
        {
            return Rules.First(x => x.GameAction == action);
        }
    }
}