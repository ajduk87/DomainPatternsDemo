using CommercialClientApplication.DataGridModels;
using CommercialClientApplication.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommercialClientApplication.Services
{
    public class StorageService : IStorageService
    {
        public void Insert(Storage storage)
        {
        }
        public void Update(Storage storage)
        {
        }
        public Storage Get(string name)
        {
            return new Storage();
        }
        public ObservableCollection<StorehouseItem> GetState(string name)
        {
            return new ObservableCollection<StorehouseItem>();
        }
    }
}
