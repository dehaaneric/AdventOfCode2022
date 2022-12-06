namespace AdventOfCode2022.ConsoleApp.Day5
{
    public struct MoveInstruction
    {
        public MoveInstruction(int itemsToMove, int fromLine, int toLine)
        {
            ItemsToMove = itemsToMove;
            FromLine = fromLine;
            ToLine = toLine;
        }

        public int ItemsToMove { get; }
        public int FromLine { get; }
        public int ToLine { get; }
    }
}
