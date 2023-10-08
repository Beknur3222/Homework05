using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Homework05
{
    internal class Program
    {
        static void Exepml01()
        {
            try
            {
                // Здесь выполняется HTTP-запрос к несуществующему ресурсу
                using (var client = new WebClient())
                {
                    string result = client.DownloadString("http://example.com/nonexistent");
                    Console.WriteLine(result);
                }
            }
            catch (WebException ex)
            {
                // Обработка исключения WebException, которое возникает при ошибках HTTP-запросов
                Console.WriteLine("Произошла ошибка: " + ex.Message);
            }
            catch (Exception ex)
            {
                // Обработка других исключений, если они возникнут
                Console.WriteLine("Произошла непредвиденная ошибка: " + ex.Message);
            }
        }

        static void Exepml02()
        {
            int[] array = { 1, 2, 3, 4, 5 };
            int index = 10; // Попытка обратиться к элементу массива, выходящему за его пределы

            try
            {
                int value = array[index]; // Попытка обращения к элементу массива
                Console.WriteLine("Значение элемента: " + value);
            }
            catch (IndexOutOfRangeException ex)
            {
                // Обработка исключения IndexOutOfRangeException, которое возникает при выходе за пределы массива
                Console.WriteLine("Произошла ошибка: " + ex.Message);
            }
            finally
            {
                // Финальный блок, который будет выполнен независимо от того, было исключение или нет
                Console.WriteLine("Завершение обработки массива");
            }
        }

        static void MethodWithException()
        {
            Console.WriteLine("Метод MethodWithException начал выполнение.");
            throw new Exception("Это исключение было сгенерировано в методе MethodWithException.");
        }

        // Метод, который вызывает MethodWithException и "поднимает" исключение
        static void CallerMethod()
        {
            try
            {
                Console.WriteLine("Метод CallerMethod начал выполнение.");
                MethodWithException(); // Вызываем метод, который генерирует исключение
                Console.WriteLine("Этот код не будет выполнен из-за исключения.");
            }
            catch (Exception ex)
            {
                // Обработка исключения, поднятого из MethodWithException
                Console.WriteLine("Произошла ошибка: " + ex.Message);
            }
        }

        static void Exepml03()
        {
            try
            {
                CallerMethod(); // Вызываем метод, который "поднимает" исключение
            }
            catch (Exception ex)
            {
                // Обработка исключения в методе Main (если требуется)
                Console.WriteLine("Произошла ошибка в методе Main: " + ex.Message);
            }
            finally
            {
                Console.WriteLine("Завершение программы.");
            }
        }

        // Метод, который генерирует исключение
        static void ThrowException()
        {
            Console.WriteLine("Метод ThrowException начал выполнение.");
            throw new Exception("Это исключение было сгенерировано в методе ThrowException.");
        }

        // Метод, который вызывает ThrowException и "поднимает" исключение вверх
        static void CallAndRethrowException()
        {
            Console.WriteLine("Метод CallAndRethrowException начал выполнение.");
            try
            {
                ThrowException(); // Вызываем метод, который генерирует исключение
            }
            catch (Exception ex)
            {
                // Перехватываем исключение и передаем его выше
                Console.WriteLine("Метод CallAndRethrowException перехватил исключение.");
                throw ex;
            }
        }

        static void Exepml04()
        {
            try
            {
                Console.WriteLine("Главный метод Main начал выполнение.");
                CallAndRethrowException(); // Вызываем метод, который "поднимает" исключение
            }
            catch (Exception ex)
            {
                // Обработка исключения в методе Main
                Console.WriteLine("Произошла ошибка в методе Main: " + ex.Message);
            }
            finally
            {
                Console.WriteLine("Завершение программы.");
            }
        }

        //--------------------------------------------------------------------------------
        // Метод, который генерирует исключение
        static void MethodThatThrowsException()
        {
            Console.WriteLine("Метод MethodThatThrowsException начал выполнение.");
            throw new Exception("Это исключение было сгенерировано в методе MethodThatThrowsException.");
        }

        // Метод, который вызывает MethodThatThrowsException и "поднимает" исключение вверх
        static void CallerMethod2()
        {
            Console.WriteLine("Метод CallerMethod начал выполнение.");
            try
            {
                MethodThatThrowsException(); // Вызываем метод, который генерирует исключение
            }
            catch (Exception ex)
            {
                // Перехватываем исключение и выбрасываем его снова
                Console.WriteLine("Метод CallerMethod перехватил исключение.");
                throw ex;
            }
        }

        static void Work()
        {
            try
            {
                Console.WriteLine("Главный метод Main начал выполнение.");
                CallerMethod2(); // Вызываем метод, который "поднимает" исключение
            }
            catch (Exception ex)
            {
                // Обработка исключения в методе Main
                Console.WriteLine("Произошла ошибка в методе Main: " + ex.Message);
            }
            finally
            {
                Console.WriteLine("Завершение программы.");
            }
        }
        static void Main(string[] args)
        {
            Exepml01();
            Exepml02();
            Exepml03();
            Exepml04();
            Work();
        }
    }
}
