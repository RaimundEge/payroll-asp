using System.Collections.Generic;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace Payroll.Pages.Employee
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Salary { get; set; }
        public string Address { get; set; }
        public string RoutingNumber { get; set; }
        public string AccountNumber { get; set; }
        public int ProjectId { get; set; }
    }

    public class EmployeeStore
    {
        private string connStr;

        public EmployeeStore(string connStr) {
            this.connStr = connStr;
        }
        public List<Employee> FindEmployees(string name)
        {
            using (MySqlConnection sqlConnection = new MySqlConnection(connStr))
            {
                sqlConnection.Open();
                List<Employee> list = new List<Employee>();
                MySqlCommand cmd = new MySqlCommand
                {
                    Connection = sqlConnection,
                    CommandText = "SELECT * FROM Employees WHERE name LIKE @name"
                };
                cmd.Parameters.AddWithValue("name", "%" + name + "%");
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Employee emp = new Employee
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            Name = reader.GetString(reader.GetOrdinal("Name")),
                            Salary = reader.GetFloat(reader.GetOrdinal("Salary")),
                            Address = reader.GetString(reader.GetOrdinal("Address")),
                            RoutingNumber = reader.GetString(reader.GetOrdinal("RoutingNumber")),
                            AccountNumber = reader.GetString(reader.GetOrdinal("AccountNumber")),
                            ProjectId = reader.GetInt32(reader.GetOrdinal("ProjectId"))
                        };
                        list.Add(emp);
                    }
                }
                return list;
            }
        }

        public Employee getEmployee(int id)
        {
            using (MySqlConnection sqlConnection = new MySqlConnection(connStr))
            {
                sqlConnection.Open();
                Employee emp = null;
                MySqlCommand cmd = new MySqlCommand
                {
                    Connection = sqlConnection,
                    CommandText = "SELECT * FROM Employees WHERE Id = @id"
                };
                cmd.Parameters.AddWithValue("id", id);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        emp = new Employee
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            Name = reader.GetString(reader.GetOrdinal("Name")),
                            Salary = reader.GetFloat(reader.GetOrdinal("Salary")),
                            Address = reader.GetString(reader.GetOrdinal("Address")),
                            RoutingNumber = reader.GetString(reader.GetOrdinal("RoutingNumber")),
                            AccountNumber = reader.GetString(reader.GetOrdinal("AccountNumber")),
                            ProjectId = reader.GetInt32(reader.GetOrdinal("ProjectId"))
                        };

                    }
                }
                return emp;
            }
        }

        public string updateEmployee(Employee emp)
        {
            using (MySqlConnection sqlConnection = new MySqlConnection(connStr))
            {
                sqlConnection.Open();
                if (emp.Id == -1)
                {
                    MySqlCommand cmd = new MySqlCommand
                    {
                        Connection = sqlConnection,
                        CommandText = "INSERT INTO Employees (Name, Address, Salary, ProjectId, RoutingNumber, AccountNumber) VALUES (" +
                            " @name, @address, @salary, @projectid, @routingnumber, @accountnumber )"
                    };
                    cmd.Parameters.AddWithValue("name", emp.Name);
                    cmd.Parameters.AddWithValue("address", emp.Address);
                    cmd.Parameters.AddWithValue("projectid", emp.ProjectId);
                    cmd.Parameters.AddWithValue("salary", emp.Salary);
                    cmd.Parameters.AddWithValue("routingnumber", emp.RoutingNumber);
                    cmd.Parameters.AddWithValue("accountnumber", emp.AccountNumber);
                    int rows = cmd.ExecuteNonQuery();
                    if (rows > 0)
                    {
                        return "Employee record created successfully";
                    }
                    else
                    {
                        return "Error creating employee record";
                    }
                }
                else
                {
                    MySqlCommand cmd = new MySqlCommand
                    {
                        Connection = sqlConnection,
                        CommandText = "UPDATE Employees SET Name = @name, Address = @address, Salary = @salary, " +
                                "ProjectId = @projectid, RoutingNumber = @routingnumber, AccountNumber = @accountnumber " +
                                "WHERE id = @id"
                    };
                    cmd.Parameters.AddWithValue("id", emp.Id);
                    cmd.Parameters.AddWithValue("name", emp.Name);
                    cmd.Parameters.AddWithValue("address", emp.Address);
                    cmd.Parameters.AddWithValue("projectid", emp.ProjectId);
                    cmd.Parameters.AddWithValue("salary", emp.Salary);
                    cmd.Parameters.AddWithValue("routingnumber", emp.RoutingNumber);
                    cmd.Parameters.AddWithValue("accountnumber", emp.AccountNumber);
                    int rows = cmd.ExecuteNonQuery();
                    if (rows > 0)
                    {
                        return "Employee record updated successfully";
                    }
                    else
                    {
                        return "Error updating employee record";
                    }
                }
            }
        }

        public string deleteEmployee(int id)
        {
            using (MySqlConnection sqlConnection = new MySqlConnection(connStr))
            {
                sqlConnection.Open();
                MySqlCommand cmd = new MySqlCommand
                {
                    Connection = sqlConnection,
                    CommandText = "DELETE FROM Employees WHERE Id = @id"
                };
                cmd.Parameters.AddWithValue("id", id);
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    return "Employee record deleted successfully";
                }
                else
                {
                    return "Error deleting employee record";
                }
            }
        }
    }

}