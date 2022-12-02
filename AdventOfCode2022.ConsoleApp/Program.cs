using AdventOfCode2022.ConsoleApp.Day1;
using AdventOfCode2022.ConsoleApp.Day2;
using BenchmarkDotNet.Running;

namespace AdventOfCode2022.ConsoleApp
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            RunDay2();
        }

        private static void RunDay2()
        {
            Day2Tasks day2Tasks = new Day2Tasks();
            int totalScore = day2Tasks.GetTotalScore();

            Console.WriteLine($"What would your total score be if everything goes exactly according to your strategy guide?: {totalScore}");
        }

        private static void RunDay1()
        {
            //BenchmarkRunner.Run<Day1Benchmark>();

            Day1Tasks day1Tasks = new Day1Tasks();

            var highestCalorieCount = day1Tasks.Task1HighestCalorieCount();
            Console.WriteLine($"How many total Calories is that Elf carrying? Answer: {highestCalorieCount}");

            var top3CalorieCount = day1Tasks.Task2TopThreeTotalCalorieCount();
            Console.WriteLine($"How many Calories are those Elves carrying in total? Answer: {top3CalorieCount}");

            Console.ReadLine();
        }
    }
}