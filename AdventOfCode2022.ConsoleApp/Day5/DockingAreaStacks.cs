using System.Collections.Generic;

namespace AdventOfCode2022.ConsoleApp.Day5
{
    public class DockingArea
    {
        private readonly Dictionary<int, Stack<Crate>> _cratesPerLine;
        public DockingArea(int numberOfLanes)
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
        internal void MoveMultiple(MoveInstruction instruction)
        {
            int itemsToMove = instruction.ItemsToMove;

            List<Crate> cratesToMove = new List<Crate>(itemsToMove);

            int currentStackCount = _cratesPerLine[instruction.FromLine].Count;
            int finalStackCount = currentStackCount - itemsToMove;
            while (currentStackCount > finalStackCount)
            {
                cratesToMove.Add(_cratesPerLine[instruction.FromLine].Pop());

                currentStackCount = _cratesPerLine[instruction.FromLine].Count;
            }

            for (int i = cratesToMove.Count; i-- > 0;)
            {
                _cratesPerLine[instruction.ToLine].Push(cratesToMove[i]);
            }
        }

        public IEnumerable<Stack<Crate>> LinesOfCrates => _cratesPerLine.Select(x => x.Value);
    }
}
