namespace AdventOfCode2022.ConsoleApp.Day4
{
    public sealed partial class Day4Tasks
    {
        public class Section
        {
            public Section(List<int> coordinates)
            {
                Coordinates = coordinates;
            }

            public List<int> Coordinates { get; }

            public static Section Parse(int start, int end)
            {
                var list = new List<int>(end - start);
                
                for (int index = start; index <= end; index++)
                {
                    list.Add(index);
                }

                return new Section(list);
            }
        }
    }
}