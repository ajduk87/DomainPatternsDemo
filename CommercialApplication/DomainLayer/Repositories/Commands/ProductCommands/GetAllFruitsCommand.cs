using CommercialApplication.DomainLayer.Entities.ValueObjects.Common;
using CommercialApplication.DomainLayer.Entities.ValueObjects.Product;
using CommercialApplicationCommand.DomainLayer.Entities.ProductEntities;
using CommercialApplicationCommand.DomainLayer.Entities.ValueObjects.Common;
using CommercialApplicationCommand.DomainLayer.Entities.ValueObjects.Product;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommercialApplication.DomainLayer.Repositories.Commands.ProductCommands
{
    public class GetAllFruitsCommand : CommandBase, IProductCommand
    {
        public string StoredFunctionName { get; } = "select_fruits";

        public IEnumerable<Product> Execute(IDbConnection conn, IDbTransaction transaction = null)
        {
            List<Product> products = new List<Product>();

            this.connection = (NpgsqlConnection)conn;
            connection.Open();
            NpgsqlCommand command = new NpgsqlCommand(this.StoredFunctionName, connection);
            command.CommandType = CommandType.StoredProcedure;

            // Execute the procedure and obtain a result set
            NpgsqlDataReader dr = command.ExecuteReader();

            while (dr.Read())
            {
                Product product = new Product
                {
                    Id = new Id(Convert.ToInt64(dr["Id"].ToString())),
                    Name = new Name(dr["Name"].ToString()),
                    UnitCost = new UnitCost
                    {
                        Value = Convert.ToDouble(dr["UnitCost"]
                                                 .ToString()
                                                 .Split(' ')
                                                 .First()),
                        Currency = new Currency(dr["UnitCost"]
                                                 .ToString()
                                                 .Split(' ')[1])
                    },
                    Description = new Description(dr["Description"].ToString()),
                    ImageUrl = new ImageUrl(dr["ImageUrl"].ToString()),
                    VideoLink = new VideoLink(dr["VideoLink"].ToString()),
                    KindOfProduct = new KindOfProduct(dr["KindOfProduct"].ToString()),
                    SerialNumber = new SerialNumber(dr["SerialNumber"].ToString()),
                    State = new State(dr["State"].ToString()),
                };

                products.Add(product);
            }

            connection.Close();

            return products;
        }
    }
}
