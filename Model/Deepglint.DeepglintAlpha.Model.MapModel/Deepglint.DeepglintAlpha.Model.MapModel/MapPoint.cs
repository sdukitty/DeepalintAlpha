using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Deepglint.DeepglintAlpha.Model.MapModel
{
    public class MapPoint : BaseModel
    {

        public double X { get; set; }

        public double Y { get; set; }


        public MapPoint() { }

        public MapPoint(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }
    }
}
