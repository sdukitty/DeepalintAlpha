using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace Deepglint.DeepglintAlpha.Demo.WallDemo
{
    public class Passage
    {
        #region Attribute

        public Point StartPoint { set; get; }

        public Point EndPoint { set; get; }

        #endregion

        #region Action

        public Passage()
        {

        }

        public Passage(Point start, Point end)
        {
            this.StartPoint = start;
            this.EndPoint = end;
        }

        #endregion
    }
}
