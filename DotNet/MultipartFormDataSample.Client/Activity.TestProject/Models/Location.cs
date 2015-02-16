using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Activity.TestProject.Models
{
    public class LocationModel
    {
        /// <summary>
        /// 经度
        /// </summary>
        [JsonProperty(PropertyName = "lng")]
        public float Longitude { get; set; }

        /// <summary>
        /// 纬度
        /// </summary>
        [JsonProperty(PropertyName = "lat")]
        public float Latitude { get; set; }

        /// <summary>
        /// 显示地名
        /// </summary>
        [JsonProperty(PropertyName = "display")]
        public string DisplayName { get; set; }
    }
}
