using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;

namespace ForKids.Util
{
    public class ImageHelper
    {
        /// <summary>
        /// 字节数组生成图片
        /// </summary>
        /// <param name="Bytes">字节数组</param>
        /// <returns>图片</returns>
        public static Image ByteArrayToImage(byte[] Bytes)
        {
            MemoryStream ms = new MemoryStream(Bytes);
            Image outputImg = Image.FromStream(ms);
            return outputImg;
        }

        /// <summary>
        /// 图片转成成字节数组
        /// </summary>
        /// <param name="inputImg">图片对象</param>
        /// <param name="format">图片转成字节的图片格式</param>
        /// <returns>字节数组</returns>
        public static byte[] ImageToByteArray(Image inputImg,System.Drawing.Imaging.ImageFormat format)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                inputImg.Save(ms, format);
                return ms.ToArray();
            }
        }
    }
}
