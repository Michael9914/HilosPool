using System;
using System.IO;
using System.Threading;

namespace HilosPool
{
    class Program
    {
        const string path = @"D:\Archivos de programa\trabajo";
        static void Main(string[] args)
        {
            for (int i=0; i<=50; i++) 
            {
                ThreadPool.QueueUserWorkItem(CrearTxt, i);
            }
            while (ThreadPool.PendingWorkItemCount > 0) ;


        }
        static void CrearTxt(object data)
        {
            int i = (int)data;

            using (var sw = new StreamWriter(path+i+".txt"))
            {
                sw.WriteLine("Buenas, soy el hilo: "+Thread.CurrentThread.ManagedThreadId);
            }
            Console.WriteLine("Buenas, soy el hilo: " + Thread.CurrentThread.ManagedThreadId);

        }
    }
}
