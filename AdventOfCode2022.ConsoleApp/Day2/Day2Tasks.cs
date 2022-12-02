namespace AdventOfCode2022.ConsoleApp.Day2
{
    internal class Day2Tasks
    {
        private string[] _values;
        private List<GameRound> _gameRounds;

        public Day2Tasks()
        {
            _values = GetInputDay2();
        }

        private List<GameRound> ParseGameRounds(string[] values)
        {
            int count = values.Length;
            var gameRounds = new List<GameRound>(count);

            for (int i = 0; i < count; i++)
            {
                ReadOnlySpan<char> line = values[i].AsSpan();

                GameAction otherAction = ParseGameMethod1(line.Slice(0, 1));
                GameAction myAction = ParseGameMethod1(line.Slice(2, 1));
                GameResult gameResult = ParseGameResult(line.Slice(2, 1));

                gameRounds.Add(new GameRound(otherAction, myAction, gameResult));
            }

            return gameRounds;
        }

        private GameResult ParseGameResult(ReadOnlySpan<char> readOnlySpan)
        {
            return readOnlySpan[0] switch
            {
                'X' => GameResult.Loose,
                'Y' => GameResult.Draw,
                'Z' => GameResult.Win,
                _ => throw new ArgumentOutOfRangeException(),
            };
        }

        static IScoreCalculator task1Calculator = new Task1Calculator();
        static IScoreCalculator task2Calculator = new Task2Calculator();

        public int GetTotalScoreTask1()
        {
            _gameRounds = ParseGameRounds(_values);
            int totalScore = _gameRounds.Sum(x => x.CalculateScore(task1Calculator));
            return totalScore;
        }

        public int GetTotalScoreTask2()
        {
            _gameRounds = ParseGameRounds(_values);
            int totalScore = _gameRounds.Sum(x => x.CalculateScore(task2Calculator));
            return totalScore;
        }

        private GameAction ParseGameMethod1(ReadOnlySpan<char> readOnlySpan)
        {
            switch (readOnlySpan[0])
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
