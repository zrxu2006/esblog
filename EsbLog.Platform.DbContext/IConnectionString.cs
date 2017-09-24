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
            _builder.DataSource = "localhost";
            _builder.InitialCatalog = "esblog";
            _builder.IntegratedSecurity = true;
            //_builder.UserID = "sa";
            //_builder.Password = "sysadmin";
            _builder.UserID = "EsblogApp";
            _builder.Password = "EsblogApp";
        }

        public string ConnectionString
        {
            get
            {
                return _builder.ToString();
                //return @"Data Source=mssqlserver;Initial Catalog=esblog;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False";
                //return @"Data Source=(LocalDb)\v11.0;AttachDbFilename=E:\S00.Life\10.交大在职\2015-论文阶段\论文项目\EsbLog\_git\esblog_2017\EsbLog.Web\App_Data\EsbLog.mdf;Integrated Security=True";
            }
        }

    }
}
