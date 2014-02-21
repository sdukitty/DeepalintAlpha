using Deepglint.DeepglintAlpha.Model.MapModel.Model;
using Deepglint.DeepglintAlpha.Model.MapModel.Model.Sensor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Deepglint.DeepglintAlpha.BaseView.SensorView.Model
{
    public class SensorLayerGroupModel : BaseModel
    {

        #region 属性

        public List<SensorLayerModel> SensorLayerGroup { get; set; }

        #endregion

        #region 方法

        public SensorLayerGroupModel()
        {
            this.SensorLayerGroup = new List<SensorLayerModel>();
        }

        public SensorLayerGroupModel(List<SensorLayerModel> sensorLayerGroup)
        {
            this.SensorLayerGroup = sensorLayerGroup;
        }

        #endregion

    }
}
