using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Media;

namespace ShapeCanvasWPFv2.Models
{
    public class ColorSelectorModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        public void FirePropertyChanged(String propertyName)
        {
            if (PropertyChanged != null)
            {
                Console.WriteLine("ColorSelectorModel.FirePropertyChanged({0})", propertyName);
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private byte _A;
        public byte A
        {
            get { return _A; }
            set
            {
                _A = value;
                GenerateBrush();
                FirePropertyChanged("A");
            }
        }

        private byte _R;
        public byte R
        {
            get { return _R; }
            set
            {
                _R = value;
                GenerateBrush();
                FirePropertyChanged("R");
            }
        }

        private byte _G;
        public byte G
        {
            get { return _G; }
            set
            {
                _G = value;
                GenerateBrush();
                FirePropertyChanged("G");
            }
        }

        private byte _B;
        public byte B
        {
            get { return _B; }
            set
            {
                _B = value;
                GenerateBrush();
                FirePropertyChanged("B");
            }
        }

        private Brush _Brush;
        public Brush Brush
        {
            get { return _Brush; }
            set
            {
                _Brush = value;
                FirePropertyChanged("Brush");
            }
        }

        private void GenerateBrush()
        {
            Brush = new SolidColorBrush(Color.FromArgb(A,R,G,B));
        }

        public ColorSelectorModel(byte a = 255, byte r = 127, byte g = 127, byte b = 127)
        {
            A = a;
            R = r;
            G = g;
            B = b;
            GenerateBrush();
        }
    }
}
