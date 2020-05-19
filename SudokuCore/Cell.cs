using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuCore.Elements
{
    public class Cell
    {
        private int dimension = 9;

        public int Dimension
        {
            get { return dimension; }
            set
            {


                dimension = value;
                RefreshDimension();
            }
        }

        /// <summary>
        /// This read-only property return the value of a cell if it is sure
        /// Otherwise return -1
        /// </summary>
        public int CorrectValue
        {
            get
            {
                var items = Values.Where(p => p.Value == true).ToList();

                //impossible sudoku
                if (items.Count == 0)
                    return -2;

                if (items.Count > 1)
                    return -1;
                else
                    return items[0].Key;
            }

            set
            {
                for (int i = 1; i <= dimension; i++)
                    Values[i] = (i == value);
            }
        }

        /// <summary>
        /// All the Values that can be the cell.
        /// True is a valid value
        /// False is not a valid value
        /// </summary>
        public Dictionary<int, bool> Values { get; set; } = new Dictionary<int, bool>();

        public Cell()
        {
            RefreshDimension();
        }

        /// <summary>
        /// Initialize the values by the dimension
        /// </summary>
        private void RefreshDimension()
        {
            Values.Clear();

            for (int i = 1; i <= dimension; i++)
                Values.Add(i, true);
        }

        /// <summary>
        /// This method reset the value passed inside the dictionary
        /// </summary>
        /// <param name="value"></param>
        /// <returns>False if value is not inside the range of dimension</returns>
        public bool ResetValue(int value)
        {
            if (value < 1 || value > dimension)
                return false;
            Values[value] = false;

            return true;
        }

        public override string ToString()
        {
            string val = "";
            foreach (var item in Values)
            {
                if (item.Value)
                    val += $"{item.Key},";
            }
            return val;
        }
    }

}
