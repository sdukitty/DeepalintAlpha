using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Deepglint.DeepglintAlpha.Model.MapModel.Path
{
    public class PathLayerModel : BaseModel
    {
        #region 属性

        public double PathWidth { get; set; }

        public MapColor PathColor { get; set; }

        public MapColor PathSideColor { get; set; }

        public List<PathModel> PathModels { get; set; }

        public int ZIndex { get; set; }

        #endregion

        #region 方法

        public PathLayerModel()
        {
            this.PathModels = new List<PathModel>();
        }

        #endregion
    }
}
