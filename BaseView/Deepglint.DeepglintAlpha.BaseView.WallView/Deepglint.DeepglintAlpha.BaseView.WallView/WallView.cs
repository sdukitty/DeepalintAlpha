using Deepglint.DeepglintAlpha.Model.MapModel.Wall;
using Deepglint.DeepglintAlpha.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Deepglint.DeepglintAlpha.BaseView.WallView
{
    public class WallView : MapElementView
    {
        #region 属性

        public Brush WallColor { set; get; }

        public Brush WallSideColor { set; get; }

        public WallModel WallModelSingle { set; get; }

        public Path Path { get; set; }

        #endregion


        #region 方法

        public WallView(WallModel wallModel, Brush wallColor, Brush wallSideColor,int zIndex)
        {
            this.WallModelSingle = wallModel;
            this.WallColor = wallColor;
            this.WallSideColor = wallSideColor;

            this.Zindex = zIndex;
            Path = new Path(); 
        }

        public override void Draw(Canvas canvas)
        {
       
            PathGeometry pathGeometry = new PathGeometry();

            PathFigureCollection pathFigureCollection = new PathFigureCollection();

            PathFigure pathFigureInner = new PathFigure { IsClosed = true };
            pathFigureInner.StartPoint = Utils.GetPoint(this.WallModelSingle.WallInner[0]);

            PathSegmentCollection pathSegmentCollectionInner = new PathSegmentCollection();

            for (int i = 1; i < this.WallModelSingle.WallInner.Count; i++)
            {
                LineSegment lineSegment = new LineSegment();
                lineSegment.Point = Utils.GetPoint(this.WallModelSingle.WallInner[i]);
                pathSegmentCollectionInner.Add(lineSegment);
            }
            pathFigureInner.Segments = pathSegmentCollectionInner;
            pathFigureCollection.Add(pathFigureInner);


            PathFigure pathFigureOuter = new PathFigure { IsClosed = true };
            pathFigureOuter.StartPoint = Utils.GetPoint(this.WallModelSingle.WallOuter[0]);
            PathSegmentCollection pathSegmentCollectionOuter = new PathSegmentCollection();
            for (int i = 1; i < this.WallModelSingle.WallOuter.Count; i++)
            {
                LineSegment lineSegment = new LineSegment();
                lineSegment.Point = Utils.GetPoint(this.WallModelSingle.WallOuter[i]);
                pathSegmentCollectionOuter.Add(lineSegment);
            }
            pathFigureOuter.Segments = pathSegmentCollectionOuter;
            pathFigureCollection.Add(pathFigureOuter);

            pathGeometry.Figures = pathFigureCollection;

           
            Path.Stroke = this.WallSideColor;
            Path.StrokeThickness = 2;
            Path.Data = pathGeometry;
            Path.Fill = this.WallColor;

            Path.SetValue(Canvas.ZIndexProperty, this.Zindex);
            canvas.Children.Add(Path);
        }

        #endregion

        public override void DisVisiable()
        {
            this.Path.Visibility = System.Windows.Visibility.Collapsed;
        }

        public override void IsVisiable()
        {
            this.Path.Visibility = System.Windows.Visibility.Visible;
        }
    }
}
