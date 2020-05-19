using System.Collections.Generic;

namespace SudokuCore.Elements
{
    /// <summary>
    /// Class that indentify a group of cell (they can be row, col or square)
    /// </summary>
    public class GroupOfCells
    {
        Dictionary<int, Cell> Cells = new Dictionary<int, Cell>();

        public GroupOfCells(Dictionary<int,Cell> groupCells)
        {
            Cells = groupCells;
        }

        /// <summary>
        /// This method verify if a cell has a certanly value then remove this value from the other cell
        /// </summary>
        /// <returns></returns>
        public bool VerifyCell()
        {
            for (int i = 0; i < Cells.Count; i++)
            {
                if (Cells[i].CorrectValue > 0)
                    for (int j = 0; j < Cells.Count; j++)
                    {
                        if (j == i)
                            continue;
                        Cells[j].ResetValue(Cells[i].CorrectValue);
                    }
            }
            return true;
        }
    }
    public class Row : GroupOfCells
    {
        public Row(Dictionary<int, Cell> groupCells) : base(groupCells)
        {
        }
    }

    public class Column : GroupOfCells
    {
        public Column(Dictionary<int, Cell> groupCells) : base(groupCells)
        {
        }
    }

    public class Square : GroupOfCells
    {
        public Square(Dictionary<int, Cell> groupCells) : base(groupCells)
        {
        }
    }

}
