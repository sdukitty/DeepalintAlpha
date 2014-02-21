using Deepglint.DeepglintAlpha.Model.MapModel.Path;
using Deepglint.DeepglintAlpha.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Deepglint.DeepglintAlpha.BaseView.PathView
{
    public class PathView : MapElementView
    {



        #region 属性

        public double PathWidth { set; get; }

        public Brush PathColor { set; get; }

        public Brush PathSideColor { set; get; }

        public PathModel PathModelSingle { set; get; }

        public Path PathLane { get; set; }

        public Path PathRoad { get; set; }

        #endregion

        #region 方法

        public PathView(PathModel pathModel, double pathWidth, Brush pathColor, Brush pathSideColor, int zIdex)
        {
            this.PathModelSingle = pathModel;
            this.PathWidth = pathWidth;
            this.PathColor = pathColor;
            this.PathSideColor = pathSideColor;
            this.Zindex = zIdex;
            PathLane = new Path();
            PathRoad = new Path();
        }

        public override void Draw(Canvas canvas)
        {
            DrawSidePath(canvas, this.PathModelSingle, this.PathWidth, this.PathSideColor);
            DrawSinglePath(canvas, this.PathModelSingle, this.PathWidth, this.PathColor);
        }

        private void DrawSinglePath(Canvas canvas, PathModel pathModel, double pathWidth, Brush pathColor)
        {
            PathGeometry pathGeometry = new PathGeometry();
            PathFigureCollection pathFigureCollection = new PathFigureCollection();

            PathFigure pathFigure = new PathFigure();
            pathFigure.StartPoint = Utils.GetPoint(pathModel.StartPoint);
            LineSegment lineSegment = new LineSegment();
            lineSegment.Point = Utils.GetPoint(pathModel.EndPoint);
            PathSegmentCollection pathSegmentCollection = new PathSegmentCollection();
            pathSegmentCollection.Add(lineSegment);
            pathFigure.Segments = pathSegmentCollection;
            pathFigureCollection.Add(pathFigure);

            pathGeometry.Figures = pathFigureCollection;

      
            PathRoad.Stroke = pathColor;
            PathRoad.StrokeThickness = pathWidth - 2;
            PathRoad.Data = pathGeometry;
            PathRoad.SetValue(Canvas.ZIndexProperty, this.Zindex);

            canvas.Children.Add(PathRoad);
        }

        public void DrawSidePath(Canvas canvas, PathModel pathModel, double pathWidth, Brush pathSideColor)
        {
            PathGeometry pathGeometry = new PathGeometry();
            PathFigureCollection pathFigureCollection = new PathFigureCollection();
            Point startPoint1, startPoint2, endPoint1, endPoint2;
            Point start = Utils.GetPoint(pathModel.StartPoint);
            Point end = Utils.GetPoint(pathModel.EndPoint);
            if (end.X == start.X)
            {
                startPoint1 = new Point(start.X - (pathWidth - 1) / 2, start.Y);
                endPoint1 = new Point(end.X - (pathWidth - 1) / 2, end.Y);
                startPoint2 = new Point(start.X + (pathWidth - 1) / 2, start.Y);
                endPoint2 = new Point(end.X + (pathWidth - 1) / 2, end.Y);
            }
            else if (end.Y == start.Y)
            {
                startPoint1 = new Point(start.X, start.Y - (pathWidth - 1) / 2);
                endPoint1 = new Point(end.X, end.Y - (pathWidth - 1) / 2);
                startPoint2 = new Point(start.X, start.Y + (pathWidth - 1) / 2);
                endPoint2 = new Point(end.X, end.Y + (pathWidth - 1) / 2);
            }
            else
            {
                double slope = (end.Y - start.Y) / (end.X - start.X);
                //double reverse = -1 / slope;
                //double angle = Math.Atan(reverse) * 180 / Math.PI;

                //startPoint1 = new Point(start.X + pathWidth * Math.Cos(angle) / 2, start.Y + pathWidth * Math.Sin(angle) / 2);
                //startPoint2 = new Point(start.X - pathWidth * Math.Cos(angle) / 2, start.Y - pathWidth * Math.Sin(angle) / 2);
                //endPoint1 = new Point(end.X + pathWidth * Math.Cos(angle) / 2, end.Y + pathWidth * Math.Sin(angle) / 2);
                //endPoint2 = new Point(end.X - pathWidth * Math.Cos(angle) / 2, end.Y - pathWidth * Math.Sin(angle) / 2);
                startPoint1 = new Point(start.X + Math.Abs(slope) * pathWidth / (2 * Math.Sqrt(slope * slope + 1)),
                    start.Y - Math.Abs(slope) * pathWidth / (2 * slope * Math.Sqrt(slope * slope + 1)));
                startPoint2 = new Point(start.X - Math.Abs(slope) * pathWidth / (2 * Math.Sqrt(slope * slope + 1)),
                    start.Y + Math.Abs(slope) * pathWidth / (2 * slope * Math.Sqrt(slope * slope + 1)));
                endPoint1 = new Point(end.X + Math.Abs(slope) * pathWidth / (2 * Math.Sqrt(slope * slope + 1)),
                    end.Y - Math.Abs(slope) * pathWidth / (2 * slope * Math.Sqrt(slope * slope + 1)));
                endPoint2 = new Point(end.X - Math.Abs(slope) * pathWidth / (2 * Math.Sqrt(slope * slope + 1)),
                    end.Y + Math.Abs(slope) * pathWidth / (2 * slope * Math.Sqrt(slope * slope + 1)));
            }

            PathFigure pathFigure = new PathFigure();
            pathFigure.StartPoint = startPoint1;
            LineSegment lineSegment = new LineSegment();
            lineSegment.Point = endPoint1;
            PathSegmentCollection pathSegmentCollection = new PathSegmentCollection();
            pathSegmentCollection.Add(lineSegment);
            pathFigure.Segments = pathSegmentCollection;
            pathFigureCollection.Add(pathFigure);

            PathFigure pathFigure2 = new PathFigure();
            pathFigure2.StartPoint = startPoint2;
            LineSegment lineSegment2 = new LineSegment();
            lineSegment2.Point = endPoint2;
            PathSegmentCollection pathSegmentCollection2 = new PathSegmentCollection();
            pathSegmentCollection2.Add(lineSegment2);
            pathFigure2.Segments = pathSegmentCollection2;
            pathFigureCollection.Add(pathFigure2);

            pathGeometry.Figures = pathFigureCollection;


            PathLane.Stroke = pathSideColor;
            PathLane.StrokeThickness = 2;
            PathLane.Data = pathGeometry;

            PathLane.SetValue(Canvas.ZIndexProperty, this.Zindex);
            canvas.Children.Add(PathLane);
        }



        public override void DisVisiable()
        {
            this.PathLane.Visibility = System.Windows.Visibility.Collapsed;
            this.PathRoad.Visibility = System.Windows.Visibility.Collapsed;
        }

        public override void IsVisiable()
        {
            this.PathLane.Visibility = System.Windows.Visibility.Visible;
            this.PathRoad.Visibility = System.Windows.Visibility.Visible;
        }

        #endregion

        #region Event

        #endregion



    }
}
