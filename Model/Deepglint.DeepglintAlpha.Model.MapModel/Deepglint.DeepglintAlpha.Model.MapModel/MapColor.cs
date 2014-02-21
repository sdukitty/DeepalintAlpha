using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Deepglint.DeepglintAlpha.Model.MapModel
{
    public class MapColor : BaseModel
    {
        public int A { get; set; }

        public int R { get; set; }

        public int G { get; set; }

        public int B { get; set; }

        public MapColor() { }

        public MapColor(int a, int r, int g, int b)
        {
            this.A = a;
            this.R = r;
            this.G = g;
            this.B = b;
        }
    }
}
