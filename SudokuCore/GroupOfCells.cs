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

    public enum BoardSolutionState
    {
        Unsolved,
        Solved,
        ImpossibleBoard,
        ImpossibleSolution,
    }

    public class Board
    {
        public DimensionOption Dimension { get; set; } = DimensionOption.Values9;

        public int SolvedCells
        {
            get
            {
                int _solvedCells = 0;
                foreach (var item in Cells)
                {
                    if (item.CorrectValue > 0)
                        _solvedCells++;
                }
                return _solvedCells;
            }
        }

        public List<Row> Rows { get; private set; } = new List<Row>();
        public List<Column> Cols { get; private set; } = new List<Column>();
        public List<Square> Squares { get; private set; } = new List<Square>();
        public List<Cell> Cells { get; private set; } = new List<Cell>();

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

        /// <summary>
        /// This method check one time lines,columns and squares
        /// </summary>
        /// <returns></returns>
        public BoardSolutionState SolveBoard()
        {
            int _solvedCells = SolvedCells;

            //verify all the lines
            foreach (var item in Rows)
                item.VerifyCells();

            //verify all the columns
            foreach (var item in Cols)
                item.VerifyCells();

            //verify all the squares
            foreach (var item in Squares)
                item.VerifyCells();

            if (_solvedCells == SolvedCells)
                return BoardSolutionState.ImpossibleSolution;

            return VerifyBoardSolution();
        }

        /// <summary>
        ///verify if all the cells have correct value
        /// </summary>
        /// <returns></returns>
        private BoardSolutionState VerifyBoardSolution()
        {
            bool unsolvedyet = false;
            foreach (var item in Cells)
            {
                if (item.CorrectValue == -1)
                    unsolvedyet = true;

                if (item.CorrectValue == -2)
                    return BoardSolutionState.ImpossibleSolution;
            }

            if (unsolvedyet)
                return BoardSolutionState.Unsolved;
            else
                return BoardSolutionState.Solved;
        }
    }

    /// <summary>
    /// Class that indentify a group of cell (they can be row, col or square)
    /// </summary>
    public class GroupOfCells
    {
        public List<Cell> Cells { get; private set; } = new List<Cell>();

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
        public bool VerifyCells()
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