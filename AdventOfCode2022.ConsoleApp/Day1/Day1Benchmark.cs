using BenchmarkDotNet.Attributes;

namespace AdventOfCode2022.ConsoleApp.Day1
{
    /*
        |    Method |     Mean |     Error |    StdDev |   Gen0 | Allocated |
        |---------- |---------:|----------:|----------:|-------:|----------:|
        | Day1Task1 | 2.035 us | 0.0229 us | 0.0214 us |      - |      40 B |
        | Day1Task2 | 5.505 us | 0.0899 us | 0.0797 us | 0.3586 |    4576 B |   
    */

    [MemoryDiagnoser]
    public class Day1Benchmark
    {
        Day1Tasks _day1Tasks = null!;

        [GlobalSetup]
        public void Setup()
        {
            _day1Tasks = new Day1Tasks();
        }

        [Benchmark]
        public int Day1Task1()
        {
            return _day1Tasks.Task1HighestCalorieCount();
        }

        [Benchmark]
        public int Day1Task2()
        {
            return _day1Tasks.Task2TopThreeTotalCalorieCount();
        }
    }
}
