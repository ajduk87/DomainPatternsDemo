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
    public class ImageUrlTypeHandler : SqlMapper.TypeHandler<ImageUrl>
    {
        public override ImageUrl Parse(object value)
        {
            return new ImageUrl((string)value);
        }

        public override void SetValue(IDbDataParameter parameter, ImageUrl value)
        {
            parameter.Value = value.Content;
        }
    }
}
