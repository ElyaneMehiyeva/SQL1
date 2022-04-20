using System;
using System.Collections.Generic;
using System.Text;

namespace _20042022.Data.Entities
{
    internal class Stadion
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal HourPrice { get; set; }
        public int Capacity { get; set; }
    }
}
