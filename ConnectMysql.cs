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
            return this.Erro;
        }
        private bool connect()
        {
            try
            {
                disconnect();
                objConnection.ConnectionString = strConnect;
                objCommand.Connection = objConnection;
                objConnection.Open();
                return true;
            }
            catch (Exception _erro)
            {
                Erro = _erro.Message.ToString();
                return false;
            }
            
        }
        private bool disconnect()
        {
            try
            {
                if (objConnection.State == ConnectionState.Open)
                {
                    objConnection.Close();
                }
                return true;
            }
            catch (Exception _erro)
            {
                Erro = _erro.Message.ToString();
                return false;
            }
        }
        public bool testConnect()
        {
            return connect();
        }
        public bool INSERT(string commandSql)
        {
            try
            {
                bool blnReturn = false;
                if (connect())
                {
                    objCommand.CommandText = commandSql;
                    int result = objCommand.ExecuteNonQuery();
                    if (result > 0)
                    {
                        blnReturn = true;
                    } else
                    {
                        Erro = "Erro na inclusão de dados";
                    }
                }
                return blnReturn;
            }
            catch (Exception _erro)
            {
                Erro = _erro.Message.ToString();
                return false;
            }
        }
        public bool UPDATE(string commandSql)
        {
            try
            {
                bool blnReturn = false;
                if (connect())
                {
                    objCommand.CommandText = commandSql;
                    int result = objCommand.ExecuteNonQuery();
                    if (result > 0)
                    {
                        blnReturn = true;
                    } else 
                    {
                        Erro = "Erro na alteração de dados.";
                    }
                }
                return blnReturn;
            }
            catch (Exception _erro)
            {
                Erro = _erro.Message.ToString();
                return false;
            }
        }
        public bool DELETE(string commandSql)
        {
            try
            {
                bool blnReturn = false;
                if (connect())
                {
                    objCommand.CommandText = commandSql;
                    int result = objCommand.ExecuteNonQuery();
                    if (result > 0)
                    {
                        blnReturn = true;
                    } else
                    {
                        Erro = "Erro na exclusão de dados.";
                    }
                }
                return blnReturn;
            }
            catch (Exception _erro)
            {
                Erro = _erro.Message.ToString();
                return false;
            }
        }
        public string[,] SELECT_1(string commandSql)
        {
            try
            {
                string[,] result = null;
                if (connect())
                {
                    objDateToMemory = new MySqlDataAdapter(commandSql, objConnection);
                    DataTable tabledata = new DataTable();
                    objDateToMemory.Fill(tabledata);
                    if (tabledata.Rows.Count > 0)
                    {
                        int l = tabledata.Rows.Count;
                        int c = tabledata.Columns.Count;
                        result = new string[l, c];
                        DataRow[] lines = tabledata.Select();
                        int count = 0;
                        foreach (DataRow line in lines)
                        {
                            for (int i = 0; i < c; i++)
                            {
                                result[count, i] = line[i].ToString();
                            }
                            count++;
                        }
                    }
                }
                return result;
            }
            catch (Exception _erro)
            {
                Erro =_erro.Message.ToString();
                return null;
            }
        }
        public DataTable SELECT_2(string commandSql)
        {
            try
            {
                if(connect())
                {
                    objDateToMemory = new MySqlDataAdapter(commandSql, objConnection);
                    DataTable tabledata = new DataTable();
                    objDateToMemory.Fill(tabledata);
                    if (tabledata.Rows.Count > 0)
                    {
                        return tabledata;
                    }
                }
                return null;
            }
            catch (Exception _erro)
            {
                Erro = _erro.Message.ToString();
                return null;
            }
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
            return this.Erro;
        }
        private bool connect()
        {
            try
            {
                disconnect();
                objConnection.ConnectionString = strConnect;
                objCommand.Connection = objConnection;
                objConnection.Open();
                return true;                
            }
            catch (Exception _erro)
            {
                Erro = _erro.Message.ToString();
                return false;
            }
        }
        private bool disconnect()
        {
            try
            {
                if (objConnection.State == ConnectionState.Open)
                {
                    objConnection.Close();
                }
                return true;
            }
            catch (Exception _erro)
            {
                Erro = _erro.Message.ToString();
                return false;
            }
        }
        public bool testConnect()
        {
            return connect();
        }
        public bool INSERT(string commandSql)
        {
            try
            {
                bool blReturn = false;
                if (connect())
                {
                    objCommand.CommandText = commandSql;
                    int result = objCommand.ExecuteNonQuery();
                    if (result > 0)
                    {
                        blReturn = true;
                    } else
                    {
                        Erro = "Erro na inserção de dados.";
                    }
                }
                return blReturn;
            }
            catch (Exception _erro)
            {
                Erro = _erro.Message.ToString();
                return false;
            }
        }
        public bool UPDATE(string commandSql)
        {
            try
            {
                bool blnReturn = false;
                if (connect())
                {
                    objCommand.CommandText = commandSql;
                    int result = objCommand.ExecuteNonQuery();
                    if (result > 0)
                    {
                        blnReturn = true;
                    } else
                    {
                        Erro = "Erro na alteração de dados.";
                    }
                }
                return blnReturn;
            }
            catch (Exception _erro)
            {
                Erro = _erro.Message.ToString();
                return false;
            }
        }
        public bool DELETE(string commandSql)
        {
            try
            {
                bool blnReturn = false;
                if (connect())
                {
                    objCommand.CommandText = commandSql;
                    int result = objCommand.ExecuteNonQuery();
                    if (result > 0)
                    {
                        blnReturn = true;
                    } else
                    {
                        Erro = "Erro na exclusão de dados.";
                    }
                }
                return blnReturn;
            }
            catch (Exception _erro)
            {
                Erro = _erro.Message.ToString();
                return false;
            }
        }
        public string[,] SELECT_1(string commandSql)
        {
            try
            {
                string[,] result = null;
                if (connect())
                {
                    objDateToMemory = new SqlDataAdapter(commandSql, objConnection);
                    DataTable tabledata = new DataTable();
                    objDateToMemory.Fill(tabledata);
                    if (tabledata.Rows.Count > 0)
                    {
                        int l = tabledata.Rows.Count;
                        int c = tabledata.Columns.Count;
                        result = new string[l, c];
                        DataRow[] lines = tabledata.Select();
                        int count = 0;
                        foreach (DataRow line in lines)
                        {
                            for (int i = 0; i < c; i++)
                            {
                                result[count, i] = line[i].ToString();
                            }
                            count++;
                        }
                    }
                }   
                return result;
            }
            catch (Exception _erro)
            {
                Erro = _erro.Message.ToString();
                return null;
            }
        }
        public DataTable SELECT_2(string commandSql)
        {
           try
           {
               if (connect())
               {
                    objDateToMemory = new SqlDataAdapter(commandSql, objConnection);
                    DataTable tabledata = new DataTable();
                    objDateToMemory.Fill(tabledata);
                    if (tabledata.Rows.Count > 0)
                    {
                        return tabledata;
                    }
               }
                return null;
           }
           catch (Exception _erro)
           {
               Erro = _erro.Message.ToString();
               return null;
           }
        }
    }
}
