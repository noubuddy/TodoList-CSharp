using RethinkDb.Driver;
using RethinkDb.Driver.Net;

namespace TodoList_CSharp.Modules;

public class DatabaseManager
{
    private RethinkDB r = RethinkDB.R;
    private Connection conn;

    public DatabaseManager(string host, int port)
    {
        conn = r.Connection()
             .Hostname(host) // 127.0.0.1
             .Port(port) // 38015
             .Timeout(60)
             .Connect();
    }

    public void CreateDb(string dbName)
    {
        r.DbCreate(dbName).Run(conn);
    }

    public void CreateTable(string dbName, string tableName)
    {
        r.Db(dbName).TableCreate(tableName).Run(conn);
    }
}
