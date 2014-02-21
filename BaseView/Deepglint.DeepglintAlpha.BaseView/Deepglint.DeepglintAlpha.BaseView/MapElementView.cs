using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace Deepglint.DeepglintAlpha.BaseView
{
    public abstract class MapElementView
    {

        protected bool visible;

        public double X { set; get; }

        public double Y { set; get; }

        public string ID { set; get; }

        public int Zindex { set; get; }

        public bool Visible
        {
            get
            {
                return visible;
            }
            set
            {
                visible = value;

                if (value == false)
                {
                    DisVisiable();
                }
                else
                {
                    IsVisiable();
                }

                //foreach (MapElementView mapElementView in this.MapElementViews)
                //{
                //    mapElementView.Visible = this.visible;
                //}
                //VisibleChangedEvent(this, null);
            }
        }

        #region 方法

        public abstract void Draw(Canvas canvas);

        public abstract void IsVisiable();

        public abstract void DisVisiable();

        #endregion

    }
}
