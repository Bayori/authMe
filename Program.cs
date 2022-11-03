using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
namespace authMe
{
    class Program
    {
        static bool isValidLogin(string login)
        {
            
            if (login.Length < 6 || login.Length > 20) // Длина строки
            {
                return false;
            }
            
            if (Regex.IsMatch(login, "[A-Z ]")) // Если есть заглавные буквы или пробелы
            {
                return false;
            }
            return true;
        }

        static bool isValidPassword(string password, string login)
        {
            if (password.Length < 6 || password.Length > 20) // Длина строки
            {
                return false;
            } 
            if (Regex.IsMatch(password, " ")) // Проверка на пробел.ы
            {
                return false;
            }
            if (!Regex.IsMatch(password, "[A-Z]")) // Проверка на верхний регистр
            {   
                return false;
            }
            return true;        
        }
        static void Main(string[] args)
        {
            Console.Write("login: ");
            string login = Console.ReadLine();

            if (isValidLogin(login)) // Проверка на валидность
            {
                Console.WriteLine("Login is valid");
            }
            else
            {
                Console.WriteLine("Login is invalid");
                return;
            }

            Console.Write("password: ");
            string password = Console.ReadLine();
            
            if (isValidPassword(password, login)) // Проверка на валидность
            {
                Console.WriteLine("Password is valid");
            }
            else
            {
                Console.WriteLine("Password is invalid");
            }
            return;
        }
    }
}
