using Models;
using Reposytories.Abstract;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace Reposytories.Concrete.ADONET
{
    public class SubjectReposytory: ISubjectReposytory
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
        public IEnumerable<Subject> GetAllSubjects()
        {
            string connStr = ConfigurationManager.ConnectionStrings["adoConnStr"].ConnectionString;
        
            using (SqlConnection connection = new SqlConnection(connStr))
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "select * from Subject";
                var reader = command.ExecuteReader();
                var result = new List<Subject>();
                while (reader.Read())
                {
                    result.Add(new Subject
                    {
                        Id = Convert.ToInt32(reader["Id"].ToString()),
                        Name = reader["Name"].ToString()
                    });
                }
                connection.Close();
                return result;
            }
        }
        public bool Add(Subject subject)
        {
            return ExecuteNonQueryCommand(string.Format("insert into Subject(Id, Name) values ({0}, '{1}')", subject.Id, subject.Name));
        }
        public bool Delete(Subject subject)
        {
            return ExecuteNonQueryCommand(string.Format("delete from Subject where Id = {0}", subject.Id));
        }
        public bool Update(Subject subject)
        {
            return ExecuteNonQueryCommand(string.Format("update Subject set Id = {0}, Name = {1} where Id = {0}", subject.Id, subject.Name));
        }
        public bool DeleteReference(Subject subject)
        {
            return ExecuteNonQueryCommand(string.Format("delete from Lesson where Subject = {0}", subject.Id));
        }
    }
}

