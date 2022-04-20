using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using Stadion.Data;

namespace Stadion.CRUD
{
    internal class SelectAllUsers
    {
        public static void AllUsers()
        {
            Database db = new Database();
            using (SqlConnection con = new SqlConnection(db.connectionStr))
            {
                con.Open();
                string query = "SELECT * FROM Users";
                using (SqlCommand cmd = new SqlCommand(query,con))
                {
                    SqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        int id = dataReader.GetInt32(0);
                        string fullName = dataReader.GetString(1);
                        string email = dataReader.GetString(2);
                        Users user = new Users()
                        {
                            Id = id,
                            FullName = fullName,
                            Email = email,
                        };
                        user.ShowInfo();
                    }
                    dataReader.Close();
                }
            }
        }
    }
}
