using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation.Peers;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Automation.Provider;

namespace ShapeCanvasWPF
{

    enum ShapeType
    {
        RANDOM, ELLIPSE, RECTANGLE//, TRIANGLE
    }

    /// <summary>
    /// This is the window of the shape canvas lab
    /// 
    /// Blake Rollins
    /// 
    /// </summary>
    public partial class MainWindow : Window
    {
        Random _Random = new Random();
        Point _CurrentPoint = new Point();
        SolidColorBrush _CurrentColor = new SolidColorBrush(); //.FromArgb(255, 0, 0, 0);
        ShapeType _NextShapeToCreate;
        TextBlock _NextShapeText;
        bool _RandomColor = true;
        int _MinHeight = 25, _MaxHeight = 65;
        int _MinWidth = 25, _MaxWidth = 65;
        Shape _NextShape;

        public MainWindow()
        {
            InitializeComponent();

            _NextShape = new Rectangle();
            _NextShape.Width = 30;
            _NextShape.Height = 30;
            _NextShape.Stroke = _CurrentColor;
            _NextShape.Fill = _CurrentColor;

            PlayCanvas.Children.Add(_NextShape);
            Canvas.SetTop(_NextShape, 10);
            Canvas.SetLeft(_NextShape, 10);

            _NextShapeText = new TextBlock();
            _NextShapeText.Text = _NextShapeToCreate.ToString();
            _NextShapeText.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));

            PlayCanvas.Children.Add(_NextShapeText);
            Canvas.SetTop(_NextShapeText, 10);
            Canvas.SetLeft(_NextShapeText, 50);

