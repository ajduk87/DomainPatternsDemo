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
    public class VideoLinkTypeHandler : SqlMapper.TypeHandler<VideoLink>
    {
        public override VideoLink Parse(object value)
        {
            return new VideoLink((string)value);
        }

        public override void SetValue(IDbDataParameter parameter, VideoLink value)
        {
            parameter.Value = value.Content;
        }
    }
}
