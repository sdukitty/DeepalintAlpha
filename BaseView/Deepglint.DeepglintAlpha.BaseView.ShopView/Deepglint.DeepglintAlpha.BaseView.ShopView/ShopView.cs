using Deepglint.DeepglintAlpha.Model.MapModel.Shop;
using Deepglint.DeepglintAlpha.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Deepglint.DeepglintAlpha.BaseView.ShopView
{
    public class ShopView : MapElementView
    {

        public ShopControl shopControl { get; set; }


        public ShopView(ShopModel shopModel,  int zIndex)
        {

            List<Point> shopPointList = new List<Point>();

            foreach (var p in shopModel.PointList)
            {
                shopPointList.Add(Utils.GetPoint(p));
            }
            shopControl = new ShopControl(shopPointList, Utils.GetBrush(shopModel.Color), zIndex);
        }

        public override void Draw(Canvas canvas)
        {
            canvas.Children.Add(shopControl);
        }

        public override void DisVisiable()
        {
            this.shopControl.Visibility = System.Windows.Visibility.Collapsed;
        }

        public override void IsVisiable()
        {
            this.shopControl.Visibility = System.Windows.Visibility.Visible;
        }
    }
}
