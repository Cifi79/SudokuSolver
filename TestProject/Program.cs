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
            SudokuBoard.Cells[1].CorrectValue = 1;
            SudokuBoard.Cells[2].CorrectValue = 2;
            SudokuBoard.Cells[3].CorrectValue = 3;
            SudokuBoard.Cells[4].CorrectValue = 4;
            SudokuBoard.Cells[5].CorrectValue = 5;
            SudokuBoard.Cells[6].CorrectValue = 6;
            SudokuBoard.Cells[7].CorrectValue = 7;
            SudokuBoard.Cells[8].CorrectValue = 8;

            SudokuBoard.Cells[31].CorrectValue = 1;
            SudokuBoard.Cells[32].CorrectValue = 2;
            SudokuBoard.Cells[33].CorrectValue = 3;
            SudokuBoard.Cells[34].CorrectValue = 4;
            SudokuBoard.Cells[35].CorrectValue = 5;
            SudokuBoard.Cells[36].CorrectValue = 6;
            SudokuBoard.Cells[37].CorrectValue = 7;
            SudokuBoard.Cells[38].CorrectValue = 8;


            //solve the sudoku
            bool unsolvedyet = true;
            int unsolvedcells = 0;
            int unsolvedcells_old = 0;
            do
            {
                //verify all the lines
                foreach (var item in SudokuBoard.Rows)
                    item.VerifyCell();

                //verify all the columns
                foreach (var item in SudokuBoard.Cols)
                    item.VerifyCell();

                //verify all the squares
                foreach (var item in SudokuBoard.Squares)
                    item.VerifyCell();

                //verify if all the cells have correct value
                unsolvedcells = 0;
                foreach (var item in SudokuBoard.Cells)
                {
                    if (item.CorrectValue == -1)
                    {
                        unsolvedcells++;
                        unsolvedyet = true;
                    }

                    if (item.CorrectValue == -2)
                    {
                        Console.WriteLine("Impossible Sudoku !!!");
                        unsolvedcells_old = unsolvedcells;

                        break;
                    }
                }

                Console.WriteLine("Unsolved cells:" + unsolvedcells);

                if (unsolvedcells == unsolvedcells_old)
                {
                    Console.WriteLine("Unresolvable Sudoku");
                    break;
                }
                else
                    unsolvedcells_old = unsolvedcells;

            } while (unsolvedyet);

            Console.ReadLine();
        }
    }
}
