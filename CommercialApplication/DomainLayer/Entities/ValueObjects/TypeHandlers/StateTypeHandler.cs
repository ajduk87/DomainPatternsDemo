using CommercialApplication.DomainLayer.Entities.ValueObjects.Common;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommercialApplication.DomainLayer.Entities.ValueObjects.TypeHandlers
{
    public class StateTypeHandler : SqlMapper.TypeHandler<State>
    {
        public override State Parse(object value)
        {
            return new State((string)value);
        }

        public override void SetValue(IDbDataParameter parameter, State value)
        {
            parameter.Value = value.Content;
        }
    }
}
