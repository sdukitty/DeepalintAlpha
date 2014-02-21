using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Deepglint.DeepglintAlpha.Model.MapModel.Wall
{
    public class WallModel : BaseModel
    {
        #region 属性

        public List<MapPoint> WallInner { set; get; }

        public List<MapPoint> WallOuter { set; get; }

        #endregion

        #region 方法

        public WallModel()
        {
            this.WallInner = new List<MapPoint>();
            this.WallOuter = new List<MapPoint>();
        }

        public WallModel(List<MapPoint> wallInner, List<MapPoint> wallOuter)
        {
            this.WallInner = wallInner;
            this.WallOuter = WallOuter;
        }

        #endregion
    }
}
