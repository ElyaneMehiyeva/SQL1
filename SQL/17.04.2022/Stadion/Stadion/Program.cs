using System;
using System.Text;
using Stadion.CRUD;
namespace Stadion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            bool menu = true;
            while (menu)
            {
                Menu();
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        break;
                    case "2":
                        Console.WriteLine("Butun stadionlar");
                        SelectAllStadions.AllStadions();
                        break;
                    case "3":
                        break;
                    case "4":
                        Console.WriteLine("Butun userler");
                        SelectAllUsers.AllUsers();
                        break;
                    case "5":
                        Console.WriteLine("Butun reservasiyalar");
                        SelectAllReservations.AllReservations();
                        break;
                    case "6":
                        break;
                    case "7":
                        Console.WriteLine("Stadion id daxil edin :");
                        int stadionId = int.Parse(Console.ReadLine());
                        SelectReservationByStadionId.GetReservationByStadionId(stadionId);
                        break;
                    case "8":
                        Console.WriteLine("User id daxil edin :");
                        int userId = int.Parse(Console.ReadLine());
                        SelectReservationsByUserId.GetReservationsByUserId(userId);
                        break;
                    case "9":
                        Console.WriteLine("Rezervasiya id daxil edin :");
                        int reservationId = int.Parse(Console.ReadLine());
                        DeleteReservationById.Delete(reservationId);
                        break;
                    case "0":
                        Console.WriteLine("Sistem dayandirildi !");
                        menu = false;
                        break;
                    default:
                        Console.WriteLine("Yanlish secimdir !");
                        break;
                }
            }
        }

        static void Menu()
        {
            Console.WriteLine("Menu");
            Console.WriteLine(" 1. Stadion əlavə et");
            Console.WriteLine(" 2. Stadionları göstər"); // +
            Console.WriteLine(" 3. İstifadəçi əlavə et");
            Console.WriteLine(" 4. İstifadəçiləri göstər"); // +
            Console.WriteLine(" 5. Rezervasiyaları göstər"); // +
            Console.WriteLine(" 6. Rezervasiya yarat");
            Console.WriteLine(" 7. Verilmiş id-li stadionun rezervasiyalarını göstər"); // +
            Console.WriteLine(" 8. Verilmiş id-li userin rezervasiyalarını göstər "); // +
            Console.WriteLine(" 9. Verilmiş id-li rezervasiyanı sil"); // +
            Console.WriteLine(" 0. Sistemi dayandir"); // +
        }

    }
}
