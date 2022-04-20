using Stadion.Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Stadion.CRUD
{
    internal class SelectAllStadions
    {
        public static void AllStadions()
        {
            Database db = new Database();
            using (SqlConnection con = new SqlConnection(db.connectionStr))
            {
                con.Open();
                string query = "SELECT * FROM Stadions";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    SqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        int id = dataReader.GetInt32(0);
                        string name = dataReader.GetString(1);
                        decimal hourPrice = dataReader.GetDecimal(2);
                        int capacity = dataReader.GetInt32(3);
                        Stadions stadion = new Stadions()
                        {
                            Id = id,
                            Name = name,
                            HourPrice = hourPrice,
                            Capacity = capacity,
                        };
                        stadion.ShowInfo();
                    }
                    dataReader.Close();
                }
            }
        }
    }
}
