using CommercialApplicationCommand.DomainLayer.Entities.ProductEntities;
using CommercialApplicationCommand.DomainLayer.Entities.ValueObjects.Common;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommercialApplication.DomainLayer.Entities.ValueObjects.TypeHandlers
{
    public class UnitCostTypeHandler : SqlMapper.TypeHandler<UnitCost>
    {
        public override UnitCost Parse(object value)
        {
            string[] fragments = value.ToString().Split();
            return new UnitCost
            {
                Value = double.Parse(fragments[0]),
                Currency = new Currency(fragments[1])
            };
        }

        public override void SetValue(IDbDataParameter parameter, UnitCost value)
        {
            parameter.Value = value.ToString();
        }
    }
}
