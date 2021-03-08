using Models;
using Reposytories.Abstract;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace Reposytories.Concrete.ADONET
{
    public class HistoryReposytory: IHistoryReposytory
    {
        public IEnumerable<History> GetAllHistory()
        {
            string connStr = ConfigurationManager.ConnectionStrings["adoConnStr"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connStr))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "select * from History";

                var reader = command.ExecuteReader();

                var result = new List<History>();
                while (reader.Read())
                {
                    result.Add(new History
                    {
                        Id = Convert.ToInt32(reader["Id"].ToString()),
                        Lesson_ID = Convert.ToInt32(reader["Lesson_ID"].ToString()),
                        Operation = reader["Operation"].ToString(),
                        OnTime = Convert.ToDateTime(reader["OnTime"].ToString())
                    });
                }

                connection.Close();

                return result;
            }
        }
    }
}
