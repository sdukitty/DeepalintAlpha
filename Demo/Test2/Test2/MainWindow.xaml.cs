
using Deepglint.DeepglintAlpha.BaseView.MapBox;
using Deepglint.DeepglintAlpha.BaseView.MapBox.Model;
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

namespace Test2
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MapBox mapBox = new MapBox(800, 600, @"C:\Users\deepglint\Desktop\bin\Debug\Resource\config.txt");
            VisualWindowModel visualWindow = new VisualWindowModel(1, new Point(400, 300));
          
            this.grid.Children.Add(mapBox);

            //mapBox.VisualWindow(visualWindow);
        }
    }
}
