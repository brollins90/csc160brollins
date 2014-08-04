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
using System.Numerics;
using System.Windows.Threading;
using System.IO;
using GameOfLife.Extensions;
using Microsoft.Win32;
//using System.Windows.Automation.Provider;

namespace GameOfLife
{

    /// <summary>
    /// Interaction logic for WindowOfLife.xaml
    /// </summary>
    public partial class WindowOfLife : Window
    {

        public BigInteger[] GameRows;
        public BigInteger[] GameRowsThis;

        private DispatcherTimer Timer;
        private Random _Random;
        
        public int NumberOfRows { get; set; }
        public int NumberOfColumns { get; set; }
        private Cell[,] cells;
        private bool[,] cellsThisRound;
        private Grid GameGrid;


        public WindowOfLife()
        {
            InitializeComponent();
            Timer = new DispatcherTimer();
            Timer.Interval = TimeSpan.FromSeconds(1);
            Timer.Tick += Timer_Tick;
            _Random = new Random();
        }

        void Timer_Tick(object sender, EventArgs e)
        {
            ProcessStep();
        }
        
        public Cell GetCellAt(int col, int row)
        {
            if (col > -1 && col < NumberOfColumns && row > -1 && row < NumberOfRows)
            {
                return cells[col, row];
            }
            return null;
        }

        public void PrepareGameRows()
        {

            for (int rowIndex = 0; rowIndex < NumberOfRows; rowIndex++)
            {
                for (int colIndex = 0; colIndex < NumberOfColumns; colIndex++)
                {
                    if (cells[rowIndex, colIndex].Alive)
                    {
                        GameRows[rowIndex].SetBit(colIndex, out GameRows[rowIndex]);
                    }
                    else
                    {
                        GameRows[rowIndex].UnsetBit(colIndex, out GameRows[rowIndex]);
                    }
                }
                GameRowsThis[rowIndex] = BigInteger.Parse(GameRows[rowIndex].ToString());
            }
        }

        public void ProcessStep()
        {
            PrepareGameRows();

            //GameRowsThis = GameRows;

            for (int rowIndex = 0; rowIndex < NumberOfRows; rowIndex++)
            {
                //Console.WriteLine(GameRows[rowIndex].ToBinaryString());
                int rowAbove = rowIndex - 1;
                int rowBelow = rowIndex + 1;

                for (int colIndex = 0; colIndex < NumberOfColumns; colIndex++)
                {
                    int left = colIndex - 1;
                    int right = colIndex + 1;

                    int nCount = 0;
                    if (rowAbove > -1 && GameRows[rowAbove].IsSet(left))
                        nCount++;
                    if (rowAbove > -1 && GameRows[rowAbove].IsSet(colIndex))
                        nCount++;
                    if (rowAbove > -1 && GameRows[rowAbove].IsSet(right))
                        nCount++;
                    if (GameRows[rowIndex].IsSet(right))
                        nCount++;
                    if (rowBelow < NumberOfRows && GameRows[rowBelow].IsSet(right))
                        nCount++;
                    if (rowBelow < NumberOfRows && GameRows[rowBelow].IsSet(colIndex))
                        nCount++;
                    if (rowBelow < NumberOfRows && GameRows[rowBelow].IsSet(left))
                        nCount++;
                    if (GameRows[rowIndex].IsSet(left))
                        nCount++;

                    //Console.WriteLine("{0},{1}: {2}", rowIndex, colIndex, nCount);
                    switch (nCount)
                    {
                        default:
                            GameRowsThis[rowIndex].UnsetBit(colIndex, out GameRowsThis[rowIndex]);
                            cells[rowIndex, colIndex].Alive = false;
                            break;
                        case 2:
                            if (cells[rowIndex, colIndex].Alive)
                            {
                                GameRowsThis[rowIndex].SetBit(colIndex, out GameRowsThis[rowIndex]);
                                cells[rowIndex, colIndex].Alive = true;
                            }
                            break;
                        case 3:
                            GameRowsThis[rowIndex].SetBit(colIndex, out GameRowsThis[rowIndex]);
                            cells[rowIndex, colIndex].Alive = true;
                            break;

                    }
                }
            }
        }

        private void ProceedButton_Click(object sender, RoutedEventArgs e)
        {
            ProcessStep();
        }

        private void Cell_Click(object sender, EventArgs e)
        {
            Rectangle curLabel = (Rectangle)sender;
            Cell curCell = (Cell)curLabel.DataContext;
            curCell.Alive = (curCell.Alive) ? false : true;
        }

