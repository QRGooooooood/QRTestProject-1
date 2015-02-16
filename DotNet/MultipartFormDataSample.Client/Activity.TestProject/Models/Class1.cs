using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Activity.TestProject.Models
{
    public class AddParticipantModel
    {
        /// <summary>
        /// 参与者Id
        /// </summary>
        [JsonProperty(PropertyName = "mateid")]
        public Guid MateId { get; set; }

        /// <summary>
        /// 操作者Id
        /// </summary>
        [JsonProperty(PropertyName = "uid")]
        public Guid UserId { get; set; }
    }
}
