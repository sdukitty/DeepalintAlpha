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

namespace Deepglint.DeepglintAlpha.BaseView.MapControlView
{
    /// <summary>
    /// MapControl.xaml 的交互逻辑
    /// </summary>
    public partial class MapControl : UserControl
    {
        #region 属性

        public SensorLayerGroupModel SensorLayerGroup { get; set; }

        public bool moveStatus;
        public bool zoomStatus;
        public bool wallStatus;
        public bool pathStatus;
        public bool roomStatus;
        public bool shopStatus;
        public bool sensorStatus;
        public bool hotspotStatus;
        //public bool groupComboStatus;
        //public bool sensorComboStatus;
        //public bool hotspotComboStatus;
        public string groupValue;
        public string sensorValue;
        public string hotspotValue;

        #endregion


        BitmapImage move = new BitmapImage(new Uri("/Assets/Move.png", UriKind.Relative));
        BitmapImage moveActive = new BitmapImage(new Uri("/Assets/Move(active).png", UriKind.Relative));
        BitmapImage zoom = new BitmapImage(new Uri("/Assets/Zooming.png", UriKind.Relative));
        BitmapImage zoomActive = new BitmapImage(new Uri("/Assets/Zooming(active).png", UriKind.Relative));
        BitmapImage wall = new BitmapImage(new Uri("/Assets/Wall.png", UriKind.Relative));
        BitmapImage wallActive = new BitmapImage(new Uri("/Assets/Wall(active).png", UriKind.Relative));
        BitmapImage path = new BitmapImage(new Uri("/Assets/Path.png", UriKind.Relative));
        BitmapImage pathActive = new BitmapImage(new Uri("/Assets/Path(active).png", UriKind.Relative));
        BitmapImage room = new BitmapImage(new Uri("/Assets/Room.png", UriKind.Relative));
        BitmapImage roomActive = new BitmapImage(new Uri("/Assets/Room(active).png", UriKind.Relative));
        BitmapImage shop = new BitmapImage(new Uri("/Assets/Shop.png", UriKind.Relative));
        BitmapImage shopActive = new BitmapImage(new Uri("/Assets/Shop(active).png", UriKind.Relative));
        BitmapImage sensor = new BitmapImage(new Uri("/Assets/Sensor.png", UriKind.Relative));
        BitmapImage sensorActive = new BitmapImage(new Uri("/Assets/Sensor(active).png", UriKind.Relative));
        BitmapImage hotspot = new BitmapImage(new Uri("/Assets/Hotspot.png", UriKind.Relative));
        BitmapImage hotspotActive = new BitmapImage(new Uri("/Assets/Hotspot(active).png", UriKind.Relative));
        BitmapImage groupCombo = new BitmapImage(new Uri("/Assets/Group-Combo.png", UriKind.Relative));
        BitmapImage groupComboActive = new BitmapImage(new Uri("/Assets/Group-Combo(active).png", UriKind.Relative));
        BitmapImage sensorCombo = new BitmapImage(new Uri("/Assets/Sensor-Combo.png", UriKind.Relative));
        BitmapImage sensorComboActive = new BitmapImage(new Uri("/Assets/Sensor-Combo(active).png", UriKind.Relative));
        BitmapImage hotspotCombo = new BitmapImage(new Uri("/Assets/Hotspot-Combo.png", UriKind.Relative));
        BitmapImage hotspotComboActive = new BitmapImage(new Uri("/Assets/Hotspot-Combo(active).png", UriKind.Relative));


        #region 方法

        public MapControl(SensorLayerGroupModel sensorLayerGroup)
        {
            InitializeComponent();

            this.SensorLayerGroup = sensorLayerGroup;

            this.moveStatus = true;
            this.zoomStatus = false;
            this.wallStatus = true;
            this.pathStatus = true;
            this.roomStatus = true;
            this.shopStatus = false;
            this.sensorStatus = true;
            this.hotspotStatus = false;
            this.groupValue = "";
            this.sensorValue = "";
            this.hotspotValue = "";
            this.Height = 38;

            InitComboBox();
        }

        private void InitComboBox()
        {
            foreach (SensorLayerModel sensorLayerModel in this.SensorLayerGroup.SensorLayerGroup)
            {
                this.comboGroup.Items.Add(sensorLayerModel.LayerID);
            }
        }

        private void imageMove_MouseEnter(object sender, MouseEventArgs e)
        {
            if (!moveStatus)
                this.imageMove.Source = moveActive;
        }

        private void imageMove_MouseLeave(object sender, MouseEventArgs e)
        {
            if (!moveStatus)
                this.imageMove.Source = move;
        }

        private void imageMove_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (!moveStatus)
            {
                moveStatus = true;
                this.imageMove.Source = moveActive;

                if (zoomStatus)
                {
                    zoomStatus = false;
                    this.imageZoom.Source = zoom;
                }

                this.StatusChangedEvent(this, e);
            }
        }

        private void imageZoom_MouseEnter(object sender, MouseEventArgs e)
        {
            if (!zoomStatus)
                this.imageZoom.Source = zoomActive;
        }

