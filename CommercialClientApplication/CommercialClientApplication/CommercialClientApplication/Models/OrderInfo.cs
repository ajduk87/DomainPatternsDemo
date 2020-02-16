using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommercialClientApplication.Models
{
    public class OrderInfo
    {
        public string CustomerName { get; set; }
        public ObservableCollection<DataGridModels.OrderItem> OrderItems { get; set; }
        public double Total { get; set; }
    }
}
