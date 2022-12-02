using Microsoft.Diagnostics.Tracing.Parsers.FrameworkEventSource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.ConsoleApp.Day2
{
    internal class Day2Tasks
    {
        private List<GameRound> _gameRounds;

        public Day2Tasks()
        {
            string[] values = GetInputDay2();
            _gameRounds = ParseGameRounds(values);
        }

        private List<GameRound> ParseGameRounds(string[] values)
        {
            int count = values.Length;
            var gameRounds = new List<GameRound>(count);

            for (int i = 0; i < count; i++)
            {
                ReadOnlySpan<char> line = values[i].AsSpan();

                GameAction otherAction = ParseGameAction(line.Slice(0,1));
                GameAction myActoin = ParseGameAction(line.Slice(2,1));

                gameRounds.Add(new GameRound(otherAction, myActoin));
            }

            return gameRounds;
        }

        public int GetTotalScore()
        {
            int totalScore = _gameRounds.Sum(x => x.CalculateScore());
            return totalScore;
        }

        private GameAction ParseGameAction(ReadOnlySpan<char> readOnlySpan)
        {
            switch(readOnlySpan[0])
            {
                case 'A':
                case 'X':
                    return GameAction.Rock;
                case 'B':
                case 'Y':
                    return GameAction.Paper;
                case 'C':
                case 'Z':
                    return GameAction.Scissors;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private static string[] GetInputDay2()
        {
            return File.ReadAllLines("Day2/Day2Input.txt");
        }
    }
}
