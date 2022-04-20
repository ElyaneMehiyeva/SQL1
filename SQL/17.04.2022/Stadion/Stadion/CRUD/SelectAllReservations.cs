using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using Stadion.Data;

namespace Stadion.CRUD
{
    internal class SelectAllReservations
    {
        public static void AllReservations()
        {
            Database db = new Database();
            using(SqlConnection con = new SqlConnection(db.connectionStr))
            {
                con.Open();
                string query = "SELECT * FROM Reservations";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    SqlDataReader sqlDataReader = cmd.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        int id = sqlDataReader.GetInt32(0);
                        int stadionId = sqlDataReader.GetInt32(1);
                        int userId = sqlDataReader.GetInt32(2);
                        DateTime startDate = sqlDataReader.GetDateTime(3);
                        DateTime endDate = sqlDataReader.GetDateTime(4);
                        Reservations reservation = new Reservations()
                        {
                            Id = id,
                            StadionId = stadionId,
                            UserId = userId,
                            StartDate = startDate,
                            EndDate = endDate
                        };
                        reservation.ShowInfo();
                    }
                    sqlDataReader.Close();
                }                            
            }
        }
    }
}
