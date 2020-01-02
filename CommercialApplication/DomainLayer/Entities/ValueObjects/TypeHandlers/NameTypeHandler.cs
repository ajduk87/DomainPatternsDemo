using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommercialApplicationCommand.DomainLayer.Entities.ValueObjects.Common;
using Dapper;

namespace CommercialApplication.DomainLayer.Entities.ValueObjects.TypeHandlers
{
    public class NameTypeHandler : SqlMapper.TypeHandler<Name>
    {
        public override Name Parse(object value)
        {
            return new Name((string)value);
        }

        public override void SetValue(IDbDataParameter parameter, Name value)
        {
            parameter.Value = value.Content;
        }
    }
}
