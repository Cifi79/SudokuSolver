using SudokuCore.Elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MainWindow
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Board mainBoard = new Board(DimensionOption.Values9);

        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnStart_Click(object sender, RoutedEventArgs e)
        {
            mainBoard = new Board(DimensionOption.Values9);

            //inizializzazione griglia
            MainBoard.RowDefinitions.Clear();
            for (int i = 0; i < 9; i++)
            {
                MainBoard.RowDefinitions.Add(new RowDefinition());
                MainBoard.ColumnDefinitions.Add(new ColumnDefinition());
            }
        }

        private void MainBoard_MouseUp(object sender, MouseButtonEventArgs e)
        {
            
        }

        private void BtnSolve_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
