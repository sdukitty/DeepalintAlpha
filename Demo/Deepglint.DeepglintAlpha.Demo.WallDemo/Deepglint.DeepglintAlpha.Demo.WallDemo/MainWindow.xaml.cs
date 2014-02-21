using Deepglint.DeepglintAlpha.BaseView;
using Deepglint.DeepglintAlpha.BaseView.WallView;
using Deepglint.DeepglintAlpha.Model.MapModel;
using Deepglint.DeepglintAlpha.Model.MapModel.Wall;
using Deepglint.DeepglintAlpha.Util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
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

namespace Deepglint.DeepglintAlpha.Demo.WallDemo
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Init();

        }

        private void Init()
        {
            string path = "D://wall.txt";
            StreamReader streamReader = new StreamReader(path);
            string json = streamReader.ReadToEnd();
            System.Console.WriteLine(json);
            Config config = Config.ToSerializableClass<Config>(json);
            streamReader.Close();
            
            Point p1 = new Point(100, 100);
            Point p2 = new Point(200, 100);
            Point p3 = new Point(200, 200);
            Point p4 = new Point(50, 200);
            Point p5 = new Point(100, 150);

            List<MapPoint> wallInner = new List<MapPoint>();
            for (int i = 0; i < config.Wall[0].Count; i++)
            {
                wallInner.Add(new MapPoint(config.Wall[0][i].X * 800, config.Wall[0][i].Y * 600));
            }
            //wallInner.Add(p1);
            //wallInner.Add(p2);
            //wallInner.Add(p3);
            //wallInner.Add(p4);
            //wallInner.Add(p5);

            List<MapPoint> wallOuter = new List<MapPoint>();
            for (int i = 0; i < config.Wall[1].Count; i++)
            {
                wallOuter.Add(new MapPoint(config.Wall[1][i].X * 800, config.Wall[1][i].Y * 600));
            }
            //wallOuter.Add(new Point(90, 90));
            //wallOuter.Add(new Point(210, 90));
            //wallOuter.Add(new Point(210, 210));
            //wallOuter.Add(new Point(20, 210));
            //wallOuter.Add(new Point(90, 150));

            MapColor wallColor = new MapColor(255, 255, 222, 102);

            MapColor wallSideColor = new MapColor(255, 225, 173, 85);

            WallModel wallModel = new WallModel();
            wallModel.WallInner = wallInner;
            wallModel.WallOuter = wallOuter;

            WallLayerModel wlm = new WallLayerModel();
            wlm.WallColor = wallColor;
            wlm.WallSideColor = wallSideColor;
            wlm.WallModels.Add(wallModel);

            MapElementView wall = new WallView(wallModel, Utils.GetBrush(wallColor), Utils.GetBrush(wallSideColor), 1);

            LayerView lv = new WallLayerView();
            lv.Add(wall);
            lv.Draw(this.canvas);
        }
    }
}
