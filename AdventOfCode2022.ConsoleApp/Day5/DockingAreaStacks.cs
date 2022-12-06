namespace AdventOfCode2022.ConsoleApp.Day5
{
    public class DockingAreaStack
    {
        private Dictionary<int, Stack<Crate>> _cratesPerLine;
        public DockingAreaStack(int numberOfLanes)
        {
            _cratesPerLine = new Dictionary<int, Stack<Crate>>(numberOfLanes);

            foreach (var lineId in Enumerable.Range(1, numberOfLanes))
            {
                _cratesPerLine.Add(lineId, new Stack<Crate>());
            }
        }

        internal void AddToStack(int line, char value)
        {
            _cratesPerLine[line].Push(new Crate(value));
        }

        internal void Move(MoveInstruction instruction)
        {
            for (int index = 0; index < instruction.ItemsToMove; index++)
            {
                Crate crateOnTopOfPile = _cratesPerLine[instruction.FromLine].Pop();
                _cratesPerLine[instruction.ToLine].Push(crateOnTopOfPile);
            }
        }

        public IEnumerable<Stack<Crate>> LinesOfCrates => _cratesPerLine.Select(x => x.Value);
    }
}
