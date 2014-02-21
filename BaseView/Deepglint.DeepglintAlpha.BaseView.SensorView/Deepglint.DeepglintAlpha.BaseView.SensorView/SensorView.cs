using Deepglint.DeepglintAlpha.Model.MapModel.Model.Sensor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Deepglint.DeepglintAlpha.BaseView.SensorView
{
    public class SensorView : MapElementView
    {
        public SensorControl sensorControl { get; set; }

        public SensorView( SensorModel sensorModel,int zIndex)
        { 
        this.ID=sensorModel.ID;
        this.Zindex = zIndex;
        sensorControl = new SensorControl(sensorModel.CenterPoint, sensorModel.ScopeDistance, sensorModel.SensorSize, sensorModel.Direction,this.ID,Zindex);
        }

        public override void Draw(System.Windows.Controls.Canvas canvas)
        {
            canvas.Children.Add(sensorControl);
        }

        public override void DisVisiable()
        {
            this.sensorControl.Visibility = System.Windows.Visibility.Collapsed;
        }

        public override void IsVisiable()
        {
            this.sensorControl.Visibility = System.Windows.Visibility.Visible;
        }
    }
}
