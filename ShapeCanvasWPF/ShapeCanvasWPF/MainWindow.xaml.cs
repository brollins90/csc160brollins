﻿using System;
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

    enum ShapeToCreate
    {
        RANDOM, TRIANGLE, RECTANGLE
    }

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Random _Random = new Random();
        Point _CurrentPoint = new Point();
        SolidColorBrush _CurrentColor = new SolidColorBrush(); //.FromArgb(255, 0, 0, 0);
        ShapeToCreate _NextShapeToCreate;
        TextBlock _NextShapeText;

        public MainWindow()
        {
            InitializeComponent();

            Shape _NextShape = new Rectangle();
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

        private void PushButtonProgrammatically(Button buttonToPush)
        {
            ButtonAutomationPeer peer = new ButtonAutomationPeer(buttonToPush);
            IInvokeProvider invokeProv = peer.GetPattern(PatternInterface.Invoke) as IInvokeProvider;
            invokeProv.Invoke();
        }

        private void SetColor(Color currentColor)
        {
            _CurrentColor.Color = currentColor;
        }

        private void SetShape(ShapeToCreate nextShape)
        {
            if (nextShape == ShapeToCreate.RANDOM)
            {
                _NextShapeToCreate = (ShapeToCreate)(_Random.Next(0, (Enum.GetNames(typeof(ShapeToCreate)).Length - 1)) + 1);
            }
            else
            {
                _NextShapeToCreate = nextShape;
            }

            _NextShapeText.Text = _NextShapeToCreate.ToString();
        }

        private void ColorButton_Click(object sender, RoutedEventArgs e)
        {
            if (e.Source == buttonColorBlue)
            {
                SetColor(Color.FromArgb(255, 0, 0, 255));
            }
            else if (e.Source == buttonColorGreen)
            {
                SetColor(Color.FromArgb(255, 0, 255, 0));
            }
            else if (e.Source == buttonColorRed)
            {
                SetColor(Color.FromArgb(255, 255, 0, 0));
            }
            else if (e.Source == buttonColorRandom)
            {
                SetColor(Color.FromArgb(255, (byte)_Random.Next(255), (byte)_Random.Next(255), (byte)_Random.Next(255)));
            }
        }

        private void ShapeButton_Click(object sender, RoutedEventArgs e)
        {
            if (e.Source == buttonShapeRandom)
            {
                SetShape(ShapeToCreate.RANDOM);
            }
            else if (e.Source == buttonShapeRectangle)
            {
                SetShape(ShapeToCreate.RANDOM);
            }
            else if (e.Source == buttonShapeTriangle)
            {
                SetShape(ShapeToCreate.TRIANGLE);
            }

        }

        private void PlayCanvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            _CurrentPoint = e.GetPosition(this);
        }

        private void PlayCanvas_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            _CurrentPoint = e.GetPosition(this);
        }

        private void PlayCanvas_MouseMove_1(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                Line line = new Line();

                //line.Stroke = SystemColors.WindowFrameBrush;
                line.Stroke = new SolidColorBrush(_CurrentColor.Color);
                line.X1 = _CurrentPoint.X;
                line.Y1 = _CurrentPoint.Y;
                line.X2 = e.GetPosition(this).X;
                line.Y2 = e.GetPosition(this).Y;

                _CurrentPoint = e.GetPosition(this);

                PlayCanvas.Children.Add(line);
            }
        }

    }
}
