using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommercialClientApplication.Models
{
    public class Action
    {
        public string ProductName { get; set; }
        public double Discount { get; set; }
        public int ThresholdAmount { get; set; }
    }
}
