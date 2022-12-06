using System.Text;

namespace AdventOfCode2022.ConsoleApp.Day5
{
    public sealed class Day5Tasks
    {
        public static string Task1()
        {
            string[] input = GetInputDay4();

            DockingArea dockingArea = ParseDockingArea(input);
            foreach(var instruction in ParseInstructions(input))
            {
                dockingArea.Move(instruction);
            }

            var sb = new StringBuilder();
            foreach(var kvp in dockingArea.CratesPerLine)
            {
                sb.Append(kvp.Value.Last().Id);
            }

            return sb.ToString();
        }

        private static List<MoveInstruction> ParseInstructions(string[] input)
        {
            List<MoveInstruction> moveInstructions = new(input.Length);

            int emptyIndex = GetEmptyIndex(input) + 1;
            var span = input.AsSpan();

            for (int index = emptyIndex; index < span.Length; index++)
            {
                                          //  0    1   2  3  4 5
                string line = span[index];// move 10 from 4 to 1
                string[] items = line.Split(' ');

                var moveInstruction = new MoveInstruction(ParseCharToInt(items[1]), ParseCharToInt(items[3]), ParseCharToInt(items[5]));
                moveInstructions.Add(moveInstruction);
            }

            return moveInstructions;
        }

        private static int ParseCharToInt(string s)
        {
            return int.Parse(s);
        }
        private static int GetEmptyIndex(string[] input)
        {
            Span<string> span = input.AsSpan();

            int lineCount = span.Length;
            for (int i = 0; i < lineCount; i++)
            {
                if (string.IsNullOrEmpty(span[i]))
                {
                    return i;
                }
            }

            return -1;
        }

        private static DockingArea ParseDockingArea(string[] input)
        {
            // Get line break index
            int lanesLineIndex = GetEmptyIndex(input) - 1;

            // Move upwards
            List<int> lanes = input[lanesLineIndex].Trim().Split(' ').Where(x => !string.IsNullOrEmpty(x)).Select(int.Parse).ToList();
            DockingArea dockingArea = new(lanes.Count);

            for (int i = lanesLineIndex; i-- > 0;)
            {
                foreach (var kvp in ParseCharacterCrateForLine(input[i]))
                {
                    dockingArea.AddToStack(kvp.Key, kvp.Value);
                }
            }

            return dockingArea;
        }

        private static Dictionary<int, char> ParseCharacterCrateForLine(string linefeed)
        {
            var dictionary = new Dictionary<int, char>();

            int previousIndex = 0;
            int index = 0;
            int laneCounter = 0;
            while (GetIndexOfNextBlock(index, linefeed, out int foundIndex))
            {
                string itemInLine = linefeed.Substring(foundIndex + 1, 1);

                var diffInIndex = foundIndex - previousIndex;
                if (diffInIndex == 0)
                {
                    laneCounter = 1;
                }
                if (diffInIndex != 0)
                {
                    if (laneCounter == 0) laneCounter++;
                    laneCounter += diffInIndex / 4;
                }

                dictionary.Add(laneCounter, itemInLine[0]);

                previousIndex = foundIndex;
                index = foundIndex + 1;
            }

            return dictionary;
        }

        private static bool GetIndexOfNextBlock(int startWith, string line, out int indexOut)
        {
            indexOut = -1;

            if (startWith >= line.Length)
                return false;

            for (int i = startWith; i < line.Length; i++)
            {
                var c = line[i];
                indexOut = i;
                if (c == '[') return true;
            }

            return false;
        }

        private static string[] GetInputDay4()
        {
            return File.ReadAllLines("Day5/Day5Input1.txt");
        }
    }
}
