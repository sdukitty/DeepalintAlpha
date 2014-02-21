using Deepglint.DeepglintAlpha.BaseView.MapControlView;
using Deepglint.DeepglintAlpha.BaseView.SensorView.Model;
using Deepglint.DeepglintAlpha.Model.MapModel.Model.Sensor;
using System;
using System.Collections.Generic;
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

namespace Deepglint.DeepglintAlpha.Demo.MapControlDemo
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            InitControls();
        }

        private void InitControls()
        {
            SensorModel sensorModel = new SensorModel(new Point(100, 100),"s1",20,20,new List<double>());
            SensorLayerModel slm = new SensorLayerModel();
            slm.LayerID = "g1";
            slm.Sensors.Add(sensorModel);
            SensorLayerGroupModel groupsModel = new SensorLayerGroupModel();
            groupsModel.SensorLayerGroup.Add(slm);

            MapControl mapControl = new MapControl(groupsModel);
            mapControl.StatusChangedEvent += mapControls_StatusChangedEvent;
            mapControl.ValueChangedEvent += mapControls_ValueChangedEvent;
            mapControl.Width = 400;
            mapControl.Height = 38;

            this.grid.Children.Add(mapControl);
        }

        private void mapControls_ValueChangedEvent(object sender, SelectionChangedEventArgs e)
        {
            MapControl map = sender as MapControl;
            //MessageBox.Show(map.sensorValue.ToString());
        }

        private void mapControls_StatusChangedEvent(object sender, MouseButtonEventArgs e)
        {
            MapControl map = sender as MapControl;
            //MessageBox.Show(map.moveStatus.ToString());
        }


    }
}
