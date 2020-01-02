using CommercialApplication.DomainLayer.Entities.ValueObjects.Product;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommercialApplication.DomainLayer.Entities.ValueObjects.TypeHandlers
{
    public class KindOfProductTypeHandler : SqlMapper.TypeHandler<KindOfProduct>
    {
        public override KindOfProduct Parse(object value)
        {
            return new KindOfProduct((string)value);
        }

        public override void SetValue(IDbDataParameter parameter, KindOfProduct value)
        {
            parameter.Value = value.Content;
        }
    }
}