        private void imageZoom_MouseLeave(object sender, MouseEventArgs e)
        {
            if (!zoomStatus)
                this.imageZoom.Source = zoom;
        }

        private void imageZoom_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (!zoomStatus)
            {
                zoomStatus = true;
                this.imageZoom.Source = zoomActive;

                if (moveStatus)
                {
                    moveStatus = false;
                    this.imageMove.Source = move;
                }

                this.StatusChangedEvent(this, e);
            }
        }

        private void imageWall_MouseEnter(object sender, MouseEventArgs e)
        {
            if (!wallStatus)
                this.imageWall.Source = wallActive;
        }

        private void imageWall_MouseLeave(object sender, MouseEventArgs e)
        {
            if (!wallStatus)
                this.imageWall.Source = wall;
        }

        private void imageWall_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            wallStatus = !wallStatus;
            this.imageWall.Source = wallStatus ? wallActive : wall;

            this.StatusChangedEvent(this, e);
        }

        private void imagePath_MouseEnter(object sender, MouseEventArgs e)
        {
            if (!pathStatus)
                this.imagePath.Source = pathActive;
        }

        private void imagePath_MouseLeave(object sender, MouseEventArgs e)
        {
            if (!pathStatus)
                this.imagePath.Source = path;
        }

        private void imagePath_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            pathStatus = !pathStatus;
            this.imagePath.Source = pathStatus ? pathActive : path;

            this.StatusChangedEvent(this, e);
        }

        private void imageRoom_MouseEnter(object sender, MouseEventArgs e)
        {
            if (!roomStatus)
                this.imageRoom.Source = roomActive;
        }

        private void imageRoom_MouseLeave(object sender, MouseEventArgs e)
        {
            if (!roomStatus)
                this.imageRoom.Source = room;
        }

        private void imageRoom_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            roomStatus = !roomStatus;
            this.imageRoom.Source = roomStatus ? roomActive : room;

            this.StatusChangedEvent(this, e);
        }

        private void imageShop_MouseEnter(object sender, MouseEventArgs e)
        {
            if (!shopStatus)
                this.imageShop.Source = shopActive;
        }

        private void imageShop_MouseLeave(object sender, MouseEventArgs e)
        {
            if (!shopStatus)
                this.imageShop.Source = shop;
        }

        private void imageShop_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            shopStatus = !shopStatus;
            this.imageShop.Source = shopStatus ? shopActive : shop;

            this.StatusChangedEvent(this, e);
        }

        private void imageSensor_MouseEnter(object sender, MouseEventArgs e)
        {
            if (!sensorStatus)
                this.imageSensor.Source = sensorActive;
        }

        private void imageSensor_MouseLeave(object sender, MouseEventArgs e)
        {
            if (!sensorStatus)
                this.imageSensor.Source = sensor;
        }

        private void imageSensor_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            sensorStatus = !sensorStatus;
            this.imageSensor.Source = sensorStatus ? sensorActive : sensor;

            this.StatusChangedEvent(this, e);
        }

        private void imageHotspot_MouseEnter(object sender, MouseEventArgs e)
        {
            if (!hotspotStatus)
                this.imageHotspot.Source = hotspotActive;
        }

        private void imageHotspot_MouseLeave(object sender, MouseEventArgs e)
        {
            if (!hotspotStatus)
                this.imageHotspot.Source = hotspot;
        }

        private void imageHotspot_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            hotspotStatus = !hotspotStatus;
            this.imageHotspot.Source = hotspotStatus ? hotspotActive : hotspot;

            this.StatusChangedEvent(this, e);
        }

        private List<SensorModel> GetSensorModels(string layerID)
        {
            foreach (SensorLayerModel sensorLayerModel in this.SensorLayerGroup.SensorLayerGroup)
            {
                if (sensorLayerModel.LayerID.Equals(layerID))
                {
                    return sensorLayerModel.Sensors;
                }
            }
            return null;
        }

        #endregion


        #region 事件

        public event StatusChangedEventHandler StatusChangedEvent;

        public delegate void StatusChangedEventHandler(object sender, MouseButtonEventArgs e);

        public event ValueChangedEventHandler ValueChangedEvent;

        public delegate void ValueChangedEventHandler(object sender, SelectionChangedEventArgs e);

        private void comboGroup_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.comboSensor.Items.Clear();
            foreach (SensorModel sensorModel in GetSensorModels(this.comboGroup.SelectedValue.ToString()))
            {
                this.comboSensor.Items.Add(sensorModel.ID);
            }

            this.groupValue = this.comboGroup.SelectedValue.ToString();

            this.textbox.Text = this.groupValue;

            this.ValueChangedEvent(this, e);
        }

        private void comboSensor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.sensorValue = this.comboSensor.SelectedValue.ToString();

            this.ValueChangedEvent(this, e);
        }

        private void comboHotspot_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.hotspotValue = this.comboHotspot.SelectedValue.ToString();
            this.ValueChangedEvent(this, e);
        }

        #endregion

    }
}
