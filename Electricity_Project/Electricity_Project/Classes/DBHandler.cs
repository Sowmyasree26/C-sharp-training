using System.Data.SqlClient;
using System.Web.Configuration;

namespace Electricity_Project
{
    public class DBHandler
    {
        public SqlConnection GetConnection()
        {
            string connStr = WebConfigurationManager.ConnectionStrings["electricitydbconnection"].ConnectionString;
            return new SqlConnection(connStr);
        }
    }
}
