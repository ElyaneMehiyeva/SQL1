using System;
using System.Collections.Generic;
using System.Text;

namespace Stadion.Data
{
    internal class Reservations
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int StadionId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public void ShowInfo()
        {
            Console.WriteLine($"Id :{Id}, UserId :{UserId}, StadionId :{StadionId}, StartDate :{StartDate}, EndDate :{EndDate}");
        }
    }
}
