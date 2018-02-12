using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace warcaby
{
    public class PLAYER
    {
        private string name;
        private int color;
        public string p_name
        {
            get { return this.name; }
            set { name = value; }
        }
        public int p_color
        {
            get { return this.color; }
            set { color = value; }
        }
        public PLAYER(int value)
        {
            color = value;
        }
        public string create_name(string Name)
        {
            return name = Name;
        }
    }
}
