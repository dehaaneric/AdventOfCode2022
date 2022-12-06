using AdventOfCode2022.ConsoleApp.Day1;
using AdventOfCode2022.ConsoleApp.Day2;
using AdventOfCode2022.ConsoleApp.Day3;
using AdventOfCode2022.ConsoleApp.Day4;
using AdventOfCode2022.ConsoleApp.Day5;

namespace AdventOfCode2022.ConsoleApp
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            RunDay5();
        }

        private static void RunDay5()
        {
            string resultTask1 = Day5Tasks.Task1();
            Console.WriteLine($"After the rearrangement procedure completes, what crate ends up on top of each stack?: \"{resultTask1}\"");
        }

        private static void RunDay4()
        {
            Day4Tasks day4Tasks = new Day4Tasks();

            int task1Result = day4Tasks.Task1();
            Console.WriteLine($"Day 4 Task 1 In how many assignment pairs does one range fully contain the other?: {task1Result}");

            int task2Result = day4Tasks.Task2();
            Console.WriteLine($"Day 4 Task 2 In how many assignment pairs do the ranges overlap?: {task2Result}");
        }

        private static void RunDay3()
        {
            Day3Tasks day3Tasks = new Day3Tasks();
            var task1Result = day3Tasks.GetTotalValueTask1();
            Console.WriteLine($"Day 3 Task 1 - What is the sum of the priorities of those item types?: {task1Result}");

            var task2Result = day3Tasks.GetTotalValueTask2();
            Console.WriteLine($"Day 3 Task 2 - What is the sum of the priorities of those item types?: {task2Result}");

        }

        private static void RunDay2()
        {
            Day2Tasks day2Tasks = new Day2Tasks();
            int totalScore = day2Tasks.GetTotalScoreTask1();

            Console.WriteLine($"Task 1 - What would your total score be if everything goes exactly according to your strategy guide?: {totalScore}");

            int totalScoreTask2 = day2Tasks.GetTotalScoreTask2();

            Console.WriteLine($"Task 2 - What would your total score be if everything goes exactly according to your strategy guide?: {totalScoreTask2}");

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