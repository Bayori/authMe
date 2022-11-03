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
            int lenght = login.Length;
            if (lenght < 6 || lenght > 20) // Длина строки
            {
                return false;
            }
            Regex l = new Regex("[ A-Z ]"); // Если есть заглавные буквы или пробелы
            Match m = l.Match(login);
            if (m.Success)
            {
                return false;
            }
            return true;
        }

        static bool isValidPassword(string password, string login)
        {
            int lenght = password.Length;
            if (lenght < 6 || lenght > 20) // Длина строки
            {
                return false;
            }
            if (password == login) // Сравнение строк логина и пароля
            {
                return false;
            }
            Regex w = new Regex(" "); // Проверка на пробел.ы
            Match m = w.Match(password);
            if (m.Success)
            {
                return false;
            }
            Regex p = new Regex("[A-Z]"); // Проверка на верхний регистр
            MatchCollection total = p.Matches(password);
            if (total.Count > 0)
            {   
                return true;
            }
            return false;        
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
