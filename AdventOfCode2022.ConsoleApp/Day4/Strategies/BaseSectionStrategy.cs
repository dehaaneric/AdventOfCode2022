using static AdventOfCode2022.ConsoleApp.Day4.Day4Tasks;

namespace AdventOfCode2022.ConsoleApp.Day4.Strategies
{
    public abstract class BaseSectionStrategy
    {
        public abstract bool HasOverlap(Section left, Section right);
    }
}
