using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Deepglint.DeepglintAlpha.Model.MapModel.Model.Sensor
{
    public class SensorLayerModel : BaseModel
    {
        public string LayerID;

        public List<SensorModel> Sensors { get; set; }

        public int ZIndex { get; set; }

        public SensorLayerModel()
        {
            Sensors = new List<SensorModel>();
        }
    }
}
