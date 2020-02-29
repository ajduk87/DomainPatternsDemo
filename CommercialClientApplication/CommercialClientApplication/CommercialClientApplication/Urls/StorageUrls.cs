using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommercialClientApplication.Urls
{
    public class StorageUrls : Urls
    {
        public string Storage;
        public string StorageContent;

        public StorageUrls()
        {
            this.Storage = $"{ServerIpAddress}/api/storage";
            this.StorageContent = $"{ServerIpAddress}/api/storage/content";
        }
    }
}
