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
                
                using (var client = new WebClient())
                {
                    string result = client.DownloadString("https://www.google.kz/?hl=ru");
                    Console.WriteLine(result);
                }
            }
            catch (WebException ex)
            {
    
                Console.WriteLine("Произошла ошибка: " + ex.Message);
            }
            catch (Exception ex)
            {
             
                Console.WriteLine("Произошла непредвиденная ошибка: " + ex.Message);
            }
        }

        static void Exepml02()
        {
            int[] array = { 1, 2, 3, 4, 5 };
            int index = 10; 

            try
            {
                int value = array[index]; 
                Console.WriteLine("Значение элемента: " + value);
            }
            catch (IndexOutOfRangeException ex)
            {
              
                Console.WriteLine("Произошла ошибка: " + ex.Message);
            }
            finally
            {
                
                Console.WriteLine("Завершение обработки массива");
            }
        }

        static void MethodWithException()
        {
            Console.WriteLine("Метод MethodWithException начал выполнение.");
            throw new Exception("Это исключение было сгенерировано в методе MethodWithException.");
        }

        
        static void CallerMethod()
        {
            try
            {
                Console.WriteLine("Метод CallerMethod начал выполнение.");
                MethodWithException(); 
                Console.WriteLine("Этот код не будет выполнен из-за исключения.");
            }
            catch (Exception ex)
            {
                
                Console.WriteLine("Произошла ошибка: " + ex.Message);
            }
        }

        static void Exepml03()
        {
            try
            {
                CallerMethod();
            }
            catch (Exception ex)
            {
               
                Console.WriteLine("Произошла ошибка в методе Main: " + ex.Message);
            }
            finally
            {
                Console.WriteLine("Завершение программы.");
            }
        }

       
        static void ThrowException()
        {
            Console.WriteLine("Метод ThrowException начал выполнение.");
            throw new Exception("Это исключение было сгенерировано в методе ThrowException.");
        }

        
        static void CallAndRethrowException()
        {
            Console.WriteLine("Метод CallAndRethrowException начал выполнение.");
            try
            {
                ThrowException(); 
            }
            catch (Exception ex)
            {
                
                Console.WriteLine("Метод CallAndRethrowException перехватил исключение.");
                throw ex;
            }
        }

        static void Exepml04()
        {
            try
            {
                Console.WriteLine("Главный метод Main начал выполнение.");
                CallAndRethrowException(); 
            }
            catch (Exception ex)
            {
                
                Console.WriteLine("Произошла ошибка в методе Main: " + ex.Message);
            }
            finally
            {
                Console.WriteLine("Завершение программы.");
            }
        }

     
        static void MethodThatThrowsException()
        {
            Console.WriteLine("Метод MethodThatThrowsException начал выполнение.");
            throw new Exception("Это исключение было сгенерировано в методе MethodThatThrowsException.");
        }

       
        static void CallerMethod2()
        {
            Console.WriteLine("Метод CallerMethod начал выполнение.");
            try
            {
                MethodThatThrowsException(); 
            }
            catch (Exception ex)
            {
                
                Console.WriteLine("Метод CallerMethod перехватил исключение.");
                throw ex;
            }
        }

        static void Work()
        {
            try
            {
                Console.WriteLine("Главный метод Main начал выполнение.");
                CallerMethod2(); 
            }
            catch (Exception ex)
            {
                
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
