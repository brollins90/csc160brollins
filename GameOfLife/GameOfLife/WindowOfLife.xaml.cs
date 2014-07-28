using GameOfLife.Models;
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
using System.Windows.Shapes;
using System.Threading;
//using System.Windows.Automation.Provider;

namespace GameOfLife
{
    /// <summary>
    /// Interaction logic for WindowOfLife.xaml
    /// </summary>
    public partial class WindowOfLife : Window
    {
        public int NumberOfRows { get; set; }
        public int NumberOfColumns { get; set; }
        private Cell[,] cells;
        private bool[,] cellsThisRound;
        private Grid GameGrid;



        public WindowOfLife()
        {
            //NumberOfColumns = 10;
            //NumberOfRows = 10;
            //int counter = 0;
            //int onCount = 4;
            //cells = new Cell[NumberOfColumns,NumberOfRows];
            //cellsThisRound = new bool[NumberOfColumns, NumberOfRows];

            InitializeComponent();

            //Button b1 = new Button();
            //b1.Click += ProceedButton_Click;
            //b1.Height = 50;
            //b1.Content = "push";
            //GameControls.Children.Add(b1);


            //GameGrid = new Grid();
            //GameGrid.ShowGridLines = true;

            //for (int i = 0; i < NumberOfColumns; i++)
            //{
            //    GameGrid.ColumnDefinitions.Add(new ColumnDefinition());
            //}
            //for (int i = 0; i < NumberOfRows; i++)
            //{
            //    GameGrid.RowDefinitions.Add(new RowDefinition());
            //}
            //for (int colIndex = 0; colIndex < NumberOfColumns; colIndex++)
            //{
            //    for (int rowIndex = 0; rowIndex < NumberOfRows; rowIndex++)
            //    {
            //        Label tempLabel = new Label();
            //        Cell tempCell = new Cell();
            //        tempCell.Alive = (counter++ % onCount) == 0 ? true : false;
            //        tempLabel.DataContext = tempCell;
            //        tempLabel.Content = string.Format("{0},{1}", colIndex,rowIndex);
            //        tempLabel.MouseLeftButtonDown += Cell_Click;

            //        var bind = new Binding("Alive")
            //        {
            //            Converter = new AliveToColorConverter()
            //        };

            //        tempLabel.SetBinding(Label.BackgroundProperty, bind);

            //        GameGrid.Children.Add(tempLabel);
            //        Grid.SetColumn(tempLabel, colIndex);
            //        Grid.SetRow(tempLabel, rowIndex);
            //        cells[colIndex,rowIndex] = tempCell;
            //        //Console.WriteLine("{0}: - {1}", counter, tempCell.Alive);
            //    }
            //}
            //GameFrame.Children.Add(GameGrid);
            //this.Content = GameFrame;
        }
        
        public Cell GetCellAt(int col, int row)
        {
            if (col > -1 && col < NumberOfColumns && row > -1 && row < NumberOfRows)
            {
                return cells[col, row];
            }
            return null;
        }

