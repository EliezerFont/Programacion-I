using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSC09
{
    public class Item
    {
        public string _nombre { get; set; }
        public int _valor { get; set; }

        public Item(string name, int value)
        {
            _nombre = name;
            _valor = value;
        }

        public override string ToString()
        {
            return _nombre;
        }
    }
}
