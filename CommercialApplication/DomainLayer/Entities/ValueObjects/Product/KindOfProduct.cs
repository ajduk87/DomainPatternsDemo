using CommercialApplicationCommand.DomainLayer.Entities.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommercialApplication.DomainLayer.Entities.ValueObjects.Product
{
    public class KindOfProduct : ValueObject
    {
        public string Content { get; }

        public KindOfProduct(string Content)
        {
            this.Content = Content;
        }

        public static explicit operator KindOfProduct(string kindOfProduct)
        {
            return new KindOfProduct(kindOfProduct);
        }

        public static implicit operator string(KindOfProduct kindOfProduct)
        {
            return kindOfProduct.Content;
        }
    }
}
