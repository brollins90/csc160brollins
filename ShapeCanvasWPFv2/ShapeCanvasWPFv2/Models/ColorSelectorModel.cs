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

        private int _A;
        public int A
        {
            get { return _A; }
            set
            {
                _A = value;
                GenerateBrush();
                FirePropertyChanged("A");
            }
        }

        private int _R;
        public int R
        {
            get { return _R; }
            set
            {
                _R = value;
                GenerateBrush();
                FirePropertyChanged("R");
            }
        }

        private int _G;
        public int G
        {
            get { return _G; }
            set
            {
                _G = value;
                GenerateBrush();
                FirePropertyChanged("G");
            }
        }

        private int _B;
        public int B
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
            Brush = new SolidColorBrush(Color.FromArgb((byte)A, (byte)R, (byte)G, (byte)B));
        }

        public ColorSelectorModel(int a = 255, int r = 127, int g = 127, int b = 127)
        {
            A = a;
            R = r;
            G = g;
            B = b;
            GenerateBrush();
        }
    }
}
