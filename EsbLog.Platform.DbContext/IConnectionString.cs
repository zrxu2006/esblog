using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsbLog.Platform.Database
{
    public interface IConnectionString
    {
        string ConnectionString { get; }
    }

    public class PlatformConnectionStringProvider : IConnectionString
    {
        SqlConnectionStringBuilder _builder;
        public PlatformConnectionStringProvider()
        {
            _builder = new SqlConnectionStringBuilder();
            _builder.DataSource = "local";
            _builder.InitialCatalog = "EsbLog";
            _builder.IntegratedSecurity = true;
            

        }

        public string ConnectionString
        {
            get
            {
                return _builder.ToString();
            }
        }

    }
}
