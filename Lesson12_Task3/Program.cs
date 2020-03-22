using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lesson12_Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            Action CalculateCoronavirusSickQtyDelegate = new Action(CalculateCoronavirusSickQtyAsync);

            Action AliveMethodDelegate = new Action(AliveStatusAsync);

            CalculateCoronavirusSickQtyDelegate.Invoke();

            AliveMethodDelegate.Invoke();

            


            Console.ReadLine();
        }

        static void CalculateCoronavirusSickQty()
        {
             
            Console.WriteLine("Запуск метода подсчета больных коронавирусом в потоке: "+ Thread.CurrentThread.ManagedThreadId);
            int qtyKorona2203200000 = 307000;
            DateTime zeropoint = new DateTime(2020, 3, 22, 00, 00, 00);
            TimeSpan timeDifference = DateTime.Now - zeropoint;

            double newSickQty = 1.3 * (Convert.ToInt32(timeDifference.TotalSeconds) - 1);
            int actualKoronaQty = (int)(qtyKorona2203200000 + newSickQty);
            Console.WriteLine("Количество больных коронавирусом " + actualKoronaQty);
        
            
        }

        static void AliveStatus()
        {
            
                for (int i = 0; i < 1000; i++)
                {
                    Console.WriteLine($"Это поток {Thread.CurrentThread.ManagedThreadId} второго метода AliveStatus");
                    Thread.Sleep(1000);
                }
            
        }

        static async  void CalculateCoronavirusSickQtyAsync()
        {
            await Task.Run(() => CalculateCoronavirusSickQty());
        }

        static async void AliveStatusAsync()
        {
            await Task.Run(() => AliveStatus());
        }
    

    }
}
