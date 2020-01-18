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
    public interface IProduct
    {
        Id Id { get; set; }
        Name Name { get; set; }
        UnitCost UnitCost { get; set; }
        Description Description { get; set; }
        ImageUrl ImageUrl { get; set; }
        VideoLink VideoLink { get; set; }
        SerialNumber SerialNumber { get; set; }
        KindOfProduct KindOfProduct { get; set; }
    }
}
