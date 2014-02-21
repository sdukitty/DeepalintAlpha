using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Deepglint.DeepglintAlpha.Model.MapModel.Wall
{
    public class WallLayerModel : BaseModel
    {

        #region 属性

        public List<WallModel> WallModels { set; get; }

        public MapColor WallColor { set; get; }

        public MapColor WallSideColor { set; get; }

        public int ZIndex { get; set; }

        #endregion

        #region 方法

        public WallLayerModel()
        {
            this.WallModels = new List<WallModel>();
        }

        #endregion
    }
}
