using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hermes.DataAccess
{
    public class DataAccessOptions
    {
        public DataConnectionOptions DefaultConnection { get; set; } = new DataConnectionOptions();
    }

    public class DataConnectionOptions    {        public DatabaseType Type { get; set; } = DatabaseType.MsSqlServer;        public string ConntectionString { get; set; }    }    public enum DatabaseType    {        PostgreSql,        MsSqlServer    }

}
