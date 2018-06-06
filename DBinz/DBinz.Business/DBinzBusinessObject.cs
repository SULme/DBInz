using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBinz.Data.Access;
using DBinz.Data.Models;

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
            catch (SqlException)
            {
                return false;
            }
            return true;
        }

        public IEnumerable<Tuple<string, string, int>> FetchTableDetails()
        {
            var tableDetails = Context.Database.SqlQuery<TableDetails>(@"   select	S.name			as SchemaName,
                                                                                    T.name			as TableName,
		                                                                            T.object_id		as ObjectID
                                                                            from	sys.schemas		as S
                                                                            join	sys.tables		as T
	                                                                            on	S.schema_id = T.schema_id"
                                                                                );

            foreach(var tableDetailsItem in tableDetails)
                yield return new Tuple<string, string, int>(tableDetailsItem.SchemaName, tableDetailsItem.TableName, tableDetailsItem.ObjectID);
        }

      

        public IEnumerable<Tuple<string>> FetchColumnData(int objectId)
        {
            var columnDetails = Context.Database.SqlQuery<ColumnDetails>(@" ");

            foreach (var columnDetailsItem in columnDetails)
                yield return new Tuple<string>("something");

        }

        public void Dispose()
        {
        }
    }
}

