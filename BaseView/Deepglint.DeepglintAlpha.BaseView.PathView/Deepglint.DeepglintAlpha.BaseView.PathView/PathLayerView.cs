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
    public class PathLayerView : LayerView
    {

        #region 属性

        public PathLayerModel PathLayerModelSingle { set; get; }

        public List<Path> PathList { get; set; }


        #endregion

        #region 方法

        public PathLayerView() : base() { }

        public PathLayerView(PathLayerModel pathLayerModel,int zIndex)
            : base()
        {
            PathList = new List<Path>();
            this.PathLayerModelSingle = pathLayerModel;

            this.Zindex = zIndex;

            foreach (PathModel pathModel in this.PathLayerModelSingle.PathModels)
            {
                InilizeSinglePath(pathModel, this.PathLayerModelSingle.PathWidth, Utils.GetBrush(this.PathLayerModelSingle.PathColor));
            }
           
        }

        public override void Draw(Canvas canvas)
        {
            foreach (MapElementView mapElementView in this.MapElementViews)
            {
                mapElementView.Draw(canvas);
            }

            foreach (var path in PathList)
            {
                canvas.Children.Add(path);
            }

        }

        private void InilizeSinglePath(PathModel pathModel, double pathWidth, Brush pathColor)
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

            Path path = new Path();
            path.Stroke = pathColor;
            path.StrokeThickness = pathWidth - 2;
            path.Data = pathGeometry;
            path.SetValue(Canvas.ZIndexProperty, this.Zindex);
            PathList.Add(path);
        
        
        }

        public override void IsVisiable()
        {
            foreach (MapElementView mapElementView in this.MapElementViews)
            {
                mapElementView.Visible=true;
            }

            foreach (var path in PathList)
            {
                path.Visibility = System.Windows.Visibility.Visible;
            }
        }

        public override void DisVisiable()
        {
            foreach (MapElementView mapElementView in this.MapElementViews)
            {
                mapElementView.Visible = false ;
            }
            foreach (var path in PathList)
            {
                path.Visibility = System.Windows.Visibility.Collapsed;
            }
        }

        #endregion
    }
}
