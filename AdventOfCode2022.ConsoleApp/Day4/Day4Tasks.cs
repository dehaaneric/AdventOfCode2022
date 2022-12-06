using AdventOfCode2022.ConsoleApp.Day4.Strategies;

namespace AdventOfCode2022.ConsoleApp.Day4
{
    public sealed partial class Day4Tasks
    {
        private static List<ElvesTeam> ParseInput()
        {
            string[] linesFromFile = GetInputDay4();

            var elveTeams = new List<ElvesTeam>(linesFromFile.Length);

            foreach (var line in linesFromFile)
            {
                var span = line.AsSpan();
                int commaSplitIndex = span.IndexOf(',');

                var leftAreaSlice = span.Slice(0, commaSplitIndex);
                var rightAreaSlice = span.Slice(commaSplitIndex + 1, (span.Length - commaSplitIndex - 1));

                var left = ParseStartAndEnd(leftAreaSlice);
                var right = ParseStartAndEnd(rightAreaSlice);

                var elvesTeam = new ElvesTeam(left, right);
                elveTeams.Add(elvesTeam);
            }

            return elveTeams;
        }

        private static Section ParseStartAndEnd(ReadOnlySpan<char> span)
        {
            int dashSplitIndexRight = span.IndexOf('-');

            int start = int.Parse(span.Slice(0, dashSplitIndexRight));
            int end = int.Parse(span.Slice(dashSplitIndexRight + 1, span.Length - dashSplitIndexRight - 1));

            return Section.Parse(start, end);
        }

        private static string[] GetInputDay4()
        {
            return File.ReadAllLines("Day4/Day4Input.txt");
        }

        internal int Task1()
        {
            return GetCountByStrategy(new Task1FullyContainStrategy());
        }

        internal int Task2()
        {
            return GetCountByStrategy(new Task2PartiallyContainStrategy());
        }

        private static int GetCountByStrategy(BaseSectionStrategy baseSectionStrategy)
        {
            List<ElvesTeam> elvesTeams = ParseInput();

            int counter = 0;
            foreach (var elvesTeam in elvesTeams)
            {
                if (elvesTeam.GetHasOverlappingRange(baseSectionStrategy))
                {
                    counter++;
                }
            }

            return counter;
        }
    }
}
