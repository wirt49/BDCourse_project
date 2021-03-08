using Models;
using Reposytories.Abstract;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace Reposytories.Concrete.ADONET
{
    public class LessonReposytory: ILessonReposytory
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
        public IEnumerable<Lesson> GetAllLessons()
        {
            string connStr = ConfigurationManager.ConnectionStrings["adoConnStr"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connStr))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "select * from Lesson";

                var reader = command.ExecuteReader();

                var result = new List<Lesson>();
                while (reader.Read())
                {
                    result.Add(new Lesson
                    {
                        Id = Convert.ToInt32(reader["Id"].ToString()),
                        Subject = Convert.ToInt32(reader["Subject"].ToString()),
                        Lecturer = Convert.ToInt32(reader["Lecturer"].ToString()),
                        Audience = Convert.ToInt32(reader["Audience"].ToString()),
                        Academic_group = Convert.ToInt32(reader["Academic_group"].ToString()),
                        Time = Convert.ToDateTime(reader["Time"].ToString()),
                        Day = reader["Day"].ToString(),
                        Type = reader["Type"].ToString(),

                    });
                }

                connection.Close();

                return result;
            }
        }

        public bool Add(Lesson lesson)
        {
            return ExecuteNonQueryCommand(string.Format("insert into Lesson(Id, Subject, Lecturer, Audience, Academic_group, Time, Day, Type)" +
                " values ({0}, {1}, {2}, {3}, {4}, {5}, '{6}', '{7}', '{8}')",
                lesson.Id, lesson.Subject, lesson.Lecturer, lesson.Audience, lesson.Academic_group, lesson.Time, lesson.Day, lesson.Type));
        }
        public bool Delete(Lesson lesson)
        {
            return ExecuteNonQueryCommand(string.Format("delete from Lesson where Id = {0}", lesson.Id));
        }
        public bool Update(Lesson lesson)
        {
            return ExecuteNonQueryCommand(string.Format("update Lesson set Id = {0}," +
                " Subject = {1}, Lecturer = {2}, Audience = {3}, Academic_group = {4}, Time = {5}, Day = {6}, Type = {7} where Id = {0}",
                lesson.Id, lesson.Subject, lesson.Lecturer, lesson.Audience, lesson.Academic_group, lesson.Time, lesson.Day, lesson.Type));
        }
    }
}
