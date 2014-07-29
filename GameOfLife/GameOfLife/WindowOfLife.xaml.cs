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
//using System.Windows.Automation.Provider;

namespace GameOfLife
{

    public static class ExtensionMethods {

        public static void SetBit(this BigInteger value, int bit, out BigInteger o)
        {
            //Console.WriteLine("org  :   " + value.ToBinaryString());
            //BigInteger mask = BigInteger.One;
            //Console.WriteLine("mask1:       " + mask.ToBinaryString());
            //mask = mask << bit;
            //Console.WriteLine("mask2:     " + mask.ToBinaryString());
            //BigInteger notMask = ~mask;
            //Console.WriteLine("mask~: " + notMask.ToBinaryString());
            ////decimal mask = (decimal)1 << bit;
            //BigInteger b2 = value | mask;
            //Console.WriteLine("b2   :   " + b2.ToBinaryString());
            //o = b2;
            ////BigInteger mask = BigInteger.Parse("1") << bit;
            ////value |= mask;

            BigInteger mask = BigInteger.Parse("1") << bit;
            o = value | mask;            
        }

        public static void UnsetBit(this BigInteger value, int bit, out BigInteger o)
        {
            BigInteger mask = BigInteger.Parse("1") << bit;
            o = value & ~mask;
        }

        public static bool IsSet(this BigInteger value, int bit)
        {
            BigInteger i = value & (BigInteger.One << bit);
            //Console.WriteLine(i.ToBinaryString());
            return i != 0; ;
        }

        public static string ToBinaryString(this BigInteger bigint)
        {
            var bytes = bigint.ToByteArray();
            var idx = bytes.Length - 1;

            // Create a StringBuilder having appropriate capacity.
            var base2 = new StringBuilder(bytes.Length * 8);

            // Convert first byte to binary.
            var binary = Convert.ToString(bytes[idx], 2);

            // Ensure leading zero exists if value is positive.
            if (binary[0] != '0' && bigint.Sign == 1)
            {
                base2.Append('0');
            }

            // Append binary string to StringBuilder.
            base2.Append(binary);

            // Convert remaining bytes adding leading zeros.
            for (idx--; idx >= 0; idx--)
            {
                base2.Append(Convert.ToString(bytes[idx], 2).PadLeft(8, '0'));
            }

            return base2.ToString();
        }
    }

    /// <summary>
    /// Interaction logic for WindowOfLife.xaml
    /// </summary>
    public partial class WindowOfLife : Window
    {

        public BigInteger[] GameRows;
        public BigInteger[] GameRowsThis;

        private DispatcherTimer Timer;


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

        public void ProcessStep()
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

        public void ProcessStepOld()
        {
            for (int i = 0; i < NumberOfColumns; i++)
            {
                for (int j = 0; j < NumberOfRows; j++)
                {
                    cellsThisRound[i, j] = cells[i, j].Alive;
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
                    //Console.WriteLine("{0},{1}: {2}", colIndex, rowIndex, nCount);

                    switch (nCount)
                    {
                        default:
                            cellsThisRound[colIndex, rowIndex] = false;
                            break;
                        case 2:
                            if (cells[colIndex, rowIndex].Alive)
                            {
                                cellsThisRound[colIndex, rowIndex] = true;
                            }
                            break;
                        case 3:
                            cellsThisRound[colIndex, rowIndex] = true;
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

            cells = new Cell[NumberOfRows, NumberOfColumns];
            cellsThisRound = new bool[NumberOfRows, NumberOfColumns];
            GameRows = new BigInteger[NumberOfRows];
            GameRowsThis = new BigInteger[NumberOfRows];

            GameGrid = new Grid();
            GameGrid.ShowGridLines = true;

            for (int i = 0; i < NumberOfRows; i++)
            {
                GameGrid.RowDefinitions.Add(new RowDefinition());
            }
            for (int i = 0; i < NumberOfColumns; i++)
            {
                GameGrid.ColumnDefinitions.Add(new ColumnDefinition());
            }
            for (int rowIndex = 0; rowIndex < NumberOfRows; rowIndex++) 
            {
                for (int colIndex = 0; colIndex < NumberOfColumns; colIndex++)
                {
                    Label tempLabel = new Label();
                    Cell tempCell = new Cell();
                    tempCell.Alive = (counter++ % onCount) == 0 ? true : false;
                    tempLabel.DataContext = tempCell;
                    tempLabel.Content = string.Format("{0},{1}", rowIndex, colIndex);
                    tempLabel.MouseLeftButtonDown += Cell_Click;

                    var bind = new Binding("Alive")
                    {
                        Converter = new AliveToColorConverter()
                    };

                    tempLabel.SetBinding(Label.BackgroundProperty, bind);

                    GameGrid.Children.Add(tempLabel);
                    Grid.SetRow(tempLabel, rowIndex);
                    Grid.SetColumn(tempLabel, colIndex);
                    cells[rowIndex, colIndex] = tempCell;
                    //Console.WriteLine("{0}: - {1}", counter, tempCell.Alive);
                }
            }
            GameFrame.Children.Add(GameGrid);
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
