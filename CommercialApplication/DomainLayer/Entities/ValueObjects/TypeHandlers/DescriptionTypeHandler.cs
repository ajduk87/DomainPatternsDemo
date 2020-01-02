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
    public class DescriptionTypeHandler : SqlMapper.TypeHandler<Description>
    {
        public override Description Parse(object value)
        {
            return new Description((string)value);
        }

        public override void SetValue(IDbDataParameter parameter, Description value)
        {
            parameter.Value = value.Content;
        }
    }
}
