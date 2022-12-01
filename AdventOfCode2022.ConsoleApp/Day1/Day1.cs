using AdventOfCode2022.ConsoleApp.Shared;

namespace AdventOfCode2022.ConsoleApp.Day1
{
    internal class Day1Tasks
    {
        private List<Elf> _elves = null!;

        public Day1Tasks()
        {
            var stringsInput = GetInputDay1();
            _elves = CreateElves(stringsInput);
        }

        public int Task1HighestCalorieCount()
        {
            return _elves.Max(x => x.SumCalories);
        }

        public int Task2TopThreeTotalCalorieCount()
        {
            var top3elvesWithHighestCalories = _elves.OrderByDescending(x => x.SumCalories).Skip(0).Take(3).ToArray();
            return top3elvesWithHighestCalories.Sum(x => x.SumCalories);
        }
        private static List<Elf> CreateElves(string[] getInput)
        {
            Span<string> calorieLines = getInput.AsSpan();

            List<Elf> elves = new();

            List<int>? calorieCollection = null;
            foreach (string calorie in calorieLines)
            {
                if (!string.IsNullOrEmpty(calorie))
                {
                    calorieCollection ??= new List<int>(10);

                    calorieCollection.Add(int.Parse(calorie));
                }
                else
                {
                    // End of a batch
                    elves.Add(new Elf(calorieCollection!));

                    calorieCollection = null;
                }
            }
            return elves;
        }

        private static string[] GetInputDay1()
        {
            return File.ReadAllLines("Day1/Day1Input.txt");
        }
    }
}