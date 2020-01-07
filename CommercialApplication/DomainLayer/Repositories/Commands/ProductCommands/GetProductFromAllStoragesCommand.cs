using CommercialApplicationCommand.DomainLayer.Entities.ProductEntities;
using CommercialApplicationCommand.DomainLayer.Entities.ValueObjects.Common;
using CommercialApplicationCommand.DomainLayer.Entities.ValueObjects.ProductStorage;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommercialApplication.DomainLayer.Repositories.Commands.ProductCommands
{
    public class GetProductFromAllStoragesCommand : CommandBase, IProductCommand
    {
        public string StoredFunctionName { get; } = "select_product_fromallstorages";
        public IEnumerable<ProductStorage> Execute(IDbConnection conn, long id, IDbTransaction transaction = null)
        {
            List<ProductStorage> storageItems = new List<ProductStorage>();

            this.connection = (NpgsqlConnection)conn;
            connection.Open();
            NpgsqlCommand command = new NpgsqlCommand(this.StoredFunctionName, connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("criteriaproductid", id);

            // Execute the procedure and obtain a result set
            NpgsqlDataReader dr = command.ExecuteReader();

            while (dr.Read())
            {
                ProductStorage productStorage = new ProductStorage
                {
                    Id = new Id(Convert.ToInt64(dr["Id"].ToString())),
                    ProductId = new ProductId(Convert.ToInt64(dr["ProductId"].ToString())),
                    StorageId = new StorageId(Convert.ToInt64(dr["StorageId"].ToString())),
                    AmountOfProduct = new Amount(Convert.ToInt32(dr["AmountOfProduct"].ToString()))
                };
            }

            connection.Close();

            return storageItems;
        }
    }
}
