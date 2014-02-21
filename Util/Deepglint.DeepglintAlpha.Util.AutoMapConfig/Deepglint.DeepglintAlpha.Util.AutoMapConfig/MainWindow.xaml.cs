using Deepglint.DeepglintAlpha.Model.MapModel;
using Deepglint.DeepglintAlpha.Model.MapModel.Path;
using Microsoft.Win32;
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

namespace Deepglint.DeepglintAlpha.Util.AutoMapConfig
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private MapConfig config = new MapConfig();
        private List<Point> pointList = new List<Point>();
        private Point pointOne = new Point(0, 0),
            pointAno = new Point(0, 0);
        private double width, height;

        public MainWindow()
        {
            InitializeComponent();

            Init();
        }

        private void Init()
        {

            this.label.Content = "";
            this.configPath.Text = "";
            this.imagePath.Text = "";
        }

        private Point ModifyPoint(Point one, Point another)
        {
            if (Math.Abs(another.X - one.X) < 3)
                another.X = one.X;
            if (Math.Abs(another.Y - one.Y) < 3)
                another.Y = one.Y;

            Point modifiedPoint = new Point(Convert.ToInt32(another.X), Convert.ToInt32(another.Y));
            return modifiedPoint;
        }

        #region Event

        private void image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //MessageBox.Show(Mouse.GetPosition(this.image).X.ToString());

            if (this.radioWall.IsChecked == true || this.radioRoom.IsChecked == true ||
                this.radioShop.IsChecked == true)
            {
                pointOne = pointAno;
                pointAno = ModifyPoint(pointOne, Mouse.GetPosition(this.image));
                pointList.Add(new Point(pointAno.X / width, pointAno.Y / height));
            }

            if (this.radioPassage.IsChecked == true)
            {
                pointOne = pointAno;
                pointAno = ModifyPoint(pointOne, Mouse.GetPosition(this.image));
            }

            if (this.radioSensor.IsChecked == true)
            {
                pointOne = pointAno;
                pointAno = ModifyPoint(pointOne, Mouse.GetPosition(this.image));
                config.Sensor.Add(new Point(pointAno.X / width, pointAno.Y / height));
            }

            this.textBox.Text += "(" + pointAno.X + "," + pointAno.Y + ")";
        }

        private void endButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.radioWall.IsChecked == true)
            {
                config.Wall.Add(pointList);
                pointList = new List<Point>();
            }

            if (this.radioRoom.IsChecked == true)
            {
                System.Console.WriteLine(pointList[0].X);
                config.Room.Add(pointList);
                pointList = new List<Point>();
            }

            if (this.radioShop.IsChecked == true)
            {
                config.Shop.Add(pointList);
                pointList = new List<Point>();
            }

            if (this.radioPassage.IsChecked == true)
            {
                PathModel passage = new PathModel(new MapPoint(pointOne.X / width, pointOne.Y / height), new MapPoint(pointAno.X / width, pointAno.Y / height));
                config.Pathor.Add(passage);
            }
            this.textBox.Clear();
        }

        private void radioRoom_Checked(object sender, RoutedEventArgs e)
        {
            this.textBox.Clear();
        }

        #endregion

        private void GenerateJson_Click(object sender, RoutedEventArgs e)
        {
            if (this.configPath.Text != "")
            {
                string path = this.configPath.Text.ToString().Trim();
                //System.Console.WriteLine(config.ToJson());
                StreamWriter streamWriter = new StreamWriter(path);

                streamWriter.Write(config.ToJson());
                streamWriter.Close();
            }
            //Config config1 = Config.ToSerializableClass<Config>(config.ToJson());
            this.label.Content = "--DONE--";
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.DefaultExt = ".png";
            openFileDialog.Filter = "png File|*.png";
            if (openFileDialog.ShowDialog() == true)
            {
                this.imagePath.Text = openFileDialog.FileName;
                this.image.Source = new BitmapImage(new Uri(openFileDialog.FileName, UriKind.Absolute));

                width = this.image.Width;
                height = this.image.Height;
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.DefaultExt = ".txt";
            openFileDialog.Filter = "txt File|*.txt";
            if (openFileDialog.ShowDialog() == true)
            {
                this.configPath.Text = openFileDialog.FileName;
            }
        }
    }
}
