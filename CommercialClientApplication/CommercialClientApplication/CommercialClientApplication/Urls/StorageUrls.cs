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

        public StorageUrls()
        {
            this.Storage = $"{ServerIpAddress}/api/storage";
        }
    }
}
