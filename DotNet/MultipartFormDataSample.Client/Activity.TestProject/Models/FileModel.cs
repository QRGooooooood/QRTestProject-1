using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Activity.TestProject.Models
{
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
}
