using Deepglint.DeepglintAlpha.Model.MapModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Deepglint.DeepglintAlpha.BaseView.ShopView
{
    /// <summary>
    /// UserControl1.xaml 的交互逻辑
    /// </summary>
    public partial class ShopControl : UserControl
    {

        public Point originPoint { get; set; }

        public ShopControl(List<Point> pointList, Brush color, int zIndex)
        {
            InitializeComponent();
            Inilize(pointList, color, zIndex);
        }

        private void Inilize(List<Point> pointList, Brush color,int zIndex)
        {
            SolidColorBrush shadowBrush = new SolidColorBrush();
            shadowBrush.Color = Color.FromArgb(255, 221, 221, 221);

            pointList = Tranlate(pointList);

            PointCollection pointCollection = new PointCollection();
            foreach (var point in pointList)
            {
                pointCollection.Add(point);
            }
            Polygon polygon = new Polygon();
            polygon.Points = pointCollection; //设置Polygon属性Points的点集合
            polygon.Fill = color;
            polygon.Stroke = shadowBrush;
            polygon.StrokeThickness = 1;
            this.grid.Children.Add(polygon);
            this.SetValue(Canvas.LeftProperty, originPoint.X);
            this.SetValue(Canvas.TopProperty, originPoint.Y);
            this.SetValue(Canvas.ZIndexProperty, zIndex);
            this.Opacity = 0.5;
        }

        private List<Point> Tranlate(List<Point> pointList)
        {
            List<Point> newListPoint = new List<Point>();
            Point oPoint = new Point(0, 0);
            if (pointList.Count == 0)
            {
                return null;
            }
            else
            {
                oPoint = pointList[0];
                foreach (var point in pointList)
                {
                    if (point.X < oPoint.X)
                    {
                        oPoint.X = point.X;
                    }

                    if (point.Y < oPoint.Y)
                    {
                        oPoint.Y = point.Y;
                    }
                }
                originPoint = oPoint;
                foreach (var point in pointList)
                {
                    newListPoint.Add(new Point(point.X - originPoint.X, point.Y - originPoint.Y));
                }

                return newListPoint;
            }
        }
    }
}
