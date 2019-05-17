using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lottak.Core.Common
{
    public class SecuritySettings
    {
        private string _encryptionKey;
        private const string key = "25126848FE0144F4A0E04D82066F25B7";//默认加密字符串
        /// <summary>
        /// 读取或设置密钥
        /// </summary>
        public string EncryptionKey
        {
            get
            {
                return _encryptionKey ?? key;
            }
            set { _encryptionKey = value; }
        }
    }
}
