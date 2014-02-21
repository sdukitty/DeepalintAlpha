using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Deepglint.DeepglintAlpha.Demo.WallDemo
{
    public class BaseModel
    {
        /// <summary>
        /// 将可序列化的对象转换为Json
        /// </summary>
        /// <returns>Json字符串</returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }

        /// <summary>
        /// 返回可反序列化的对象
        /// </summary>
        /// <param name="json">Json字符串</param>
        /// <returns>反序列化的对象</returns>
        public static T ToSerializableClass<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}
