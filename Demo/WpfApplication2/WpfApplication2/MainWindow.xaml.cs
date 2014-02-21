using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Research.DynamicDataDisplay;
using Microsoft.Research.DynamicDataDisplay.DataSources;
using Microsoft.Research.DynamicDataDisplay.PointMarkers;
using System.Globalization;
using System.Reflection;
using System.IO;
using System.Threading;

namespace WpfApplication2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableDataSource<Point> source1 = null;
        ObservableDataSource<Point> source2 = null;
        ObservableDataSource<Point> source3 = null;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Simulation()
        {
            CultureInfo culture = CultureInfo.InvariantCulture;
            Assembly executingAssembly = Assembly.GetExecutingAssembly();
            // load spim-generated data from embedded resource file
            const string spimDataName = "WpfApplication2.Resource.txt";
            using (Stream spimStream = executingAssembly.GetManifestResourceStream(spimDataName))
            {
                using (StreamReader r = new StreamReader(spimStream))
                {
                    string line = r.ReadLine();
                    while (!r.EndOfStream)
                    {
                        line = r.ReadLine();
                        string[] values = line.Split(',');

                        double x = Double.Parse(values[0], culture);
                        double y1 = Double.Parse(values[1], culture);
                        double y2 = Double.Parse(values[2], culture);
                        double y3 = Double.Parse(values[3], culture);

                        Point p1 = new Point(x, y1);
                        Point p2 = new Point(x, y2);
                        Point p3 = new Point(x, y3);

                        source1.AppendAsync(Dispatcher, p1);
                        source2.AppendAsync(Dispatcher, p2);
                        source3.AppendAsync(Dispatcher, p3);

                        Thread.Sleep(10); // Long-long time for computations...
                    }
                }
            }
        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            source1 = new ObservableDataSource<Point>();
            source1.SetXYMapping(p => p);
            source2 = new ObservableDataSource<Point>();
            source2.SetXYMapping(p => p);
            source3 = new ObservableDataSource<Point>();
            source3.SetXYMapping(p => p);

            //plotter.AddLineGraph(source1,
              //  new Pen(Brushes.DarkGoldenrod, 3),
               // new CirclePointMarker { Size = 10, Fill = Brushes.Red },
                //new PenDescription("Data1"));
            plotter.AddLineGraph(source1, 3, "Data1");
            plotter.AddLineGraph(source2, 3, "Data2");
            plotter.AddLineGraph(source3, 3, "Data3");

            Thread simThread = new Thread(new ThreadStart(Simulation));
            simThread.IsBackground = true;
            simThread.Start();
        }
    }
}
