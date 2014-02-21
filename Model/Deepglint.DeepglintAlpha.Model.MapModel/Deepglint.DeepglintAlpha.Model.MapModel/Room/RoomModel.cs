using Deepglint.DeepglintAlpha.Model.MapModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Deepglint.DeepglintAlpha.Model.MapModel.Room
{
    public class RoomModel : BaseModel
    {
        public List<MapPoint> PointList { get; set; }

        #region 方法

        public RoomModel(List<MapPoint> pointList)
        {
            this.PointList = pointList;
        }

        #endregion
    }
}