        private void NewGameButton_Click(object sender, RoutedEventArgs e)
        {
            NewGame();
        }
        private void NewGame()
        {
            GameFrame.Children.Remove(GameGrid);

            NumberOfColumns = (int)ColSlider.Value;
            NumberOfRows = (int)RowSlider.Value;
            //int counter = 0;
            //int onCount = 4;

            cells = new Cell[NumberOfRows, NumberOfColumns];
            //cellsThisRound = new bool[NumberOfRows, NumberOfColumns];
            GameRows = new BigInteger[NumberOfRows];
            GameRowsThis = new BigInteger[NumberOfRows];

            //GameGrid = new Grid();
            //GameGrid.ShowGridLines = true;

            //for (int i = 0; i < NumberOfRows; i++)
            //{
            //    GameGrid.RowDefinitions.Add(new RowDefinition());
            //}
            //for (int i = 0; i < NumberOfColumns; i++)
            //{
            //    GameGrid.ColumnDefinitions.Add(new ColumnDefinition());
            //}
            for (int rowIndex = 0; rowIndex < NumberOfRows; rowIndex++) 
            {
                for (int colIndex = 0; colIndex < NumberOfColumns; colIndex++)
                {
                    Rectangle tempLabel = new Rectangle();
                    tempLabel.Width = 10;
                    tempLabel.Height = 10;
                    Cell tempCell = new Cell();
                    //tempCell.Alive = (counter++ % onCount) == 0 ? true : false;
                    tempLabel.DataContext = tempCell;
                    //tempLabel.Content = string.Format("{0},{1}", rowIndex, colIndex);
                    tempLabel.MouseLeftButtonDown += Cell_Click;

                    var bind = new Binding("Alive")
                    {
                        Converter = new AliveToColorConverter()
                    };

                    tempLabel.SetBinding(Rectangle.FillProperty, bind);


                    GameFrame.Children.Add(tempLabel);
                    Canvas.SetTop(tempLabel, rowIndex * 10);
                    Canvas.SetLeft(tempLabel, colIndex * 10);
                    cells[rowIndex, colIndex] = tempCell;
                    //Console.WriteLine("{0}: - {1}", counter, tempCell.Alive);
                }
            }
            //GameFrame.Children.Add(GameGrid);
        }

        private void StartTimerButton_Click(object sender, RoutedEventArgs e)
        {
            Timer.Interval = TimeSpan.FromMilliseconds((1000 / TimeSlider.Value));
            Timer.Start();
        }

        private void StopTimerButton_Click(object sender, RoutedEventArgs e)
        {
            Timer.Stop();
        }

        private void RandomButton_Click(object sender, RoutedEventArgs e)
        {
            for (int rowIndex = 0; rowIndex < NumberOfRows; rowIndex++)
            {
                for (int colIndex = 0; colIndex < NumberOfColumns; colIndex++)
                {
                    cells[rowIndex,colIndex].Alive = (_Random.Next(0,4) == 0) ? true : false;
                }
            }
        }

        public void SaveGame(string filename)
        {
            PrepareGameRows();
            TextWriter tw = new StreamWriter(filename);
            tw.WriteLine(string.Format("{0},{1}",NumberOfRows.ToString(), NumberOfColumns.ToString()));
            for (int rowIndex = 0; rowIndex < NumberOfRows; rowIndex++)
            {
                tw.WriteLine(GameRows[rowIndex]);
            }
            tw.Close();
        }
        
        public void LoadGame(string filename)
        {
            
            int rowIndex = 0;
            TextReader tr = new StreamReader(filename);

            string line = tr.ReadLine();
            string[] randc = line.Split(',');

            RowSlider.Value = int.Parse(randc[0]);
            ColSlider.Value = int.Parse(randc[1]);

            NewGame();


            while ((line = tr.ReadLine()) != null) {

                GameRows[rowIndex++] = BigInteger.Parse(line);

                for (int colIndex = 0; colIndex < NumberOfColumns; colIndex++)
                {
                    cells[rowIndex - 1, colIndex].Alive = GameRows[rowIndex - 1].IsSet(colIndex);
                }    
            }
        
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog fileSelector = new SaveFileDialog();
            fileSelector.Filter = "Game of Life files|*.save";
            fileSelector.FilterIndex = 0;

            bool? clickedOK = fileSelector.ShowDialog();
            if (clickedOK == true)
            {
                SaveGame(fileSelector.FileName);
            }
            //SaveGame(@"c:\_\gameoflife1.save");
        }

        private void LoadButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileSelector = new OpenFileDialog();
            fileSelector.Filter = "Game of Life files|*.save";
            fileSelector.FilterIndex = 0;

            bool? clickedOK = fileSelector.ShowDialog();
            if (clickedOK == true)
            {
                LoadGame(fileSelector.FileName);
            }
            //LoadGame(@"c:\_\gameoflife1.save");
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
