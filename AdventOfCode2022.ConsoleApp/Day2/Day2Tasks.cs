using AdventOfCode2022.ConsoleApp.Day2.Enums;
using AdventOfCode2022.ConsoleApp.Day2.Models;
using AdventOfCode2022.ConsoleApp.Day2.Parsers;

namespace AdventOfCode2022.ConsoleApp.Day2
{
    internal class Day2Tasks
    {
        private readonly string[] _values;

        public Day2Tasks()
        {
            _values = GetInputDay2();
        }

        private static List<GameRound> ParseGameRounds(string[] values, IDay2DataParser parserToUse)
        {
            int count = values.Length;
            var gameRounds = new List<GameRound>(count);

            for (int i = 0; i < count; i++)
            {
                ReadOnlySpan<char> line = values[i].AsSpan();

                (GameActionType, GameActionType) results = parserToUse.ParseGameAction(line);
                gameRounds.Add(new GameRound(results.Item1, results.Item2));
            }

            return gameRounds;
        }

        public int GetTotalScoreTask1()
        {
            var gameRounds = ParseGameRounds(_values, new Task1Parser());
            return gameRounds.Sum(x => x.CalculateScore());
        }

        public int GetTotalScoreTask2()
        {
            var gameRounds = ParseGameRounds(_values, new Task2Parser());
            return gameRounds.Sum(x => x.CalculateScore());
        }

        private static string[] GetInputDay2()
        {
            return File.ReadAllLines("Day2/Day2Input.txt");
        }
    }
}