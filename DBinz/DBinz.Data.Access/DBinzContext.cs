using DBinz.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBinz.Data.Access
{
    public class DBinzContext : DbContext
    {
        private static string _server;
        private static string _database;
        private static string _login;
        private static string _password;
        //private static string _appname;

        public DBinzContext(string conStr)
            : base(conStr)
        {
        }

        public static string CreateConStr(LoginData loginData)
        {
            const string masterConnectionBase = "Data Source=[@SERVER];" +
                                                "Initial Catalog=[@KATALOG];" +
                                                "User ID=[@BENUTZER];" +
                                                "Password=[@PASSWORD];" +
                                                "Connection Timeout=60;" +
                                                "App=[@APPNAME];" +
                                                "Pooling = false;";

            _server = loginData.Server;
            _database = loginData.Database;
            _login = loginData.Login;
            _password = loginData.Password;

            string connectionString = masterConnectionBase
                                        .Replace("[@SERVER]", _server)
                                        .Replace("[@KATALOG]", _database)
                                        .Replace("[@BENUTZER]", _login)
                                        .Replace("[@PASSWORD]", _password)
                                        //.Replace("[@APPNAME]", _appname)
                                        ;

            return connectionString;
        }

        public DbSet<TableDetails> TableDetails { get; set; }
        public DbSet<object> InsertionData;
    }
}
