using AdventOfCode2022.ConsoleApp.Day8.Models;
using AdventOfCode2022.ConsoleApp.Shared;
using static AdventOfCode2022.ConsoleApp.Day8.Models.TreeGrid;

namespace AdventOfCode2022.ConsoleApp.Day8
{
    internal class Day8Tasks : BaseTask
    {
        private TreeGrid _treeGrid;

        public Day8Tasks()
        {
            string[] lines = GetInput("Day8/Day8Input1.txt");

            int heightOfGrid = lines.Length;
            int widthOfGrid = lines[0].Length;

            _treeGrid = new TreeGrid(heightOfGrid, widthOfGrid);

            for (int lineIndex = 0; lineIndex < lines.Length; lineIndex++)
            {
                string line = lines[lineIndex]!;
                for (int charIndex = 0; charIndex < line.Length; charIndex++)
                {
                    char c = line[charIndex];

                    // Is visible at the beginning of end of the line
                    //bool isVisibleChar = charIndex == 0 || charIndex == line.Length - 1;
                    //bool isVisibleLine = lineIndex == 0 || lineIndex == lines.Length - 1;
                    //bool isVisible = isVisibleChar || isVisibleLine;
                    bool isOuterY = lineIndex == 0 || lineIndex == lines.Length - 1;
                    bool isOuterX = charIndex == 0 || charIndex == line.Length - 1;

                    var coordinates = new Coordinates(lineIndex, charIndex, isOuterX || isOuterY);
                    var cell = new Cell(coordinates, ParseCharToInt(c));

                    _treeGrid.SetValue(lineIndex, charIndex, cell);
                }
            }
        }

        public int Task1()
        {
            int heightCount = _treeGrid.Cells.GetLength(0);
            int widthCount = _treeGrid.Cells.GetLength(1);

            //how many trees are visible from outside the grid?

            // 1 - for each row, go from left to inner and from right to inner
            for (int rowIndex = 1; rowIndex < heightCount - 1; rowIndex++)
            {
                var row = _treeGrid.GetValuesForRow(rowIndex);

                int previousHeighest = -1;
                foreach (var cell in row)
                {
                    if (cell.IsVisible == true)
                    {
                        if (cell.Value > previousHeighest)
                            previousHeighest = cell.Value;
                        continue;
                    }

                    if (cell.Value > previousHeighest)
                    {
                        cell.SetVisible();
                    }
                    else
                    {
                        cell.SetHidden();
                    }

                    previousHeighest = cell.Value;
                }

                previousHeighest = -1;
                // Move to left to see if its hidden <---<---<---
                for (int cellX = (widthCount); cellX-- > 0;)
                {
                    var cell = row[cellX];

                    if (cell.IsVisible == true)
                    {
                        if (cell.Value > previousHeighest)
                            previousHeighest = cell.Value;
                        continue;
                    }

                    {
                        cell.SetVisible();
                    }

                    if (cell.Value > previousHeighest)
                        previousHeighest = cell.Value;
                }
            }

            for (int colIndex = 1; colIndex < widthCount - 1; colIndex++)
            {
                var verticalCells = _treeGrid.GetValuesForColumn(colIndex);

                int previousHeighest = -1;

                for (int heightIndex = 0; heightIndex < heightCount - 1; heightIndex++)
                {
                    var cell = verticalCells[heightIndex];

                    if (cell.IsVisible == true)
                    {
                        if (cell.Value > previousHeighest)
                            previousHeighest = cell.Value;
                        continue;
                    }

                    {
                        cell.SetVisible();
                    }

                    if (cell.Value > previousHeighest)
                        previousHeighest = cell.Value;
                }

                previousHeighest = -1;
                for (int heightIndex = (heightCount); heightIndex-- > 0;)
                {
                    var cell = verticalCells[heightIndex];

                    if (cell.IsVisible == true)
                    {
                        if (cell.Value > previousHeighest)
                            previousHeighest = cell.Value;
                        continue;
                    }

                    {
                        cell.SetVisible();
                    }

                    if (cell.Value > previousHeighest)
                        previousHeighest = cell.Value;
                }
            }

            IEnumerable<Cell> visibleCells = _treeGrid.GetVisibleCells();

            int count = visibleCells.Count();
            return count;
        }

