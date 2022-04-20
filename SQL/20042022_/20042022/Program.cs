using _20042022.Data.DAL;
using _20042022.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _20042022
{
    internal class Program
    {
        static void Main(string[] args)
        {
            EntityDbContext context = new EntityDbContext();

            bool menu = true;
            while (menu)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("---> Menu <---");
                Console.WriteLine(" 1. Stadion əlavə et");
                Console.WriteLine(" 2. Stadionları göstər");
                Console.WriteLine(" 3. İstifadəçi əlavə et");
                Console.WriteLine(" 4. İstifadəçiləri göstər");
                Console.WriteLine(" 5. Rezervasiyaları göstər");
                Console.WriteLine(" 6. Rezervasiya yarat");
                Console.WriteLine(" 7. Verilmiş id-li stadionun rezervasiyalarını göstər");
                Console.WriteLine(" 8. Verilmiş id-li userin rezervasiyalarını göstər");
                Console.WriteLine(" 9. Verilmiş id-li rezervasiyanı sil");
                Console.WriteLine(" 0. Programdan cix");
                Console.ForegroundColor = ConsoleColor.White;
                string choise = Console.ReadLine();
                switch (choise)
                {
                    case "1":
                        Console.WriteLine("Stadion name daxil edin :");
                        string name = Console.ReadLine();
                        Console.WriteLine("Stadion capacity daxil edin :");
                        int capacity = int.Parse(Console.ReadLine());
                        Console.WriteLine("Stadion hour price daxil edin :");
                        decimal hourPrice = decimal.Parse(Console.ReadLine());
                        context.Stadions.Add(new Stadion() { Name = name, Capacity = capacity, HourPrice = hourPrice });
                        context.SaveChanges();
                        break;
                    case "2":
                        Console.WriteLine("Butun stadionlar");
                        foreach (Stadion stadion in context.Stadions.ToList())
                        {
                            Console.WriteLine($"Id : {stadion.Id},Name : {stadion.Name},Capacity : {stadion.Capacity}, HourPrice : {stadion.HourPrice}");
                        }
                        break;
                    case "3":
                        Console.WriteLine("User Fullname daxil edin :");
                        string fullname = Console.ReadLine();
                        Console.WriteLine("User email daxil edin :");
                        string email = Console.ReadLine();
                        context.Users.Add(new User() { Fullname = fullname, Email = email });
                        context.SaveChanges();
                        break;
                    case "4":
                        Console.WriteLine("Butun Userler");
                        foreach (User user in context.Users.ToList())
                        {
                            Console.WriteLine($"Id :{user.Id},Fullanme : {user.Fullname}, Email : {user.Email}");
                        }
                        break;
                    case "5":
                        Console.WriteLine("Butun reservesiyalar");
                        foreach (Reservation reservation in context.Reservations.ToList())
                        {
                            Console.WriteLine($"Id : {reservation.Id},StadionId : {reservation.StadionId},UserId : {reservation.UserId},StartDate : {reservation.StartDate},EndDate : {reservation.EndDate}");
                        }
                        break;
                    case "6":
                        Console.WriteLine("Reservation stadionId daxil edin :");
                        int stadionId = int.Parse(Console.ReadLine());
                        Console.WriteLine("Reservation userId daxil edin :");
                        int userId = int.Parse(Console.ReadLine());
                        Console.WriteLine("Reservation StartDate daxil edin :");
                        DateTime startDate = DateTime.Parse(Console.ReadLine());
                        Console.WriteLine("Reservation EndDate daxil edin :");
                        DateTime endDate = DateTime.Parse(Console.ReadLine());
                        context.Reservations.Add(new Reservation() { StadionId = stadionId, UserId = userId, StartDate = startDate, EndDate = endDate });
                        context.SaveChanges();
                        break;
                    case "7":
                        Console.WriteLine("Reservasiyanin stadion id-si :");
                        int stId = int.Parse(Console.ReadLine());
                        List<Reservation> reservations = context.Reservations.Where(x => x.StadionId == stId).ToList();
                        foreach (Reservation reservation in reservations)
                        {
                            Console.WriteLine($"Id : {reservation.Id},StadionId : {reservation.StadionId},UserId : {reservation.UserId},StartDate : {reservation.StartDate},EndDate : {reservation.EndDate}");
                        }
                        break;
                    case "8":
                        Console.WriteLine("Reservasiyanin user id - si :");
                        int usId = int.Parse(Console.ReadLine());
                        List<Reservation> reservations1 = context.Reservations.Where(x => x.UserId == usId).ToList();
                        foreach (Reservation reservation in reservations1)
                        {
                            Console.WriteLine($"Id : {reservation.Id},StadionId : {reservation.StadionId},UserId : {reservation.UserId},StartDate : {reservation.StartDate},EndDate : {reservation.EndDate}");
                        }
                        break;
                    case "9":
                        Console.WriteLine("Silmek istediyiniz reservasiyanin id-si :");
                        int delId = int.Parse(Console.ReadLine());
                        Reservation reservdel = context.Reservations.FirstOrDefault(x => x.Id == delId);
                        if (reservdel != null)
                        {
                            context.Reservations.Remove(reservdel);
                        }
                        context.SaveChanges();
                        break;
                    case "0":
                        menu = false;
                        break;
                    default:
                        break;
                }
            }

        }
    }
}

