using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemControls.Models
{
    public class Item
    {
        private string _Name;
        public string Name { get { return _Name; } set { _Name = value; } }

        
        private string _Effect;
        public string Effect { get { return _Effect; } set { _Effect = value; } }
        
        
        private int _Cost;
        public int Cost { get { return _Cost; } set { _Cost = value; } }


        private string _Description;
        public string Description { get { return _Description; } set { _Description = value; } }


        private bool _Equipped;
        public bool Equipped { get { return _Equipped; } set { _Equipped = value; } }
    }
}
