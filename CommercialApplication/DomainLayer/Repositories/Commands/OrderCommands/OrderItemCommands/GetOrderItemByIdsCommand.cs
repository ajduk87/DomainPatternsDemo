using CommercialApplicationCommand.DomainLayer.Entities.CommonEntities;
using CommercialApplicationCommand.DomainLayer.Entities.OrderEntities;
using CommercialApplicationCommand.DomainLayer.Entities.ValueObjects.Common;
using CommercialApplicationCommand.DomainLayer.Entities.ValueObjects.InvoiceItem;
using CommercialApplicationCommand.DomainLayer.Entities.ValueObjects.ProductStorage;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommercialApplication.DomainLayer.Repositories.Commands.OrderCommands
{
    public class GetOrderItemByIdsCommand : CommandBase, IOrderCommand
    {
        public string StoredFunctionName { get; } = "select_orderitem_byids";

        public IEnumerable<OrderItem> Execute(IDbConnection conn, IEnumerable<long> ids, IDbTransaction transaction = null)
        {
            List<OrderItem> orderItems = new List<OrderItem>();
            this.connection = (NpgsqlConnection)conn;
            connection.Open();
            NpgsqlCommand command = new NpgsqlCommand(this.StoredFunctionName, connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("criteriaids", ids);

            // Execute the procedure and obtain a result set
            NpgsqlDataReader dr = command.ExecuteReader();

            while (dr.Read())
            {
                OrderItem orderItem = new OrderItem
                {
                    Id = new Id(Convert.ToInt64(dr["Id"].ToString())),
                    ProductId = new ProductId(Convert.ToInt64(dr["ProductId"].ToString())),
                    Amount = new Amount(Convert.ToInt32(dr["Amount"].ToString())),
                    Value = new Money
                    {
                        Value = Convert.ToInt32(dr["Value"].ToString()
                                                           .Split(' ')
                                                           .First()),
                        Currency = new Currency(dr["Value"].ToString()
                                                           .Split(' ')[1])
                    },
                    DiscountBasic = new Discount(Convert.ToDouble(dr["DiscountBasic"].ToString())),
                    ActionId = new ActionId(Convert.ToInt64(dr["ActionId"].ToString()))
                };

                orderItems.Add(orderItem);
            }

            connection.Close();

            return orderItems;
        }
    }
}
