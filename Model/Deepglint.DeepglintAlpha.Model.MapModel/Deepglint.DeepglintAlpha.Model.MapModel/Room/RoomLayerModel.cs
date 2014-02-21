using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Deepglint.DeepglintAlpha.Model.MapModel.Room
{
    public class RoomLayerModel : BaseModel
    {
        public List<RoomModel> Rooms { get; set; }

        public double Angle { get; set; }

        public int Height { get; set; }

        public MapColor Color { get; set; }

        public int ZIndex { get; set; }

        public RoomLayerModel()
        {
            this.Rooms = new List<RoomModel>();
        }
    }
}
