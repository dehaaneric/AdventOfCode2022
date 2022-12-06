using static AdventOfCode2022.ConsoleApp.Day4.Day4Tasks;

namespace AdventOfCode2022.ConsoleApp.Day4.Strategies
{
    public class Task2PartiallyContainStrategy : BaseSectionStrategy
    {
        public override bool HasOverlap(Section LeftMember, Section RightMember)
        {
            List<int> leftRange = LeftMember.Coordinates;
            List<int> rightRange = RightMember.Coordinates;

            return leftRange.Intersect(rightRange).Any();
        }
    }
}
