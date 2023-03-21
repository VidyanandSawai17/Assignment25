using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Assignment25
{
    //Multithreading : multiple threads working simultaniously is called as Multithreading
    //                 Execution of multiple thread at same time

    //When to use multithreading ? → when we want to execute multiple task at same time
    //                 Save the application time
    //                 All the tasks are independent task, so can run concurrently

    //Thread is a light weight ,containing a single task..

    public class Tasks
    {
        public void Display1To5()
        {
            Thread thread = Thread.CurrentThread;
            Console.WriteLine(thread.Name);
            for (int i = 1; i <= 5; i++)
            {
                Console.WriteLine(i);
                Thread.Sleep(2000);
            }
        }
        public void Display6To10()
        {
            Thread thread = Thread.CurrentThread;
            Console.WriteLine(thread.Name);
            for (int i = 6; i <= 10; i++)
            {
                Console.WriteLine(i);
                Thread.Sleep(2000);
            }
        }
    }


    public class Program
    {
        static void Main(string[] args)
        {
            Tasks task1 = new Tasks();
            Thread t1 = new Thread(new ThreadStart(task1.Display1To5));
            Thread t2 = new Thread(new ThreadStart(task1.Display6To10));
            Thread t3 = new Thread(new ThreadStart(task1.Display1To5));
            t1.Name = "Display1-5";
            t2.Name = "Display6-10";
            t3.Name = "Thread 3";

            //Join();  → when we want to block the execution of another thread we will use Join();

            //t1.Priority = ThreadPriority.Lowest;
            //t2.Priority = ThreadPriority.Highest;
            //t1.Join(); // till t1 will complete the task t2 & t3 will remain block
            t1.Join(3000); // block the execution of another thread for 3s
            t1.Start();
            t2.Start();
            t3.Start();
        }
    }
}
