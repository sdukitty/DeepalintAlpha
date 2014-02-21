using Deepglint.DeepglintAlpha.BaseView.MapBox.Model;
using Deepglint.DeepglintAlpha.BaseView.MapContenView;
using Deepglint.DeepglintAlpha.Model.MapModel.Model;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace Deepglint.DeepglintAlpha.BaseView.MapBox
{
    /// <summary>
    /// UserControl1.xaml 的交互逻辑
    /// </summary>
    public partial class MapBox : UserControl
    {
        #region 字段

        private int width;

        private int height;

        private bool mouseLeftDown;

        private Point mouseXY;

        private double del = 0;

        #endregion

        #region 属性

        public int MapWidth
        {
            get
            {
                return width;
            }
            set
            {
                width = value;
                this.canvas.Width = width;
            }
        }

        public int MapHeight
        {
            get
            {
                return height;
            }
            set
            {
                this.height = value;
                this.canvas.Height = height;
            }
        }

        public MapContentView MapContentView { get; set; }

        public VisualWindowModel VisualWindowModel { get; set; }

        #endregion

        public MapBox(int mapWidth, int mapHeight, string configUrl)
        {
            InitializeComponent();
            this.MapWidth = mapWidth;
            this.MapHeight = mapHeight;
            this.BackFrame.Width = mapWidth;
            this.BackFrame.Height = mapHeight;

            StreamReader sr = new StreamReader(configUrl);
            string s = sr.ReadToEnd();
            MapConfig mapConfig = MapConfig.ToSerializableClass<MapConfig>(s);

            MapContentView = new MapContentView(mapConfig, canvas);
            MapContentView.Draw(canvas);

            this.VisualWindowModel = new VisualWindowModel(1, new Point(mapWidth / 2, mapHeight / 2));
        }

        public void VisualWindow(VisualWindowModel visualWindowModel)
        {
            var group = canvas.FindResource("Imageview") as TransformGroup;
            var transform = group.Children[1] as TranslateTransform;

            transform.X -= visualWindowModel.CenterPoint.X;
            transform.Y -= visualWindowModel.CenterPoint.Y;
            //transform.X -= this.Width / 2 - visualWindowModel.CenterPoint.X;
            //transform.Y -= this.Height/2- visualWindowModel.CenterPoint.Y;

        }

        #region 事件

        private void IMG1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {


            var img = sender as ContentControl;
            if (img == null)
            {
                return;
            }
            img.CaptureMouse();
            mouseLeftDown = true;
            mouseXY = e.GetPosition(img);
        }

        private void IMG1_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var img = sender as ContentControl;
            if (img == null)
            {
                return;
            }
            img.ReleaseMouseCapture();
            mouseLeftDown = false;
        }

        private void IMG1_MouseMove(object sender, MouseEventArgs e)
        {
            var img = sender as ContentControl;
            if (img == null)
            {
                return;
            }
            if (mouseLeftDown)
            {
                Domousemove(img, e);
            }
        }

        private void Domousemove(ContentControl img, MouseEventArgs e)
        {
            if (e.LeftButton != MouseButtonState.Pressed)
            {
                return;
            }
            var group = canvas.FindResource("Imageview") as TransformGroup;
            var transform = group.Children[1] as TranslateTransform;
            var position = e.GetPosition(img);
            transform.X -= mouseXY.X - position.X;
            transform.Y -= mouseXY.Y - position.Y;

            this.VisualWindowModel.CenterPoint.X += mouseXY.X - position.X;
            this.VisualWindowModel.CenterPoint.Y += mouseXY.Y - position.Y;
            mouseXY = position;
            System.Console.WriteLine("大小：" + VisualWindowModel.CenterPoint.X.ToString());
            System.Console.WriteLine("大小：" + VisualWindowModel.CenterPoint.Y.ToString());
        }

        private void IMG1_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            var img = sender as ContentControl;
            if (img == null)
            {
                return;
            }
            var point = e.GetPosition(img);
            var group = canvas.FindResource("Imageview") as TransformGroup;
            double delta = e.Delta * 0.001;
            DowheelZoom(group, point, delta);
            del += delta;
            //System.Console.WriteLine("放缩比例为：" + del.ToString());
        }

        private void DowheelZoom(TransformGroup group, Point point, double delta)
        {
            var pointToContent = group.Inverse.Transform(point);
            var transform = group.Children[0] as ScaleTransform;
            if (transform.ScaleX + delta < 0.1) return;
            transform.ScaleX += delta;
            transform.ScaleY += delta;
            var transform1 = group.Children[1] as TranslateTransform;
            transform1.X = -1 * ((pointToContent.X * transform.ScaleX) - point.X);
            transform1.Y = -1 * ((pointToContent.Y * transform.ScaleY) - point.Y);
            //System.Console.WriteLine("大小：" + this.canvas.Width.ToString());
        }



        #endregion

    }
}
