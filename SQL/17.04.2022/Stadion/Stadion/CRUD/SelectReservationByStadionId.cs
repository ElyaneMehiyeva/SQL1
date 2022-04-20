using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using Stadion.Data;
namespace Stadion.CRUD
{
    internal class SelectReservationByStadionId
    {
        public static void GetReservationByStadionId(int id)
        {
            Database db = new Database();

            using (SqlConnection con = new SqlConnection(db.connectionStr))
            {
                con.Open();
                string query = $"SELECT * FROM Reservations WHERE StadionId = {id}";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    SqlDataReader dataReader = cmd.ExecuteReader();
                    if (dataReader.HasRows)
                    {
                        while (dataReader.Read())
                        {
                            int reservationId = dataReader.GetInt32(0);
                            int stadionId = dataReader.GetInt32(1);
                            int userId = dataReader.GetInt32(2);
                            DateTime startDate = dataReader.GetDateTime(3);
                            DateTime endDate = dataReader.GetDateTime(4);
                            Reservations reservation = new Reservations()
                            {
                                Id = reservationId,
                                StadionId = stadionId,
                                UserId = userId,
                                StartDate = startDate,
                                EndDate = endDate
                            };
                            reservation.ShowInfo();
                        }
                    } else
                    {
                        Console.WriteLine("Tapilmadi");
                    }
                }
            }
        }
    }
}
