using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AdventOfCode2022.ConsoleApp.Day4.Day4Tasks;

namespace AdventOfCode2022.ConsoleApp.Day4.Strategies
{
    public class Task1FullyContainStrategy : BaseSectionStrategy
    {
        public override bool HasOverlap(Section LeftMember, Section RightMember)
        {
            List<int> leftRange = LeftMember.Coordinates;
            int leftMin = leftRange.Min();
            int leftMax = leftRange.Max();

            List<int> rightRange = RightMember.Coordinates;
            int rightMin = rightRange.Min();
            int rightMax = rightRange.Max();

            //5-7,7-9
            bool left1 = leftMin >= rightMin;
            bool left2 = leftMax <= rightMax;
            bool hasOverlapLeft = left1 && left2;

            bool right1 = rightMin >= leftMin;
            bool right2 = rightMax <= leftMax;
            bool hasOverlapRight = right1 && right2;

            return hasOverlapLeft || hasOverlapRight;
        }
    }
}
