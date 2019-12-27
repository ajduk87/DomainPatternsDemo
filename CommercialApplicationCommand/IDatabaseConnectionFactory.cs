using Npgsql;

namespace CommercialApplicationCommand
{
    public interface IDatabaseConnectionFactory
    {
        IDatabaseConnectionFactory Instance { get; }

        NpgsqlConnection Create(string connectionStringParam = null);
    }
}