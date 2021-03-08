using Models;
using Reposytories.Abstract;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace Reposytories.Concrete.ADONET
{
    public class GroupReposytory: IGroupReposytory
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
        public IEnumerable<Groups> GetAllGroups()
        {
            string connStr = ConfigurationManager.ConnectionStrings["adoConnStr"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connStr))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "select * from Groups";

                var reader = command.ExecuteReader();

                var result = new List<Groups>();
                while (reader.Read())
                {
                    result.Add(new Groups
                    {
                        Id = Convert.ToInt32(reader["Id"].ToString()),
                        Name = "ADO" + (reader["Name"].ToString())
                    });
                }

                connection.Close();

                return result;
            }
        }

        public bool Add(Groups groups)
        {
            return ExecuteNonQueryCommand(string.Format("insert into Groups(Id, Name) values ({0}, '{1}')", groups.Id, groups.Name));
        }
        public bool Delete(Groups groups)
        {
            return ExecuteNonQueryCommand(string.Format("delete from Groups where Id = {0}", groups.Id));
        }
        public bool Update(Groups groups)
        {
            return ExecuteNonQueryCommand(string.Format("update Groups set Id = {0}, Name = {1} where Id = {0}", groups.Id, groups.Name));
        }
        public bool DeleteReference(Groups groups)
        {
            return ExecuteNonQueryCommand(string.Format("delete from Student where Group_number = {0}" 
                + "delete from Lesson where Academic_group = {0}", groups.Id));
        }

    }
}
