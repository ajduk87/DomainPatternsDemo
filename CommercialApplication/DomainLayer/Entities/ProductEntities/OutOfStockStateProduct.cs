using CommercialApplication.DomainLayer.Entities.ValueObjects.Product;
using CommercialApplicationCommand.DomainLayer.Entities;
using CommercialApplicationCommand.DomainLayer.Entities.ProductEntities;
using CommercialApplicationCommand.DomainLayer.Entities.ValueObjects.Common;
using CommercialApplicationCommand.DomainLayer.Entities.ValueObjects.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommercialApplication.DomainLayer.Entities.ProductEntities
{
    public class OutOfStockStateProduct: Entity, IProduct
    {
        public Name Name { get; set; }
        public UnitCost UnitCost { get; set; }
        public Description Description { get; set; }
        public ImageUrl ImageUrl { get; set; }
        public VideoLink VideoLink { get; set; }
        public SerialNumber SerialNumber { get; set; }
        public KindOfProduct KindOfProduct { get; set; }

        public OutOfStockStateProduct(IProduct product)
        {
            this.Id = product.Id;
            this.Name = product.Name;
            this.UnitCost = product.UnitCost;
            this.Description = product.Description;
            this.ImageUrl = product.ImageUrl;
            this.VideoLink = product.VideoLink;
            this.SerialNumber = product.SerialNumber;
            this.KindOfProduct = product.KindOfProduct;
        }

        public ForSoldStateProduct SetForSoldStateProduct()
        {
            return new ForSoldStateProduct(this);
        }
    }
}
