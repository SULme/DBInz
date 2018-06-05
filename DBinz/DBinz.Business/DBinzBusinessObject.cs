using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBinz.Data.Access;

namespace DBinz.Business
{
    public class DBinzBusinessObject : IDisposable
    {
        public DBinzContext Context { get; set; }

        public DBinzBusinessObject(LoginData loginData)
        {
            var conStr = DBinzContext.CreateConStr(new DBinz.Data.Access.LoginData
            {
                Server = loginData.Server,
                Database = loginData.Database,
                Login = loginData.Login,
                Password = loginData.Password
            }
            );
            Context = new DBinzContext(conStr);
        }

        public bool CheckConnection()
        {
            try
            {
                Context.Database.Connection.Open();
                Context.Database.Connection.Close();
            }
            catch (SqlException exc)
            {
                return false;
            }
            return true;
        }

        public List<string> RetrieveTableNames()
        {
            var tableNames = Context.Database.SqlQuery<string>(@"   select		CONCAT(A.name, '.', T.name)
                                                                    from		sys.schemas		as A
                                                                    join		sys.tables		as T
	                                                                    on		A.schema_id = T.schema_id"
                                                                ).ToList<string>();
            return tableNames;
        }

        public void RetrieveColumns()
        {
            
        }

        public void Dispose()
        {
        }
    }
}

