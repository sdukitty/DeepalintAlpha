using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Deepglint.DeepglintAlpha.Model.MapModel.Shop
{
    public class ShopModel : BaseModel
    {
        public List<MapPoint> PointList { get; set; }

        public MapColor Color { get; set; }


        #region 方法

        public ShopModel(List<MapPoint> pointList, MapColor color)
        {
            this.PointList = pointList;
            this.Color = color;
        }

        //public void GetColor(int num)
        //{
        //    switch (num % 17)
        //    {
        //        case 0:
        //            this.Color = Brushes.MediumPurple;
        //            break;
        //        case 1:
        //            this.Color = Brushes.Red;
        //            break;
        //        case 2:
        //            this.Color = Brushes.Blue;
        //            break;
        //        case 3:
        //            this.Color = Brushes.Yellow;
        //            break;
        //        case 4:
        //            this.Color = Brushes.Purple;
        //            break;
        //        case 5:
        //            this.Color = Brushes.Pink;
        //            break;
        //        case 6:
        //            this.Color = Brushes.Orange;
        //            break;
        //        case 7:
        //            this.Color = Brushes.Green;
        //            break;
        //        case 8:
        //            this.Color = Brushes.Gold;
        //            break;
        //        case 9:
        //            this.Color = Brushes.LightSkyBlue;
        //            break;
        //        case 10:
        //            this.Color = Brushes.OrangeRed;
        //            break;
        //        case 11:
        //            this.Color = Brushes.YellowGreen;
        //            break;
        //        case 12:
        //            this.Color = Brushes.Tomato;
        //            break;
        //        case 13:
        //            this.Color = Brushes.Teal;
        //            break;
        //        case 14:
        //            this.Color = Brushes.SandyBrown;
        //            break;
        //        case 15:
        //            this.Color = Brushes.RosyBrown;
        //            break;
        //        case 16:
        //            this.Color = Brushes.MediumBlue;
        //            break;
        //        default:
        //            this.Color = null;
        //            break;

        //    }

        //}

        #endregion
    }
}
