using AdventOfCode2022.ConsoleApp.Day1;
using BenchmarkDotNet.Running;

namespace AdventOfCode2022.ConsoleApp
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            BenchmarkRunner.Run<Day1Benchmark>();

            //Day1Tasks day1Tasks = new Day1Tasks();
            
            //var highestCalorieCount = day1Tasks.Task1HighestCalorieCount();
            //Console.WriteLine($"How many total Calories is that Elf carrying? Answer: {highestCalorieCount}");

            //var top3CalorieCount = day1Tasks.Task2TopThreeTotalCalorieCount();
            //Console.WriteLine($"How many Calories are those Elves carrying in total? Answer: {top3CalorieCount}");

            //Console.ReadLine();
        }
    }
}