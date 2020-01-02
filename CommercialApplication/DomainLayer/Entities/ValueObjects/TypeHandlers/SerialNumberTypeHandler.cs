using CommercialApplicationCommand.DomainLayer.Entities.ValueObjects.Product;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommercialApplication.DomainLayer.Entities.ValueObjects.TypeHandlers
{
    public class SerialNumberTypeHandler : SqlMapper.TypeHandler<SerialNumber>
    {
        public override SerialNumber Parse(object value)
        {
            return new SerialNumber((string)value);
        }

        public override void SetValue(IDbDataParameter parameter, SerialNumber value)
        {
            parameter.Value = value.Content;
        }
    }
}
