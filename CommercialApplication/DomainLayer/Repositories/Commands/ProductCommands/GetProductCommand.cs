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
    public class GetProductCommand : CommandBase, IProductCommand
    {
        public Product Execute(IDbConnection conn, Id id, IDbTransaction transaction = null)
        {
            Product product = new Product();

            this.connection = (NpgsqlConnection)conn;
            connection.Open();
            NpgsqlCommand command = new NpgsqlCommand("select_product_byid", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("criteriaid", id);

            // Execute the procedure and obtain a result set
            NpgsqlDataReader dr = command.ExecuteReader();

            while (dr.Read())
            {
                product = new Product
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
            }

            connection.Close();

            return product;
        }
    }
}
