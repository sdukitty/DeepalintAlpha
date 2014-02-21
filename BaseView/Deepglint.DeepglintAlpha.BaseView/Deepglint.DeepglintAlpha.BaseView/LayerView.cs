using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace Deepglint.DeepglintAlpha.BaseView
{
    public abstract class LayerView : MapElementView
    {

        #region 属性

        public List<MapElementView> MapElementViews { set; get; }



        #endregion


        #region 方法

        public LayerView()
        {
            this.MapElementViews = new List<MapElementView>();
        }

        public void Add(MapElementView mapElementView)
        {
            this.MapElementViews.Add(mapElementView);
        }

        public override void Draw(Canvas canvas)
        {
            foreach (MapElementView mapElementView in this.MapElementViews)
            {
                mapElementView.Draw(canvas);
            }
        }

        public override void IsVisiable()
        {
            foreach (MapElementView mapElementView in this.MapElementViews)
            {
                mapElementView.Visible=true;
            }
        }

        public override void DisVisiable()
        {
            foreach (MapElementView mapElementView in this.MapElementViews)
            {
                mapElementView.Visible = false;
            }
        }
        #endregion

        #region 事件

        public event VisibleChangedEventHandler VisibleChangedEvent;

        public delegate void VisibleChangedEventHandler(object sender, RoutedEventArgs e);

        #endregion

    }
}
