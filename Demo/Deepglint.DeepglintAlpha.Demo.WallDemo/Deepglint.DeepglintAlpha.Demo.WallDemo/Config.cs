using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Windows;

namespace Deepglint.DeepglintAlpha.Demo.WallDemo
{
    public class Config:BaseModel
    {
        #region Attribute

        public List<List<Point>> Wall { set; get; }

        public List<Passage> Passage { set; get; }

        public List<List<Point>> Room { set; get; }

        public List<List<Point>> Shop { set; get; }

        public List<Point> Sensor { set; get; }

        #endregion

        #region Action

        public Config()
        {
            this.Wall = new List<List<Point>>();
            this.Passage = new List<Passage>();
            this.Room = new List<List<Point>>();
            this.Shop = new List<List<Point>>();
            this.Sensor = new List<Point>();
        }

        public Config(List<List<Point>> wall, List<Passage> passage, List<List<Point>> room, List<List<Point>> shop, List<Point> sensor)
        {
            this.Wall = wall;
            this.Passage = passage;
            this.Room = room;
            this.Shop = shop;
            this.Sensor = sensor;
        }

        #endregion

    }
}
