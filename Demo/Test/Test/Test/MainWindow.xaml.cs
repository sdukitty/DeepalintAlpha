using Deepglint.DeepglintAlpha.BaseView;
using Deepglint.DeepglintAlpha.BaseView.MapContenView;
using Deepglint.DeepglintAlpha.BaseView.PathView;
using Deepglint.DeepglintAlpha.BaseView.RoomView;
using Deepglint.DeepglintAlpha.Model.MapModel;
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

namespace Test
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();


            StreamReader sr = new StreamReader(@"C:\Users\deepglint\Desktop\bin\Debug\Resource\config.txt");
            string s = sr.ReadToEnd();
            MapConfig mapConfig = MapConfig.ToSerializableClass<MapConfig>(s);

            //List<Room> rooms= Config.ToSerializableClass< List<Room>>(s); 

            MapContentView mapContentView = new MapContentView(mapConfig,canvas);

            //LayerView roomLayerView = new RoomLayerView();

            //LayerView sensorLayerView = new SensorLayerView();

            //LayerView shopLayerView = new ShopLayerView();

            //foreach (var roomConfig in mapConfig.Room)
            //{
            //    List<Point> pointList1 = new List<Point>();

            //    foreach (var p in roomConfig)
            //    {
            //        Point point = new Point(canvas.Width * p.X, canvas.Height * p.Y);
            //        pointList1.Add(point);
            //    }
            //    RoomModel roomModel = new RoomModel(pointList1);
            //    SolidColorBrush shadowBrush = new SolidColorBrush();
            //    shadowBrush.Color = Color.FromArgb(255, 249, 247, 244);
            //    MapElementView rv = new RoomView(roomModel,8, 0.8, shadowBrush,1);
            //    roomLayerView.Add(rv);

            //}

            //int k = 0;
            //foreach (var shopConfig in mapConfig.Shop)
            //{

            //    k++;
            //    List<Point> pointList1 = new List<Point>();
            //    foreach (var p in shopConfig)
            //    {
            //        Point point = new Point(canvas.Width * p.X, canvas.Height * p.Y);
            //        pointList1.Add(point);
            //    }
            //    ShopModel shopModel = new ShopModel(pointList1,null);
            //    shopModel.GetColor(k);
               
            //    //SolidColorBrush shadowBrush = new SolidColorBrush();
            //    //shadowBrush.Color = Color.FromArgb(255, 249, 247, 244);
            //    MapElementView sv = new ShopView(shopModel, 2);
            //    shopLayerView.Add(sv);
            
            
            //}

            //foreach (var sensorConfig in mapConfig.Sensor)
            //{
            //    Point point = new Point(canvas.Width * sensorConfig.X, canvas.Height * sensorConfig.Y);
            //    List<double> direction = new List<double>();
            //    direction.Add(1);
            //    direction.Add(0);

            //    SensorModel sensorModel = new SensorModel(point, "1", 200, 24, direction);
            //    MapElementView sv = new SensorView(sensorModel,9);
            //    sensorLayerView.Add(sv);

            //}

            ///// Path
            //SolidColorBrush pathColor = new SolidColorBrush();
            //pathColor.Color = Color.FromArgb(255, 254, 253, 177);

            //SolidColorBrush pathSideColor = new SolidColorBrush();
            //pathSideColor.Color = Color.FromArgb(255, 211, 197, 148);

            //double pathWidth = 5;


            //PathLayerModel plm = new PathLayerModel();
            //for (int i = 0; i < mapConfig.Pathor.Count; i++)
            //{
            //    Point start = new Point(mapConfig.Pathor[i].StartPoint.X * 800, mapConfig.Pathor[i].StartPoint.Y * 600);
            //    Point end = new Point(mapConfig.Pathor[i].EndPoint.X * 800, mapConfig.Pathor[i].EndPoint.Y * 600);
            //    PathModel pathModel = new PathModel(start, end);

            //    plm.PathModels.Add(pathModel);
            //}

            //plm.PathColor = pathColor;
            //plm.PathWidth = pathWidth;


            //LayerView plv = new PathLayerView(plm);
            //for (int i = 0; i < mapConfig.Pathor.Count; i++)
            //{
            //    Point start = new Point(mapConfig.Pathor[i].StartPoint.X * 800, mapConfig.Pathor[i].StartPoint.Y * 600);
            //    Point end = new Point(mapConfig.Pathor[i].EndPoint.X * 800, mapConfig.Pathor[i].EndPoint.Y * 600);
            //    PathModel pathModel = new PathModel(start, end);
            //    MapElementView pathView = new PathView(pathModel, pathWidth, pathColor, pathSideColor,8);

            //    plv.Add(pathView);
            //}

            //List<Point> wallInner = new List<Point>();
            //for (int i = 0; i < mapConfig.Wall[0].Count; i++)
            //{
            //    wallInner.Add(new Point(mapConfig.Wall[0][i].X * 800, mapConfig.Wall[0][i].Y * 600));
            //}

            //List<Point> wallOuter = new List<Point>();
            //for (int i = 0; i < mapConfig.Wall[1].Count; i++)
            //{
            //    wallOuter.Add(new Point(mapConfig.Wall[1][i].X * 800, mapConfig.Wall[1][i].Y * 600));
            //}

            //SolidColorBrush wallColor = new SolidColorBrush();
            //wallColor.Color = Color.FromArgb(255, 255, 222, 102);

            //SolidColorBrush wallSideColor = new SolidColorBrush();
            //wallSideColor.Color = Color.FromArgb(255, 225, 173, 85);

            //WallModel wallModel = new WallModel();
            //wallModel.WallInner = wallInner;
            //wallModel.WallOuter = wallOuter;

            //WallLayerModel wlm = new WallLayerModel();
            //wlm.WallColor = wallColor;
            //wlm.WallSideColor = Brushes.Red;
            //wlm.WallModels.Add(wallModel);

            //MapElementView wall = new WallView(wallModel, wallColor, wallSideColor,40);

            //LayerView lv = new WallLayerView();
            //lv.Add(wall);



            //lv.Visible = true;
            //mapContentView.Add(roomLayerView);
            //mapContentView.Add(shopLayerView);
            //mapContentView.Add(sensorLayerView);
            //mapContentView.Add(plv);
            //mapContentView.Add(lv);

            //mapContentView.MapElementViews[2].Visible = false;

            mapContentView.Draw(canvas);

        }
    }
}
