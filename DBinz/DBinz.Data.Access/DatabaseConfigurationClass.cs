using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.SqlServer;
using System.Diagnostics;

namespace DBinz.Data.Access
{
    /// <summary>
    /// Diese Klasse wird benötigt, um die EntityFramework.SqlServer DLL zu referenzieren und so das Kopieren der DLL zu erzwingen. Referenziert wird diese Klasse nicht
    /// </summary>
    internal class DatabaseConfigurationClass : DbConfiguration
    {
        [DebuggerHidden]
        public DatabaseConfigurationClass()
        {
            SetExecutionStrategy("System.Data.SqlClient", () => new SqlAzureExecutionStrategy());
            SetDefaultConnectionFactory(new LocalDbConnectionFactory("v11.0"));                 // MSSQL2012    
            //SetDefaultConnectionFactory(new LocalDbConnectionFactory("mssqllocaldb"));        // MSSQL2014 ??.

        }
    }
}
