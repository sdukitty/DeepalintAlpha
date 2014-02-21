using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Deepglint.DeepglintAlpha.Model.MapModel.Sensor
{
    public class SensorModel : BaseModel
    {

        public string SensorID { get; set; }

        public int RTSPServerPort { get; set; }

        public string MacAddress { get; set; }

        public MapPoint CenterPoint { get; set; }

        public int ScopeDistance { get; set; }

        public int SensorSize { get; set; }

        public double Angle { get; set; }


        #region 方法

        public SensorModel() { }

        public SensorModel(MapPoint point, string id, int port,string addr, int scopeDistance, int sensorSize, double angle)
        {
            this.RTSPServerPort = port;
            this.MacAddress = addr;
            this.CenterPoint = point;
            this.SensorID = id;
            this.ScopeDistance = scopeDistance;
            this.SensorSize = sensorSize;
            this.Angle = angle;
        }

        #endregion
    }
}
