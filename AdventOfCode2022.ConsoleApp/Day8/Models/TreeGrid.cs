using System.Net.Http.Headers;

namespace AdventOfCode2022.ConsoleApp.Day8.Models
{
    public class TreeGrid
    {
        public TreeGrid(int height, int width)
        {
            Cells = new Cell[height, width];
        }
        public Cell[,] Cells { get; }

        public int GetWidth() => Cells.GetLength(1);
        public int GetHeight() => Cells.GetLength(0);

        internal Cell GetValue(int heightIndex, int cellX)
        {
            return Cells[heightIndex, cellX];
        }

        internal List<Cell> GetValuesForRow(int rowIndex)
        {
            int widthSize = GetWidth();
            List<Cell> ints = new List<Cell>(widthSize);
            for (int index = 0; index < widthSize; index++)
            {
                ints.Add(Cells[rowIndex, index]);
            }
            return ints;
        }
        internal List<Cell> GetValuesForColumn(int columnIndex)
        {
            int heightSize = GetHeight();
            List<Cell> ints = new List<Cell>(heightSize);
            for (int index = 0; index < heightSize; index++)
            {
                ints.Add(Cells[index, columnIndex]);
            }
            return ints;
        }
        internal void SetValue(int lineIndex, int charIndex, Cell cell)
        {
            Cells[lineIndex, charIndex] = cell;
        }

        internal IEnumerable<Cell> GetVisibleCells()
        {
            for (int rowIndex = 0; rowIndex < GetHeight(); rowIndex++)
            {
                for (int colIndex = 0; colIndex < GetWidth(); colIndex++)
                {
                    var cell = Cells[rowIndex, colIndex];
                    if (cell.IsVisible.GetValueOrDefault(false))
                    {
                        yield return cell;
                    }
                }
            }
        }
        internal IEnumerable<Cell> GetCells()
        {
            for (int rowIndex = 0; rowIndex < GetHeight(); rowIndex++)
            {
                for (int colIndex = 0; colIndex < GetWidth(); colIndex++)
                {
                    var cell = Cells[rowIndex, colIndex];
                    yield return cell;
                }
            }
        }

        public class Coordinates
        {
            public Coordinates(int y, int x, bool isOuter)
            {
                Y = y;
                X = x;
                IsOuter = isOuter;
            }

            public int Y { get; }
            public int X { get; }
            public bool IsOuter { get; }
        }
        public class ScenicScore
        {
            public int Left { set; get; }
            public int Right { set; get; }
            public int Up { set; get; }
            public int Down { set; get; }
            public int Total => Left * Right * Up * Down;
        }

        public class Cell
        {
            public Cell(Coordinates coordinates, int value)
            {
                Coordinates = coordinates;
                Value = value;
            }

            public Coordinates Coordinates { get; }
            public int Value { get; }
            private bool? _isVisible = null;
            public bool? IsVisible
            {
                get
                {
                    if (this.Coordinates.IsOuter) return true;
                    return _isVisible;
                }
                set { _isVisible = value; }
            }
            public bool? VisibleX { get; private set; }
            public bool? VisibleY { get; private set; }
            public void SetVisabilityX(bool isVisible)
            {
                VisibleX = isVisible;
            }
            public void SetVisabilityY(bool isVisible)
            {
                VisibleY = isVisible;
            }

            internal void SetVisible()
            {
                IsVisible = true;
            }

            internal void SetHidden()
            {
                IsVisible = false;
            }

            public ScenicScore ScenicScore { get; } = new ScenicScore();
        }
    }
}