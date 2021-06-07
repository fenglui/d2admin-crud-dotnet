using Qiniu.Storage;
using Qiniu.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace d2admin.Services
{
    public class QiniuMac
    {
        public string AccessKey { get; set; }
        public string SecretKey { get; set; }
        public string Bucket { get; set; }
    }

    public static class QiniuHelper
    {
        public static String GetToken(QiniuMac mac, string key, int expires = 7200)
        {
            PutPolicy putPolicy = new PutPolicy();

            // 如果需要设置为"覆盖"上传(如果云端已有同名文件则覆盖)，请使用 SCOPE = "BUCKET:KEY"
            // putPolicy.Scope = bucket + ":" + saveKey;
            if (String.IsNullOrEmpty(key))
            {
                putPolicy.Scope = mac.Bucket;
            }
            else
            {
                putPolicy.Scope = mac.Bucket + ":" + key;
            }

            putPolicy.SetExpires(expires);
            string token = Auth.CreateUploadToken(new Mac(mac.AccessKey, mac.SecretKey), putPolicy.ToJsonString());
            return token;
        }
    }
}
