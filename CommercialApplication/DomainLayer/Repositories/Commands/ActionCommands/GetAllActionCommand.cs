using CommercialApplicationCommand.DomainLayer.Entities.ActionEntities;
using CommercialApplicationCommand.DomainLayer.Entities.ValueObjects.Common;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Action = CommercialApplicationCommand.DomainLayer.Entities.ActionEntities.Action;

namespace CommercialApplication.DomainLayer.Repositories.Commands.ActionCommands
{
    public class GetAllActionCommand : CommandBase, IActionCommand
    {
        public IEnumerable<Action> Execute(IDbConnection conn, IDbTransaction transaction = null)
        {
            List<Action> actions = new List<Action>();

            this.connection = (NpgsqlConnection)conn;
            connection.Open();
            NpgsqlCommand command = new NpgsqlCommand("select_action", connection);
            command.CommandType = CommandType.StoredProcedure;

            // Execute the procedure and obtain a result set
            NpgsqlDataReader dr = command.ExecuteReader();

            while (dr.Read())
            {
                Action action = new Action
                {
                    ProductId = new Id(Convert.ToInt64(dr["ProductId"].ToString())),
                    SalesChannelId = new Id(Convert.ToInt64(dr["SalesChannelId"].ToString())),
                    Discount = new Discount(Convert.ToDouble(dr["Discount"].ToString())),
                    ThresholdAmount = new Amount(Convert.ToInt32(dr["ThresholdAmount"].ToString())),
                    CustomerId = new Id(Convert.ToInt64(dr["CustomerId"].ToString()))
                };

                actions.Add(action);
            }

            connection.Close();

            return actions;
        }
    }
}