        public void Task1_attempt1()
        {
            int heightCount = _treeGrid.Cells.GetLength(0);
            int widthCount = _treeGrid.Cells.GetLength(1);
            int totalOutsideTrees = ((heightCount * 2) + (widthCount * 2)) - 4; // -4 corners

            // Loop through rows
            for (int heightIndex = 1; heightIndex < (heightCount - 1); heightIndex++)
            {
                List<Cell> valuesForRow = _treeGrid.GetValuesForRow(heightIndex);
                var nonOuterValues = valuesForRow.Where(x => !x.Coordinates.IsOuter);

                foreach (var tree in nonOuterValues)
                {
                    bool isHiddenFromLeft = false;
                    bool isHiddenFromRight = false;
                    // Move to left to see if its hidden <---<---<---
                    for (int cellX = (tree.Coordinates.X); cellX-- > 0;)
                    {
                        Cell cell = _treeGrid.GetValue(heightIndex, cellX);
                        if (cell.Value >= tree.Value)
                        {
                            // On the left there is an higher value so it's hidden from the left
                            isHiddenFromLeft = true;
                            break;
                        }
                    }

                    // Move to right to see if its hidden  --->--->--->
                    for (int cellX = tree.Coordinates.X + 1; cellX < _treeGrid.GetWidth(); cellX++)
                    {
                        Cell cell = _treeGrid.GetValue(heightIndex, cellX);
                        if (cell.Value >= tree.Value)
                        {
                            // On the right there is an higher value so it's hidden from the right
                            isHiddenFromRight = true;
                            break;
                        }
                    }

                    if (isHiddenFromLeft && isHiddenFromRight)
                    {
                        tree.SetVisabilityX(false);
                    }
                }
            }

            // Loop through columns
            for (int widthIndex = 1; widthIndex < (widthCount - 1); widthIndex++)
            {
                List<Cell> valuesForColumn = _treeGrid.GetValuesForColumn(widthIndex);
                var nonOuterValues = valuesForColumn.Where(x => !x.Coordinates.IsOuter);

                foreach (var tree in nonOuterValues)
                {
                    bool isHiddenFromTop = false;
                    bool isHiddenFromBottom = false;
                    // Move to up to see if its hidden <---<---<---
                    for (int cellY = (tree.Coordinates.Y); cellY-- >= 0;)
                    {
                        Cell cell = _treeGrid.GetValue(cellY, widthIndex);
                        if (cell.Value >= tree.Value)
                        {
                            // On the left there is an higher value so it's hidden from the left
                            isHiddenFromTop = true;
                            break;
                        }
                    }

                    // Move to right to see if its hidden  --->--->--->
                    for (int cellY = tree.Coordinates.Y + 1; cellY < _treeGrid.GetWidth(); cellY++)
                    {
                        Cell cell = _treeGrid.GetValue(cellY, widthIndex);
                        if (cell.Value >= tree.Value)
                        {
                            // On the right there is an higher value so it's hidden from the right
                            isHiddenFromBottom = true;
                            break;
                        }
                    }

                    if (isHiddenFromTop && isHiddenFromBottom)
                    {
                        tree.SetVisabilityX(false);
                    }
                }
            }
        }

        private static int ParseCharToInt(char c)
        {
            return c - '0';
        }

