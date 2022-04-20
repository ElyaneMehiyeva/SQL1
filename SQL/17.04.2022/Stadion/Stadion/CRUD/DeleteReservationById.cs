using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Stadion.CRUD
{
    internal class DeleteReservationById
    {
        public static void Delete(int id)
        {
            Database db = new Database();
            using (SqlConnection con = new SqlConnection(db.connectionStr))
            {
                con.Open();
                string query = $"DElETE FROM Reservations WHERE Id = {id}";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    var result = cmd.ExecuteNonQuery();
                    Console.WriteLine($"{result} reservation silindi");
                }
            }
        }
    }
}
