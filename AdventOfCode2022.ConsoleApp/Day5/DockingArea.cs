namespace AdventOfCode2022.ConsoleApp.Day5
{
    public class DockingArea
    {
        private Dictionary<int, List<Crate>> _cratesPerLine;
        public DockingArea(int numberOfLanes)
        {
            _cratesPerLine = new Dictionary<int, List<Crate>>(numberOfLanes);

            foreach (var lineId in Enumerable.Range(1, numberOfLanes))
            {
                _cratesPerLine.Add(lineId, new List<Crate>());
            }
        }

        internal void AddToStack(int line, char value)
        {
            _cratesPerLine[line].Add(new Crate(value));
        }

        internal void Move(MoveInstruction instruction)
        {
            for (int index = 0; index < instruction.ItemsToMove; index++)
            {
                Crate crateOnTopOfPile = _cratesPerLine[instruction.FromLine].Last();
                _cratesPerLine[instruction.FromLine].RemoveAt(_cratesPerLine[instruction.FromLine].Count - 1);

                _cratesPerLine[instruction.ToLine].Add(crateOnTopOfPile);
            }
        }

        public IReadOnlyDictionary<int, List<Crate>> CratesPerLine => _cratesPerLine;
    }
}
