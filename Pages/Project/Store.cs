using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace Payroll.Pages.Project
{
    public class Project
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public double Expense { get; set; }
    }
    public class ProjectStore
    {
        private string connStr;
        public ProjectStore(string connStr)
        {
            this.connStr = connStr;
        }
        public List<Project> FindProjects(string name)
        {
            using (MySqlConnection sqlConnection = new MySqlConnection(connStr))
            {
                sqlConnection.Open();
                List<Project> list = new List<Project>();
                if (sqlConnection != null)
                {
                    MySqlCommand cmd = new MySqlCommand
                    {
                        Connection = sqlConnection,
                        CommandText = "SELECT * FROM Projects WHERE Title LIKE @name"
                    };
                    cmd.Parameters.AddWithValue("name", "%" + name + "%");
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Project proj = new Project
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                Title = reader.GetString(reader.GetOrdinal("Title")),
                                Expense = reader.GetFloat(reader.GetOrdinal("Expense"))
                            };
                            list.Add(proj);
                        }
                    }
                }
                return list;
            }
        }

        public Project getProject(int id)
        {
            using (MySqlConnection sqlConnection = new MySqlConnection(connStr))
            {
                sqlConnection.Open();
                Project proj = null;
                MySqlCommand cmd = new MySqlCommand
                {
                    Connection = sqlConnection,
                    CommandText = "SELECT * FROM Projects WHERE Id = @id"
                };
                cmd.Parameters.AddWithValue("id", id);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        proj = new Project
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            Title = reader.GetString(reader.GetOrdinal("Title")),
                            Expense = reader.GetFloat(reader.GetOrdinal("Expense"))
                        };

                    }
                }
                return proj;
            }
        }

        public string updateProject(Project proj)
        {
            using (MySqlConnection sqlConnection = new MySqlConnection(connStr))
            {
                sqlConnection.Open();
                if (proj.Id == -1)
                {
                    MySqlCommand cmd = new MySqlCommand
                    {
                        Connection = sqlConnection,
                        CommandText = "INSERT INTO Projects (Title, Expense) VALUES (" +
                            " @title, @expense)"
                    };
                    cmd.Parameters.AddWithValue("title", proj.Title);
                    cmd.Parameters.AddWithValue("expense", proj.Expense);
                    int rows = cmd.ExecuteNonQuery();
                    sqlConnection.Close();
                    if (rows > 0)
                    {
                        return "Project record created successfully";
                    }
                    else
                    {
                        return "Error creating Project record";
                    }
                }
                else
                {
                    MySqlCommand cmd = new MySqlCommand
                    {
                        Connection = sqlConnection,
                        CommandText = "UPDATE Projects SET Title = @title, Expense = @expense " +
                                "WHERE id = @id"
                    };
                    cmd.Parameters.AddWithValue("id", proj.Id);
                    cmd.Parameters.AddWithValue("title", proj.Title);
                    cmd.Parameters.AddWithValue("expense", proj.Expense);
                    int rows = cmd.ExecuteNonQuery();
                    if (rows > 0)
                    {
                        return "Project record updated successfully";
                    }
                    else
                    {
                        return "Error updating Project record";
                    }
                }
            }
        }

        public string deleteProject(int id)
        {
            using (MySqlConnection sqlConnection = new MySqlConnection(connStr))
            {
                sqlConnection.Open();
                MySqlCommand cmd = new MySqlCommand
                {
                    Connection = sqlConnection,
                    CommandText = "DELETE FROM Projects WHERE Id = @id"
                };
                cmd.Parameters.AddWithValue("id", id);
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    return "Project record deleted successfully";
                }
                else
                {
                    return "Error deleting project record";
                }
            }
        }
    }
}