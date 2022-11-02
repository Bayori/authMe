using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace authMe
{
    class Program
    {      
        static void Main(string[] args)
        {
        menu:
            Console.WriteLine("Добро пожаловать! Пожалуйста, зарегистрируйтесь.\n[1] Справка\n[2] Перейти к регистрации");

            switch (Convert.ToInt32(Console.ReadLine()))
            {
                case 1: // Справка
                    {
                        Console.Clear();
                        Console.WriteLine("[Логин]\n- Длина: От 6 до 20 символов\n- Разрешенные символы: Латиница нижнего регистра, цифры");
                        Console.WriteLine("\n[Пароль]\n- Длина: От 6 до 20 символов\n- Должна быть хотя бы одна буква латиницы верхнего регистра\n- Не должен совпадать с логином\n- Не может быть пустым\n- Не должен содержать пробелы");
                        Console.WriteLine("\nНажмите Enter для возврата в меню");
                        switch (Console.ReadLine())
                        {  
                            default: Console.Clear(); goto menu;
                        }
                    }
                
                default: break;
            }
            Console.Clear();
            login:
            Console.Write("Введите логин: ");
            string _input = Console.ReadLine();
            char[] logArr; // Начало работы с Логином
            logArr = _input.ToCharArray(); // Конвертация вводимых данных (string) -> в массив типа char

            if (logArr.Length < 6 || logArr.Length > 20) // Проверка на длину логина
            {
                Console.Clear();
                Console.WriteLine("Разрешённая длина логина: От 6 до 20 символов!\n");
                goto login;
            }
            for (int i = 0; i < logArr.Length; i++) // Перебираем каждый символ логина
            {
                if ((logArr[i] >= 'a' && logArr[i] <= 'z') || (logArr[i] >= '0' && logArr[i] <= '9')) // Проверка на разрешенные символы ввода
                {
                    Console.Clear();
                    Console.Write("Логин введён успешно! Добро пожаловать, ");
                    Console.WriteLine(logArr); // (Нельзя уместить в одном операторе строку и массив, поэтому два оператора вывода строки)
                    
                }
                else // Проверка на ввод запрещенных символов
                {
                    Console.Clear();
                    Console.WriteLine("Логин содержит недопустимые символы!\n");
                    goto login;
                }
            } // Конец цикла

            string login = Convert.ToString(logArr);
            
        pass:     
            Console.Write("\nВведите пароль: "); // Начало работы с паролем
            _input = Console.ReadLine();
            char[] passArr;
            passArr = _input.ToCharArray(); // Конвертация вводимых данных (string) -> в массив типа char
            string _login = new String(logArr); // Конвертация массивов в строки
            string _pass = new String(passArr);

            if (_pass == _login) // Сравнение логина с паролем
            {
                Console.Clear();
                Console.WriteLine("Логин и пароль совпадают");
                goto pass;
            }

            if (passArr.Length < 6 || passArr.Length > 20)
            {
                Console.Clear();
                Console.WriteLine("Разрешённая длина пароля: От 6 до 20 символов!");
                goto pass;
            }          
            for (int i = 0; i < passArr.Length; i++)
            {
                if (passArr[i] >= 'a' && passArr[i] <= 'z' || passArr[i] >= 'A' && passArr[i] <= 'Z' || (passArr[i] >= '0' && passArr[i] <= '9') || (passArr[i] == '!' || passArr[i] == '@' || passArr[i] == '#' || passArr[i] == '$' || passArr[i] == '%' || passArr[i] == '^' || passArr[i] == '&' || passArr[i] == '*'))
                {
                    for (int j = 0; j < passArr.Length; j++)
                    {
                        if (passArr[j] >= 'A' && passArr[j] <= 'Z' || (passArr[j] >= '0' && passArr[j] <= '9') || (passArr[j] == '!' || passArr[j] == '@' || passArr[j] == '#' || passArr[j] == '$' || passArr[j] == '%' || passArr[j] == '^' || passArr[j] == '&' || passArr[j] == '*'))
                        {
                            Console.Clear();
                            Console.WriteLine("Регистрация завершена успешно!");
                            return;
                        }
                    }
                }
                Console.Clear();
                Console.WriteLine("Неверный ввод");
                goto pass;
            } // Конец цикла
        }
        }
    }

