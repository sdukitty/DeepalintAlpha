using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Deepglint.DeepglintAlpha.Model.MapModel.Path
{
    public class PathModel : BaseModel
    {
        #region 属性

        public MapPoint StartPoint { set; get; }

        public MapPoint EndPoint { set; get; }

        public int ZIndex { get; set; }

        #endregion

        #region 方法

        public PathModel() { }

        public PathModel(MapPoint start, MapPoint end)
        {
            this.StartPoint = start;
            this.EndPoint = end;
        }

        #endregion

    }
}
