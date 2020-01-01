using CommercialApplicationCommand.ApplicationLayer.Dtoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommercialApplication.ApplicationLayer.Dtoes.Product
{
    public class ProductStateDto : Dto
    {
        public string Name { get; set; }
        public string State { get; set; }
    }
}
