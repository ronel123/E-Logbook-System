using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Log_book_System.Classes.Variable
{
    public static class Global
    {
        /* Constant Database Configuration */
        public const string
                        DATABASE_HOST = "localhost",
                        DATABASE_NAME = "logbook_database",
                        DATABASE_PORT = "3306",
                        DATABASE_USER = "root",
                        DATABASE_PASS = "",
                        DATABASE_SSLMODE = "none"
        ;
        /* Constant MySql Connection String Formatted */
        public static readonly string MYSQL_CONNECTION_STRING = string.Format("datasource={0}; database={1}; port={2}; username={3}; password={4}; SslMode={5}; Convert Zero Datetime=True",
                DATABASE_HOST, DATABASE_NAME, DATABASE_PORT, DATABASE_USER, DATABASE_PASS, DATABASE_SSLMODE);

        /* Global MySql Connection Object*/
        public static MySqlConnection MysqlCon;

        /* Login User Info*/
        public static int Login_UserID = 0;
        public static string Login_UserRole = "";

        /*Selected ID from Data History */
        public static int frmForm137id = 0;
        public static int frmRandomFilesid = 0;

        /* Profile Picture Path */
        public static readonly string BACKUPDATABASETABLE_PATH = string.Format("{0}\\Back-up Data\\", Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));

    }
}
