using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace ProductionLineDemoClassLibrary.DataAccessLayer
{
    public class ADO_DAL
    {
        private string _connectionString;

        public string ConnectionString
        {
            get { return _connectionString; }
            set { _connectionString = value; }
        }
        /// <summary>
        /// Method of ADO_DAL class to insert update and DELETE records from SQL Server database. It can be used with 
        /// both a SQL statement and a Stored Procedure
        /// </summary>
        /// <param name="sql">Takes in the SQL Statement or the Stored Rocedure name</param>
        /// <param name="sqlParameters">Takes in the parameters for the query</param>
        /// <param name="isSP">If value passed is true, than the method will consider the SQL to be the name of a SP. Otherwise it will consider it as a SQL Query </param>
        /// <returns>Statement execution success status</returns>
        /// <throws>Exception if SQL error</throws>
        public bool Exec_INS_UPD_DEL(string sql, List<SqlParameter> sqlParameters, bool isStoredProcedure)
        {
            bool retVal = false;
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.CommandType = CommandType.Text;
                        if (isStoredProcedure)
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                        }
                        cmd.Parameters.AddRange(sqlParameters.ToArray());

                        retVal =  cmd.ExecuteNonQuery() > 0
                    };
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                //NO MATTER WHAT WILL HAPPEN, THIS WILL RUN!
                finally
                {
                    //Close the connection to the database
                    conn.Close();
                }
            }
            return retVal;
        }
        /// <summary>
        /// Method of ADO_DAL Class to select records from DB by using a SQL Query or a Stored Procedure 
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="isSP"></param>
        /// <param name="hasParams"></param>
        /// <param name="sqlParameters"></param>
        /// <returns></returns>
        public DataTable Exec_SELECT(string sql, bool isStoredProcedure, bool hasParams, List<SqlParameter> sqlParameters = null)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                try
                {
                    conn.Open();
                    if (conn != null && conn.State != ConnectionState.Open)
                    {
                        Debug.WriteLine($"Connection is OPEN!");
                    }
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.CommandType = CommandType.Text;
                        if (isStoredProcedure)
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                        }

                        if (hasParams)
                        {
                            cmd.Parameters.AddRange(sqlParameters.ToArray());
                        }

                        //Execute Command
                        SqlCommand command = conn.CreateCommand();
                        SqlDataReader dataReader = cmd.ExecuteReader();

                        dt.Load(dataReader);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                //NO MATTER WHAT WILL HAPPEN, THIS WILL RUN!
                finally
                {
                    //Close the connection to the database
                    conn.Close();
                }
            }
            return dt;
        }
    }
}
