using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eleventh_Laboratory
{
    public static class Menu
    {
        private static string[] errorMessages = { "Вы ввели не число.", "Число выходит за границы допустимого диапазона." };

        public static bool ValidateDataDouble(double number, double min, double max)
        {
            return min <= number && number <= max;
        }

        public static double InputDoubleNumber(string message, string errorMessage)
        {
            bool isRead = false;
            double number;
            do
            {
                Console.WriteLine(message);
                isRead = double.TryParse(Console.ReadLine(), out number);
                if (!isRead)
                    Console.WriteLine(errorMessage);
            } while (!isRead);
            return number;
        }

        public static double InputAndValidateDoubleNumber(double min, double max, string message)
        {
            double number;
            bool isRead = false;
            bool isValid = false;
            do
            {
                Console.WriteLine(message);
                isRead = double.TryParse(Console.ReadLine(), out number);
                if (!isRead)
                    Console.WriteLine(errorMessages[0]);
                else
                {
                    isValid = ValidateDataDouble(number, min, max);
                    if (!isValid)
                        Console.WriteLine(errorMessages[1]);
                }
            } while (!isRead && !isValid);
            return number;
        }

        public static bool ValidateDataInt(int number, int min, int max)
        {
            return min <= number && number <= max;
        }

        public static int InputIntNumber(string message, string errorMessage)
        {
            bool isRead = false;
            int number;
            do
            {
                Console.WriteLine(message);
                isRead = Int32.TryParse(Console.ReadLine(), out number);
                if (!isRead)
                    Console.WriteLine(errorMessage);
            } while (!isRead);
            return number;
        }

        public static int InputAndValidateIntNumber(int min, int max, string message)
        {
            int number;
            bool isRead = false;
            bool isValid = false;
            do
            {
                Console.WriteLine(message);
                isRead = Int32.TryParse(Console.ReadLine(), out number);
                if (!isRead)
                    Console.WriteLine(errorMessages[0]);
                else
                {
                    isValid = ValidateDataDouble(number, min, max);
                    if (!isValid)
                        Console.WriteLine(errorMessages[1]);
                }
            } while (!isRead && !isValid);
            return number;
        }

        public static String InputString(string message)
        {
            Console.WriteLine(message);
            String input = Console.ReadLine();
            return input;
        }

        public static void ShowOptions()
        {
            Console.WriteLine("1. Создать коллекцию ArrayList.\n" +
                "2. Вывести коллекцию ArrayList.\n" +
                "3. Добавить элемент в коллекцию ArrayList.\n" +
                "4. Удалить элемент из коллекции ArrayList.\n" +
                "5. Вывести названия городов заданной области в коллекции ArrayList.\n" +
                "6. Вычислить суммарное количество жителей всех городов в области в коллекции ArrayList.\n" +
                "7. Найти среднюю площадь мегаполисов в коллекции ArrayList.\n" +
                "8. Склонировать коллекцию ArrayList и произвести ее поверхностное копирование.\n" +
                "9. Найти указанный элемент в коллекции ArrayList и отсортировать ее.\n" +
                "10. Создать обобщенную коллекцию Dictionary<K,T>.\n" +
                "11. Вывести обобщенную коллекцию Dictionary<K,T>.\n" +
                "12. Добавить элемент в обобщенную коллекцию Dictionary<K,T>.\n" +
                "13. Удалить элемент из обобщенной коллекции Dictionary<K,T>.\n" +
                "14. Вывести названия городов заданной области в обобщенной коллекции Dictionary<K,T>.\n" +
                "15. Вычислить суммарное количество жителей всех городов в области в обобщенной коллекции Dictionary<K,T>.\n" +
                "16. Найти среднюю площадь мегаполисов в обобщенной коллекции Dictionary<K,T>.\n" +
                "17. Склонировать обобщенную коллекцию Dictionary<K,T> и произвести ее поверхностное копирование.\n" + 
                "18. Найти указанный элемент в обобщенной коллекции Dictionary<K,T> и отсортировать ее.\n" +
                "19. Создать экзепляр класса TestCollections.\n" +
                "20. Вывести объект класса TestCollections.\n" +
                "21. Добавить элемент в объект класса TestCollections.\n" +
                "22. Удалить элемент в объекте класса TestCollections.\n" +
                "23. Измерить время поиска первого, центрального, последнего элементов и элемента, не входящего в TestCollections.\n" + 
                "24. Очистить консоль.\n" +
                "25. Выход.\n");
        }
    }
}