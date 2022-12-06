using AdventOfCode2022.ConsoleApp.Day4.Strategies;
using static AdventOfCode2022.ConsoleApp.Day4.Day4Tasks;

namespace AdventOfCode2022.ConsoleApp.Day4
{
    public class ElvesTeam
    {
        public ElvesTeam(Section leftMember, Section rightMember)
        {
            LeftMember = leftMember;
            RightMember = rightMember;
        }

        public Section LeftMember { get; }
        public Section RightMember { get; }

        public bool GetHasOverlappingRange(BaseSectionStrategy sectionStrategy)
        {
            return sectionStrategy.HasOverlap(LeftMember, RightMember);
        }
    }
}