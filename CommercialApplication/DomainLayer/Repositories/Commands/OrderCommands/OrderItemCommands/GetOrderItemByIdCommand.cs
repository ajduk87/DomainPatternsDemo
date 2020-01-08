using CommercialApplicationCommand.DomainLayer.Entities.OrderEntities;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommercialApplicationCommand.DomainLayer.Entities.ValueObjects.Common;
using CommercialApplicationCommand.DomainLayer.Entities.ValueObjects.ProductStorage;
using CommercialApplicationCommand.DomainLayer.Entities.CommonEntities;
using CommercialApplicationCommand.DomainLayer.Entities.ValueObjects.InvoiceItem;

namespace CommercialApplication.DomainLayer.Repositories.Commands.OrderCommands
{
    public class GetOrderItemByIdCommand : CommandBase, IOrderCommand
    {
        public string StoredFunctionName { get; } = "select_orderitem_byid";

        public OrderItem Execute(IDbConnection conn, long orderId, IDbTransaction transaction = null)
        {
            OrderItem orderItem = new OrderItem();
            this.connection = (NpgsqlConnection)conn;
            connection.Open();
            NpgsqlCommand command = new NpgsqlCommand(this.StoredFunctionName, connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("criteriaid", orderId);

            // Execute the procedure and obtain a result set
            NpgsqlDataReader dr = command.ExecuteReader();

            while (dr.Read())
            {
                orderItem = new OrderItem
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
            }

            connection.Close();

            return orderItem;
        }
    }
}
