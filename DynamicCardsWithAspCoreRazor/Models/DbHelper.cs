using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace DynamicCardsWithAspCoreRazor.Models
{
    public static class AppSettings
    {
        public static string ConnectionString { get; set; }
    }
    public class DbHelper
    {
        // You need to change connection string from Web.config
        private static readonly string connectionString = AppSettings.ConnectionString;
        /// <summary>
        /// Execute Select query and return results as a DataTable
        /// </summary>
        /// <param name="cmdText"></param>
        /// <param name="cmdType"></param>
        /// <param name="parameters"></param>
        /// <returns>DataTable</returns>
        public static DataTable ExecuteQuery(string cmdText, CommandType cmdType, SqlParameter[] parameters)
        {
            DataTable table = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(cmdText, con))
                    {
                        con.Open();
                        cmd.CommandType = cmdType;

                        if (parameters != null)
                            cmd.Parameters.AddRange(parameters);

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(table);
                    }
                }
            }
            catch (Exception ex)
            {
                // save ex to logger (file or eventLog)
                string error = ex.Message;

                return null;
            }
            return table;
        }
    }
}
