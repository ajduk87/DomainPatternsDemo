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
    public interface IStorageService
    {
        void Insert(Storage storage);
        void Update(Storage storage);
        Storage Get(string name);
        ObservableCollection<StorehouseItem> GetState(string name);
    }
}
