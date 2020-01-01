using CommercialApplicationCommand.ApplicationLayer.Dtoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommercialApplication.ApplicationLayer.Dtoes.Product
{
    public class DecreaseVegetablesUnitCostDto : Dto
    {
        public double Percent { get; set; }
    }
}
