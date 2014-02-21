using Deepglint.DeepglintAlpha.Model.MapModel.Wall;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace Deepglint.DeepglintAlpha.BaseView.WallView
{
    public class WallLayerView : LayerView
    {
        #region 属性

        public WallLayerModel WallLayerModelSingle { get; set; }

        #endregion

        #region 方法

        public WallLayerView() : base() { }

        public WallLayerView(WallLayerModel wallLayerModel)
            : base()
        {
            this.WallLayerModelSingle = wallLayerModel;
        }

        public override void Draw(Canvas canvas)
        {
                foreach (MapElementView mapElementView in this.MapElementViews)
                {
                    mapElementView.Draw(canvas);
                }
        }

        #endregion
    }
}
