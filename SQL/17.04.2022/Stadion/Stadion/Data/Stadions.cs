using System;
using System.Collections.Generic;
using System.Text;

namespace Stadion.Data
{
    internal class Stadions
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal HourPrice { get; set; }
        public int Capacity { get; set; }


        public void ShowInfo()
        {
            Console.WriteLine($"Id :{Id}, Name :{Name}, HourPrice :{HourPrice}, Capacity :{Capacity}");
        }
    }
}
