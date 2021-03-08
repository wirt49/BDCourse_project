using Models;
using Reposytories.Abstract;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;


namespace Reposytories.Concrete.ADONET
{
    public class AudienceReposytory: IAudienceReposytory
    {
        public bool ExecuteNonQueryCommand(string cmd)
        {
            string connStr = ConfigurationManager.ConnectionStrings["adoConnStr"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connStr))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = cmd;

                int affeectedRows = command.ExecuteNonQuery();
                connection.Close();

                return affeectedRows > 0;
            }
        }
        public IEnumerable<Audience> GetAllAudiences()
        {
            string connStr = ConfigurationManager.ConnectionStrings["adoConnStr"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connStr))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "select * from Audience";

                var reader = command.ExecuteReader();

                var result = new List<Audience>();
                while (reader.Read())
                {
                    result.Add(new Audience
                    {
                        Id = Convert.ToInt32(reader["Id"].ToString()),
                        Number = Convert.ToInt32(reader["Number"].ToString())
                    });
                }

                connection.Close();

                return result;
            }
        }
    
        public bool Add(Audience audience)
        {
            return ExecuteNonQueryCommand(string.Format("insert into Audience(Id, Number) values ({0}, '{1}')", audience.Id, audience.Number));
        }
        public bool Delete(Audience audience)
        {
            return ExecuteNonQueryCommand(string.Format("delete from Audience where Id = {0}", audience.Id));
        }
        public bool Update(Audience audience)
        {
            return ExecuteNonQueryCommand(string.Format("update Audience set Id = {0}, Number = {1} where Id = {0}", audience.Id, audience.Number));
        }
        public bool DeleteReference(Audience audience)
        {
            return ExecuteNonQueryCommand(string.Format("delete from Lesson where Audience = {0}", audience.Id ));
        }

    }
}