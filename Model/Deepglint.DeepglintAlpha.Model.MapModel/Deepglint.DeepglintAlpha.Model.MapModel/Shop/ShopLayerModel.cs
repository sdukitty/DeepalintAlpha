using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Deepglint.DeepglintAlpha.Model.MapModel.Shop
{
    public class ShopLayerModel : BaseModel
    {
        public List<ShopModel> Shops { get; set; }

        public int ZIndex { get; set; }
    }
}
