using System;
using System.Collections.Generic;

namespace SudokuCore.Elements
{
    public enum DimensionOption : int
    {
        Values4 = 4,
        Values9 = 9,
        Values16 = 16
    }

    public class Board
    {
        public DimensionOption Dimension { get; set; } = DimensionOption.Values9;

        public List<Row> Rows = new List<Row>();
        public List<Column> Cols = new List<Column>();
        public List<Square> Squares = new List<Square>();
        public List<Cell> Cells = new List<Cell>();

        public Board()
        {
            CreateNewBoard();
        }

        public Board(DimensionOption dimension)
        {
            Dimension = dimension;
            CreateNewBoard();
        }

        /// <summary>
        /// This method initialize all the elements for the board
        /// </summary>
        /// <returns></returns>
        private bool CreateNewBoard()
        {
            int dim = (int)Dimension;
            int dimSQRT = (int)System.Math.Sqrt(dim);

            Rows = new List<Row>(dim);
            Cols = new List<Column>(dim);
            Squares = new List<Square>(dim);
            Cells = new List<Cell>(dim * dim);

            List<Cell> _group = new List<Cell>();

            //init cells
            for (int i = 0; i < dim * dim; i++)
            {
                Cell _cell = new Cell()
                {
                    Dimension = dim
                };

                Cells.Add(_cell);
            }

            //init rows
            for (int i = 0; i < dim; i++)
            {
                _group = new List<Cell>();

                for (int j = 0; j < dim; j++)
                {
                    _group.Add(Cells[j + i * dim]);
                }
                Rows.Add(new Row(_group));
            }

            //init cols
            for (int i = 0; i < dim; i++)
            {
                _group = new List<Cell>();

                for (int j = 0; j < dim; j++)
                {
                    _group.Add(Cells[j * dim + i]);
                }
                Cols.Add(new Column(_group));
            }

            //init square
            for (int i = 0; i < dimSQRT; i++)
            {

                for (int j = 0; j < dimSQRT; j++)
                {
                    _group = new List<Cell>();
                    for (int ii = 0; ii < dimSQRT; ii++)
                    {
                        for (int jj = 0; jj < dimSQRT; jj++)
                        {
                            _group.Add(Cells[i * dimSQRT + j * dim * dimSQRT + ii * dim + jj]);
                        }
                    }
                    Squares.Add(new Square(_group));
                }
            }


            return true;
        }
    }

    /// <summary>
    /// Class that indentify a group of cell (they can be row, col or square)
    /// </summary>
    public class GroupOfCells
    {
        List<Cell> Cells = new List<Cell>();

        /// <summary>
        /// Constructor that accept a dictionary with cells passed from the Board with its indexes
        /// </summary>
        /// <param name="groupCells"></param>
        public GroupOfCells(List<Cell> groupCells)
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
        /// <summary>
        /// Constructor that accept a dictionary with cells passed from the Board with its indexes
        /// </summary>
        /// <param name="groupCells"></param>
        public Row(List<Cell> groupCells) : base(groupCells) { }
    }

    public class Column : GroupOfCells
    {
        /// <summary>
        /// Constructor that accept a dictionary with cells passed from the Board with its indexes
        /// </summary>
        /// <param name="groupCells"></param>
        public Column(List<Cell> groupCells) : base(groupCells) { }
    }

    public class Square : GroupOfCells
    {
        /// <summary>
        /// Constructor that accept a dictionary with cells passed from the Board with its indexes
        /// </summary>
        /// <param name="groupCells"></param>
        public Square(List<Cell> groupCells) : base(groupCells) { }
    }

}
