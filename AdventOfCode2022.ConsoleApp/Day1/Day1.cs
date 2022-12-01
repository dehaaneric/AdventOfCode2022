using AdventOfCode2022.ConsoleApp.Shared;

namespace AdventOfCode2022.ConsoleApp.Day1
{
    internal class Day1Tasks
    {
        private List<Elf> _elves = null!;

        public Day1Tasks()
        {
            PreloadElves();
        }

        private void PreloadElves()
        {
            var stringsInput = GetInputDay1();
            _elves = CreateElves(stringsInput);
        }

        public void ProcessTask1()
        {
            var highestCalorieCount = _elves.Max(x => x.SumCalories);

            Console.WriteLine($"How many total Calories is that Elf carrying? Answer: {highestCalorieCount}");
        }

        public void ProcessTask2()
        {
            var top3elvesWithHighestCalories = _elves.OrderByDescending(x => x.SumCalories).Skip(0).Take(3);
            var totalCalories = top3elvesWithHighestCalories.Sum(x => x.SumCalories);

            Console.WriteLine($"How many Calories are those Elves carrying in total? Answer: {totalCalories}");
        }

        private static List<Elf> CreateElves(string[] getInput)
        {
            Span<string> calorieLines = getInput.AsSpan();

            List<Elf> elves = new List<Elf>();

            List<int>? calorieCollection = null;
            foreach (string calorie in calorieLines)
            {
                if (!string.IsNullOrEmpty(calorie))
                {
                    if (calorieCollection == null)
                        calorieCollection = new List<int>(10);

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

        private string[] GetInputDay1()
        {
            return File.ReadAllLines(@"Day1/Day1Input.txt");
        }
    }
}
