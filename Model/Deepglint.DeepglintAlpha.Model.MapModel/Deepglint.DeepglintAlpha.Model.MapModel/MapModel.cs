using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Deepglint.DeepglintAlpha.Model.MapModel
{
    public class MapModel : BaseModel
    {
        public string MapID { get; set; }

        public string ServerIP { get; set; }

        public int FileServerPort { get; set; }

        public int InfoServerPort { get; set; }
        
        public List<GroupModel> Groups { get; set; }
    }
}
