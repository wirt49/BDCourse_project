using Models;
using Reposytories.Abstract;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace Reposytories.Concrete.ADONET
{
    public class LecturerReposytory: ILecturerReposytory
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
        public IEnumerable<Lecturer> GetAllLecturers()
        {
            string connStr = ConfigurationManager.ConnectionStrings["adoConnStr"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connStr))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "select * from Lecturer";

                var reader = command.ExecuteReader();

                var result = new List<Lecturer>();
                while (reader.Read())
                {
                    result.Add(new Lecturer
                    {
                        Id = Convert.ToInt32(reader["Id"].ToString()),
                        FirstName = reader["First name"].ToString(),
                        LastName = reader["Last name"].ToString(),
                        Reputation = Convert.ToInt32(reader["Reputation"].ToString()),
                        Phone = reader["Phone"].ToString()
                    });
                }

                connection.Close();

                return result;
            }
        }

        public bool Add(Lecturer lecturer)
        {
            return ExecuteNonQueryCommand(string.Format("insert into Lecturer(Id, FirstName, LastName, Reputation, Phone)" +
                " values ({0}, '{1}', '{2}', {3}, '{4}')",
                lecturer.Id, lecturer.FirstName, lecturer.LastName, lecturer.Reputation, lecturer.Phone));
        }
        public bool Delete(Lecturer lecturer)
        {
            return ExecuteNonQueryCommand(string.Format("delete from Lecturer where Id = {0}", lecturer.Id));
        }
        public bool Update(Lecturer lecturer)
        {
            return ExecuteNonQueryCommand(string.Format("update Lectrer set Id = {0}," +
                " FirstName = {1}, LastName = {2}, Reputation = {3}, Phone = {4} where Id = {0}",
                lecturer.Id, lecturer.FirstName, lecturer.LastName, lecturer.Reputation, lecturer.Phone));
        }
        public bool DeleteReference(Lecturer lecturer)
        {
            return ExecuteNonQueryCommand(string.Format("delete from Lesson where Lecturer = {0}", lecturer.Id));
        }
    }
}
