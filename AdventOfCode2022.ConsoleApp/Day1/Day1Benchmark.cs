using BenchmarkDotNet.Attributes;

namespace AdventOfCode2022.ConsoleApp.Day1
{
    /*
        |    Method |     Mean |     Error |    StdDev |   Gen0 | Allocated |
        |---------- |---------:|----------:|----------:|-------:|----------:|
        | Day1Task1 | 2.091 us | 0.0323 us | 0.0302 us |      - |      40 B |
        | Day1Task2 | 1.838 us | 0.0352 us | 0.0329 us | 0.0954 |    1200 B |
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
