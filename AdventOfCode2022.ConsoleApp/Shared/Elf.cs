namespace AdventOfCode2022.ConsoleApp.Shared
{
    public sealed class Elf
    {
        public List<int> Calories { get; }
        public Elf(List<int> calories)
        {
            Calories = calories;
            SumCalories = calories.Sum();
        }

        public int SumCalories { get; }
    }
}