        internal int Task2()
        {
            int heightCount = _treeGrid.Cells.GetLength(0);
            int widthCount = _treeGrid.Cells.GetLength(1);

            // scenic score

            // 1 - for each row, go from left to inner and from right to inner
            for (int rowIndex = 1; rowIndex < heightCount - 1; rowIndex++)
            {
                var cellsInRow = _treeGrid.GetValuesForRow(rowIndex);

                for (int colIndex = 0; colIndex < cellsInRow.Count; colIndex++)
                {
                    Cell cell = cellsInRow[colIndex];
                    if (cell.Coordinates.IsOuter)
                        continue;

                    cell.ScenicScore.Left = GetVisibleOnLeft(cellsInRow, colIndex);
                    cell.ScenicScore.Right = GetVisibleOnRight(cellsInRow, colIndex);
                }
            }

            for (int colIndex = 1; colIndex < widthCount - 1; colIndex++)
            {
                var cellsInColumn = _treeGrid.GetValuesForColumn(colIndex);

                for (int rowIndex = 0; rowIndex < heightCount - 1; rowIndex++)
                {
                    Cell cell = cellsInColumn[rowIndex];
                    if (cell.Coordinates.IsOuter)
                        continue;

                    cell.ScenicScore.Up = GetVisibleAbove(cellsInColumn, rowIndex);
                    cell.ScenicScore.Down = GetVisibleDown(cellsInColumn, rowIndex);
                }
            }

            int highestScenicScore = _treeGrid.GetCells().Max(x => x.ScenicScore.Total);
            return highestScenicScore;
        }

        private int GetVisibleDown(List<Cell> cellsInColumn, int viewingRowIndex)
        {
            var cell = cellsInColumn[viewingRowIndex];

            int downScore = 0;
            for (int rowIndex = (viewingRowIndex + 1); rowIndex < cellsInColumn.Count; rowIndex++)
            {
                if (cellsInColumn[rowIndex].Value < cell.Value)
                {
                    downScore++;
                }
                else if (cellsInColumn[rowIndex].Value == cell.Value)
                {
                    downScore++;
                    break;
                }
                else if (cellsInColumn[rowIndex].Value > cell.Value)
                {
                    downScore++;
                    break;
                }
                else
                {
                    break;
                }
            }

            return downScore;
        }
        private int GetVisibleAbove(List<Cell> cellsInColumn, int viewingRowIndex)
        {
            // Go up!
            var cell = cellsInColumn[viewingRowIndex];

            int upScore = 0;
            for (int rowIndex = (viewingRowIndex); rowIndex-- > 0;)
            {
                if (cellsInColumn[rowIndex].Value < cell.Value)
                {
                    upScore++;
                }
                else if (cellsInColumn[rowIndex].Value == cell.Value)
                {
                    upScore++;
                    break;
                }
                else if (cellsInColumn[rowIndex].Value > cell.Value)
                {
                    upScore++;
                    break;
                }
                else
                {
                    break;
                }
            }

            return upScore;
        }

        private int GetVisibleOnRight(List<Cell> row, int viewingCellColIndex)
        {
            var cell = row[viewingCellColIndex];

            int rightScore = 0;
            for (int columnIndex = (viewingCellColIndex + 1); columnIndex < row.Count; columnIndex++)
            {
                if (row[columnIndex].Value < cell.Value)
                {
                    rightScore++;
                }
                else if (row[columnIndex].Value == cell.Value)
                {
                    rightScore++;
                    break;
                }
                else if (row[columnIndex].Value > cell.Value)
                {
                    rightScore++;
                    break;
                }
                else
                {
                    break;
                }
            }

            return rightScore;
        }
        private int GetVisibleOnLeft(List<Cell> row, int viewingCellColIndex)
        {
            var cell = row[viewingCellColIndex];

            int leftScore = 0;
            for (int columnIndex = (viewingCellColIndex); columnIndex-- > 0;)
            {
                if (row[columnIndex].Value < cell.Value)
                {
                    leftScore++;
                }
                else if (row[columnIndex].Value == cell.Value)
                {
                    leftScore++;
                    break;
                }
                else if (row[columnIndex].Value > cell.Value)
                {
                    leftScore++;
                    break;
                }
                else
                {
                    break;
                }
            }

            return leftScore;
        }
    }
}
