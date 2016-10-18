namespace TruckApi.Core
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Data;
    using System.Linq;
    using System.Web;
    using MySql.Data.MySqlClient;
    using Newtonsoft.Json;
    using TruckApi.Models;

    public static class DbAccess
    {

        private static string dbConnection = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        public static List<Dictionary<string, object>> DbASelect(string query)
        {
            try
            {
                DataTable dt = new DataTable();

                using (MySqlConnection mySqlConnection = new MySqlConnection(dbConnection))
                {
                    using (MySqlCommand mySqlCommand = new MySqlCommand(query, mySqlConnection))
                    {
                        mySqlConnection.Open();

                        using (MySqlDataAdapter da = new MySqlDataAdapter(mySqlCommand))
                        {
                            da.Fill(dt);
                        }

                        return DictionaryData(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }

        public static string DbAInsert(string query)
        {
            try
            {
                using (MySqlConnection objDbConnection = new MySqlConnection(dbConnection))
                {
                    using (MySqlCommand DBcommand = new MySqlCommand(query, objDbConnection))
                    {
                        objDbConnection.Open();

                        int i = DBcommand.ExecuteNonQuery();

                        if (i == 1)
                        {
                            return "success";
                        }
                        else
                        {
                            return "no added";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }

        public static List<Dictionary<string, object>> DictionaryData(DataTable dt)
        {
            List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
            Dictionary<string, object> row;

            foreach (DataRow dr in dt.Rows)
            {
                row = new Dictionary<string, object>();
                foreach (DataColumn col in dt.Columns)
                {
                    row.Add(col.ColumnName, dr[col]);
                }
                rows.Add(row);
            }

            return rows;
        }
    }
}