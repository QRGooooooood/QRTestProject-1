using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultipartFormDataSample.Client
{
    //public class FileModel<T>
    //{
    //    public T Entity { get; set; }
    //    public FileModel Image { get; set; }
    //}
    public class CreateActivityModel
    {
        /// <summary>
        /// 事件主题
        /// </summary>
        [JsonProperty(PropertyName = "title")]
        public string ActivityName { get; set; }

        /// <summary>
        /// 事件封面
        /// </summary>
         [JsonProperty(PropertyName = "cover")]
        public FileModel ActivityCover { get; set; }

        /// <summary>
        /// 创建者
        /// </summary>
        [JsonProperty(PropertyName = "organizer")]
        public Guid CreatorId { get; set; }

        /// <summary>
        /// 天气
        /// </summary>
        [JsonProperty(PropertyName = "weather")]
        public Weather Weather { get; set; }

        /// <summary>
        /// 地理位置
        /// </summary>
           [JsonProperty(PropertyName = "location")]
        public LocationModel Location { get; set; }

        /// <summary>
        /// 参与者
        /// </summary>
        [JsonProperty(PropertyName = "mates")]
        public List<Guid> Participants { get; set; }
    }

    //public class ImageModel
    //{
    //    public string FileName { get; set; }

    //    public string MediaType { get; set; }

    //    public byte[] Buffer { get; set; }

    //    public ImageModel(string fileName, string mediaType, byte[] imagebuffer)
    //    {
    //        FileName = fileName;
    //        MediaType = mediaType;
    //        Buffer = imagebuffer;
    //    }
    //}

    public class FileModel
    {
        /// <summary>
        /// 文件名称
        /// </summary>
        // [DataMember]
        public string FileName { get; set; }

        /// <summary>
        /// 文件类型
        /// </summary>
        // [DataMember]
        public FileType FileType { get; set; }

        /// <summary>
        /// 文件二进制数据
        /// </summary>
        // [DataMember]
        public byte[] FileBytes { get; set; }

        public string GetExtension()
        {
            string extension = string.Empty;
            if (string.IsNullOrEmpty(FileName))
                return extension;

            if (FileName.IndexOf(".") == 0)
                return extension;

            extension = FileName.Split('.')[1];
            return extension;
        }
    }

    /// <summary>
    /// 文件类型
    /// </summary>
    public enum FileType
    {
        /// <summary>
        /// 图像
        /// </summary>
        Image,

        /// <summary>
        /// 音频
        /// </summary>
        Audio,

        /// <summary>
        ///视频
        /// </summary>
        Vedio
    }

    public enum Weather
    {
        Sun,
        Cloud
    }

    public class LocationModel
    {
        /// <summary>
        /// 经度
        /// </summary>
        public float Longitude { get; set; }

        /// <summary>
        /// 纬度
        /// </summary>
        public float Latitude { get; set; }

        /// <summary>
        /// 显示地名
        /// </summary>
        public string DisplayName { get; set; }
    }
}
