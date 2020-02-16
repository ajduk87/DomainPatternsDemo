using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommercialClientApplication.Models
{
    public class Order
    {
        public string CustomerName { get; set; }
        public ObservableCollection<OrderItem> OrderItems { get; set; }
    }
}
