using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using Stadion.Data;

namespace Stadion.CRUD
{
    internal class SelectReservationsByUserId
    {
        public static void GetReservationsByUserId(int userId)
        {
            Database db = new Database();
            using (SqlConnection con = new SqlConnection(db.connectionStr))
            {
                con.Open();
                string query = $"SELECT * FROM Reservations WHERE UserId = {userId}";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    SqlDataReader sqlDataReader = cmd.ExecuteReader();
                    if (sqlDataReader.HasRows)
                    {
                        while (sqlDataReader.Read())
                        {
                            int id = sqlDataReader.GetInt32(0);
                            int stadionId = sqlDataReader.GetInt32(1);
                            int userid = sqlDataReader.GetInt32(2);
                            DateTime startDate = sqlDataReader.GetDateTime(3);
                            DateTime endDate = sqlDataReader.GetDateTime(4);
                            Reservations reservation = new Reservations()
                            {
                                Id = id,
                                StadionId = stadionId,
                                UserId = userid,
                                StartDate = startDate,
                                EndDate = endDate
                            };
                            reservation.ShowInfo();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Tapilmadi");
                    }
                }
            }

        }
    }
}
