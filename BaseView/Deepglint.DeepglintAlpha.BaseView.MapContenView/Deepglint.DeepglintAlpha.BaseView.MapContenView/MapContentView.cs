using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;
using System.Windows.Controls;
using Deepglint.DeepglintAlpha.Model.MapModel;
using Deepglint.DeepglintAlpha.BaseView.RoomView;
using Deepglint.DeepglintAlpha.Model.MapModel.Room;
using Deepglint.DeepglintAlpha.Util;
using Deepglint.DeepglintAlpha.Model.MapModel.Path;
using Deepglint.DeepglintAlpha.BaseView.PathView;
using Deepglint.DeepglintAlpha.Model.MapModel.Wall;
using Deepglint.DeepglintAlpha.BaseView.WallView;
using Deepglint.DeepglintAlpha.Model.MapModel.Shop;
using Deepglint.DeepglintAlpha.BaseView.ShopView;


namespace Deepglint.DeepglintAlpha.BaseView.MapContenView
{
    public class MapContentView : LayerView
    {
        public MapContentView(MapConfig mapConfig, Canvas canvas)
            : base()
        {

            LayerView roomLayerView = new RoomLayerView();

            //LayerView sensorLayerView = new SensorLayerView();

            LayerView shopLayerView = new ShopLayerView();

            LayerView wallLayerView = new WallLayerView();


            #region room

            foreach (var roomConfig in mapConfig.Room)
            {
                List<MapPoint> pointList1 = new List<MapPoint>();

                foreach (var p in roomConfig)
                {
                    MapPoint point = new MapPoint(canvas.Width * p.X, canvas.Height * p.Y);
                    pointList1.Add(point);
                }
                RoomModel roomModel = new RoomModel(pointList1);

                RoomLayerModel roomLayerModel = new RoomLayerModel();
                roomLayerModel.Color = new MapColor(255, 249, 247, 244);
                roomLayerModel.Height = 8;
                roomLayerModel.Angle = 0.8;
                roomLayerModel.ZIndex = 1;

                MapElementView rv = new RoomView.RoomView(roomModel, roomLayerModel.Height, roomLayerModel.Angle, Utils.GetBrush(roomLayerModel.Color), roomLayerModel.ZIndex);
                roomLayerView.Add(rv);

            }

            #endregion

            #region shop

            int k = 0;
            foreach (var shopConfig in mapConfig.Shop)
            {

                k++;
                List<MapPoint> pointList = new List<MapPoint>();
                foreach (var p in shopConfig)
                {
                    MapPoint point = new MapPoint(canvas.Width * p.X, canvas.Height * p.Y);
                    pointList.Add(point);
                }
                ShopModel shopModel = new ShopModel(pointList, new MapColor(255, 234, 111, 234));

                ShopLayerModel shopLayerModel = new ShopLayerModel();
                shopLayerModel.ZIndex = 2;
                //SolidColorBrush shadowBrush = new SolidColorBrush();
                //shadowBrush.Color = Color.FromArgb(255, 249, 247, 244);
                MapElementView sv = new ShopView.ShopView(shopModel, shopLayerModel.ZIndex);
                shopLayerView.Add(sv);


            }

            #endregion

            #region Sensor

            //foreach (var sensorConfig in mapConfig.Sensor)
            //{
            //    Point point = new Point(canvas.Width * sensorConfig.X, canvas.Height * sensorConfig.Y);
            //    List<double> direction = new List<double>();
            //    direction.Add(1);
            //    direction.Add(0);

            //    SensorModel sensorModel = new SensorModel(point, "1", 200, 24, direction);
            //    MapElementView sv = new SensorView.SensorView(sensorModel, 9);
            //    sensorLayerView.Add(sv);

            //}

            #endregion

            #region path

            PathLayerModel plm = new PathLayerModel();

            #region 测试数据
            MapColor pathColor = new MapColor(255, 254, 253, 177);
            MapColor pathSideColor = new MapColor(255, 211, 197, 148);
            double pathWidth = 5;

            #endregion



            plm.PathSideColor = pathSideColor;
            plm.PathColor = pathColor;
            plm.PathWidth = pathWidth;
            plm.ZIndex = 7;


            for (int i = 0; i < mapConfig.Pathor.Count; i++)
            {
                MapPoint start = new MapPoint(mapConfig.Pathor[i].StartPoint.X * 800, mapConfig.Pathor[i].StartPoint.Y * 600);
                MapPoint end = new MapPoint(mapConfig.Pathor[i].EndPoint.X * 800, mapConfig.Pathor[i].EndPoint.Y * 600);
                PathModel pathModel = new PathModel(start, end);

                plm.PathModels.Add(pathModel);
            }




            LayerView pathLayerView = new PathLayerView(plm,8);



            for (int i = 0; i < mapConfig.Pathor.Count; i++)
            {
                MapPoint start = new MapPoint(mapConfig.Pathor[i].StartPoint.X * 800, mapConfig.Pathor[i].StartPoint.Y * 600);
                MapPoint end = new MapPoint(mapConfig.Pathor[i].EndPoint.X * 800, mapConfig.Pathor[i].EndPoint.Y * 600);
                PathModel pathModel = new PathModel(start, end);
                MapElementView pathView = new PathView.PathView(pathModel, plm.PathWidth, Utils.GetBrush(plm.PathColor), Utils.GetBrush(plm.PathSideColor), plm.ZIndex);

                pathLayerView.Add(pathView);
            }
            pathLayerView.Visible = true;
            #endregion

            #region wall

            #region 测试数据

            if (mapConfig.Wall.Count > 0)
            {
                List<MapPoint> wallInner = new List<MapPoint>();
                List<MapPoint> wallOuter = new List<MapPoint>();


                for (int i = 0; i < mapConfig.Wall[0].Count; i++)
                {
                    wallInner.Add(new MapPoint(mapConfig.Wall[0][i].X * 800, mapConfig.Wall[0][i].Y * 600));
                }


                for (int i = 0; i < mapConfig.Wall[1].Count; i++)
                {
                    wallOuter.Add(new MapPoint(mapConfig.Wall[1][i].X * 800, mapConfig.Wall[1][i].Y * 600));
                }


                MapColor wallColor = new MapColor(255, 255, 222, 102);

                MapColor wallSideColor = new MapColor(255, 225, 173, 85);



                WallModel wallModel = new WallModel();
                wallModel.WallInner = wallInner;
                wallModel.WallOuter = wallOuter;

                WallLayerModel wlm = new WallLayerModel();
                wlm.WallColor = wallColor;
                wlm.WallSideColor = wallSideColor;
                wlm.WallModels.Add(wallModel);
                wlm.ZIndex = 40;


            #endregion

                MapElementView wall = new WallView.WallView(wallModel, Utils.GetBrush(wlm.WallColor), Utils.GetBrush(wlm.WallSideColor), wlm.ZIndex);

               

                wallLayerView.Add(wall);

            }
            #endregion

            this.MapElementViews.Add(roomLayerView);
            this.MapElementViews.Add(shopLayerView);
            //this.MapElementViews.Add(sensorLayerView);
            this.MapElementViews.Add(pathLayerView);
             this.MapElementViews.Add(wallLayerView);

        }
    }
}
