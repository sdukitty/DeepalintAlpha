using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace Deepglint.DeepglintAlpha.Model.MapModel.Model.Sensor
{
    public class SensorModel : BaseModel
    {

        public string ID { get; set; }

        public Point CenterPoint { get; set; }

        public int ScopeDistance { get; set; }

        public int SensorSize { get; set; }

        public List<double> Direction { get; set;}

       

        #region 方法

        public SensorModel(Point point,string id,int scopeDistance,int sensorSize,List<double> direction)
        {
            this.CenterPoint = point;
            this.ID = id;
            this.ScopeDistance = scopeDistance;
            this.SensorSize = sensorSize;
            this.Direction = new List<double>();
            this.Direction = direction;
        }

        #endregion
    }
}
