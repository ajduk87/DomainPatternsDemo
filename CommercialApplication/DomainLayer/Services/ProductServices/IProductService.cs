using CommercialApplication.DomainLayer.Entities.ProductEntities;
using CommercialApplicationCommand.ApplicationLayer.Dtoes.Product;
using CommercialApplicationCommand.DomainLayer.Entities.ProductEntities;
using CommercialApplicationCommand.DomainLayer.Entities.ValueObjects.Common;
using System.Collections.Generic;
using System.Data;

namespace CommercialApplicationCommand.DomainLayer.Services.ProductServices
{
    public interface /* IProduct */ AProductService
    {
        IEnumerable</* IProduct */ AProduct> Select(IDbConnection connection, IDbTransaction transaction = null);
        /* IProduct */ AProduct SelectByName(IDbConnection connection, Name name, IDbTransaction transaction = null);

        void Insert(IDbConnection connection, /* IProduct */ AProduct product, IDbTransaction transaction = null);

        void Update(IDbConnection connection, /* IProduct */ AProduct product, IDbTransaction transaction = null);
        void UpdateFruitsUnitCost(IDbConnection connection, DecreaseFruitsUnitCost decreaseFruitsUnitCost, IDbTransaction transaction = null);
        void UpdateVegetablesUnitCost(IDbConnection connection, DecreaseVegetablesUnitCost decreaseVegetablesUnitCost, IDbTransaction transaction = null);
        //void UpdateState(IDbConnection connection, ProductState productState, IDbTransaction transaction = null);
        void SetNotForSoldState(IDbConnection connection, Name name, IDbTransaction transaction = null);
        void SetForSoldState(IDbConnection connection, Name name, IDbTransaction transaction = null);
        void SetOutOfStockState(IDbConnection connection, Name name, IDbTransaction transaction = null);

        void Delete(IDbConnection connection, /* IProduct */ AProduct product, IDbTransaction transaction = null);
    }
}