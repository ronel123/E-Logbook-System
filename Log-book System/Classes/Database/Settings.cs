using Log_book_System.Classes.Variable;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Log_book_System.Classes.Database
{
    class Settings : DBConnection
    {
        static DataTable settingsTable;
        static MySqlDataAdapter mysqlAdapter;
        static MySqlCommand mysqlCmd;
        static DataTable accTable;

        public Settings()
        {
            settingsTable = new DataTable();
            mysqlAdapter = new MySqlDataAdapter();
            mysqlCmd = new MySqlCommand();
        }

        public DataTable ReadForm137Data(int id)
        {
            accTable = new DataTable();
            string queryStr = "SELECT * FROM form137file_tbl WHERE id = @id";

            Global.MysqlCon.Open();
            mysqlCmd.Parameters.Clear();
            mysqlCmd.CommandText = queryStr;
            mysqlCmd.CommandType = CommandType.Text;
            mysqlCmd.Connection = Global.MysqlCon;

            mysqlCmd.Parameters.Add("@id", MySqlDbType.Int32).Value = id;

            accTable.Load(mysqlCmd.ExecuteReader());
            Global.MysqlCon.Close();
            return accTable;
        }

        public DataTable ReadRandomFiles(int id)
        {
            accTable = new DataTable();
            //string queryStr = "SELECT e.employee_id, u.user_name, u.hashed_password, u.email, (CASE WHEN r.role_name IS null THEN \"None\" ELSE r.role_name END) AS role, e.first_name, e.middle_name, e.last_name, e.birthday, e.gender, e.address, e.city, e.province, e.contact_number, " +
            //"(CASE WHEN d.department_name IS null THEN \"None\" ELSE d.department_name END) AS department, (CASE WHEN p.position_name IS null THEN \"None\" ELSE p.position_name  END) AS position FROM " +
            //"employee e LEFT JOIN user_account u ON e.user_id = u.user_id LEFT JOIN user_role r ON u.user_role_id = r.user_role_id LEFT JOIN department d ON e.department_id = d.department_id LEFT JOIN position p ON e.position_id = p.position_id WHERE e.employee_id = @id";
            string queryStr = "SELECT * FROM randomfile_tbl WHERE id = @id";

            Global.MysqlCon.Open();
            mysqlCmd.Parameters.Clear();
            mysqlCmd.CommandText = queryStr;
            mysqlCmd.CommandType = CommandType.Text;
            mysqlCmd.Connection = Global.MysqlCon;

            mysqlCmd.Parameters.Add("@id", MySqlDbType.Int32).Value = id;

            accTable.Load(mysqlCmd.ExecuteReader());
            Global.MysqlCon.Close();
            return accTable;
        }
        public DataTable GetForm137Data()
        {
            settingsTable = new DataTable();
            Global.MysqlCon.Open();
            mysqlCmd.Parameters.Clear();
            mysqlCmd.CommandText = "SELECT id, date_format(created, '%M %e %Y %r') as created, CONCAT(last_name, \", \", first_name, \" \", SUBSTRING(middle_name, 1, 1)) as name, UPPER(gradelevel) AS gradelevel, previous_school, UPPER(status) AS status FROM form137file_tbl ORDER BY id ASC;";
            mysqlCmd.CommandType = CommandType.Text;
            mysqlCmd.Connection = Global.MysqlCon;

            settingsTable.Load(mysqlCmd.ExecuteReader());
            Global.MysqlCon.Close();
            return settingsTable;
        }

        public DataTable GetRandomFilesData()
        {
            settingsTable = new DataTable();
            Global.MysqlCon.Open();
            mysqlCmd.Parameters.Clear();
            mysqlCmd.CommandText = "SELECT id, date_format(created, '%M %e %Y %r') as created, typeofdocuments, receivedby, remarks, UPPER(status) AS status FROM randomfile_tbl ORDER BY id ASC;";
            mysqlCmd.CommandType = CommandType.Text;
            mysqlCmd.Connection = Global.MysqlCon;

            settingsTable.Load(mysqlCmd.ExecuteReader());
            Global.MysqlCon.Close();
            return settingsTable;
        }

        public int inputDataForm137(string first_name, string middle_name, string last_name, string gradelevel, string previous_school, string status)
        {
            Global.MysqlCon.Open();
            mysqlCmd.Parameters.Clear();
            string insertQuery = "INSERT INTO form137file_tbl (first_name, middle_name, last_name, gradelevel, previous_school, status) VALUES(@first_name, @middle_name, @last_name, @gradelevel, @previous_school, @status);";
            mysqlCmd.CommandText = insertQuery;
            mysqlCmd.CommandType = CommandType.Text;
            mysqlCmd.Connection = Global.MysqlCon;

            mysqlCmd.Parameters.Add("@first_name", MySqlDbType.VarChar).Value = first_name;
            mysqlCmd.Parameters.Add("@middle_name", MySqlDbType.VarChar).Value = middle_name;
            mysqlCmd.Parameters.Add("@last_name", MySqlDbType.VarChar).Value = last_name;
            mysqlCmd.Parameters.Add("@gradelevel", MySqlDbType.VarChar).Value = gradelevel;
            mysqlCmd.Parameters.Add("@previous_school", MySqlDbType.VarChar).Value = previous_school;
            mysqlCmd.Parameters.Add("@status", MySqlDbType.VarChar).Value = status;

            int affectedRows = mysqlCmd.ExecuteNonQuery();
            Global.MysqlCon.Close();
            return affectedRows;
        }

        public int inputRandomFiles(string typeofdocuments, string receivedby, string remarks, string status)
        {
            Global.MysqlCon.Open();
            mysqlCmd.Parameters.Clear();
            string insertQuery = "INSERT INTO randomfile_tbl (typeofdocuments, receivedby, remarks, status) VALUES(@typeofdocuments, @receivedby, @remarks, @status);";
            mysqlCmd.CommandText = insertQuery;
            mysqlCmd.CommandType = CommandType.Text;
            mysqlCmd.Connection = Global.MysqlCon;

            mysqlCmd.Parameters.Add("@typeofdocuments", MySqlDbType.VarChar).Value = typeofdocuments;
            mysqlCmd.Parameters.Add("@receivedby", MySqlDbType.VarChar).Value = receivedby;
            mysqlCmd.Parameters.Add("@remarks", MySqlDbType.VarChar).Value = remarks;
            mysqlCmd.Parameters.Add("@status", MySqlDbType.VarChar).Value = status;

            int affectedRows = mysqlCmd.ExecuteNonQuery();
            Global.MysqlCon.Close();
            return affectedRows;
        }

        public int updateDataForm137(string first_name, string middle_name, string last_name, string gradelevel, string previous_school, string status, int id, string outgoing_remarks)
        {
            Global.MysqlCon.Open();
            mysqlCmd.Parameters.Clear();

            string tempStr = string.Format("UPDATE form137file_tbl SET first_name =@first_name, middle_name =@middle_name, last_name =@last_name, gradelevel =@gradelevel, previous_school =@previous_school, status =@status, outgoing_remarks = @outgoing_remarks WHERE id = @id");

            mysqlCmd.CommandText = tempStr;
            mysqlCmd.CommandType = CommandType.Text;
            mysqlCmd.Connection = Global.MysqlCon;

            mysqlCmd.Parameters.Add("@first_name", MySqlDbType.VarChar).Value = first_name;
            mysqlCmd.Parameters.Add("@middle_name", MySqlDbType.VarChar).Value = middle_name;
            mysqlCmd.Parameters.Add("@last_name", MySqlDbType.VarChar).Value = last_name;
            mysqlCmd.Parameters.Add("@gradelevel", MySqlDbType.VarChar).Value = gradelevel;
            mysqlCmd.Parameters.Add("@previous_school", MySqlDbType.VarChar).Value = previous_school;
            mysqlCmd.Parameters.Add("@status", MySqlDbType.VarChar).Value = status;
            mysqlCmd.Parameters.Add("@id", MySqlDbType.Int64).Value = id;
            mysqlCmd.Parameters.Add("@outgoing_remarks", MySqlDbType.VarChar).Value = outgoing_remarks;

            int affectedRows = mysqlCmd.ExecuteNonQuery();
            Global.MysqlCon.Close();
            if (affectedRows > 0)
                return affectedRows;
            return 0;
        }

        public int updateRandomFiles(string typeofdocuments, string receivedby, string remarks, string status, int id)
        {
            Global.MysqlCon.Open();
            mysqlCmd.Parameters.Clear();

            string tempStr = string.Format("UPDATE randomfile_tbl SET typeofdocuments =@typeofdocuments, receivedby =@receivedby, remarks =@remarks, status =@status WHERE id = @id");

            mysqlCmd.CommandText = tempStr;
            mysqlCmd.CommandType = CommandType.Text;
            mysqlCmd.Connection = Global.MysqlCon;

            mysqlCmd.Parameters.Add("@typeofdocuments", MySqlDbType.VarChar).Value = typeofdocuments;
            mysqlCmd.Parameters.Add("@receivedby", MySqlDbType.VarChar).Value = receivedby;
            mysqlCmd.Parameters.Add("@remarks", MySqlDbType.VarChar).Value = remarks;
            mysqlCmd.Parameters.Add("@status", MySqlDbType.VarChar).Value = status;
            mysqlCmd.Parameters.Add("@id", MySqlDbType.Int64).Value = id;

            int affectedRows = mysqlCmd.ExecuteNonQuery();
            Global.MysqlCon.Close();
            if (affectedRows > 0)
                return affectedRows;
            return 0;
        }

        public DataTable deleteForm137Data(int id)
        {
            accTable = new DataTable();
            string queryStr = "DELETE FROM form137file_tbl WHERE id = @id;";

            Global.MysqlCon.Open();
            mysqlCmd.Parameters.Clear();
            mysqlCmd.CommandText = queryStr;
            mysqlCmd.CommandType = CommandType.Text;
            mysqlCmd.Connection = Global.MysqlCon;

            mysqlCmd.Parameters.Add("@id", MySqlDbType.VarChar).Value = id;

            accTable.Load(mysqlCmd.ExecuteReader());
            Global.MysqlCon.Close();
            return accTable;
        }

        public DataTable deleteRandomFiles(int id)
        {
            accTable = new DataTable();
            string queryStr = "DELETE FROM randomfile_tbl WHERE id = @id;";

            Global.MysqlCon.Open();
            mysqlCmd.Parameters.Clear();
            mysqlCmd.CommandText = queryStr;
            mysqlCmd.CommandType = CommandType.Text;
            mysqlCmd.Connection = Global.MysqlCon;

            mysqlCmd.Parameters.Add("@id", MySqlDbType.VarChar).Value = id;

            accTable.Load(mysqlCmd.ExecuteReader());
            Global.MysqlCon.Close();
            return accTable;
        }

        public DataTable GetRandomFileDataAndFilter(string name)
        {
            settingsTable = new DataTable();
            Global.MysqlCon.Open();
            mysqlCmd.Parameters.Clear();

            mysqlCmd.CommandText = "SELECT id, date_format(created, '%M %e %Y %r') as created, typeofdocuments, receivedby, remarks, UPPER(status) AS status FROM randomfile_tbl WHERE date_format(created, '%M %e %Y %r') LIKE @name OR typeofdocuments LIKE @name  OR receivedby LIKE @name OR remarks LIKE @name OR status LIKE @name ORDER BY id ASC;";
            mysqlCmd.CommandType = CommandType.Text;
            mysqlCmd.Connection = Global.MysqlCon;

            mysqlCmd.Parameters.Add("@name", MySqlDbType.VarChar).Value = name;

            settingsTable.Load(mysqlCmd.ExecuteReader());
            Global.MysqlCon.Close();
            return settingsTable;
        }

        public DataTable GetForm137DataAndFilter(string name)
        {
            settingsTable = new DataTable();
            Global.MysqlCon.Open();
            mysqlCmd.Parameters.Clear();

            mysqlCmd.CommandText = "SELECT id, date_format(created, '%M %e %Y %r') as created, CONCAT(last_name, \", \", first_name, \" \", SUBSTRING(middle_name, 1, 1)) as name, UPPER(gradelevel) AS gradelevel, previous_school, UPPER(status) AS status FROM form137file_tbl WHERE date_format(created, '%M %e %Y %r') LIKE @name1 OR CONCAT(last_name, \", \", first_name, \" \", SUBSTRING(middle_name, 1, 1)) LIKE @name1 OR gradelevel LIKE @name1 OR previous_school LIKE @name1 OR status LIKE @name1 ORDER BY id ASC;";
            mysqlCmd.CommandType = CommandType.Text;
            mysqlCmd.Connection = Global.MysqlCon;

            mysqlCmd.Parameters.Add("@name1", MySqlDbType.VarChar).Value = name;

            settingsTable.Load(mysqlCmd.ExecuteReader());
            Global.MysqlCon.Close();
            return settingsTable;
        }
        public DataTable GetRandomFileDataBasedOnDate(string datefrom, string dateto)
        {
            settingsTable = new DataTable();
            Global.MysqlCon.Open();
            mysqlCmd.Parameters.Clear();

            //mysqlCmd.CommandText = "SELECT q.processed_date, t.transaction_name, CONCAT(e.last_name, \", \", e.first_name) as employeeLastName, CASE WHEN q.queue_by = 0 THEN \"Guest\" ELSE CONCAT(s.last_name, \", \", s.first_name) END AS Name FROM queue q LEFT JOIN student s ON s.student_number = q.queue_by LEFT JOIN employee e ON e.employee_id = q.processed_by LEFT JOIN transaction_modes t ON t.transaction_id = q.transaction_id WHERE q.processed_date BETWEEN @datefrom AND @dateto ORDER by q.processed_date;";
            mysqlCmd.CommandText = "SELECT id, date_format(created, '%M %e %Y %r') as created, typeofdocuments, receivedby, remarks, UPPER(status) AS status FROM randomfile_tbl WHERE created BETWEEN @datefrom AND @dateto ORDER BY id ASC;";
            mysqlCmd.CommandType = CommandType.Text;
            mysqlCmd.Connection = Global.MysqlCon;

            mysqlCmd.Parameters.Add("@datefrom", MySqlDbType.VarChar).Value = datefrom;
            mysqlCmd.Parameters.Add("@dateto", MySqlDbType.VarChar).Value = dateto;

            settingsTable.Load(mysqlCmd.ExecuteReader());
            Global.MysqlCon.Close();
            return settingsTable;
        }

        public DataTable GetForm137DataBasedOnDate(string datefrom, string dateto)
        {
            settingsTable = new DataTable();
            Global.MysqlCon.Open();
            mysqlCmd.Parameters.Clear();

            //mysqlCmd.CommandText = "SELECT q.processed_date, t.transaction_name, CONCAT(e.last_name, \", \", e.first_name) as employeeLastName, CASE WHEN q.queue_by = 0 THEN \"Guest\" ELSE CONCAT(s.last_name, \", \", s.first_name) END AS Name FROM queue q LEFT JOIN student s ON s.student_number = q.queue_by LEFT JOIN employee e ON e.employee_id = q.processed_by LEFT JOIN transaction_modes t ON t.transaction_id = q.transaction_id WHERE q.processed_date BETWEEN @datefrom AND @dateto ORDER by q.processed_date;";
            mysqlCmd.CommandText = "SELECT id, date_format(created, '%M %e %Y %r') as created, CONCAT(last_name, \", \", first_name, \" \", SUBSTRING(middle_name, 1, 1)) as name, UPPER(gradelevel) AS gradelevel, previous_school, UPPER(status) AS status FROM form137file_tbl WHERE created BETWEEN @datefrom AND @dateto ORDER BY id ASC;";
            mysqlCmd.CommandType = CommandType.Text;
            mysqlCmd.Connection = Global.MysqlCon;

            mysqlCmd.Parameters.Add("@datefrom", MySqlDbType.VarChar).Value = datefrom;
            mysqlCmd.Parameters.Add("@dateto", MySqlDbType.VarChar).Value = dateto;

            settingsTable.Load(mysqlCmd.ExecuteReader());
            Global.MysqlCon.Close();
            return settingsTable;
        }

        public int GetTotalRandomFiles()
        {
            Global.MysqlCon.Open();
            mysqlCmd.Parameters.Clear();
            mysqlCmd.CommandText = "SELECT COUNT(*) FROM randomfile_tbl";
            mysqlCmd.CommandType = CommandType.Text;
            mysqlCmd.Connection = Global.MysqlCon;

            int count = Convert.ToInt32(mysqlCmd.ExecuteScalar());
            Global.MysqlCon.Close();
            return count;
        }

        public int GetTotalForm137()
        {
            Global.MysqlCon.Open();
            mysqlCmd.Parameters.Clear();
            mysqlCmd.CommandText = "SELECT COUNT(*) FROM form137file_tbl";
            mysqlCmd.CommandType = CommandType.Text;
            mysqlCmd.Connection = Global.MysqlCon;

            int count = Convert.ToInt32(mysqlCmd.ExecuteScalar());
            Global.MysqlCon.Close();
            return count;
        }

        public DataTable GetSystemLogs()
        {
            settingsTable = new DataTable();
            Global.MysqlCon.Open();
            mysqlCmd.Parameters.Clear();
            mysqlCmd.CommandText = "SELECT h.id, date_format(h.timestamp, '%M %e %Y %r') as timestamp, CASE WHEN h.user_id = 0 THEN 'N/A' ELSE CONCAT(e.last_name, \", \", e.first_name) END AS name, h.action, h.description, h.status FROM system_logs h LEFT JOIN user_information e ON e.user_id = h.user_id ORDER BY h.id ASC;";
            mysqlCmd.CommandType = CommandType.Text;
            mysqlCmd.Connection = Global.MysqlCon;

            settingsTable.Load(mysqlCmd.ExecuteReader());
            Global.MysqlCon.Close();
            return settingsTable;
        }

        public int systemLogs(int user_id, string action, string description, string status)
        {
            Global.MysqlCon.Open();
            mysqlCmd.Parameters.Clear();
            string insertQuery = "INSERT INTO system_logs (user_id, action, description, status) VALUES(@user_id, @action, @description, @status);";
            mysqlCmd.CommandText = insertQuery;
            mysqlCmd.CommandType = CommandType.Text;
            mysqlCmd.Connection = Global.MysqlCon;

            mysqlCmd.Parameters.Add("@user_id", MySqlDbType.Int32).Value = user_id;
            mysqlCmd.Parameters.Add("@action", MySqlDbType.VarChar).Value = action;
            mysqlCmd.Parameters.Add("@description", MySqlDbType.VarChar).Value = description;
            mysqlCmd.Parameters.Add("@status", MySqlDbType.VarChar).Value = status;

            int affectedRows = mysqlCmd.ExecuteNonQuery();
            Global.MysqlCon.Close();
            return affectedRows;
        }

        public DataTable GetSystemLogsDataAndFilter(string date)
        {
            settingsTable = new DataTable();
            Global.MysqlCon.Open();
            mysqlCmd.Parameters.Clear();

            mysqlCmd.CommandText = "SELECT h.id, date_format(h.timestamp, '%M %e %Y %r') as timestamp, CASE WHEN h.user_id = 0 THEN 'N/A' ELSE CONCAT(e.last_name, \", \", e.first_name) END AS name, h.action, h.description, h.status FROM system_logs h LEFT JOIN user_information e ON e.user_id = h.user_id WHERE date_format(h.timestamp, '%M %e %Y %r') LIKE @date ORDER BY h.id ASC;";
            mysqlCmd.CommandType = CommandType.Text;
            mysqlCmd.Connection = Global.MysqlCon;

            mysqlCmd.Parameters.Add("@date", MySqlDbType.VarChar).Value = date;

            settingsTable.Load(mysqlCmd.ExecuteReader());
            Global.MysqlCon.Close();
            return settingsTable;
        }
    }
}