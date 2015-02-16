using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Activity.TestProject.Models
{
    public class CreateUnstartEventModel
    {
        [JsonProperty(PropertyName = "location")]
        public LocationModel Location { get; set; }

        [JsonProperty(PropertyName = "organizer")]
        public Guid Organizer { get; set; }
    }

    public class StartUnstartEventModel
    {

        /// <summary>
        /// 天气
        /// </summary>
        [JsonProperty(PropertyName = "weather")]
        public int Weather { get; set; }

        /// <summary>
        /// 事件标题
        /// </summary>
        [JsonProperty(PropertyName = "title")]
        public string ActivityName { get; set; }

        /// <summary>
        /// 事件封面
        /// </summary>
        [JsonProperty(PropertyName = "cover")]
        public FileModel ActivityCover { get; set; }

        /// <summary>
        /// 参与者ID
        /// </summary>
        [JsonProperty(PropertyName = "mates")]
        public List<Guid> Participants { get; set; }
    }

    public class UpdateActivityModel
    {
        /// <summary>
        /// 事件封面
        /// </summary>
        [JsonProperty(PropertyName = "cover")]
        public FileModel ActivityCover { get; set; }
        
    }
}
