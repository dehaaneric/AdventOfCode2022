using AdventOfCode2022.ConsoleApp.Day1;

namespace AdventOfCode2022.ConsoleApp
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Day1Tasks day1Tasks = new Day1Tasks();
            day1Tasks.ProcessTask1();
            day1Tasks.ProcessTask2();

            Console.ReadLine();
        }
    }
}