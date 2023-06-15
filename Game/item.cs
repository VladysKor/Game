using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    internal class item : ICloneable
    {
            public string name;
            public int id;
            public bool stack;
            public int count;

        public item(string name, int id, bool stack, int count = 1)
        {
            this.name = name;
            this.id = id;
            this.stack = stack;
            this.count = count;
        }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
