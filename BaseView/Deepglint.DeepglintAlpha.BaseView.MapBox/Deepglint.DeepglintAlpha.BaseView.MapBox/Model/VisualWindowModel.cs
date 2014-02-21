using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace Deepglint.DeepglintAlpha.BaseView.MapBox.Model
{
    public class VisualWindowModel
    {
        public double ZoomRate;

        public Point CenterPoint;

        public VisualWindowModel(double zoonRate, Point centerPoint)
        {
            this.ZoomRate = zoonRate;
            this.CenterPoint = centerPoint;
        }
    }
}