            PushButtonProgrammatically(buttonColorRandom);
            PushButtonProgrammatically(buttonShapeRandom);
        }

        /// <summary>
        /// Automate a WPF button push
        /// </summary>
        /// <param name="buttonToPush">reference of the button to push</param>
        private void PushButtonProgrammatically(Button buttonToPush)
        {
            ButtonAutomationPeer peer = new ButtonAutomationPeer(buttonToPush);
            IInvokeProvider invokeProv = peer.GetPattern(PatternInterface.Invoke) as IInvokeProvider;
            invokeProv.Invoke();
        }

        /// <summary>
        /// Change the color of the next Shape
        /// </summary>
        /// <param name="currentColor">The color to change to</param>
        private void SetColor(Color currentColor)
        {
            _CurrentColor.Color = currentColor;
        }

        /// <summary>
        /// Set which shape will be created next
        /// </summary>
        /// <param name="nextShape">The shape to create next</param>
        private void SetShape(ShapeType nextShape)
        {
            _NextShapeToCreate = nextShape;
            _NextShapeText.Text = _NextShapeToCreate.ToString();
        }

        /// <summary>
        /// The action for the color changing buttons
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ColorButton_Click(object sender, RoutedEventArgs e)
        {
            if (e.Source == buttonColorBlue)
            {
                SetColor(Color.FromArgb(255, 0, 0, 255));
                _RandomColor = false;
            }
            else if (e.Source == buttonColorGreen)
            {
                SetColor(Color.FromArgb(255, 0, 255, 0));
                _RandomColor = false;
            }
            else if (e.Source == buttonColorRed)
            {
                SetColor(Color.FromArgb(255, 255, 0, 0));
                _RandomColor = false;
            }
            else if (e.Source == buttonColorRandom)
            {
                SetColor(Color.FromArgb(255, (byte)_Random.Next(255), (byte)_Random.Next(255), (byte)_Random.Next(255)));
                _RandomColor = true;
            }
        }

        /// <summary>
        /// The action for the Clear button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            PlayCanvas.Children.Clear();
            PlayCanvas.Children.Add(_NextShape);
            PlayCanvas.Children.Add(_NextShapeText);
        }

        /// <summary>
        /// The action for the shape buttons
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShapeButton_Click(object sender, RoutedEventArgs e)
        {
            if (e.Source == buttonShapeRandom)
            {
                SetShape(ShapeType.RANDOM);
            }
            else if (e.Source == buttonShapeRectangle)
            {
                SetShape(ShapeType.RECTANGLE);
            }
            else if (e.Source == buttonShapeElipse)
            {
                SetShape(ShapeType.ELLIPSE);
            }
            //else if (e.Source == buttonShapeTriangle)
            //{
            //    SetShape(ShapeType.TRIANGLE);
            //}

        }

        /// <summary>
        /// The left click for the canvas
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PlayCanvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            _CurrentPoint = e.GetPosition(this);
            if (_RandomColor)
            {
                PushButtonProgrammatically(buttonColorRandom);
            }
            ShapeType nextShapeType = (_NextShapeToCreate == ShapeType.RANDOM) ? (ShapeType)(_Random.Next(0, (Enum.GetNames(typeof(ShapeType)).Length - 1)) + 1) : _NextShapeToCreate;
            Shape temp = null;
            int shapeWidth = _Random.Next(_MinWidth, _MaxWidth);
            int shapeHeight = _Random.Next(_MinHeight, _MaxHeight);
            int xOffset = (shapeWidth / 2);
            int yOffset = (shapeHeight / 2);

            switch (nextShapeType)
            {
                case ShapeType.ELLIPSE:
                    temp = new Ellipse();
                    break;
                default:
                case ShapeType.RECTANGLE:
                    temp = new Rectangle();
                    break;
                //case ShapeType.TRIANGLE:
                //    shapeWidth = 100;
                //    shapeHeight = 100;
                //    int x = _Random.Next(_MinWidth, _MaxWidth);
                //    int y = _Random.Next(_MinHeight, _MaxHeight);
                //    Polygon p = new Polygon();
                    
                //    PointCollection myPointCollection = new PointCollection();
                //    //myPointCollection.Add(new Point(4 + _Random.Next(_MinWidth, _MaxWidth), 4 + _Random.Next(_MinWidth, _MaxWidth)));
                //    //myPointCollection.Add(new Point(4 + _Random.Next(_MinWidth, _MaxWidth), 4 + _Random.Next(_MinWidth, _MaxWidth)));
                //    //myPointCollection.Add(new Point(4 + _Random.Next(_MinWidth, _MaxWidth), 4 + _Random.Next(_MinWidth, _MaxWidth))); 
                //    myPointCollection.Add(new Point(5, 0));
                //    myPointCollection.Add(new Point(10, 10));
                //    myPointCollection.Add(new Point(0, 10));
                //    xOffset = 5;
                //    yOffset = 5;

                //    p.Points = myPointCollection;
                //    temp = p;
                //    break;
            }

            SolidColorBrush tempColor = new SolidColorBrush(_CurrentColor.Color);
            temp.Stroke = tempColor;
            temp.Fill = tempColor;
            temp.Width = shapeWidth;
            temp.Height = shapeHeight;

            //temp.LayoutTransform = new RotateTransform(_Random.Next(0, 360));

            PlayCanvas.Children.Add(temp);
            Canvas.SetTop(temp, (int)_CurrentPoint.Y - yOffset);
            Canvas.SetLeft(temp, (int)_CurrentPoint.X - xOffset);
        }
        
        /// <summary>
        /// The right click for the canvas
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PlayCanvas_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            // http://www.c-sharpcorner.com/UploadFile/47fc0a/create-shapes-dynamically-in-wpf/
            _CurrentPoint = e.GetPosition(this);
            HitTestResult result = VisualTreeHelper.HitTest(PlayCanvas, _CurrentPoint);
            if (result != null)
            {
                PlayCanvas.Children.Remove(result.VisualHit as Shape);
            }

        }

        /// <summary>
        /// The move action for the canvas
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PlayCanvas_MouseMove_1(object sender, System.Windows.Input.MouseEventArgs e)
        {
        }

    }
}
