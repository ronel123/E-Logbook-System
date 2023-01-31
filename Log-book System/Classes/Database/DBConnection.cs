using Log_book_System.Classes.Variable;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Log_book_System.Classes.Database
{
    class DBConnection
    {
        /* Constructor */
        public DBConnection()
        {
            Global.MysqlCon = new MySqlConnection(Global.MYSQL_CONNECTION_STRING);
        }
    }
}
