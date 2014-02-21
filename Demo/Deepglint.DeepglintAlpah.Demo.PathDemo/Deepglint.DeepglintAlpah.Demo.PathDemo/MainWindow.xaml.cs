using Deepglint.DeepglintAlpha.BaseView;
using Deepglint.DeepglintAlpha.BaseView.PathView;
using Deepglint.DeepglintAlpha.Model.MapModel;
using Deepglint.DeepglintAlpha.Model.MapModel.Path;
using Deepglint.DeepglintAlpha.Util;
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

namespace Deepglint.DeepglintAlpah.Demo.PathDemo
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            InitPassage();

        }

        private void InitPassage()
        {
            Point p0 = new Point(100, 150);
            Point p1 = new Point(300, 150);

            Point p2 = new Point(100, 100);
            Point p3 = new Point(300, 300);

            Point p4 = new Point(100, 300);
            Point p5 = new Point(300, 100);

            Point p6 = new Point(100, 250);
            Point p7 = new Point(300, 250);

            Point p8 = new Point(500, 100);
            Point p9 = new Point(500, 500);


            string path = "D://path.txt";
            StreamReader streamReader = new StreamReader(path);
            string json = streamReader.ReadToEnd();
            System.Console.WriteLine(json);
            MapConfig config = MapConfig.ToSerializableClass<MapConfig>(json);
            streamReader.Close();

            MapColor pathColor = new MapColor(255, 254, 253, 177);

            MapColor pathSideColor = new MapColor(255, 211, 197, 148);

            double pathWidth = 5;


            PathLayerModel plm = new PathLayerModel();
            for (int i = 0; i < config.Pathor.Count; i++)
            {
                MapPoint start = new MapPoint(config.Pathor[i].StartPoint.X * 800, config.Pathor[i].StartPoint.Y * 600);
                MapPoint end = new MapPoint(config.Pathor[i].EndPoint.X * 800, config.Pathor[i].EndPoint.Y * 600);
                PathModel pathModel = new PathModel(start, end);

                plm.PathModels.Add(pathModel);
            }


            //PathModel pathModel1 = new PathModel(p3, p2);
            //PathModel pathModel2 = new PathModel(p5, p4);

            //MapElementView pathView1 = new PathView(pathModel1, pathWidth, pathColor, pathSideColor);

            //MapElementView pathView2 = new PathView(pathModel2, pathWidth, pathColor, pathSideColor);

            //plm.PathModels.Add(pathModel1);
            //plm.PathModels.Add(pathModel2);

            plm.PathColor = pathColor;
            plm.PathWidth = pathWidth;


            LayerView plv = new PathLayerView(plm,5);
            for (int i = 0; i < config.Pathor.Count; i++)
            {
                MapPoint start = new MapPoint(config.Pathor[i].StartPoint.X * 800, config.Pathor[i].StartPoint.Y * 600);
                MapPoint end = new MapPoint(config.Pathor[i].EndPoint.X * 800, config.Pathor[i].EndPoint.Y * 600);
                PathModel pathModel = new PathModel(start, end);
                MapElementView pathView = new PathView(pathModel, pathWidth, Utils.GetBrush(pathColor), Utils.GetBrush(pathSideColor), 4);

                plv.Add(pathView);
            }

            //plv.Add(pathView1);
            //plv.Add(pathView2);

            plv.Draw(this.canvas);

        }

    }
}
