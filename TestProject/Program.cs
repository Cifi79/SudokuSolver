using SudokuCore.Elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    class Program
    {
        static void Main(string[] args)
        {
            //init board
            Board SudokuBoard = new Board(DimensionOption.Values4);

            //fill some cells
            SudokuBoard.Cells[0].CorrectValue = 4;
            SudokuBoard.Cells[3].CorrectValue = 2;
            SudokuBoard.Cells[5].CorrectValue = 2;
            SudokuBoard.Cells[6].CorrectValue = 1;

            //SudokuBoard.Cells[12].CorrectValue = 2;
            //SudokuBoard.Cells[13].CorrectValue = 3;
            //SudokuBoard.Cells[14].CorrectValue = 4;
            SudokuBoard.Cells[15].CorrectValue = 1;


            //solve the sudoku
            bool tryAgain = true;
            do
            {
                switch (SudokuBoard.SolveBoard())
                {
                    case BoardSolutionState.Unsolved:
                        Console.WriteLine("Solved cells:" + SudokuBoard.SolvedCells);
                        tryAgain = true;
                        break;
                    case BoardSolutionState.Solved:
                        Console.WriteLine("BOARD SOLVED !!!");
                        tryAgain = false;
                        break;
                    case BoardSolutionState.ImpossibleBoard:
                        Console.WriteLine("This board is not possible");
                        tryAgain = true;
                        break;
                    case BoardSolutionState.ImpossibleSolution:
                        Console.WriteLine("Unresolvable Sudoku");
                        tryAgain = true;
                        break;
                    default:
                        break;
                }

                //Console.ReadLine();

            } while (tryAgain);


            foreach (var row in SudokuBoard.Rows)
            {
                foreach (var cell in row.Cells)
                {
                    Console.Write($"\t{cell.CorrectValue}");
                }
                Console.Write("\n\r");
                Console.Write("\n\r");
            }

            Console.ReadLine();
        }
    }
}