        public void ProcessStep()
        {
            for (int i = 0; i < NumberOfColumns; i++) {
                for (int j = 0; j < NumberOfRows; j++) {
                    cellsThisRound[i,j] = cells[i,j].Alive;
                }
            }

            for (int colIndex = 0; colIndex < NumberOfColumns; colIndex++)
            {
                for (int rowIndex = 0; rowIndex < NumberOfRows; rowIndex++)
                {
                    Cell[] neighbors = new Cell[8];
                    neighbors[0] = GetCellAt(colIndex - 1, rowIndex - 1);
                    neighbors[1] = GetCellAt(colIndex - 0, rowIndex - 1);
                    neighbors[2] = GetCellAt(colIndex + 1, rowIndex - 1);
                    neighbors[3] = GetCellAt(colIndex + 1, rowIndex - 0);
                    neighbors[4] = GetCellAt(colIndex + 1, rowIndex + 1);
                    neighbors[5] = GetCellAt(colIndex - 0, rowIndex + 1);
                    neighbors[6] = GetCellAt(colIndex - 1, rowIndex + 1);
                    neighbors[7] = GetCellAt(colIndex - 1, rowIndex - 0);
                    
                    int nCount = 0;
                    for (int nIndex = 0; nIndex < 8; nIndex++)
                    {
                        Cell cur = neighbors[nIndex];
                        if (cur != null && cur.Alive)
                        {
                            nCount++;
                        }
                    }
                    Console.WriteLine("{0},{1}: {2}",colIndex, rowIndex, nCount);

                    switch (nCount)
                    {
                        default:
                            cellsThisRound[colIndex,rowIndex] = false;
                            break;
                        case 2:
                            if (cells[colIndex,rowIndex].Alive) {
                                cellsThisRound[colIndex,rowIndex] = true;
                            }
                            break;
                        case 3:
                            cellsThisRound[colIndex,rowIndex] = true;
                            break;
                    }
                    
                }
            }

            for (int i = 0; i < NumberOfColumns; i++)
            {
                for (int j = 0; j < NumberOfRows; j++)
                {
                    cells[i, j].Alive = cellsThisRound[i, j];
                }
            }
        }

        private void ProceedButton_Click(object sender, RoutedEventArgs e)
        {
            ProcessStep();
        }

        private void Cell_Click(object sender, EventArgs e)
        {
            Label curLabel = (Label)sender;
            Cell curCell = (Cell)curLabel.DataContext;
            curCell.Alive = (curCell.Alive) ? false : true;
        }

        private void NewGameButton_Click(object sender, RoutedEventArgs e)
        {
            GameFrame.Children.Remove(GameGrid);

            NumberOfColumns = (int)ColSlider.Value;
            NumberOfRows = (int)RowSlider.Value;
            int counter = 0;
            int onCount = 4;

            cells = new Cell[NumberOfColumns, NumberOfRows];
            cellsThisRound = new bool[NumberOfColumns, NumberOfRows];

            GameGrid = new Grid();
            GameGrid.ShowGridLines = true;

            for (int i = 0; i < NumberOfColumns; i++)
            {
                GameGrid.ColumnDefinitions.Add(new ColumnDefinition());
            }
            for (int i = 0; i < NumberOfRows; i++)
            {
                GameGrid.RowDefinitions.Add(new RowDefinition());
            }
            for (int colIndex = 0; colIndex < NumberOfColumns; colIndex++)
            {
                for (int rowIndex = 0; rowIndex < NumberOfRows; rowIndex++)
                {
                    Label tempLabel = new Label();
                    Cell tempCell = new Cell();
                    tempCell.Alive = (counter++ % onCount) == 0 ? true : false;
                    tempLabel.DataContext = tempCell;
                    tempLabel.Content = string.Format("{0},{1}", colIndex, rowIndex);
                    tempLabel.MouseLeftButtonDown += Cell_Click;

                    var bind = new Binding("Alive")
                    {
                        Converter = new AliveToColorConverter()
                    };

                    tempLabel.SetBinding(Label.BackgroundProperty, bind);

                    GameGrid.Children.Add(tempLabel);
                    Grid.SetColumn(tempLabel, colIndex);
                    Grid.SetRow(tempLabel, rowIndex);
                    cells[colIndex, rowIndex] = tempCell;
                    //Console.WriteLine("{0}: - {1}", counter, tempCell.Alive);
                }
            }
            GameFrame.Children.Add(GameGrid);
        }


    }

    public class AliveToColorConverter : IValueConverter
    {
        public static SolidColorBrush AliveBrush = new SolidColorBrush(Color.FromArgb(255, 255, 0, 0));
        public static SolidColorBrush DeadBrush = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            //Cell temp = (Cell)value;
            return (bool)value ? AliveBrush : DeadBrush;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
