using CommercialApplicationCommand.DomainLayer.Entities.ActionEntities;
using Npgsql;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommercialApplication.DomainLayer.Repositories.Commands.ActionCommands
{
    public class DeleteActionCommand : CommandBase, IActionCommand
    {
        public string StoredFunctionName { get; } = "delete_action";       

        public void Execute(IDbConnection conn, Action actionEntity, IDbTransaction transaction = null)
        {
            this.connection = (NpgsqlConnection)conn;
            connection.Open();
            NpgsqlCommand command = new NpgsqlCommand(this.StoredFunctionName, connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("criteriaid", actionEntity.Id);

            // Execute the procedure and obtain a result set
            NpgsqlDataReader dr = command.ExecuteReader();
            connection.Close();
        }
    }
}
