using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ForKids.Util
{
    public class SecurityHelper
    {
        /// <summary>
        /// 加密方法
        /// </summary>
        /// <param name="Source">待加密的串</param>
        /// <returns>经过加密的串</returns>
        public static string Encrypto(string Source)
        {
            //RsNGDBMngSys.Util.EncryptHelper.EncryptMode= RsNGDBMngSys.Util.Encryption.EncryptionMode.DES;
            //return RsNGDBMngSys.Util.EncryptHelper.Encrypt(Source);
            try
            {
                return SymmetricMethod.Encrypto(Source);
            }
            catch// (Exception ex)
            {
                //System.Windows.Forms.MessageBox.Show("加密失败！" + ex.Message);
                return null;
            }
        }
        /// <summary>
        /// 解密方法
        /// </summary>
        /// <param name="Source">待解密的串</param>
        /// <returns>经过解密的串</returns>
        public static string Decrypto(string Source)
        {
            //RsNGDBMngSys.Util.EncryptHelper.EncryptMode = RsNGDBMngSys.Util.Encryption.EncryptionMode.DES;
            //return RsNGDBMngSys.Util.EncryptHelper.Decrypt(Source);
            try
            {
                return SymmetricMethod.Decrypto(Source);
            }
            catch// (Exception ex)
            {
                //System.Windows.Forms.MessageBox.Show("解密失败！" + ex.Message);
                return null;
            }
        }
    }
}
