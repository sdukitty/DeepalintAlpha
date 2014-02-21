using Deepglint.DeepglintAlpha.Model.MapModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;

namespace Deepglint.DeepglintAlpha.Util
{
    public class Utils
    {

        public static SolidColorBrush GetBrush(MapColor color)
        {
            if (color != null)
            {
                SolidColorBrush brush = new SolidColorBrush();
                brush.Color = Color.FromArgb(Convert.ToByte(color.A), Convert.ToByte(color.R),
                    Convert.ToByte(color.G), Convert.ToByte(color.B));
                return brush;
            }
            return null;
        }


        public static Point GetPoint(MapPoint mapPoint)
        {
            
            return new Point(mapPoint.X, mapPoint.Y);
        }

        public static Brush GetShopColor(int num)
        {
            switch (num % 17)
            {
                case 0:
                    return Brushes.MediumPurple;
                case 1:
                    return Brushes.Red;

                case 2:
                    return Brushes.Blue;
      
                case 3:
                    return Brushes.Yellow;
            
                case 4:
                    return Brushes.Purple;

                case 5:
                    return Brushes.Pink;
           
                case 6:
                    return Brushes.Orange;
            
                case 7:
                    return Brushes.Green;
               
                case 8:
                    return Brushes.Gold;
         
                case 9:
                    return Brushes.LightSkyBlue;
          
                case 10:
                    return Brushes.OrangeRed;
       
                case 11:
                    return Brushes.YellowGreen;
          
                case 12:
                    return Brushes.Tomato;
    
                case 13:
                    return Brushes.Teal;
                 
                case 14:
                     return  Brushes.SandyBrown;
              
                case 15:
                    return Brushes.RosyBrown;
              
                case 16:
                    return Brushes.MediumBlue;
           
                default:
                    return null;
               

            }
        
        }
    }
}
