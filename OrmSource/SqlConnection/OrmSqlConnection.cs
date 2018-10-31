using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrmSource.SqlConnection
{
   public   class OrmSqlConnection
   {
       private static string sqlConnectionString = "Data Source=DESKTOP-UVKQQ4Q;Initial Catalog=PersonalInformation;Integrated Security=True";
        public static System.Data.SqlClient.SqlConnection SqlConnection()
        {
            System.Data.SqlClient.SqlConnection sqlConnection=new System.Data.SqlClient.SqlConnection(sqlConnectionString);
            sqlConnection.Open();
            return sqlConnection;
        }
    }
}
