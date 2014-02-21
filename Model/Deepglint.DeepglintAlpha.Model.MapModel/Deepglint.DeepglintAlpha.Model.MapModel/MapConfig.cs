using Deepglint.DeepglintAlpha.Model.MapModel.Path;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace Deepglint.DeepglintAlpha.Model.MapModel
{
    public class MapConfig : BaseModel
    {
        #region Attribute

        public List<List<Point>> Wall { set; get; }

        public List<PathModel> Pathor { set; get; }

        public List<List<Point>> Room { set; get; }

        public List<List<Point>> Shop { set; get; }

        public List<Point> Sensor { set; get; }

        #endregion

        #region Action

        public MapConfig()
        {
            this.Wall = new List<List<Point>>();
            this.Pathor = new List<PathModel>();
            this.Room = new List<List<Point>>();
            this.Shop = new List<List<Point>>();
            this.Sensor = new List<Point>();
        }

        public MapConfig(List<List<Point>> wall, List<PathModel> path, List<List<Point>> room, List<List<Point>> shop, List<Point> sensor)
        {
            this.Wall = wall;
            this.Pathor = path;
            this.Room = room;
            this.Shop = shop;
            this.Sensor = sensor;
        }

        #endregion
    }
}
