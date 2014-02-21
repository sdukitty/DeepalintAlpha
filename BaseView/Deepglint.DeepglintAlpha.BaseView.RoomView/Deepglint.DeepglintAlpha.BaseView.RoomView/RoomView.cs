using Deepglint.DeepglintAlpha.Model.MapModel.Room;
using Deepglint.DeepglintAlpha.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Deepglint.DeepglintAlpha.BaseView.RoomView
{
    public class RoomView : MapElementView
    {

        #region

        public RoomControl roomControl { get; set; }

        public RoomModel Room { get; set; }

        public int Height { get; set; }

        public double Angle { get; set; }

        public Brush Color { get; set; }

        #endregion

        public RoomView(RoomModel room, int height, double angle, Brush color, int zIndex)
        {
            List<Point> roomPointList = new List<Point>();

            foreach (var p in room.PointList)
            {
                roomPointList.Add(Utils.GetPoint(p));
            }

            roomControl = new RoomControl(roomPointList, height, angle, color, zIndex);
        }

        public override void Draw(Canvas canvas)
        {

            canvas.Children.Add(roomControl);
        }

        public override void DisVisiable()
        {
            this.roomControl.Visibility = System.Windows.Visibility.Collapsed;
        }

        public override void IsVisiable()
        {
            this.roomControl.Visibility = System.Windows.Visibility.Visible;
        }
    }
}
