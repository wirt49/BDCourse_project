using Models;
using Reposytories.Abstract;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace Reposytories.Concrete.ADONET
{
    public class StudentReposytory: IStudentReposytory
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
        public IEnumerable<Student> GetAllStudents()
        {
            string connStr = ConfigurationManager.ConnectionStrings["adoConnStr"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connStr))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "select * from Student";

                var reader = command.ExecuteReader();

                var result = new List<Student>();
                while (reader.Read())
                {
                    result.Add(new Student
                    {
                        Id = Convert.ToInt32(reader["Id"].ToString()),
                        FirstName = reader["First name"].ToString(),
                        LastName = reader["Last name"].ToString(),
                        Birth = Convert.ToDateTime(reader["Date of birth"].ToString()),
                        Group_number = Convert.ToInt32(reader["Academic Group"].ToString()),
                    });
                }

                connection.Close();

                return result;
            }
        }

        public bool Add(Student student)
        {
            return ExecuteNonQueryCommand(string.Format("insert into Student(Id, FirstName, LastName, Birth, Group_number)" +
                " values ({0}, '{1}', '{2}', '{3}', {4})",
                student.Id, student.FirstName, student.LastName, student.Birth, student.Group_number));
        }
        public bool Delete(Student student)
        {
            return ExecuteNonQueryCommand(string.Format("delete from Student where Id = {0}", student.Id));
        }
        public bool Update(Student student)
        {
            return ExecuteNonQueryCommand(string.Format("update Lectrer set Id = {0}," +
                " FirstName = {1}, LastName = {2}, Birth = {3}, Group_number = {4} where Id = {0}",
                student.Id, student.FirstName, student.LastName, student.Birth, student.Group_number));
        }

    }
}
