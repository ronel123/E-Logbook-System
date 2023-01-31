using Log_book_System.Classes.Variable;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Log_book_System.Classes.Database
{
    class Account : DBConnection
    {
        /* Objects */
        static DataTable accTable;
        static MySqlCommand mysqlCmd;

        /* Properties (Variables w/ Getter and Setter) */
        public Account()
        {
            accTable = new DataTable();
            mysqlCmd = new MySqlCommand();
        }

        /* ReadAccount method is the one that get the User Account Information and return to DataTable */
        public DataTable ReadAccount(string user)
        {
            Global.MysqlCon.Open();
            mysqlCmd.Parameters.Clear(); // Clear the parameter this is to avoid exception error due to the parameter is being added.
            mysqlCmd.CommandText = "SELECT ui.user_id, CONCAT(ui.last_name, \", \", ui.first_name, \" \", SUBSTRING(ui.middle_name, 1, 1)) as name, ui.gender, ua.email_address, ua.username, ua.password, ur.rolename FROM `user_information` ui LEFT JOIN user_account ua ON ui.user_id = ua.user_id LEFT JOIN user_roles ur ON ua.role_id = ur.role_id WHERE ua.username = @user";
            mysqlCmd.CommandType = CommandType.Text;
            mysqlCmd.Connection = Global.MysqlCon;

            mysqlCmd.Parameters.Add("@user", MySqlDbType.VarChar).Value = user;

            accTable.Load(mysqlCmd.ExecuteReader());
            Global.MysqlCon.Close();
            return accTable;
        }

        public DataTable CheckPasswordAccount(string password)
        {
            Global.MysqlCon.Open();
            mysqlCmd.Parameters.Clear(); // Clear the parameter this is to avoid exception error due to the parameter is being added.
            //mysqlCmd.CommandText = "SELECT u.*, e.employee_id, CONCAT(e.last_name, \", \", e.first_name, \" \", SUBSTRING(e.middle_name, 1, 1), \".\") AS employee_name, (CASE WHEN ur.role_name IS null THEN \"None\" ELSE ur.role_name END) AS role FROM user_account u LEFT JOIN employee e ON e.user_id = u.user_id LEFT JOIN user_role ur ON u.user_role_id = ur.user_role_id WHERE user_name = @user";
            mysqlCmd.CommandText = "SELECT user_id, password FROM user_account WHERE user_id = @user_id AND password =@password";
            mysqlCmd.CommandType = CommandType.Text;
            mysqlCmd.Connection = Global.MysqlCon;

            mysqlCmd.Parameters.Add("@user_id", MySqlDbType.VarChar).Value = Global.Login_UserID;
            mysqlCmd.Parameters.Add("@password", MySqlDbType.VarChar).Value = password;

            accTable.Load(mysqlCmd.ExecuteReader());
            Global.MysqlCon.Close();
            return accTable;
        }

        public int ChangeUserPassword(string password)
        {
            Global.MysqlCon.Open();
            mysqlCmd.Parameters.Clear();

            string tempStr = string.Format("UPDATE user_account SET password =@password WHERE user_id = @user_id");

            mysqlCmd.CommandText = tempStr;
            mysqlCmd.CommandType = CommandType.Text;
            mysqlCmd.Connection = Global.MysqlCon;

            mysqlCmd.Parameters.Add("@user_id", MySqlDbType.VarChar).Value = Global.Login_UserID;
            mysqlCmd.Parameters.Add("@password", MySqlDbType.VarChar).Value = password;

            int affectedRows = mysqlCmd.ExecuteNonQuery();
            Global.MysqlCon.Close();
            if (affectedRows > 0)
                return affectedRows;
            return 0;
        }
   
        
    }
}
