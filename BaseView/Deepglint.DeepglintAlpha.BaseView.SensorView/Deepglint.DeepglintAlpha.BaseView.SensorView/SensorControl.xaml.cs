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

namespace Deepglint.DeepglintAlpha.BaseView.SensorView
{
    /// <summary>
    /// UserControl1.xaml 的交互逻辑
    /// </summary>
    public partial class SensorControl : UserControl
    {
        public SensorControl(Point centerPoint, int scopeDistance, int sensorSize, List<double> direction, string id, int zIndex)
        {
            InitializeComponent();

            InilizeSize(centerPoint, 3 * scopeDistance, scopeDistance, sensorSize, sensorSize, direction, id, zIndex);
        }



        public void InilizeSize(Point centerPoint, int scope, int r, int sensorWidth, int sensorHeight, List<double> direction, string ID, int zIndex)
        {
            image.Width = sensorWidth;
            image.Height = sensorHeight;
            grid.Width = scope;
            grid.Height = scope;
            //this.sensorGrid.Width = r;
            //this.sensorGrid.Height = r;
            System.Console.WriteLine(Math.Sin(Math.Atan2(1, 1)));
            Point point1 = new Point(scope / 2, scope / 2); //封闭多边形的多个顶点坐标
            Point point2 = new Point(scope / 2 - r * 0.707, scope / 2 + r * 0.707);
            Point point3 = new Point(scope / 2 + r * 0.707, scope / 2 + r * 0.707);
            //定义点集合对象
            PointCollection pointCollection = new PointCollection();
            pointCollection.Add(point1); //将顶点添加到点集合对象
            pointCollection.Add(point2);
            pointCollection.Add(point3);
            this.viewEllipese.Points = pointCollection; //设置Polygon属性Points的点集合
            this.SetValue(Canvas.LeftProperty, centerPoint.X - scope / 2);
            this.SetValue(Canvas.TopProperty, centerPoint.Y - scope / 2);
            this.SetValue(Canvas.ZIndexProperty, zIndex);

        }

        private Point PointTranslate(Point point, List<double> direction, int r)
        {

            Point newPoint = new Point();

            try
            {
                double n = Math.Atan2(direction.ToList()[1], direction.ToList()[0]);
                newPoint.X = r / 2 + (point.X * Math.Cos(n) - point.Y * Math.Sin(n));
                newPoint.Y = r / 2 - (point.X * Math.Sin(n) + point.Y * Math.Cos(n));
            }

            catch
            {

                System.Console.WriteLine("绘制sensor出现错误！");
            }
            return newPoint;

        }

        private void image_MouseEnter(object sender, MouseEventArgs e)
        {
            BitmapImage img = new BitmapImage();
            //img.UriSource = new Uri(@"/Assets/SensorPoint(active).png");
            this.image.Source = img;
        }
    }
}
