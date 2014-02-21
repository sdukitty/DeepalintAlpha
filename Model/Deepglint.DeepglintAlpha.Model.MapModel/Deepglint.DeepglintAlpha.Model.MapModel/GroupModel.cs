using Deepglint.DeepglintAlpha.Model.MapModel.Path;
using Deepglint.DeepglintAlpha.Model.MapModel.Room;
using Deepglint.DeepglintAlpha.Model.MapModel.Sensor;
using Deepglint.DeepglintAlpha.Model.MapModel.Shop;
using Deepglint.DeepglintAlpha.Model.MapModel.Wall;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Deepglint.DeepglintAlpha.Model.MapModel
{
    public class GroupModel : BaseModel
    {

        public string GroupID { get; set; }

        public WallLayerModel WallLayer { get; set; }

        public PathLayerModel PathLayer { get; set; }

        public RoomLayerModel RoomLayer { get; set; }

        public ShopLayerModel ShopLayer { get; set; }

        public SensorLayerModel SensorLayer { get; set; }

    }
}
