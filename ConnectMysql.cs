using System;
using MySql.Data.MySqlClient;
using System.Data;
using System.Data.SqlClient;

namespace ConectionToDLL
{
    public class ConnectMysql
    {
        #region attributes
        
        private MySqlConnection objConnection = new MySqlConnection();
        private MySqlCommand objCommand = new MySqlCommand();
        private MySqlDataReader objData;
        private MySqlDataAdapter objDateToMemory;
        private string Erro;
        public string strConnect;

        #endregion

        public ConnectMysql(string server, string database, string user, string password)
        {
            strConnect = $"Server={server};Database={database};User={user};Pwd={password}";
        }

        public string getErro()
        {
            return "";
        }
        private bool connect()
        {
            return true;
        }
        private bool disconnect()
        {
            return true;
        }
        public bool testConnect()
        {
            return true;
        }
        public bool INSERT(string commandSql)
        {
            return true;
        }
        public bool UPDATE(string commandSql)
        {
            return true;
        }
        public bool DELETE(string commandSql)
        {
            return true;
        }
        public string[,] SELECT_1(string commandSql)
        {
            return null;
        }
        public DataTable SELECT_2(string commandSql)
        {
            return null;
        }
    }
}


namespace ConectionToDLL
{
    public class ConnectSqlServer
    {
        #region attributes
        
        private SqlConnection objConnection = new SqlConnection();
        private SqlCommand objCommand = new SqlCommand();
        private SqlDataReader objData;
        private SqlDataAdapter objDateToMemory;
        private string Erro;
        public string strConnect;

        #endregion

        public ConnectSqlServer(string strconnect)
        {
            strConnect = strconnect;
        }

        public string getErro()
        {
            return "";
        }
        private bool connect()
        {
            return true;
        }
        private bool disconnect()
        {
            return true;
        }
        public bool testConnect()
        {
            return true;
        }
        public bool INSERT(string commandSql)
        {
            return true;
        }
        public bool UPDATE(string commandSql)
        {
            return true;
        }
        public bool DELETE(string commandSql)
        {
            return true;
        }
        public string[,] SELECT_1(string commandSql)
        {
            return null;
        }
        public DataTable SELECT_2(string commandSql)
        {
            return null;
        }
    }
}
