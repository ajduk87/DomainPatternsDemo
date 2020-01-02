using CommercialApplicationCommand.DomainLayer.Entities.ValueObjects.Common;
using CommercialApplicationCommand.DomainLayer.Entities.ValueObjects.Product;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommercialApplication.DomainLayer.Entities.ValueObjects.TypeHandlers
{
    class TypeHandlerInitializer
    {
        public static void InitializeTypeHandlers()
        {
            SqlMapper.AddTypeHandler(new DescriptionTypeHandler());
            SqlMapper.AddTypeHandler(new ImageUrlTypeHandler());
            SqlMapper.AddTypeHandler(new KindOfProductTypeHandler());
            SqlMapper.AddTypeHandler(new NameTypeHandler());
            SqlMapper.AddTypeHandler(new SerialNumberTypeHandler());
            SqlMapper.AddTypeHandler(new StateTypeHandler());
            SqlMapper.AddTypeHandler(new UnitCostTypeHandler());
            SqlMapper.AddTypeHandler(new VideoLinkTypeHandler());
        }
    }
}
