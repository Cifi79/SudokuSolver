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
            Board SudokuBoard = new Board(DimensionOption.Values9);

            //fill some cells
            SudokuBoard.Cells[0].CorrectValue = 4;
            SudokuBoard.Cells[1].CorrectValue = 0;
            SudokuBoard.Cells[2].CorrectValue = 0;
            SudokuBoard.Cells[3].CorrectValue = 0;
            SudokuBoard.Cells[4].CorrectValue = 3;
            SudokuBoard.Cells[5].CorrectValue = 2;
            SudokuBoard.Cells[6].CorrectValue = 0;
            SudokuBoard.Cells[7].CorrectValue = 0;
            SudokuBoard.Cells[8].CorrectValue = 8;
            //
            SudokuBoard.Cells[9].CorrectValue = 0;
            SudokuBoard.Cells[10].CorrectValue = 0;
            SudokuBoard.Cells[11].CorrectValue = 0;
            SudokuBoard.Cells[12].CorrectValue = 0;
            SudokuBoard.Cells[13].CorrectValue = 0;
            SudokuBoard.Cells[14].CorrectValue = 0;
            SudokuBoard.Cells[15].CorrectValue = 0;
            SudokuBoard.Cells[16].CorrectValue = 0;
            SudokuBoard.Cells[17].CorrectValue = 0;
            //
            SudokuBoard.Cells[18].CorrectValue = 0;
            SudokuBoard.Cells[19].CorrectValue = 0;
            SudokuBoard.Cells[20].CorrectValue = 0;
            SudokuBoard.Cells[21].CorrectValue = 0;
            SudokuBoard.Cells[22].CorrectValue = 0;
            SudokuBoard.Cells[23].CorrectValue = 0;
            SudokuBoard.Cells[24].CorrectValue = 0;
            SudokuBoard.Cells[25].CorrectValue = 0;
            SudokuBoard.Cells[26].CorrectValue = 0;
            //
            SudokuBoard.Cells[27].CorrectValue = 0;
            SudokuBoard.Cells[28].CorrectValue = 0;
            SudokuBoard.Cells[29].CorrectValue = 0;
            SudokuBoard.Cells[30].CorrectValue = 0;
            SudokuBoard.Cells[31].CorrectValue = 0;
            SudokuBoard.Cells[32].CorrectValue = 0;
            SudokuBoard.Cells[33].CorrectValue = 0;
            SudokuBoard.Cells[34].CorrectValue = 0;
            SudokuBoard.Cells[35].CorrectValue = 0;
            //
            SudokuBoard.Cells[36].CorrectValue = 0;
            SudokuBoard.Cells[37].CorrectValue = 0;
            SudokuBoard.Cells[38].CorrectValue = 0;
            SudokuBoard.Cells[39].CorrectValue = 0;
            SudokuBoard.Cells[40].CorrectValue = 0;
            SudokuBoard.Cells[41].CorrectValue = 0;
            SudokuBoard.Cells[42].CorrectValue = 0;
            SudokuBoard.Cells[43].CorrectValue = 0;
            SudokuBoard.Cells[44].CorrectValue = 0;
            //                                   0
            SudokuBoard.Cells[45].CorrectValue = 0;
            SudokuBoard.Cells[46].CorrectValue = 0;
            SudokuBoard.Cells[47].CorrectValue = 0;
            SudokuBoard.Cells[48].CorrectValue = 0;
            SudokuBoard.Cells[49].CorrectValue = 0;
            SudokuBoard.Cells[50].CorrectValue = 0;
            SudokuBoard.Cells[51].CorrectValue = 0;
            SudokuBoard.Cells[52].CorrectValue = 0;
            SudokuBoard.Cells[53].CorrectValue = 0;
            //                                   0
            SudokuBoard.Cells[54].CorrectValue = 0;
            SudokuBoard.Cells[55].CorrectValue = 0;
            SudokuBoard.Cells[56].CorrectValue = 0;
            SudokuBoard.Cells[57].CorrectValue = 0;
            SudokuBoard.Cells[58].CorrectValue = 0;
            SudokuBoard.Cells[59].CorrectValue = 0;
            SudokuBoard.Cells[60].CorrectValue = 0;
            SudokuBoard.Cells[61].CorrectValue = 0;
            SudokuBoard.Cells[62].CorrectValue = 0;
            //                                   0
            SudokuBoard.Cells[63].CorrectValue = 0;
            SudokuBoard.Cells[64].CorrectValue = 0;
            SudokuBoard.Cells[65].CorrectValue = 0;
            SudokuBoard.Cells[66].CorrectValue = 0;
            SudokuBoard.Cells[67].CorrectValue = 0;
            SudokuBoard.Cells[68].CorrectValue = 0;
            SudokuBoard.Cells[69].CorrectValue = 0;
            SudokuBoard.Cells[70].CorrectValue = 0;
            SudokuBoard.Cells[71].CorrectValue = 0;
            //                                   0
            SudokuBoard.Cells[72].CorrectValue = 0;
            SudokuBoard.Cells[73].CorrectValue = 0;
            SudokuBoard.Cells[74].CorrectValue = 0;
            SudokuBoard.Cells[75].CorrectValue = 0;
            SudokuBoard.Cells[76].CorrectValue = 0;
            SudokuBoard.Cells[77].CorrectValue = 0;
            SudokuBoard.Cells[78].CorrectValue = 0;
            SudokuBoard.Cells[79].CorrectValue = 0;
            SudokuBoard.Cells[80].CorrectValue = 0;


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
                        tryAgain = false;
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
