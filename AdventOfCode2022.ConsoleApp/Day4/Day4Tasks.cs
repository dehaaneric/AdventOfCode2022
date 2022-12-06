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
                /*  2-4,6-8
                    2-3,4-5
                    5-7,7-9
                    2-8,3-7
                    6-6,4-6
                    2-6,4-8 */

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
            List<ElvesTeam> elvesTeams = ParseInput();

            var strategyToUse = new Task1FullyContainStrategy();

            int counter = 0;
            foreach (var elvesTeam in elvesTeams)
            {
                if (elvesTeam.GetHasOverlappingRange(strategyToUse))
                {
                    counter++;
                }
            }

            return counter;
        }
        internal int Task2()
        {
            List<ElvesTeam> elvesTeams = ParseInput();

            var strategyToUse = new Task2PartiallyContainStrategy();

            int counter = 0;
            foreach (var elvesTeam in elvesTeams)
            {
                if (elvesTeam.GetHasOverlappingRange(strategyToUse))
                {
                    counter++;
                }
            }

            return counter;
        }
    }
}
